﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheLuxe.Entity
{
    public partial class tblWaiterAccount
    {
        public int WaiterID { get; set; }
        [Required]
        [StringLength(50)]
        public string WaiterName { get; set; }
        [Column(TypeName = "money")]
        public decimal OpeningBalance { get; set; }
        [Column(TypeName = "money")]
        public decimal AmountOwed { get; set; }
        [Column(TypeName = "money")]
        public decimal AmountPaid { get; set; }
        [Column(TypeName = "money")]
        public decimal? Balance { get; set; }
    }
}