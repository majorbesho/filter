using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EdgeMobile.Models.ViewModels
{
    public class InvoiceViewModel
    {
        [Key]
        public int ID { get; set; }
        public InvItem invItem { get; set; }
        public InvUnit invUnit { get; set; }
        public InvItemStore invItemStore { get; set; }
       // public InvItemBalanceEvaluate InvItemBalanceEvaluate { get; set; }
        public InvStore invStore { get; set; }
        public InvGroup invGroup { get; set; }
   //     public ArApInvoiceTemp ArApInvoiceTemp { get; set; }
        public ArApInvoiceItemTemp ArApInvoiceItemTemp { get; set; }
        //   public Delegate Delegate { get; set; }
        //  public Customer customer { get; set; }
        // public Branch Branch { get; set; }


        //inv.InvoiceCode,
        //                       inv.InvoiceDate,
        //                       inv.Netprice,
        //                       items.ItemCode,
        //                       items.ItemName,
        //                       invitem.Quantity,
        //                       invitem.SellingPrice,
        //                       invitem.NetPrice,
        //                       delc.DelegateName,
        //                       bran.BranchName,
        //                       cust.CustomerSupplierName,
        //                       grp.GroupName

            public int ArApInvoiceID { get; set; }
          public string InvoiceCode { get; set; }
        //  public DateTime InvoiceDate { get; set; }
        [DisplayName("اجمالي السعر")]
        public decimal Netprice { get; set; }
       // public decimal NetpriceInv { get; set; }
        public int InvItemID { get; set; }
        [DisplayName("كود الصنف")]
        public string ItemCode { get; set; }
        [DisplayName("اسم الصنف")]
        public string ItemName { get; set; }
        public int InvUnitID { get; set; }
        [DisplayName("الوحدة")]
        public string UnitName { get; set; }
        public int InvItemStoreID { get; set; }
        [DisplayName("الكمية")]
        public decimal? Quantity { get; set; }
        [DisplayName("السعر")]
        public decimal? SellingPrice { get; set; }
        [DisplayName("المجموعة")]
        public string GroupName { get; set; }
        public int InvGroupID { get; set; }
    //    public string DelegateName { get; set; }
  //      public string CustomerSupplierName { get; set; }
//        public string BranchName { get; set; }

    }
}