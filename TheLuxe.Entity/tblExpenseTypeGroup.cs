﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheLuxe.Entity
{
    public partial class tblExpenseTypeGroup
    {
        [Key]
        public int ExpenseTypeGroupID { get; set; }
        [Required]
        [StringLength(10)]
        public string ExpenseTypeGroupCode { get; set; }
        [Required]
        [StringLength(50)]
        public string ExpenseTypeGroupName { get; set; }
    }
}