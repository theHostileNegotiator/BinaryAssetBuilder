#if KANESWRATH
using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, StrikeForceElementTemplateType* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(StrikeForceElementTemplateType.Object), null), &objT->Object, state);
        Marshal(node.GetAttributeValue(nameof(StrikeForceElementTemplateType.Cost), "0"), &objT->Cost, state);
        Marshal(node.GetAttributeValue(nameof(StrikeForceElementTemplateType.Tier), "1"), &objT->Tier, state);
        Marshal(node.GetAttributeValue(nameof(StrikeForceElementTemplateType.Maximum), "50"), &objT->Maximum, state);
        Marshal(node.GetAttributeValue(nameof(StrikeForceElementTemplateType.PopCount), "1"), &objT->PopCount, state);
        Marshal(node.GetAttributeValue(nameof(StrikeForceElementTemplateType.DisplayName), "missing display name"), &objT->DisplayName, state);
        Marshal(node.GetAttributeValue(nameof(StrikeForceElementTemplateType.Description), "missing description name"), &objT->Description, state);
        Marshal(node.GetAttributeValue(nameof(StrikeForceElementTemplateType.TypeDescription), "missing type Description name"), &objT->TypeDescription, state);
        Marshal(node.GetAttributeValue(nameof(StrikeForceElementTemplateType.ButtonImage), null), &objT->ButtonImage, state);
    }

    public static unsafe void Marshal(Node node, StrikeForceElementTemplateListType* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(StrikeForceElementTemplateListType.StrikeForceElementTemplate)), &objT->StrikeForceElementTemplate, state);
    }

    public static unsafe void Marshal(Node node, StrikeForceElementTemplateListType** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(StrikeForceElementTemplateListType), 1u);
        Marshal(node, *objT, state);
    }

    public static unsafe void Marshal(Node node, StrikeForceBuildTemplate* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(StrikeForceBuildTemplate.Side), null), &objT->Side, state);
        Marshal(node.GetAttributeValue(nameof(StrikeForceBuildTemplate.UltraLightCost), "2500"), &objT->UltraLightCost, state);
        Marshal(node.GetAttributeValue(nameof(StrikeForceBuildTemplate.LightCost), "7500"), &objT->LightCost, state);
        Marshal(node.GetAttributeValue(nameof(StrikeForceBuildTemplate.MediumCost), "12500"), &objT->MediumCost, state);
        Marshal(node.GetAttributeValue(nameof(StrikeForceBuildTemplate.HeavyCost), "20000"), &objT->HeavyCost, state);
        Marshal(node.GetAttributeValue(nameof(StrikeForceBuildTemplate.UltraHeavyCost), "25000"), &objT->UltraHeavyCost, state);
        Marshal(node.GetAttributeValue(nameof(StrikeForceBuildTemplate.UltraLightMapRep), null), &objT->UltraLightMapRep, state);
        Marshal(node.GetAttributeValue(nameof(StrikeForceBuildTemplate.LightMapRep), null), &objT->LightMapRep, state);
        Marshal(node.GetAttributeValue(nameof(StrikeForceBuildTemplate.MediumMapRep), null), &objT->MediumMapRep, state);
        Marshal(node.GetAttributeValue(nameof(StrikeForceBuildTemplate.HeavyMapRep), null), &objT->HeavyMapRep, state);
        Marshal(node.GetAttributeValue(nameof(StrikeForceBuildTemplate.UltraHeavyMapRep), null), &objT->UltraHeavyMapRep, state);
        Marshal(node.GetAttributeValue(nameof(StrikeForceBuildTemplate.MaxPop), "50"), &objT->MaxPop, state);
        Marshal(node.GetChildNode(nameof(StrikeForceBuildTemplate.Support), null), &objT->Support, state);
        Marshal(node.GetChildNode(nameof(StrikeForceBuildTemplate.Infantry), null), &objT->Infantry, state);
        Marshal(node.GetChildNode(nameof(StrikeForceBuildTemplate.Vehicles), null), &objT->Vehicles, state);
        Marshal(node.GetChildNode(nameof(StrikeForceBuildTemplate.Aircraft), null), &objT->Aircraft, state);
        Marshal(node, (BaseInheritableAsset*)objT, state);
    }
}
#endif
