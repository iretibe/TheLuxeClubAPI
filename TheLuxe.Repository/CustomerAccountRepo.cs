using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using TheLuxe.Data;
using TheLuxe.Helper;
using TheLuxe.Model.CustomerAccount;
using TheLuxe.RepositoryInterface;

namespace TheLuxe.Repository
{

    public class CustomerAccountRepo : ICustomerAccountRepo
    {
        private TheLuxeClubContext _context;

        public CustomerAccountRepo(TheLuxeClubContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<uspSelectCustomerAccount>> GetCustomerAccountAsync()
        {
            List<uspSelectCustomerAccount> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspSelectCustomerAccount";
                cmdObj.CommandType = CommandType.StoredProcedure;

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<uspSelectCustomerAccount>();
                }
            }
            return lst;
        }
    }
}
