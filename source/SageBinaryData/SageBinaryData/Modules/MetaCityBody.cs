#if KANESWRATH
using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct MetaCityBodyModuleData
{
    public MetaBodyModuleData Base;
    public Percentage SlightlyLowPopulationPercentage;
    public Percentage LowPopulationPercentage;
    public Percentage ReallyLowPopulationPercentage;
    public float MaxUnrest;
    public Percentage SlightlyLowUnrestPercentage;
    public Percentage LowUnrestPercentage;
    public Percentage ReallyLowUnrestPercentage;
    public float InitialUnrest;
    public int MinHumanCityTiberiumBonus;
    public int MaxHumanCityTiberiumBonus;
    public int ALIENCityTiberiumBonusPop;
    public Percentage ALIENCityTiberiumBonusPopTHRESHOLD;
}
#endif
