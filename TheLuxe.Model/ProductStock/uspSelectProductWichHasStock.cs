namespace TheLuxe.Model.ProductStock
{
    public class uspSelectProductWichHasStock
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public bool DoesItHaveStock { get; set; }
        public double StockLevel { get; set; }
        public double InitialStock { get; set; }
        public int BaseUnitID { get; set; }
        public double ReOrderLevel { get; set; }
        public int ProductCategoryID { get; set; }
    }
}
