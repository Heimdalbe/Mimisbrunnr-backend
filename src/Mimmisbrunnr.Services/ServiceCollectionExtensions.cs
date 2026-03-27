using Microsoft.Extensions.DependencyInjection;
using Mimmisbrunnr.Persistence;

namespace Mimmisbrunnr.Services;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<DbSeeder>();       
        
        // Add other application services here.
        return services;
    }
}