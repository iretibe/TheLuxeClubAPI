using System.Collections.Generic;
using System.Threading.Tasks;
using TheLuxe.Entity;
using TheLuxe.Model.CustomerContactPerson;

namespace TheLuxe.RepositoryInterface
{
    public interface ICustomerContactPersonRepo
    {
        Task DeleteCustomerContactPersonAsync(tblCustomerContactPerson entity);
        tblCustomerContactPerson GetCustomerContactPerson(int CustomerContactPersonId);
        bool Save();
        void Commit();
        Task AddCustomerContactPersonAsync(int TitleID, int PositionID, string ContactPersonName, 
            string MobilePhoneNo, string HomePhoneNo, string OfficePhoneNo, string Address, int CustomerID);
        Task<IEnumerable<uspSelectCustomerContactPerson>> GetCustomerContactPersonAsync(int CustomerID);
        Task UpdateCustomerContactPersonAsync(int CustomerContactPersonId, int TitleID, int PositionID, 
            string ContactPersonName, string MobilePhoneNo, string HomePhoneNo, string OfficePhoneNo, string Address, 
            int CustomerID);
    }
}