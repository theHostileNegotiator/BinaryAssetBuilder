namespace BinaryAssetBuilder.ExpressionEval.Antlr.Debug;

public interface SemanticPredicateListener : Listener
{
    void semanticPredicateEvaluated(object source, SemanticPredicateEventArgs e);
}
