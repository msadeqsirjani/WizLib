using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WizLib.Infra.Data.Persistence;

namespace WizLib.Infra.IoC
{
    public static class DependencyContainer
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddDistributedMemoryCache()
                .AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


        }

        public static void EnableMiddleWares(this IApplicationBuilder app, IWebHostEnvironment env,
            IConfiguration configuration)
        {

        }
    }
}
