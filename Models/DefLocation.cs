using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdgeMobile.Models
{
    public partial class DefLocation
    {
        public DefLocation()
        {
            this.Customers = new List<Customer>();
            this.DefLocation1 = new List<DefLocation>();
            //this.PslCompanies = new List<PslCompany>();
            //this.PslEmployees = new List<PslEmployee>();
        }

        public int DefLocationID { get; set; }
        public int LocationLevel { get; set; }
        public Nullable<int> DefLocationIDParent { get; set; }
        public int LocationCode { get; set; }
        public string LocationName { get; set; }
        public string LocationNameEN { get; set; }
        public int DefLocationTypeID { get; set; }
        public Nullable<short> IsLeaf { get; set; }
        public string Analytical { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<DefLocation> DefLocation1 { get; set; }
        public virtual DefLocation DefLocation2 { get; set; }
        //public virtual ICollection<PslCompany> PslCompanies { get; set; }
        //public virtual ICollection<PslEmployee> PslEmployees { get; set; }
        public virtual DefLocationType DefLocationType { get; set; }
    }
}