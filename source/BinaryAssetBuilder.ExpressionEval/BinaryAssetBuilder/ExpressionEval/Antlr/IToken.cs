namespace BinaryAssetBuilder.ExpressionEval.Antlr;

/// <summary>
/// A token is minimally a token type.  Subclasses can add the text matched
/// for the token and line info. 
/// </summary>
public interface IToken
{
    int getColumn();

    void setColumn(int c);

    int getLine();

    void setLine(int l);

    string getFilename();

    void setFilename(string name);

    string getText();

    void setText(string t);

    int Type { get; set; }
}
