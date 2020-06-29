﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheLuxe.Entity
{
    public partial class tblCreditSalePayment
    {
        [Key]
        public int CreditSalePaymentID { get; set; }
        public int CustomerID { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime PaymentDate { get; set; }
        public int PaymentModeID { get; set; }
        [StringLength(50)]
        public string ChequeNo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ChequeDate { get; set; }
        public int BankID { get; set; }
        public int BankBranchID { get; set; }
        [Column(TypeName = "money")]
        public decimal AmountPaid { get; set; }
        [StringLength(100)]
        public string PaidBy { get; set; }
        public int UserID { get; set; }
        public int ShiftID { get; set; }
        public int OrderID { get; set; }
    }
}