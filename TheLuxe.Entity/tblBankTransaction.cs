﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheLuxe.Entity
{
    public partial class tblBankTransaction
    {
        [Key]
        public int TransactionID { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime TransactionDate { get; set; }
        public int BankTransactionTypeID { get; set; }
        public int BankAccountID { get; set; }
        public int PaymentModeID { get; set; }
        public string Notes { get; set; }
        public int BankID { get; set; }
        [Column(TypeName = "money")]
        public decimal Amount { get; set; }
        [StringLength(50)]
        public string TransactedBy { get; set; }
        public bool IsPosted { get; set; }
        [StringLength(50)]
        public string ChequeNo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ChequeDate { get; set; }
        public int UserID { get; set; }
        public int AccountID { get; set; }
        public int FromBankAccountID { get; set; }
        public int ToBankAccountID { get; set; }
    }
}