using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheLuxe.Entity;
using TheLuxe.Model.Product;

namespace TheLuxe.RepositoryInterface
{
    public interface IProductRepo
    {
        Task CheckProductBarCodeAsync(int ProductID, string BarCode);
        Task CheckProductWithNoStockRecipeStockLevelAsync(int ProductID, double Qty, int CompanyLocationID);
        Task DeleteProductAsync(tblProduct entity);
        Task AddProductAsync(string ProductCode, string BarCode, string ProductName, bool? IsActive, double StockLevel,
            int BaseUnitID, double ReOrderLevel, int ProductCategoryID, int UserID, bool? DoesItHaveStock, bool? AllowProtocol,
            decimal? SellingPrice, decimal? CostPrice, int CompanyLocationID);
        tblProduct GetProduct(int ProductId);
        bool Save();
        void Commit();
        Task<IEnumerable<uspSelectAvailableProduct>> GetAvailableProductAsync(string ProductCodeName, int ProductID, int ProductCategoryID);
        Task GetAvailableProductByBarCodeAsync(string BarCode, int ProductID, int ProductCategoryID); 
        Task<IEnumerable<uspSelectProductDropDown>> GetProductDropDownAsync();
        Task<IEnumerable<uspSelectProductDropDownForStockPurchase>> GetProductDropDownForStockPurchaseAsync();
        Task GetProductInStockAsync(string ProductCodeName);
        Task<IEnumerable<uspSelectProductPicture>> GetProductPictureAsync(int ProductID);
        Task<IEnumerable<uspSelectProductPriceNew>> GetProductPriceNewAsync(int? ProductCategoryID);
        Task<IEnumerable<uspSelectProductWithNoStockForRecipe>> GetProductWithNoStockForRecipeAsync(string ProductCodeName, int? ProductID, int? ProductCategoryID);
        Task TruncateProduct();
        Task UpdateProductAsync(int ProductID, string ProductCode, string BarCode, string ProductName, bool? IsActive,
            int BaseUnitID, int ProductCategoryID, int UserID, bool? DoesItHaveStock, bool? AllowProtocol, decimal NoOfPortion);
        Task UpdateProductFromInventoryAsync(int ProductID, string ProductCode, string BarCode, string ProductName, string Description,
            int StatusID, int BaseUnitID, DateTime ExpiryDate, int ProductCategoryID, int UserID, bool? DoesItHaveStock);
        Task UpdateProductPictureAsync(int ProductID, byte[] ProductPicture);
        Task UpdateProductWithPriceAsync(int ProductID, string ProductCode, string BarCode, string ProductName, bool? IsActive,
            int BaseUnitID, int ProductCategoryID, int UserID, bool? DoesItHaveStock, bool? AllowProtocol, decimal SellingPrice,
            decimal CostPrice, int CompanyLocationID, int ProductPriceID);
    }    
}
