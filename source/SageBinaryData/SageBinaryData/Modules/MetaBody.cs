#if KANESWRATH
using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct MetaBodyModuleData
{
    public ActiveBodyModuleData Base;
    public float InfluenceRadius;
    public float TiberiumInfluence;
    public float PopulationInfluence;
    public float UnrestInfluence;
    public float InfluenceDecayWithRange;
    public float DollarsPerTiberiumDamage;
    public float DollarsPerPopulationDamage;
}
#endif
