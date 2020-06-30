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
using TheLuxe.Model.CustomerContactPerson;
using TheLuxe.RepositoryInterface;

namespace TheLuxe.Repository
{
    public class CustomerContactPersonRepo : ICustomerContactPersonRepo
    {
        private TheLuxeClubContext _context;

        public CustomerContactPersonRepo(TheLuxeClubContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddCustomerContactPersonAsync(int TitleID, int PositionID, string ContactPersonName, 
            string MobilePhoneNo, string HomePhoneNo, string OfficePhoneNo, string Address, int CustomerID)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspInsertCustomerContactPerson";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@TitleID", TitleID));
                cmdObj.Parameters.Add(new SqlParameter("@PositionID", PositionID));
                cmdObj.Parameters.Add(new SqlParameter("@ContactPersonName", ContactPersonName));
                cmdObj.Parameters.Add(new SqlParameter("@MobilePhoneNo", MobilePhoneNo));
                cmdObj.Parameters.Add(new SqlParameter("@HomePhoneNo", HomePhoneNo));
                cmdObj.Parameters.Add(new SqlParameter("@OfficePhoneNo", OfficePhoneNo));
                cmdObj.Parameters.Add(new SqlParameter("@Address", Address));
                cmdObj.Parameters.Add(new SqlParameter("@CustomerID", CustomerID));

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task DeleteCustomerContactPersonAsync(tblCustomerContactPerson entity)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspDeleteCustomerContactPerson";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@CustomerContactPersonID", entity.CustomerContactPersonID));

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public tblCustomerContactPerson GetCustomerContactPerson(int CustomerContactPersonId)
        {
            return _context.tblCustomerContactPerson.FirstOrDefault(c => c.CustomerContactPersonID == CustomerContactPersonId);
        }

        public async Task<IEnumerable<uspSelectCustomerContactPerson>> GetCustomerContactPersonAsync(int CustomerID)
        {
            List<uspSelectCustomerContactPerson> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspSelectCustomerContactPerson";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@CustomerID", CustomerID));

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<uspSelectCustomerContactPerson>();
                }
            }
            return lst;
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public async Task UpdateCustomerContactPersonAsync(int CustomerContactPersonId, int TitleID, int PositionID, 
            string ContactPersonName, string MobilePhoneNo, string HomePhoneNo, string OfficePhoneNo, string Address, int CustomerID)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspUpdateCustomerContactPerson";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@CustomerContactPersonID", CustomerContactPersonId));
                cmdObj.Parameters.Add(new SqlParameter("@TitleID", TitleID));
                cmdObj.Parameters.Add(new SqlParameter("@PositionID", PositionID));
                cmdObj.Parameters.Add(new SqlParameter("@ContactPersonName", ContactPersonName));
                cmdObj.Parameters.Add(new SqlParameter("@MobilePhoneNo", MobilePhoneNo));
                cmdObj.Parameters.Add(new SqlParameter("@HomePhoneNo", HomePhoneNo));
                cmdObj.Parameters.Add(new SqlParameter("@OfficePhoneNo", OfficePhoneNo));
                cmdObj.Parameters.Add(new SqlParameter("@Address", Address));
                cmdObj.Parameters.Add(new SqlParameter("@CustomerID", CustomerID));

                await cmdObj.ExecuteScalarAsync();
            }
        }
    }
}
