namespace Areas.Domain.Regions;

public class RegionItem(Guid id, String name)
{
    public Guid Id { get; } = id;
    public String Name { get; } = name;
}
