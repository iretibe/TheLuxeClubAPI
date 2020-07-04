namespace TheLuxe.Model.ProductPrice
{
    public class uspSelectAvailableProductWithPriceForCashier
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int PackageID { get; set; }
        public decimal CostPrice { get; set; }
        public double QtyInPackage { get; set; }
        public decimal SellingPriceWithoutTAX { get; set; }
        public decimal VAT { get; set; }
        public decimal NHIL { get; set; }
        public decimal TL { get; set; }
        public decimal SellingPriceWithTAX { get; set; }
        public string PackageName { get; set; }
        public int ProductCategoryLocationID { get; set; }
        public bool DoesItHaveStock { get; set; }
        public string PrinterName { get; set; }
        public bool AllowProtocol { get; set; }
        public decimal StockLevel { get; set; }
    }
}
