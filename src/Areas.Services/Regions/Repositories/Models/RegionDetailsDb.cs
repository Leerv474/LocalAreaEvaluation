namespace Areas.Domain.Regions;

using Areas.Domain.Regions.Enums;

public class RegionDetailsDb
{
    public Guid Id { get; set; }
    public String Name { get; set; }
    public FederalDistrict FederalDistrict { get; set; }
    public String[] PlateCodes { get; set; }
    public Int32 LocalityCount { get; set; }

    public RegionDetailsDb(
        Guid id,
        String name,
        FederalDistrict federalDistrict,
        String[] plateCodes,
        Int32 localityCount
    )
    {
        Id = id;
        Name = name;
        FederalDistrict = federalDistrict;
        PlateCodes = plateCodes;
        LocalityCount = localityCount;
    }
}
