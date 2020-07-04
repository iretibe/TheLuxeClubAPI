namespace TheLuxe.Model.ProductDamage
{
    public class uspSelectProductDamage
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double QtyDamaged { get; set; }
        public string TotalQtyDamaged { get; set; }
        public decimal TotalAmount { get; set; }
        public int CompanyLocationID { get; set; }
        public string CompanyLocationName { get; set; }
    }
}
