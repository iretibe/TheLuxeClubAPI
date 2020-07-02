using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheLuxe.Model.SupplierStatement;

namespace TheLuxe.RepositoryInterface
{
    public interface ISupplierStatementRepo
    {
        Task<IEnumerable<uspSelectSupplierStatement>> GetSupplierStatementAsync(int SupplierID, DateTime SupplierStatementDateFrom, DateTime SupplierStatementDateTo);
    }
}
