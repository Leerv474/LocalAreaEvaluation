namespace Areas.Domain.Regions;

public class Region(Guid id, String name, String federalDistrict, String[] plateCodes) {
    public Guid Id {get; } = id;
    public String Name {get; } = name;
    public String FederalDistrict {get; } = federalDistrict;
    public String[] PlateCodes {get; } = plateCodes;
}
