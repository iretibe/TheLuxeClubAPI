using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheLuxe.Entity;
using TheLuxe.Model.Supplier;

namespace TheLuxe.RepositoryInterface
{
    public interface ISupplierRepo
    {
        Task DeleteSupplierAsync(tblSupplier entity);
        tblSupplier GetSupplier(int SupplierId);
        bool Save();
        void Commit();
        Task AddSupplierAsync(DateTime RegistrationDate, string SupplierName, string PhoneNo, 
            string FaxNo, string EMailAddress, string WebSite, string Address, bool? IsActive, decimal Debit, decimal Credit);
        Task<IEnumerable<uspSelectSupplier>> GetSupplierAsync(string SupplierName);
        Task TruncateSupplierAsync();
        Task UpdateSupplierAsync(int SupplierID, DateTime RegistrationDate, string SupplierName, string PhoneNo,
            string FaxNo, string EMailAddress, string WebSite, string Address, bool? IsActive, decimal Debit, decimal Credit);
    }
}