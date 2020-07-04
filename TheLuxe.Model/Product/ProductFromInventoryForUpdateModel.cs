using System;

namespace TheLuxe.Model.Product
{
    public class ProductFromInventoryForUpdateModel
    {
        public int ProductID { get; set; }
        public string ProductCode { get; set; }
        public string BarCode { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int StatusID { get; set; }
        public int BaseUnitID { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int ProductCategoryID { get; set; }
        public int UserID { get; set; }
        public bool? DoesItHaveStock { get; set; }
    }
}
