using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheLuxe.Model.ProductTransfer;

namespace TheLuxe.RepositoryInterface
{
    public interface IProductTransferRepo
    {
        Task<IEnumerable<uspSelectProductForStockTransfer>> GetProductForStockTransferAsync(string ProductCodeName, int ProductID, int ProductCategoryID, int CompanyLocationID);
        Task<IEnumerable<uspSelectProductForStockTransferFrom>> GetProductForStockTransferFromAsync(string ProductCodeName, int ProductID, int ProductCategoryID, int CompanyLocationID);
        Task<IEnumerable<uspSelectProductTransfer>> GetProductTransferAsync(DateTime? StockTransferDateFrom, DateTime? StockTransferDateTo, int? ProductID, int? UserID, int? FromCompanyLocationID, int? ToCompanyLocationID);
    }
}
