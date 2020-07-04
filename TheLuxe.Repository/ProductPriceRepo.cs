using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using TheLuxe.Data;
using TheLuxe.Entity;
using TheLuxe.Helper;
using TheLuxe.Model.ProductPrice;
using TheLuxe.RepositoryInterface;

namespace TheLuxe.Repository
{
    public class ProductPriceRepo : IProductPriceRepo
    {
        private TheLuxeClubContext _context;

        public ProductPriceRepo(TheLuxeClubContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddProductPriceAsync(int ProductID, int PackageID, decimal CostPrice, double QtyInPackage, 
            decimal SellingPriceWithoutTAX, decimal VAT, decimal NHIL, decimal TL, decimal SellingPriceWithTAX, 
            bool ExemptVAT, bool ExemptNHIL, bool ExemptTL, int UserID, bool? ShowInMenuList)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspInsertProductPrice";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductID", ProductID));
                cmdObj.Parameters.Add(new SqlParameter("@PackageID", PackageID));
                cmdObj.Parameters.Add(new SqlParameter("@CostPrice", CostPrice));
                cmdObj.Parameters.Add(new SqlParameter("@QtyInPackage", QtyInPackage));
                cmdObj.Parameters.Add(new SqlParameter("@SellingPriceWithoutTAX", SellingPriceWithoutTAX));
                cmdObj.Parameters.Add(new SqlParameter("@VAT", VAT));
                cmdObj.Parameters.Add(new SqlParameter("@NHIL", NHIL));
                cmdObj.Parameters.Add(new SqlParameter("@TL", TL));
                cmdObj.Parameters.Add(new SqlParameter("@SellingPriceWithTAX", SellingPriceWithTAX));
                cmdObj.Parameters.Add(new SqlParameter("@ExemptVAT", ExemptVAT));
                cmdObj.Parameters.Add(new SqlParameter("@ExemptNHIL", ExemptNHIL));
                cmdObj.Parameters.Add(new SqlParameter("@ExemptTL", ExemptTL));
                cmdObj.Parameters.Add(new SqlParameter("@UserID", UserID));
                cmdObj.Parameters.Add(new SqlParameter("@ShowInMenuList", ShowInMenuList));

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public async Task AddProductPriceChangeAsync(int ProductID, int PackageID, decimal SellingPriceWithoutTAX, decimal NewSellingPrice, int UserID)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspInsertProductPriceChange";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductID", ProductID));
                cmdObj.Parameters.Add(new SqlParameter("@PackageID", PackageID));
                cmdObj.Parameters.Add(new SqlParameter("@SellingPriceWithoutTAX", SellingPriceWithoutTAX));
                cmdObj.Parameters.Add(new SqlParameter("@NewSellingPrice", NewSellingPrice));
                cmdObj.Parameters.Add(new SqlParameter("@UserID", UserID));

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public async Task AddProductPriceForNewlyCreatedCompanyLocationAsync(int CompanyLocationID)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspInsertProductPriceForNewlyCreatedCompanyLocation";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@CompanyLocationID", CompanyLocationID));

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public Task AddProductStockTakingAsync(int ProductID, string ProductName, int BaseUnitID, decimal StockLevel, decimal NewStockLevel, int UserID)
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task DeleteProductPriceAsync(tblProductPrice entity)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspDeleteProductPrice";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductPriceID", entity.ProductPriceID));

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public async Task<IEnumerable<uspSelectAvailableProductWithPriceForCashier>> GetAvailableProductWithPriceForCashierAsync(int CompanyLocationID, int ProductCategoryID)
        {
            List<uspSelectAvailableProductWithPriceForCashier> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspSelectAvailableProductWithPriceForCashier";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@CompanyLocationID", CompanyLocationID));
                cmdObj.Parameters.Add(new SqlParameter("@ProductCategoryID", ProductCategoryID));

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<uspSelectAvailableProductWithPriceForCashier>();
                }
            }
            return lst;
        }

        public async Task<IEnumerable<uspMobileSelectAvailableProductWithPriceForCashier>> GetMobileAvailableProductWithPriceForCashierAsync(int CompanyLocationID, int ProductCategoryID)
        {
            List<uspMobileSelectAvailableProductWithPriceForCashier> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspMobileSelectAvailableProductWithPriceForCashier";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@CompanyLocationID", CompanyLocationID));
                cmdObj.Parameters.Add(new SqlParameter("@ProductCategoryID", ProductCategoryID));

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<uspMobileSelectAvailableProductWithPriceForCashier>();
                }
            }
            return lst;
        }

        public tblProductPrice GetProductPrice(int ProductPriceId)
        {
            return _context.tblProductPrice.FirstOrDefault(c => c.ProductPriceID == ProductPriceId);
        }

        public async Task<IEnumerable<uspSelectProductPrice>> GetProductPriceAsync(int ProductID, int CompanyLocationID)
        {
            List<uspSelectProductPrice> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspSelectProductPrice";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductID", ProductID));
                cmdObj.Parameters.Add(new SqlParameter("@CompanyLocationID", CompanyLocationID));

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<uspSelectProductPrice>();
                }
            }
            return lst;
        }

        public async Task<IEnumerable<uspSelectProductPriceByPackageID>> GetProductPriceByPackageIDAsync(int ProductID, int PackageID, int CompanyLocationID)
        {
            List<uspSelectProductPriceByPackageID> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspSelectProductPriceByPackageID";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductID", ProductID));
                cmdObj.Parameters.Add(new SqlParameter("@PackageID", PackageID));
                cmdObj.Parameters.Add(new SqlParameter("@CompanyLocationID", CompanyLocationID));

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<uspSelectProductPriceByPackageID>();
                }
            }
            return lst;
        }

        public async Task GetProductPriceChangeAsync(int ProductCategoryID)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspSelectProductPriceChange";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductCategoryID", ProductCategoryID));

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public async Task<IEnumerable<uspSelectProductSellingUnit>> GetProductSellingUnitAsync(int ProductID, int CompanyLocationID)
        {
            List<uspSelectProductSellingUnit> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspSelectProductSellingUnit";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductID", ProductID));
                cmdObj.Parameters.Add(new SqlParameter("@CompanyLocationID", CompanyLocationID));

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<uspSelectProductSellingUnit>();
                }
            }
            return lst;
        }

        public async Task<IEnumerable<uspSelectSellingUnitByProductID>> GetSellingUnitByProductIDAsync(int ProductID)
        {
            List<uspSelectSellingUnitByProductID> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspSelectSellingUnitByProductID";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductID", ProductID));

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<uspSelectSellingUnitByProductID>();
                }
            }
            return lst;
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public async Task TruncateProductPrice()
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspTruncateProductPrice";
                cmdObj.CommandType = CommandType.StoredProcedure;

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public async Task UpdateProductCostPriceAsync(int ProductID)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspUpdateProductCostPrice";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductID", ProductID));

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public async Task UpdateProductPriceAsync(int ProductPriceID, int ProductID, int PackageID, decimal CostPrice, 
            double QtyInPackage, decimal SellingPriceWithoutTAX, decimal VAT, decimal NHIL, decimal TL, decimal SellingPriceWithTAX, 
            bool ExemptVAT, bool ExemptNHIL, bool ExemptTL, int UserID, bool? ShowInMenuList)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspUpdateProductPrice";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductPriceID", ProductPriceID));
                cmdObj.Parameters.Add(new SqlParameter("@ProductID", ProductID));
                cmdObj.Parameters.Add(new SqlParameter("@PackageID", PackageID));
                cmdObj.Parameters.Add(new SqlParameter("@CostPrice", CostPrice));
                cmdObj.Parameters.Add(new SqlParameter("@QtyInPackage", QtyInPackage));
                cmdObj.Parameters.Add(new SqlParameter("@SellingPriceWithoutTAX", SellingPriceWithoutTAX));
                cmdObj.Parameters.Add(new SqlParameter("@VAT", VAT));
                cmdObj.Parameters.Add(new SqlParameter("@NHIL", NHIL));
                cmdObj.Parameters.Add(new SqlParameter("@TL", TL));
                cmdObj.Parameters.Add(new SqlParameter("@SellingPriceWithTAX", SellingPriceWithTAX));
                cmdObj.Parameters.Add(new SqlParameter("@ExemptVAT", ExemptVAT));
                cmdObj.Parameters.Add(new SqlParameter("@ExemptNHIL", ExemptNHIL));
                cmdObj.Parameters.Add(new SqlParameter("@ExemptTL", ExemptTL));
                cmdObj.Parameters.Add(new SqlParameter("@UserID", UserID));
                cmdObj.Parameters.Add(new SqlParameter("@ShowInMenuList", ShowInMenuList));

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public async Task UpdateProductPriceForNewProductAsync(int ProductPriceID, int ProductID, int PackageID, 
            decimal CostPrice, double QtyInPackage, decimal SellingPriceWithoutTAX, decimal VAT, decimal NHIL, 
            decimal TL, decimal SellingPriceWithTAX, bool ExemptVAT, bool ExemptNHIL, bool ExemptTL, int UserID, 
            bool? ShowInMenuList)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspUpdateProductPriceForNewProduct";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductPriceID", ProductPriceID));
                cmdObj.Parameters.Add(new SqlParameter("@ProductID", ProductID));
                cmdObj.Parameters.Add(new SqlParameter("@PackageID", PackageID));
                cmdObj.Parameters.Add(new SqlParameter("@CostPrice", CostPrice));
                cmdObj.Parameters.Add(new SqlParameter("@QtyInPackage", QtyInPackage));
                cmdObj.Parameters.Add(new SqlParameter("@SellingPriceWithoutTAX", SellingPriceWithoutTAX));
                cmdObj.Parameters.Add(new SqlParameter("@VAT", VAT));
                cmdObj.Parameters.Add(new SqlParameter("@NHIL", NHIL));
                cmdObj.Parameters.Add(new SqlParameter("@TL", TL));
                cmdObj.Parameters.Add(new SqlParameter("@SellingPriceWithTAX", SellingPriceWithTAX));
                cmdObj.Parameters.Add(new SqlParameter("@ExemptVAT", ExemptVAT));
                cmdObj.Parameters.Add(new SqlParameter("@ExemptNHIL", ExemptNHIL));
                cmdObj.Parameters.Add(new SqlParameter("@ExemptTL", ExemptTL));
                cmdObj.Parameters.Add(new SqlParameter("@UserID", UserID));
                cmdObj.Parameters.Add(new SqlParameter("@ShowInMenuList", ShowInMenuList));

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public async Task UpdateProductPriceFromInventoryAsync(int ProductPriceID, int ProductID, int PackageID, 
            decimal CostPrice, double QtyInPackage, decimal SellingPriceWithoutTAX, decimal VAT, decimal NHIL, 
            decimal SellingPriceWithTAX, bool ExemptVAT, bool ExemptNHIL, int UserID)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspUpdateProductPriceFromInventory";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductPriceID", ProductPriceID));
                cmdObj.Parameters.Add(new SqlParameter("@ProductID", ProductID));
                cmdObj.Parameters.Add(new SqlParameter("@PackageID", PackageID));
                cmdObj.Parameters.Add(new SqlParameter("@CostPrice", CostPrice));
                cmdObj.Parameters.Add(new SqlParameter("@QtyInPackage", QtyInPackage));
                cmdObj.Parameters.Add(new SqlParameter("@SellingPriceWithoutTAX", SellingPriceWithoutTAX));
                cmdObj.Parameters.Add(new SqlParameter("@VAT", VAT));
                cmdObj.Parameters.Add(new SqlParameter("@NHIL", NHIL));
                cmdObj.Parameters.Add(new SqlParameter("@SellingPriceWithTAX", SellingPriceWithTAX));
                cmdObj.Parameters.Add(new SqlParameter("@ExemptVAT", ExemptVAT));
                cmdObj.Parameters.Add(new SqlParameter("@ExemptNHIL", ExemptNHIL));
                cmdObj.Parameters.Add(new SqlParameter("@UserID", UserID));

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public async Task UpdateProductPriceFromProductAsync(int ProductID, int PackageID, decimal CostPrice, 
            decimal SellingPriceWithTAX, int UserID, int CompanyLocationID, int ProductPriceID)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspUpdateProductPriceFromProduct";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductID", ProductID));
                cmdObj.Parameters.Add(new SqlParameter("@PackageID", PackageID));
                cmdObj.Parameters.Add(new SqlParameter("@CostPrice", CostPrice));
                cmdObj.Parameters.Add(new SqlParameter("@SellingPriceWithTAX", SellingPriceWithTAX));
                cmdObj.Parameters.Add(new SqlParameter("@UserID", UserID));
                cmdObj.Parameters.Add(new SqlParameter("@CompanyLocationID", CompanyLocationID));
                cmdObj.Parameters.Add(new SqlParameter("@ProductPriceID", ProductPriceID));

                await cmdObj.ExecuteScalarAsync();
            }
        }
    }
}
