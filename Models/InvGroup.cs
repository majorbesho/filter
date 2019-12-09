using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace EdgeMobile.Models
{
    public partial class InvGroup
    {
        public InvGroup()
        {
            this.InvGroup1 = new List<InvGroup>();
            this.InvItems = new List<InvItem>();
        }

        public int InvGroupID { get; set; }
        [DisplayName("المجموعة")]
        public string GroupName { get; set; }
        public string Notes { get; set; }
        public string GroupNameEN { get; set; }
        public string NotesEN { get; set; }
        public Nullable<int> ParentID { get; set; }
        public byte[] PhotoG { get; set; }
        public virtual ICollection<InvGroup> InvGroup1 { get; set; }
        public virtual InvGroup InvGroup2 { get; set; }
        public virtual ICollection<InvItem> InvItems { get; set; }
    }
}