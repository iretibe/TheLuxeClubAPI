namespace TheLuxe.Model.ProductRecipe
{
    public class ProductRecipeForInsertModel
    {
        public int ProductID { get; set; }
        public int RecipeID { get; set; }
        public double Qty { get; set; }
        public int PackageID { get; set; }
        public decimal CostPrice { get; set; }
    }
}
