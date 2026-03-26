using BinaryAssetBuilder.ExpressionEval.Antlr.Collections;
using System;

namespace BinaryAssetBuilder.ExpressionEval.Antlr;

public class CommonASTWithHiddenTokens : CommonAST
{
    new public static readonly CommonASTWithHiddenTokens.CommonASTWithHiddenTokensCreator Creator = new CommonASTWithHiddenTokensCreator();

    protected internal IHiddenStreamToken hiddenBefore, hiddenAfter; // references to hidden tokens

    public CommonASTWithHiddenTokens() : base()
    {
    }

    public CommonASTWithHiddenTokens(IToken tok) : base(tok)
    {
    }

    [Obsolete("Deprecated since version 2.7.2. Use ASTFactory.dup() instead.", false)]
    protected CommonASTWithHiddenTokens(CommonASTWithHiddenTokens another) : base(another)
    {
        hiddenBefore = another.hiddenBefore;
        hiddenAfter = another.hiddenAfter;
    }

    public virtual IHiddenStreamToken getHiddenAfter()
    {
        return hiddenAfter;
    }

    public virtual IHiddenStreamToken getHiddenBefore()
    {
        return hiddenBefore;
    }

    override public void initialize(AST t)
    {
        hiddenBefore = ((CommonASTWithHiddenTokens)t).getHiddenBefore();
        hiddenAfter = ((CommonASTWithHiddenTokens)t).getHiddenAfter();
        base.initialize(t);
    }

    override public void initialize(IToken tok)
    {
        IHiddenStreamToken t = (IHiddenStreamToken)tok;
        base.initialize(t);
        hiddenBefore = t.getHiddenBefore();
        hiddenAfter = t.getHiddenAfter();
    }

    #region Implementation of ICloneable
    [Obsolete("Deprecated since version 2.7.2. Use ASTFactory.dup() instead.", false)]
    override public object Clone()
    {
        return new CommonASTWithHiddenTokens(this);
    }
    #endregion

    public class CommonASTWithHiddenTokensCreator : ASTNodeCreator
    {
        public CommonASTWithHiddenTokensCreator() { }

        /// <summary>
        /// Returns the fully qualified name of the AST type that this
        /// class creates.
        /// </summary>
        public override string ASTNodeTypeName
        {
            get
            {
                return typeof(BinaryAssetBuilder.ExpressionEval.Antlr.CommonASTWithHiddenTokens).FullName; ;
            }
        }

        /// <summary>
        /// Constructs a <see cref="AST"/> instance.
        /// </summary>
        public override AST Create()
        {
            return new CommonASTWithHiddenTokens();
        }
    }
}
