using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Options;
using Services.TapService;

namespace Services;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<TapOptions>(configuration.GetSection(TapOptions.SectionName));

        services.AddScoped<ITapService, TapService.TapService>();

        return services;
    }
}
