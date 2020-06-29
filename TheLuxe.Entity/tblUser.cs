﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheLuxe.Entity
{
    public partial class tblUser
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
        [Required]
        [StringLength(50)]
        public string FullName { get; set; }
        public bool IsAdmin { get; set; }
        [Required]
        public bool? IsActive { get; set; }
        public int CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedDateTime { get; set; }
        public bool CanGiveDiscount { get; set; }
        public int UserTypeID { get; set; }
        [StringLength(50)]
        public string MobilePassword { get; set; }
    }
}