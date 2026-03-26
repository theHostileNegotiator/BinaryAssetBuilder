using BinaryAssetBuilder.ExpressionEval.Antlr.Collections;

namespace BinaryAssetBuilder.ExpressionEval.Antlr
{
    public abstract class ASTNodeCreator
    {
        public abstract AST Create();

        public abstract string ASTNodeTypeName { get; }
    }
}
