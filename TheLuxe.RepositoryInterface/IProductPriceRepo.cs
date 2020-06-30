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
        //Task AddProductPriceChangeAsync(int ProductID, int PackageID, decimal CostPrice, double QtyInPackage, decimal SellingPriceWithoutTAX,
        //    decimal VAT, decimal NHIL, decimal TL, decimal SellingPriceWithTAX, bool ExemptVAT, bool ExemptNHIL, bool ExemptTL, int UserID,
        //    bool? ShowInMenuList);
        tblProductPrice GetProductPrice(int ProductPriceId);
        bool Save();
        void Commit();
    }
}