using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheLuxe.Model.ProductDamage;

namespace TheLuxe.RepositoryInterface
{
    public interface IProductDamageRepo
    {
        Task<IEnumerable<uspSelectProductDamage>> GetProductDamageAsync(DateTime StockDamageDateFrom, DateTime StockDamageDateTo, int ProductID, int UserID, int CompanyLocationID);
        Task<IEnumerable<uspSelectProductForStockDamage>> GetProductForStockDamageAsync(string ProductCodeName, int ProductID, int ProductCategoryID, int CompanyLocationID);
    }
}
