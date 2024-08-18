using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, InGameUIGroupSelectionGroupCommandSlots* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(InGameUIGroupSelectionGroupCommandSlots.Create), null), &objT->Create, state);
        Marshal(node.GetAttributeValue(nameof(InGameUIGroupSelectionGroupCommandSlots.AddTo), null), &objT->AddTo, state);
        Marshal(node.GetAttributeValue(nameof(InGameUIGroupSelectionGroupCommandSlots.Select), null), &objT->Select, state);
        Marshal(node.GetAttributeValue(nameof(InGameUIGroupSelectionGroupCommandSlots.View), null), &objT->View, state);
    }

    public static unsafe void Marshal(Node node, InGameUIViewBookmarkCommandSlots* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(InGameUIViewBookmarkCommandSlots.GoTo), null), &objT->GoTo, state);
        Marshal(node.GetAttributeValue(nameof(InGameUIViewBookmarkCommandSlots.Save), null), &objT->Save, state);
    }

    public static unsafe void Marshal(Node node, InGameUIGroupSelectionCommandSlots* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(InGameUIGroupSelectionCommandSlots.Group)), &objT->Group, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }

    public static unsafe void Marshal(Node node, InGameUILookAtCommandSlots* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(InGameUILookAtCommandSlots.ViewBookmark)), &objT->ViewBookmark, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }

    public static unsafe void Marshal(Node node, InGameUITacticalCommandSlots* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(InGameUITacticalCommandSlots.AllCheer), null), &objT->AllCheer, state);
        Marshal(node.GetAttributeValue(nameof(InGameUITacticalCommandSlots.AttackMove), null), &objT->AttackMove, state);
        Marshal(node.GetAttributeValue(nameof(InGameUITacticalCommandSlots.CameraReset), null), &objT->CameraReset, state);
        Marshal(node.GetAttributeValue(nameof(InGameUITacticalCommandSlots.CameraRotateLeft), null), &objT->CameraRotateLeft, state);
        Marshal(node.GetAttributeValue(nameof(InGameUITacticalCommandSlots.CameraRotateRight), null), &objT->CameraRotateRight, state);
        Marshal(node.GetAttributeValue(nameof(InGameUITacticalCommandSlots.CameraScrollDown), null), &objT->CameraScrollDown, state);
        Marshal(node.GetAttributeValue(nameof(InGameUITacticalCommandSlots.CameraScrollLeft), null), &objT->CameraScrollLeft, state);
        Marshal(node.GetAttributeValue(nameof(InGameUITacticalCommandSlots.CameraScrollRight), null), &objT->CameraScrollRight, state);
        Marshal(node.GetAttributeValue(nameof(InGameUITacticalCommandSlots.CameraScrollUp), null), &objT->CameraScrollUp, state);
        Marshal(node.GetAttributeValue(nameof(InGameUITacticalCommandSlots.CameraZoomIn), null), &objT->CameraZoomIn, state);
        Marshal(node.GetAttributeValue(nameof(InGameUITacticalCommandSlots.CameraZoomOut), null), &objT->CameraZoomOut, state);
        Marshal(node.GetAttributeValue(nameof(InGameUITacticalCommandSlots.ChatWithAllies), null), &objT->ChatWithAllies, state);
        Marshal(node.GetAttributeValue(nameof(InGameUITacticalCommandSlots.ChatWithBuddies), null), &objT->ChatWithBuddies, state);
        Marshal(node.GetAttributeValue(nameof(InGameUITacticalCommandSlots.ChatWithEveryone), null), &objT->ChatWithEveryone, state);
        Marshal(node.GetAttributeValue(nameof(InGameUITacticalCommandSlots.CreateFormation), null), &objT->CreateFormation, state);
        Marshal(node.GetAttributeValue(nameof(InGameUITacticalCommandSlots.CycleHarvesters), null), &objT->CycleHarvesters, state);
        Marshal(node.GetAttributeValue(nameof(InGameUITacticalCommandSlots.ForceAttack), null), &objT->ForceAttack, state);
        Marshal(node.GetAttributeValue(nameof(InGameUITacticalCommandSlots.ForceAttackMove), null), &objT->ForceAttackMove, state);
        Marshal(node.GetAttributeValue(nameof(InGameUITacticalCommandSlots.ForceMove), null), &objT->ForceMove, state);
        Marshal(node.GetAttributeValue(nameof(InGameUITacticalCommandSlots.GoToNextBuildQueue), null), &objT->GoToNextBuildQueue, state);
        Marshal(node.GetAttributeValue(nameof(InGameUITacticalCommandSlots.GoToPriorBuildQueue), null), &objT->GoToPriorBuildQueue, state);
        Marshal(node.GetAttributeValue(nameof(InGameUITacticalCommandSlots.OpenMessenger), null), &objT->OpenMessenger, state);
        Marshal(node.GetAttributeValue(nameof(InGameUITacticalCommandSlots.OpenPauseScreen), null), &objT->OpenPauseScreen, state);
        Marshal(node.GetAttributeValue(nameof(InGameUITacticalCommandSlots.OpenStatusScreen), null), &objT->OpenStatusScreen, state);
        Marshal(node.GetAttributeValue(nameof(InGameUITacticalCommandSlots.PlaceBeacon), null), &objT->PlaceBeacon, state);
        Marshal(node.GetAttributeValue(nameof(InGameUITacticalCommandSlots.PlaceRallyPoint), null), &objT->PlaceRallyPoint, state);
        Marshal(node.GetAttributeValue(nameof(InGameUITacticalCommandSlots.PlanningMode), null), &objT->PlanningMode, state);
        Marshal(node.GetAttributeValue(nameof(InGameUITacticalCommandSlots.PreferSelection), null), &objT->PreferSelection, state);
        Marshal(node.GetAttributeValue(nameof(InGameUITacticalCommandSlots.ReverseMove), null), &objT->ReverseMove, state);
        Marshal(node.GetAttributeValue(nameof(InGameUITacticalCommandSlots.Scatter), null), &objT->Scatter, state);
        Marshal(node.GetAttributeValue(nameof(InGameUITacticalCommandSlots.SelectAll), null), &objT->SelectAll, state);
        Marshal(node.GetAttributeValue(nameof(InGameUITacticalCommandSlots.SelectMatchingUnits), null), &objT->SelectMatchingUnits, state);
        Marshal(node.GetAttributeValue(nameof(InGameUITacticalCommandSlots.Sell), null), &objT->Sell, state);
        Marshal(node.GetAttributeValue(nameof(InGameUITacticalCommandSlots.SellMode), null), &objT->SellMode, state);
        Marshal(node.GetAttributeValue(nameof(InGameUITacticalCommandSlots.ShowAllHealthBars), null), &objT->ShowAllHealthBars, state);
        Marshal(node.GetAttributeValue(nameof(InGameUITacticalCommandSlots.StanceAggressive), null), &objT->StanceAggressive, state);
        Marshal(node.GetAttributeValue(nameof(InGameUITacticalCommandSlots.StanceGuard), null), &objT->StanceGuard, state);
        Marshal(node.GetAttributeValue(nameof(InGameUITacticalCommandSlots.StanceHoldFire), null), &objT->StanceHoldFire, state);
        Marshal(node.GetAttributeValue(nameof(InGameUITacticalCommandSlots.StanceHoldPosition), null), &objT->StanceHoldPosition, state);
        Marshal(node.GetAttributeValue(nameof(InGameUITacticalCommandSlots.Stop), null), &objT->Stop, state);
        Marshal(node.GetAttributeValue(nameof(InGameUITacticalCommandSlots.TelestratorErase), null), &objT->TelestratorErase, state);
        Marshal(node.GetAttributeValue(nameof(InGameUITacticalCommandSlots.TelestratorNextColor), null), &objT->TelestratorNextColor, state);
        Marshal(node.GetAttributeValue(nameof(InGameUITacticalCommandSlots.TelestratorNextLineWidth), null), &objT->TelestratorNextLineWidth, state);
        Marshal(node.GetAttributeValue(nameof(InGameUITacticalCommandSlots.TelestratorPriorColor), null), &objT->TelestratorPriorColor, state);
        Marshal(node.GetAttributeValue(nameof(InGameUITacticalCommandSlots.TelestratorToggle), null), &objT->TelestratorToggle, state);
        Marshal(node.GetAttributeValue(nameof(InGameUITacticalCommandSlots.ToggleFastForwardMode), null), &objT->ToggleFastForwardMode, state);
        Marshal(node.GetAttributeValue(nameof(InGameUITacticalCommandSlots.ToggleHUD), null), &objT->ToggleHUD, state);
        Marshal(node.GetAttributeValue(nameof(InGameUITacticalCommandSlots.TogglePowerMode), null), &objT->TogglePowerMode, state);
        Marshal(node.GetAttributeValue(nameof(InGameUITacticalCommandSlots.ToggleRepairMode), null), &objT->ToggleRepairMode, state);
        Marshal(node.GetAttributeValue(nameof(InGameUITacticalCommandSlots.ViewHomeBase), null), &objT->ViewHomeBase, state);
        Marshal(node.GetAttributeValue(nameof(InGameUITacticalCommandSlots.ViewLastEvaEvent), null), &objT->ViewLastEvaEvent, state);
        Marshal(node.GetAttributeValue(nameof(InGameUITacticalCommandSlots.WaypointMode), null), &objT->WaypointMode, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }

    public static unsafe void Marshal(Node node, InGameUISideBarBuildQueuePageSlot* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(InGameUISideBarBuildQueuePageSlot.QueueType), null), &objT->QueueType, state);
        Marshal(node.GetAttributeValue(nameof(InGameUISideBarBuildQueuePageSlot.Slot), null), &objT->Slot, state);
    }

    public static unsafe void Marshal(Node node, InGameUISideBarCommandSlots* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(InGameUISideBarCommandSlots.SelectionRefinementPage), null), &objT->SelectionRefinementPage, state);
        Marshal(node.GetChildNodes(nameof(InGameUISideBarCommandSlots.BuildQueuePage)), &objT->BuildQueuePage, state);
        Marshal(node.GetChildNodes(nameof(InGameUISideBarCommandSlots.ButtonSlot)), &objT->ButtonSlot, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }

    public static unsafe void Marshal(Node node, InGameUIPlayerPowerCommandSlots* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(InGameUIPlayerPowerCommandSlots.Slot)), &objT->Slot, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }

    public static unsafe void Marshal(Node node, InGameUIUnitAbilityCommandSlots* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(InGameUIUnitAbilityCommandSlots.Slot)), &objT->Slot, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }

