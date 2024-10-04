#if KANESWRATH
using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, MetaBaseBodyModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(MetaBaseBodyModuleData.Tier1TiberiumProduction), "1000"), &objT->Tier1TiberiumProduction, state);
        Marshal(node.GetAttributeValue(nameof(MetaBaseBodyModuleData.Tier2TiberiumProduction), "2000"), &objT->Tier2TiberiumProduction, state);
        Marshal(node.GetAttributeValue(nameof(MetaBaseBodyModuleData.Tier2TiberiumInfluence), "0.0"), &objT->Tier2TiberiumInfluence, state);
        Marshal(node.GetAttributeValue(nameof(MetaBaseBodyModuleData.Tier2PopulationInfluence), "0.0"), &objT->Tier2PopulationInfluence, state);
        Marshal(node.GetAttributeValue(nameof(MetaBaseBodyModuleData.Tier2UnrestInfluence), "0.0"), &objT->Tier2UnrestInfluence, state);
        Marshal(node.GetAttributeValue(nameof(MetaBaseBodyModuleData.Tier3TiberiumProduction), "3000"), &objT->Tier3TiberiumProduction, state);
        Marshal(node.GetAttributeValue(nameof(MetaBaseBodyModuleData.Tier3TiberiumInfluence), "0.0"), &objT->Tier3TiberiumInfluence, state);
        Marshal(node.GetAttributeValue(nameof(MetaBaseBodyModuleData.Tier3PopulationInfluence), "0.0"), &objT->Tier3PopulationInfluence, state);
        Marshal(node.GetAttributeValue(nameof(MetaBaseBodyModuleData.Tier3UnrestInfluence), "0.0"), &objT->Tier3UnrestInfluence, state);
        Marshal(node.GetAttributeValue(nameof(MetaBaseBodyModuleData.StartingTier), "1"), &objT->StartingTier, state);
        Marshal(node.GetAttributeValue(nameof(MetaBaseBodyModuleData.StartWithDefenses), "false"), &objT->StartWithDefenses, state);
        Marshal(node.GetAttributeValue(nameof(MetaBaseBodyModuleData.StartWithPowerPlants), "false"), &objT->StartWithPowerPlants, state);
        Marshal(node.GetAttributeValue(nameof(MetaBaseBodyModuleData.StartWithStratBuilding), "0"), &objT->StartWithStratBuilding, state);
        Marshal(node.GetAttributeValue(nameof(MetaBaseBodyModuleData.StartDamaged), "false"), &objT->StartDamaged, state);
        Marshal(node.GetAttributeValue(nameof(MetaBaseBodyModuleData.InfluenceRadiusTier2), "0.0"), &objT->InfluenceRadiusTier2, state);
        Marshal(node.GetAttributeValue(nameof(MetaBaseBodyModuleData.InfluenceRadiusTier3), "0.0"), &objT->InfluenceRadiusTier3, state);
        Marshal(node.GetAttributeValue(nameof(MetaBaseBodyModuleData.SpecialTiberiumInfluence), "false"), &objT->SpecialTiberiumInfluence, state);
        Marshal(node.GetAttributeValue(nameof(MetaBaseBodyModuleData.BaseStrat1Upgrade), null), &objT->BaseStrat1Upgrade, state);
        Marshal(node.GetAttributeValue(nameof(MetaBaseBodyModuleData.BaseStrat2Upgrade), null), &objT->BaseStrat2Upgrade, state);
        Marshal(node.GetAttributeValue(nameof(MetaBaseBodyModuleData.BaseStrat3Upgrade), null), &objT->BaseStrat3Upgrade, state);
        Marshal(node.GetAttributeValue(nameof(MetaBaseBodyModuleData.BaseStrat4Upgrade), null), &objT->BaseStrat4Upgrade, state);
        Marshal(node.GetAttributeValue(nameof(MetaBaseBodyModuleData.BaseStrat5Upgrade), null), &objT->BaseStrat5Upgrade, state);
        Marshal(node.GetChildNodes(nameof(MetaBaseBodyModuleData.Tier1Base)), &objT->Tier1Base, state);
        Marshal(node.GetChildNodes(nameof(MetaBaseBodyModuleData.Tier2Base)), &objT->Tier2Base, state);
        Marshal(node.GetChildNodes(nameof(MetaBaseBodyModuleData.Tier3Base)), &objT->Tier3Base, state);
        Marshal(node.GetChildNodes(nameof(MetaBaseBodyModuleData.UpgradeBasePower)), &objT->UpgradeBasePower, state);
        Marshal(node.GetChildNodes(nameof(MetaBaseBodyModuleData.Tier1BaseDefense)), &objT->Tier1BaseDefense, state);
        Marshal(node.GetChildNodes(nameof(MetaBaseBodyModuleData.Tier2BaseDefense)), &objT->Tier2BaseDefense, state);
        Marshal(node.GetChildNodes(nameof(MetaBaseBodyModuleData.Tier3BaseDefense)), &objT->Tier3BaseDefense, state);
        Marshal(node.GetChildNode(nameof(MetaBaseBodyModuleData.UpgradeBaseStrat1), null), &objT->UpgradeBaseStrat1, state);
        Marshal(node.GetChildNode(nameof(MetaBaseBodyModuleData.UpgradeBaseStrat2), null), &objT->UpgradeBaseStrat2, state);
        Marshal(node.GetChildNode(nameof(MetaBaseBodyModuleData.UpgradeBaseStrat3), null), &objT->UpgradeBaseStrat3, state);
        Marshal(node.GetChildNode(nameof(MetaBaseBodyModuleData.UpgradeBaseStrat4), null), &objT->UpgradeBaseStrat4, state);
        Marshal(node.GetChildNode(nameof(MetaBaseBodyModuleData.UpgradeBaseStrat5), null), &objT->UpgradeBaseStrat5, state);
        Marshal(node.GetChildNodes(nameof(MetaBaseBodyModuleData.StartingBase)), &objT->StartingBase, state);
        Marshal(node, (MetaBodyModuleData*)objT, state);
    }
}
#endif
