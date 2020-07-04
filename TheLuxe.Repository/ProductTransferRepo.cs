using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using TheLuxe.Data;
using TheLuxe.Helper;
using TheLuxe.Model.ProductTransfer;
using TheLuxe.RepositoryInterface;

namespace TheLuxe.Repository
{
    public class ProductTransferRepo : IProductTransferRepo
    {
        private TheLuxeClubContext _context;

        public ProductTransferRepo(TheLuxeClubContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<uspSelectProductForStockTransfer>> GetProductForStockTransferAsync(string ProductCodeName, 
            int ProductID, int ProductCategoryID, int CompanyLocationID)
        {
            List<uspSelectProductForStockTransfer> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspSelectProductForStockTransfer";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductCodeName", ProductCodeName));
                cmdObj.Parameters.Add(new SqlParameter("@ProductID", ProductID));
                cmdObj.Parameters.Add(new SqlParameter("@ProductCategoryID", ProductCategoryID));
                cmdObj.Parameters.Add(new SqlParameter("@CompanyLocationID", CompanyLocationID));

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<uspSelectProductForStockTransfer>();
                }
            }
            return lst;
        }

        public async Task<IEnumerable<uspSelectProductForStockTransferFrom>> GetProductForStockTransferFromAsync(string ProductCodeName, 
            int ProductID, int ProductCategoryID, int CompanyLocationID)
        {
            List<uspSelectProductForStockTransferFrom> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspSelectProductForStockTransferFrom";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductCodeName", ProductCodeName));
                cmdObj.Parameters.Add(new SqlParameter("@ProductID", ProductID));
                cmdObj.Parameters.Add(new SqlParameter("@ProductCategoryID", ProductCategoryID));
                cmdObj.Parameters.Add(new SqlParameter("@CompanyLocationID", CompanyLocationID));

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<uspSelectProductForStockTransferFrom>();
                }
            }
            return lst;
        }

        public async Task<IEnumerable<uspSelectProductTransfer>> GetProductTransferAsync(DateTime? StockTransferDateFrom, 
            DateTime? StockTransferDateTo, int? ProductID, int? UserID, int? FromCompanyLocationID, int? ToCompanyLocationID)
        {
            List<uspSelectProductTransfer> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspSelectProductTransfer";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@StockTransferDateFrom", StockTransferDateFrom));
                cmdObj.Parameters.Add(new SqlParameter("@StockTransferDateTo", StockTransferDateTo));
                cmdObj.Parameters.Add(new SqlParameter("@ProductID", ProductID));
                cmdObj.Parameters.Add(new SqlParameter("@UserID", UserID));
                cmdObj.Parameters.Add(new SqlParameter("@FromCompanyLocationID", FromCompanyLocationID));
                cmdObj.Parameters.Add(new SqlParameter("@ToCompanyLocationID", ToCompanyLocationID));

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<uspSelectProductTransfer>();
                }
            }
            return lst;
        }
    }
}
