#if KANESWRATH
using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct MetaGameMapZoneEntry
{
    public AnsiString MapName;
}

[StructLayout(LayoutKind.Sequential)]
public struct MetaGameMapZoneGreen
{
    public List<MetaGameMapZoneEntry> MapEntry;
}

[StructLayout(LayoutKind.Sequential)]
public struct MetaGameMapZoneYellow
{
    public List<MetaGameMapZoneEntry> MapEntry;
}

[StructLayout(LayoutKind.Sequential)]
public struct MetaGameMapZoneRed
{
    public List<MetaGameMapZoneEntry> MapEntry;
}

[StructLayout(LayoutKind.Sequential)]
public struct MetaGameMapZonePlayerSet
{
    public MetaGameMapZoneGreen GreenGroup;
    public MetaGameMapZoneYellow YellowGroup;
    public MetaGameMapZoneRed RedGroup;
}

[StructLayout(LayoutKind.Sequential)]
public struct MetaGameMapZoneData
{
    public BaseAssetType Base;
    public AnsiString Name;
    public MetaGameMapZonePlayerSet Group2Player;
    public MetaGameMapZonePlayerSet Group3Player;
    public MetaGameMapZonePlayerSet Group4Player;
}
#endif
