﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheLuxe.Entity
{
    public partial class vwProduct
    {
        public int ProductCategoryID { get; set; }
        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; }
        public int? ProductID { get; set; }
        [StringLength(50)]
        public string ProductCode { get; set; }
        [StringLength(100)]
        public string ProductName { get; set; }
        [StringLength(151)]
        public string ProductCodeName { get; set; }
        public int? BaseUnitID { get; set; }
        [StringLength(50)]
        public string PackageName { get; set; }
        [StringLength(100)]
        public string BarCode { get; set; }
        public int? UserID { get; set; }
        public bool? IsActive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateCreated { get; set; }
        public bool? DoesItHaveStock { get; set; }
        public bool? AllowProtocol { get; set; }
        [StringLength(50)]
        public string UserName { get; set; }
    }
}