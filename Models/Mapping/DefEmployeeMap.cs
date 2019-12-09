using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace EdgeMobile.Models.Mapping
{
    public class DefEmployeeMap : EntityTypeConfiguration<DefEmployee>
    {
        public DefEmployeeMap()
        {
            // Primary Key
            this.HasKey(t => t.DefEmployeeID);

            // Properties
            this.Property(t => t.EmployeeName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.EmployeeNameEN)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.BirthPlace)
                .HasMaxLength(100);

            this.Property(t => t.BirthPlaceEN)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("DefEmployee");
            this.Property(t => t.DefEmployeeID).HasColumnName("DefEmployeeID");
            this.Property(t => t.EmployeeCode).HasColumnName("EmployeeCode");
            this.Property(t => t.EmployeeName).HasColumnName("EmployeeName");
            this.Property(t => t.EmployeeNameEN).HasColumnName("EmployeeNameEN");
            this.Property(t => t.BirthDate).HasColumnName("BirthDate");
            this.Property(t => t.BirthPlace).HasColumnName("BirthPlace");
            this.Property(t => t.BirthPlaceEN).HasColumnName("BirthPlaceEN");
            this.Property(t => t.PslNationalityID).HasColumnName("PslNationalityID");
            this.Property(t => t.PslSocialStatusID).HasColumnName("PslSocialStatusID");
            this.Property(t => t.DefDepartmentID).HasColumnName("DefDepartmentID");
            this.Property(t => t.PslTitleID).HasColumnName("PslTitleID");
            this.Property(t => t.DefEmployeeIDReportTo).HasColumnName("DefEmployeeIDReportTo");
            this.Property(t => t.HireDate).HasColumnName("HireDate");
            this.Property(t => t.PslCareerLevelID).HasColumnName("PslCareerLevelID");
            this.Property(t => t.Casual).HasColumnName("Casual");
            this.Property(t => t.StaffManager).HasColumnName("StaffManager");
            this.Property(t => t.ServiceChargeStatus).HasColumnName("ServiceChargeStatus");
            this.Property(t => t.DefBranchID).HasColumnName("DefBranchID");
            this.Property(t => t.PslWorkPlaceID).HasColumnName("PslWorkPlaceID");
            this.Property(t => t.InsuranceStatus).HasColumnName("InsuranceStatus");
            this.Property(t => t.MemberOfHealthInsurance).HasColumnName("MemberOfHealthInsurance");
            this.Property(t => t.InsuranceDate).HasColumnName("InsuranceDate");
            this.Property(t => t.InsuranceNo).HasColumnName("InsuranceNo");
            this.Property(t => t.PslInsuranceOfficeID).HasColumnName("PslInsuranceOfficeID");
            this.Property(t => t.FixedInsurance).HasColumnName("FixedInsurance");
            this.Property(t => t.VariableInsurance).HasColumnName("VariableInsurance");
            this.Property(t => t.EmployeeStatus).HasColumnName("EmployeeStatus");
            this.Property(t => t.DefCurrencyID).HasColumnName("DefCurrencyID");
            this.Property(t => t.EmployeeNetSalary).HasColumnName("EmployeeNetSalary");
            this.Property(t => t.GrossUpSalary).HasColumnName("GrossUpSalary");
            this.Property(t => t.TotalGross).HasColumnName("TotalGross");
            this.Property(t => t.SecurityLevelCode).HasColumnName("SecurityLevelCode");
            this.Property(t => t.EmployeePhoto).HasColumnName("EmployeePhoto");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");

            // Relationships
            //this.HasOptional(t => t.DefBranch)
            //    .WithMany(t => t.DefEmployees)
            //    .HasForeignKey(d => d.DefBranchID);
            //this.HasOptional(t => t.DefCurrency)
            //    .WithMany(t => t.DefEmployees)
            //    .HasForeignKey(d => d.DefCurrencyID);
            //this.HasOptional(t => t.DefDepartment)
            //    .WithMany(t => t.DefEmployees)
            //    .HasForeignKey(d => d.DefDepartmentID);
            //this.HasOptional(t => t.DefEmployee2)
            //    .WithMany(t => t.DefEmployee1)
            //    .HasForeignKey(d => d.DefEmployeeIDReportTo);
            //this.HasOptional(t => t.PslCareerLevel)
            //    .WithMany(t => t.DefEmployees)
            //    .HasForeignKey(d => d.PslCareerLevelID);
            //this.HasOptional(t => t.PslInsuranceOffice)
            //    .WithMany(t => t.DefEmployees)
            //    .HasForeignKey(d => d.PslInsuranceOfficeID);
            //this.HasOptional(t => t.PslNationality)
            //    .WithMany(t => t.DefEmployees)
            //    .HasForeignKey(d => d.PslNationalityID);
            //this.HasOptional(t => t.PslSocialStatu)
            //    .WithMany(t => t.DefEmployees)
            //    .HasForeignKey(d => d.PslSocialStatusID);
            //this.HasOptional(t => t.PslTitle)
            //    .WithMany(t => t.DefEmployees)
            //    .HasForeignKey(d => d.PslTitleID);
            //this.HasOptional(t => t.PslWorkPlace)
                //.WithMany(t => t.DefEmployees)
                //.HasForeignKey(d => d.PslWorkPlaceID);

        }
    }
}