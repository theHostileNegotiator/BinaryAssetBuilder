namespace BinaryAssetBuilder.ExpressionEval.Antlr.Collections.Impl;

/*ASTArray is a class that allows ANTLR to
* generate code that can create and initialize an array
* in one expression, like:
*    (new ASTArray(3)).add(x).add(y).add(z)
*/
public class ASTArray
{
    public int size = 0;
    public AST[] array;


    public ASTArray(int capacity)
    {
        array = new AST[capacity];
    }
    public virtual ASTArray add(AST node)
    {
        array[size++] = node;
        return this;
    }
}
