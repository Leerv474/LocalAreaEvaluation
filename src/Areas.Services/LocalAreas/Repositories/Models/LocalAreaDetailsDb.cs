using Areas.Domain.LocalAreas.Enums;

namespace Areas.Domain.LocalAreas;

public class LocalAreaDetailsDb(
    Guid id,
    String name,
    AreaType areaType,
    Int32 population,
    DateOnly establishmentDate,
    Double averageHotelBill,
    Boolean isHeroCity,
    String regionName,
    Boolean isRemoved,
    DateTime? modifiedAt,
    DateTime createdAt
)
{
    public Guid Id { get; set; } = id;
    public String Name { get; set; } = name;
    public AreaType AreaType { get; set; } = areaType;
    public Int32 Population { get; set; } = population;
    public DateOnly EstablishmentDate { get; set; } = establishmentDate;
    public Double AverageHotelBill { get; set; } = averageHotelBill;
    public Boolean IsHeroCity { get; set; } = isHeroCity;
    public String RegionName { get; set; } = regionName;
    public Boolean IsRemoved { get; set; } = isRemoved;
    public DateTime? ModifiedAt { get; set; } = modifiedAt;
    public DateTime CreatedAt { get; set; } = createdAt;
}

