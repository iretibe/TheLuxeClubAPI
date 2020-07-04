using System.Collections.Generic;
using System.Threading.Tasks;
using TheLuxe.Entity;
using TheLuxe.Model.ProductPrice;

namespace TheLuxe.RepositoryInterface
{
    public interface IProductPriceRepo
    {
        Task<IEnumerable<uspSelectProductPriceByPackageID>> GetProductPriceByPackageIDAsync(int ProductID, int PackageID, int CompanyLocationID);
        Task DeleteProductPriceAsync(tblProductPrice entity);
        Task AddProductPriceAsync(int ProductID, int PackageID, decimal CostPrice, double QtyInPackage, decimal SellingPriceWithoutTAX,
            decimal VAT, decimal NHIL, decimal TL, decimal SellingPriceWithTAX, bool ExemptVAT, bool ExemptNHIL, bool ExemptTL, int UserID,
            bool? ShowInMenuList);
        Task AddProductPriceChangeAsync(int ProductID, int PackageID, decimal SellingPriceWithoutTAX, decimal NewSellingPrice, int UserID);
        Task AddProductPriceForNewlyCreatedCompanyLocationAsync(int CompanyLocationID);
        tblProductPrice GetProductPrice(int ProductPriceId);
        bool Save();
        void Commit();
        Task AddProductStockTakingAsync(int ProductID, string ProductName, int BaseUnitID, decimal StockLevel, decimal NewStockLevel, int UserID); //uspInsertProductStockTaking
        Task<IEnumerable<uspMobileSelectAvailableProductWithPriceForCashier>> GetMobileAvailableProductWithPriceForCashierAsync(int CompanyLocationID, int ProductCategoryID);
        Task<IEnumerable<uspSelectAvailableProductWithPriceForCashier>> GetAvailableProductWithPriceForCashierAsync(int CompanyLocationID, int ProductCategoryID);
        Task<IEnumerable<uspSelectProductPrice>> GetProductPriceAsync(int ProductID, int CompanyLocationID);
        Task GetProductPriceChangeAsync(int ProductCategoryID);
        Task<IEnumerable<uspSelectProductSellingUnit>> GetProductSellingUnitAsync(int ProductID, int CompanyLocationID);
        Task<IEnumerable<uspSelectSellingUnitByProductID>> GetSellingUnitByProductIDAsync(int ProductID);
        Task TruncateProductPrice();
        Task UpdateProductCostPriceAsync(int ProductID);
        Task UpdateProductPriceAsync(int ProductPriceID, int ProductID, int PackageID, decimal CostPrice, double QtyInPackage, 
            decimal SellingPriceWithoutTAX, decimal VAT, decimal NHIL, decimal TL, decimal SellingPriceWithTAX, bool ExemptVAT, 
            bool ExemptNHIL, bool ExemptTL, int UserID, bool? ShowInMenuList);
        Task UpdateProductPriceForNewProductAsync(int ProductPriceID, int ProductID, int PackageID, decimal CostPrice, double QtyInPackage,
            decimal SellingPriceWithoutTAX, decimal VAT, decimal NHIL, decimal TL, decimal SellingPriceWithTAX, bool ExemptVAT,
            bool ExemptNHIL, bool ExemptTL, int UserID, bool? ShowInMenuList);
        Task UpdateProductPriceFromInventoryAsync(int ProductPriceID, int ProductID, int PackageID, decimal CostPrice, double QtyInPackage,
            decimal SellingPriceWithoutTAX, decimal VAT, decimal NHIL, decimal SellingPriceWithTAX, bool ExemptVAT, bool ExemptNHIL, int UserID);
        Task UpdateProductPriceFromProductAsync(int ProductID, int PackageID, decimal CostPrice, decimal SellingPriceWithTAX,
           int UserID, int CompanyLocationID, int ProductPriceID);
    }
}