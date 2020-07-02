using System.Collections.Generic;
using System.Threading.Tasks;
using TheLuxe.Entity;
using TheLuxe.Model.SupplierContactPerson;

namespace TheLuxe.RepositoryInterface
{
    public interface ISupplierContactPersonRepo
    {
        Task DeleteSupplierContactPersonAsync(tblSupplierContactPerson entity);
        tblSupplierContactPerson GetSupplierSupplierContactPerson(int SupplierContactPersonId);
        bool Save();
        void Commit();
        Task AddSupplierContactPersoAsync(int TitleID, int PositionID, string ContactPersonName,
            string MobilePhoneNo, string HomePhoneNo, string OfficePhoneNo, string Address, int SupplierID);
        Task<IEnumerable<uspSelectSupplierContactPerson>> GetSupplierContactPersonAsync(int SupplierContactPersonID, int SupplierID);
        Task UpdateSupplierContactPersoAsync(int SupplierContactPersonID, int TitleID, int PositionID, 
            string ContactPersonName, string MobilePhoneNo, string HomePhoneNo, string OfficePhoneNo, string Address, int SupplierID);
    }
}