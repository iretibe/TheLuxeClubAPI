﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheLuxe.Entity
{
    public partial class tblShiftReportTemp
    {
        public int ShiftID { get; set; }
        public int OrderStatusID { get; set; }
        [Column(TypeName = "money")]
        public decimal Amount { get; set; }
    }
}