using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace EdgeMobile.Models.Mapping
{
    public class InvItemMap : EntityTypeConfiguration<InvItem>
    {
        public InvItemMap()
        {
            // Primary Key
            this.HasKey(t => t.InvItemID);

            // Properties
            this.Property(t => t.ItemCode)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.ItemName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.ItemNameEN)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.ItemAnalytical)
                .HasMaxLength(10);

            this.Property(t => t.ShortName)
                .HasMaxLength(15);

            this.Property(t => t.ShortNameEN)
                .HasMaxLength(15);

            this.Property(t => t.PackageName)
                .HasMaxLength(15);

            this.Property(t => t.PackageNameEN)
                .HasMaxLength(15);

            this.Property(t => t.PackageSize)
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("InvItem");
            this.Property(t => t.InvItemID).HasColumnName("InvItemID");
            this.Property(t => t.ItemCode).HasColumnName("ItemCode");
            this.Property(t => t.ItemName).HasColumnName("ItemName");
            this.Property(t => t.ItemNameEN).HasColumnName("ItemNameEN");
            this.Property(t => t.InvGroupID).HasColumnName("InvGroupID");
            this.Property(t => t.InvUnitID).HasColumnName("InvUnitID");
            this.Property(t => t.HasExpierDate).HasColumnName("HasExpierDate");
            this.Property(t => t.IsKit).HasColumnName("IsKit");
            this.Property(t => t.HasSerialNo).HasColumnName("HasSerialNo");
            this.Property(t => t.ItemAnalytical).HasColumnName("ItemAnalytical");
            this.Property(t => t.ShortName).HasColumnName("ShortName");
            this.Property(t => t.ShortNameEN).HasColumnName("ShortNameEN");
            this.Property(t => t.PackageName).HasColumnName("PackageName");
            this.Property(t => t.PackageNameEN).HasColumnName("PackageNameEN");
            this.Property(t => t.PackageSize).HasColumnName("PackageSize");
            this.Property(t => t.SalesWarranty).HasColumnName("SalesWarranty");
            this.Property(t => t.PurchaseWarranty).HasColumnName("PurchaseWarranty");
            this.Property(t => t.ExtendedName).HasColumnName("ExtendedName");
            this.Property(t => t.ExtendedNameEN).HasColumnName("ExtendedNameEN");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.IsReturned).HasColumnName("IsReturned");
            this.Property(t => t.PeriodOfReturn).HasColumnName("PeriodOfReturn");
            this.Property(t => t.SellingPriceType).HasColumnName("SellingPriceType");
            this.Property(t => t.SellingPrice).HasColumnName("SellingPrice");
            this.Property(t => t.WholeSaleType).HasColumnName("WholeSaleType");
            this.Property(t => t.WholeSalePrice).HasColumnName("WholeSalePrice");
            this.Property(t => t.DistributorPriceType).HasColumnName("DistributorPriceType");
            this.Property(t => t.DistributorPrice).HasColumnName("DistributorPrice");
            this.Property(t => t.IsColored).HasColumnName("IsColored");
            this.Property(t => t.NotificationValueExpireDate).HasColumnName("NotificationValueExpireDate");
            this.Property(t => t.ItemType).HasColumnName("ItemType");
            this.Property(t => t.TransferePrice).HasColumnName("TransferePrice");


            this.Property(t => t.GuideCostPrice).HasColumnName("GuideCostPrice");

            // Relationships
            this.HasRequired(t => t.InvGroup)
                .WithMany(t => t.InvItems)
                .HasForeignKey(d => d.InvGroupID);
            //this.HasOptional(t => t.InvUnit)
            //    .WithMany(t => t.InvItems)
            //    .HasForeignKey(d => d.InvUnitID);

        }
    }
}