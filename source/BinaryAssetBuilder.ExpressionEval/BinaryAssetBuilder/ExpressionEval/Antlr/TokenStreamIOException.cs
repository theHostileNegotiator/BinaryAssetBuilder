using System;
using System.IO;

namespace BinaryAssetBuilder.ExpressionEval.Antlr
{
    [Serializable]
    public class TokenStreamIOException : TokenStreamException
    {
        public IOException io;

        public TokenStreamIOException(IOException io) : base(io.Message)
        {
            this.io = io;
        }
    }
}
