using Areas.Domain.LocalAreas.Enums;

namespace Areas.Domain.LocalAreas;

public class LocalAreaDetails(
    Guid id,
    String name,
    AreaType areaType,
    Int32 population,
    DateOnly establishmentDate,
    Double averageHotelBill,
    Boolean isHeroCity,
    String regionName
)
{
    public Guid Id { get; } = id;
    public String Name { get; } = name;
    public AreaType AreaType { get; } = areaType;
    public Int32 Population { get; } = population;
    public DateOnly EstablishmentDate { get; } = establishmentDate;
    public Double AverageHotelBill { get; } = averageHotelBill;
    public Boolean IsHeroCity { get; } = isHeroCity;
    public String RegionName{ get; } = regionName;
}
