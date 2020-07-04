namespace TheLuxe.Model.ProductPrice
{
    public class ProductPriceFromProductForUpdateModel
    {
        public int ProductID { get; set; }
        public int PackageID { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SellingPriceWithTAX { get; set; }
        public int UserID { get; set; }
        public int CompanyLocationID { get; set; }
        public int ProductPriceID { get; set; }
    }
}
