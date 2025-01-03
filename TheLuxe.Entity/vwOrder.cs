﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheLuxe.Entity
{
    public partial class vwOrder
    {
        public int OrderID { get; set; }
        [StringLength(32)]
        public string OrderNo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime OrderDate { get; set; }
        [Column(TypeName = "money")]
        public decimal OrderTotal { get; set; }
        [Column(TypeName = "money")]
        public decimal Discount { get; set; }
        [Column(TypeName = "money")]
        public decimal NetTotal { get; set; }
        [Column(TypeName = "money")]
        public decimal TAX { get; set; }
        public int WaiterID { get; set; }
        public int ChefID { get; set; }
        public int CustomerID { get; set; }
        [StringLength(50)]
        public string CustomerName { get; set; }
        public int UserID { get; set; }
        [StringLength(50)]
        public string ChefName { get; set; }
        [StringLength(32)]
        public string CustomerNo { get; set; }
        [StringLength(50)]
        public string PhoneNo { get; set; }
        [StringLength(50)]
        public string FaxNo { get; set; }
        [StringLength(50)]
        public string EMailAddress { get; set; }
        [StringLength(50)]
        public string WebSite { get; set; }
        public string Address { get; set; }
        [StringLength(50)]
        public string UserName { get; set; }
        [StringLength(50)]
        public string FullName { get; set; }
        public int? OrderDetailID { get; set; }
        public int? ProductID { get; set; }
        public int? SellingUnitID { get; set; }
        public double? Qty { get; set; }
        public double? TotalQty { get; set; }
        [Column(TypeName = "money")]
        public decimal? SellingPrice { get; set; }
        [Column(TypeName = "money")]
        public decimal? CostPrice { get; set; }
        [Column(TypeName = "money")]
        public decimal? VAT { get; set; }
        [Column(TypeName = "money")]
        public decimal? NHIL { get; set; }
        public double? OrderDetailTotal { get; set; }
        public double? OrderDetailTotalCost { get; set; }
        [StringLength(50)]
        public string ProductCode { get; set; }
        [StringLength(100)]
        public string ProductName { get; set; }
        [StringLength(151)]
        public string ProductCodeName { get; set; }
        [StringLength(50)]
        public string PackageName { get; set; }
        public int? ProductCategoryLocationID { get; set; }
        [StringLength(50)]
        public string ProductCategoryLocationName { get; set; }
        public int DeletedBy { get; set; }
        [Column("Deleted By")]
        [StringLength(50)]
        public string Deleted_By { get; set; }
        [StringLength(100)]
        public string PrinterName { get; set; }
        public int ShiftID { get; set; }
        public int TableID { get; set; }
        [StringLength(50)]
        public string TableNo { get; set; }
        public int OrderStatusID { get; set; }
        [StringLength(20)]
        public string OrderStatusName { get; set; }
        public int? ProductCategoryID { get; set; }
        [StringLength(100)]
        public string CategoryName { get; set; }
        [StringLength(69)]
        public string TimeRange { get; set; }
        public double? SellingPriceWithoutTax { get; set; }
        public double? OrderDetailTotalWithoutTax { get; set; }
        [StringLength(500)]
        public string ProductOption { get; set; }
        [StringLength(606)]
        public string ProductNameWithOption { get; set; }
        [StringLength(10)]
        public string ProductOptionID { get; set; }
        public int OrderTypeID { get; set; }
        [StringLength(50)]
        public string OrderTypeName { get; set; }
        [StringLength(50)]
        public string TableGroupName { get; set; }
        [Column(TypeName = "money")]
        public decimal? TL { get; set; }
        public int DebitedBy { get; set; }
        [StringLength(50)]
        public string DebitedByName { get; set; }
        public int ProtocolBy { get; set; }
        [StringLength(50)]
        public string ProtocolByName { get; set; }
        public bool? DoesItHaveStock { get; set; }
        [StringLength(50)]
        public string CategoryGroupName { get; set; }
        public int? CategoryGroupID { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDatetime { get; set; }
        public int CompanyLocationID { get; set; }
        [StringLength(50)]
        public string CompanyLocationName { get; set; }
        [StringLength(50)]
        public string WaiterName { get; set; }
        [Column(TypeName = "money")]
        public decimal CashPayment { get; set; }
        [Column(TypeName = "money")]
        public decimal VisaPayment { get; set; }
        [Column(TypeName = "money")]
        public decimal WaiterPayment { get; set; }
        public bool IsServiceCharge { get; set; }
        [Column(TypeName = "money")]
        public decimal ServiceCharge { get; set; }
        public int NoOfPeople { get; set; }
        [Column(TypeName = "money")]
        public decimal? OverAllTotal { get; set; }
        [Column(TypeName = "money")]
        public decimal MomoPayment { get; set; }
        public bool? NewlyInserted { get; set; }
    }
}