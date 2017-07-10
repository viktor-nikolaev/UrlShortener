using Microsoft.AspNetCore.Builder;
using UrlShortener.Dal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace UrlShortener.WebApp.Helpers
{
    public static class DatabaseExtensions
    {
        public static void MigrateDatabase(this IApplicationBuilder app)
        {
            var context = app.ApplicationServices.GetService<UrlShortenerDb>();
            context.Database.Migrate();
        }
    }
}