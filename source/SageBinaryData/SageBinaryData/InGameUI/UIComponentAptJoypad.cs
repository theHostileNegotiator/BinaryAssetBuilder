using System;
using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct UIComponentAptJoypad
{
    public UIBaseComponent Base;
#if KANESWRATH
    public SageBool RelayLeftStickPosition;
    public SageBool RelayRightStickPosition;
#endif
}
