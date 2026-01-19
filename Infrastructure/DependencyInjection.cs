using Application.Data.DataBaseContext;
using Infrastructure.Data.DataBaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SqLiteConnection");

            services.AddDbContext<Data.DataBaseContext.ApplicationDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });

            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

            return services;
        }
    }
}
