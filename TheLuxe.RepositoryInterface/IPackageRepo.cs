using System.Collections.Generic;
using System.Threading.Tasks;
using TheLuxe.Entity;
using TheLuxe.Model.ProductPackage;

namespace TheLuxe.RepositoryInterface
{
    public interface IPackageRepo
    {
        Task DeleteProductPackageAsync(tblPackage entity);
        Task AddProductPackageAsync(string PackageName);
        Task<IEnumerable<uspSelectPackage>> GetPackageAsync();
        Task UpdateProductPackageAsync(int PackageID, string PackageName);
        tblPackage GetProductPackage(int ProductPackageId);
        bool Save();
        void Commit();
    }
}
