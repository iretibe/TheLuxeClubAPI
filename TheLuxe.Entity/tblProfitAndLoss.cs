﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheLuxe.Entity
{
    public partial class tblProfitAndLoss
    {
        [Key]
        public int ProfitAndLossID { get; set; }
        public int StockOrderID { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime StockOrderDate { get; set; }
        [Required]
        [StringLength(50)]
        public string SupplierName { get; set; }
        [Required]
        [StringLength(50)]
        public string StockOrderNo { get; set; }
        [Column(TypeName = "money")]
        public decimal StockOrderTotal { get; set; }
        [Column(TypeName = "money")]
        public decimal DeliveryTotal { get; set; }
        [Column(TypeName = "money")]
        public decimal SaleTotal { get; set; }
        [Column(TypeName = "money")]
        public decimal StockTransferTotal { get; set; }
        [Column(TypeName = "money")]
        public decimal StockDamageTotal { get; set; }
        [Column(TypeName = "money")]
        public decimal? ProfitAndLoss { get; set; }
        [StringLength(50)]
        public string Remarks { get; set; }
    }
}