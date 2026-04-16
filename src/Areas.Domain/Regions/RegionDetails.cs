using Areas.Domain.Regions.Enums;

namespace Areas.Domain.Regions;


public class RegionDetails(
    Guid id,
    String name,
    FederalDistrict federalDistrict,
    String[] plateCodes,
    Int32 localityCount
)
{
    public Guid Id { get; } = id;
    public String Name { get; } = name;
    public FederalDistrict FederalDistrict { get; } = federalDistrict;
    public String[] PlateCodes { get; } = plateCodes;
    public Int32 LocalityCount { get; } = localityCount;
}
