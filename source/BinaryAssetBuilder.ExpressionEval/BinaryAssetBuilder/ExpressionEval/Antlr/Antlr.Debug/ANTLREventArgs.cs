using System;

namespace BinaryAssetBuilder.ExpressionEval.Antlr.Debug;

public abstract class ANTLREventArgs : EventArgs
{
    private int type_;

    public ANTLREventArgs()
    {
    }

    public ANTLREventArgs(int type) => Type = type;

    internal void setValues(int type) => Type = type;

    public virtual int Type
    {
        get => type_;
        set => type_ = value;
    }
}
