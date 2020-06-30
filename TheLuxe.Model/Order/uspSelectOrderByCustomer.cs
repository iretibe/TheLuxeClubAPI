using System;

namespace TheLuxe.Model.Order
{
    public class uspSelectOrderByCustomer
    {
        public int OrderID { get; set; }
        public string OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal NetTotal { get; set; }
        public decimal TAX { get; set; }
        public int WaiterID { get; set; }
        public int ChefID { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public int OrderStatusID { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string WaiterName { get; set; }
        public int TableID { get; set; }
        public string TableNo { get; set; }
    }
}
