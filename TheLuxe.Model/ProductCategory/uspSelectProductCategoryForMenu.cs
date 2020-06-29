using System;

namespace TheLuxe.Model.ProductCategory
{
    public class uspSelectProductCategoryForMenu
    {
        public int ProductCategoryDetailID { get; set; }
        public int ProductCategoryID { get; set; }
        public bool ShowInMenu { get; set; }
        public int CompanyLocationID { get; set; }
        public int ProductCategoryLocationID { get; set; }
        public string CategoryName { get; set; }
        public Nullable<bool> SelectOption { get; set; }
    }
}
