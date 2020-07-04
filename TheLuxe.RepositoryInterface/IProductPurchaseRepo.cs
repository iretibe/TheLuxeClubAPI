using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheLuxe.Model.ProductPurchase;

namespace TheLuxe.RepositoryInterface
{
    public interface IProductPurchaseRepo
    {
        Task<IEnumerable<uspSelectProductForStockPurchase>> GetProductForStockPurchaseAsync(string ProductCodeName, int ProductID, int ProductCategoryID, int CompanyLocationID);
        Task<IEnumerable<uspSelectProductPurchase>> GetProductPurchaseAsync(DateTime? StockPurchaseDateFrom, DateTime? StockPurchaseDateTo, int? ProductID, int? SupplierID, int? UserID, int? CompanyLocationID);
    }
}
