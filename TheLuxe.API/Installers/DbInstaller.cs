using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TheLuxe.Data;
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
            services.AddScoped<ICategoryLocationRepo, CategoryLocationRepo>();
            services.AddScoped<IProductRepo, ProductRepo>();
            services.AddScoped<IProductRecipeRepo, ProductRecipeRepo>();
            services.AddScoped<ISupplierProductRepo, SupplierProductRepo>();
            services.AddScoped<ICustomerRepo, CustomerRepo>();
            services.AddScoped<ICustomerContactPersonRepo, CustomerContactPersonRepo>();
            services.AddScoped<ICustomerTypeRepo, CustomerTypeRepo>();
            services.AddScoped<IOrderRepo, OrderRepo>();
            services.AddScoped<ICustomerStatementRepo, CustomerStatementRepo>();
            services.AddScoped<ICustomerAccountRepo, CustomerAccountRepo>();
            services.AddScoped<ISupplierRepo, SupplierRepo>();
            services.AddScoped<ISupplierContactPersonRepo, SupplierContactPersonRepo>();
            services.AddScoped<ISupplierStatementRepo, SupplierStatementRepo>();
            services.AddScoped<ISupplierAccountRepo, SupplierAccountRepo>();
            services.AddScoped<IShiftProductStockTakingRepo, ShiftProductStockTakingRepo>();
            services.AddScoped<IProductStockRepo, ProductStockRepo>();
            services.AddScoped<IProductTransferRepo, ProductTransferRepo>();
            services.AddScoped<IProductPurchaseRepo, ProductPurchaseRepo>();
            services.AddScoped<IProductProtocolRepo, ProductProtocolRepo>();
            services.AddScoped<IProductOrderRepo, ProductOrderRepo>();
            services.AddScoped<IProductDamageRepo, ProductDamageRepo>();
            services.AddScoped<IOrderDetailRepo, OrderDetailRepo>();
        }
    }
}
