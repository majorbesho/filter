using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace EdgeMobile.Models.Mapping
{
    public class InvGroupMap : EntityTypeConfiguration<InvGroup>
    {
        public InvGroupMap()
        {
            // Primary Key
            this.HasKey(t => t.InvGroupID);

            // Properties
            this.Property(t => t.InvGroupID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.GroupName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.GroupNameEN)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("InvGroup");
            this.Property(t => t.InvGroupID).HasColumnName("InvGroupID");
            this.Property(t => t.GroupName).HasColumnName("GroupName");
            this.Property(t => t.Notes).HasColumnName("Notes");
            this.Property(t => t.GroupNameEN).HasColumnName("GroupNameEN");
            this.Property(t => t.NotesEN).HasColumnName("NotesEN");
            this.Property(t => t.ParentID).HasColumnName("ParentID");
            this.Property(t => t.PhotoG).HasColumnName("PhotoG");


            // Relationships
            this.HasOptional(t => t.InvGroup2)
                .WithMany(t => t.InvGroup1)
                .HasForeignKey(d => d.ParentID);

        }
    }
}