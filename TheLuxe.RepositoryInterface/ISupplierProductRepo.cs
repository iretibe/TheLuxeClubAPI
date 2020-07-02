using System.Collections.Generic;
using System.Threading.Tasks;
using TheLuxe.Entity;
using TheLuxe.Model.SupplierProduct;

namespace TheLuxe.RepositoryInterface
{
    public interface ISupplierProductRepo
    {
        Task DeleteSupplierProductAsync(tblSupplierProduct entity);

        tblSupplierProduct GetSupplierProduct(int SupplierProductId);
        bool Save();
        void Commit();
        Task AddSupplierProductAsync(int ProductID, int SupplierID);
        Task<IEnumerable<uspSelectSupplierProduct>> GetSupplierProductAsync(int SupplierID);
    }
}
