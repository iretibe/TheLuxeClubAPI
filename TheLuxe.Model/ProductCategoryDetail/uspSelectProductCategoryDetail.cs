namespace TheLuxe.Model.ProductCategoryDetail
{
    public class uspSelectProductCategoryDetail
    {
        public int ProductCategoryDetailID { get; set; }
        public int ProductCategoryID { get; set; }
        public bool ShowInMenu { get; set; }
        public int CompanyLocationID { get; set; }
        public string CompanyLocationName { get; set; }
        public int ProductCategoryLocationID { get; set; }
        public string ProductCategoryLocationName { get; set; }
        public string PrinterName { get; set; }
    }
}
