using System;
using System.Text;

namespace BinaryAssetBuilder.ExpressionEval.Antlr;

[Serializable]
public class NoViableAltForCharException : RecognitionException
{
    public char foundChar;

    public NoViableAltForCharException(char c, CharScanner scanner) :
                base("NoViableAlt", scanner.getFilename(), scanner.getLine(), scanner.getColumn())
    {
        foundChar = c;
    }

    public NoViableAltForCharException(char c, string fileName, int line, int column) :
                base("NoViableAlt", fileName, line, column)
    {
        foundChar = c;
    }

    /*
    * Returns a clean error message (no line number/column information)
    */
    override public string Message
    {
        get
        {
            StringBuilder mesg = new StringBuilder("unexpected char: ");

            // I'm trying to mirror a change in the C++ stuff.
            // But java seems to lack something isprint-ish..
            // so we do it manually. This is probably too restrictive.

            if ((foundChar >= ' ') && (foundChar <= '~'))
            {
                mesg.Append('\'');
                mesg.Append(foundChar);
                mesg.Append('\'');
            }
            else
            {
                mesg.Append("0x");
                mesg.Append(((int)foundChar).ToString("X"));
            }
            return mesg.ToString();
        }
    }
}
