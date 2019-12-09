using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace EdgeMobile.Models.Mapping
{
    class GlCashVoucherCashMap : EntityTypeConfiguration<GlCashVoucherCash>
    {
        public GlCashVoucherCashMap()
        {
            // Primary Key
            this.HasKey(t => t.GlCashVoucherCID);


            this.Property(t => t.RowVersionNumber)
             .IsFixedLength()
             .HasMaxLength(8)
             .IsRowVersion();

            this.ToTable("GlCashVoucherCash");

            this.Property(t => t.GlCashVoucherCID).HasColumnName("GlCashVoucherCID");
            this.Property(t => t.CashVoucherSerial).HasColumnName("CashVoucherSerial");
            this.Property(t => t.CashVoucherDate).HasColumnName("CashVoucherDate");
            this.Property(t => t.ArApCustomerSupplierID).HasColumnName("ArApCustomerSupplierID");
            this.Property(t => t.ArApDelegateID).HasColumnName("ArApDelegateID");
            this.Property(t => t.CashVouchertype).HasColumnName("CashVouchertype");
            this.Property(t => t.CashVoucherValue).HasColumnName("CashVoucherValue");
            this.Property(t => t.CashVoucherNote).HasColumnName("CashVoucherNote");
            this.Property(t => t.RecordOwnerID).HasColumnName("RecordOwnerID");
            this.Property(t => t.RowVersionNumber).HasColumnName("RowVersionNumber");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");
            this.Property(t => t.IsPosted).HasColumnName("IsPosted");



            // Relationships
            this.HasOptional(t => t.ArApCustomerSupplier)
                .WithMany(t => t.GlCashVoucherCash)
                .HasForeignKey(d => d.ArApCustomerSupplierID);

            this.HasRequired(t => t.ArApDelegate)
                .WithMany(t => t.GlCashVoucherCash)
                .HasForeignKey(d => d.ArApDelegateID);

        }
    }
}