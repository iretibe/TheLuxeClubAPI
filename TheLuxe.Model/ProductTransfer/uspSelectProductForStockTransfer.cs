using System;

namespace TheLuxe.Model.ProductTransfer
{
    public class uspSelectProductForStockTransfer
    {
        public int ProductCategoryID { get; set; }
        public string CategoryName { get; set; }
        public int? ProductID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductCodeName { get; set; }
        public decimal InitialStock { get; set; }
        public decimal StockLevel { get; set; }
        public int? BaseUnitID { get; set; }
        public decimal ReOrderLevel { get; set; }
        public string PackageName { get; set; }
        public string BarCode { get; set; }
        public int? UserID { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? DateCreated { get; set; }
        public bool? DoesItHaveStock { get; set; }
        public bool? AllowProtocol { get; set; }
        public string UserName { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SellingPrice { get; set; }
    }
}
