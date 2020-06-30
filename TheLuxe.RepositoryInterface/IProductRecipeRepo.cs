using System.Threading.Tasks;
using TheLuxe.Entity;

namespace TheLuxe.RepositoryInterface
{
    public interface IProductRecipeRepo
    {
        Task DeductProductRecipeAsync(int OrderDetailID, int ProductID, double Qty, int ShiftID, int CompanyLocationID);
        Task DeleteProductRecipeAsync(tblProductRecipe entity);

        tblProductRecipe GetProductRecipe(int ProductRecipeId);
        bool Save();
        void Commit();
    }
}
