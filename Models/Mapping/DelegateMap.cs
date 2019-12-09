using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace EdgeMobile.Models.Mapping
{
    public class DelegateMap : EntityTypeConfiguration<Delegate>
    {
        public DelegateMap()
        {
            // Primary Key
            this.HasKey(t => t.ArApDelegateID);

            // Properties
            this.Property(t => t.DelegateCode)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.DelegateName)
                .IsRequired()
                .HasMaxLength(100);

            //this.Property(t => t.DelegateNameEN)
            //    .IsRequired()
            //    .HasMaxLength(100);

            this.Property(t => t.Address)
                .HasMaxLength(100);

            this.Property(t => t.Telephone1)
                .HasMaxLength(15);

            this.Property(t => t.Telephone2)
                .HasMaxLength(15);

            this.Property(t => t.Fax)
                .HasMaxLength(15);

            this.Property(t => t.Email)
                .HasMaxLength(50);

            this.Property(t => t.BankAccountNumber)
                .HasMaxLength(50);
            this.Property(t => t.RowVersionNumber)
                .IsFixedLength()
                .HasMaxLength(8)
                .IsRowVersion();

            this.Property(t => t.RowVersionNumber)
               .IsFixedLength()
               .HasMaxLength(8)
               .IsRowVersion();

            // Table & Column Mappings
            this.ToTable("ArApDelegate");
            this.Property(t => t.ArApDelegateID).HasColumnName("ArApDelegateID");
            this.Property(t => t.DelegateCode).HasColumnName("DelegateCode");
            this.Property(t => t.DelegateName).HasColumnName("DelegateName");
            this.Property(t => t.DelegateNameEN).HasColumnName("DelegateNameEN");
            this.Property(t => t.DefEmployeeID).HasColumnName("DefEmployeeID");
            this.Property(t => t.DelegateType).HasColumnName("DelegateType");
            this.Property(t => t.DelegateFlag).HasColumnName("DelegateFlag");
            this.Property(t => t.BirthDate).HasColumnName("BirthDate");
            this.Property(t => t.NationalityID).HasColumnName("NationalityID");
            this.Property(t => t.StartDealingDate).HasColumnName("StartDealingDate");
            this.Property(t => t.Gender).HasColumnName("Gender");
            this.Property(t => t.Salary).HasColumnName("Salary");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.Telephone1).HasColumnName("Telephone1");
            this.Property(t => t.Telephone2).HasColumnName("Telephone2");
            this.Property(t => t.Fax).HasColumnName("Fax");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.BankID).HasColumnName("BankID");
            this.Property(t => t.BankAccountNumber).HasColumnName("BankAccountNumber");
            this.Property(t => t.IsCompanyEmployee).HasColumnName("IsCompanyEmployee");
            this.Property(t => t.DefBranchID).HasColumnName("DefBranchID");
            this.Property(t => t.SalesDelegateType).HasColumnName("SalesDelegateType");
            this.Property(t => t.RecordOwnerID).HasColumnName("RecordOwnerID");
            this.Property(t => t.RowVersionNumber).HasColumnName("RowVersionNumber");

            // Relationships
            this.HasRequired(t => t.Branch)
                .WithMany(t => t.Delegates)
                .HasForeignKey(d => d.DefBranchID);

        }
    }
}