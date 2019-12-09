using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace EdgeMobile.Models
{
    public partial class InvUnit
    {
        public InvUnit()
        {
           // this.ApPriceOfferDetails = new List<ApPriceOfferDetail>();
         //   this.ArPriceOfferDetails = new List<ArPriceOfferDetail>();
         //   this.ApPurchasingRequestOrderDetails = new List<ApPurchasingRequestOrderDetail>();
         //   this.ArApInvoiceItems = new List<ArApInvoiceItem>();
            this.InvItems = new List<InvItem>();
        //    this.InvItemUnitFactors = new List<InvItemUnitFactor>();
        //    this.InvUnitFactors = new List<InvUnitFactor>();
       //     this.InvUnitFactors1 = new List<InvUnitFactor>();
       //     this.ArSalesOrderDetails = new List<ArSalesOrderDetail>();
       //     this.MFWorkOrderDetails = new List<MFWorkOrderDetail>();
       //     this.ArKitItemSalesDetails = new List<ArKitItemSalesDetail>();

        }

        public int InvUnitID { get; set; }
        [DisplayName("الوحدة")]
        public string UnitName { get; set; }
        public string Notes { get; set; }
        public string UnitNameEN { get; set; }
        public string NotesEN { get; set; }
    //    public virtual ICollection<ApPriceOfferDetail> ApPriceOfferDetails { get; set; }
    //    public virtual ICollection<ArPriceOfferDetail> ArPriceOfferDetails { get; set; }
     //   public virtual ICollection<ArSalesOrderDetail> ArSalesOrderDetails { get; set; }
    //    public virtual ICollection<ApPurchasingRequestOrderDetail> ApPurchasingRequestOrderDetails { get; set; }
    //    public virtual ICollection<ArApInvoiceItem> ArApInvoiceItems { get; set; }
        public virtual ICollection<InvItem> InvItems { get; set; }
    //    public virtual ICollection<InvItemUnitFactor> InvItemUnitFactors { get; set; }
    //    public virtual ICollection<InvUnitFactor> InvUnitFactors { get; set; }
   //     public virtual ICollection<InvUnitFactor> InvUnitFactors1 { get; set; }
    //    public virtual ICollection<MFWorkOrderDetail> MFWorkOrderDetails { get; set; }
     //   public virtual ICollection<ArKitItemSalesDetail> ArKitItemSalesDetails { get; set; }
    }
}