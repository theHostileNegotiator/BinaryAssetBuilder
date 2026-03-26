namespace BinaryAssetBuilder.ExpressionEval.Antlr.Debug;

public abstract class GuessingEventArgs : ANTLREventArgs
{
    private int guessing_;

    public GuessingEventArgs()
    {
    }

    public GuessingEventArgs(int type) : base(type)
    {
    }

    public virtual void setValues(int type, int guessing)
    {
        setValues(type);
        Guessing = guessing;
    }

    public virtual int Guessing
    {
        get => guessing_;
        set => guessing_ = value;
    }
}
