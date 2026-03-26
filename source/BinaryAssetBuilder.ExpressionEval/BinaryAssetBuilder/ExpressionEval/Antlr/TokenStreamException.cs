using System;

namespace BinaryAssetBuilder.ExpressionEval.Antlr
{
    [Serializable]
    public class TokenStreamException : ANTLRException
    {
        public TokenStreamException()
        {
        }

        public TokenStreamException(string s) : base(s)
        {
        }
    }
}
