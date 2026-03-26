namespace BinaryAssetBuilder.ExpressionEval.Antlr.Debug;

public interface MessageListener : Listener
{
    void reportError(object source, MessageEventArgs e);

    void reportWarning(object source, MessageEventArgs e);
}
