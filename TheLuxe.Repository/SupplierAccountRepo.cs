using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using TheLuxe.Data;
using TheLuxe.Helper;
using TheLuxe.Model.SupplierAccount;
using TheLuxe.RepositoryInterface;

namespace TheLuxe.Repository
{
    public class SupplierAccountRepo : ISupplierAccountRepo
    {
        private TheLuxeClubContext _context;

        public SupplierAccountRepo(TheLuxeClubContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<uspSelectSupplierAccount>> GetSupplierAccountAsync(int SupplierID)
        {
            List<uspSelectSupplierAccount> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspSelectSupplierAccount";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@SupplierID", SupplierID));

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<uspSelectSupplierAccount>();
                }
            }
            return lst;
        }
    }
}
