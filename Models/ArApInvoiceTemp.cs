using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EdgeMobile.Models
{
    [Table("ArApInvoiceTemp")]
    public partial class ArApInvoiceTemp
    {
       
        public ArApInvoiceTemp()
        {
        //    this.ArApActualPaymentPeriods = new List<ArApActualPaymentPeriod>();
        //    this.ArApFinancialTransactions = new List<ArApFinancialTransaction>();
        //    this.ArApInvoiceEffects = new List<ArApInvoiceEffect>();
            this.ArApInvoiceItemTemp = new List<ArApInvoiceItemTemp>();
            // this.ArBackorders = new List<ArBackorder>();
            // this.MFWorkOrders = new List<MFWorkOrder>();
            InvoiceDate = DateTime.Now;
        }

        //public DateTime _SetDefaultDate = DateTime.Now;

        //public DateTime UserDefaultDate
        //{
        //    get
        //    {
        //        return _SetDefaultDate;
        //    }
        //    set
        //    {
        //        _SetDefaultDate = value;
        //    }
        //}

        [Key]
        public int ArApInvoiceID { get; set; }
        [DisplayName("رقم الفاتورة")]
        public string InvoiceCode { get; set; }
        public int DefBranchID { get; set; }

        [DisplayName("التاريخ")]
        public System.DateTime InvoiceDate { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
        public short TransactionType { get; set; }
        public Nullable<int> ArApReturnInvoiceID { get; set; }
        public int InvStoreID { get; set; }
        public short PaymentMethod { get; set; }
        public Nullable<int> ArApCustomerSupplierID { get; set; }
        public Nullable<int> ArApInvoiceTypeID { get; set; }
        public Nullable<int> ArApSupplyOrderID { get; set; }
        public Nullable<int> DefCurrencyID { get; set; }
        public Nullable<decimal> ExchangeRate { get; set; }
        public Nullable<int> ArApDelegateIDMarketing { get; set; }
        public int ArApDelegateID { get; set; }
        public Nullable<int> ArApDelegateIDCollection { get; set; }
        [DisplayName("ملاحظات")]
        public string Note { get; set; }
        public short InvoiceFlag { get; set; }
        [DisplayName("صافي الفاتورة")]
        public decimal? Netprice { get; set; }
        public Nullable<int> CreditPeriod { get; set; }
        public Nullable<int> ApPurchasingOrderID { get; set; }
        public Nullable<int> ApPurchasingRequestID { get; set; }
        public Nullable<int> ApPriceOfferID { get; set; }
        public decimal TotalDiscountPercentage { get; set; }
        public decimal TotalDiscountValue { get; set; }
        public decimal TotalEffectsValue { get; set; }
        public decimal TotalPrice { get; set; }
        public Nullable<int> ArApDiscountID { get; set; }
        public Nullable<short> IsTotalsClaimCalculated { get; set; }
        public Nullable<decimal> TotalSupplierEffectsValue { get; set; }
        public Nullable<int> GlJournalID { get; set; }
        public Nullable<int> JournalSerial { get; set; }
        public Nullable<int> ArPurposeOfIssueID { get; set; }
        public Nullable<int> ArSalesOrderID { get; set; }
        public Nullable<int> ArPriceOfferID { get; set; }
        public Nullable<short> IsIssueTransactions { get; set; }
        public string recipient { get; set; }
        public Nullable<int> InvoiceID { get; set; }
        public Nullable<long> RecordOwnerID { get; set; }
        public byte[] RowVersionNumber { get; set; }
        public Nullable<decimal> Amountpaid { get; set; }
        public Nullable<decimal> RemainingAmount { get; set; }
        public Nullable<int> ArWindowShowTypeID { get; set; }


    //    public virtual ICollection<MFWorkOrder> MFWorkOrders { get; set; }
    //   public virtual ICollection<ArApActualPaymentPeriod> ArApActualPaymentPeriods { get; set; }
      public virtual Customer ArApCustomerSupplier { get; set; }
   ///     public virtual ArApDelegate ArApDelegate { get; set; }
   //     public virtual ArApDelegate ArApMarketingDelegate { get; set; }
    //    public virtual ArApDelegate ArApCollectionDelegate { get; set; }
  //      public virtual ICollection<ArApFinancialTransaction> ArApFinancialTransactions { get; set; }
    //    public virtual ArApInvoiceType ArApInvoiceType { get; set; }
        public virtual Branch DefBranch { get; set; }
        public virtual DefCurrency DefCurrency { get; set; }
        public virtual InvStore InvStore { get; set; }
   //     public virtual ApPurchasingOrder ApPurchasingOrder { get; set; }
   //     public virtual ArSalesOrder ArSalesOrder { get; set; }
  //      public virtual ArPriceOffer ArPriceOffer { get; set; }
  //      public virtual ApPurchasingRequest ApPurchasingRequest { get; set; }
  //      public virtual ApPriceOffer ApPriceOffer { get; set; }
  //      public virtual ICollection<ArApInvoiceEffect> ArApInvoiceEffects { get; set; }
        public virtual ICollection<ArApInvoiceItemTemp> ArApInvoiceItemTemp { get; set; }
    //    public virtual ICollection<ArBackorder> ArBackorders { get; set; }
     //   public virtual ArPurposeOfIssue ArPurposeOfIssue { get; set; }

    }
}