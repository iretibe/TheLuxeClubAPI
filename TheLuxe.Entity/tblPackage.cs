﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheLuxe.Entity
{
    public partial class tblPackage
    {
        [Key]
        public int PackageID { get; set; }
        [Required]
        [StringLength(50)]
        public string PackageName { get; set; }
    }
}