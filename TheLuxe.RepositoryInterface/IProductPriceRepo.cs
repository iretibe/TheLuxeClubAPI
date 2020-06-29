using System.Collections.Generic;
using System.Threading.Tasks;
using TheLuxe.Model.ProductPrice;

namespace TheLuxe.RepositoryInterface
{
    public interface IProductPriceRepo
    {
        Task<IEnumerable<uspSelectProductPriceByPackageID>> GetProductPriceByPackageIDAsync(int ProductID, int PackageID, int CompanyLocationID);
    }
}
