namespace TheLuxe.Model.ProductStock
{
    public class ProductStockForInsertModel
    {
        public int ProductID { get; set; }
        public double StockLevel { get; set; }
        public double ReOrderLevel { get; set; }
        public bool? NoStockUpdate { get; set; }
    }
}
