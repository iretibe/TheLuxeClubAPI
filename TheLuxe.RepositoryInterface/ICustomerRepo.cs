using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheLuxe.Entity;
using TheLuxe.Model.Customer;

namespace TheLuxe.RepositoryInterface
{
    public interface ICustomerRepo
    {
        Task CheckIfIsOwnerAsync(int CustomerID);
        Task CheckIfItIsCreditCustomerAsync(int CustomerID);
        Task CheckIfProtocolSetupIsAppliedAsync(int CustomerID);
        Task DeleteCustomerAsync(tblCustomer entity);
        tblCustomer GetCustomer(int CustomerId);
        bool Save();
        void Commit();
        Task AddCustomerAsync(DateTime RegistrationDate, string CustomerName, string PhoneNo, string FaxNo, string EMailAddress,
            string WebSite, string Address, bool? IsActive, decimal Debit, decimal Credit, decimal CreditLimit, bool? ApplyProtocolSetup,
            int ProtocolTypeID, decimal Amount, int CustomerTypeID);
        Task AddMobileInsertCustomerAsync(string CustomerName, string PhoneNo, string EMailAddress, string Address, string Note);
        Task<IEnumerable<uspSelectCustomerForCashier>> GetCustomerForCashierAsync(int CustomerID);
        Task<IEnumerable<uspSelectCustomerDiscount>> GetCustomerDiscountAsync(string CustomerName);
        Task<IEnumerable<uspSelectCustomer>> GetCustomerAsync(string CustomerName, int CustomerID);
        Task<IEnumerable<uspSelectCreditCustomer>> GetCreditCustomerAsync(string CustomerName, int CustomerID);
        Task TruncateCustomerAsync();
        Task UpdateCustomerAsync(int CustomerID, DateTime RegistrationDate, string CustomerName, string PhoneNo, string FaxNo, 
            string EMailAddress, string WebSite, string Address, bool? IsActive, decimal Debit, decimal Credit, decimal CreditLimit, 
            bool? ApplyProtocolSetup, int ProtocolTypeID, decimal Amount, int CustomerTypeID);
    }
}