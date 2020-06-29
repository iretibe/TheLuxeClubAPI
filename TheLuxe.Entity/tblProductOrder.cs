﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheLuxe.Entity
{
    public partial class tblProductOrder
    {
        public int ProductID { get; set; }
        [StringLength(100)]
        public string ProductName { get; set; }
        public double QtyOrdered { get; set; }
        [StringLength(50)]
        public string BaseUnit { get; set; }
        [StringLength(50)]
        public string TotalQtyOrdered { get; set; }
        [Column(TypeName = "money")]
        public decimal TotalAmount { get; set; }
        [StringLength(100)]
        public string CategoryName { get; set; }
        [StringLength(100)]
        public string ShiftName { get; set; }
        [Column(TypeName = "money")]
        public decimal TotalCostAmount { get; set; }
        [Column(TypeName = "money")]
        public decimal? Profit { get; set; }
        [Column(TypeName = "money")]
        public decimal SellingPrice { get; set; }
        [Column(TypeName = "money")]
        public decimal CostPrice { get; set; }
        [StringLength(50)]
        public string CompanyLocationName { get; set; }
    }
}