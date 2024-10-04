#if KANESWRATH
using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct MetaTiberiumBodyModuleData
{
    public MetaBodyModuleData Base;
    public Percentage SlightlyLowTiberiumPercentage;
    public Percentage LowTiberiumPercentage;
    public Percentage ReallyLowTiberiumPercentage;
}
#endif
