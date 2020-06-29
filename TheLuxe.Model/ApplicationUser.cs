using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheLuxe.Model
{
    public class ApplicationUser : IdentityUser
    {
        public int UserID { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
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
