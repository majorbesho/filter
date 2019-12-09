using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace EdgeMobile.Models.Mapping
{
    public class BranchMap : EntityTypeConfiguration<Branch>
    {
        public BranchMap()
        {
            // Primary Key
            this.HasKey(t => t.DefBranchID);

            // Properties
            this.Property(t => t.DefBranchID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.BranchName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.BranchNameEN)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("DefBranch");
            this.Property(t => t.DefBranchID).HasColumnName("DefBranchID");
            this.Property(t => t.BranchName).HasColumnName("BranchName");
            this.Property(t => t.Notes).HasColumnName("Notes");
            this.Property(t => t.BranchNameEN).HasColumnName("BranchNameEN");
            this.Property(t => t.NotesEN).HasColumnName("NotesEN");
            this.Property(t => t.IsMainBranch).HasColumnName("IsMainBranch");
            this.Property(t => t.DefCompanyID).HasColumnName("DefCompanyID");
            this.Property(t => t.GlAccountID).HasColumnName("GlAccountID");
            this.Property(t => t.GlAccountIDCompany).HasColumnName("GlAccountIDCompany");

            // Relationships
            this.HasRequired(t => t.Company)
                .WithMany(t => t.Branches)
                .HasForeignKey(d => d.DefCompanyID);

        }
    }
}