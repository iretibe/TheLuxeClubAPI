namespace TheLuxe.Model.ProductOrder
{
    public class uspSelectProductOrderWithShift
    {
        public int? ProductID { get; set; }
        public string ProductName { get; set; }
        public double? QtyOrdered { get; set; }
        public decimal? SellingPrice { get; set; }
        public int BaseUnit { get; set; }
        public string TotalQtyOrdered { get; set; }
        public decimal TotalAmount { get; set; }
        public string CategoryName { get; set; }
        public string ShiftName { get; set; }
        public decimal CostPrice { get; set; }
        public decimal TotalCostAmount { get; set; }
        public decimal Profit { get; set; }
        public string CompanyLocationName { get; set; }
    }
}
