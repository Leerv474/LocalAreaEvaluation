using Areas.Domain.LocalAreas.Enums;

namespace Areas.Domain.LocalAreas;

public class LocalArea(
    Guid id,
    String name,
    AreaType areaType,
    Int32 population,
    DateOnly establishmentDate,
    Double averageHotelBill,
    Boolean isHeroCity,
    Guid regionId
)
{
    public Guid Id { get; } = id;
    public String Name { get; } = name;
    public AreaType AreaType { get; } = areaType;
    public Int32 Population { get; } = population;
    public DateOnly EstablishmentDate { get; } = establishmentDate;
    public Double AverageHotelBill { get; } = averageHotelBill;
    public Boolean IsHeroCity { get; } = isHeroCity;
    public Guid RegionId { get; } = regionId;
}
