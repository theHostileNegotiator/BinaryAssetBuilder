using BinaryAssetBuilder.Core;
using BinaryAssetBuilder.Core.Diagnostics;
using BinaryAssetBuilder.Core.Hashing;
using Relo;
using SageBinaryData;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using System.Xml.XPath;

namespace BinaryAssetBuilder.XmlCompiler;

public class Plugin : IAssetBuilderPlugin
{
    public unsafe delegate void MarshalDelegate<T>(Node node, T* objT, Tracker state) where T : unmanaged;

    private static readonly Tracer _tracer = Tracer.GetTracer(nameof(XmlCompiler), "Marshals XML data into binary data structures.");
    // private static readonly int _win32 = 0;
    private static readonly int _xbox360 = 2;
    private static readonly int _xmlCompilerVersion = 1;
    private static readonly IDictionary<uint, MethodInfo> _handleMethods = new SortedDictionary<uint, MethodInfo>();
    private static readonly IDictionary<uint, Delegate> _marshalMethods = new SortedDictionary<uint, Delegate>();
    private static readonly IDictionary<uint, ExtendedTypeInformation> _extendedTypeInformations = new SortedDictionary<uint, ExtendedTypeInformation>();

    private TargetPlatform _platform;

#if TIBERIUMWARS
    public uint AllTypesHash => 0xEB19D975u; // TW 1.09
#elif KANESWRATH
    public uint AllTypesHash => 0x12B3E763u; // KW 1.02
#else
#error No game set in configuration.
#endif
    public uint VersionNumber => 1;

    private static void SetTypeHash(ExtendedTypeInformation typeInformation, uint num, uint tw, uint kw)
    {
#if TIBERIUMWARS
        typeInformation.ProcessingHash = num ^ tw;
        typeInformation.TypeHash = tw;
#elif KANESWRATH
        typeInformation.ProcessingHash = num ^ kw;
        typeInformation.TypeHash = kw;
#else
        throw new NotImplementedException();
#endif
    }

    private static unsafe void WriteAssetBuffer(AssetBuffer buffer, Tracker tracker)
    {
        Chunk chunk = new();
        tracker.MakeRelocatable(chunk);
        buffer.InstanceData = chunk.InstanceBuffer;
        if (chunk.RelocationBuffer.Length > 0)
        {
            buffer.RelocationData = chunk.RelocationBuffer;
        }
        else
        {
            buffer.RelocationData = Array.Empty<byte>();
        }
        if (chunk.ImportsBuffer.Length > 0)
        {
            buffer.ImportsData = chunk.ImportsBuffer;
        }
        else
        {
            buffer.ImportsData = Array.Empty<byte>();
        }
    }

    private static void CreateTypeInfo(Type type, uint num, uint hash, bool hasCustomData)
    {
        string name = type.Name;
        uint typeId = FastHash.GetHashCode(name);
        _extendedTypeInformations.Add(typeId, new ExtendedTypeInformation
        {
            HasCustomData = hasCustomData,
            TypeId = typeId,
            Type = type,
            TypeName = name,
            ProcessingHash = num ^ hash,
            TypeHash = hash
        });
    }

