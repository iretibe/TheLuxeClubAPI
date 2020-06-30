using System.Collections.Generic;
using System.Threading.Tasks;
using TheLuxe.Model.CustomerAccount;

namespace TheLuxe.RepositoryInterface
{
    public interface ICustomerAccountRepo
    {
        Task<IEnumerable<uspSelectCustomerAccount>> GetCustomerAccountAsync();
    }
}
