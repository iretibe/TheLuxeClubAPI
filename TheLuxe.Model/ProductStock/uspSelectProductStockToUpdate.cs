namespace TheLuxe.Model.ProductStock
{
    public class uspSelectProductStockToUpdate
    {
        public int ProductStockID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double InitialStock { get; set; }
        public double StockLevel { get; set; }
        public double ReOrderLevel { get; set; }
        public int CompanyLocationID { get; set; }
        public string CompanyLocationName { get; set; }
        public int ProductCategoryID { get; set; }
        public int BaseUnitID { get; set; }
        public string PackageName { get; set; }
        public string CategoryName { get; set; }
        public double ConvertedStockLevel { get; set; }
        public int HighestPackageID { get; set; }
        public string HighestPackageName { get; set; }
        public double QtyInPackage { get; set; }
    }
}
