using System.Collections.Generic;
using System.Threading.Tasks;
using TheLuxe.Model;

namespace TheLuxe.RepositoryInterface
{
    public interface ICategoryLocationRepo
    {
        Task CheckProductCategoryLocationInOrderAsync(int OrderID, int ProductCategoryLocationID, int ComputerLocationID);
        Task DeleteProductCategoryLocationAsync(int ProductCategoryLocationID);
        Task AddProductCategoryLocationAsync(string ProductCategoryLocationName, string PrinterName);
        Task<IEnumerable<uspSelectNoOfProductCategoryLocation>> GetNoOfProductCategoryLocationAsync();
        Task<IEnumerable<uspSelectProductCategoryLocation>> GetProductCategoryLocationAsync();
        Task UpdateProductCategoryLocationAsync(int ProductCategoryLocationID, string ProductCategoryLocationName, string PrinterName);
    }
}
