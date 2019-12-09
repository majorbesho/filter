using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdgeMobile.Models
{
    public partial class InvItemStore
    {
        public InvItemStore()
        {
         //   this.ArApInvoiceItems = new List<ArApInvoiceItem>();
         //   this.ArBackorders = new List<ArBackorder>();
           this.InvItemBalanceEvaluates = new List<InvItemBalanceEvaluate>();
         //   this.InvItemSerials = new List<InvItemSerial>();
          //  this.InvItemSizeColorBalances = new List<InvItemSizeColorBalance>();
          //  this.InvItemStoreOpeningBalanceDetails = new List<InvItemStoreOpeningBalanceDetail>();
         //   this.InvItemUnitPrices = new List<InvItemUnitPrice>();
          //  this.InvTransactionDetails = new List<InvTransactionDetail>();
          //  this.ArBackorders = new List<ArBackorder>();
           // this.ArSalesOrderDetails = new List<ArSalesOrderDetail>();
           // this.MFWorkOrderDetails = new List<MFWorkOrderDetail>();
           // this.ArKitItemSalesDetails = new List<ArKitItemSalesDetail>();

        }

        public int InvItemStoreID { get; set; }
        public int InvStoreID { get; set; }
        public string Location { get; set; }
        public Nullable<decimal> SellingPrice { get; set; }
        public Nullable<decimal> WholeSalePrice { get; set; }
        public Nullable<decimal> DistributorPrice { get; set; }
        public Nullable<decimal> OpeningBalance { get; set; }
        public string Analytical { get; set; }
        public int DefBranchID { get; set; }
        public int InvItemID { get; set; }
        public Nullable<int> RecessionPeriod { get; set; }
        public Nullable<decimal> MinimumLimit { get; set; }
        public Nullable<decimal> MaximumLimit { get; set; }
        public Nullable<decimal> ReorderLimit { get; set; }
        public Nullable<decimal> OpeningCostPrice { get; set; }
        public Nullable<decimal> OpeningLastCostPrice { get; set; }
        public Nullable<decimal> AverageCostPrice { get; set; }
        public Nullable<decimal> LastCostPrice { get; set; }
        public Nullable<decimal> ReservedQuantity { get; set; }
        public Nullable<decimal> PurchaseQuantity { get; set; }
        public Nullable<decimal> RequestedQuantityWhenReachToReorderLimit { get; set; }



  
        public virtual InvItem InvItem { get; set; }
        public virtual ICollection<InvItemBalanceEvaluate> InvItemBalanceEvaluates { get; set; }

        public virtual InvStore InvStore { get; set; }

    }
}