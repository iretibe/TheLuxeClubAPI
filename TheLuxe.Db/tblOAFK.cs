﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheLuxe.Db
{
    public partial class tblOAFK
    {
        [Key]
        public int ID { get; set; }
        public int OrderActivityID { get; set; }
    }
}