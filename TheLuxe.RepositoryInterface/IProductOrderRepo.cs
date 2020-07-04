using System.Collections.Generic;
using System.Threading.Tasks;
using TheLuxe.Model.ProductOrder;

namespace TheLuxe.RepositoryInterface
{
    public interface IProductOrderRepo
    {
        Task<IEnumerable<uspSelectProductOrderWithShift>> GetProductOrderWithShiftAsync(int FromShiftID, int ToShiftID, int ProductID, int UserID,
            int ProductCategoryID, int OrderStatusID, int CustomerID, int ProductCategoryLocationID, int CategoryGroupID, int CompanyLocationID);
    }
}
