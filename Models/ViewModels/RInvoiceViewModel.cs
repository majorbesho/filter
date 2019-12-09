using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdgeMobile.Models.ViewModels
{
    public class RInvoiceViewModel
    {
        public int InvoiceID { get; set; }
        public string InvoiceCode { get; set; }
        public DateTime InvoiceDate { get; set; }

        //  [DisplayName("اجمالي السعر")]
        //public decimal NetpriceInv { get; set; }

        public int ArApCustomerSupplierID { get; set; }
        public string CustomerSupplierName { get; set; }
        public string CustomerSupplierCode { get; set; }
        public int ArApDelegateID { get; set; }
        public string DelegateName { get; set; }

        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        // public string UnitName { get; set; }
        // public String ItemDetails { get; set; } // BatchNo - ExpiryDate - CompanyName
        public decimal Quantity { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal Netprice { get; set; }
    }
}