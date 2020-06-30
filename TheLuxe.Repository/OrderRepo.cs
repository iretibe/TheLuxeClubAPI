using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using TheLuxe.Data;
using TheLuxe.Helper;
using TheLuxe.Model.Order;
using TheLuxe.RepositoryInterface;

namespace TheLuxe.Repository
{
    public class OrderRepo : IOrderRepo
    {
        private TheLuxeClubContext _context;

        public OrderRepo(TheLuxeClubContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<uspSelectCustomerOustandingBalance>> GetCustomerOustandingBalanceAsync(int CustomerID)
        {
            List<uspSelectCustomerOustandingBalance> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspSelectCustomerOustandingBalance";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@CustomerID", CustomerID));

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<uspSelectCustomerOustandingBalance>();
                }
            }
            return lst;
        }

        public async Task<IEnumerable<uspSelectOrderByCustomer>> GetOrderByCustomerAsync(int CustomerID)
        {
            List<uspSelectOrderByCustomer> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspSelectOrderByCustomer";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@CustomerID", CustomerID));

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<uspSelectOrderByCustomer>();
                }
            }
            return lst;
        }

        public async Task<IEnumerable<uspSelectPendingOrderByCustomerID>> GetPendingOrderByCustomerIDAsync(int CustomerID)
        {
            List<uspSelectPendingOrderByCustomerID> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspSelectPendingOrderByCustomerID";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@CustomerID", CustomerID));

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<uspSelectPendingOrderByCustomerID>();
                }
            }
            return lst;
        }
    }
}
