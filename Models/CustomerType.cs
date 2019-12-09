using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdgeMobile.Models
{
    public partial class CustomerType
    {
        public CustomerType()
        {
            this.Customers = new List<Customer>();
        }

        public int ArApCustomerSupplierTypeID { get; set; }
        public string CustomerSupplierTypeCode { get; set; }
        public string CustomerSupplierTypeName { get; set; }
        public string CustomerSupplierTypeNameEN { get; set; }
        public short CustomerSupplierTypeFlag { get; set; }
        public Nullable<long> RecordOwnerID { get; set; }
        public byte[] RowVersionNumber { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}