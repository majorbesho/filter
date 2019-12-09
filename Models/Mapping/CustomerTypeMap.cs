using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace EdgeMobile.Models.Mapping
{
    public class CustomerTypeMap : EntityTypeConfiguration<CustomerType>
    {
        public CustomerTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.ArApCustomerSupplierTypeID);

            // Properties
            this.Property(t => t.CustomerSupplierTypeCode)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.CustomerSupplierTypeName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.CustomerSupplierTypeNameEN)
                .IsRequired()
                .HasMaxLength(100);
            this.Property(t => t.RowVersionNumber)
                .IsFixedLength()
                .HasMaxLength(8)
                .IsRowVersion();

            this.Property(t => t.RowVersionNumber)
               .IsFixedLength()
               .HasMaxLength(8)
               .IsRowVersion();

            // Table & Column Mappings
            this.ToTable("ArApCustomerSupplierType");
            this.Property(t => t.ArApCustomerSupplierTypeID).HasColumnName("ArApCustomerSupplierTypeID");
            this.Property(t => t.CustomerSupplierTypeCode).HasColumnName("CustomerSupplierTypeCode");
            this.Property(t => t.CustomerSupplierTypeName).HasColumnName("CustomerSupplierTypeName");
            this.Property(t => t.CustomerSupplierTypeNameEN).HasColumnName("CustomerSupplierTypeNameEN");
            this.Property(t => t.CustomerSupplierTypeFlag).HasColumnName("CustomerSupplierTypeFlag");
            this.Property(t => t.RecordOwnerID).HasColumnName("RecordOwnerID");
            this.Property(t => t.RowVersionNumber).HasColumnName("RowVersionNumber");
        }
    }
}