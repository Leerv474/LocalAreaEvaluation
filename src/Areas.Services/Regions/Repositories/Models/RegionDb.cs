using Areas.Domain.Regions.Enums;

namespace Areas.Services.Regions.Repositories.Models;

public class RegionDb(
    Guid id,
    String name,
    FederalDistrict federalDistrict,
    String[] plateCodes,
    Boolean isRemoved,
    DateTime? modifiedAt,
    DateTime createdAt
)
{
    public Guid Id { get; set; } = id;
    public String Name { get; set; } = name;
    public FederalDistrict FederalDistrict { get; set; } = federalDistrict;
    public String[] PlateCodes { get; set; } = plateCodes;
    public Boolean IsRemoved { get; set; } = isRemoved;
    public DateTime? ModifiedAt { get; set; } = modifiedAt;
    public DateTime CreatedAt { get; set; } = createdAt;
}
