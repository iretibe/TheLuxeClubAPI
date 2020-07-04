namespace TheLuxe.Model.Product
{
    public class uspSelectProductWithNoStockForRecipe
    {
        public int ProductID { get; set; }
        public string BarCode { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductCodeName { get; set; }
        public bool? IsActive { get; set; }
        public int BaseUnitID { get; set; }
        public int ProductCategoryID { get; set; }
        public int UserID { get; set; }
        public bool? DoesItHaveStock { get; set; }
        public bool? AllowProtocol { get; set; }
    }
}
