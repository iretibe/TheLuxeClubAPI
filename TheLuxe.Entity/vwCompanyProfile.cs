﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheLuxe.Entity
{
    public partial class vwCompanyProfile
    {
        public int CompanyProfileID { get; set; }
        [Required]
        [StringLength(100)]
        public string CompanyName { get; set; }
        [StringLength(200)]
        public string EMailAddress { get; set; }
        [StringLength(100)]
        public string PhoneNo { get; set; }
        [StringLength(100)]
        public string FaxNo { get; set; }
        public int CountryID { get; set; }
        public int CityID { get; set; }
        public int LocationID { get; set; }
        public string Address { get; set; }
        [StringLength(50)]
        public string WebSite { get; set; }
        [StringLength(50)]
        public string VATNo { get; set; }
        [Column(TypeName = "image")]
        public byte[] Logo { get; set; }
        [StringLength(200)]
        public string CountryName { get; set; }
        [StringLength(50)]
        public string CityName { get; set; }
        [StringLength(50)]
        public string LocationName { get; set; }
        public int CurrencyID { get; set; }
        public double VATRate { get; set; }
        public double NHILRate { get; set; }
        public double TLRate { get; set; }
        public double ServiceChargeRate { get; set; }
        public bool CanCashierOrder { get; set; }
        public bool CanWaiterInvoice { get; set; }
        public bool SelectTable { get; set; }
        public bool SelectOrderType { get; set; }
        public bool SelectWaiter { get; set; }
        public bool SelectNoOfPeople { get; set; }
        public bool StockControl { get; set; }
        public bool ShowVAT { get; set; }
        public int NoOfReceiptToPrint { get; set; }
        public int NoOfOrderToPrint { get; set; }
        public int NoOfInvoiceToPrint { get; set; }
        public bool LogUserAccess { get; set; }
        public bool TransferPendingBillToNextShift { get; set; }
        public bool CanCashierMergeBill { get; set; }
        public bool CanCashierSplitBill { get; set; }
    }
}