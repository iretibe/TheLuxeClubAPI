namespace TheLuxe.Model.ProductRecipe
{
    public class uspSelectProductRecipe
    {
        public int ProductRecipeID { get; set; }
        public int ProductID { get; set; }
        public int RecipeID { get; set; }
        public double Qty { get; set; }
        public int PackageID { get; set; }
        public decimal CostPrice { get; set; }
        public double? TotalCostPrice { get; set; }
        public string Recipe { get; set; }
        public string PackageName { get; set; }
        public string ProductName { get; set; }
    }
}
