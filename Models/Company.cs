using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdgeMobile.Models
{
    public partial class Company
    {

        public Company()
        {
            this.Branches = new List<Branch>();
        }

        public int DefCompanyID { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string CompanyNameEN { get; set; }
        public string AddressEN { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }
        public string NotesEN { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public string CompanyInsuranceNo { get; set; }
        public string CompanyGMName { get; set; }
        public string CompanyGMNameEN { get; set; }
        public string CompanyHRManagerName { get; set; }
        public string CompanyHRManagerNameEN { get; set; }
        public byte[] CompanyLogo { get; set; }
        public string Area { get; set; }
        public string Office { get; set; }
        public string LegalForm { get; set; }
        public string BuildingNo { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string Village { get; set; }
        public Nullable<int> DefLocationID { get; set; }
        public Nullable<decimal> DiseaseInsuranceRate { get; set; }
        public Nullable<System.DateTime> DiseaseRateStartDate { get; set; }
        public Nullable<decimal> AccidentsInsuranceRate { get; set; }
        public Nullable<System.DateTime> AccidentsRateStartDate { get; set; }
        public Nullable<System.DateTime> StopContinuationDate { get; set; }
        public string StopReason { get; set; }
        public Nullable<System.DateTime> StartActivityDate { get; set; }
        public string LegalArticle42 { get; set; }

        public virtual ICollection<Branch> Branches { get; set; }


    }
}