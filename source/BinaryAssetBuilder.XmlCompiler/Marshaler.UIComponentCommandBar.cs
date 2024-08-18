using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, UIComponentCommandBar* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
#if TIBERIUMWARS
        Marshal(node.GetAttributeValue(nameof(UIComponentCommandBar.StackLevels), "3"), &objT->StackLevels, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentCommandBar.CommandBarImageBaseName), "CbarImage"), &objT->CommandBarImageBaseName, state);
#elif KANESWRATH
        Marshal(node.GetAttributeValue(nameof(UIComponentCommandBar.HomeButtonImageName), "CbarHome"), &objT->HomeButtonImageName, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentCommandBar.ButtonSlotImageBaseName), "CbarSlot"), &objT->ButtonSlotImageBaseName, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentCommandBar.GeneralButtonImageBaseName), "CbarGeneral"), &objT->GeneralButtonImageBaseName, state);
#endif
        Marshal(node.GetAttributeValue(nameof(UIComponentCommandBar.RenderClockName), null), &objT->RenderClockName, state);
#if TIBERIUMWARS
        Marshal(node.GetAttributeValue(nameof(UIComponentCommandBar.TabNameBookmarks), null), &objT->TabNameBookmarks, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentCommandBar.TabNamePowers), null), &objT->TabNamePowers, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentCommandBar.TabNameGroundUnits), null), &objT->TabNameGroundUnits, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentCommandBar.TabNameVehicles), null), &objT->TabNameVehicles, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentCommandBar.TabNameAirUnits), null), &objT->TabNameAirUnits, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentCommandBar.TabNameStructures), null), &objT->TabNameStructures, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentCommandBar.TabNameBaseDefenses), null), &objT->TabNameBaseDefenses, state);
#endif
        Marshal(node.GetAttributeValue(nameof(UIComponentCommandBar.ClockScale), null), &objT->ClockScale, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentCommandBar.ClockImage), null), &objT->ClockImage, state);
#if TIBERIUMWARS
        Marshal(node.GetAttributeValue(nameof(UIComponentCommandBar.DrillUpButtonId), null), &objT->DrillUpButtonId, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentCommandBar.StanceDrillDownButtonId), null), &objT->StanceDrillDownButtonId, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentCommandBar.TogglePowerButtonId), null), &objT->TogglePowerButtonId, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentCommandBar.SelfRepairButtonId), null), &objT->SelfRepairButtonId, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentCommandBar.SellButtonId), null), &objT->SellButtonId, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentCommandBar.SetDefaultBuildingButtonId), null), &objT->SetDefaultBuildingButtonId, state);
#endif
        Marshal(node.GetAttributeValue(nameof(UIComponentCommandBar.UnitCapFlashSeconds), null), &objT->UnitCapFlashSeconds, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentCommandBar.UnitCapFinalWarningAmount), null), &objT->UnitCapFinalWarningAmount, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentCommandBar.UnitCapInitialWarningAmount), null), &objT->UnitCapInitialWarningAmount, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentCommandBar.UnitCapNoMoreCP), null), &objT->UnitCapNoMoreCP, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentCommandBar.UnitCapAlmostNoMoreCP), null), &objT->UnitCapAlmostNoMoreCP, state);
#if KANESWRATH
        Marshal(node.GetAttributeValue(nameof(UIComponentCommandBar.ScrollPowersSoundName), null), &objT->ScrollPowersSoundName, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentCommandBar.OpenUISoundName), null), &objT->OpenUISoundName, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentCommandBar.CloseUISoundName), null), &objT->CloseUISoundName, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentCommandBar.HighlightButtonSoundName), null), &objT->HighlightButtonSoundName, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentCommandBar.SelectButtonSoundName), null), &objT->SelectButtonSoundName, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentCommandBar.ZoomInSoundName), null), &objT->ZoomInSoundName, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentCommandBar.ZoomOutSoundName), null), &objT->ZoomOutSoundName, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentCommandBar.CycleSoundName), null), &objT->CycleSoundName, state);
#endif
        Marshal(node.GetChildNode(nameof(UIComponentCommandBar.ClockColor), null), &objT->ClockColor, state);
        Marshal(node, (UIBaseComponent*)objT, state);
    }
}