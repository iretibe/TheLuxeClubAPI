﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheLuxe.Entity
{
    public partial class tblLocation
    {
        [Key]
        public int LocationID { get; set; }
        [Required]
        [StringLength(50)]
        public string LocationName { get; set; }
        [StringLength(50)]
        public string OfficeNo { get; set; }
        public bool IsDefault { get; set; }
    }
}