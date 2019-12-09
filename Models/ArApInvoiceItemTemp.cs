using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EdgeMobile.Models
{
    public class ArApInvoiceItemTemp
    {
        [Key]
        public int ArApInvoiceItemID { get; set; }
        public int ArApInvoiceID { get; set; }
        public string ArApInvoiceCode { get; set; }
        //   public Nullable<int> ArApDelegateIDMarketing { get; set; }
        public int InvItemStoreID { get; set; }
        public int InvUnitID { get; set; }
        public decimal ConvertFactor { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal EffectsValue { get; set; }
        public decimal NetPrice { get; set; }
        public short InvoiceItemFlag { get; set; }
        public int FreeQuantity { get; set; }
        public Nullable<decimal> ItemCostPrice { get; set; }
        public Nullable<decimal> ItemCostPriceFromSupplier { get; set; }
        public Nullable<int> InvSizeID { get; set; }
        public Nullable<int> InvColorID { get; set; }
        public Nullable<int> ApPurchasingRequestOrderDetailID { get; set; }
        public decimal SellingPrice { get; set; }

        public Nullable<int> ArSalesOrderDetailID { get; set; }
        public Nullable<short> OperationType { get; set; }
        public Nullable<long> RecordOwnerID { get; set; }
        public int UserID { get; set; }
        public virtual ArApInvoiceTemp ArApInvoiceTemp { get; set; }
        public virtual InvItemStore InvItemStore { get; set; }
        public virtual InvUnit InvUnit { get; set; }
    }
}