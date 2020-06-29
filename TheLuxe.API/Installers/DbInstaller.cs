using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TheLuxe.Data;
using TheLuxe.Entity;
using TheLuxe.Model;
using TheLuxe.Repository;
using TheLuxe.RepositoryInterface;

namespace TheLuxe.API.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["connectionStrings:DefaultConnection"];
            services.AddDbContext<TheLuxeClubContext>(o => o.UseSqlServer(connectionString));
            services.AddDbContext<AuthenticationContext>(o => o.UseSqlServer(connectionString));

            //services.AddDbContext<TheLuxeClubContext>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            //var connString = Configuration["connectionStrings:DefaultConnection"];
            //services.AddDbContext<TheLuxeClubContext>(o => o.UseSqlServer(connString));

            services.AddDefaultIdentity<ApplicationUser>().AddEntityFrameworkStores<AuthenticationContext>();

            services.AddScoped<ICategoryRepo, CategoryRepo>();
            services.AddScoped<IPackageRepo, PackageRepo>();
            services.AddScoped<IProductPriceRepo, ProductPriceRepo>();
            services.AddScoped<ICategoryDetailRepo, CategoryDetailRepo>();
            services.AddScoped<ICategoryGroupRepo, CategoryGroupRepo>();
        }
    }
}
