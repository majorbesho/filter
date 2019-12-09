using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdgeMobile.Models
{
    public partial class DefLocationType
    {
        public DefLocationType()
        {
            this.DefLocations = new List<DefLocation>();
        }

        public int DefLocationTypeID { get; set; }
        public int LocationTypeCode { get; set; }
        public string LocationTypeName { get; set; }
        public string LocationTypeNameEN { get; set; }
        public virtual ICollection<DefLocation> DefLocations { get; set; }
    }
}