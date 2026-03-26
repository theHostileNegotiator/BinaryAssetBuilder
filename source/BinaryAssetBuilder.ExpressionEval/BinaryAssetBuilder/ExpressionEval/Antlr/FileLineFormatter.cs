namespace BinaryAssetBuilder.ExpressionEval.Antlr;

public abstract class FileLineFormatter
{

    private static FileLineFormatter formatter = new DefaultFileLineFormatter();

    public static FileLineFormatter getFormatter()
    {
        return formatter;
    }

    public static void setFormatter(FileLineFormatter f)
    {
        formatter = f;
    }

    /*@param fileName the file that should appear in the prefix. (or null)
    * @param line the line (or -1)
    * @param column the column (or -1)
    */
    public abstract string getFormatString(string fileName, int line, int column);
}
