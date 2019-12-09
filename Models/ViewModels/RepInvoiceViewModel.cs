using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EdgeMobile.Models.ViewModels
{
    public class RepInvoiceViewModel
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
        public decimal? SellingPrice { get; set; }
        public decimal Netprice { get; set; }
        public List<ArInvoiceDetailsReportModel> InvoiceDetails { get; set; }
    }
    public class ArInvoiceDetailsReportModel
    {
        public int? RowSerialNumberDynamic { get; set; }// return ToknowRowNumber(); } // set { x++; } 

        public int InvoiceID { get; set; }
        public string InvoiceCode { get; set; }
        public DateTime InvoiceDate { get; set; }

        [DisplayName("اجمالي السعر")]
        public decimal NetpriceInv { get; set; }

        public int ArApCustomerSupplierID { get; set; }
        public string CustomerSupplierName { get; set; }
        public string CustomerSupplierCode { get; set; }
        public int ArApDelegateID { get; set; }
        public string DelegateName { get; set; }

      //  public int InvoiceID { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
       // public string UnitName { get; set; }
       // public String ItemDetails { get; set; } // BatchNo - ExpiryDate - CompanyName
        public decimal Quantity { get; set; }
        public decimal? SellingPrice { get; set; }
        public decimal Netprice { get; set; }
      
        
    }
}