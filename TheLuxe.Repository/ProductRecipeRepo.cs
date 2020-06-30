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
    public class ProductRecipeRepo : IProductRecipeRepo
    {
        private TheLuxeClubContext _context;

        public ProductRecipeRepo(TheLuxeClubContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Commit()
        {
            throw new NotImplementedException();
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

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
