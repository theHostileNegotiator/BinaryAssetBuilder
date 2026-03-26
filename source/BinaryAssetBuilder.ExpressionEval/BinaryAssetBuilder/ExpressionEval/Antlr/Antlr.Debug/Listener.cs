namespace BinaryAssetBuilder.ExpressionEval.Antlr.Debug;

public interface Listener
{
    void doneParsing(object source, TraceEventArgs e);

    void refresh();
}
