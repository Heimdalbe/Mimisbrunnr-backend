using Microsoft.Extensions.DependencyInjection;
using Mimmisbrunnr.Persistence;
using Mimmisbrunnr.Services.Praesidium;
using Mimmisbrunnr.Shared.Praesidium;

namespace Mimmisbrunnr.Services;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IPraesidiumService, PraesidiumService>();
        
        services.AddTransient<DbSeeder>();       
        
        return services;
    }
}