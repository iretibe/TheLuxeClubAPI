using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheLuxe.Model.CustomerStatement;

namespace TheLuxe.RepositoryInterface
{
    public interface ICustomerStatementRepo
    {
        Task<IEnumerable<uspSelectCustomerStatement>> GetCustomerStatementAsync(int CustomerID, DateTime CustomerStatementDateFrom, DateTime CustomerStatementDateTo);
    }
}
