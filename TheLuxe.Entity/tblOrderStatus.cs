﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheLuxe.Entity
{
    public partial class tblOrderStatus
    {
        [Key]
        public int OrderStatusID { get; set; }
        [Required]
        [StringLength(20)]
        public string OrderStatusName { get; set; }
    }
}