﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheLuxe.Entity
{
    public partial class tblBankAccount
    {
        [Key]
        public int BankAccountID { get; set; }
        public int BankID { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime OpeningDate { get; set; }
        [Required]
        [StringLength(50)]
        public string AccountNo { get; set; }
        [Required]
        [StringLength(50)]
        public string AccountName { get; set; }
        public int AccountTypeID { get; set; }
        [StringLength(50)]
        public string BankBranchName { get; set; }
        [Column(TypeName = "money")]
        public decimal OpeningBalance { get; set; }
        [Column(TypeName = "money")]
        public decimal CurrentBalance { get; set; }
        public int CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedDateTime { get; set; }
        public int ModifiedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDateTime { get; set; }
    }
}