﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheLuxe.Entity
{
    public partial class tblMonthlyOrderSummaryReport
    {
        public int CompanyLocationID { get; set; }
        [StringLength(50)]
        public string CompanyLocationName { get; set; }
        [StringLength(50)]
        public string OrderYear { get; set; }
        [StringLength(50)]
        public string Month { get; set; }
        [Column(TypeName = "money")]
        public decimal Total { get; set; }
    }
}