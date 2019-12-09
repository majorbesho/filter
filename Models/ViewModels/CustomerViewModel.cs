using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EdgeMobile.Models.ViewModels
{
    public class CustomerViewModel
    {
        public Customer customer { get; set; }
        [Key]
        public int ArApCustomerSupplierID { get; set; }
        [DisplayName("كود العميل")]
        public string CustomerSupplierCode { get; set; }
        [DisplayName("اسم العميل")]
        public string CustomerSupplierName { get; set; }
        [DisplayName("العنوان")]
        public string Address { get; set; }
        [DisplayName("جوال")]
        public string Telephone1 { get; set; }
        [DisplayName("جوال")]
        public string Telephone2 { get; set; }
       
    }
}