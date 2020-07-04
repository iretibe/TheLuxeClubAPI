namespace TheLuxe.Model.Product
{
    public class ProductForInsertModel
    {
        public string ProductCode { get; set; }
        public string BarCode { get; set; }
        public string ProductName { get; set; }
        public bool? IsActive { get; set; }
        public double StockLevel { get; set; }
        public int BaseUnitID { get; set; }
        public double ReOrderLevel { get; set; }
        public int ProductCategoryID { get; set; }
        public int UserID { get; set; }
        public bool? DoesItHaveStock { get; set; }
        public bool? AllowProtocol { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal CostPrice { get; set; }
        public int CompanyLocationID { get; set; }
    }
}
