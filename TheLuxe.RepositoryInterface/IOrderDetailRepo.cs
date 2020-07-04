using System.Threading.Tasks;

namespace TheLuxe.RepositoryInterface
{
    public interface IOrderDetailRepo
    {
        Task CheckIfProductExistsInOrderAsync(int ProductID, int OrderID, int SellingUnitID);
        Task CheckProductInOrderAsync(int OrderID, int ProductID, int SellingUnitID, double Qty);
        Task GetReturnOrderDetailProductWithNoStockAsync(int OrderDetailID);  //[uspReturnOrderDetailProductWithNoStock]
        Task GetReturnOrderDetailProductWithStockAsync(int OrderDetailID, int CompanyLocationID);  //[[uspReturnOrderDetailProductWithStock]]
        Task GetReturnOrderProductWithNoStockAsync(int OrderID, int CompanyLocationID);  //[uspReturnOrderProductWithNoStock]
        Task GetReturnOrderProductWithStockAsync(int OrderID, int CompanyLocationID);  //[uspReturnOrderProductWithStock]
    }
}
