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
using TheLuxe.Model.ProductRecipe;
using TheLuxe.RepositoryInterface;

namespace TheLuxe.Repository
{
    public class ProductRecipeRepo : IProductRecipeRepo
    {
        private TheLuxeClubContext _context;

        public ProductRecipeRepo(TheLuxeClubContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddProductRecipeAsync(int ProductID, int RecipeID, double Qty, int PackageID, decimal CostPrice)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspInsertProductRecipe";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductID", ProductID));
                cmdObj.Parameters.Add(new SqlParameter("@RecipeID", RecipeID));
                cmdObj.Parameters.Add(new SqlParameter("@Qty", Qty));
                cmdObj.Parameters.Add(new SqlParameter("@PackageID", PackageID));
                cmdObj.Parameters.Add(new SqlParameter("@CostPrice", CostPrice));

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task DeductProductRecipeAsync(int OrderDetailID, int ProductID, double Qty, int ShiftID, int CompanyLocationID)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspDeductProductRecipe";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@OrderDetailID", OrderDetailID));
                cmdObj.Parameters.Add(new SqlParameter("@ProductID", ProductID));
                cmdObj.Parameters.Add(new SqlParameter("@Qty", Qty));
                cmdObj.Parameters.Add(new SqlParameter("@ShiftID", ShiftID));
                cmdObj.Parameters.Add(new SqlParameter("@CompanyLocationID", CompanyLocationID));

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public async Task DeleteProductRecipeAsync(tblProductRecipe entity)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspDeleteProductRecipe";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductRecipeID", entity.ProductRecipeID));

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public tblProductRecipe GetProductRecipe(int ProductRecipeId)
        {
            return _context.tblProductRecipe.FirstOrDefault(c => c.ProductRecipeID == ProductRecipeId);
        }

        public async Task<IEnumerable<uspSelectProductRecipe>> GetProductRecipeAsync(int? ProductRecipeID, int? ProductID)
        {
            List<uspSelectProductRecipe> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspSelectProductRecipe";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductRecipeID", ProductRecipeID));
                cmdObj.Parameters.Add(new SqlParameter("@ProductID", ProductID));

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<uspSelectProductRecipe>();
                }
            }
            return lst;
        }

        public async Task<IEnumerable<uspSelectProductRecipeSelector>> GetProductRecipeSelectorAsync(int ProductID, int? ProductCategoryID)
        {
            List<uspSelectProductRecipeSelector> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspSelectProductRecipeSelector";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductID", ProductID));
                cmdObj.Parameters.Add(new SqlParameter("@ProductCategoryID", ProductCategoryID));

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<uspSelectProductRecipeSelector>();
                }
            }
            return lst;
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public async Task UpdateProductRecipeAsync(int ProductRecipeID, int ProductID, int RecipeID, double Qty, int PackageID, decimal CostPrice)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspUpdateProductRecipe";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductRecipeID", ProductRecipeID));
                cmdObj.Parameters.Add(new SqlParameter("@ProductID", ProductID));
                cmdObj.Parameters.Add(new SqlParameter("@RecipeID", RecipeID));
                cmdObj.Parameters.Add(new SqlParameter("@Qty", Qty));
                cmdObj.Parameters.Add(new SqlParameter("@PackageID", PackageID));
                cmdObj.Parameters.Add(new SqlParameter("@CostPrice", CostPrice));

                await cmdObj.ExecuteScalarAsync();
            }
        }
    }
}
