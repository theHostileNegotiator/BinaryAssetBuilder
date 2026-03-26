using System;

namespace BinaryAssetBuilder.ExpressionEval.Antlr
{
    [Serializable]
    public class TokenStreamRecognitionException : TokenStreamException
    {
        public RecognitionException recog;

        public TokenStreamRecognitionException(RecognitionException re)
            : base(re.Message)
        {
            recog = re;
        }

        public override string ToString()
        {
            return recog.ToString();
        }
    }

}
