namespace TheLuxe.Model.ProductStock
{
    public class uspSelectProductTransactionSummary
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double InitialStock { get; set; }
        public double StockPurchase { get; set; }
        public double QtySold { get; set; }
        public double StockDamage { get; set; }
        public double TransferIn { get; set; }
        public double TransferOut { get; set; }
        public double Protocol { get; set; }
        public double StockVariance { get; set; }
        public double StockLevel { get; set; }
    }
}
