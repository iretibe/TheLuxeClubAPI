﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheLuxe.Entity
{
    public partial class tblOrderConfirmation
    {
        [Key]
        public int OrderConfirmationID { get; set; }
        public int OrderID { get; set; }
        public int UserID { get; set; }
    }
}