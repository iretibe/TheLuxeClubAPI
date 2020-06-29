namespace TheLuxe.Model.ProductCategory
{
    public class CategoryForUpdateModel
    {
        public int ProductCategoryID { get; set; }
        public string CategoryName { get; set; }
        public bool SelectOption { get; set; }
        public int CategoryGroupID { get; set; }
    }
}
