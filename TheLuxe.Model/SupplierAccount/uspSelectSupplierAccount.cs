namespace TheLuxe.Model.SupplierAccount
{
    public class uspSelectSupplierAccount
    {
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public decimal OpeningBalance { get; set; }
        public decimal AmountOwed { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal? Balance { get; set; }
    }
}
