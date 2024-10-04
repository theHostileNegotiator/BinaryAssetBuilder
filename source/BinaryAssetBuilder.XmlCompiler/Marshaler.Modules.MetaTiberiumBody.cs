#if KANESWRATH
using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, MetaTiberiumBodyModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(MetaTiberiumBodyModuleData.SlightlyLowTiberiumPercentage), "75%"), &objT->SlightlyLowTiberiumPercentage, state);
        Marshal(node.GetAttributeValue(nameof(MetaTiberiumBodyModuleData.LowTiberiumPercentage), "50%"), &objT->LowTiberiumPercentage, state);
        Marshal(node.GetAttributeValue(nameof(MetaTiberiumBodyModuleData.ReallyLowTiberiumPercentage), "25%"), &objT->ReallyLowTiberiumPercentage, state);
        Marshal(node, (MetaBodyModuleData*)objT, state);
    }
}
#endif
