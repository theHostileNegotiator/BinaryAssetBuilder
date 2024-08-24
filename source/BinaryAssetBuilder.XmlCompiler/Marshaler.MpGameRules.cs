using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, SkirmishStartCash* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(SkirmishStartCash.LoCash), null), &objT->LoCash, state);
        Marshal(node.GetAttributeValue(nameof(SkirmishStartCash.HiCash), null), &objT->HiCash, state);
        Marshal(node.GetAttributeValue(nameof(SkirmishStartCash.ChoiceStepAmount), null), &objT->ChoiceStepAmount, state);
        Marshal(node.GetAttributeValue(nameof(SkirmishStartCash.DefaultChoiceIndex), "1"), &objT->DefaultChoiceIndex, state);
    }

#if KANESWRATH
    public static unsafe void Marshal(Node node, valueAndDifficulty* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(valueAndDifficulty.value), null), &objT->value, state);
        Marshal(node.GetAttributeValue(nameof(valueAndDifficulty.difficulty), null), &objT->difficulty, state);
    }

    public static unsafe void Marshal(Node node, listDefaultValueDifficulty* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(listDefaultValueDifficulty.DefaultChoiceIndex), "1"), &objT->DefaultChoiceIndex, state);
        Marshal(node.GetChildNodes(nameof(listDefaultValueDifficulty.entry)), &objT->entry, state);
    }
#endif

    public static unsafe void Marshal(Node node, MpGameRules* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(MpGameRules.SkirmishStartCash), null), &objT->SkirmishStartCash, state);
#if KANESWRATH
        Marshal(node.GetChildNode(nameof(MpGameRules.MetaGameTiberiumSupply), null), &objT->MetaGameTiberiumSupply, state);
        Marshal(node.GetChildNode(nameof(MpGameRules.MetaGameTiberiumInfestation), null), &objT->MetaGameTiberiumInfestation, state);
        Marshal(node.GetChildNode(nameof(MpGameRules.MetaGameOPsPoints), null), &objT->MetaGameOPsPoints, state);
        Marshal(node.GetChildNode(nameof(MpGameRules.MetaGameCoreObjectives), null), &objT->MetaGameCoreObjectives, state);
#endif
        Marshal(node, (BaseAssetType*)objT, state);
    }
}