#if KANESWRATH
using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct MetaBaseBodyModuleData
{
    public MetaBodyModuleData Base;
    public uint Tier1TiberiumProduction;
    public uint Tier2TiberiumProduction;
    public float Tier2TiberiumInfluence;
    public float Tier2PopulationInfluence;
    public float Tier2UnrestInfluence;
    public uint Tier3TiberiumProduction;
    public float Tier3TiberiumInfluence;
    public float Tier3PopulationInfluence;
    public float Tier3UnrestInfluence;
    public int StartingTier;
    public int StartWithStratBuilding;
    public float InfluenceRadiusTier2;
    public float InfluenceRadiusTier3;
    public TypedAssetId<UpgradeTemplate> BaseStrat1Upgrade;
    public TypedAssetId<UpgradeTemplate> BaseStrat2Upgrade;
    public TypedAssetId<UpgradeTemplate> BaseStrat3Upgrade;
    public TypedAssetId<UpgradeTemplate> BaseStrat4Upgrade;
    public TypedAssetId<UpgradeTemplate> BaseStrat5Upgrade;
    public List<TypedAssetId<GameObject>> Tier1Base;
    public List<TypedAssetId<GameObject>> Tier2Base;
    public List<TypedAssetId<GameObject>> Tier3Base;
    public List<TypedAssetId<GameObject>> UpgradeBasePower;
    public List<TypedAssetId<GameObject>> Tier1BaseDefense;
    public List<TypedAssetId<GameObject>> Tier2BaseDefense;
    public List<TypedAssetId<GameObject>> Tier3BaseDefense;
    public unsafe TypedAssetId<GameObject>* UpgradeBaseStrat1;
    public unsafe TypedAssetId<GameObject>* UpgradeBaseStrat2;
    public unsafe TypedAssetId<GameObject>* UpgradeBaseStrat3;
    public unsafe TypedAssetId<GameObject>* UpgradeBaseStrat4;
    public unsafe TypedAssetId<GameObject>* UpgradeBaseStrat5;
    public List<TypedAssetId<GameObject>> StartingBase;
    public SageBool StartWithDefenses;
    public SageBool StartWithPowerPlants;
    public SageBool StartDamaged;
    public SageBool SpecialTiberiumInfluence;
}
#endif
