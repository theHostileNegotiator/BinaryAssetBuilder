using System.Collections;
using System.Collections.Generic;
using System.IO;
using BinaryAssetBuilder.ExpressionEval.Antlr;
using BinaryAssetBuilder.ExpressionEval.Antlr.Collections.Impl;

public class ExpressionLexer : CharScanner, TokenStream
{
    public const int EOF = 1;
    public const int NULL_TREE_LOOKAHEAD = 3;
    public const int EQ = 4;
    public const int OR = 5;
    public const int AND = 6;
    public const int NE = 7;
    public const int LS = 8;
    public const int GT = 9;
    public const int LE = 10;
    public const int GE = 11;
    public const int PLUS = 12;
    public const int MINUS = 13;
    public const int MUL = 14;
    public const int DIV = 15;
    public const int MOD = 16;
    public const int LPAREN = 17;
    public const int RPAREN = 18;
    public const int INT = 19;
    public const int FLOAT = 20;
    public const int STRING = 21;
    public const int STRING2 = 22;
    public const int DEFINE = 23;
    public const int ROUND = 24;
    public const int WS = 25;
    public const int DIGIT = 26;
    public const int LETTER = 27;
    public const int NUMBER = 28;

    public static readonly BitSet tokenSet_0_ = new BitSet(mk_tokenSet_0_());

    public static readonly BitSet tokenSet_1_ = new BitSet(mk_tokenSet_1_());

    public ExpressionLexer(Stream ins)
        : this(new ByteBuffer(ins))
    {
    }

    public ExpressionLexer(TextReader r)
        : this(new CharBuffer(r))
    {
    }

    public ExpressionLexer(InputBuffer ib)
        : this(new LexerSharedInputState(ib))
    {
    }

    public ExpressionLexer(LexerSharedInputState state)
        : base(state)
    {
        initialize();
    }

    private void initialize()
    {
        caseSensitiveLiterals = true;
        setCaseSensitive(true);
        literals = new Hashtable(100, 0.4f, null, Comparer.Default);
    }