#if KANESWRATH
    public static unsafe void Marshal(Node node, MetaGameUITacticalCommandSlots* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(MetaGameUITacticalCommandSlots.MGOpenObjectivesDialog), null), &objT->MGOpenObjectivesDialog, state);
        Marshal(node.GetAttributeValue(nameof(MetaGameUITacticalCommandSlots.MGOpenIntelligenceDialog), null), &objT->MGOpenIntelligenceDialog, state);
        Marshal(node.GetAttributeValue(nameof(MetaGameUITacticalCommandSlots.MGEndTurn), null), &objT->MGEndTurn, state);
        Marshal(node.GetAttributeValue(nameof(MetaGameUITacticalCommandSlots.MGResupply), null), &objT->MGResupply, state);
        Marshal(node.GetAttributeValue(nameof(MetaGameUITacticalCommandSlots.MGClearOrders), null), &objT->MGClearOrders, state);
        Marshal(node.GetAttributeValue(nameof(MetaGameUITacticalCommandSlots.MGSell), null), &objT->MGSell, state);
        Marshal(node.GetAttributeValue(nameof(MetaGameUITacticalCommandSlots.MGNextBase), null), &objT->MGNextBase, state);
        Marshal(node.GetAttributeValue(nameof(MetaGameUITacticalCommandSlots.MGPrevBase), null), &objT->MGPrevBase, state);
        Marshal(node.GetAttributeValue(nameof(MetaGameUITacticalCommandSlots.MGNextStrikeForce), null), &objT->MGNextStrikeForce, state);
        Marshal(node.GetAttributeValue(nameof(MetaGameUITacticalCommandSlots.MGPrevStrikeForce), null), &objT->MGPrevStrikeForce, state);
        Marshal(node.GetAttributeValue(nameof(MetaGameUITacticalCommandSlots.MGNextBattle), null), &objT->MGNextBattle, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }

    public static unsafe void Marshal(Node node, MetaGameUICommonOpCommandSlots* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(MetaGameUICommonOpCommandSlots.Slot)), &objT->Slot, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }
#endif

}
