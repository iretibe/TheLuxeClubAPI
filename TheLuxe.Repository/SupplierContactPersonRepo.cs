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
using TheLuxe.Model.SupplierContactPerson;
using TheLuxe.RepositoryInterface;

namespace TheLuxe.Repository
{
    public class SupplierContactPersonRepo : ISupplierContactPersonRepo
    {
        private TheLuxeClubContext _context;

        public SupplierContactPersonRepo(TheLuxeClubContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddSupplierContactPersoAsync(int TitleID, int PositionID, string ContactPersonName, 
            string MobilePhoneNo, string HomePhoneNo, string OfficePhoneNo, string Address, int SupplierID)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspInsertSupplierContactPerson";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@TitleID", TitleID));
                cmdObj.Parameters.Add(new SqlParameter("@PositionID", PositionID));
                cmdObj.Parameters.Add(new SqlParameter("@ContactPersonName", ContactPersonName));
                cmdObj.Parameters.Add(new SqlParameter("@MobilePhoneNo", MobilePhoneNo));
                cmdObj.Parameters.Add(new SqlParameter("@HomePhoneNo", HomePhoneNo));
                cmdObj.Parameters.Add(new SqlParameter("@OfficePhoneNo", OfficePhoneNo));
                cmdObj.Parameters.Add(new SqlParameter("@Address", Address));
                cmdObj.Parameters.Add(new SqlParameter("@SupplierID", SupplierID));

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task DeleteSupplierContactPersonAsync(tblSupplierContactPerson entity)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspDeleteSupplierContactPerson";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@SupplierContactPersonID", entity.SupplierContactPersonID));

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public async Task<IEnumerable<uspSelectSupplierContactPerson>> GetSupplierContactPersonAsync(int SupplierContactPersonID, int SupplierID)
        {
            List<uspSelectSupplierContactPerson> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspSelectSupplierContactPerson";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@SupplierContactPersonID", SupplierContactPersonID));
                cmdObj.Parameters.Add(new SqlParameter("@SupplierID", SupplierID));

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<uspSelectSupplierContactPerson>();
                }
            }
            return lst;
        }

        public tblSupplierContactPerson GetSupplierSupplierContactPerson(int SupplierContactPersonId)
        {
            return _context.tblSupplierContactPerson.FirstOrDefault(c => c.SupplierContactPersonID == SupplierContactPersonId);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public async Task UpdateSupplierContactPersoAsync(int SupplierContactPersonID, int TitleID, int PositionID, 
            string ContactPersonName, string MobilePhoneNo, string HomePhoneNo, string OfficePhoneNo, string Address, int SupplierID)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspUpdateSupplierContactPerson";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@SupplierContactPersonID", SupplierContactPersonID));
                cmdObj.Parameters.Add(new SqlParameter("@TitleID", TitleID));
                cmdObj.Parameters.Add(new SqlParameter("@PositionID", PositionID));
                cmdObj.Parameters.Add(new SqlParameter("@ContactPersonName", ContactPersonName));
                cmdObj.Parameters.Add(new SqlParameter("@MobilePhoneNo", MobilePhoneNo));
                cmdObj.Parameters.Add(new SqlParameter("@HomePhoneNo", HomePhoneNo));
                cmdObj.Parameters.Add(new SqlParameter("@OfficePhoneNo", OfficePhoneNo));
                cmdObj.Parameters.Add(new SqlParameter("@Address", Address));
                cmdObj.Parameters.Add(new SqlParameter("@SupplierID", SupplierID));

                await cmdObj.ExecuteScalarAsync();
            }
        }
    }
}
