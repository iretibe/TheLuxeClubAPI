using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using TheLuxe.Data;
using TheLuxe.Helper;
using TheLuxe.Model.ProductPurchase;
using TheLuxe.RepositoryInterface;

namespace TheLuxe.Repository
{
    public class ProductPurchaseRepo : IProductPurchaseRepo
    {
        private TheLuxeClubContext _context;

        public ProductPurchaseRepo(TheLuxeClubContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<uspSelectProductForStockPurchase>> GetProductForStockPurchaseAsync(string ProductCodeName, 
            int ProductID, int ProductCategoryID, int CompanyLocationID)
        {
            List<uspSelectProductForStockPurchase> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspSelectProductForStockPurchase";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductCodeName", ProductCodeName));
                cmdObj.Parameters.Add(new SqlParameter("@ProductID", ProductID));
                cmdObj.Parameters.Add(new SqlParameter("@ProductCategoryID", ProductCategoryID));
                cmdObj.Parameters.Add(new SqlParameter("@CompanyLocationID", CompanyLocationID));

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<uspSelectProductForStockPurchase>();
                }
            }
            return lst;
        }

        public async Task<IEnumerable<uspSelectProductPurchase>> GetProductPurchaseAsync(DateTime? StockPurchaseDateFrom, 
            DateTime? StockPurchaseDateTo, int? ProductID, int? SupplierID, int? UserID, int? CompanyLocationID)
        {
            List<uspSelectProductPurchase> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspSelectProductPurchase";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@StockPurchaseDateFrom", StockPurchaseDateFrom));
                cmdObj.Parameters.Add(new SqlParameter("@StockPurchaseDateTo", StockPurchaseDateTo));
                cmdObj.Parameters.Add(new SqlParameter("@ProductID", ProductID));
                cmdObj.Parameters.Add(new SqlParameter("@SupplierID", SupplierID));
                cmdObj.Parameters.Add(new SqlParameter("@UserID", UserID));
                cmdObj.Parameters.Add(new SqlParameter("@CompanyLocationID", CompanyLocationID));

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<uspSelectProductPurchase>();
                }
            }
            return lst;
        }
    }
}
