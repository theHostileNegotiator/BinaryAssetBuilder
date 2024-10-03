#if KANESWRATH
using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, MetaGameMapZoneEntry* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(MetaGameMapZoneEntry.MapName), ""), &objT->MapName, state);
    }

    public static unsafe void Marshal(Node node, MetaGameMapZoneGreen* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(MetaGameMapZoneGreen.MapEntry)), &objT->MapEntry, state);
    }

    public static unsafe void Marshal(Node node, MetaGameMapZoneYellow* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(MetaGameMapZoneYellow.MapEntry)), &objT->MapEntry, state);
    }

    public static unsafe void Marshal(Node node, MetaGameMapZoneRed* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(MetaGameMapZoneRed.MapEntry)), &objT->MapEntry, state);
    }

    public static unsafe void Marshal(Node node, MetaGameMapZonePlayerSet* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(MetaGameMapZonePlayerSet.GreenGroup), null), &objT->GreenGroup, state);
        Marshal(node.GetChildNode(nameof(MetaGameMapZonePlayerSet.YellowGroup), null), &objT->YellowGroup, state);
        Marshal(node.GetChildNode(nameof(MetaGameMapZonePlayerSet.RedGroup), null), &objT->RedGroup, state);
    }

    public static unsafe void Marshal(Node node, MetaGameMapZoneData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(MetaGameMapZoneData.Name), null), &objT->Name, state);
        Marshal(node.GetChildNode(nameof(MetaGameMapZoneData.Group2Player), null), &objT->Group2Player, state);
        Marshal(node.GetChildNode(nameof(MetaGameMapZoneData.Group3Player), null), &objT->Group3Player, state);
        Marshal(node.GetChildNode(nameof(MetaGameMapZoneData.Group4Player), null), &objT->Group4Player, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }
}
#endif
