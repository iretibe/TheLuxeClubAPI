namespace TheLuxe.Model.ShiftProductStockTaking
{
    public class uspSelectShiftProductStockTaking
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int PackageID { get; set; }
        public string PackageName { get; set; }
        public double StockLevelBefore { get; set; }
        public double QtyOut { get; set; }
        public double StockLevelAfterQtyOut { get; set; }
        public double StockLevelAfter { get; set; }
        public double StockVariance { get; set; }
        public int UserID { get; set; }
        public int ShiftID { get; set; }
        public int CompanyLocationID { get; set; }
    }
}
