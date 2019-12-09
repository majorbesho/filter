using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdgeMobile.Models.ViewModels
{
    public class RepCashVoucher
    {
        public int GlCashVoucherCID { get; set; }
        public string CashVoucherSerial { get; set; }
        public System.DateTime CashVoucherDate { get; set; }
        public int ArApCustomerSupplierID { get; set; }
        public string CustomerSupplierName { get; set; }
        public int ArApDelegateID { get; set; }
       
        public decimal CashVoucherValue { get; set; }
        public string CashVoucherNote { get; set; }

    }
}