using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdgeMobile.Models
{
    public partial class InvStore
    {
        public InvStore()
        {
         //   this.ApPurchasingOrders = new List<ApPurchasingOrder>();
         //   this.ApPurchasingRequests = new List<ApPurchasingRequest>();
      //      this.ArApInvoices = new List<ArApInvoice>();
            this.InvItemStores = new List<InvItemStore>();
         //   this.ArBackorders = new List<ArBackorder>();
         //   this.ArSalesOrders = new List<ArSalesOrder>();
         //   this.ArKitItemSaless = new List<ArKitItemSales>();
         //  this.MFWorkOrders = new List<MFWorkOrder>();

        }

        public int InvStoreID { get; set; }
        public string StoreName { get; set; }
        public string Notes { get; set; }
        public int DefBranchID { get; set; }
        public string StoreNameEN { get; set; }
        public string NotesEN { get; set; }
        public Nullable<long> GlStoreAccountID { get; set; }
        public Nullable<long> GlStoreCostAccountID { get; set; }
     //   public virtual ICollection<ApPurchasingOrder> ApPurchasingOrders { get; set; }
     //   public virtual ICollection<ApPurchasingRequest> ApPurchasingRequests { get; set; }
     //   public virtual ICollection<ArApInvoice> ArApInvoices { get; set; }
     //   public virtual ICollection<MFWorkOrder> MFWorkOrders { get; set; }
      //  public virtual ICollection<ArKitItemSales> ArKitItemSaless { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual ICollection<InvItemStore> InvItemStores { get; set; }
       // public virtual ICollection<ArBackorder> ArBackorders { get; set; }
      //  public virtual ICollection<ArSalesOrder> ArSalesOrders { get; set; }

    }
}