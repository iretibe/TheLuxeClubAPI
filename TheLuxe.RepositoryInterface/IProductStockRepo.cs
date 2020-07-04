using System.Collections.Generic;
using System.Threading.Tasks;
using TheLuxe.Model.ProductStock;

namespace TheLuxe.RepositoryInterface
{
    public interface IProductStockRepo
    {
        Task AddProductStockAsync(int ProductID, double StockLevel, double ReOrderLevel, bool? NoStockUpdate);
        Task AddProductStockForNewlyCreatedCompanyLocationAsync(int CompanyLocationID);
        Task<IEnumerable<uspSelectProductStock>> GetProductStockAsync(int? ProductID, int? CompanyLocationID, int? ProductCategoryID);
        Task<IEnumerable<uspSelectProductStockLevel>> GetProductStockLevelAsync(int? ProductID, int? CompanyLocationID);
        Task<IEnumerable<uspSelectProductStockTaking>> GetProductStockTakingAsync(int? ProductCategoryID, int? CompanyLocationID);
        Task<IEnumerable<uspSelectProductStockToUpdate>> GetProductStockToUpdateAsync(int? ProductID, int? CompanyLocationID, int? ProductCategoryID);
        Task<IEnumerable<uspSelectProductTransactionSummary>> GetProductTransactionSummaryAsync(int? ProductCategoryID, int? ProductID, int CompanyLocationID);
        Task<IEnumerable<uspSelectProductWichHasStock>> GetProductWichHasStockAsync(string ProductCodeName);
        Task TruncateProductStockLevel();
        Task UpdateProductStockAsync(int ProductID, double StockLevel, double ReOrderLevel, int CompanyLocationID, int UserID);
        Task UpdateProductStockLevelAsync(int ProductID, double Qty);
    }
}
