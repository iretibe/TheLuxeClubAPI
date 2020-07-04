namespace TheLuxe.Model.ProductRecipe
{
    public class uspSelectProductRecipeSelector
    {
        public int ProductRecipeID { get; set; }
        public int ProductID { get; set; }
        public int PackageID { get; set; }
        public decimal CostPrice { get; set; }
        public double Qty { get; set; }
        public string ProductName { get; set; }
        public string PackageName { get; set; }
        public double? TotalCostPrice { get; set; }
        
    }
}
