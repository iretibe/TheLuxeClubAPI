﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheLuxe.Entity
{
    public partial class tblPrinterSetting
    {
        [Key]
        public int PrinterSettingID { get; set; }
        public int ProductCategoryLocationID { get; set; }
        public int ComputerLocationID { get; set; }
        [Required]
        [StringLength(50)]
        public string PrinterName { get; set; }
    }
}