#if KANESWRATH
using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct UnitAbilityButtonTemplateDataRef : IPolymorphic
{
    public uint TypeId;
}

[StructLayout(LayoutKind.Sequential)]
public struct SingleStateUnitAbilityButtonTemplateData
{
    public UnitAbilityButtonTemplateDataRef Base;
    public AssetReference<ButtonSingleStateData> StateData;
}

[StructLayout(LayoutKind.Sequential)]
public struct BuildWallUnitAbilityButtonTemplateData
{
    public SingleStateUnitAbilityButtonTemplateData Base;
}

[StructLayout(LayoutKind.Sequential)]
public struct EvacuateUnitAbilityButtonTemplateData
{
    public SingleStateUnitAbilityButtonTemplateData Base;
}

[StructLayout(LayoutKind.Sequential)]
public struct ObjectUpgradeUnitAbilityButtonTemplateData
{
    public SingleStateUnitAbilityButtonTemplateData Base;
}

[StructLayout(LayoutKind.Sequential)]
public struct PlayerUpgradeUnitAbilityButtonTemplateData
{
    public SingleStateUnitAbilityButtonTemplateData Base;
}

[StructLayout(LayoutKind.Sequential)]
public struct StanceUnitAbilityButtonTemplateData
{
    public SingleStateUnitAbilityButtonTemplateData Base;
    public Stance StanceType;
}

[StructLayout(LayoutKind.Sequential)]
public struct SpecialPowerUnitAbilityButtonTemplateData
{
    public SingleStateUnitAbilityButtonTemplateData Base;
}

[StructLayout(LayoutKind.Sequential)]
public struct TargetedSpecialPowerUnitAbilityButtonTemplateData
{
    public SpecialPowerUnitAbilityButtonTemplateData Base;
    public AnsiString ValidTargetCursor;
    public AnsiString InvalidTargetCursor;
    public AnsiString RadiusCursor;
}

[StructLayout(LayoutKind.Sequential)]
public struct MultiplePowersTargetedSpecialPowerUnitAbilityButtonTemplateData
{
    public TargetedSpecialPowerUnitAbilityButtonTemplateData Base;
    public List<AssetReference<SpecialPowerTemplate>> AdditionalSpecialPowerTemplate;
    public List<AnsiString> AdditionalRadiusCursor;
}

[StructLayout(LayoutKind.Sequential)]
public struct ProductionQueueUnitAbilityButtonTemplateData
{
    public SingleStateUnitAbilityButtonTemplateData Base;
    public ProductionQueueType ProductionQueue;
}

[StructLayout(LayoutKind.Sequential)]
public struct UnitAbilityButtonTemplate
{
    public BaseInheritableAsset Base;
    public AssetReference<LogicCommand> LogicCommand;
    public unsafe UnitAbilityButtonTemplateDataRef* Data;
}
#endif
