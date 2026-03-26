namespace BinaryAssetBuilder.ExpressionEval.Antlr.Debug;

public interface ParserTokenListener : Listener
{
    void parserConsume(object source, TokenEventArgs e);

    void parserLA(object source, TokenEventArgs e);
}
