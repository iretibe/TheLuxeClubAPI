using System.Collections.Generic;
using System.Threading.Tasks;
using TheLuxe.Model.Order;

namespace TheLuxe.RepositoryInterface
{
    public interface IOrderRepo
    {
        Task<IEnumerable<uspSelectCustomerOustandingBalance>> GetCustomerOustandingBalanceAsync(int CustomerID);
        Task<IEnumerable<uspSelectOrderByCustomer>> GetOrderByCustomerAsync(int CustomerID);
        Task<IEnumerable<uspSelectPendingOrderByCustomerID>> GetPendingOrderByCustomerIDAsync(int CustomerID);
    }
}
