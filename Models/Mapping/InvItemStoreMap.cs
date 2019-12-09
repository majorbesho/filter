using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace EdgeMobile.Models.Mapping
{
    public class InvItemStoreMap : EntityTypeConfiguration<InvItemStore>
    {
        public InvItemStoreMap()
        {
            // Primary Key
            this.HasKey(t => t.InvItemStoreID);

            // Properties
            this.Property(t => t.Location)
                .HasMaxLength(100);

            this.Property(t => t.Analytical)
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("InvItemStore");
            this.Property(t => t.InvItemStoreID).HasColumnName("InvItemStoreID");
            this.Property(t => t.InvStoreID).HasColumnName("InvStoreID");
            this.Property(t => t.Location).HasColumnName("Location");
            this.Property(t => t.SellingPrice).HasColumnName("SellingPrice");
            this.Property(t => t.WholeSalePrice).HasColumnName("WholeSalePrice");
            this.Property(t => t.DistributorPrice).HasColumnName("DistributorPrice");
            this.Property(t => t.OpeningBalance).HasColumnName("OpeningBalance");
            this.Property(t => t.Analytical).HasColumnName("Analytical");
            this.Property(t => t.DefBranchID).HasColumnName("DefBranchID");
            this.Property(t => t.InvItemID).HasColumnName("InvItemID");
            this.Property(t => t.RecessionPeriod).HasColumnName("RecessionPeriod");
            this.Property(t => t.MinimumLimit).HasColumnName("MinimumLimit");
            this.Property(t => t.MaximumLimit).HasColumnName("MaximumLimit");
            this.Property(t => t.ReorderLimit).HasColumnName("ReorderLimit");
            this.Property(t => t.OpeningCostPrice).HasColumnName("OpeningCostPrice");
            this.Property(t => t.OpeningLastCostPrice).HasColumnName("OpeningLastCostPrice");
            this.Property(t => t.AverageCostPrice).HasColumnName("AverageCostPrice");
            this.Property(t => t.LastCostPrice).HasColumnName("LastCostPrice");
            this.Property(t => t.ReservedQuantity).HasColumnName("ReservedQuantity");
            this.Property(t => t.PurchaseQuantity).HasColumnName("PurchaseQuantity");
            this.Property(t => t.RequestedQuantityWhenReachToReorderLimit).HasColumnName("RequestedQuantityWhenReachToReorderLimit");

            // Relationships
            this.HasRequired(t => t.InvItem)
                .WithMany(t => t.InvItemStores)
                .HasForeignKey(d => d.InvItemID);
            this.HasRequired(t => t.InvStore)
                .WithMany(t => t.InvItemStores)
                .HasForeignKey(d => d.InvStoreID);

        }
    }
}