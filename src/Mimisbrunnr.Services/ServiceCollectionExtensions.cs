using Microsoft.Extensions.DependencyInjection;
using Mimisbrunnr.Persistence;
using Mimisbrunnr.Services.Praesidium;
using Mimisbrunnr.Shared.Praesidium;

namespace Mimisbrunnr.Services;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IPraesidiumService, PraesidiumService>();
        
        services.AddTransient<DbSeeder>();       
        
        return services;
    }
}