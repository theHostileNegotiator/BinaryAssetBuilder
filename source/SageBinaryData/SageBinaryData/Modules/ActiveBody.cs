using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct DamageCreationList
{
    public AssetReference<ObjectCreationList> ObjectCreationList;
    public FXTriggerType TriggerFX;
    public BodySideDestroyedType DestroyedSide;
}

#if KANESWRATH
[StructLayout(LayoutKind.Sequential)]
public struct DamageTriggerType
{
    public float HealthLevelBelowPercent;
    public TypedAssetId<UpgradeTemplate> RemoveUpgrade;
    public ObjectStatusBitFlags RemoveStatus;
}
#endif

[StructLayout(LayoutKind.Sequential)]
public struct ActiveBodyModuleData
{
    public BodyModuleData Base;
    public float MaxHealth;
    public float MaxHealthDamaged;
    public float MaxHealthReallyDamaged;
    public float InitialHealth;
    public float RecoveryTime;
    public float DodgePercent;
    public Time EnteringDamagedTransitionTime;
    public Time EnteringReallyDamagedTransitionTime;
    public AnsiString GrabObject;
    public AssetReference<FXList> GrabFX;
    public float GrabDamage;
    public AssetReference<FXList> HealingBuffFX;
    public AssetReference<AttributeModifier> DamagedAttributeModifier;
    public AssetReference<AttributeModifier> ReallyDamagedAttributeModifier;
    public float CheerRadius;
    public AssetReference<FXList> BurningDeathFX;
#if KANESWRATH
    public TypedAssetId<UpgradeTemplate> SecondChanceUpgrade;
    public int SecondChanceHeal;
#endif
    public unsafe Coord2D* GrabOffset;
    public List<DamageCreationList> DamageCreation;
#if KANESWRATH
    public List<DamageTriggerType> DamageTrigger;
#endif
    public SageBool UseDefaultDamageSettings;
    public SageBool RemoveUpgradesOnDeath;
    public SageBool BurningDeathBehavior;
}
