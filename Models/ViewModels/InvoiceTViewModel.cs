using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EdgeMobile.Models.ViewModels
{
    public class InvoiceTViewModel
    {
        [Key]
        public int ID { get; set; }
       // public InvItem invItem { get; set; }
      //  public InvUnit invUnit { get; set; }
      //  public InvItemStore invItemStore { get; set; }
        // public InvItemBalanceEvaluate InvItemBalanceEvaluate { get; set; }
     //   public InvStore invStore { get; set; }
     //   public InvGroup invGroup { get; set; }
       //  public ArApInvoiceItemTemp ArApInvoiceItemTemp { get; set; } 
        public ArApInvoiceTemp ArApInvoiceTemp { get; set; }
      
        public Delegate Delegate { get; set; }
        public Customer customer { get; set; }
        public Branch Branch { get; set; }

    
        public int ArApInvoiceID { get; set; }
        [DisplayName("رقم الفاتورة")]

       
        public string InvoiceCode { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [DisplayName("تاريخ الفاتورة")]
        [DataType(DataType.Date)]
        public DateTime InvoiceDate { get; set; }
        [DisplayName("اسم الفني")]
        public string DelegateName { get; set; }
        [DisplayName("اسم العميل")]
        public string CustomerSupplierName { get; set; }
        [DisplayName("الفرع")]
        public string BranchName { get; set; }
        [DisplayName("صافي الفاتورة")]
        public Nullable<decimal> Netprice { get; set; }
      //  public decimal NetpriceInv { get; set; }
     //   public int InvItemID { get; set; }
     //   public string ItemCode { get; set; }
      //  public string ItemName { get; set; }
    //    public int InvUnitID { get; set; }
    //    public string UnitName { get; set; }
    //    public int InvItemStoreID { get; set; }
   //     public decimal? Quantity { get; set; }
   //     public decimal? SellingPrice { get; set; }
   //     public string GroupName { get; set; }
     //   public int InvGroupID { get; set; }

    }
}