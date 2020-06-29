using System;

namespace TheLuxe.Model.User
{
    public class UserRegistrationModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public bool IsAdmin { get; set; }
        public bool? IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public bool CanGiveDiscount { get; set; }
        public int UserTypeID { get; set; }
        public string MobilePassword { get; set; }
    }
}
