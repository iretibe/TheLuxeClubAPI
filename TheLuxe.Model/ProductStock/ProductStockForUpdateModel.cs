namespace TheLuxe.Model.ProductStock
{
    public class ProductStockForUpdateModel
    {
        public int ProductID { get; set; }
        public double StockLevel { get; set; }
        public double ReOrderLevel { get; set; }
        public int CompanyLocationID { get; set; }
        public int UserID { get; set; }
    }
}
