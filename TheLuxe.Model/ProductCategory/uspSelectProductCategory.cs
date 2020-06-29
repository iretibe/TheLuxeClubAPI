namespace TheLuxe.Model.ProductCategory
{
    public class uspSelectProductCategory
    {
        public int ProductCategoryID { get; set; }
        public string CategoryName { get; set; }
        public int CategoryGroupID { get; set; }
        public string CategoryGroupName { get; set; }
        public bool SelectOption { get; set; }
    }
}
