﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheLuxe.Entity
{
    public partial class tblWaiter
    {
        [Key]
        public int WaiterID { get; set; }
        [Required]
        [StringLength(50)]
        public string WaiterName { get; set; }
        [StringLength(50)]
        public string WaiterPassword { get; set; }
        [Required]
        public bool? IsActive { get; set; }
        [Column(TypeName = "money")]
        public decimal WaiterSalary { get; set; }
        public int CreatedBy { get; set; }
    }
}