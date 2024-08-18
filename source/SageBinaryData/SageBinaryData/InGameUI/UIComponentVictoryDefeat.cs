using AssetStream;
using System.Runtime.InteropServices;
using Relo;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct UIComponentVictoryDefeat
{
    public UIBaseComponent Base;
#if KANESWRATH
    public TypedAssetId<AssetId> PostEndGameMusic;
    public List<AnsiString> EndGameMusicAlias;
#endif
}
