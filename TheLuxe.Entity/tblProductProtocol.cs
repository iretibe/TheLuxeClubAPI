﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheLuxe.Entity
{
    public partial class tblProductProtocol
    {
        public int ProductID { get; set; }
        [StringLength(100)]
        public string ProductName { get; set; }
        public double QtyProtocoled { get; set; }
        [StringLength(50)]
        public string TotalQtyProtocoled { get; set; }
        [Column(TypeName = "money")]
        public decimal TotalAmount { get; set; }
    }
}