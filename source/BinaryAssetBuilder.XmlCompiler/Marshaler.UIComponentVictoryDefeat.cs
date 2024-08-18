using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, UIComponentVictoryDefeat* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
#if KANESWRATH
        Marshal(node.GetChildNode(nameof(UIComponentVictoryDefeat.PostEndGameMusic), null), &objT->PostEndGameMusic, state);
        Marshal(node.GetChildNodes(nameof(UIComponentVictoryDefeat.EndGameMusicAlias)), &objT->EndGameMusicAlias, state);
#endif
        Marshal(node, (UIBaseComponent*)objT, state);
    }
}