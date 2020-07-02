using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using TheLuxe.Data;
using TheLuxe.Helper;
using TheLuxe.Model.SupplierStatement;
using TheLuxe.RepositoryInterface;

namespace TheLuxe.Repository
{
    public class SupplierStatementRepo : ISupplierStatementRepo
    {
        private TheLuxeClubContext _context;

        public SupplierStatementRepo(TheLuxeClubContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<uspSelectSupplierStatement>> GetSupplierStatementAsync(int SupplierID, DateTime SupplierStatementDateFrom, DateTime SupplierStatementDateTo)
        {
            List<uspSelectSupplierStatement> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspSelectSupplierStatement";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@SupplierID", SupplierID));
                cmdObj.Parameters.Add(new SqlParameter("@SupplierStatementDateFrom", SupplierStatementDateFrom));
                cmdObj.Parameters.Add(new SqlParameter("@SupplierStatementDateTo", SupplierStatementDateTo));

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<uspSelectSupplierStatement>();
                }
            }
            return lst;
        }
    }
}
