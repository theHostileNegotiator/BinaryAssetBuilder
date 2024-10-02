#if KANESWRATH
using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct PlayerPowerButtonTemplateDataRef : IPolymorphic
{
    public uint TypeId;
    public AssetReference<ButtonSingleStateData> StateData;
}

[StructLayout(LayoutKind.Sequential)]
public struct TargetedPlayerPowerButtonTemplateData
{
    public PlayerPowerButtonTemplateDataRef Base;
    public AnsiString ValidTargetCursor;
    public AnsiString InvalidTargetCursor;
    public AnsiString RadiusCursor;
}

[StructLayout(LayoutKind.Sequential)]
public struct MultipleTargetsTargetedPlayerPowerButtonTemplateData
{
    public TargetedPlayerPowerButtonTemplateData Base;
    public TypedAssetId<GameObject> TargetMarkerTemplate;
    public uint TargetCount;
    public float MinTargetDistance;
}

[StructLayout(LayoutKind.Sequential)]
public struct MultiplePowersTargetedPlayerPowerButtonTemplateData
{
    public TargetedPlayerPowerButtonTemplateData Base;
    public List<AssetReference<SpecialPowerTemplate>> AdditionalSpecialPowerTemplate;
    public List<AnsiString> AdditionalRadiusCursor;
}

[StructLayout(LayoutKind.Sequential)]
public struct PlayerPowerButtonTemplate
{
    public BaseInheritableAsset Base;
    public AssetReference<SpecialPowerTemplate> SpecialPower;
    public unsafe PlayerPowerButtonTemplateDataRef* Data;
}
#endif
