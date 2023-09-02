using APIWebApp.Service.Abstractions;
using APIWebApp.Service.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace APIWebApp.DependencyInjection
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterTypes(IServiceCollection services, IConfiguration configuration)
        {
            // Register ASP.NET Core services
            services.AddScoped<ISuperHeroService, SuperHeroService>();
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
