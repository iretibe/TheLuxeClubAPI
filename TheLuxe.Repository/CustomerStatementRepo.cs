using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using TheLuxe.Data;
using TheLuxe.Helper;
using TheLuxe.Model.CustomerStatement;
using TheLuxe.RepositoryInterface;

namespace TheLuxe.Repository
{
    public class CustomerStatementRepo : ICustomerStatementRepo
    {
        private TheLuxeClubContext _context;

        public CustomerStatementRepo(TheLuxeClubContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<uspSelectCustomerStatement>> GetCustomerStatementAsync(int CustomerID, DateTime CustomerStatementDateFrom, DateTime CustomerStatementDateTo)
        {
            List<uspSelectCustomerStatement> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspSelectCustomerStatement";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@CustomerID", CustomerID));
                cmdObj.Parameters.Add(new SqlParameter("@CustomerStatementDateFrom", CustomerStatementDateFrom));
                cmdObj.Parameters.Add(new SqlParameter("@CustomerStatementDateTo", CustomerStatementDateTo));

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<uspSelectCustomerStatement>();
                }
            }
            return lst;
        }
    }
}
