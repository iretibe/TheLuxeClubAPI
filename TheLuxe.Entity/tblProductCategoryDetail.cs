﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheLuxe.Entity
{
    public partial class tblProductCategoryDetail
    {
        [Key]
        public int ProductCategoryDetailID { get; set; }
        public int ProductCategoryID { get; set; }
        [Required]
        public bool? ShowInMenu { get; set; }
        public int CompanyLocationID { get; set; }
        public int ProductCategoryLocationID { get; set; }
    }
}