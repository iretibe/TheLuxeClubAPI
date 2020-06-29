﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheLuxe.Entity
{
    public partial class tblStock
    {
        [Key]
        public int StockID { get; set; }
        public int StockOrderID { get; set; }
        public int ProductID { get; set; }
        [StringLength(50)]
        public string ProductFullName { get; set; }
        [Column(TypeName = "money")]
        public decimal SellingPrice { get; set; }
        public int StatusID { get; set; }
        public int TransactionTypeID { get; set; }
    }
}