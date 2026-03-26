using BinaryAssetBuilder.ExpressionEval.Antlr.Collections;
using System;

namespace BinaryAssetBuilder.ExpressionEval.Antlr;

[Serializable]
public class NoViableAltException : RecognitionException
{
    public IToken token;
    public AST node; // handles parsing and treeparsing

    public NoViableAltException(AST t) : base("NoViableAlt", "<AST>", -1, -1)
    {
        node = t;
    }

    public NoViableAltException(IToken t, string fileName_) :
                base("NoViableAlt", fileName_, t.getLine(), t.getColumn())
    {
        token = t;
    }

    /*
    * Returns a clean error message (no line number/column information)
    */
    override public string Message
    {
        get
        {
            if (token != null)
            {
                //return "unexpected token: " + token.getText();
                return "unexpected token: " + token.ToString();
            }

            // must a tree parser error if token==null
            if ((node == null) || (node == TreeParser.ASTNULL))
            {
                return "unexpected end of subtree";
            }
            return "unexpected AST node: " + node.ToString();
        }
    }
}
