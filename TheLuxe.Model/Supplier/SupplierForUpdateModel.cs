using System;

namespace TheLuxe.Model.Supplier
{
    public class SupplierForUpdateModel
    {
        public int SupplierID { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string SupplierName { get; set; }
        public string PhoneNo { get; set; }
        public string FaxNo { get; set; }
        public string EMailAddress { get; set; }
        public string WebSite { get; set; }
        public string Address { get; set; }
        public bool? IsActive { get; set; }
        public decimal Credit { get; set; }
        public decimal Debit { get; set; }
    }
}
