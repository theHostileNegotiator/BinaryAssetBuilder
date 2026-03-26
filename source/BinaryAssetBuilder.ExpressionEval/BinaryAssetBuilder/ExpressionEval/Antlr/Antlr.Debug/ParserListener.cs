namespace BinaryAssetBuilder.ExpressionEval.Antlr.Debug
{
    public interface ParserListener :
        SemanticPredicateListener,
        Listener,
        ParserMatchListener,
        MessageListener,
        ParserTokenListener,
        TraceListener,
        SyntacticPredicateListener
    {
    }
}
