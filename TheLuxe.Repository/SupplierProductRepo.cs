using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using TheLuxe.Data;
using TheLuxe.Entity;
using TheLuxe.RepositoryInterface;

namespace TheLuxe.Repository
{
    public class SupplierProductRepo : ISupplierProductRepo
    {
        private TheLuxeClubContext _context;

        public SupplierProductRepo(TheLuxeClubContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task DeleteSupplierProductAsync(tblSupplierProduct entity)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspDeleteSupplierProduct";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@SupplierID", entity.SupplierID));

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public tblSupplierProduct GetSupplierProduct(int SupplierProductId)
        {
            return _context.tblSupplierProduct.FirstOrDefault(c => c.SupplierID == SupplierProductId);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
