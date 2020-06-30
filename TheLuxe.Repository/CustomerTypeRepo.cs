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
using TheLuxe.Model.CustomerType;
using TheLuxe.RepositoryInterface;

namespace TheLuxe.Repository
{
    public class CustomerTypeRepo : ICustomerTypeRepo
    {
        private TheLuxeClubContext _context;

        public CustomerTypeRepo(TheLuxeClubContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddCustomerTypeAsync(string CustomerTypeName, double Discount, string Description)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspInsertCustomerType";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@CustomerTypeName", CustomerTypeName));
                cmdObj.Parameters.Add(new SqlParameter("@Discount", Discount));
                cmdObj.Parameters.Add(new SqlParameter("@Description", Description));

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task DeleteCustomerTypeAsync(tblCustomerType entity)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspDeleteCustomerType";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@CustomerTypeID", entity.CustomerTypeID));

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public tblCustomerType GetCustomerType(int CustomerTypeId)
        {
            return _context.tblCustomerType.FirstOrDefault(c => c.CustomerTypeID == CustomerTypeId);
        }

        public async Task<IEnumerable<uspSelectCustomerType>> GetCustomerTypeAsync()
        {
            List<uspSelectCustomerType> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspSelectCustomerType";
                cmdObj.CommandType = CommandType.StoredProcedure;

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<uspSelectCustomerType>();
                }
            }
            return lst;
        }

        public async Task<IEnumerable<uspSelectCustomerTypeForDropDown>> GetCustomerTypeForDropDownAsync()
        {
            List<uspSelectCustomerTypeForDropDown> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspSelectCustomerTypeForDropDown";
                cmdObj.CommandType = CommandType.StoredProcedure;

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<uspSelectCustomerTypeForDropDown>();
                }
            }
            return lst;
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public async Task UpdateCustomerTypeAsync(int CustomerTypeId, string CustomerTypeName, string Description)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspUpdateCustomerType";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@CustomerTypeID", CustomerTypeId));
                cmdObj.Parameters.Add(new SqlParameter("@CustomerTypeName", CustomerTypeName));                
                cmdObj.Parameters.Add(new SqlParameter("@Description", Description));

                await cmdObj.ExecuteScalarAsync();
            }
        }
    }
}
