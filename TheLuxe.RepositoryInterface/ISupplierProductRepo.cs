using System.Threading.Tasks;
using TheLuxe.Entity;

namespace TheLuxe.RepositoryInterface
{
    public interface ISupplierProductRepo
    {
        Task DeleteSupplierProductAsync(tblSupplierProduct entity);

        tblSupplierProduct GetSupplierProduct(int SupplierProductId);
        bool Save();
        void Commit();
    }
}
