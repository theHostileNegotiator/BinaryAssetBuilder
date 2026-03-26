using System;

namespace BinaryAssetBuilder.ExpressionEval.Antlr;

[Serializable]
public class CharStreamException(string s) : ANTLRException(s)
{
}
