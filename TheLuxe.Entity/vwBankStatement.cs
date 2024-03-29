﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheLuxe.Entity
{
    public partial class vwBankStatement
    {
        public int BankStatementID { get; set; }
        public int BankAccountID { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime TransactionDate { get; set; }
        [Required]
        [StringLength(50)]
        public string BankAccountNo { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        [Column(TypeName = "money")]
        public decimal Debit { get; set; }
        [Column(TypeName = "money")]
        public decimal Credit { get; set; }
        [Column(TypeName = "money")]
        public decimal? Balance { get; set; }
        public int? BankID { get; set; }
        [StringLength(50)]
        public string BankName { get; set; }
        [StringLength(50)]
        public string BankBranchName { get; set; }
        [StringLength(50)]
        public string AccountTypeName { get; set; }
    }
}