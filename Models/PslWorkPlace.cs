using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdgeMobile.Models
{
    public partial class PslWorkPlace
    {
        public PslWorkPlace()
        {
            this.DefEmployees = new List<DefEmployee>();
        }

        public int WorkPlaceCode { get; set; }
        public string WorkPlaceName { get; set; }
        public string WorkPlaceNameEN { get; set; }
        public int PslWorkPlaceID { get; set; }
        public virtual ICollection<DefEmployee> DefEmployees { get; set; }
    }
}