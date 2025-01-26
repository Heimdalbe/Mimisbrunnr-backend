using Microsoft.EntityFrameworkCore;
using Mimmisbrunnr.Infrastructure.Context;
using Mimmisbrunnr.Infrastructure.Services;
using Mimmisbrunnr.Infrastructure.Services.Interfaces;

namespace Mimmisbrunnr.Api
{
    public static class Initialization
    {
        private static readonly string sqlLiteConnection = "Data Source = Mimmisbrunnr.db";

        public static void InitializeDbContext(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<ActivityStoreContext>(options => options.UseSqlite(sqlLiteConnection));
            builder.Services.AddDbContext<ImageStoreContext>(options => options.UseSqlite(sqlLiteConnection));
        }

        // TODO Register services
        public static void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IActivityService, ActivityService>();
        }
    }
}
