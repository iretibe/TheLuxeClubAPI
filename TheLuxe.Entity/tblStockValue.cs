﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheLuxe.Entity
{
    public partial class tblStockValue
    {
        public int ProductID { get; set; }
        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }
        public double StockLevel { get; set; }
        [StringLength(50)]
        public string TotalStockLevel { get; set; }
        [Column(TypeName = "money")]
        public decimal LowestPackageSellingPrice { get; set; }
        [Column(TypeName = "money")]
        public decimal HighestPackageSellingPrice { get; set; }
        [Column(TypeName = "money")]
        public decimal TotalSellingPrice { get; set; }
        [Column(TypeName = "money")]
        public decimal LowestPackageCostPrice { get; set; }
        [Column(TypeName = "money")]
        public decimal HighestPackageCostPrice { get; set; }
        [Column(TypeName = "money")]
        public decimal TotalCostPrice { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime StockValueDate { get; set; }
    }
}