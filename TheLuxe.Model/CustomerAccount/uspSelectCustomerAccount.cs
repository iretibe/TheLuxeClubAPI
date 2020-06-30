namespace TheLuxe.Model.CustomerAccount
{
    public class uspSelectCustomerAccount
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public decimal OpeningBalance { get; set; }
        public decimal AmountOwed { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal? Balance { get; set; }
    }
}
