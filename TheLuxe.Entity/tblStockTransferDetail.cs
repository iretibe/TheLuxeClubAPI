﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheLuxe.Entity
{
    public partial class tblStockTransferDetail
    {
        [Key]
        public int StockTransferDetailID { get; set; }
        public int StockTransferID { get; set; }
        public int ProductID { get; set; }
        public int SellingUnitID { get; set; }
        public double Qty { get; set; }
        public double TotalQty { get; set; }
        [Column(TypeName = "money")]
        public decimal SellingPrice { get; set; }
        public double? StockTransferDetailTotal { get; set; }
    }
}