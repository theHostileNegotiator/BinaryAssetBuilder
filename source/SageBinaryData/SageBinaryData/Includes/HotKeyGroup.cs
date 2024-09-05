#if KANESWRATH
using Relo;
using AnsiString = Relo.String<sbyte>;
using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct HotKeyGroupingDef
{
    public AnsiString Name;
}

[StructLayout(LayoutKind.Sequential)]
public struct HotKeyGrouping
{
    public AnsiString Name;
    public List<HotKeyGroupingDef> IgnoreConflict;
    public List<HotKeyGroupingDef> Group;
    public List<HotKeyGroupingDef> Slot;
}

[StructLayout(LayoutKind.Sequential)]
public struct HotKeyGroupingList
{
    public List<HotKeyGrouping> HotKeyGroup;
}
#endif