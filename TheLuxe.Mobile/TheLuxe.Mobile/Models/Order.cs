using System;
using System.Collections.Generic;

namespace TheLuxe.Mobile.Models
{
    public class Order
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public int orderTotal { get; set; }
        public DateTime orderPlaced { get; set; }
        public bool isOrderCompleted { get; set; }
        public int userId { get; set; }
        public List<OrderDetail> orderDetails { get; set; }
    }
}
