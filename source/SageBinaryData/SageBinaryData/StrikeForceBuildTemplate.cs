#if KANESWRATH
using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct StrikeForceElementTemplateType
{
    public TypedAssetId<GameObject> Object;
    public int Cost;
    public int Tier;
    public int Maximum;
    public int PopCount;
    public AnsiString DisplayName;
    public AnsiString Description;
    public AnsiString TypeDescription;
    public AnsiString ButtonImage;
}

[StructLayout(LayoutKind.Sequential)]
public struct StrikeForceElementTemplateListType
{
    public List<StrikeForceElementTemplateType> StrikeForceElementTemplate;
}

[StructLayout(LayoutKind.Sequential)]
public struct StrikeForceBuildTemplate
{
    public BaseInheritableAsset Base;
    public AnsiString Side;
    public int UltraLightCost;
    public int LightCost;
    public int MediumCost;
    public int HeavyCost;
    public int UltraHeavyCost;
    public TypedAssetId<GameObject> UltraLightMapRep;
    public TypedAssetId<GameObject> LightMapRep;
    public TypedAssetId<GameObject> MediumMapRep;
    public TypedAssetId<GameObject> HeavyMapRep;
    public TypedAssetId<GameObject> UltraHeavyMapRep;
    public int MaxPop;
    public unsafe StrikeForceElementTemplateListType* Support;
    public unsafe StrikeForceElementTemplateListType* Infantry;
    public unsafe StrikeForceElementTemplateListType* Vehicles;
    public unsafe StrikeForceElementTemplateListType* Aircraft;
}
#endif
