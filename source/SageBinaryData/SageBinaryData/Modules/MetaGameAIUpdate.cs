#if KANESWRATH
using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct MetaGameAIUpdateModuleData
{
    public AIUpdateModuleData Base;
    public float EngageRadius;
}
#endif
