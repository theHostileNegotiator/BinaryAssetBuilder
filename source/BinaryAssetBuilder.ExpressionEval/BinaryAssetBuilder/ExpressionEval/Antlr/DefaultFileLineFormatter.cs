using System.Text;

namespace BinaryAssetBuilder.ExpressionEval.Antlr;

public class DefaultFileLineFormatter : FileLineFormatter
{
    public override string getFormatString(string fileName, int line, int column)
    {
        StringBuilder buf = new StringBuilder();

        if (fileName != null)
            buf.Append(fileName + ":");

        if (line != -1)
        {
            if (fileName == null)
                buf.Append("line ");

            buf.Append(line);

            if (column != -1)
                buf.Append(":" + column);

            buf.Append(":");
        }

        buf.Append(" ");

        return buf.ToString();
    }
}
