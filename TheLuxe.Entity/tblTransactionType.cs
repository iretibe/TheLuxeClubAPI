﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheLuxe.Entity
{
    public partial class tblTransactionType
    {
        [Key]
        public int TransactionTypeID { get; set; }
        [Required]
        [StringLength(50)]
        public string TransactionTypeName { get; set; }
    }
}