namespace TheLuxe.Model.ProductPrice
{
    public class ProductPriceForNewProductForUpdateModel
    {
        public int ProductPriceID { get; set; }
        public int ProductID { get; set; }
        public int PackageID { get; set; }
        public decimal CostPrice { get; set; }
        public double QtyInPackage { get; set; }
        public decimal SellingPriceWithoutTAX { get; set; }
        public decimal VAT { get; set; }
        public decimal NHIL { get; set; }
        public decimal TL { get; set; }
        public decimal SellingPriceWithTAX { get; set; }
        public bool ExemptVAT { get; set; }
        public bool ExemptNHIL { get; set; }
        public bool ExemptTL { get; set; }
        public int UserID { get; set; }
        public bool? ShowInMenuList { get; set; }
    }
}
