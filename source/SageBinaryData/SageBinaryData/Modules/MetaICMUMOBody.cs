#if KANESWRATH
using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct MetaICMUMOBodyModuleData
{
    public MetaBodyModuleData Base;
}
#endif
