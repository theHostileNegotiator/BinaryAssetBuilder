using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, W3DSpotlightDrawModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(W3DSpotlightDrawModuleData.RefreshTime), "1s"), &objT->RefreshTime, state);
        Marshal(node.GetAttributeValue(nameof(W3DSpotlightDrawModuleData.SweepTime), "1s"), &objT->SweepTime, state);
#if KANESWRATH
        Marshal(node.GetAttributeValue(nameof(W3DSpotlightDrawModuleData.AlwaysOn), "false"), &objT->AlwaysOn, state);
#endif
        Marshal(node, (W3DScriptedModelDrawModuleData*)objT, state);
    }
}