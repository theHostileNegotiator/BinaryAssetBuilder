namespace BinaryAssetBuilder.ExpressionEval.Antlr.Debug;

public interface TraceListener : Listener
{
    void enterRule(object source, TraceEventArgs e);

    void exitRule(object source, TraceEventArgs e);
}
