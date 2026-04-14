namespace Areas.Services;

using Areas.Domain.Services;
using Areas.Services.LocalAreas;
using Areas.Services.LocalAreas.Repositories;
using Areas.Services.LocalAreas.Repositories.Interfaces;
using Areas.Services.Regions;
using Areas.Services.Regions.Repositories;
using Areas.Services.Regions.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceConfigurator
{
    public static IServiceCollection AddServices(this IServiceCollection collection)
    {
        collection.AddSingleton<ILocalAreaService, LocalAreaService>();

        collection.AddSingleton<ILocalAreaRepository, LocalAreaRepository>();
        collection.AddSingleton<IRegionService, RegionService>();

        collection.AddSingleton<IRegionRepository, RegionRepository>();

        return collection;
    }
}
