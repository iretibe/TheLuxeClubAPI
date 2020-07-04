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
using TheLuxe.Model.Product;
using TheLuxe.RepositoryInterface;

namespace TheLuxe.Repository
{
    public class ProductRepo : IProductRepo
    {
        private TheLuxeClubContext _context;

        public ProductRepo(TheLuxeClubContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddProductAsync(string ProductCode, string BarCode, string ProductName, bool? IsActive, double StockLevel, 
            int BaseUnitID, double ReOrderLevel, int ProductCategoryID, int UserID, bool? DoesItHaveStock, bool? AllowProtocol, 
            decimal? SellingPrice, decimal? CostPrice, int CompanyLocationID)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspInsertProduct";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductCode", ProductCode));
                cmdObj.Parameters.Add(new SqlParameter("@BarCode", BarCode));
                cmdObj.Parameters.Add(new SqlParameter("@ProductName", ProductName));
                cmdObj.Parameters.Add(new SqlParameter("@IsActive", IsActive));
                cmdObj.Parameters.Add(new SqlParameter("@StockLevel", StockLevel));
                cmdObj.Parameters.Add(new SqlParameter("@BaseUnitID", BaseUnitID));
                cmdObj.Parameters.Add(new SqlParameter("@ReOrderLevel", ReOrderLevel));
                cmdObj.Parameters.Add(new SqlParameter("@ProductCategoryID", ProductCategoryID));
                cmdObj.Parameters.Add(new SqlParameter("@UserID", UserID));
                cmdObj.Parameters.Add(new SqlParameter("@DoesItHaveStock", DoesItHaveStock));
                cmdObj.Parameters.Add(new SqlParameter("@AllowProtocol", AllowProtocol));
                cmdObj.Parameters.Add(new SqlParameter("@SellingPrice", SellingPrice));
                cmdObj.Parameters.Add(new SqlParameter("@CostPrice", CostPrice));
                cmdObj.Parameters.Add(new SqlParameter("@CompanyLocationID", CompanyLocationID));

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public Task CheckProductBarCodeAsync(int ProductID, string BarCode)
        {
            throw new System.NotImplementedException();
        }

