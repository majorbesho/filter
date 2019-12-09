using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace EdgeMobile.Models.Mapping
{
    public class InvStoreMap : EntityTypeConfiguration<InvStore>
    {
        public InvStoreMap()
        {
            // Primary Key
            this.HasKey(t => t.InvStoreID);

            // Properties
            this.Property(t => t.InvStoreID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.StoreName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.StoreNameEN)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("InvStore");
            this.Property(t => t.InvStoreID).HasColumnName("InvStoreID");
            this.Property(t => t.StoreName).HasColumnName("StoreName");
            this.Property(t => t.Notes).HasColumnName("Notes");
            this.Property(t => t.DefBranchID).HasColumnName("DefBranchID");
            this.Property(t => t.StoreNameEN).HasColumnName("StoreNameEN");
            this.Property(t => t.NotesEN).HasColumnName("NotesEN");
            this.Property(t => t.GlStoreAccountID).HasColumnName("GlStoreAccountID");
            this.Property(t => t.GlStoreCostAccountID).HasColumnName("GlStoreCostAccountID");

            // Relationships
            this.HasRequired(t => t.Branch)
                .WithMany(t => t.InvStores)
                .HasForeignKey(d => d.DefBranchID);

        }
    }
}