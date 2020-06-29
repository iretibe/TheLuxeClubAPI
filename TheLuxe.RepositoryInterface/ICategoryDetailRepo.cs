using System.Collections.Generic;
using System.Threading.Tasks;
using TheLuxe.Model.ProductCategoryDetail;

namespace TheLuxe.RepositoryInterface
{
    public interface ICategoryDetailRepo
    {
        Task AddProductCategoryDetailsAsync(int ProductCategoryID, int CompanyLocationID);
        Task<IEnumerable<uspSelectProductCategoryDetail>> GetProductCategoryDetailAsync(int ProductCategoryID);
        Task UpdateProductCategoryDetailsAsync(int ProductCategoryDetailID, bool? ShowInMenu, int ProductCategoryLocationID);
    }
}