    public void Initialize(TargetPlatform platform)
    {
        _platform = platform;
        uint num = (uint)_xmlCompilerVersion;
        if (_platform == TargetPlatform.Xbox360)
        {
            num += (uint)_xbox360;
        }
        // Pipeline test types START

        // TestGameObject
        // TestTexture
        // TestTextureCollection

        // Pipeline test types END

        foreach ((Type type, uint hash, bool hasCustomData) in new[]
        {
            (typeof(WeaponTemplate),
#if TIBERIUMWARS
            0xE3996069u,
#elif KANESWRATH
            0x90AEAB74u,
#endif
            false),
            (typeof(LocomotorTemplate),
#if TIBERIUMWARS
            0xBD8F61A4u,
#elif KANESWRATH
            0xDC4EEAC2u,
#endif
            false),
            (typeof(GameObject),
#if TIBERIUMWARS
            0x132408DBu,
#elif KANESWRATH
            0x50612DE9u,
#endif
            false),
            (typeof(FXParticleSystemTemplate),
#if TIBERIUMWARS
            0xA148D511u,
#elif KANESWRATH
            0xA0C56702u,
#endif
            false),
            (typeof(Weather),
#if TIBERIUMWARS
            0x368A8BA2u,
#elif KANESWRATH
            0x77FDF1C6u,
#endif
            false),
            (typeof(ShadowMap),
#if TIBERIUMWARS
            0xC6389FA6u,
#elif KANESWRATH
            0xC5C47E46u,
#endif
            false),

            (typeof(W3DContainer), 0x909DD93Fu, false),
            (typeof(W3DHierarchy), 0x3BC26A7Au, false),
            (typeof(W3DCollisionBox), 0xC917E725u, false),
            (typeof(ArmyDefinition),
#if TIBERIUMWARS
            0x57213EA5u,
#elif KANESWRATH
            0x3C1B9C81u,
#endif
            false),
            (typeof(AIPersonalityDefinition),
#if TIBERIUMWARS
            0x7DCE182Fu,
#elif KANESWRATH
            0xC360B65Bu,
#endif
            false),
            (typeof(FXList),
#if TIBERIUMWARS
            0xEBE8A8A4u,
#elif KANESWRATH
            0x8C53C309u,
#endif
            false),
            (typeof(ObjectCreationList),
#if TIBERIUMWARS
            0x683D4DE5u,
#elif KANESWRATH
            0x8B85F295u,
#endif
            false),

            (typeof(SpecialPowerTemplate),
#if TIBERIUMWARS
            0x5EF0ACA9u,
#elif KANESWRATH
            0xC4DCAF5Au,
#endif
            false),
            (typeof(UpgradeTemplate),
#if TIBERIUMWARS
            0x1E53F384u,
#elif KANESWRATH
            0x163BC89Du,
#endif
            false),
            (typeof(SkirmishOpeningMove),
#if TIBERIUMWARS
            0x21EE29FAu,
#elif KANESWRATH
            0x8A31273Fu,
#endif
            false),

            (typeof(AIStrategicStateDefinition),
#if TIBERIUMWARS
            0x1E27DA26u,
#elif KANESWRATH
            0xBB05CCECu,
#endif
            false),
            (typeof(AIBudgetStateDefinition),
#if TIBERIUMWARS
            0xA10F9630u,
#elif KANESWRATH
            0xE565E521u,
#endif
            false),
            (typeof(AITargetingHeuristic),
#if TIBERIUMWARS
            0xB7A2C222u,
#elif KANESWRATH
            0x609F30D5u,
#endif
            false),
            (typeof(GameMap),
#if TIBERIUMWARS
            0x3EC9C79Bu,
#elif KANESWRATH
            0x19F10771u,
#endif
            false),
            (typeof(AttributeModifier),
#if TIBERIUMWARS
            0xD24E7201u,
#elif KANESWRATH
            0x8C925761u,
#endif
            false),
            (typeof(ArmorTemplate),
#if TIBERIUMWARS
            0x9CDD1086u,
#elif KANESWRATH
            0x6D59C409u,
#endif
            false),
            (typeof(MissionTemplate), 0x0D283295u, false),
            (typeof(TheaterOfWarTemplate), 0xE60C9724u, false),
            (typeof(CampaignTemplate), 0xAC60B530u, false),
            (typeof(RadiusCursorLibrary),
#if TIBERIUMWARS
            0xD62B490Fu,
#elif KANESWRATH
            0xF133BF97u,
#endif
            false),
            (typeof(AudioEvent),
#if TIBERIUMWARS
            0x1B886049u,
#elif KANESWRATH
            0xD3FED271u,
#endif
            false),
            (typeof(MusicTrack),
#if TIBERIUMWARS
            0x1469548Au,
#elif KANESWRATH
            0xBCD0A189u,
#endif
            false),
            (typeof(DialogEvent),
#if TIBERIUMWARS
            0x8655CDB4u,
#elif KANESWRATH
            0x666459DDu,
#endif
            false),
            (typeof(AmbientStream),
#if TIBERIUMWARS
            0xDABB1C4Bu,
#elif KANESWRATH
            0x1FBA5E31u,
#endif
            false),
            (typeof(Multisound),
#if TIBERIUMWARS
            0x12B1C67Cu,
#elif KANESWRATH
            0xA503DBF8u,
#endif
            false),
            (typeof(MusicPalette), 0x6A7AF822u, false),
            (typeof(MusicScriptConditionNugget_LocalPlayerIsObserver), 0xAFB6AF3Au, false),
            (typeof(MusicScriptConditionNugget_UnitsFarFromBase),
#if TIBERIUMWARS
            0xD889BF98u,
#elif KANESWRATH
            0x36EB813Fu,
#endif
            false),
            (typeof(MusicScriptConditionNugget_TimeFromStartOfLevel),
#if TIBERIUMWARS
            0xAA4A9E23u,
#elif KANESWRATH
            0x61445394u,
#endif
            false),
            (typeof(MusicScriptConditionNugget_TrackPlayedCount),
#if TIBERIUMWARS
            0x4FCFFAB1u,
#elif KANESWRATH
            0x3C032973u,
#endif
            false),
            (typeof(MusicScriptConditionNugget_SpecificTrackTypePlaying), 0xBCAD9B77u, false),
            (typeof(MusicScriptConditionNugget_AnyTrackPlaying),  0x337BC326u, false),
            (typeof(MusicScriptConditionNugget_ObjectsOfTypeExist),
#if TIBERIUMWARS
            0x9586411Cu,
#elif KANESWRATH
            0x54442549u,
#endif
            false),
            (typeof(MusicScriptConditionNugget_EvaEventPlayedRecently),
#if TIBERIUMWARS
            0x1F200F13u,
#elif KANESWRATH
            0x4A18D4E4u,
#endif
            false),
            (typeof(MusicScriptConditionNugget_ObjectsNearEvaEvent),
#if TIBERIUMWARS
            0x0EC4D160u,
#elif KANESWRATH
            0xA9F67F36u,
#endif
            false),
            (typeof(MusicScriptConditionNugget_ScoredKillCount), 0x5C0F93DCu, false),
            (typeof(MusicScriptConditionNugget_Not),  0xB886383Bu, false),
            (typeof(MusicScriptConditionNugget_Or), 0x81114695u, false),
            (typeof(MusicScriptConditionNugget_And), 0x10173347u, false),
            (typeof(MusicScriptTrack),
#if TIBERIUMWARS
            0x702C8407u,
#elif KANESWRATH
            0x7AC30661u,
#endif
            false),
            (typeof(LocalBuildListMonitor),
#if TIBERIUMWARS
            0x99CC030Au,
#elif KANESWRATH
            0x242B62FDu,
#endif
            false),
            (typeof(MpGameRules),
#if TIBERIUMWARS
            0xEDDBB607u,
#elif KANESWRATH
            0x79D42582u,
#endif
            false),
            (typeof(ExperienceLevelTemplate),
#if TIBERIUMWARS
            0xAE55047Bu,
#elif KANESWRATH
            0xBD7DD70Eu,
#endif
            false),
            (typeof(MissionObjectiveList),
#if TIBERIUMWARS
            0xC385A8C1u,
#elif KANESWRATH
            0xC087BBF2u,
#endif
            false),
            (typeof(StringHashTable),
#if TIBERIUMWARS
            0x2C112832u,
#elif KANESWRATH
            0xCBB109A0u,
#endif
            false),
            (typeof(InGameUISettings),
#if TIBERIUMWARS
            0x49FE3760u,
#elif KANESWRATH
            0xE1800214u,
#endif
            false),
            (typeof(DamageFX),
#if TIBERIUMWARS
            0x4DF81EBDu,
#elif KANESWRATH
            0xEC4577C9u,
#endif
            false),
            (typeof(MultiplayerSettings),
#if TIBERIUMWARS
            0x1BAF4C42u,
#elif KANESWRATH
            0x801CBBCEu,
#endif
            false),
            (typeof(OnlineChatColors), 0xF3645AA7u, false),
            (typeof(MultiplayerColor),
#if TIBERIUMWARS
            0x966F336Au,
#elif KANESWRATH
            0x73A5BE3Cu,
#endif
            false),
            (typeof(GameLODPreset),
#if TIBERIUMWARS
            0x19DAC24Du,
#elif KANESWRATH
            0xD09C0652u,
#endif
            false),
            (typeof(StaticGameLOD),
#if TIBERIUMWARS
            0xBEAF1CC9u,
#elif KANESWRATH
            0x352AA045u,
#endif
            false),
            (typeof(DynamicGameLOD),
#if TIBERIUMWARS
            0x71BAD792u,
#elif KANESWRATH
            0xA2EDC094u,
#endif
            false),
            (typeof(AudioLOD),
#if TIBERIUMWARS
            0x3ABBF00Fu,
#elif KANESWRATH
            0x8F6AD19Du,
#endif
            false),
            (typeof(VideoEventList),
#if TIBERIUMWARS
            0x999FCBE3u,
#elif KANESWRATH
            0x18A04ECCu,
#endif
            false),

            (typeof(PackedTextureImage),
#if TIBERIUMWARS
            0x2FAEB748u,
#elif KANESWRATH
            0x8AA0FF90u,
#endif
            false),
            (typeof(OnDemandTextureImage),
#if TIBERIUMWARS
            0xF3F4AEECu,
#elif KANESWRATH
            0xFBBF792Du,
#endif
            false),

            (typeof(Mouse),
#if TIBERIUMWARS
            0x73FE99B0u,
#elif KANESWRATH
            0xA7B43DE6u,
#endif
            false),
            (typeof(Achievement),
#if TIBERIUMWARS
            0xC8D16E6Du,
#elif KANESWRATH
            0x94372A1Au,
#endif
            false),
            (typeof(StanceTemplate), 0x5C6E0E41u, false),
            (typeof(TargetingCompareList), 0x57CA5C81u, false),
            (typeof(TargetingDistanceCompare),
#if TIBERIUMWARS
            0xED45F096u,
#elif KANESWRATH
            0xCD8C1030u,
#endif
            false),
            (typeof(TargetingCombatChainCompare), 0x553808EFu, false),
            (typeof(TargetingInTurretArcCompare), 0xCD24391Au, false),
            (typeof(Road),
#if TIBERIUMWARS
            0xDCF3C28Bu,
#elif KANESWRATH
            0x193A83E3u,
#endif
            false),
            (typeof(SageBinaryData.Environment),
#if TIBERIUMWARS
            0x878C42E0u,
#elif KANESWRATH
            0x64ED86BAu,
#endif
            false),
            (typeof(LogicCommand),
#if TIBERIUMWARS
            0x97D0A46Eu,
#elif KANESWRATH
            0x548ADF93u,
#endif
            false),
            (typeof(LogicCommandSet), 0x6D148BD7u, false),
            (typeof(MiscAudio),
#if TIBERIUMWARS
            0xFA4817E2u,
#elif KANESWRATH
            0x92862F79u,
#endif
            false),
            (typeof(AudioSettings),
#if TIBERIUMWARS
            0x89AA7DDEu,
#elif KANESWRATH
            0xD842549Du,
#endif
            false),
            (typeof(CrowdResponse),
#if TIBERIUMWARS
            0x66FB33A0u,
#elif KANESWRATH
            0x0CF7A495u,
#endif
            false),

            (typeof(LargeGroupAudioMap),
#if TIBERIUMWARS
            0x9CBC0553u,
#elif KANESWRATH
            0xCD55ECB7u,
#endif
            false),
            (typeof(AptAptData), 0x36866072u, false),
            (typeof(AptConstData), 0x1CE8E595u, false),
            (typeof(AptDatData), 0x3BF7FEB9u, false),
            (typeof(AptGeometryData),
#if TIBERIUMWARS
            0x58F89E8Bu,
#elif KANESWRATH
            0x762BA1A7u,
#endif
            false),
            (typeof(MappableKey), 0xE005A668u, false),
            (typeof(HotKeySlot),
#if TIBERIUMWARS
            0x1AC54E60u,
#elif KANESWRATH
            0x07C51D32u,
#endif
            false),
            (typeof(DefaultHotKeys),
#if TIBERIUMWARS
            0x0E12479Du,
#elif KANESWRATH
            0x12CB83DCu,
#endif
            false),
            (typeof(InGameUIGroupSelectionCommandSlots), 0xF6CE1A68u, false),
            (typeof(InGameUILookAtCommandSlots), 0x8F9F9918u, false),
            (typeof(InGameUITacticalCommandSlots),
#if TIBERIUMWARS
            0xC24AEFF1u,
#elif KANESWRATH
            0xC24AEFF1u,
#endif
            false),
            (typeof(InGameUIVoiceChatCommandSlots), 0x3592E352u, false),
            (typeof(InGameUISideBarCommandSlots),
#if TIBERIUMWARS
            0xAF956455u,
#elif KANESWRATH
            0xAC67CEF0u,
#endif
            false),
            (typeof(InGameUIPlayerPowerCommandSlots), 0x4AB425C6u, false),
            (typeof(InGameUIUnitAbilityCommandSlots), 0x9DAA4182u, false),


            (typeof(GameScriptList), 0x5AC6FA18u, false),
            (typeof(IntelDB), 0xFBB64F90u, false),

            (typeof(UnitTypeIcon),
#if TIBERIUMWARS
            0xF7AB74BEu,
#elif KANESWRATH
            0x4822A4B6u,
#endif
            false),
            (typeof(ImageSequence), 0x217CF953u, false),
            (typeof(UnitOverlayIconSettings),
#if TIBERIUMWARS
            0xDFC78E66u,
#elif KANESWRATH
            0x3AB4ECB5u,
#endif
            false),

            (typeof(PhaseEffect),
#if TIBERIUMWARS
            0x4877D566u,
#elif KANESWRATH
            0x052DD6F5u,
#endif
            false),
            (typeof(ConnectionLineManager), 0x7AEB73B2u, false),
            (typeof(InGameUIFixedElementHotKeySlotMap),
#if TIBERIUMWARS
            0x475EA260u,
#elif KANESWRATH
            0x4571AA6Bu,
#endif
            false),
#if TIBERIUMWARS

            (typeof(MP3MusicTrack), 0x43A14C89u, false),
            (typeof(MP3DialogEvent), 0xF582BDC2u, false),
            (typeof(MP3AmbientStream), 0xF0F2CF86u, false),
            (typeof(UnitAbilityButtonTemplateStore), 0x5A48D289u, false),
            (typeof(PlayerPowerButtonTemplateStore), 0xDB57AB4Fu, false),

#elif KANESWRATH
            (typeof(UnitAbilityButtonTemplate), 0x5E259F73u, false),
            (typeof(PlayerPowerButtonTemplate), 0x50FE2D98u, false),

            (typeof(MetaGameUITacticalCommandSlots), 0x8679A22Fu, false),
            (typeof(MetaGameUICommonOpCommandSlots), 0xAB6D2D46u, false),

            (typeof(ButtonSingleStateData), 0x542774ABu, false),

#endif
        })
        {
            CreateTypeInfo(type, num, hash, hasCustomData);
        }
    }

