﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheLuxe.Entity
{
    public partial class tblSupplier
    {
        [Key]
        public int SupplierID { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime RegistrationDate { get; set; }
        [StringLength(32)]
        public string SupplierNo { get; set; }
        [Required]
        [StringLength(50)]
        public string SupplierName { get; set; }
        [StringLength(50)]
        public string PhoneNo { get; set; }
        [StringLength(50)]
        public string FaxNo { get; set; }
        [StringLength(50)]
        public string EMailAddress { get; set; }
        [StringLength(50)]
        public string WebSite { get; set; }
        public string Address { get; set; }
        [Required]
        public bool? IsActive { get; set; }
        [Column(TypeName = "money")]
        public decimal Credit { get; set; }
        [Column(TypeName = "money")]
        public decimal Debit { get; set; }
    }
}