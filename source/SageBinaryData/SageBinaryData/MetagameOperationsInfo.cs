#if KANESWRATH
using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct MetagameOperationsFactionalCost
{
    public FactionType Faction;
    public int Cost;
}

[StructLayout(LayoutKind.Sequential)]
public struct MetagameOperationsInfoType
{
    public BaseAssetType Base;
    public MetagameOperationsEnums ID;
    public AnsiString Name;
    public AnsiString Description;
    public AnsiString MarkerTemplateName;
    public AnsiString ObjectMarkerTemplateName;
    public AssetReference<SpecialPowerTemplate> NotificationPower;
    public uint TurnsToComplete;
    public uint TurnsToCoolDown;
    public MGPowerPrereqBitFlags PowerPrereqs;
    public Time EffectLength;
    public List<MetagameOperationsFactionalCost> FactionalCost;
    public SageBool IsInstantCast;
    public SageBool IsRepeating;
}
#endif
