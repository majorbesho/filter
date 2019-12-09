using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace EdgeMobile.Models.Mapping
{
    public class CompanyMap : EntityTypeConfiguration<Company>
    {
        public CompanyMap()
        {
            // Primary Key
            this.HasKey(t => t.DefCompanyID);

            // Properties
            this.Property(t => t.CompanyName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.CompanyNameEN)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Telephone)
                .HasMaxLength(20);

            this.Property(t => t.Fax)
                .HasMaxLength(20);

            this.Property(t => t.Email)
                .HasMaxLength(100);

            this.Property(t => t.CompanyInsuranceNo)
                .HasMaxLength(50);

            this.Property(t => t.CompanyGMName)
                .HasMaxLength(100);

            this.Property(t => t.CompanyGMNameEN)
                .HasMaxLength(100);

            this.Property(t => t.CompanyHRManagerName)
                .HasMaxLength(100);

            this.Property(t => t.CompanyHRManagerNameEN)
                .HasMaxLength(100);

            this.Property(t => t.Area)
                .HasMaxLength(50);

            this.Property(t => t.Office)
                .HasMaxLength(50);

            this.Property(t => t.LegalForm)
                .HasMaxLength(50);

            this.Property(t => t.BuildingNo)
                .HasMaxLength(50);

            this.Property(t => t.StreetName)
                .HasMaxLength(50);

            this.Property(t => t.City)
                .HasMaxLength(50);

            this.Property(t => t.Village)
                .HasMaxLength(50);

            this.Property(t => t.StopReason)
                .HasMaxLength(50);

            this.Property(t => t.LegalArticle42)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("DefCompany");
            this.Property(t => t.DefCompanyID).HasColumnName("DefCompanyID");
            this.Property(t => t.CompanyName).HasColumnName("CompanyName");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.CompanyNameEN).HasColumnName("CompanyNameEN");
            this.Property(t => t.AddressEN).HasColumnName("AddressEN");
            this.Property(t => t.Telephone).HasColumnName("Telephone");
            this.Property(t => t.Fax).HasColumnName("Fax");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Notes).HasColumnName("Notes");
            this.Property(t => t.NotesEN).HasColumnName("NotesEN");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.CompanyInsuranceNo).HasColumnName("CompanyInsuranceNo");
            this.Property(t => t.CompanyGMName).HasColumnName("CompanyGMName");
            this.Property(t => t.CompanyGMNameEN).HasColumnName("CompanyGMNameEN");
            this.Property(t => t.CompanyHRManagerName).HasColumnName("CompanyHRManagerName");
            this.Property(t => t.CompanyHRManagerNameEN).HasColumnName("CompanyHRManagerNameEN");
            this.Property(t => t.CompanyLogo).HasColumnName("CompanyLogo");
            this.Property(t => t.Area).HasColumnName("Area");
            this.Property(t => t.Office).HasColumnName("Office");
            this.Property(t => t.LegalForm).HasColumnName("LegalForm");
            this.Property(t => t.BuildingNo).HasColumnName("BuildingNo");
            this.Property(t => t.StreetName).HasColumnName("StreetName");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.Village).HasColumnName("Village");
            this.Property(t => t.DefLocationID).HasColumnName("DefLocationID");
            this.Property(t => t.DiseaseInsuranceRate).HasColumnName("DiseaseInsuranceRate");
            this.Property(t => t.DiseaseRateStartDate).HasColumnName("DiseaseRateStartDate");
            this.Property(t => t.AccidentsInsuranceRate).HasColumnName("AccidentsInsuranceRate");
            this.Property(t => t.AccidentsRateStartDate).HasColumnName("AccidentsRateStartDate");
            this.Property(t => t.StopContinuationDate).HasColumnName("StopContinuationDate");
            this.Property(t => t.StopReason).HasColumnName("StopReason");
            this.Property(t => t.StartActivityDate).HasColumnName("StartActivityDate");
            this.Property(t => t.LegalArticle42).HasColumnName("LegalArticle42");
        }
    }
}