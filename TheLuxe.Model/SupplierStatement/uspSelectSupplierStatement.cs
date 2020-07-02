using System;

namespace TheLuxe.Model.SupplierStatement
{
    public class uspSelectSupplierStatement
    {        
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public int SupplierStatementID { get; set; }
        public string TransactionNo { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal? Balance { get; set; }        
    }
}
