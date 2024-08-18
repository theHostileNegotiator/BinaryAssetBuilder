#if KANESWRATH
using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct UIComponentMode
{
    public UIBaseComponent Base;
}
#endif