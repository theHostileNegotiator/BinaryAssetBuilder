#if KANESWRATH
using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct MetaSFBodyModuleData
{
    public MetaBodyModuleData Base;
}
#endif
