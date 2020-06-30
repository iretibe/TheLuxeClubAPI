namespace TheLuxe.Model.CustomerContactPerson
{
    public class uspSelectCustomerContactPerson
    {
        public int CustomerContactPersonID { get; set; }
        public int TitleID { get; set; }
        public string TitleName { get; set; }
        public int PositionID { get; set; }
        public string PositionName { get; set; }
        public string ContactPersonName { get; set; }
        public string MobilePhoneNo { get; set; }
        public string HomePhoneNo { get; set; }
        public string OfficePhoneNo { get; set; }
        public string Address { get; set; }
        public int CustomerID { get; set; }
    }
}
