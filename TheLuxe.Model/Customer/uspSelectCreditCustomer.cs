using System;

namespace TheLuxe.Model.Customer
{
    public class uspSelectCreditCustomer
    {
        public int CustomerID { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string CustomerNo { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNo { get; set; }
        public string FaxNo { get; set; }
        public string EMailAddress { get; set; }
        public string WebSite { get; set; }
        public string Address { get; set; }
        public bool? IsActive { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal CreditLimit { get; set; }
        public bool? ApplyProtocolSetup { get; set; }
    }
}
