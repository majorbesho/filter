using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdgeMobile.Models
{
    public partial class InvItemBalanceEvaluate
    {
        public InvItemBalanceEvaluate()
        {
      //      this.ArApInvoiceItemDetails = new List<ArApInvoiceItemDetail>();
     //       this.InvItemStoreOpeningBalanceDetails = new List<InvItemStoreOpeningBalanceDetail>();
     //       this.InvTransactionDetailStockDetails = new List<InvTransactionDetailStockDetail>();
     //       this.InvTransactionDetailStockDetails1 = new List<InvTransactionDetailStockDetail>();
        }

        public long InvItemBalanceEvaluateID { get; set; }
        public int InvItemStoreID { get; set; }
        public decimal CostPrice { get; set; }
        public System.DateTime AddDate { get; set; }
        public string BatchID { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public string Location { get; set; }
        public Nullable<decimal> AveragePrice { get; set; }
        public Nullable<decimal> LastPrice { get; set; }
        public Nullable<decimal> OriginalQuantity { get; set; }
        public Nullable<int> InvSizeID { get; set; }
        public Nullable<int> InvColorID { get; set; }
        public Nullable<decimal> FreeQuantity { get; set; }
        public short IsOpeningBalanceDetail { get; set; }
        //public virtual ICollection<ArApInvoiceItemDetail> ArApInvoiceItemDetails { get; set; }
     //   public virtual InvColor InvColor { get; set; }
     //   public virtual InvSize InvSize { get; set; }
        public virtual InvItemStore InvItemStore { get; set; }
       // public virtual ICollection<InvItemStoreOpeningBalanceDetail> InvItemStoreOpeningBalanceDetails { get; set; }
       // public virtual ICollection<InvTransactionDetailStockDetail> InvTransactionDetailStockDetails { get; set; }
       // public virtual ICollection<InvTransactionDetailStockDetail> InvTransactionDetailStockDetails1 { get; set; }
    }
}