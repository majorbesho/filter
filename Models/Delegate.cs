using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdgeMobile.Models
{
    public partial class Delegate
    {
        public Delegate()
        {
            this.ArApSalesCustomerSuppliers = new List<Customer>();
            this.ArApMarketingCustomerSuppliers = new List<Customer>();
            this.ArApCollectionCustomerSuppliers = new List<Customer>();


            //this.ArApFinancialTransactions = new List<ArApFinancialTransaction>();
            //this.ArApInvoices = new List<ArApInvoice>();
            //this.MFWorkOrders = new List<MFWorkOrder>();
            //this.ArApMarketingInvoices = new List<ArApInvoice>();
            //this.ArApCollectionInvoices = new List<ArApInvoice>();

            //this.ArBackorders = new List<ArBackorder>();
            //this.ArSalesPlanBranchProductDelegetes = new List<ArSalesPlanBranchProductDelegete>();
            //this.ArSalesPlanPeriodBranchDistributions = new List<ArSalesPlanPeriodBranchDistribution>();
           this.GlCashVoucherCash = new List<GlCashVoucherCash>();
        }

        public int ArApDelegateID { get; set; }
        public string DelegateCode { get; set; }
        public string DelegateName { get; set; }
        public string DelegateNameEN { get; set; }
        public Nullable<long> DefEmployeeID { get; set; }
        public int DelegateType { get; set; }

        public short DelegateFlag { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public Nullable<int> NationalityID { get; set; }
        public Nullable<System.DateTime> StartDealingDate { get; set; }
        public Nullable<short> Gender { get; set; }
        public Nullable<decimal> Salary { get; set; }
        public string Address { get; set; }
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public Nullable<int> BankID { get; set; }
        public string BankAccountNumber { get; set; }
        public short IsCompanyEmployee { get; set; }
        public int DefBranchID { get; set; }
        public Nullable<short> SalesDelegateType { get; set; }
        public Nullable<long> RecordOwnerID { get; set; }
        public byte[] RowVersionNumber { get; set; }

        public virtual ICollection<Customer> ArApSalesCustomerSuppliers { get; set; }
        public virtual ICollection<Customer> ArApMarketingCustomerSuppliers { get; set; }
        public virtual ICollection<Customer> ArApCollectionCustomerSuppliers { get; set; }
        public virtual Branch Branch { get; set; }
        //public virtual ICollection<ArApFinancialTransaction> ArApFinancialTransactions { get; set; }
        //public virtual ICollection<ArApInvoice> ArApInvoices { get; set; }
        //public virtual ICollection<MFWorkOrder> MFWorkOrders { get; set; }

        //public virtual ICollection<ArApInvoice> ArApMarketingInvoices { get; set; }
        //public virtual ICollection<ArApInvoice> ArApCollectionInvoices { get; set; }
        //public virtual ICollection<ArBackorder> ArBackorders { get; set; }
        public virtual ICollection<GlCashVoucherCash> GlCashVoucherCash { get; set; }

        //public virtual ICollection<ArSalesPlanBranchProductDelegete> ArSalesPlanBranchProductDelegetes { get; set; }
        //public virtual ICollection<ArSalesPlanPeriodBranchDistribution> ArSalesPlanPeriodBranchDistributions { get; set; }
    }
}