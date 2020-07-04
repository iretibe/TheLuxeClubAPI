using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using TheLuxe.Data;
using TheLuxe.Helper;
using TheLuxe.Model.ProductDamage;
using TheLuxe.RepositoryInterface;

namespace TheLuxe.Repository
{
    public class ProductDamageRepo : IProductDamageRepo
    {
        private TheLuxeClubContext _context;

        public ProductDamageRepo(TheLuxeClubContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<uspSelectProductDamage>> GetProductDamageAsync(DateTime StockDamageDateFrom, 
            DateTime StockDamageDateTo, int ProductID, int UserID, int CompanyLocationID)
        {
            List<uspSelectProductDamage> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspSelectProductDamage";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@StockDamageDateFrom", StockDamageDateFrom));
                cmdObj.Parameters.Add(new SqlParameter("@StockDamageDateTo", StockDamageDateTo));
                cmdObj.Parameters.Add(new SqlParameter("@ProductID", ProductID));
                cmdObj.Parameters.Add(new SqlParameter("@UserID", UserID));
                cmdObj.Parameters.Add(new SqlParameter("@CompanyLocationID", CompanyLocationID));

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<uspSelectProductDamage>();
                }
            }
            return lst;
        }

        public async Task<IEnumerable<uspSelectProductForStockDamage>> GetProductForStockDamageAsync(string ProductCodeName, 
            int ProductID, int ProductCategoryID, int CompanyLocationID)
        {
            List<uspSelectProductForStockDamage> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspSelectProductForStockDamage";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductCodeName", ProductCodeName));
                cmdObj.Parameters.Add(new SqlParameter("@ProductID", ProductID));
                cmdObj.Parameters.Add(new SqlParameter("@ProductCategoryID", ProductCategoryID));
                cmdObj.Parameters.Add(new SqlParameter("@CompanyLocationID", CompanyLocationID));

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<uspSelectProductForStockDamage>();
                }
            }
            return lst;
        }
    }
}
