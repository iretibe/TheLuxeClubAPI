using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using TheLuxe.Data;
using TheLuxe.RepositoryInterface;

namespace TheLuxe.Repository
{
    public class OrderDetailRepo : IOrderDetailRepo
    {
        private TheLuxeClubContext _context;

        public OrderDetailRepo(TheLuxeClubContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task CheckIfProductExistsInOrderAsync(int ProductID, int OrderID, int SellingUnitID)
        {
            throw new NotImplementedException();
        }

        public Task CheckProductInOrderAsync(int OrderID, int ProductID, int SellingUnitID, double Qty)
        {
            throw new NotImplementedException();
        }

        public async Task GetReturnOrderDetailProductWithNoStockAsync(int OrderDetailID)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspReturnOrderDetailProductWithNoStock";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@OrderDetailID", OrderDetailID));

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public async Task GetReturnOrderDetailProductWithStockAsync(int OrderDetailID, int CompanyLocationID)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspReturnOrderDetailProductWithStock";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@OrderDetailID", OrderDetailID));
                cmdObj.Parameters.Add(new SqlParameter("@CompanyLocationID", CompanyLocationID));

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public async Task GetReturnOrderProductWithNoStockAsync(int OrderID, int CompanyLocationID)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspReturnOrderProductWithNoStock";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@OrderID", OrderID));
                cmdObj.Parameters.Add(new SqlParameter("@CompanyLocationID", CompanyLocationID));

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public async Task GetReturnOrderProductWithStockAsync(int OrderID, int CompanyLocationID)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspReturnOrderProductWithStock";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@OrderID", OrderID));
                cmdObj.Parameters.Add(new SqlParameter("@CompanyLocationID", CompanyLocationID));

                await cmdObj.ExecuteScalarAsync();
            }
        }
    }
}
