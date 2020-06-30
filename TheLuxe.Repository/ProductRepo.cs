using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using TheLuxe.Data;
using TheLuxe.Entity;
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

        public tblProduct GetProduct(int ProductId)
        {
            return _context.tblProduct.FirstOrDefault(c => c.ProductID == ProductId);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
