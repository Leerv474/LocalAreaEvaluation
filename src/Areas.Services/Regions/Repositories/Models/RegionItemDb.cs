namespace Areas.Services.Regions.Repositories.Models;

public class RegionItemDb(
    Guid id,
    String name
)
{
    public Guid Id { get; set; } = id;
    public String Name { get; set; } = name;
}
