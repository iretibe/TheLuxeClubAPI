using System.Collections.Generic;
using System.Threading.Tasks;
using TheLuxe.Entity;
using TheLuxe.Model.CustomerType;

namespace TheLuxe.RepositoryInterface
{
    public interface ICustomerTypeRepo
    {
        Task DeleteCustomerTypeAsync(tblCustomerType entity);
        tblCustomerType GetCustomerType(int CustomerTypeId);
        bool Save();
        void Commit();
        Task AddCustomerTypeAsync(string CustomerTypeName, double Discount, string Description);
        Task<IEnumerable<uspSelectCustomerType>> GetCustomerTypeAsync();
        Task<IEnumerable<uspSelectCustomerTypeForDropDown>> GetCustomerTypeForDropDownAsync();
        Task UpdateCustomerTypeAsync(int CustomerTypeId, string CustomerTypeName, string Description);
    }
}
