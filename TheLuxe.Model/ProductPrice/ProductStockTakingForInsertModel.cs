namespace TheLuxe.Model.ProductPrice
{
    public class ProductStockTakingForInsertModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int BaseUnitID { get; set; }
        public decimal StockLevel { get; set; }
        public decimal NewStockLevel { get; set; }
        public int UserID { get; set; }
    }
}
