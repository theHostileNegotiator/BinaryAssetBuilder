#if KANESWRATH
using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct ButtonSingleStateData
{
    public BaseAssetType Base;
    public ButtonState State;
}
#endif
