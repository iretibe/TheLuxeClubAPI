﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheLuxe.Entity
{
    public partial class tblStockVariance
    {
        [Key]
        public int StockVarianceID { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime StockVarianceDate { get; set; }
        public int ProductID { get; set; }
        public int SellingUnitID { get; set; }
        [Column(TypeName = "money")]
        public decimal SellingPrice { get; set; }
        public double StockLevelBefore { get; set; }
        [StringLength(50)]
        public string TotalStockLevelBefore { get; set; }
        public double CurrentStockLevel { get; set; }
        [StringLength(50)]
        public string TotalCurrentStockLevel { get; set; }
        public double StockDifference { get; set; }
        [StringLength(50)]
        public string TotalStockDifference { get; set; }
        [Column(TypeName = "money")]
        public decimal StockDifferenceAmount { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        public int UserID { get; set; }
        public int CompanyLocationID { get; set; }
    }
}