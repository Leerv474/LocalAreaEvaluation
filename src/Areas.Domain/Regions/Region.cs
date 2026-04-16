namespace Areas.Domain.Regions;

using Areas.Domain.Regions.Enums;

public class Region(Guid id, String name, FederalDistrict federalDistrict, String[] plateCodes) {
    public Guid Id {get; } = id;
    public String Name {get; } = name;
    public FederalDistrict FederalDistrict {get; } = federalDistrict;
    public String[] PlateCodes {get; } = plateCodes;
}
