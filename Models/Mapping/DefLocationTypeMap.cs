using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace EdgeMobile.Models.Mapping
{
    public class DefLocationTypeMap : EntityTypeConfiguration<DefLocationType>
    {
        public DefLocationTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.DefLocationTypeID);

            // Properties
            this.Property(t => t.LocationTypeName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.LocationTypeNameEN)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("DefLocationType");
            this.Property(t => t.DefLocationTypeID).HasColumnName("DefLocationTypeID");
            this.Property(t => t.LocationTypeCode).HasColumnName("LocationTypeCode");
            this.Property(t => t.LocationTypeName).HasColumnName("LocationTypeName");
            this.Property(t => t.LocationTypeNameEN).HasColumnName("LocationTypeNameEN");
        }
    }
}