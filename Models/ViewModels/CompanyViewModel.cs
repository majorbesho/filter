using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdgeMobile.Models.ViewModels
{
    public class CompanyViewModel
    {
        public int DefCompanyID { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string CompanyNameEN { get; set; }
        public string AddressEN { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
    }
}