﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheLuxe.Entity
{
    public partial class tblProductCategoryLocation
    {
        [Key]
        public int ProductCategoryLocationID { get; set; }
        [Required]
        [StringLength(50)]
        public string ProductCategoryLocationName { get; set; }
        [StringLength(100)]
        public string PrinterName { get; set; }
    }
}