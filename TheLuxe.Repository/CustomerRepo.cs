using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using TheLuxe.Data;
using TheLuxe.Entity;
using TheLuxe.Helper;
using TheLuxe.Model.Customer;
using TheLuxe.RepositoryInterface;

namespace TheLuxe.Repository
{
    public class CustomerRepo : ICustomerRepo
    {
        private TheLuxeClubContext _context;

        public CustomerRepo(TheLuxeClubContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddCustomerAsync(DateTime RegistrationDate, string CustomerName, string PhoneNo, string FaxNo, 
            string EMailAddress, string WebSite, string Address, bool? IsActive, decimal Debit, decimal Credit, decimal CreditLimit, 
            bool? ApplyProtocolSetup, int ProtocolTypeID, decimal Amount, int CustomerTypeID)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspInsertCustomer";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@RegistrationDate", RegistrationDate));
                cmdObj.Parameters.Add(new SqlParameter("@CustomerName", CustomerName));
                cmdObj.Parameters.Add(new SqlParameter("@PhoneNo", PhoneNo));
                cmdObj.Parameters.Add(new SqlParameter("@FaxNo", FaxNo));
                cmdObj.Parameters.Add(new SqlParameter("@EMailAddress", EMailAddress));
                cmdObj.Parameters.Add(new SqlParameter("@WebSite", WebSite));
                cmdObj.Parameters.Add(new SqlParameter("@Address", Address));
                cmdObj.Parameters.Add(new SqlParameter("@IsActive", IsActive));
                cmdObj.Parameters.Add(new SqlParameter("@Debit", Debit));
                cmdObj.Parameters.Add(new SqlParameter("@Credit", Credit));
                cmdObj.Parameters.Add(new SqlParameter("@CreditLimit", CreditLimit));
                cmdObj.Parameters.Add(new SqlParameter("@ApplyProtocolSetup", ApplyProtocolSetup));
                cmdObj.Parameters.Add(new SqlParameter("@ProtocolTypeID", ProtocolTypeID));
                cmdObj.Parameters.Add(new SqlParameter("@Amount", Amount));
                cmdObj.Parameters.Add(new SqlParameter("@CustomerTypeID", CustomerTypeID));

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public async Task AddMobileInsertCustomerAsync(string CustomerName, string PhoneNo, string EMailAddress, string Address, string Note)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspMobileInsertCustomer";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@CustomerName", CustomerName));
                cmdObj.Parameters.Add(new SqlParameter("@PhoneNo", PhoneNo));
                cmdObj.Parameters.Add(new SqlParameter("@EMailAddress", EMailAddress));
                cmdObj.Parameters.Add(new SqlParameter("@Address", Address));
                cmdObj.Parameters.Add(new SqlParameter("@Note", Note));

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public Task CheckIfIsOwnerAsync(int CustomerID)
        {
            throw new NotImplementedException();
        }

        public Task CheckIfItIsCreditCustomerAsync(int CustomerID)
        {
            throw new NotImplementedException();
        }

        public Task CheckIfProtocolSetupIsAppliedAsync(int CustomerID)
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task DeleteCustomerAsync(tblCustomer entity)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspDeleteCustomer";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@CustomerID", entity.CustomerID));

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public async Task<IEnumerable<uspSelectCreditCustomer>> GetCreditCustomerAsync(string CustomerName, int CustomerID)
        {
            List<uspSelectCreditCustomer> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspSelectCreditCustomer";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@CustomerName", CustomerName));
                cmdObj.Parameters.Add(new SqlParameter("@CustomerID", CustomerID));

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<uspSelectCreditCustomer>();
                }
            }
            return lst;
        }

        public tblCustomer GetCustomer(int CustomerId)
        {
            return _context.tblCustomer.FirstOrDefault(c => c.CustomerID == CustomerId);
        }

        public async Task<IEnumerable<uspSelectCustomer>> GetCustomerAsync(string CustomerName, int CustomerID)
        {
            List<uspSelectCustomer> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspSelectCustomer";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@CustomerName", CustomerName));
                cmdObj.Parameters.Add(new SqlParameter("@CustomerID", CustomerID));

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<uspSelectCustomer>();
                }
            }
            return lst;
        }

        public async Task<IEnumerable<uspSelectCustomerDiscount>> GetCustomerDiscountAsync(string CustomerName)
        {
            List<uspSelectCustomerDiscount> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspSelectCustomerDiscount";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@CustomerName", CustomerName));

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<uspSelectCustomerDiscount>();
                }
            }
            return lst;
        }

        public async Task<IEnumerable<uspSelectCustomerForCashier>> GetCustomerForCashierAsync(int CustomerID)
        {
            List<uspSelectCustomerForCashier> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspSelectCustomerForCashier";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@CustomerID", CustomerID));

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<uspSelectCustomerForCashier>();
                }
            }
            return lst;
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public async Task TruncateCustomerAsync()
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspTruncateCustomer";
                cmdObj.CommandType = CommandType.StoredProcedure;

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public async Task UpdateCustomerAsync(int CustomerID, DateTime RegistrationDate, string CustomerName, 
            string PhoneNo, string FaxNo, string EMailAddress, string WebSite, string Address, bool? IsActive, 
            decimal Debit, decimal Credit, decimal CreditLimit, bool? ApplyProtocolSetup, int ProtocolTypeID, 
            decimal Amount, int CustomerTypeID)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspUpdateCustomer";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@CustomerID", CustomerID));
                cmdObj.Parameters.Add(new SqlParameter("@RegistrationDate", RegistrationDate));
                cmdObj.Parameters.Add(new SqlParameter("@CustomerName", CustomerName));
                cmdObj.Parameters.Add(new SqlParameter("@PhoneNo", PhoneNo));
                cmdObj.Parameters.Add(new SqlParameter("@FaxNo", FaxNo));
                cmdObj.Parameters.Add(new SqlParameter("@EMailAddress", EMailAddress));
                cmdObj.Parameters.Add(new SqlParameter("@WebSite", WebSite));
                cmdObj.Parameters.Add(new SqlParameter("@Address", Address));
                cmdObj.Parameters.Add(new SqlParameter("@IsActive", IsActive));
                cmdObj.Parameters.Add(new SqlParameter("@Debit", Debit));
                cmdObj.Parameters.Add(new SqlParameter("@Credit", Credit));
                cmdObj.Parameters.Add(new SqlParameter("@CreditLimit", CreditLimit));
                cmdObj.Parameters.Add(new SqlParameter("@ApplyProtocolSetup", ApplyProtocolSetup));
                cmdObj.Parameters.Add(new SqlParameter("@ProtocolTypeID", ProtocolTypeID));
                cmdObj.Parameters.Add(new SqlParameter("@Amount", Amount));
                cmdObj.Parameters.Add(new SqlParameter("@CustomerTypeID", CustomerTypeID));

                await cmdObj.ExecuteScalarAsync();
            }
        }
    }
}