    public void ReInitialize(TargetPlatform platform)
    {
        _extendedTypeInformations.Clear();
        Initialize(platform);
    }

    public ExtendedTypeInformation GetExtendedTypeInformation(uint typeId)
    {
        return _extendedTypeInformations[typeId];
//            ExtendedTypeInformation result = new()
//            {
//                HasCustomData = false,
//                TypeId = typeId
//            };
//            uint num = (uint)_xmlCompilerVersion;
//            if (_platform == TargetPlatform.Xbox360)
//            {
//                num += (uint)_xbox360;
//            }
//            switch (typeId)
//            {
//                case 0x036B677Bu:
//                    result.Type = typeof(MusicScriptConditionNugget_TrackPlayedCount);
//                    result.TypeName = nameof(MusicScriptConditionNugget_TrackPlayedCount);
//                    result.ProcessingHash = num ^ 0x4FCFFAB1u;
//                    result.TypeHash = 0x4FCFFAB1u;
//                    break;
//                case 0x0559C032u:
//                    result.Type = typeof(TargetingCombatChainCompare);
//                    result.TypeName = nameof(TargetingCombatChainCompare);
//                    result.ProcessingHash = num ^ 0x553808EFu;
//                    result.TypeHash = 0x553808EFu;
//                    break;
//                case 0x064B2184u:
//                    result.Type = typeof(ConnectionLineManager);
//                    result.TypeName = nameof(ConnectionLineManager);
//                    result.ProcessingHash = num ^ 0x7AEB73B2u;
//                    result.TypeHash = 0x7AEB73B2u;
//                    break;
//                case 0x0B3906FAu:
//                    result.Type = typeof(MusicScriptConditionNugget_LocalPlayerIsObserver);
//                    result.TypeName = nameof(MusicScriptConditionNugget_LocalPlayerIsObserver);
//                    result.ProcessingHash = num ^ 0xAFB6AF3Au;
//                    result.TypeHash = 0xAFB6AF3Au;
//                    break;
//                case 0x0B408BD4u:
//                    result.Type = typeof(UnitAbilityButtonTemplateStore);
//                    result.TypeName = nameof(UnitAbilityButtonTemplateStore);
//                    result.ProcessingHash = num ^ 0x5A48D289u;
//                    result.TypeHash = 0x5A48D289u;
//                    break;
//                case 0x0B63AEF0u:
//                    result.Type = typeof(MultiplayerSettings);
//                    result.TypeName = nameof(MultiplayerSettings);
//                    result.ProcessingHash = num ^ 0x1BAF4C42u;
//                    result.TypeHash = 0x1BAF4C42u;
//                    break;
//                case 0x0CAD7864u:
//                    result.Type = typeof(DLContent);
//                    result.TypeName = nameof(DLContent);
//                    result.ProcessingHash = num ^ 0x4E1A5713u;
//                    result.TypeHash = 0x4E1A5713u;
//                    break;
//                case 0x11D8BAC7u:
//                    result.Type = typeof(AudioLOD);
//                    result.TypeName = nameof(AudioLOD);
//                    result.ProcessingHash = num ^ 0x3ABBF00Fu;
//                    result.TypeHash = 0x3ABBF00Fu;
//                    break;
//                case 0x11E5CF64u:
//                    result.Type = typeof(StringHashTable);
//                    result.TypeName = nameof(StringHashTable);
//                    result.ProcessingHash = num ^ 0x2C112832u;
//                    result.TypeHash = 0x2C112832u;
//                    break;
//                case 0x12CFE3EFu:
//                    result.Type = typeof(LocalBuildListMonitor);
//                    result.TypeName = nameof(LocalBuildListMonitor);
//                    result.ProcessingHash = num ^ 0x99CC030Au;
//                    result.TypeHash = 0x99CC030Au;
//                    break;
//                case 0x151D037Cu:
//                    result.Type = typeof(GameLODPreset);
//                    result.TypeName = nameof(GameLODPreset);
//                    result.ProcessingHash = num ^ 0x19DAC24Du;
//                    result.TypeHash = 0x19DAC24Du;
//                    break;
//                case 0x17E53184u:
//                    result.Type = typeof(CrowdResponse);
//                    result.TypeName = nameof(CrowdResponse);
//                    result.ProcessingHash = num ^ 0x66FB33A0u;
//                    result.TypeHash = 0x66FB33A0u;
//                    break;
//                case 0x1A2DC767u:
//                    result.Type = typeof(TheaterOfWarTemplate);
//                    result.TypeName = nameof(TheaterOfWarTemplate);
//                    result.ProcessingHash = num ^ 0xE60C9724u;
//                    result.TypeHash = 0xE60C9724u;
//                    break;
//                case 0x1E0FC59Eu:
//                    result.Type = typeof(InGameUIPlayerPowerCommandSlots);
//                    result.TypeName = nameof(InGameUIPlayerPowerCommandSlots);
//                    result.ProcessingHash = num ^ 0x4AB425C6u;
//                    result.TypeHash = 0x4AB425C6u;
//                    break;
//                case 0x1F9865CEu:
//                    result.Type = typeof(IntelDB);
//                    result.TypeName = nameof(IntelDB);
//                    result.ProcessingHash = num ^ 0xFBB64F90u;
//                    result.TypeHash = 0xFBB64F90u;
//                    break;
//                case 0x1FB298D1u:
//                    result.Type = typeof(StaticGameLOD);
//                    result.TypeName = nameof(StaticGameLOD);
//                    result.ProcessingHash = num ^ 0xBEAF1CC9u;
//                    result.TypeHash = 0xBEAF1CC9u;
//                    break;
//                case 0x1FD451BFu:
//                    result.Type = typeof(LargeGroupAudioMap);
//                    result.TypeName = nameof(LargeGroupAudioMap);
//                    result.ProcessingHash = num ^ 0x9CBC0553u;
//                    result.TypeHash = 0x9CBC0553u;
//                    break;
//                case 0x21BA45A7u:
//                    result.Type = typeof(ImageSequence);
//                    result.TypeName = nameof(ImageSequence);
//                    result.ProcessingHash = num ^ 0x217CF953u;
//                    result.TypeHash = 0x217CF953u;
//                    break;
//                case 0x242FF6D4u:
//                    result.Type = typeof(AIStrategicStateDefinition);
//                    result.TypeName = nameof(AIStrategicStateDefinition);
//                    result.ProcessingHash = num ^ 0x1E27DA26u;
//                    result.TypeHash = 0x1E27DA26u;
//                    break;
//                case 0x245EB4F9u:
//                    result.Type = typeof(InGameUIVoiceChatCommandSlots);
//                    result.TypeName = nameof(InGameUIVoiceChatCommandSlots);
//                    result.ProcessingHash = num ^ 0x3592E352u;
//                    result.TypeHash = 0x3592E352u;
//                    break;
//                case 0x2893E309u:
//                    result.Type = typeof(SageBinaryData.Environment);
//                    result.TypeName = nameof(SageBinaryData.Environment);
//                    result.ProcessingHash = num ^ 0x878C42E0u;
//                    result.TypeHash = 0x878C42E0u;
//                    break;
//                case 0x28E7FD7Fu:
//                    result.Type = typeof(FXParticleSystemTemplate);
//                    result.TypeName = nameof(FXParticleSystemTemplate);
//                    result.ProcessingHash = num ^ 0xA148D511u;
//                    result.TypeHash = 0xA148D511u;
//                    break;
//                case 0x2B49BF71u:
//                    result.Type = typeof(Achievement);
//                    result.TypeName = nameof(Achievement);
//                    result.ProcessingHash = num ^ 0xC8D16E6Du;
//                    result.TypeHash = 0xC8D16E6Du;
//                    break;
//                case 0x2C108648u:
//                    result.Type = typeof(MusicScriptConditionNugget_SpecificTrackTypePlaying);
//                    result.TypeName = nameof(MusicScriptConditionNugget_SpecificTrackTypePlaying);
//                    result.ProcessingHash = num ^ 0xBCAD9B77u;
//                    result.TypeHash = 0xBCAD9B77u;
//                    break;
//                case 0x2C358B80u:
//                    result.Type = typeof(MpGameRules);
//                    result.TypeName = nameof(MpGameRules);
//                    result.ProcessingHash = num ^ 0xEDDBB607u;
//                    result.TypeHash = 0xEDDBB607u;
//                    break;
//                case 0x30D2F544u:
//                    result.Type = typeof(RadiusCursorLibrary);
//                    result.TypeName = nameof(RadiusCursorLibrary);
//                    result.ProcessingHash = num ^ 0xD62B490Fu;
//                    result.TypeHash = 0xD62B490Fu;
//                    break;
//                case 0x33A671F8u:
//                    result.Type = typeof(InGameUISettings);
//                    result.TypeName = nameof(InGameUISettings);
//                    result.ProcessingHash = num ^ 0x49FE3760u;
//                    result.TypeHash = 0x49FE3760u;
//                    break;
//                case 0x373E10FAu:
//                    result.Type = typeof(AITargetingHeuristic);
//                    result.TypeName = nameof(AITargetingHeuristic);
//                    result.ProcessingHash = num ^ 0xB7A2C222u;
//                    result.TypeHash = 0xB7A2C222u;
//                    break;
//                case 0x395A0FD6u:
//                    result.Type = typeof(InGameUILookAtCommandSlots);
//                    result.TypeName = nameof(InGameUILookAtCommandSlots);
//                    result.ProcessingHash = num ^ 0x8F9F9918u;
//                    result.TypeHash = 0x8F9F9918u;
//                    break;
//                case 0x3A6C5E8Eu:
//                    result.Type = typeof(ArmorTemplate);
//                    result.TypeName = nameof(ArmorTemplate);
//                    result.ProcessingHash = num ^ 0x9CDD1086u;
//                    result.TypeHash = 0x9CDD1086u;
//                    break;
//                case 0x3A9CE0B0u:
//                    result.Type = typeof(AptConstData);
//                    result.TypeName = nameof(AptConstData);
//                    result.ProcessingHash = num ^ 0x1CE8E595u;
//                    result.TypeHash = 0x1CE8E595u;
//                    break;
//                case 0x3DAA8C20u:
//                    result.Type = typeof(AptGeometryData);
//                    result.TypeName = nameof(AptGeometryData);
//                    result.ProcessingHash = num ^ 0x58F89E8Bu;
//                    result.TypeHash = 0x58F89E8Bu;
//                    break;
//                case 0x3DDFA8BDu:
//                    result.Type = typeof(MusicScriptTrack);
//                    result.TypeName = nameof(MusicScriptTrack);
//                    result.ProcessingHash = num ^ 0x702C8407u;
//                    result.TypeHash = 0x702C8407u;
//                    break;
//                case 0x423395E1u:
//                    result.Type = typeof(AptDatData);
//                    result.TypeName = nameof(AptDatData);
//                    result.ProcessingHash = num ^ 0x3BF7FEB9u;
//                    result.TypeHash = 0x3BF7FEB9u;
//                    break;
//                case 0x44A5973Du:
//                    result.Type = typeof(ObjectFilterAsset);
//                    result.TypeName = nameof(ObjectFilterAsset);
//                    result.ProcessingHash = num ^ 0x25970AF7u;
//                    result.TypeHash = 0x25970AF7u;
//                    break;
//                case 0x5016F8C3u:
//                    result.Type = typeof(MusicScriptConditionNugget_And);
//                    result.TypeName = nameof(MusicScriptConditionNugget_And);
//                    result.ProcessingHash = num ^ 0x10173347u;
//                    result.TypeHash = 0x10173347u;
//                    break;
//                case 0x502EED32u:
//                    result.Type = typeof(OnlineChatColors);
//                    result.TypeName = nameof(OnlineChatColors);
//                    result.ProcessingHash = num ^ 0xF3645AA7u;
//                    result.TypeHash = 0xF3645AA7u;
//                    break;
//                case 0x5080A5D8u:
//                    result.Type = typeof(MappableKey);
//                    result.TypeName = nameof(MappableKey);
//                    result.ProcessingHash = num ^ 0xE005A668u;
//                    result.TypeHash = 0xE005A668u;
//                    break;
//                case 0x5608EE71u:
//                    result.Type = typeof(AudioSettings);
//                    result.TypeName = nameof(AudioSettings);
//                    result.ProcessingHash = num ^ 0x89AA7DDEu;
//                    result.TypeHash = 0x89AA7DDEu;
//                    break;
//                case 0x564A9693u:
//                    result.Type = typeof(VideoEventList);
//                    result.TypeName = nameof(VideoEventList);
//                    result.ProcessingHash = num ^ 0x999FCBE3u;
//                    result.TypeHash = 0x999FCBE3u;
//                    break;
//                case 0x56626220u:
//                    result.Type = typeof(PackedTextureImage);
//                    result.TypeName = nameof(PackedTextureImage);
//                    result.ProcessingHash = num ^ 0x2FAEB748u;
//                    result.TypeHash = 0x2FAEB748u;
//                    break;
//                case 0x57495B42u:
//                    result.Type = typeof(MusicScriptConditionNugget_TimeFromStartOfLevel);
//                    result.TypeName = nameof(MusicScriptConditionNugget_TimeFromStartOfLevel);
//                    result.ProcessingHash = num ^ 0xAA4A9E23u;
//                    result.TypeHash = 0xAA4A9E23u;
//                    break;
//                case 0x582FDC2Au:
//                    result.Type = typeof(WaterTransparency);
//                    result.TypeName = nameof(WaterTransparency);
//                    result.ProcessingHash = num ^ 0x331DA6CEu;
//                    result.TypeHash = 0x331DA6CEu;
//                    break;
//                case 0x585E034Eu:
//                    result.Type = typeof(CampaignTemplate);
//                    result.TypeName = nameof(CampaignTemplate);
//                    result.ProcessingHash = num ^ 0xAC60B530u;
//                    result.TypeHash = 0xAC60B530u;
//                    break;
//                case 0x5F969146u:
//                    result.Type = typeof(MapMetaDataType);
//                    result.TypeName = nameof(MapMetaDataType);
//                    result.ProcessingHash = num ^ 0x59013A51u;
//                    result.TypeHash = 0x59013A51u;
//                    break;
//                case 0x6114137Eu:
//                    result.Type = typeof(InGameUIGroupSelectionCommandSlots);
//                    result.TypeName = nameof(InGameUIGroupSelectionCommandSlots);
//                    result.ProcessingHash = num ^ 0xF6CE1A68u;
//                    result.TypeHash = 0xF6CE1A68u;
//                    break;
//                case 0x61D7EA40u:
//                    result.Type = typeof(W3DHierarchy);
//                    result.TypeName = nameof(W3DHierarchy);
//                    result.ProcessingHash = num ^ 0x3BC26A7Au;
//                    result.TypeHash = 0x3BC26A7Au;
//                    break;
//                case 0x66219699u:
//                    result.Type = typeof(PlayerPowerButtonTemplateStore);
//                    result.TypeName = nameof(PlayerPowerButtonTemplateStore);
//                    result.ProcessingHash = num ^ 0xDB57AB4Fu;
//                    result.TypeHash = 0xDB57AB4Fu;
//                    break;
//                case 0x6C41E6DCu:
//                    result.Type = typeof(AptAptData);
//                    result.TypeName = nameof(AptAptData);
//                    result.ProcessingHash = num ^ 0x36866072u;
//                    result.TypeHash = 0x36866072u;
//                    break;
//                case 0x6CDDC801u:
//                    result.Type = typeof(MissionObjectiveList);
//                    result.TypeName = nameof(MissionObjectiveList);
//                    result.ProcessingHash = num ^ 0xC385A8C1u;
//                    result.TypeHash = 0xC385A8C1u;
//                    break;
//                case 0x6FBC4A9Fu:
//                    result.Type = typeof(ExperienceLevelTemplate);
//                    result.TypeName = nameof(ExperienceLevelTemplate);
//                    result.ProcessingHash = num ^ 0xAE55047Bu;
//                    result.TypeHash = 0xAE55047Bu;
//                    break;
//                case 0x7046D9F8u:
//                    result.Type = typeof(MusicTrack);
//                    result.TypeName = nameof(MusicTrack);
//                    result.ProcessingHash = num ^ 0x1469548Au;
//                    result.TypeHash = 0x1469548Au;
//                    break;
//                case 0x77AC3B08u:
//                    result.Type = typeof(TargetingInTurretArcCompare);
//                    result.TypeName = nameof(TargetingInTurretArcCompare);
//                    result.ProcessingHash = num ^ 0xCD24391Au;
//                    result.TypeHash = 0xCD24391Au;
//                    break;
//                case 0x7B6AE7D5u:
//                    result.Type = typeof(MiscAudio);
//                    result.TypeName = nameof(MiscAudio);
//                    result.ProcessingHash = num ^ 0xFA4817E2u;
//                    result.TypeHash = 0xFA4817E2u;
//                    break;
//                case 0x7D464170u:
//                    result.Type = typeof(LogicCommand);
//                    result.TypeName = nameof(LogicCommand);
//                    result.ProcessingHash = num ^ 0x97D0A46Eu;
//                    result.TypeHash = 0x97D0A46Eu;
//                    break;
//                case 0x81D85EFAu:
//                    result.Type = typeof(SpecialPowerTemplate);
//                    result.TypeName = nameof(SpecialPowerTemplate);
//                    result.ProcessingHash = num ^ 0x5EF0ACA9u;
//                    result.TypeHash = 0x5EF0ACA9u;
//                    break;
//                case 0x844D7B9Fu:
//                    result.Type = typeof(AudioEvent);
//                    result.TypeName = nameof(AudioEvent);
//                    result.ProcessingHash = num ^ 0x1B886049u;
//                    result.TypeHash = 0x1B886049u;
//                    break;
//                case 0x86682E78u:
//                    result.Type = typeof(FXList);
//                    result.TypeName = nameof(FXList);
//                    result.ProcessingHash = num ^ 0xEBE8A8A4u;
//                    result.TypeHash = 0xEBE8A8A4u;
//                    break;
//                case 0x88011B0Eu:
//                    result.Type = typeof(MusicScriptConditionNugget_Or);
//                    result.TypeName = nameof(MusicScriptConditionNugget_Or);
//                    result.ProcessingHash = num ^ 0x81114695u;
//                    result.TypeHash = 0x81114695u;
//                    break;
//                case 0x8CA5A7D7u:
//                    result.Type = typeof(TargetingDistanceCompare);
//                    result.TypeName = nameof(TargetingDistanceCompare);
//                    result.ProcessingHash = num ^ 0xED45F096u;
//                    result.TypeHash = 0xED45F096u;
//                    break;
//                case 0x8E28081Du:
//                    result.Type = typeof(MultiplayerColor);
//                    result.TypeName = nameof(MultiplayerColor);
//                    result.ProcessingHash = num ^ 0x966F336Au;
//                    result.TypeHash = 0x966F336Au;
//                    break;
//                case 0x8F7DC19Bu:
//                    result.Type = typeof(MusicPalette);
//                    result.TypeName = nameof(MusicPalette);
//                    result.ProcessingHash = num ^ 0x6A7AF822u;
//                    result.TypeHash = 0x6A7AF822u;
//                    break;
//                case 0x9053D603u:
//                    result.Type = typeof(UnitOverlayIconSettings);
//                    result.TypeName = nameof(UnitOverlayIconSettings);
//                    result.ProcessingHash = num ^ 0xDFC78E66u;
//                    result.TypeHash = 0xDFC78E66u;
//                    break;
//                case 0x90D951ADu:
//                    result.Type = typeof(Weather);
//                    result.TypeName = nameof(Weather);
//                    result.ProcessingHash = num ^ 0x368A8BA2u;
//                    result.TypeHash = 0x368A8BA2u;
//                    break;
//                case 0x98EE2743u:
//                    result.Type = typeof(InGameUISideBarCommandSlots);
//                    result.TypeName = nameof(InGameUISideBarCommandSlots);
//                    result.ProcessingHash = num ^ 0xAF956455u;
//                    result.TypeHash = 0xAF956455u;
//                    break;
//                case 0x9A104B07u:
//                    result.Type = typeof(CommandSet);
//                    result.TypeName = nameof(CommandSet);
//                    result.ProcessingHash = num ^ 0x3CFF78A1u;
//                    result.TypeHash = 0x3CFF78A1u;
//                    break;
//                case 0x928F51E4u:
//                    result.Type = typeof(InGameUIFixedElementHotKeySlotMap);
//                    result.TypeName = nameof(InGameUIFixedElementHotKeySlotMap);
//                    result.ProcessingHash = num ^ 0x475EA260u;
//                    result.TypeHash = 0x475EA260u;
//                    break;
//                case 0x9684C743u:
//                    result.Type = typeof(StanceTemplate);
//                    result.TypeName = nameof(StanceTemplate);
//                    result.ProcessingHash = num ^ 0x5C6E0E41u;
//                    result.TypeHash = 0x5C6E0E41u;
//                    break;
//                case 0x9687F57Bu:
//                    result.Type = typeof(Mouse);
//                    result.TypeName = nameof(Mouse);
//                    result.ProcessingHash = num ^ 0x73FE99B0u;
//                    result.TypeHash = 0x73FE99B0u;
//                    break;
//                case 0x9C361A08u:
//                    result.Type = typeof(MusicScriptConditionNugget_UnitsFarFromBase);
//                    result.TypeName = nameof(MusicScriptConditionNugget_UnitsFarFromBase);
//                    result.ProcessingHash = num ^ 0xD889BF98u;
//                    result.TypeHash = 0xD889BF98u;
//                    break;
//                case 0x942FFF2Du:
//                    result.Type = typeof(GameObject);
//                    result.TypeName = nameof(GameObject);
//                    result.ProcessingHash = num ^ 0x132408DBu;
//                    result.TypeHash = 0x132408DBu;
//                    break;
//                case 0xA38DB775u:
//                    result.Type = typeof(MusicScriptConditionNugget_EvaEventPlayedRecently);
//                    result.TypeName = nameof(MusicScriptConditionNugget_EvaEventPlayedRecently);
//                    result.ProcessingHash = num ^ 0x1F200F13u;
//                    result.TypeHash = 0x1F200F13u;
//                    break;
//                case 0xA3A7AF37u:
//                    result.Type = typeof(Multisound);
//                    result.TypeName = nameof(Multisound);
//                    result.ProcessingHash = num ^ 0x12B1C67Cu;
//                    result.TypeHash = 0x12B1C67Cu;
//                    break;
//                case 0xA6E6BBA7u:
//                    result.Type = typeof(HotKeySlot);
//                    result.TypeName = nameof(HotKeySlot);
//                    result.ProcessingHash = num ^ 0x1AC54E60u;
//                    result.TypeHash = 0x1AC54E60u;
//                    break;
//                case 0xA78E592Eu:
//                    result.Type = typeof(InGameUIUnitAbilityCommandSlots);
//                    result.TypeName = nameof(InGameUIUnitAbilityCommandSlots);
//                    result.ProcessingHash = num ^ 0x9DAA4182u;
//                    result.TypeHash = 0x9DAA4182u;
//                    break;
//                case 0xA7A65DACu:
//                    result.Type = typeof(InGameUITacticalCommandSlots);
//                    result.TypeName = nameof(InGameUITacticalCommandSlots);
//                    result.ProcessingHash = num ^ 0xC24AEFF1u;
//                    result.TypeHash = 0xC24AEFF1u;
//                    break;
//                case 0xAC78CE63u:
//                    result.Type = typeof(AIBudgetStateDefinition);
//                    result.TypeName = nameof(AIBudgetStateDefinition);
//                    result.ProcessingHash = num ^ 0xA10F9630u;
//                    result.TypeHash = 0xA10F9630u;
//                    break;
//                case 0xACEF31A4u:
//                    result.Type = typeof(DynamicGameLOD);
//                    result.TypeName = nameof(DynamicGameLOD);
//                    result.ProcessingHash = num ^ 0x71BAD792u;
//                    result.TypeHash = 0x71BAD792u;
//                    break;
//                case 0xAD3568F5u:
//                    result.Type = typeof(DamageFX);
//                    result.TypeName = nameof(DamageFX);
//                    result.ProcessingHash = num ^ 0x4DF81EBDu;
//                    result.TypeHash = 0x4DF81EBDu;
//                    break;
//                case 0xB71D7323u:
//                    result.Type = typeof(UIConfigList);
//                    result.TypeName = nameof(UIConfigList);
//                    result.ProcessingHash = num ^ 0xB3B7607Au;
//                    result.TypeHash = 0xB3B7607Au;
//                    break;
//                case 0xBE06A9E5u:
//                    result.Type = typeof(TargetingCompareList);
//                    result.TypeName = nameof(TargetingCompareList);
//                    result.ProcessingHash = num ^ 0x57CA5C81u;
//                    result.TypeHash = 0x57CA5C81u;
//                    break;
//                case 0xC11D7E83u:
//                    result.Type = typeof(AIStateDefinition);
//                    result.TypeName = nameof(AIStateDefinition);
//                    result.ProcessingHash = num ^ 0x262BE85Fu;
//                    result.TypeHash = 0x262BE85Fu;
//                    break;
//                case 0xC5E07887u:
//                    result.Type = typeof(AttributeModifier);
//                    result.TypeName = nameof(AttributeModifier);
//                    result.ProcessingHash = num ^ 0xD24E7201u;
//                    result.TypeHash = 0xD24E7201u;
//                    break;
//                case 0xC8E41828u:
//                    result.Type = typeof(BootupDisplaySequence);
//                    result.TypeName = nameof(BootupDisplaySequence);
//                    result.ProcessingHash = num ^ 0x84C1C2F0u;
//                    result.TypeHash = 0x84C1C2F0u;
//                    break;
//                case 0xC9DD2E6Du:
//                    result.Type = typeof(MusicScriptConditionNugget_ObjectsNearEvaEvent);
//                    result.TypeName = nameof(MusicScriptConditionNugget_ObjectsNearEvaEvent);
//                    result.ProcessingHash = num ^ 0x0EC4D160u;
//                    result.TypeHash = 0x0EC4D160u;
//                    break;
//                case 0xCAD58CC1u:
//                    result.Type = typeof(MusicScriptConditionNugget_AnyTrackPlaying);
//                    result.TypeName = nameof(MusicScriptConditionNugget_AnyTrackPlaying);
//                    result.ProcessingHash = num ^ 0x337BC326u;
//                    result.TypeHash = 0x337BC326u;
//                    break;
//                case 0xCF4AED23u:
//                    result.Type = typeof(MissionTemplate);
//                    result.TypeName = nameof(MissionTemplate);
//                    result.ProcessingHash = num ^ 0x0D283295u;
//                    result.TypeHash = 0x0D283295u;
//                    break;
//                case 0xD19D90C6u:
//                    result.Type = typeof(Road);
//                    result.TypeName = nameof(Road);
//                    result.ProcessingHash = num ^ 0xDCF3C28Bu;
//                    result.TypeHash = 0xDCF3C28Bu;
//                    break;
//                case 0xD414D1C3u:
//                    result.Type = typeof(DialogEvent);
//                    result.TypeName = nameof(DialogEvent);
//                    result.ProcessingHash = num ^ 0x8655CDB4u;
//                    result.TypeHash = 0x8655CDB4u;
//                    break;
//                case 0xD51AE5E1u:
//                    result.Type = typeof(GameMap);
//                    result.TypeName = nameof(GameMap);
//                    result.ProcessingHash = num ^ 0x3EC9C79Bu;
//                    result.TypeHash = 0x3EC9C79Bu;
//                    break;
//                case 0xD5D580F6u:
//                    result.Type = typeof(ArmyDefinition);
//                    result.TypeName = nameof(ArmyDefinition);
//                    result.ProcessingHash = num ^ 0x57213EA5u;
//                    result.TypeHash = 0x57213EA5u;
//                    break;
//                case 0xD6D4F18Eu:
//                    result.Type = typeof(AIPersonalityDefinition);
//                    result.TypeName = nameof(AIPersonalityDefinition);
//                    result.ProcessingHash = num ^ 0x7DCE182Fu;
//                    result.TypeHash = 0x7DCE182Fu;
//                    break;
//                case 0xD76B50C7u:
//                    result.Type = typeof(UnitTypeIcon);
//                    result.TypeName = nameof(UnitTypeIcon);
//                    result.ProcessingHash = num ^ 0xF7AB74BEu;
//                    result.TypeHash = 0xF7AB74BEu;
//                    break;
//                case 0xD7D07964u:
//                    result.Type = typeof(MusicScriptConditionNugget_ScoredKillCount);
//                    result.TypeName = nameof(MusicScriptConditionNugget_ScoredKillCount);
//                    result.ProcessingHash = num ^ 0x5C0F93DCu;
//                    result.TypeHash = 0x5C0F93DCu;
//                    break;
//                case 0xD99C40A9u:
//                    result.Type = typeof(PhaseEffect);
//                    result.TypeName = nameof(PhaseEffect);
//                    result.ProcessingHash = num ^ 0x4877D566u;
//                    result.TypeHash = 0x4877D566u;
//                    break;
//                case 0xDEBF8788u:
//                    result.Type = typeof(GameScriptList);
//                    result.TypeName = nameof(GameScriptList);
//                    result.ProcessingHash = num ^ 0x5AC6FA18u;
//                    result.TypeHash = 0x5AC6FA18u;
//                    break;
//                case 0xDEFCA2F6u:
//                    result.Type = typeof(DefaultHotKeys);
//                    result.TypeName = nameof(DefaultHotKeys);
//                    result.ProcessingHash = num ^ 0x0E12479Du;
//                    result.TypeHash = 0x0E12479Du;
//                    break;
//                case 0xE1AFE75Bu:
//                    result.Type = typeof(UpgradeTemplate);
//                    result.TypeName = nameof(UpgradeTemplate);
//                    result.ProcessingHash = num ^ 0x1E53F384u;
//                    result.TypeHash = 0x1E53F384u;
//                    break;
//                case 0xE3181C04u:
//                    result.Type = typeof(W3DCollisionBox);
//                    result.TypeName = nameof(W3DCollisionBox);
//                    result.ProcessingHash = num ^ 0xC917E725u;
//                    result.TypeHash = 0xC917E725u;
//                    break;
//                case 0xE86E4D61u:
//                    result.Type = typeof(ObjectCreationList);
//                    result.TypeName = nameof(ObjectCreationList);
//                    result.ProcessingHash = num ^ 0x683D4DE5u;
//                    result.TypeHash = 0x683D4DE5u;
//                    break;
//                case 0xEA2C2798u:
//                    result.Type = typeof(AmbientStream);
//                    result.TypeName = nameof(AmbientStream);
//                    result.ProcessingHash = num ^ 0xDABB1C4Bu;
//                    result.TypeHash = 0xDABB1C4Bu;
//                    break;
//                case 0xEC066D65u:
//                    result.Type = typeof(LogicCommandSet);
//                    result.TypeName = nameof(LogicCommandSet);
//                    result.ProcessingHash = num ^ 0x6D148BD7u;
//                    result.TypeHash = 0x6D148BD7u;
//                    break;
//                case 0xECBE73E8u:
//                    result.Type = typeof(SkirmishOpeningMove);
//                    result.TypeName = nameof(SkirmishOpeningMove);
//                    result.ProcessingHash = num ^ 0x21EE29FAu;
//                    result.TypeHash = 0x21EE29FAu;
//                    break;
//                case 0xECC2A1D3u:
//                    result.Type = typeof(LocomotorTemplate);
//                    result.TypeName = nameof(LocomotorTemplate);
//                    result.ProcessingHash = num ^ 0xBD8F61A4u;
//                    result.TypeHash = 0xBD8F61A4u;
//                    break;
//                case 0xEED6A240u:
//                    result.Type = typeof(MusicScriptConditionNugget_Not);
//                    result.TypeName = nameof(MusicScriptConditionNugget_Not);
//                    result.ProcessingHash = num ^ 0xB886383Bu;
//                    result.TypeHash = 0xB886383Bu;
//                    break;
//                case 0xF0F08712u:
//                    result.Type = typeof(W3DContainer);
//                    result.TypeName = nameof(W3DContainer);
//                    result.ProcessingHash = num ^ 0x909DD93Fu;
//                    result.TypeHash = 0x909DD93Fu;
//                    break;
//                case 0xF7CE0BBDu:
//                    result.Type = typeof(ShadowMap);
//                    result.TypeName = nameof(ShadowMap);
//                    result.ProcessingHash = num ^ 0xC6389FA6u;
//                    result.TypeHash = 0xC6389FA6u;
//                    break;
//                case 0xFC82DC06u:
//                    result.Type = typeof(TheVersion);
//                    result.TypeName = nameof(TheVersion);
//                    result.ProcessingHash = num ^ 0xF659EF49u;
//                    result.TypeHash = 0xF659EF49u;
//                    break;
//                case 0xFE0E84BBu:
//                    result.Type = typeof(OnDemandTextureImage);
//                    result.TypeName = nameof(OnDemandTextureImage);
//                    result.ProcessingHash = num ^ 0xF3F4AEECu;
//                    result.TypeHash = 0xF3F4AEECu;
//                    break;
//                case 0xFF7BDFBFu:
//                    result.Type = typeof(MusicScriptConditionNugget_ObjectsOfTypeExist);
//                    result.TypeName = nameof(MusicScriptConditionNugget_ObjectsOfTypeExist);
//                    result.ProcessingHash = num ^ 0x9586411Cu;
//                    result.TypeHash = 0x9586411Cu;
//                    break;
//                default:
//                    result.TypeName = "<unknown>";
//                    result.ProcessingHash = 0u;
//                    result.TypeHash = 0u;
//                    break;
//            }
//            return result;
    }

