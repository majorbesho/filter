using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EdgeMobile.Models.ViewModels
{
    public class InvItemViewModel
    {
        [Key]
        public int ID { get; set; }
        public InvItem invItem { get; set; }
        public InvUnit invUnit { get; set; }
        public InvItemStore invItemStore { get; set; }
        public InvItemBalanceEvaluate InvItemBalanceEvaluate { get; set; }
        public InvStore invStore { get; set; }
        public InvGroup invGroup { get; set; }





        // [Key]
        //// public int ID { get; set; }
        public int InvItemID { get; set; }
        [DisplayName("كود الصنف")]
        public string ItemCode { get; set; }
        [DisplayName("اسم الصنف")]
        public string ItemName { get; set; }
        public int InvUnitID { get; set; }
        [DisplayName("الوحدة")]
        public string UnitName { get; set; }
        public int InvItemStoreID { get; set; }
        [DisplayName("الكمية")]
        public decimal? Quantity { get; set; }
        [DisplayName("السعر")]
        public decimal? SellingPrice { get; set; }
        [DisplayName("المجموعة")]
        public string GroupName { get; set; }
        public int InvGroupID { get; set;}

    }
}