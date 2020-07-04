namespace TheLuxe.Model.ProductRecipe
{
    public class ProductRecipeForUpdateModel
    {
        public int ProductRecipeID { get; set; }
        public int ProductID { get; set; }
        public int RecipeID { get; set; }
        public double Qty { get; set; }
        public int PackageID { get; set; }
        public decimal CostPrice { get; set; }
    }
}
