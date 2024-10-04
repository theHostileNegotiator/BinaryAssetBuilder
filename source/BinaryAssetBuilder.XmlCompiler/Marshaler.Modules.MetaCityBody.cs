#if KANESWRATH
using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, MetaCityBodyModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(MetaCityBodyModuleData.SlightlyLowPopulationPercentage), "75%"), &objT->SlightlyLowPopulationPercentage, state);
        Marshal(node.GetAttributeValue(nameof(MetaCityBodyModuleData.LowPopulationPercentage), "50%"), &objT->LowPopulationPercentage, state);
        Marshal(node.GetAttributeValue(nameof(MetaCityBodyModuleData.ReallyLowPopulationPercentage), "25%"), &objT->ReallyLowPopulationPercentage, state);
        Marshal(node.GetAttributeValue(nameof(MetaCityBodyModuleData.MaxUnrest), "100.0"), &objT->MaxUnrest, state);
        Marshal(node.GetAttributeValue(nameof(MetaCityBodyModuleData.SlightlyLowUnrestPercentage), "75%"), &objT->SlightlyLowUnrestPercentage, state);
        Marshal(node.GetAttributeValue(nameof(MetaCityBodyModuleData.LowUnrestPercentage), "50%"), &objT->LowUnrestPercentage, state);
        Marshal(node.GetAttributeValue(nameof(MetaCityBodyModuleData.ReallyLowUnrestPercentage), "25%"), &objT->ReallyLowUnrestPercentage, state);
        Marshal(node.GetAttributeValue(nameof(MetaCityBodyModuleData.InitialUnrest), "-1.0"), &objT->InitialUnrest, state);
        Marshal(node.GetAttributeValue(nameof(MetaCityBodyModuleData.MinHumanCityTiberiumBonus), "0"), &objT->MinHumanCityTiberiumBonus, state);
        Marshal(node.GetAttributeValue(nameof(MetaCityBodyModuleData.MaxHumanCityTiberiumBonus), "1000"), &objT->MaxHumanCityTiberiumBonus, state);
        Marshal(node.GetAttributeValue(nameof(MetaCityBodyModuleData.ALIENCityTiberiumBonusPop), "0"), &objT->ALIENCityTiberiumBonusPop, state);
        Marshal(node.GetAttributeValue(nameof(MetaCityBodyModuleData.ALIENCityTiberiumBonusPopTHRESHOLD), "0%"), &objT->ALIENCityTiberiumBonusPopTHRESHOLD, state);
        Marshal(node, (MetaBodyModuleData*)objT, state);
    }
}
#endif
