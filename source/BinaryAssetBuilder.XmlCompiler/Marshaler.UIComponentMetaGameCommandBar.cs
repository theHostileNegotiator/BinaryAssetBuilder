#if KANESWRATH
using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, UIComponentMetaGameCommandBar* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(UIComponentMetaGameCommandBar.NumCommandSetsOnTabMain), "1"), &objT->NumCommandSetsOnTabMain, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentMetaGameCommandBar.NumCommandSetsOnTabSupport), "2"), &objT->NumCommandSetsOnTabSupport, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentMetaGameCommandBar.StackLevels), "3"), &objT->StackLevels, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentMetaGameCommandBar.CommandBarImageBaseName), "CbarImage"), &objT->CommandBarImageBaseName, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentMetaGameCommandBar.RenderClockName), null), &objT->RenderClockName, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentMetaGameCommandBar.TabNameBookmarks), null), &objT->TabNameBookmarks, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentMetaGameCommandBar.TabNamePowers), null), &objT->TabNamePowers, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentMetaGameCommandBar.TabNameGroundUnits), null), &objT->TabNameGroundUnits, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentMetaGameCommandBar.TabNameVehicles), null), &objT->TabNameVehicles, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentMetaGameCommandBar.TabNameAirUnits), null), &objT->TabNameAirUnits, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentMetaGameCommandBar.TabNameStructures), null), &objT->TabNameStructures, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentMetaGameCommandBar.TabNameBaseDefenses), null), &objT->TabNameBaseDefenses, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentMetaGameCommandBar.ClockScale), null), &objT->ClockScale, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentMetaGameCommandBar.ClockImage), null), &objT->ClockImage, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentMetaGameCommandBar.DrillUpButtonId), null), &objT->DrillUpButtonId, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentMetaGameCommandBar.StanceDrillDownButtonId), null), &objT->StanceDrillDownButtonId, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentMetaGameCommandBar.TogglePowerButtonId), null), &objT->TogglePowerButtonId, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentMetaGameCommandBar.SelfRepairButtonId), null), &objT->SelfRepairButtonId, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentMetaGameCommandBar.SellButtonId), null), &objT->SellButtonId, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentMetaGameCommandBar.SetDefaultBuildingButtonId), null), &objT->SetDefaultBuildingButtonId, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentMetaGameCommandBar.UnitCapFlashSeconds), null), &objT->UnitCapFlashSeconds, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentMetaGameCommandBar.UnitCapFinalWarningAmount), null), &objT->UnitCapFinalWarningAmount, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentMetaGameCommandBar.UnitCapInitialWarningAmount), null), &objT->UnitCapInitialWarningAmount, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentMetaGameCommandBar.UnitCapNoMoreCP), null), &objT->UnitCapNoMoreCP, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentMetaGameCommandBar.UnitCapAlmostNoMoreCP), null), &objT->UnitCapAlmostNoMoreCP, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentMetaGameCommandBar.ScrollPowersSoundName), null), &objT->ScrollPowersSoundName, state);
        Marshal(node.GetChildNode(nameof(UIComponentMetaGameCommandBar.ClockColor), null), &objT->ClockColor, state);
        Marshal(node, (UIBaseComponent*)objT, state);
    }
}
#endif