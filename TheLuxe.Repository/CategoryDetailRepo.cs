using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using TheLuxe.Data;
using TheLuxe.Helper;
using TheLuxe.Model.ProductCategoryDetail;
using TheLuxe.RepositoryInterface;

namespace TheLuxe.Repository
{
    public class CategoryDetailRepo : ICategoryDetailRepo
    {
        private TheLuxeClubContext _context;

        public CategoryDetailRepo(TheLuxeClubContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddProductCategoryDetailsAsync(int ProductCategoryID, int CompanyLocationID)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspInsertProductCategoryDetail";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductCategoryID", ProductCategoryID));
                cmdObj.Parameters.Add(new SqlParameter("@CompanyLocationID", CompanyLocationID));

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public async Task<IEnumerable<uspSelectProductCategoryDetail>> GetProductCategoryDetailAsync(int ProductCategoryID)
        {
            List<uspSelectProductCategoryDetail> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspSelectProductCategoryDetail";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductCategoryID", ProductCategoryID));

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<uspSelectProductCategoryDetail>();
                }
            }
            return lst;
        }

        public async Task UpdateProductCategoryDetailsAsync(int ProductCategoryDetailID, bool? ShowInMenu, int ProductCategoryLocationID)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspUpdateProductCategoryDetail";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductCategoryDetailID", ProductCategoryDetailID));
                cmdObj.Parameters.Add(new SqlParameter("@ShowInMenu", ShowInMenu));
                cmdObj.Parameters.Add(new SqlParameter("@ProductCategoryLocationID", ProductCategoryLocationID));

                await cmdObj.ExecuteScalarAsync();
            }
        }
    }
}
