namespace TheLuxe.Model.ProductTransfer
{
    public class uspSelectProductTransfer
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double QtyTransfered { get; set; }
        public string TotalQtyTransfered { get; set; }
        public decimal TotalAmount { get; set; }
        public int CompanyLocationID { get; set; }
        public string CompanyLocationName { get; set; }
    }
}
