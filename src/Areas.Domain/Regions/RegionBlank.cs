using Areas.Domain.Regions.Enums;

namespace Areas.Domain.Regions;

public class RegionBlank
{
    public Guid? Id { get; set; }
    public String? Name { get; set; }
    public FederalDistrict? FederalDistrict { get; set; }
    public String[]? PlateCodes { get; set; }
}

