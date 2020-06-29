using System.Collections.Generic;
using System.Threading.Tasks;
using TheLuxe.Entity;
using TheLuxe.Model.ProductCategory;

namespace TheLuxe.RepositoryInterface
{
    public interface ICategoryRepo
    {
        Task DeleteProductCategoryAsync(tblProductCategory entity);        
        Task AddProductCategoryAsync(string CategoryName, int CategoryGroupID, bool SelectOption);   
        Task<IEnumerable<uspMobileSelectProductCategory>> GetMobileProductCategoryAsync();
        Task<IEnumerable<uspSelectCategory>> GetCategoryAsync(int? ProductCategoryID, string CategoryName, 
            int PageSize, int PageNumber, string SortBy, string SortOrder);        
        Task<IEnumerable<uspSelectProductCategory>> GetProductCategoryAsync(int ProductCategoryID);        
        Task<IEnumerable<uspSelectProductCategoryForMenu>> GetProductCategoryForMenuAsync(int ProductCategoryID, int CategoryGroupID, int CompanyLocationID);           
        Task UpdateProductCategoryAsync(int ProductCategoryID, string CategoryName, int CategoryGroupID, bool SelectOption);
        tblProductCategory GetProductCategory(int ProductCategoryId);
        bool Save();
        void Commit();
    }
}
