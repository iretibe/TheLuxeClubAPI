﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheLuxe.Entity
{
    public partial class tblCustomerStatement
    {
        public int CustomerStatementID { get; set; }
        public int CustomerID { get; set; }
        [StringLength(50)]
        public string TransactionNo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime TransactionDate { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        [Column(TypeName = "money")]
        public decimal Debit { get; set; }
        [Column(TypeName = "money")]
        public decimal Credit { get; set; }
        [Column(TypeName = "money")]
        public decimal? Balance { get; set; }
    }
}