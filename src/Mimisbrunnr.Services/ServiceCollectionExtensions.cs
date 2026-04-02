using Microsoft.Extensions.DependencyInjection;
using Mimisbrunnr.Persistence;
using Mimisbrunnr.Services.Praesidium;
using Mimisbrunnr.Shared.Praesidium;
using Mimisbrunnr.Services.Events;
using Mimisbrunnr.Services.Socials;
using Mimisbrunnr.Services.Sponsors;
using Mimisbrunnr.Shared.Events;
using Mimisbrunnr.Shared.Socials;
using Mimisbrunnr.Shared.Sponsors;

namespace Mimisbrunnr.Services;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IPraesidiumService, PraesidiumService>();
        services.AddScoped<IEventService, EventService>();
        services.AddScoped<ISponsorService, SponsorService>();
        services.AddScoped<ISocialService, SocialService>();
        
        services.AddTransient<DbSeeder>();       
        
        return services;
    }
}