﻿using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct UIComponentCommandBar
{
    public UIBaseComponent Base;
#if TIBERIUMWARS
    public int StackLevels;
    public AnsiString CommandBarImageBaseName;
#elif KANESWRATH
    public AnsiString HomeButtonImageName;
    public AnsiString ButtonSlotImageBaseName;
    public AnsiString GeneralButtonImageBaseName;
#endif
    public AnsiString RenderClockName;
#if TIBERIUMWARS
    public StringHash TabNameBookmarks;
    public StringHash TabNamePowers;
    public StringHash TabNameGroundUnits;
    public StringHash TabNameVehicles;
    public StringHash TabNameAirUnits;
    public StringHash TabNameStructures;
    public StringHash TabNameBaseDefenses;
#endif
    public float ClockScale;
    public TypedAssetId<PackedTextureImage> ClockImage;
#if TIBERIUMWARS
    public TypedAssetId<LogicCommand> DrillUpButtonId;
    public TypedAssetId<LogicCommand> StanceDrillDownButtonId;
    public TypedAssetId<LogicCommand> TogglePowerButtonId;
    public TypedAssetId<LogicCommand> SelfRepairButtonId;
    public TypedAssetId<LogicCommand> SellButtonId;
    public TypedAssetId<LogicCommand> SetDefaultBuildingButtonId;
#endif
    public int UnitCapFlashSeconds;
    public int UnitCapFinalWarningAmount;
    public int UnitCapInitialWarningAmount;
    public AnsiString UnitCapNoMoreCP;
    public AnsiString UnitCapAlmostNoMoreCP;
#if KANESWRATH
    public AnsiString ScrollPowersSoundName;
    public AnsiString OpenUISoundName;
    public AnsiString CloseUISoundName;
    public AnsiString HighlightButtonSoundName;
    public AnsiString SelectButtonSoundName;
    public AnsiString ZoomInSoundName;
    public AnsiString ZoomOutSoundName;
    public AnsiString CycleSoundName;
#endif
    public Color ClockColor;
}
