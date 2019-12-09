using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdgeMobile.Models
{
    public partial class DefCurrency
    {
        public DefCurrency()
        {
            //this.ApPurchasingOrders = new List<ApPurchasingOrder>();
            //this.ApPurchasingRequests = new List<ApPurchasingRequest>();
            //this.ApPurchasingRequestOrderDetails = new List<ApPurchasingRequestOrderDetail>();
            //this.ArApCustomerSuppliers = new List<ArApCustomerSupplier>();
            //this.ArApInvoices = new List<ArApInvoice>();
            //this.DefEmployees = new List<DefEmployee>();
            //this.PrlCurrencyRates = new List<PrlCurrencyRate>();
            //this.DefGlobalApplicationConfigurations = new List<DefGlobalApplicationConfiguration>();
            //this.GlAccounts = new List<GlAccount>();
            //this.GlBankAccounts = new List<GlBankAccount>();
            //this.GlBankTransactions = new List<GlBankTransaction>();
            //this.GlCashVoucherDetails = new List<GlCashVoucherDetail>();
            //this.GlCustodies = new List<GlCustody>();
            //this.GlJournalDetails = new List<GlJournalDetail>();
            //this.GlSubAccounts = new List<GlSubAccount>();
        }

        public int DefCurrencyID { get; set; }
        public string CurrencyName { get; set; }
        public decimal ExchangeRate { get; set; }
        public string PettyName { get; set; }
        public string Symbol { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> DefAnalyticalID { get; set; }
        public string Notes { get; set; }
        public string CurrencyNameEN { get; set; }
        public string PettyNameEN { get; set; }
        public string SymbolEN { get; set; }
        public string NotesEN { get; set; }
        //public virtual ICollection<ApPurchasingOrder> ApPurchasingOrders { get; set; }
        //public virtual ICollection<ApPurchasingRequest> ApPurchasingRequests { get; set; }
        //public virtual ICollection<ApPurchasingRequestOrderDetail> ApPurchasingRequestOrderDetails { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        //public virtual ICollection<ArApInvoice> ArApInvoices { get; set; }
        //public virtual DefAnalytical DefAnalytical { get; set; }
        //public virtual ICollection<DefEmployee> DefEmployees { get; set; }
        //public virtual ICollection<PrlCurrencyRate> PrlCurrencyRates { get; set; }
        //public virtual ICollection<DefGlobalApplicationConfiguration> DefGlobalApplicationConfigurations { get; set; }
        //public virtual ICollection<GlAccount> GlAccounts { get; set; }
        //public virtual ICollection<GlBankAccount> GlBankAccounts { get; set; }
        //public virtual ICollection<GlBankTransaction> GlBankTransactions { get; set; }
        //public virtual ICollection<GlCashVoucherDetail> GlCashVoucherDetails { get; set; }
        //public virtual ICollection<GlCustody> GlCustodies { get; set; }
        //public virtual ICollection<GlJournalDetail> GlJournalDetails { get; set; }
        //public virtual ICollection<GlSubAccount> GlSubAccounts { get; set; }
    }
}