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
using TheLuxe.Model.ProductPrice;
using TheLuxe.RepositoryInterface;

namespace TheLuxe.Repository
{
    public class ProductPriceRepo : IProductPriceRepo
    {
        private TheLuxeClubContext _context;

        public ProductPriceRepo(TheLuxeClubContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddProductPriceAsync(int ProductID, int PackageID, decimal CostPrice, double QtyInPackage, 
            decimal SellingPriceWithoutTAX, decimal VAT, decimal NHIL, decimal TL, decimal SellingPriceWithTAX, 
            bool ExemptVAT, bool ExemptNHIL, bool ExemptTL, int UserID, bool? ShowInMenuList)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspInsertProductPrice";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductID", ProductID));
                cmdObj.Parameters.Add(new SqlParameter("@PackageID", PackageID));
                cmdObj.Parameters.Add(new SqlParameter("@CostPrice", CostPrice));
                cmdObj.Parameters.Add(new SqlParameter("@QtyInPackage", QtyInPackage));
                cmdObj.Parameters.Add(new SqlParameter("@SellingPriceWithoutTAX", SellingPriceWithoutTAX));
                cmdObj.Parameters.Add(new SqlParameter("@VAT", VAT));
                cmdObj.Parameters.Add(new SqlParameter("@NHIL", NHIL));
                cmdObj.Parameters.Add(new SqlParameter("@TL", TL));
                cmdObj.Parameters.Add(new SqlParameter("@SellingPriceWithTAX", SellingPriceWithTAX));
                cmdObj.Parameters.Add(new SqlParameter("@ExemptVAT", ExemptVAT));
                cmdObj.Parameters.Add(new SqlParameter("@ExemptNHIL", ExemptNHIL));
                cmdObj.Parameters.Add(new SqlParameter("@ExemptTL", ExemptTL));
                cmdObj.Parameters.Add(new SqlParameter("@UserID", UserID));
                cmdObj.Parameters.Add(new SqlParameter("@ShowInMenuList", ShowInMenuList));

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task DeleteProductPriceAsync(tblProductPrice entity)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspDeleteProductPrice";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductPriceID", entity.ProductPriceID));

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public tblProductPrice GetProductPrice(int ProductPriceId)
        {
            return _context.tblProductPrice.FirstOrDefault(c => c.ProductPriceID == ProductPriceId);
        }

        public async Task<IEnumerable<uspSelectProductPriceByPackageID>> GetProductPriceByPackageIDAsync(int ProductID, int PackageID, int CompanyLocationID)
        {
            List<uspSelectProductPriceByPackageID> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspSelectProductPriceByPackageID";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductID", ProductID));
                cmdObj.Parameters.Add(new SqlParameter("@PackageID", PackageID));
                cmdObj.Parameters.Add(new SqlParameter("@CompanyLocationID", CompanyLocationID));

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<uspSelectProductPriceByPackageID>();
                }
            }
            return lst;
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
