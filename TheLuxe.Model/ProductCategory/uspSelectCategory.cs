namespace TheLuxe.Model.ProductCategory
{
    public class uspSelectCategory
    {
        public int ProductCategoryID { get; set; }
        public string CategoryName { get; set; }
        public int CategoryGroupID { get; set; }
        public bool SelectOption { get; set; }
        public string CategoryGroupName { get; set; }
    }
}
