using System;

namespace TheLuxe.Model.CustomerStatement
{
    public class uspSelectCustomerStatement
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public int CustomerStatementID { get; set; }
        public string TransactionNo { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal? Balance { get; set; }
    }
}
