using Goods.Domain.LocalAreas.Enums;
using Goods.Services.Regions.Repositories.Models;

namespace Goods.Services.LocalAreas.Repositories.Models;

public class LocalAreaDb(
    Guid id,
    String name,
    AreaType type,
    Int32 population,
    DateOnly establishmentDate,
    Double averageHotelBill,
    Boolean isHeroCity,
    Guid regionId,
    Boolean isRemoved,
    DateTime? modifiedAt,
    DateTime createdAt
)
{
    public Guid Id { get; set; } = id;
    public String Name { get; set; } = name;
    public AreaType Type { get; set; } = type;
    public Int32 Population { get; set; } = population;
    public DateOnly EstablishmentDate { get; set; } = establishmentDate;
    public Double AverageHotelBill { get; set; } = averageHotelBill;
    public Boolean IsHeroCity { get; set; } = isHeroCity;
    public Guid RegionId { get; set; } = regionId;
    public Boolean IsRemoved { get; set; } = isRemoved;
    public DateTime? ModifiedAt { get; set; } = modifiedAt;
    public DateTime CreatedAt { get; set; } = createdAt;
}
