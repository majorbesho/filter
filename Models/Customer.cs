using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EdgeMobile.Models
{
    public partial class Customer
    {
        public Customer()
        {
            //this.ApPriceOffers = new List<ApPriceOffer>();
            //this.ApPurchasingOrders = new List<ApPurchasingOrder>();
            //this.ApPurchasingRequests = new List<ApPurchasingRequest>();
            //this.ApPurchasingRequestOrderDetails = new List<ApPurchasingRequestOrderDetail>();
            //this.ArApInvoices = new List<ArApInvoice>();
            //this.ArApFinancialTransactions = new List<ArApFinancialTransaction>();
            //this.ArBackorders = new List<ArBackorder>();
            //this.InvItemSuppliers = new List<InvItemSupplier>();
            //this.ArPriceOffers = new List<ArPriceOffer>();
            //this.ArSalesOrders = new List<ArSalesOrder>();
            //this.MFWorkOrders = new List<MFWorkOrder>();
            //this.ArKitItemSaless = new List<ArKitItemSales>();
            this.GlCashVoucherCash = new List<GlCashVoucherCash>();


        }
        public int ArApCustomerSupplierID { get; set; }
        [Required(ErrorMessage = ".برجاء ادخال كود العميل")]
        public string CustomerSupplierCode { get; set; }
        [Required(ErrorMessage = ".برجاء ادخال اسم العميل")]
        public string CustomerSupplierName { get; set; }
        public string CustomerSupplierNameEN { get; set; }
        public int DefBranchID { get; set; }

        public Nullable<int> DefLocationID { get; set; }
        public Nullable<int> DefCurrencyID { get; set; }
        public int ArApCustomerSupplierTypeID { get; set; }
        public Nullable<int> ArApCustomerSupplierCategoryID { get; set; }
        public Nullable<long> GlAccountID { get; set; }
        public Nullable<long> GlSubAccountID { get; set; }
        public Nullable<System.DateTime> DealingStartDate { get; set; }
        public short Status { get; set; }
        public string BusinessName { get; set; }
        public string POBox { get; set; }
        public string PostalCode { get; set; }
        public string RecordTrading { get; set; }
        [Required(ErrorMessage = ".برجاء ادخال رقم الجوال")]
        [StringLength(15, MinimumLength = 9, ErrorMessage = "* .برجاء ادخال رقم الجوال")]
        [DataType(DataType.PhoneNumber)]
        public string Telephone1 { get; set; }
      

        [StringLength(15, MinimumLength = 9, ErrorMessage = "* .برجاء ادخال رقم الجوال")]
        [DataType(DataType.PhoneNumber)]
        public string Telephone2 { get; set; }
        public string Telephone3 { get; set; }
        public string Fax { get; set; }

        [DataType(DataType.EmailAddress)]
        [DisplayName("البريد الالكتروني")]
        public string Email { get; set; }
        public string ResponsibleName { get; set; }
        [Required(ErrorMessage = ".برجاء ادخال عنوان العميل")]
        public string Address { get; set; }
        public short HasCreditLimit { get; set; }
        public Nullable<decimal> CreditLimit { get; set; }
        public Nullable<decimal> InitialCredit { get; set; }
        public Nullable<int> ArApPaymentPeriodID { get; set; }
        public int ArApCustomerSupplierGroupID { get; set; }
        public short CustomerSupplierFlag { get; set; }
        public Nullable<decimal> LocalDebit { get; set; }
        public Nullable<decimal> LocalCredit { get; set; }
        public Nullable<int> ArApDelegateIDMarketing { get; set; }
        public Nullable<int> ArApDelegateID { get; set; }
        public Nullable<int> ArApDelegateIDCollection { get; set; }
        public Nullable<decimal> NotificationValueCreditLimit { get; set; }


        public Nullable<int> ArCreditTypeID { get; set; }
        public Nullable<int> ArApDiscountID { get; set; }
        public Nullable<int> CreditPeriod { get; set; }
        public Nullable<short> SellingPriceType { get; set; }
        public short PaymentMethod { get; set; }
        public Nullable<short> CustomerSupplierType { get; set; }
        public Nullable<long> RecordOwnerID { get; set; }

        //RowVersion	timestamp	Checked
        public byte[] RowVersionNumber { get; set; }
        public string Logn_line { get; set; }
        public string Latit_Line { get; set; }
        public string Logn_Latit { get; set; }







        public virtual CustomerType CustomerType { get; set; }
        public virtual Delegate ArApSalesDelegate { get; set; }
        public virtual Delegate ArApMarketingDelegate { get; set; }
        public virtual Delegate ArApCollectionDelegate { get; set; }

        //   public virtual ICollection<ArApInvoice> ArApInvoices { get; set; }
        // public virtual ArApPaymentPeriod ArApPaymentPeriod { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual DefCurrency DefCurrency { get; set; }
        public virtual DefLocation DefLocation { get; set; }
       // public virtual ICollection<InvItemSupplier> InvItemSuppliers { get; set; }
        public virtual ICollection<GlCashVoucherCash> GlCashVoucherCash { get; set; }

    }
}