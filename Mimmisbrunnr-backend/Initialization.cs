using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Mimmisbrunnr.Infrastructure.Context;
using Mimmisbrunnr.Infrastructure.Services;
using Mimmisbrunnr.Infrastructure.Services.Interfaces;

namespace Mimmisbrunnr.Api
{
    public static class Initialization
    {
        private static readonly string sqlLiteConnection = "Data Source=Mimmisbrunnr.db;Version=3;";

        public static void InitializeDbContext(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<ActivityStoreContext>(options => options.UseInMemoryDatabase("Mimisbrunnr"));
            builder.Services.AddDbContext<ImageStoreContext>(options => options.UseInMemoryDatabase("Mimisbrunnr"));

            
        }

        // TODO Register services
        public static void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IActivityService, ActivityService>();
        }
    }
}
