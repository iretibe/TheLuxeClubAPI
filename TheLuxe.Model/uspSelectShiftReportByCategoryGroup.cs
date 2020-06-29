using System;

namespace TheLuxe.Model
{
    public class uspSelectShiftReportByCategoryGroup
    {
        public int ShiftID { get; set; }
        public string CategoryGroupName { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double CashQty { get; set; }
        public string CashConverted { get; set; }
        public decimal CashAmt { get; set; }
        public double CreditQty { get; set; }
        public string CreditConverted { get; set; }
        public decimal CreditAmt { get; set; }
        public double ProtocolQty { get; set; }
        public string ProtocolConverted { get; set; }
        public decimal ProtocolAmt { get; set; }
        public double PendingQty { get; set; }
        public string PendingConverted { get; set; }
        public decimal PendingAmt { get; set; }
        public double WaiterTransferQty { get; set; }
        public string WaiterTransferConverted { get; set; }
        public decimal WaiterTransferAmt { get; set; }
        public double TotalQty { get; set; }
        public string TotalQtyConverted { get; set; }
        public Nullable<decimal> TotalAmt { get; set; }
    }
}
