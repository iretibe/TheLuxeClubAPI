﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheLuxe.Entity
{
    public partial class tblStockPurchaseDetail
    {
        [Key]
        public int StockPurchaseDetailID { get; set; }
        public int StockPurchaseID { get; set; }
        public int ProductID { get; set; }
        public int SellingUnitID { get; set; }
        public double Qty { get; set; }
        public double TotalQty { get; set; }
        [Column(TypeName = "money")]
        public decimal CostPrice { get; set; }
        public double? StockPurchaseDetailTotal { get; set; }
    }
}