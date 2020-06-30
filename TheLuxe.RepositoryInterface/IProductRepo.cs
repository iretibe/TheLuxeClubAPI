using System.Threading.Tasks;
using TheLuxe.Entity;

namespace TheLuxe.RepositoryInterface
{
    public interface IProductRepo
    {
        Task CheckProductBarCodeAsync(int ProductID, string BarCode);
        Task CheckProductWithNoStockRecipeStockLevelAsync(int ProductID, double Qty, int CompanyLocationID);
        Task DeleteProductAsync(tblProduct entity);
        Task AddProductAsync(string ProductCode, string BarCode, string ProductName, bool? IsActive, double StockLevel,
            int BaseUnitID, double ReOrderLevel, int ProductCategoryID, int UserID, bool? DoesItHaveStock, bool? AllowProtocol,
            decimal? SellingPrice, decimal? CostPrice, int CompanyLocationID);
        tblProduct GetProduct(int ProductId);
        bool Save();
        void Commit();
    }
}
