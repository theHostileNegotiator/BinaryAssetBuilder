#if KANESWRATH
using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, MetagameOperationsFactionalCost* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(MetagameOperationsFactionalCost.Faction), null), &objT->Faction, state);
        Marshal(node.GetAttributeValue(nameof(MetagameOperationsFactionalCost.Cost), "0"), &objT->Cost, state);
    }

    public static unsafe void Marshal(Node node, MetagameOperationsInfoType* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(MetagameOperationsInfoType.ID), null), &objT->ID, state);
        Marshal(node.GetAttributeValue(nameof(MetagameOperationsInfoType.Name), null), &objT->Name, state);
        Marshal(node.GetAttributeValue(nameof(MetagameOperationsInfoType.Description), null), &objT->Description, state);
        Marshal(node.GetAttributeValue(nameof(MetagameOperationsInfoType.MarkerTemplateName), ""), &objT->MarkerTemplateName, state);
        Marshal(node.GetAttributeValue(nameof(MetagameOperationsInfoType.NotificationPower), ""), &objT->NotificationPower, state);
        Marshal(node.GetAttributeValue(nameof(MetagameOperationsInfoType.IsInstantCast), "false"), &objT->IsInstantCast, state);
        Marshal(node.GetAttributeValue(nameof(MetagameOperationsInfoType.IsRepeating), "false"), &objT->IsRepeating, state);
        Marshal(node.GetAttributeValue(nameof(MetagameOperationsInfoType.TurnsToComplete), "0"), &objT->TurnsToComplete, state);
        Marshal(node.GetAttributeValue(nameof(MetagameOperationsInfoType.TurnsToCoolDown), "0"), &objT->TurnsToCoolDown, state);
        Marshal(node.GetAttributeValue(nameof(MetagameOperationsInfoType.PowerPrereqs), ""), &objT->PowerPrereqs, state);
        Marshal(node.GetAttributeValue(nameof(MetagameOperationsInfoType.EffectLength), "0s"), &objT->EffectLength, state);
        Marshal(node.GetChildNodes(nameof(MetagameOperationsInfoType.FactionalCost)), &objT->FactionalCost, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }
}
#endif
