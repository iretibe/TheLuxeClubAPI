using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using TheLuxe.Data;
using TheLuxe.Helper;
using TheLuxe.Model.ProductStock;
using TheLuxe.RepositoryInterface;

namespace TheLuxe.Repository
{
    public class ProductStockRepo : IProductStockRepo
    {
        private TheLuxeClubContext _context;

        public ProductStockRepo(TheLuxeClubContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddProductStockAsync(int ProductID, double StockLevel, double ReOrderLevel, bool? NoStockUpdate)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspInsertProductStock";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductID", ProductID));
                cmdObj.Parameters.Add(new SqlParameter("@StockLevel", StockLevel));
                cmdObj.Parameters.Add(new SqlParameter("@ReOrderLevel", ReOrderLevel));
                cmdObj.Parameters.Add(new SqlParameter("@NoStockUpdate", NoStockUpdate));

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public async Task AddProductStockForNewlyCreatedCompanyLocationAsync(int CompanyLocationID)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspInsertProductStockForNewlyCreatedCompanyLocation";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@CompanyLocationID", CompanyLocationID));

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public async Task<IEnumerable<uspSelectProductStock>> GetProductStockAsync(int? ProductID, int? CompanyLocationID, int? ProductCategoryID)
        {
            List<uspSelectProductStock> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspSelectProductStock";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductID", ProductID));
                cmdObj.Parameters.Add(new SqlParameter("@CompanyLocationID", CompanyLocationID));
                cmdObj.Parameters.Add(new SqlParameter("@ProductCategoryID", ProductCategoryID));

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<uspSelectProductStock>();
                }
            }
            return lst;
        }

        public async Task<IEnumerable<uspSelectProductStockLevel>> GetProductStockLevelAsync(int? ProductID, int? CompanyLocationID)
        {
            List<uspSelectProductStockLevel> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspSelectProductStockLevel";
                cmdObj.CommandType = CommandType.StoredProcedure;

                cmdObj.Parameters.Add(new SqlParameter("@ProductID", ProductID));
                cmdObj.Parameters.Add(new SqlParameter("@CompanyLocationID", CompanyLocationID));

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<uspSelectProductStockLevel>();
                }
            }
            return lst;
        }

        public async Task<IEnumerable<uspSelectProductStockTaking>> GetProductStockTakingAsync(int? ProductCategoryID, int? CompanyLocationID)
        {
            List<uspSelectProductStockTaking> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspSelectProductStockTaking";
                cmdObj.CommandType = CommandType.StoredProcedure;
                
                cmdObj.Parameters.Add(new SqlParameter("@ProductCategoryID", ProductCategoryID));
                cmdObj.Parameters.Add(new SqlParameter("@CompanyLocationID", CompanyLocationID));

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<uspSelectProductStockTaking>();
                }
            }
            return lst;
        }

        public async Task<IEnumerable<uspSelectProductStockToUpdate>> GetProductStockToUpdateAsync(int? ProductID, int? CompanyLocationID, int? ProductCategoryID)
        {
            List<uspSelectProductStockToUpdate> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspSelectProductStockToUpdate";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductID", ProductID));
                cmdObj.Parameters.Add(new SqlParameter("@CompanyLocationID", CompanyLocationID));
                cmdObj.Parameters.Add(new SqlParameter("@ProductCategoryID", ProductCategoryID));

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<uspSelectProductStockToUpdate>();
                }
            }
            return lst;
        }

        public async Task<IEnumerable<uspSelectProductTransactionSummary>> GetProductTransactionSummaryAsync(int? ProductCategoryID, 
            int? ProductID, int CompanyLocationID)
        {
            List<uspSelectProductTransactionSummary> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspSelectProductTransactionSummary";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductCategoryID", ProductCategoryID));
                cmdObj.Parameters.Add(new SqlParameter("@ProductID", ProductID));
                cmdObj.Parameters.Add(new SqlParameter("@CompanyLocationID", CompanyLocationID));

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<uspSelectProductTransactionSummary>();
                }
            }
            return lst;
        }

        public async Task<IEnumerable<uspSelectProductWichHasStock>> GetProductWichHasStockAsync(string ProductCodeName)
        {
            List<uspSelectProductWichHasStock> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspSelectProductWichHasStock";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductCodeName", ProductCodeName));

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<uspSelectProductWichHasStock>();
                }
            }
            return lst;
        }

        public async Task TruncateProductStockLevel()
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspTruncateProductStockLevel";
                cmdObj.CommandType = CommandType.StoredProcedure;

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public async Task UpdateProductStockAsync(int ProductID, double StockLevel, double ReOrderLevel, int CompanyLocationID, int UserID)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspUpdateProductStock";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductID", ProductID));
                cmdObj.Parameters.Add(new SqlParameter("@StockLevel", StockLevel));
                cmdObj.Parameters.Add(new SqlParameter("@ReOrderLevel", ReOrderLevel));
                cmdObj.Parameters.Add(new SqlParameter("@CompanyLocationID", CompanyLocationID));
                cmdObj.Parameters.Add(new SqlParameter("@UserID", UserID));

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public async Task UpdateProductStockLevelAsync(int ProductID, double Qty)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspUpdateProductStockLevel";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductID", ProductID));
                cmdObj.Parameters.Add(new SqlParameter("@Qty", Qty));

                await cmdObj.ExecuteScalarAsync();
            }
        }
    }
}
