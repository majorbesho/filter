using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EdgeMobile.Models.ViewModels
{
    public class InvGroupViewModel
    {
        [Key]
        public int InvGroupID { get; set; }
        [UIHint("GroupName")]
        public string GroupName { get; set; }
        public string Notes { get; set; }
        public string GroupNameEN { get; set; }
        public string NotesEN { get; set; }
        public Nullable<int> ParentID { get; set; }
        public string ParentName { get; set; }
    }
}