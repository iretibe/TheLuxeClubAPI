﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheLuxe.Entity
{
    public partial class tblSelectEndOfShift
    {
        public string Description { get; set; }
        [StringLength(50)]
        public string Qty { get; set; }
        [StringLength(50)]
        public string Amount { get; set; }
    }
}