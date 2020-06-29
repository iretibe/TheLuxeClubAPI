using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TheLuxe.RepositoryInterface
{
    public interface IOrderDetailRepo
    {
        Task CheckIfProductExistsInOrderAsync(int ProductID, int OrderID, int SellingUnitID);
        Task CheckProductInOrderAsync(int OrderID, int ProductID, int SellingUnitID, double Qty);
    }
}
