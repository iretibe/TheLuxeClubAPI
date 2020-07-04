namespace TheLuxe.Model.ProductStock
{
    public class uspSelectProductStockTaking
    {
        public int ProductID { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public int BaseUnitID { get; set; }
        public string PackageName { get; set; }
        public double StockLevel { get; set; }
        public double NewStockLevel { get; set; }
    }
}
