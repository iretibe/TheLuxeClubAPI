using System.Collections.Generic;
using System.Threading.Tasks;
using TheLuxe.Entity;
using TheLuxe.Model.ProductRecipe;

namespace TheLuxe.RepositoryInterface
{
    public interface IProductRecipeRepo
    {
        Task DeductProductRecipeAsync(int OrderDetailID, int ProductID, double Qty, int ShiftID, int CompanyLocationID);
        Task DeleteProductRecipeAsync(tblProductRecipe entity);
        tblProductRecipe GetProductRecipe(int ProductRecipeId);
        bool Save();
        void Commit();
        Task AddProductRecipeAsync(int ProductID, int RecipeID, double Qty, int PackageID, decimal CostPrice);
        Task<IEnumerable<uspSelectProductRecipe>> GetProductRecipeAsync(int? ProductRecipeID, int? ProductID);
        Task<IEnumerable<uspSelectProductRecipeSelector>> GetProductRecipeSelectorAsync(int ProductID, int? ProductCategoryID);
        Task UpdateProductRecipeAsync(int ProductRecipeID, int ProductID, int RecipeID, double Qty, int PackageID, decimal CostPrice);
    }
}
