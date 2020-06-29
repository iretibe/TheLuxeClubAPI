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
using TheLuxe.Model.ProductCategory;
using TheLuxe.RepositoryInterface;

namespace TheLuxe.Repository
{
    public class CategoryRepo : ICategoryRepo
    {
        private TheLuxeClubContext _context;

        public CategoryRepo(TheLuxeClubContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddProductCategoryAsync(string CategoryName, int CategoryGroupID, bool SelectOption)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspInsertProductCategory";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@CategoryName", CategoryName));
                cmdObj.Parameters.Add(new SqlParameter("@CategoryGroupID", CategoryGroupID));
                cmdObj.Parameters.Add(new SqlParameter("@SelectOption", SelectOption));

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task DeleteProductCategoryAsync(tblProductCategory entity)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspDeleteProductCategory";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductCategoryID", entity.ProductCategoryID));

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public async Task<IEnumerable<uspSelectCategory>> GetCategoryAsync(int? ProductCategoryID, string CategoryName, int PageSize, int PageNumber, string SortBy, string SortOrder)
        {
            List<uspSelectCategory> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspSelectCategory";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductCategoryID", ProductCategoryID));
                cmdObj.Parameters.Add(new SqlParameter("@CategoryName", CategoryName));
                cmdObj.Parameters.Add(new SqlParameter("@PageSize", PageSize));
                cmdObj.Parameters.Add(new SqlParameter("@PageNumber", PageNumber));
                cmdObj.Parameters.Add(new SqlParameter("@SortBy", SortBy));
                cmdObj.Parameters.Add(new SqlParameter("@SortOrder", SortOrder));

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<uspSelectCategory>();
                }
            }
            return lst;
        }

        public async Task<IEnumerable<uspMobileSelectProductCategory>> GetMobileProductCategoryAsync()
        {
            List<uspMobileSelectProductCategory> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspMobileSelectProductCategory";
                cmdObj.CommandType = CommandType.StoredProcedure;

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<uspMobileSelectProductCategory>();
                }
            }
            return lst;
        }

        public tblProductCategory GetProductCategory(int ProductCategoryId)
        {
            return _context.tblProductCategory.FirstOrDefault(c => c.ProductCategoryID == ProductCategoryId);
        }

        public async Task<IEnumerable<uspSelectProductCategory>> GetProductCategoryAsync(int ProductCategoryID)
        {
            List<uspSelectProductCategory> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspSelectProductCategory";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductCategoryID", ProductCategoryID));

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<uspSelectProductCategory>();
                }
            }
            return lst;
        }

        public async Task<IEnumerable<uspSelectProductCategoryForMenu>> GetProductCategoryForMenuAsync(int ProductCategoryID, int CategoryGroupID, int CompanyLocationID)
        {
            List<uspSelectProductCategoryForMenu> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspSelectProductCategoryForMenu";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductCategoryID", ProductCategoryID));
                cmdObj.Parameters.Add(new SqlParameter("@CategoryGroupID", CategoryGroupID));
                cmdObj.Parameters.Add(new SqlParameter("@CompanyLocationID", CompanyLocationID));

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<uspSelectProductCategoryForMenu>();
                }
            }
            return lst;
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public async Task UpdateProductCategoryAsync(int ProductCategoryID, string CategoryName, int CategoryGroupID, bool SelectOption)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspUpdateProductCategory";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductCategoryID", ProductCategoryID));
                cmdObj.Parameters.Add(new SqlParameter("@CategoryName", CategoryName));
                cmdObj.Parameters.Add(new SqlParameter("@CategoryGroupID", CategoryGroupID));
                cmdObj.Parameters.Add(new SqlParameter("@SelectOption", SelectOption));

                await cmdObj.ExecuteScalarAsync();
            }
        }
    }
}
