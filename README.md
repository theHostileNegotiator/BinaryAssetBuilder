# BinaryAssetBuilder
BinaryAssetBuilder implementation for Kane's Wrath in .Net Core

### First Version will be for Tiberium Wars
I decided to first make a TW version so I can be sure everything works.

### Implemented Asset Types
* [ ] TestGameObject
* [ ] TestTexture
* [ ] TestTextureCollection
* [x] WeaponTemplate                                            0xE3996069
* [x] LocomotorTemplate                                         0xBD8F61A4
* [ ] GameObject
* [ ] FXParticleSystemTemplate
* [x] Weather                                                   0x368A8BA2
* [x] ShadowMap                                                 0xC6389FA6
* [x] WaterTransparency                                         0x331DA6CE
* [ ] Texture
* [ ] OnDemandTexture
* [ ] W3DMesh
* [ ] W3DContainer
* [ ] W3DHierarchy
* [x] W3DAnimation                                              0xCC069193
* [ ] W3DCollisionBox
* [ ] ArmyDefinition
* [ ] AIPersonalityDefinition
* [ ] FXList
* [ ] ObjectCreationList
* [ ] ObjectFilterAsset
* [ ] SpecialPowerTemplate
* [ ] UpgradeTemplate
* [ ] SkirmishOpeningMove
* [ ] AIStateDefinition
* [ ] AIStrategicStateDefinition
* [ ] AIBudgetStateDefinition
* [ ] AITargetingHeuristic
* [ ] GameMap
* [ ] AttributeModifier
* [ ] ArmorTemplate
* [ ] MissionTemplate
* [ ] TheaterOfWarTemplate
* [ ] CampaignTemplate
* [ ] RadiusCursorLibrary
* [ ] AudioFile
* [ ] AudioEvent
* [ ] MusicTrack
* [ ] DialogEvent
* [ ] AmbientStream
* [ ] Multisound
* [ ] MusicPalette
* [ ] MusicScriptConditionNugget_LocalPlayerIsObserver
* [ ] MusicScriptConditionNugget_UnitsFarFromBase
* [ ] MusicScriptConditionNugget_TimeFromStartOfLevel
* [ ] MusicScriptConditionNugget_TrackPlayedCount
* [ ] MusicScriptConditionNugget_SpecificTrackTypePlaying
* [ ] MusicScriptConditionNugget_AnyTrackPlaying
* [ ] MusicScriptConditionNugget_ObjectsOfTypeExist
* [ ] MusicScriptConditionNugget_EvaEventPlayedRecently
* [ ] MusicScriptConditionNugget_ObjectsNearEvaEvent
* [ ] MusicScriptConditionNugget_ScoredKillCount
* [ ] MusicScriptConditionNugget_Not
* [ ] MusicScriptConditionNugget_Or
* [ ] MusicScriptConditionNugget_And
* [ ] MusicScriptTrack
* [ ] LocalBuildListMonitor
* [x] MpGameRules                                               0xEDDBB607
* [ ] ExperienceLevelTemplate
* [ ] MissionObjectiveList
* [ ] StringHashTable
* [ ] InGameUISettings
* [ ] DamageFX
* [ ] MultiplayerSettings
* [ ] OnlineChatColors
* [ ] MultiplayerColor
* [ ] GameLODPreset
* [ ] StaticGameLOD
* [ ] DynamicGameLOD
* [ ] AudioLOD
* [ ] VideoEventList
* [ ] UIConfigList
* [x] PackedTextureImage                                        0x2FAEB748
* [ ] OnDemandTextureImage
* [ ] TerrainTextureAtlas
* [ ] Mouse
* [x] Achievement                                               0xC8D16E6D
* [ ] StanceTemplate
* [ ] TargetingCompareList
* [ ] TargetingDistanceCompare
* [ ] TargetingCombatChainCompare
* [ ] TargetingInTurretArcCompare
* [ ] Road
* [ ] Environment
* [x] LogicCommand                                              0x97D0A46E
* [x] LogicCommandSet                                           0x6D148BD7
* [ ] MiscAudio
* [ ] AudioSettings
* [ ] CrowdResponse
* [ ] MapMetaData
* [ ] LargeGroupAudioMap
* [ ] AptAptData
* [ ] AptConstData
* [ ] AptDatData
* [ ] AptGeometryData
* [ ] MappableKey
* [x] HotKeySlot                                                0x1AC54E60
* [ ] DefaultHotKeys
* [ ] InGameUIGroupSelectionCommandSlots
* [ ] InGameUILookAtCommandSlots
* [ ] InGameUITacticalCommandSlots
* [ ] InGameUIVoiceChatCommandSlots
* [ ] InGameUISideBarCommandSlots
* [ ] InGameUIPlayerPowerCommandSlots
* [ ] InGameUIUnitAbilityCommandSlots
* [ ] GameSCriptList
* [x] IntelDB                                                   0xFBB64F90
* [ ] BootupDisplaySequence
* [ ] UnitTypeIcon
* [x] ImageSequence                                             0x217CF953
* [x] UnitOverlayIconSettings                                   0xDFC78E66
* [x] TheVersion                                                0xF659EF49
* [x] DLContent                                                 0x4E1A5713
* [x] PhaseEffect                                               0x4877D566
* [x] ConnectionLineManager                                     0x7AEB73B2
* [x] InGameUIFixedElementHotKeySlotMap                         0x475EA260

### Tiberium Wars Only Types
* [ ] AudioFileMP3Passthrough
* [ ] MP3MusicTrack
* [ ] MP3DialogEvent
* [ ] MP3AmbientStream
* [ ] UnitAbilityButtonTemplateStore
* [ ] PlayerPowerButtonTemplateStore
* [x] CommandSet                                                0x3CFF78A1

### Kane's Wrath Only Types
* [ ] UnitAbilityButtonTemplate
* [ ] PlayerPowerButtonTemplate
* [ ] StrikeForceBuildTemplate
* [ ] MetagameOperationsInfoType
* [ ] MetaGameUITacticalCommandSlots
* [ ] MetaGameUICommonOpCommandSlots
* [ ] MetaGameMapZoneData
* [ ] MetaGameStaticData
* [ ] ButtonSingleStateData
* [ ] JoypadCommandBarTemplate
* [ ] JoypadCommandBarButtonTemplate
* [ ] UIJoypadCommandBarButtonBuild
* [ ] UIJoypadCommandBarHomogenousGroup
* [ ] UIJoypadCommandBarMixedGroup
* [ ] UIJoypadCommandBarSingleUnit
* [ ] UIJoypadCommandBarStances
* [ ] UIJoypadCommandBarTopMenu
* [ ] UIJoypadCommandBarMgTopMenu
