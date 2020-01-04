using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EdgeMobile.Models
{
    public partial class GlCashVoucherCash
    {
        public int GlCashVoucherCID { get; set; }
        public string CashVoucherSerial { get; set; }
        public System.DateTime CashVoucherDate { get; set; }
        public Nullable<int> ArApCustomerSupplierID { get; set; }
        public int ArApDelegateID { get; set; }
        public short CashVouchertype { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:0.###}")]
        [Required(ErrorMessage = ".برجاء ادخال قيمة السند")]
        public decimal CashVoucherValue { get; set; }
        public string CashVoucherNote { get; set; }
        public Nullable<long> RecordOwnerID { get; set; }
        public byte[] RowVersionNumber { get; set; }
        public Nullable<short> IsDeleted { get; set; }
        public Nullable<short> IsPosted { get; set; }



         public virtual Customer ArApCustomerSupplier { get; set; }

        public virtual Delegate ArApDelegate { get; set; }
    }
}