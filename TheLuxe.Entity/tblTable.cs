﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheLuxe.Entity
{
    public partial class tblTable
    {
        [Key]
        public int TableID { get; set; }
        [Required]
        [StringLength(50)]
        public string TableNo { get; set; }
        public int TableGroupID { get; set; }
        [Required]
        public bool? IsActive { get; set; }
    }
}