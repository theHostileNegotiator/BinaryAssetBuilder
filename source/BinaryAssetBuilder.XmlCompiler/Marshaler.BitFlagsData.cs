﻿using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    // Hold BitFlags<uint, Type> Marshalers here as C# has no support of values as generic arguments. Hopefully they come in the future, so this is just copy/paste.

    public static unsafe void Marshal(string text, LogicCommandOptionsBitFlags* objT, Tracker state)
    {
        string[] tokens = text.Split(WhiteSpaces, System.StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length == 0)
        {
            return;
        }
        for (int idy = 0; idy < tokens.Length; ++idy)
        {
            string token = tokens[idy];
            bool includeToken = true;
            if (token[0] == '+')
            {
                includeToken = true;
            }
            else if (token[0] == '-')
            {
                includeToken = false;
            }
            if (string.Equals(token, "ALL", System.StringComparison.Ordinal))
            {
                for (int idx = 0; idx < LogicCommandOptionsBitFlags.NumSpans; ++idx)
                {
                    objT->Value[idx] = uint.MaxValue;
                }
                continue;
            }
            LogicCommandOptions value = (LogicCommandOptions)(-1);
            Marshal(token, &value, state);
            if (value != (LogicCommandOptions)(-1))
            {
                uint uintValue = (uint)value;
                if (uintValue < LogicCommandOptionsBitFlags.Count)
                {
                    if (includeToken)
                    {
                        objT->Value[uintValue / LogicCommandOptionsBitFlags.BitsInSpan] |= (uint)(1 << (int)(uintValue % LogicCommandOptionsBitFlags.BitsInSpan));
                    }
                    else
                    {
                        objT->Value[uintValue / LogicCommandOptionsBitFlags.BitsInSpan] ^= (uint)(1 << (int)(uintValue % LogicCommandOptionsBitFlags.BitsInSpan));
                    }
                }
            }
        }
        if (state.IsBigEndian)
        {
            for (int idx = 0; idx < LogicCommandOptionsBitFlags.NumSpans; ++idx)
            {
                state.InplaceEndianToPlatform(&objT->Value[idx]);
            }
        }
    }

    public static unsafe void Marshal(Value value, LogicCommandOptionsBitFlags* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }
}
