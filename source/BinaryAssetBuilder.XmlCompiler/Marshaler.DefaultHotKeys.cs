using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, HotKeyDef* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(HotKeyDef.Slot), null), &objT->Slot, state);
        Marshal(node.GetAttributeValue(nameof(HotKeyDef.Key), null), &objT->Key, state);
        Marshal(node.GetAttributeValue(nameof(HotKeyDef.Modifiers), null), &objT->Modifiers, state);
    }

    public static unsafe void Marshal(Node node, HotKeyMap* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(HotKeyMap.HotKey)), &objT->HotKey, state);
    }

#if KANESWRATH
    public static unsafe void Marshal(Node node, HotKeyGroupingDef* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(HotKeyGroupingDef.Name), null), &objT->Name, state);
    }

    public static unsafe void Marshal(Node node, HotKeyGrouping* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(HotKeyGrouping.Name), null), &objT->Name, state);
        Marshal(node.GetChildNodes(nameof(HotKeyGrouping.IgnoreConflict)), &objT->IgnoreConflict, state);
        Marshal(node.GetChildNodes(nameof(HotKeyGrouping.Group)), &objT->Group, state);
        Marshal(node.GetChildNodes(nameof(HotKeyGrouping.Slot)), &objT->Slot, state);
    }

    public static unsafe void Marshal(Node node, HotKeyGroupingList* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(HotKeyGroupingList.HotKeyGroup)), &objT->HotKeyGroup, state);
    }
#endif

    public static unsafe void Marshal(Node node, DefaultHotKeys* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(DefaultHotKeys.Map), null), &objT->Map, state);
#if KANESWRATH
        Marshal(node.GetChildNode(nameof(DefaultHotKeys.Groups), null), &objT->Groups, state);
#endif
        Marshal(node, (BaseInheritableAsset*)objT, state);
    }
}
