namespace TheLuxe.Model.ProductPrice
{
    public class ProductPriceChangeForInsertModel
    {
        public int ProductID { get; set; }
        public int PackageID { get; set; }
        public decimal SellingPriceWithoutTAX { get; set; }
        public decimal NewSellingPrice { get; set; }
        public int UserID { get; set; }
    }
}