    public override IToken nextToken()
    {
        while (true)
        {
            int num = 0;
            resetText();
            try
            {
                try
                {
                    switch (cached_LA1)
                    {
                        case '\t':
                        case '\n':
                        case '\r':
                        case ' ':
                            {
                                mWS(true);
                                IToken returnToken_2 = returnToken_;
                                break;
                            }
                        case '(':
                            {
                                mLPAREN(true);
                                IToken returnToken_3 = returnToken_;
                                break;
                            }
                        case ')':
                            {
                                mRPAREN(true);
                                IToken returnToken_4 = returnToken_;
                                break;
                            }
                        case 'o':
                            {
                                mOR(true);
                                IToken returnToken_5 = returnToken_;
                                break;
                            }
                        case 'a':
                            {
                                mAND(true);
                                IToken returnToken_6 = returnToken_;
                                break;
                            }
                        case '=':
                            {
                                mEQ(true);
                                IToken returnToken_7 = returnToken_;
                                break;
                            }
                        case '!':
                            {
                                mNE(true);
                                IToken returnToken_8 = returnToken_;
                                break;
                            }
                        case '+':
                            {
                                mPLUS(true);
                                IToken returnToken_9 = returnToken_;
                                break;
                            }
                        case '-':
                            {
                                mMINUS(true);
                                IToken returnToken_10 = returnToken_;
                                break;
                            }
                        case '*':
                            {
                                mMUL(true);
                                IToken returnToken_11 = returnToken_;
                                break;
                            }
                        case '/':
                            {
                                mDIV(true);
                                IToken returnToken_12 = returnToken_;
                                break;
                            }
                        case '%':
                            {
                                mMOD(true);
                                IToken returnToken_13 = returnToken_;
                                break;
                            }
                        case 'r':
                            {
                                mROUND(true);
                                IToken returnToken_14 = returnToken_;
                                break;
                            }
                        case '.':
                        case '0':
                        case '1':
                        case '2':
                        case '3':
                        case '4':
                        case '5':
                        case '6':
                        case '7':
                        case '8':
                        case '9':
                            {
                                mNUMBER(true);
                                IToken returnToken_15 = returnToken_;
                                break;
                            }
                        case '"':
                            {
                                mSTRING(true);
                                IToken returnToken_16 = returnToken_;
                                break;
                            }
                        case '\'':
                            {
                                mSTRING2(true);
                                IToken returnToken_17 = returnToken_;
                                break;
                            }
                        case '$':
                            {
                                mDEFINE(true);
                                IToken returnToken_18 = returnToken_;
                                break;
                            }
                        default:
                            if (cached_LA1 == '<')
                            {
                                mLE(true);
                                IToken returnToken_19 = returnToken_;
                                break;
                            }
                            if (cached_LA1 == '<')
                            {
                                mLS(true);
                                IToken returnToken_20 = returnToken_;
                                break;
                            }
                            if (cached_LA1 == '>')
                            {
                                mGE(true);
                                IToken returnToken_21 = returnToken_;
                                break;
                            }
                            if (cached_LA1 == '>')
                            {
                                mGT(true);
                                IToken returnToken_22 = returnToken_;
                                break;
                            }
                            if (cached_LA1 == CharScanner.EOF_CHAR)
                            {
                                uponEOF();
                                returnToken_ = makeToken(1);
                                break;
                            }
                            throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());
                    }
                    if (returnToken_ == null)
                    {
                        continue;
                    }
                    num = returnToken_.Type;
                    num = testLiteralsTable(num);
                    returnToken_.Type = num;
                    return returnToken_;
                }
                catch (RecognitionException re)
                {
                    throw new TokenStreamRecognitionException(re);
                }
            }
            catch (CharStreamException ex)
            {
                if (ex is CharStreamIOException)
                {
                    throw new TokenStreamIOException(((CharStreamIOException)ex).io);
                }
                throw new TokenStreamException(ex.Message);
            }
        }
    }

    public void mWS(bool _createToken)
    {
        IToken token = null;
        int length = text.Length;
        int num = 25;
        switch (cached_LA1)
        {
            case ' ':
                match(' ');
                break;
            case '\t':
                match('\t');
                break;
            case '\n':
                match('\n');
                break;
            case '\r':
                match('\r');
                break;
            default:
                throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());
        }
        if (inputState.guessing == 0)
        {
            num = Token.SKIP;
        }
        if (_createToken && token == null && num != Token.SKIP)
        {
            token = makeToken(num);
            token.setText(text.ToString(length, text.Length - length));
        }
        returnToken_ = token;
    }

    public void mLPAREN(bool _createToken)
    {
        IToken token = null;
        int length = text.Length;
        int num = 17;
        match('(');
        if (_createToken && token == null && num != Token.SKIP)
        {
            token = makeToken(num);
            token.setText(text.ToString(length, text.Length - length));
        }
        returnToken_ = token;
    }

    public void mRPAREN(bool _createToken)
    {
        IToken token = null;
        int length = text.Length;
        int num = 18;
        match(')');
        if (_createToken && token == null && num != Token.SKIP)
        {
            token = makeToken(num);
            token.setText(text.ToString(length, text.Length - length));
        }
        returnToken_ = token;
    }

    public void mOR(bool _createToken)
    {
        IToken token = null;
        int length = text.Length;
        int num = 5;
        match("or");
        if (_createToken && token == null && num != Token.SKIP)
        {
            token = makeToken(num);
            token.setText(text.ToString(length, text.Length - length));
        }
        returnToken_ = token;
    }

    public void mAND(bool _createToken)
    {
        IToken token = null;
        int length = text.Length;
        int num = 6;
        match("and");
        if (_createToken && token == null && num != Token.SKIP)
        {
            token = makeToken(num);
            token.setText(text.ToString(length, text.Length - length));
        }
        returnToken_ = token;
    }

    public void mEQ(bool _createToken)
    {
        IToken token = null;
        int length = text.Length;
        int num = 4;
        match('=');
        if (_createToken && token == null && num != Token.SKIP)
        {
            token = makeToken(num);
            token.setText(text.ToString(length, text.Length - length));
        }
        returnToken_ = token;
    }

    public void mNE(bool _createToken)
    {
        IToken token = null;
        int length = text.Length;
        int num = 7;
        match("!=");
        if (_createToken && token == null && num != Token.SKIP)
        {
            token = makeToken(num);
            token.setText(text.ToString(length, text.Length - length));
        }
        returnToken_ = token;
    }

    public void mLE(bool _createToken)
    {
        IToken token = null;
        int length = text.Length;
        int num = 10;
        match("<=");
        if (_createToken && token == null && num != Token.SKIP)
        {
            token = makeToken(num);
            token.setText(text.ToString(length, text.Length - length));
        }
        returnToken_ = token;
    }

    public void mLS(bool _createToken)
    {
        IToken token = null;
        int length = text.Length;
        int num = 8;
        match('<');
        if (_createToken && token == null && num != Token.SKIP)
        {
            token = makeToken(num);
            token.setText(text.ToString(length, text.Length - length));
        }
        returnToken_ = token;
    }

    public void mGE(bool _createToken)
    {
        IToken token = null;
        int length = text.Length;
        int num = 11;
        match(">=");
        if (_createToken && token == null && num != Token.SKIP)
        {
            token = makeToken(num);
            token.setText(text.ToString(length, text.Length - length));
        }
        returnToken_ = token;
    }

    public void mGT(bool _createToken)
    {
        IToken token = null;
        int length = text.Length;
        int num = 9;
        match('>');
        if (_createToken && token == null && num != Token.SKIP)
        {
            token = makeToken(num);
            token.setText(text.ToString(length, text.Length - length));
        }
        returnToken_ = token;
    }

    public void mPLUS(bool _createToken)
    {
        IToken token = null;
        int length = text.Length;
        int num = 12;
        match('+');
        if (_createToken && token == null && num != Token.SKIP)
        {
            token = makeToken(num);
            token.setText(text.ToString(length, text.Length - length));
        }
        returnToken_ = token;
    }

    public void mMINUS(bool _createToken)
    {
        IToken token = null;
        int length = text.Length;
        int num = 13;
        match('-');
        if (_createToken && token == null && num != Token.SKIP)
        {
            token = makeToken(num);
            token.setText(text.ToString(length, text.Length - length));
        }
        returnToken_ = token;
    }

    public void mMUL(bool _createToken)
    {
        IToken token = null;
        int length = text.Length;
        int num = 14;
        match('*');
        if (_createToken && token == null && num != Token.SKIP)
        {
            token = makeToken(num);
            token.setText(text.ToString(length, text.Length - length));
        }
        returnToken_ = token;
    }

    public void mDIV(bool _createToken)
    {
        IToken token = null;
        int length = text.Length;
        int num = 15;
        match('/');
        if (_createToken && token == null && num != Token.SKIP)
        {
            token = makeToken(num);
            token.setText(text.ToString(length, text.Length - length));
        }
        returnToken_ = token;
    }

    public void mMOD(bool _createToken)
    {
        IToken token = null;
        int length = text.Length;
        int num = 16;
        match('%');
        if (_createToken && token == null && num != Token.SKIP)
        {
            token = makeToken(num);
            token.setText(text.ToString(length, text.Length - length));
        }
        returnToken_ = token;
    }

    public void mROUND(bool _createToken)
    {
        IToken token = null;
        int length = text.Length;
        int num = 24;
        match("round");
        if (_createToken && token == null && num != Token.SKIP)
        {
            token = makeToken(num);
            token.setText(text.ToString(length, text.Length - length));
        }
        returnToken_ = token;
    }

    protected void mDIGIT(bool _createToken)
    {
        IToken token = null;
        int length = text.Length;
        int num = 26;
        matchRange('0', '9');
        if (_createToken && token == null && num != Token.SKIP)
        {
            token = makeToken(num);
            token.setText(text.ToString(length, text.Length - length));
        }
        returnToken_ = token;
    }

    protected void mLETTER(bool _createToken)
    {
        IToken token = null;
        int length = text.Length;
        int num = 27;
        switch (cached_LA1)
        {
            case 'a':
            case 'b':
            case 'c':
            case 'd':
            case 'e':
            case 'f':
            case 'g':
            case 'h':
            case 'i':
            case 'j':
            case 'k':
            case 'l':
            case 'm':
            case 'n':
            case 'o':
            case 'p':
            case 'q':
            case 'r':
            case 's':
            case 't':
            case 'u':
            case 'v':
            case 'w':
            case 'x':
            case 'y':
            case 'z':
                matchRange('a', 'z');
                break;
            case 'A':
            case 'B':
            case 'C':
            case 'D':
            case 'E':
            case 'F':
            case 'G':
            case 'H':
            case 'I':
            case 'J':
            case 'K':
            case 'L':
            case 'M':
            case 'N':
            case 'O':
            case 'P':
            case 'Q':
            case 'R':
            case 'S':
            case 'T':
            case 'U':
            case 'V':
            case 'W':
            case 'X':
            case 'Y':
            case 'Z':
                matchRange('A', 'Z');
                break;
            case '_':
                match('_');
                break;
            default:
                throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());
        }
        if (_createToken && token == null && num != Token.SKIP)
        {
            token = makeToken(num);
            token.setText(text.ToString(length, text.Length - length));
        }
        returnToken_ = token;
    }

    public void mNUMBER(bool _createToken)
    {
        IToken token = null;
        int length = text.Length;
        int num = 28;
        bool flag = false;
        if (cached_LA1 == '.')
        {
            int pos = mark();
            flag = true;
            inputState.guessing++;
            try
            {
                match('.');
                mDIGIT(false);
            }
            catch (RecognitionException)
            {
                flag = false;
            }
            rewind(pos);
            inputState.guessing--;
        }
        if (flag)
        {
            match('.');
            int num2 = 0;
            while (cached_LA1 >= '0' && cached_LA1 <= '9')
            {
                mDIGIT(false);
                num2++;
            }
            if (num2 < 1)
            {
                throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());
            }
            if (inputState.guessing == 0)
            {
                num = 20;
            }
        }
        else
        {
            bool flag2 = false;
            if (cached_LA1 >= '0' && cached_LA1 <= '9')
            {
                int pos2 = mark();
                flag2 = true;
                inputState.guessing++;
                try
                {
                    int num3 = 0;
                    while (cached_LA1 >= '0' && cached_LA1 <= '9')
                    {
                        mDIGIT(false);
                        num3++;
                    }
                    if (num3 < 1)
                    {
                        throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());
                    }
                    match('.');
                }
                catch (RecognitionException)
                {
                    flag2 = false;
                }
                rewind(pos2);
                inputState.guessing--;
            }
            if (flag2)
            {
                int num4 = 0;
                while (cached_LA1 >= '0' && cached_LA1 <= '9')
                {
                    mDIGIT(false);
                    num4++;
                }
                if (num4 < 1)
                {
                    throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());
                }
                match('.');
                while (cached_LA1 >= '0' && cached_LA1 <= '9')
                {
                    mDIGIT(false);
                }
                if (inputState.guessing == 0)
                {
                    num = 20;
                }
            }
            else
            {
                bool flag3 = false;
                if (cached_LA1 >= '0' && cached_LA1 <= '9')
                {
                    int pos3 = mark();
                    flag3 = true;
                    inputState.guessing++;
                    try
                    {
                        mDIGIT(false);
                    }
                    catch (RecognitionException)
                    {
                        flag3 = false;
                    }
                    rewind(pos3);
                    inputState.guessing--;
                }
                if (!flag3)
                {
                    throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());
                }
                int num5 = 0;
                while (cached_LA1 >= '0' && cached_LA1 <= '9')
                {
                    mDIGIT(false);
                    num5++;
                }
                if (num5 < 1)
                {
                    throw new NoViableAltForCharException(cached_LA1, getFilename(), getLine(), getColumn());
                }
                if (inputState.guessing == 0)
                {
                    num = 19;
                }
            }
        }
        if (_createToken && token == null && num != Token.SKIP)
        {
            token = makeToken(num);
            token.setText(text.ToString(length, text.Length - length));
        }
        returnToken_ = token;
    }

    public void mSTRING(bool _createToken)
    {
        IToken token = null;
        int length = text.Length;
        int num = 21;
        match('"');
        while (tokenSet_0_.member(cached_LA1))
        {
            match(tokenSet_0_);
        }
        match('"');
        if (_createToken && token == null && num != Token.SKIP)
        {
            token = makeToken(num);
            token.setText(text.ToString(length, text.Length - length));
        }
        returnToken_ = token;
    }

    public void mSTRING2(bool _createToken)
    {
        IToken token = null;
        int length = text.Length;
        int num = 22;
        match('\'');
        while (tokenSet_1_.member(cached_LA1))
        {
            match(tokenSet_1_);
        }
        match('\'');
        if (_createToken && token == null && num != Token.SKIP)
        {
            token = makeToken(num);
            token.setText(text.ToString(length, text.Length - length));
        }
        returnToken_ = token;
    }

    public void mDEFINE(bool _createToken)
    {
        IToken token = null;
        int length = text.Length;
        int num = 23;
        match('$');
        mLETTER(false);
        while (true)
        {
            switch (cached_LA1)
            {
                case 'A':
                case 'B':
                case 'C':
                case 'D':
                case 'E':
                case 'F':
                case 'G':
                case 'H':
                case 'I':
                case 'J':
                case 'K':
                case 'L':
                case 'M':
                case 'N':
                case 'O':
                case 'P':
                case 'Q':
                case 'R':
                case 'S':
                case 'T':
                case 'U':
                case 'V':
                case 'W':
                case 'X':
                case 'Y':
                case 'Z':
                case '_':
                case 'a':
                case 'b':
                case 'c':
                case 'd':
                case 'e':
                case 'f':
                case 'g':
                case 'h':
                case 'i':
                case 'j':
                case 'k':
                case 'l':
                case 'm':
                case 'n':
                case 'o':
                case 'p':
                case 'q':
                case 'r':
                case 's':
                case 't':
                case 'u':
                case 'v':
                case 'w':
                case 'x':
                case 'y':
                case 'z':
                    mLETTER(false);
                    continue;
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    mDIGIT(false);
                    continue;
            }
            if (_createToken && token == null && num != Token.SKIP)
            {
                token = makeToken(num);
                token.setText(text.ToString(length, text.Length - length));
            }
            returnToken_ = token;
            return;
        }
    }

    private static long[] mk_tokenSet_0_()
    {
        return new long[4] { -17179869185L, -1L, 0L, 0L };
    }

    private static long[] mk_tokenSet_1_()
    {
        return new long[4] { -549755813889L, -1L, 0L, 0L };
    }
}
