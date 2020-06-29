using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TheLuxe.RepositoryInterface
{
    public interface IProductRepo
    {
        Task CheckProductBarCodeAsync(int ProductID, string BarCode);
        Task CheckProductWithNoStockRecipeStockLevelAsync(int ProductID, double Qty, int CompanyLocationID);
    }
}
