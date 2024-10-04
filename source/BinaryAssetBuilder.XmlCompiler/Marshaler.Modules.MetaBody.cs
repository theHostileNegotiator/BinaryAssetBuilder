#if KANESWRATH
using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, MetaBodyModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(MetaBodyModuleData.InfluenceRadius), "0.0"), &objT->InfluenceRadius, state);
        Marshal(node.GetAttributeValue(nameof(MetaBodyModuleData.TiberiumInfluence), "0.0"), &objT->TiberiumInfluence, state);
        Marshal(node.GetAttributeValue(nameof(MetaBodyModuleData.PopulationInfluence), "0.0"), &objT->PopulationInfluence, state);
        Marshal(node.GetAttributeValue(nameof(MetaBodyModuleData.UnrestInfluence), "0.0"), &objT->UnrestInfluence, state);
        Marshal(node.GetAttributeValue(nameof(MetaBodyModuleData.InfluenceDecayWithRange), "1.0"), &objT->InfluenceDecayWithRange, state);
        Marshal(node.GetAttributeValue(nameof(MetaBodyModuleData.DollarsPerTiberiumDamage), "0.0"), &objT->DollarsPerTiberiumDamage, state);
        Marshal(node.GetAttributeValue(nameof(MetaBodyModuleData.DollarsPerPopulationDamage), "0.0"), &objT->DollarsPerPopulationDamage, state);
        Marshal(node, (ActiveBodyModuleData*)objT, state);
    }
}
#endif
