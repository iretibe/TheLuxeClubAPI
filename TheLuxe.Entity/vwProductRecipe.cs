﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheLuxe.Entity
{
    public partial class vwProductRecipe
    {
        public int ProductRecipeID { get; set; }
        public int ProductID { get; set; }
        public int RecipeID { get; set; }
        public double Qty { get; set; }
        [Column(TypeName = "money")]
        public decimal CostPrice { get; set; }
        public double? TotalCostPrice { get; set; }
        [StringLength(100)]
        public string Recipe { get; set; }
        [StringLength(100)]
        public string ProductName { get; set; }
        public int PackageID { get; set; }
        [Required]
        [StringLength(50)]
        public string PackageName { get; set; }
    }
}