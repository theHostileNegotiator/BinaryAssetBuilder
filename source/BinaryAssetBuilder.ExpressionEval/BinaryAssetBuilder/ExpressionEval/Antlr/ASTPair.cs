using BinaryAssetBuilder.ExpressionEval.Antlr.Collections;
using System.Collections;

namespace BinaryAssetBuilder.ExpressionEval.Antlr;

public struct ASTPair
{
    public AST root; // current root of tree
    public AST child; // current child to which siblings are added

    /*Make sure that child is the last sibling */
    public void advanceChildToEnd()
    {
        if (child != null)
        {
            while (child.getNextSibling() != null)
            {
                child = child.getNextSibling();
            }
        }
    }

    /*Copy an ASTPair.  Don't call it clone() because we want type-safety */
    public ASTPair copy()
    {
        ASTPair tmp = new ASTPair();
        tmp.root = root;
        tmp.child = child;
        return tmp;
    }

    private void reset()
    {
        root = null;
        child = null;
    }

    override public string ToString()
    {
        string r = (root == null) ? "null" : root.getText();
        string c = (child == null) ? "null" : child.getText();
        return "[" + r + "," + c + "]";
    }
}
