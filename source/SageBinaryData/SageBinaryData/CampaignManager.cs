using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData;

public enum CampaignFlagType
{
    Use_Alternate_Ending,
    Use_Alternate_Campaign_Failure,
    LUNCH_AT_IHOP,
    GDI_1_2_CampaignFlag_Snipers_Rescued,
    GDI_1_3_CampaignFlag_Mission_Complete,
    GDI_4_2_CampaignFlag_PlayedFirst,
    GDI_4_2_CampaignFlag_SnipersRescued,
    GDI_4_2_ZoneTroopersRescued,
    GDI_4_2_CommandoWin,
    GDI_4_3_CampaignFlag_PlayedFirst,
    GDI_4_3_Reinforcements,
    NOD_1_1_CampaignFlag_LessGroundForces,
    NOD_1_1_CampaignFlag_Attack_Bike_IDB,
    NOD_1_2_CampaignFlag_NoOrcas,
    NOD_4_2_CampaignFlag_IonCannonDestroyed,
    NOD_5_2_CampaignFlag_Stasis_Chamber_Destroyed,
    NOD_5_2_CampaignFlag_GravityStabilizer_Destroyed,
    Alien_1_2_CampaignFlag_Mastermind_Survived,
#if KANESWRATH
    MM_1_DestroyLab_Activated,
    MM_1_DestroyLab_Completed,
    MM_1_DestroyLab_Failed,
    MM_2_DefendLab_Activated,
    MM_2_DefendLab_Completed,
    MM_2_DefendLab_Failed,
    MM_3_CaptureLab_Activated,
    MM_3_CaptureLab_Completed,
    MM_3_CaptureLab_Failed,
    MM_4_DefendConvoy_Activated,
    MM_4_DefendConvoy_Completed,
    MM_4_DefendConvoy_Failed,
    MM_5_DestroyConvoy_Activated,
    MM_5_DestroyConvoy_Completed,
    MM_5_DestroyConvoy_Failed,
    MM_6_PowerDown_Activated,
    MM_6_PowerDown_Completed,
    MM_6_PowerDown_Failed,
    MM_7_8_9_BuildLoc_Activated,
    MM_7_8_9_BuildLoc_Completed,
    MM_7_8_9_BuildLoc_Failed,
    MM_10_11_12_MechCapture_Activated,
    MM_10_11_12_MechCapture_Completed,
    MM_10_11_12_MechCapture_Failed,
    MM_13_14_15_ConyardCapture_Activated,
    MM_13_14_15_ConyardCapture_Completed,
    MM_13_14_15_ConyardCapture_Failed,
    MM_16_17_18_RefineryCapture_Activated,
    MM_16_17_18_RefineryCapture_Completed,
    MM_16_17_18_RefineryCapture_Failed,
    MM_19_TibSpikeCapture_Activated,
    MM_19_TibSpikeCapture_Completed,
    MM_19_TibSpikeCapture_Failed,
    MM_20_Tiberium_Activated,
    MM_20_Tiberium_Completed,
    MM_20_Tiberium_Failed,
    MM_21_CaptureAndHold_Activated,
    MM_21_CaptureAndHold_Completed,
    MM_21_CaptureAndHold_Failed,
    MM_22_23_24_NoAir_Activated,
    MM_22_23_24_NoAir_Completed,
    MM_22_23_24_NoAir_Failed,
    MM_25_26_27_NoArmor_Activated,
    MM_25_26_27_NoArmor_Completed,
    MM_25_26_27_NoArmor_Failed,
    MM_28_29_30_NoInfantry_Activated,
    MM_28_29_30_NoInfantry_Completed,
    MM_28_29_30_NoInfantry_Failed,
    MM_31_SuperWeaponRace_Activated,
    MM_31_SuperWeaponRace_Completed,
    MM_31_SuperWeaponRace_Failed,
    CM_StealthTech_Activated,
    CM_StealthTech_Completed,
    CM_StealthTech_Failed,
    CM_BlackHand_Activated,
    CM_BlackHand_Completed,
    CM_BlackHand_Failed,
    CM_TibResearch_Activated,
    CM_TibResearch_Completed,
    CM_TibResearch_Failed,
    CM_Treasury_Activated,
    CM_Treasury_Completed,
    CM_Treasury_Failed,
    CM_MARV_Activated,
    CM_MARV_Completed,
    CM_MARV_Failed,
    CM_Giraud_Activated,
    CM_Giraud_Completed,
    CM_Giraud_Failed,
    CM_Munich_Activated,
    CM_Munich_Completed,
    CM_Munich_Failed,
    CM_TacitusA_Activated,
    CM_TacitusA_Completed,
    CM_TacitusA_Failed,
    CM_TacitusB_Activated,
    CM_TacitusB_Completed,
    CM_TacitusB_Failed,
    MM_General_Activate,
    MM_General_PreTacticalCheck,
    MM_General_PostTacticalCheck,
    MM_MetagameActive
#endif
}

[StructLayout(LayoutKind.Sequential)]
public struct CampaignFlagBitFlags
{
    public const int Count = 0x00000012;
    public const int BitsInSpan = 32;
    public const int NumSpans = (Count + (BitsInSpan - 1)) / BitsInSpan;

    public unsafe fixed uint Value[NumSpans];
}

[StructLayout(LayoutKind.Sequential)]
public struct MissionTemplate
{
    public BaseAssetType Base;
    public AnsiString IntroMovieName;
    public AnsiString DisplayName;
    public AnsiString Title;
    public AnsiString BriefingText;
    public AnsiString BriefingMovie;
    public AnsiString LoadScreenImage;
    public AnsiString LoadScreenText;
    public unsafe AssetReference<BaseAudioEventInfo, AudioEventInfo>* LoadScreenMusic;
    public unsafe AssetReference<BaseAudioEventInfo, AudioEventInfo>* LoadScreenVoice;
    public AnsiString MapName;
    public AnsiString VictoryMovieName;
    public AnsiString DefeatMovieName;
    public List<int> Prerequisite;
    public List<AnsiString> Objective;
    public List<AnsiString> BonusObjective;
    public SageBool BriefingMovieFullScreen;
    public SageBool RequiredToCompleteTheaterOfWar;
}

[StructLayout(LayoutKind.Sequential)]
public struct TheaterOfWarTemplate
{
    public BaseAssetType Base;
    public AnsiString DisplayName;
    public AnsiString AptTow;
    public int AutoStartMission;
    public unsafe AssetReference<BaseAudioEventInfo, AudioEventInfo>* SummaryScreenMusic;
    public unsafe AssetReference<BaseAudioEventInfo, AudioEventInfo>* SelectionScreenMusic;
    public List<AssetReference<MissionTemplate>> Mission;
}

[StructLayout(LayoutKind.Sequential)]
public struct CampaignTemplate
{
    public BaseAssetType Base;
    public AnsiString DisplayName;
    public AnsiString FinalMovie;
    public AnsiString AlternateFinalMovie;
    public AnsiString ConsoleAutosaveFilename;
    public List<AssetReference<TheaterOfWarTemplate>> TheaterOfWar;
}
