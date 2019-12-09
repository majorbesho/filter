using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace EdgeMobile.Models.Mapping
{
    public class InvUnitMap : EntityTypeConfiguration<InvUnit>
    {
        public InvUnitMap()
        {
            // Primary Key
            this.HasKey(t => t.InvUnitID);

            // Properties
            this.Property(t => t.InvUnitID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.UnitName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.UnitNameEN)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("InvUnit");
            this.Property(t => t.InvUnitID).HasColumnName("InvUnitID");
            this.Property(t => t.UnitName).HasColumnName("UnitName");
            this.Property(t => t.Notes).HasColumnName("Notes");
            this.Property(t => t.UnitNameEN).HasColumnName("UnitNameEN");
            this.Property(t => t.NotesEN).HasColumnName("NotesEN");
        }
    }
}