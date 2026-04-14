using Areas.Domain.LocalAreas.Enums;

namespace Areas.Domain.LocalAreas;

public class LocalAreaBlank
{
    public Guid? Id { get; set; }
    public String? Name { get; set; }
    public AreaType? Type { get; set; }
    public Int32? Population { get; set; }
    public DateOnly? EstablishmentDate { get; set; }
    public Double? AverageHotelBill { get; set; }
    public Boolean? IsHeroCity { get; set; }
    public Guid? RegionId { get; set; }
}
