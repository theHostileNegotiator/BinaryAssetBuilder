using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct MultiplayerColor
{
    public BaseAssetType Base;
#if KANESWRATH
    public AnsiString MetaGameSide;
#endif
    public Color RGBColor;
    public Color RGBColorT;
    public Color RGBNightColor;
    public Color LivingWorldColor;
    public Color LivingWorldBannerColor;
    public AnsiString TooltipName;
    public SageBool AvailableInMetaGame;
}
