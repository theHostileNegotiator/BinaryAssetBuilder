using System;
using System.IO;

namespace BinaryAssetBuilder.ExpressionEval.Antlr;
// SAS: added this class to handle Binary input w/ FileInputStream

public class ByteBuffer : InputBuffer
{

    // char source
    [NonSerialized()]
    internal Stream input;

    private const int BUF_SIZE = 16;
    /// <summary>
    /// Small buffer used to avoid reading individual chars
    /// </summary>
    private byte[] buf = new byte[BUF_SIZE];


    /*Create a character buffer */
    public ByteBuffer(Stream input_) : base()
    {
        input = input_;
    }

    /*Ensure that the character buffer is sufficiently full */
    override public void fill(int amount)
    {
        //			try
        //			{
        syncConsume();
        // Fill the buffer sufficiently to hold needed characters
        int bytesToRead = (amount + markerOffset) - queue.Count;
        int c;

        while (bytesToRead > 0)
        {
            // Read a few characters
            c = input.Read(buf, 0, BUF_SIZE);
            for (int i = 0; i < c; i++)
            {
                // Append the next character
                queue.Add(unchecked((char)buf[i]));
            }
            if (c < BUF_SIZE)
            {
                while ((bytesToRead-- > 0) && (queue.Count < BUF_SIZE))
                {
                    queue.Add(CharScanner.EOF_CHAR);
                }
                break;
            }
            bytesToRead -= c;
        }
    }
}
