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
using TheLuxe.Model.Supplier;
using TheLuxe.RepositoryInterface;

namespace TheLuxe.Repository
{
    public class SupplierRepo : ISupplierRepo
    {
        private TheLuxeClubContext _context;

        public SupplierRepo(TheLuxeClubContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddSupplierAsync(DateTime RegistrationDate, string SupplierName, string PhoneNo, 
            string FaxNo, string EMailAddress, string WebSite, string Address, bool? IsActive, decimal Debit, decimal Credit)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspInsertSupplier";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@RegistrationDate", RegistrationDate));
                cmdObj.Parameters.Add(new SqlParameter("@SupplierName", SupplierName));
                cmdObj.Parameters.Add(new SqlParameter("@PhoneNo", PhoneNo));
                cmdObj.Parameters.Add(new SqlParameter("@FaxNo", FaxNo));
                cmdObj.Parameters.Add(new SqlParameter("@EMailAddress", EMailAddress));
                cmdObj.Parameters.Add(new SqlParameter("@WebSite", WebSite));
                cmdObj.Parameters.Add(new SqlParameter("@Address", Address));
                cmdObj.Parameters.Add(new SqlParameter("@IsActive", IsActive));
                cmdObj.Parameters.Add(new SqlParameter("@Debit", Debit));
                cmdObj.Parameters.Add(new SqlParameter("@Credit", Credit));

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task DeleteSupplierAsync(tblSupplier entity)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspDeleteSupplier";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@SupplierID", entity.SupplierID));

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public tblSupplier GetSupplier(int SupplierId)
        {
            return _context.tblSupplier.FirstOrDefault(c => c.SupplierID == SupplierId);
        }

        public async Task<IEnumerable<uspSelectSupplier>> GetSupplierAsync(string SupplierName)
        {
            List<uspSelectSupplier> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspSelectSupplier";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@SupplierName", SupplierName));

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<uspSelectSupplier>();
                }
            }
            return lst;
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public async Task TruncateSupplierAsync()
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspTruncateSupplier";
                cmdObj.CommandType = CommandType.StoredProcedure;

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public async Task UpdateSupplierAsync(int SupplierID, DateTime RegistrationDate, string SupplierName, 
            string PhoneNo, string FaxNo, string EMailAddress, string WebSite, string Address, bool? IsActive, decimal Debit, decimal Credit)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspUpdateSupplier";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@SupplierID", SupplierID));
                cmdObj.Parameters.Add(new SqlParameter("@RegistrationDate", RegistrationDate));
                cmdObj.Parameters.Add(new SqlParameter("@SupplierName", SupplierName));
                cmdObj.Parameters.Add(new SqlParameter("@PhoneNo", PhoneNo));
                cmdObj.Parameters.Add(new SqlParameter("@FaxNo", FaxNo));
                cmdObj.Parameters.Add(new SqlParameter("@EMailAddress", EMailAddress));
                cmdObj.Parameters.Add(new SqlParameter("@WebSite", WebSite));
                cmdObj.Parameters.Add(new SqlParameter("@Address", Address));
                cmdObj.Parameters.Add(new SqlParameter("@IsActive", IsActive));
                cmdObj.Parameters.Add(new SqlParameter("@Debit", Debit));
                cmdObj.Parameters.Add(new SqlParameter("@Credit", Credit));

                await cmdObj.ExecuteScalarAsync();
            }
        }
    }
}
