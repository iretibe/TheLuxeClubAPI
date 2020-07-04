namespace TheLuxe.Model.ProductPurchase
{
    public class uspSelectProductPurchase
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double QtyPurchased { get; set; }
        public string BaseUnit { get; set; }
        public string TotalQtyPurchased { get; set; }
        public decimal TotalAmount { get; set; }
        public int CompanyLocationID { get; set; }
        public string CompanyLocationName { get; set; }
    }
}
