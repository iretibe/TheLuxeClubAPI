﻿namespace TheLuxe.Model.Product
{
    public class ProductForUpdateModel
    {
        public int ProductID { get; set; }
        public string ProductCode { get; set; }
        public string BarCode { get; set; }
        public string ProductName { get; set; }
        public bool? IsActive { get; set; }
        public int BaseUnitID { get; set; }
        public int ProductCategoryID { get; set; }
        public int UserID { get; set; }
        public bool? DoesItHaveStock { get; set; }
        public bool? AllowProtocol { get; set; }
        public decimal NoOfPortion { get; set; }
    }
}
