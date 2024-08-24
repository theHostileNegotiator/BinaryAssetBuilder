using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct SkirmishStartCash
{
    public int LoCash;
    public int HiCash;
    public int ChoiceStepAmount;
    public int DefaultChoiceIndex;
}

#if KANESWRATH
[StructLayout(LayoutKind.Sequential)]
public struct valueAndDifficulty
{
    public int value;
    public AnsiString difficulty;
}

[StructLayout(LayoutKind.Sequential)]
public struct listDefaultValueDifficulty
{
    public int DefaultChoiceIndex;
    public List<valueAndDifficulty> entry;
}
#endif

[StructLayout(LayoutKind.Sequential)]
public struct MpGameRules
{
    public BaseAssetType Base;
    public SkirmishStartCash SkirmishStartCash;
#if KANESWRATH
    public listDefaultValueDifficulty MetaGameTiberiumSupply;
    public listDefaultValueDifficulty MetaGameTiberiumInfestation;
    public listDefaultValueDifficulty MetaGameOPsPoints;
    public listDefaultValueDifficulty MetaGameCoreObjectives;
#endif
}
