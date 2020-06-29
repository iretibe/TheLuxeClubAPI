﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheLuxe.Entity
{
    public partial class tblProtocolSetup
    {
        public int DayNo { get; set; }
        [Required]
        [StringLength(50)]
        public string DayName { get; set; }
        [Column(TypeName = "money")]
        public decimal ProtocolAmount { get; set; }
        public int UserID { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDateTime { get; set; }
    }
}