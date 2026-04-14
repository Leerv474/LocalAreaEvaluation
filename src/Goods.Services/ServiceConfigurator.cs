namespace Goods.Services;

using Microsoft.Extensions.DependencyInjection;

public static class ServiceConfigurator
{
    public static IServiceCollection AddServices(this IServiceCollection collection)
    {
        // inject service and repo
        return collection;
    }
}
