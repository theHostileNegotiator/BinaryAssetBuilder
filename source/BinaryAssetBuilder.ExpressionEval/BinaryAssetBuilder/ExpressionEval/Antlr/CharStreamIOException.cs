using System;
using System.IO;

namespace BinaryAssetBuilder.ExpressionEval.Antlr;

[Serializable]
public class CharStreamIOException : CharStreamException
{
    public IOException io;

    public CharStreamIOException(IOException io) : base(io.Message)
    {
        this.io = io;
    }
}