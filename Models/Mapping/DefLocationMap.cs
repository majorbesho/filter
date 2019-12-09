using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace EdgeMobile.Models.Mapping
{
    public class DefLocationMap : EntityTypeConfiguration<DefLocation>
    {
        public DefLocationMap()
        {
            // Primary Key
            this.HasKey(t => t.DefLocationID);

            // Properties
            this.Property(t => t.LocationName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.LocationNameEN)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("DefLocation");
            this.Property(t => t.DefLocationID).HasColumnName("DefLocationID");
            this.Property(t => t.LocationLevel).HasColumnName("LocationLevel");
            this.Property(t => t.DefLocationIDParent).HasColumnName("DefLocationIDParent");
            this.Property(t => t.LocationCode).HasColumnName("LocationCode");
            this.Property(t => t.LocationName).HasColumnName("LocationName");
            this.Property(t => t.LocationNameEN).HasColumnName("LocationNameEN");
            this.Property(t => t.DefLocationTypeID).HasColumnName("DefLocationTypeID");
            this.Property(t => t.IsLeaf).HasColumnName("IsLeaf");
            this.Property(t => t.Analytical).HasColumnName("Analytical");


            // Relationships
            this.HasOptional(t => t.DefLocation2)
                .WithMany(t => t.DefLocation1)
                .HasForeignKey(d => d.DefLocationIDParent);
            this.HasRequired(t => t.DefLocationType)
                .WithMany(t => t.DefLocations)
                .HasForeignKey(d => d.DefLocationTypeID);

        }
    }
}