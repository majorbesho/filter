using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdgeMobile.Models
{
    public partial class Branch
    {
        public Branch()
        {
            //this.ApPurchasingOrders = new List<ApPurchasingOrder>();
            //this.ApPurchasingRequests = new List<ApPurchasingRequest>();
           this.Customers = new List<Customer>();
            //this.ArApDelegates = new List<ArApDelegate>();
            //this.ArApFinancialTransactions = new List<ArApFinancialTransaction>();
            //this.ArApInvoices = new List<ArApInvoice>();
            //this.ArSalesPeriodBranches = new List<ArSalesPeriodBranch>();
            //this.DefEmployees = new List<DefEmployee>();
            //this.DefDepartments = new List<DefDepartment>();
            //this.GlAccounts = new List<GlAccount>();
            //this.GlAccountBranches = new List<GlAccountBranch>();
            //this.GlAccountSubAccountBranches = new List<GlAccountSubAccountBranch>();
            //this.GlBankTransactions = new List<GlBankTransaction>();
            //this.GlBranchTransactions = new List<GlBranchTransaction>();
            //this.GlBranchTransactions1 = new List<GlBranchTransaction>();
            //this.GlCashVouchers = new List<GlCashVoucher>();
            //this.GlJournals = new List<GlJournal>();
            //this.GlMonthlyAccountSubAccountBranches = new List<GlMonthlyAccountSubAccountBranch>();
            //this.GlSafes = new List<GlSafe>();
            //this.GlSafeTransactions = new List<GlSafeTransaction>();
            //this.GlSubAccountBranches = new List<GlSubAccountBranch>();
            this.InvStores = new List<InvStore>();
            //this.ArPriceOffers = new List<ArPriceOffer>();
            //this.ArSalesOrders = new List<ArSalesOrder>();
            //this.MFWorkOrders = new List<MFWorkOrder>();
            //this.ArKitItemSaless = new List<ArKitItemSales>();
        }

        public int DefBranchID { get; set; }
        public string BranchName { get; set; }
        public string Notes { get; set; }
        public string BranchNameEN { get; set; }
        public string NotesEN { get; set; }
        public int IsMainBranch { get; set; }
        public int DefCompanyID { get; set; }
        public Nullable<long> GlAccountID { get; set; }
        public Nullable<long> GlAccountIDCompany { get; set; }

        //public virtual ICollection<MFWorkOrder> MFWorkOrders { get; set; }
        //public virtual ICollection<ArKitItemSales> ArKitItemSaless { get; set; }
        //public virtual ICollection<ApPurchasingOrder> ApPurchasingOrders { get; set; }
        //public virtual ICollection<ApPurchasingRequest> ApPurchasingRequests { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Delegate> Delegates { get; set; }
        //public virtual ICollection<ArApFinancialTransaction> ArApFinancialTransactions { get; set; }
        //public virtual ICollection<ArApInvoice> ArApInvoices { get; set; }
        //public virtual ICollection<ArSalesPeriodBranch> ArSalesPeriodBranches { get; set; }
        //public virtual ICollection<DefEmployee> DefEmployees { get; set; }
        public virtual Company Company { get; set; }
        //public virtual ICollection<DefDepartment> DefDepartments { get; set; }
        //public virtual ICollection<GlAccount> GlAccounts { get; set; }
        //public virtual ICollection<GlAccountBranch> GlAccountBranches { get; set; }
        //public virtual ICollection<GlAccountSubAccountBranch> GlAccountSubAccountBranches { get; set; }
        //public virtual ICollection<GlBankTransaction> GlBankTransactions { get; set; }
        //public virtual ICollection<GlBranchTransaction> GlBranchTransactions { get; set; }
        //public virtual ICollection<GlBranchTransaction> GlBranchTransactions1 { get; set; }
        //public virtual ICollection<GlCashVoucher> GlCashVouchers { get; set; }
        //public virtual ICollection<GlJournal> GlJournals { get; set; }
        //public virtual ICollection<GlMonthlyAccountSubAccountBranch> GlMonthlyAccountSubAccountBranches { get; set; }
        //public virtual ICollection<GlSafe> GlSafes { get; set; }
        //public virtual ICollection<GlSafeTransaction> GlSafeTransactions { get; set; }
        //public virtual ICollection<GlSubAccountBranch> GlSubAccountBranches { get; set; }
        public virtual ICollection<InvStore> InvStores { get; set; }
       // public virtual ICollection<ArPriceOffer> ArPriceOffers { get; set; }
       // public virtual ICollection<ArSalesOrder> ArSalesOrders { get; set; }


       // public virtual ICollection<FaSite> FaSites { get; set; }

    }
}