using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace EdgeMobile.Models.Mapping
{
    public class PslWorkPlaceMap : EntityTypeConfiguration<PslWorkPlace>
    {
        public PslWorkPlaceMap()
        {
            // Primary Key
            this.HasKey(t => t.PslWorkPlaceID);

            // Properties
            this.Property(t => t.WorkPlaceName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.WorkPlaceNameEN)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("PslWorkPlace");
            this.Property(t => t.WorkPlaceCode).HasColumnName("WorkPlaceCode");
            this.Property(t => t.WorkPlaceName).HasColumnName("WorkPlaceName");
            this.Property(t => t.WorkPlaceNameEN).HasColumnName("WorkPlaceNameEN");
            this.Property(t => t.PslWorkPlaceID).HasColumnName("PslWorkPlaceID");
        }
    }
}