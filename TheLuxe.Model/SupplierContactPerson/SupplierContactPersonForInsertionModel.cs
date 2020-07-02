namespace TheLuxe.Model.SupplierContactPerson
{
    public class SupplierContactPersonForInsertionModel
    {
        public int TitleID { get; set; }
        public int PositionID { get; set; }
        public string ContactPersonName { get; set; }
        public string MobilePhoneNo { get; set; }
        public string HomePhoneNo { get; set; }
        public string OfficePhoneNo { get; set; }
        public string Address { get; set; }
        public int SupplierID { get; set; }
    }
}