        public Task CheckProductWithNoStockRecipeStockLevelAsync(int ProductID, double Qty, int CompanyLocationID)
        {
            throw new System.NotImplementedException();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task DeleteProductAsync(tblProduct entity)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspDeleteProduct";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductID", entity.ProductID));

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public async Task<IEnumerable<uspSelectAvailableProduct>> GetAvailableProductAsync(string ProductCodeName, int ProductID, int ProductCategoryID)
        {
            List<uspSelectAvailableProduct> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspSelectAvailableProduct";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductCodeName", ProductCodeName));
                cmdObj.Parameters.Add(new SqlParameter("@ProductID", ProductID));
                cmdObj.Parameters.Add(new SqlParameter("@ProductCategoryID", ProductCategoryID));

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<uspSelectAvailableProduct>();
                }
            }
            return lst;
        }

        public async Task GetAvailableProductByBarCodeAsync(string BarCode, int ProductID, int ProductCategoryID)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspSelectAvailableProductByBarCode";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@BarCode", BarCode));
                cmdObj.Parameters.Add(new SqlParameter("@ProductID", ProductID));
                cmdObj.Parameters.Add(new SqlParameter("@ProductCategoryID", ProductCategoryID));

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public tblProduct GetProduct(int ProductId)
        {
            return _context.tblProduct.FirstOrDefault(c => c.ProductID == ProductId);
        }

        public async Task<IEnumerable<uspSelectProductDropDown>> GetProductDropDownAsync()
        {
            List<uspSelectProductDropDown> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspSelectProductDropDown";
                cmdObj.CommandType = CommandType.StoredProcedure;

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<uspSelectProductDropDown>();
                }
            }
            return lst;
        }

        public async Task<IEnumerable<uspSelectProductDropDownForStockPurchase>> GetProductDropDownForStockPurchaseAsync()
        {
            List<uspSelectProductDropDownForStockPurchase> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspSelectProductDropDownForStockPurchase";
                cmdObj.CommandType = CommandType.StoredProcedure;

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<uspSelectProductDropDownForStockPurchase>();
                }
            }
            return lst;
        }

        public async Task GetProductInStockAsync(string ProductCodeName)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspSelectProductInStock";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductCodeName", ProductCodeName));

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public async Task<IEnumerable<uspSelectProductPicture>> GetProductPictureAsync(int ProductID)
        {
            List<uspSelectProductPicture> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspSelectProductPicture";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductID", ProductID));

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<uspSelectProductPicture>();
                }
            }
            return lst;
        }

        public async Task<IEnumerable<uspSelectProductPriceNew>> GetProductPriceNewAsync(int? ProductCategoryID)
        {
            List<uspSelectProductPriceNew> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspSelectProductPriceNew";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductCategoryID", ProductCategoryID));

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<uspSelectProductPriceNew>();
                }
            }
            return lst;
        }

        public async Task<IEnumerable<uspSelectProductWithNoStockForRecipe>> GetProductWithNoStockForRecipeAsync(string ProductCodeName, int? ProductID, int? ProductCategoryID)
        {
            List<uspSelectProductWithNoStockForRecipe> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspSelectProductWithNoStockForRecipe";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductCodeName", ProductCodeName));
                cmdObj.Parameters.Add(new SqlParameter("@ProductID", ProductID));
                cmdObj.Parameters.Add(new SqlParameter("@ProductCategoryID", ProductCategoryID));

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<uspSelectProductWithNoStockForRecipe>();
                }
            }
            return lst;
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public async Task TruncateProduct()
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspTruncateProduct";
                cmdObj.CommandType = CommandType.StoredProcedure;

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public async Task UpdateProductAsync(int ProductID, string ProductCode, string BarCode, string ProductName, 
            bool? IsActive, int BaseUnitID, int ProductCategoryID, int UserID, bool? DoesItHaveStock, bool? AllowProtocol, decimal NoOfPortion)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspUpdateProduct";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductID", ProductID));
                cmdObj.Parameters.Add(new SqlParameter("@ProductCode", ProductCode));
                cmdObj.Parameters.Add(new SqlParameter("@BarCode", BarCode));
                cmdObj.Parameters.Add(new SqlParameter("@ProductName", ProductName));
                cmdObj.Parameters.Add(new SqlParameter("@IsActive", IsActive));
                cmdObj.Parameters.Add(new SqlParameter("@BaseUnitID", BaseUnitID));
                cmdObj.Parameters.Add(new SqlParameter("@ProductCategoryID", ProductCategoryID));
                cmdObj.Parameters.Add(new SqlParameter("@UserID", UserID));
                cmdObj.Parameters.Add(new SqlParameter("@DoesItHaveStock", DoesItHaveStock));
                cmdObj.Parameters.Add(new SqlParameter("@AllowProtocol", AllowProtocol));
                cmdObj.Parameters.Add(new SqlParameter("@NoOfPortion", NoOfPortion));

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public async Task UpdateProductFromInventoryAsync(int ProductID, string ProductCode, string BarCode, string ProductName, 
            string Description, int StatusID, int BaseUnitID, DateTime ExpiryDate, int ProductCategoryID, int UserID, bool? DoesItHaveStock)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspUpdateProductFromInventory";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductID", ProductID));
                cmdObj.Parameters.Add(new SqlParameter("@ProductCode", ProductCode));
                cmdObj.Parameters.Add(new SqlParameter("@BarCode", BarCode));
                cmdObj.Parameters.Add(new SqlParameter("@ProductName", ProductName));
                cmdObj.Parameters.Add(new SqlParameter("@Description", Description));
                cmdObj.Parameters.Add(new SqlParameter("@StatusID", StatusID));
                cmdObj.Parameters.Add(new SqlParameter("@BaseUnitID", BaseUnitID));
                cmdObj.Parameters.Add(new SqlParameter("@ExpiryDate", ExpiryDate));
                cmdObj.Parameters.Add(new SqlParameter("@ProductCategoryID", ProductCategoryID));
                cmdObj.Parameters.Add(new SqlParameter("@UserID", UserID));
                cmdObj.Parameters.Add(new SqlParameter("@DoesItHaveStock", DoesItHaveStock));

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public async Task UpdateProductPictureAsync(int ProductID, byte[] ProductPicture)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspUpdateProductPicture";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductID", ProductID));
                cmdObj.Parameters.Add(new SqlParameter("@ProductPicture", ProductPicture));

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public async Task UpdateProductWithPriceAsync(int ProductID, string ProductCode, string BarCode, string ProductName, 
            bool? IsActive, int BaseUnitID, int ProductCategoryID, int UserID, bool? DoesItHaveStock, bool? AllowProtocol, 
            decimal SellingPrice, decimal CostPrice, int CompanyLocationID, int ProductPriceID)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspUpdateProductWithPrice";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductID", ProductID));
                cmdObj.Parameters.Add(new SqlParameter("@ProductCode", ProductCode));
                cmdObj.Parameters.Add(new SqlParameter("@BarCode", BarCode));
                cmdObj.Parameters.Add(new SqlParameter("@ProductName", ProductName));
                cmdObj.Parameters.Add(new SqlParameter("@IsActive", IsActive));
                cmdObj.Parameters.Add(new SqlParameter("@BaseUnitID", BaseUnitID));
                cmdObj.Parameters.Add(new SqlParameter("@ProductCategoryID", ProductCategoryID));
                cmdObj.Parameters.Add(new SqlParameter("@UserID", UserID));
                cmdObj.Parameters.Add(new SqlParameter("@DoesItHaveStock", DoesItHaveStock));
                cmdObj.Parameters.Add(new SqlParameter("@AllowProtocol", AllowProtocol));
                cmdObj.Parameters.Add(new SqlParameter("@SellingPrice", SellingPrice));
                cmdObj.Parameters.Add(new SqlParameter("@CostPrice", CostPrice));
                cmdObj.Parameters.Add(new SqlParameter("@CompanyLocationID", CompanyLocationID));
                cmdObj.Parameters.Add(new SqlParameter("@ProductPriceID", ProductPriceID));

                await cmdObj.ExecuteScalarAsync();
            }
        }
    }
}
