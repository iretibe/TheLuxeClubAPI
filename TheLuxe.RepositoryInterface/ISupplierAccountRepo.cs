using System.Collections.Generic;
using System.Threading.Tasks;
using TheLuxe.Model.SupplierAccount;

namespace TheLuxe.RepositoryInterface
{
    public interface ISupplierAccountRepo
    {
        Task<IEnumerable<uspSelectSupplierAccount>> GetSupplierAccountAsync(int SupplierID);
    }
}
