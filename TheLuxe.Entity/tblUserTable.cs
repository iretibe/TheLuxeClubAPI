﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheLuxe.Entity
{
    public partial class tblUserTable
    {
        [Key]
        public int UserTableID { get; set; }
        public int UserID { get; set; }
        public int TableID { get; set; }
    }
}