    public AssetBuffer ProcessInstance(InstanceDeclaration declaration)
    {
        AssetBuffer result = new AssetBuffer();
        if (!_handleMethods.TryGetValue(declaration.Handle.TypeId, out MethodInfo handleType))
        {
            handleType = GetType().GetMethod(nameof(HandleType));
            ExtendedTypeInformation extendedTypeInformation = GetExtendedTypeInformation(declaration.Handle.TypeId);
            handleType = handleType.MakeGenericMethod(extendedTypeInformation.Type);
            if (handleType is null)
            {
                throw new BinaryAssetBuilderException(ErrorCode.InternalError, "Unable to find handle method for type '{0}", extendedTypeInformation.TypeName);
            }
            _handleMethods.Add(extendedTypeInformation.TypeId, handleType);
        }
        handleType.Invoke(this, new object[] { declaration, result });
        return result;
    }

    public unsafe void HandleType<T>(InstanceDeclaration declaration, AssetBuffer buffer) where T : unmanaged
    {
        bool isBigEndian = _platform == TargetPlatform.Xbox360;
        XmlNamespaceManager namespaceManager = declaration.Document.NamespaceManager;
        XPathNavigator navigator = declaration.Node.CreateNavigator();
        Node node = new Node(navigator, namespaceManager);
        T* objT;
        using Tracker tracker = new Tracker((void**)&objT, (uint)sizeof(T), isBigEndian);
        if (!_marshalMethods.TryGetValue(declaration.Handle.TypeId, out Delegate marshal))
        {
            MethodInfo method = typeof(Marshaler).GetMethod(nameof(Marshaler.Marshal), new[] { typeof(Node), typeof(T*), typeof(Tracker) });
            if (method is null)
            {
                throw new BinaryAssetBuilderException(ErrorCode.InternalError, "Cannot find marshal method for type '{0}'", typeof(T*).Name);
            }
            marshal = Delegate.CreateDelegate(typeof(MarshalDelegate<T>), method);
            if (marshal is null)
            {
                throw new BinaryAssetBuilderException(ErrorCode.InternalError, "Cannot convert marshal method to delegate for type '{0}'", typeof(T*).Name);
            }
            _marshalMethods.Add(declaration.Handle.TypeId, marshal);
        }
        (marshal as MarshalDelegate<T>)(node, objT, tracker);
        WriteAssetBuffer(buffer, tracker);
    }
}
