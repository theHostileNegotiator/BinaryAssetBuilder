namespace BinaryAssetBuilder.ExpressionEval.Antlr;

public class TreeParserSharedInputState
{
    /*Are we guessing (guessing>0)? */
    public int guessing = 0;

    public virtual void reset()
    {
        guessing = 0;
    }
}
