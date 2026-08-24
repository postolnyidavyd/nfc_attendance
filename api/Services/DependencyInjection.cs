using Microsoft.Extensions.DependencyInjection;
using Services.TapService;

namespace Services;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ITapService, TapService.TapService>();

        return services;
    }
}
