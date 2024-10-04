#if KANESWRATH
using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, MetaGameAIUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(MetaGameAIUpdateModuleData.EngageRadius), "0.0"), &objT->EngageRadius, state);
        Marshal(node, (AIUpdateModuleData*)objT, state);
    }
}
#endif
