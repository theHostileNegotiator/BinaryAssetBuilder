using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, UIComponentAptJoypad* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(UIComponentAptJoypad.RelayLeftStickPosition), "false"), &objT->RelayLeftStickPosition, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentAptJoypad.RelayRightStickPosition), "false"), &objT->RelayRightStickPosition, state);
        Marshal(node, (UIBaseComponent*)objT, state);
    }
}