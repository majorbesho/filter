using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace EdgeMobile.Models.Mapping
{
    public class InvItemBalanceEvaluateMap : EntityTypeConfiguration<InvItemBalanceEvaluate>
    {
        public InvItemBalanceEvaluateMap()
        {
            // Primary Key
            this.HasKey(t => t.InvItemBalanceEvaluateID);

            // Properties
            this.Property(t => t.BatchID)
                .HasMaxLength(15);

            this.Property(t => t.Location)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("InvItemBalanceEvaluate");
            this.Property(t => t.InvItemBalanceEvaluateID).HasColumnName("InvItemBalanceEvaluateID");
            this.Property(t => t.InvItemStoreID).HasColumnName("InvItemStoreID");
            this.Property(t => t.CostPrice).HasColumnName("CostPrice");
            this.Property(t => t.AddDate).HasColumnName("AddDate");
            this.Property(t => t.BatchID).HasColumnName("BatchID");
            this.Property(t => t.Quantity).HasColumnName("Quantity");
            this.Property(t => t.ExpiryDate).HasColumnName("ExpiryDate");
            this.Property(t => t.Location).HasColumnName("Location");
            this.Property(t => t.AveragePrice).HasColumnName("AveragePrice");
            this.Property(t => t.LastPrice).HasColumnName("LastPrice");
            this.Property(t => t.OriginalQuantity).HasColumnName("OriginalQuantity");
            this.Property(t => t.InvSizeID).HasColumnName("InvSizeID");
            this.Property(t => t.InvColorID).HasColumnName("InvColorID");
            this.Property(t => t.FreeQuantity).HasColumnName("FreeQuantity");
            this.Property(t => t.IsOpeningBalanceDetail).HasColumnName("IsOpeningBalanceDetail");

            // Relationships
            //this.HasOptional(t => t.InvColor)
            //    .WithMany(t => t.InvItemBalanceEvaluates)
            //    .HasForeignKey(d => d.InvColorID);
            //this.HasOptional(t => t.InvSize)
            //    .WithMany(t => t.InvItemBalanceEvaluates)
            //    .HasForeignKey(d => d.InvSizeID);
            this.HasRequired(t => t.InvItemStore)
                .WithMany(t => t.InvItemBalanceEvaluates)
                .HasForeignKey(d => d.InvItemStoreID);

        }
    }
}