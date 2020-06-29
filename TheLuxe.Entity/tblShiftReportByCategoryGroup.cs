﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheLuxe.Entity
{
    public partial class tblShiftReportByCategoryGroup
    {
        public int ShiftID { get; set; }
        [Required]
        [StringLength(50)]
        public string CategoryGroupName { get; set; }
        public int ProductID { get; set; }
        [StringLength(100)]
        public string ProductName { get; set; }
        public double CashQty { get; set; }
        [StringLength(50)]
        public string CashConverted { get; set; }
        [Column(TypeName = "money")]
        public decimal CashAmt { get; set; }
        public double CreditQty { get; set; }
        [StringLength(50)]
        public string CreditConverted { get; set; }
        [Column(TypeName = "money")]
        public decimal CreditAmt { get; set; }
        public double ProtocolQty { get; set; }
        [StringLength(50)]
        public string ProtocolConverted { get; set; }
        [Column(TypeName = "money")]
        public decimal ProtocolAmt { get; set; }
        public double PendingQty { get; set; }
        [StringLength(50)]
        public string PendingConverted { get; set; }
        [Column(TypeName = "money")]
        public decimal PendingAmt { get; set; }
        public double WaiterTransferQty { get; set; }
        [StringLength(50)]
        public string WaiterTransferConverted { get; set; }
        [Column(TypeName = "money")]
        public decimal WaiterTransferAmt { get; set; }
        public double TotalQty { get; set; }
        [Column(TypeName = "money")]
        public decimal? TotalAmt { get; set; }
    }
}