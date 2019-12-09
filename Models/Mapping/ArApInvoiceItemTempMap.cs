using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace EdgeMobile.Models.Mapping
{
    class ArApInvoiceItemTempMap : EntityTypeConfiguration<ArApInvoiceItemTemp>
    {
        public ArApInvoiceItemTempMap()
        {
            // Primary Key
            this.HasKey(t => t.ArApInvoiceItemID);
            // Properties
            // Table & Column Mappings
            this.ToTable("ArApInvoiceItemTemp");
            this.Property(t => t.ArApInvoiceItemID).HasColumnName("ArApInvoiceItemID");
            this.Property(t => t.ArApInvoiceID).HasColumnName("ArApInvoiceID");
            this.Property(t => t.ArApInvoiceCode).HasColumnName("ArApInvoiceCode");
            this.Property(t => t.InvItemStoreID).HasColumnName("InvItemStoreID");
            this.Property(t => t.InvUnitID).HasColumnName("InvUnitID");
            this.Property(t => t.ConvertFactor).HasColumnName("ConvertFactor");
            this.Property(t => t.Quantity).HasColumnName("Quantity");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.EffectsValue).HasColumnName("EffectsValue");
            this.Property(t => t.NetPrice).HasColumnName("NetPrice");
            this.Property(t => t.InvoiceItemFlag).HasColumnName("InvoiceItemFlag");
            this.Property(t => t.ItemCostPrice).HasColumnName("ItemCostPrice");
            this.Property(t => t.ItemCostPriceFromSupplier).HasColumnName("ItemCostPriceFromSupplier");
            this.Property(t => t.InvSizeID).HasColumnName("InvSizeID");
            this.Property(t => t.InvColorID).HasColumnName("InvColorID");
            this.Property(t => t.ApPurchasingRequestOrderDetailID).HasColumnName("ApPurchasingRequestOrderDetailID");
            this.Property(t => t.SellingPrice).HasColumnName("SellingPrice");
            this.Property(t => t.ArSalesOrderDetailID).HasColumnName("ArSalesOrderDetailID");
            this.Property(t => t.OperationType).HasColumnName("OperationType");
            this.Property(t => t.RecordOwnerID).HasColumnName("RecordOwnerID");
            this.Property(t => t.UserID).HasColumnName("UserID");



        }
    }
}