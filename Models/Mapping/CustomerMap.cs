using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace EdgeMobile.Models.Mapping
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            // Primary Key
            this.HasKey(t => t.ArApCustomerSupplierID);

            // Properties
            this.Property(t => t.CustomerSupplierCode)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.CustomerSupplierName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.CustomerSupplierNameEN)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.BusinessName)
                .HasMaxLength(100);

            this.Property(t => t.POBox)
                .HasMaxLength(50);

            this.Property(t => t.PostalCode)
                .HasMaxLength(50);

            this.Property(t => t.RecordTrading)
                .HasMaxLength(50);

            this.Property(t => t.Telephone1)
                .HasMaxLength(15);

            this.Property(t => t.Telephone2)
                .HasMaxLength(15);

            this.Property(t => t.Telephone3)
                .HasMaxLength(15);

            this.Property(t => t.Fax)
                .HasMaxLength(15);

            this.Property(t => t.Email)
                .HasMaxLength(50);

            this.Property(t => t.ResponsibleName)
                .HasMaxLength(100);

            this.Property(t => t.Address)
                .HasMaxLength(50);

            this.Property(t => t.RowVersionNumber)
                .IsFixedLength()
                .HasMaxLength(8)
                .IsRowVersion();


            // Table & Column Mappings
            this.ToTable("ArApCustomerSupplier");
            this.Property(t => t.ArApCustomerSupplierID).HasColumnName("ArApCustomerSupplierID");
            this.Property(t => t.CustomerSupplierCode).HasColumnName("CustomerSupplierCode");
            this.Property(t => t.CustomerSupplierName).HasColumnName("CustomerSupplierName");
            this.Property(t => t.CustomerSupplierNameEN).HasColumnName("CustomerSupplierNameEN");
            this.Property(t => t.DefBranchID).HasColumnName("DefBranchID");
            this.Property(t => t.DefLocationID).HasColumnName("DefLocationID");
            this.Property(t => t.DefCurrencyID).HasColumnName("DefCurrencyID");
            this.Property(t => t.ArApCustomerSupplierTypeID).HasColumnName("ArApCustomerSupplierTypeID");
            this.Property(t => t.ArApCustomerSupplierCategoryID).HasColumnName("ArApCustomerSupplierCategoryID");
            this.Property(t => t.GlAccountID).HasColumnName("GlAccountID");
            this.Property(t => t.GlSubAccountID).HasColumnName("GlSubAccountID");
            this.Property(t => t.DealingStartDate).HasColumnName("DealingStartDate");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.BusinessName).HasColumnName("BusinessName");
            this.Property(t => t.POBox).HasColumnName("POBox");
            this.Property(t => t.PostalCode).HasColumnName("PostalCode");
            this.Property(t => t.RecordTrading).HasColumnName("RecordTrading");
            this.Property(t => t.Telephone1).HasColumnName("Telephone1");
            this.Property(t => t.Telephone2).HasColumnName("Telephone2");
            this.Property(t => t.Telephone3).HasColumnName("Telephone3");
            this.Property(t => t.Fax).HasColumnName("Fax");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.ResponsibleName).HasColumnName("ResponsibleName");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.HasCreditLimit).HasColumnName("HasCreditLimit");
            this.Property(t => t.CreditLimit).HasColumnName("CreditLimit");
            this.Property(t => t.InitialCredit).HasColumnName("InitialCredit");
            this.Property(t => t.ArApPaymentPeriodID).HasColumnName("ArApPaymentPeriodID");
            this.Property(t => t.ArApCustomerSupplierGroupID).HasColumnName("ArApCustomerSupplierGroupID");
            this.Property(t => t.CustomerSupplierFlag).HasColumnName("CustomerSupplierFlag");
            this.Property(t => t.LocalDebit).HasColumnName("LocalDebit");
            this.Property(t => t.LocalCredit).HasColumnName("LocalCredit");
            this.Property(t => t.ArApDelegateIDMarketing).HasColumnName("ArApDelegateIDMarketing");
            this.Property(t => t.ArApDelegateID).HasColumnName("ArApDelegateID");
            this.Property(t => t.ArApDelegateIDCollection).HasColumnName("ArApDelegateIDCollection");
            this.Property(t => t.NotificationValueCreditLimit).HasColumnName("NotificationValueCreditLimit");


            this.Property(t => t.ArCreditTypeID).HasColumnName("ArCreditTypeID");
            this.Property(t => t.ArApDiscountID).HasColumnName("ArApDiscountID");
            this.Property(t => t.CreditPeriod).HasColumnName("CreditPeriod");
            this.Property(t => t.SellingPriceType).HasColumnName("SellingPriceType");
            this.Property(t => t.PaymentMethod).HasColumnName("PaymentMethod");
            this.Property(t => t.CustomerSupplierType).HasColumnName("CustomerSupplierType");
            this.Property(t => t.RecordOwnerID).HasColumnName("RecordOwnerID");
            this.Property(t => t.RowVersionNumber).HasColumnName("RowVersionNumber");
            this.Property(t => t.Logn_line).HasColumnName("Logn_line");
            this.Property(t => t.Latit_Line).HasColumnName("Latit_Line");
            this.Property(t => t.Logn_Latit).HasColumnName("Logn_Latit");


            // Relationships
            //this.HasOptional(t => t.ArApCustomerSupplierCategory)
            //    .WithMany(t => t.ArApCustomerSuppliers)
            //    .HasForeignKey(d => d.ArApCustomerSupplierCategoryID);
            //this.HasRequired(t => t.ArApCustomerSupplierGroup)
            //    .WithMany(t => t.ArApCustomerSuppliers)
            //    .HasForeignKey(d => d.ArApCustomerSupplierGroupID);
            this.HasRequired(t => t.CustomerType)
                .WithMany(t => t.Customers)
                .HasForeignKey(d => d.ArApCustomerSupplierTypeID);

            this.HasOptional(t => t.ArApCollectionDelegate)
                 .WithMany(t => t.ArApCollectionCustomerSuppliers)
                .HasForeignKey(d => d.ArApDelegateIDCollection);



            this.HasOptional(t => t.ArApMarketingDelegate)
                 .WithMany(t => t.ArApMarketingCustomerSuppliers)
                .HasForeignKey(d => d.ArApDelegateIDMarketing);

            this.HasOptional(t => t.ArApSalesDelegate)
                 .WithMany(t => t.ArApSalesCustomerSuppliers)
                .HasForeignKey(d => d.ArApDelegateID);

            //this.HasOptional(t => t.ArApPaymentPeriod)
            //    .WithMany(t => t.ArApCustomerSuppliers)
            //    .HasForeignKey(d => d.ArApPaymentPeriodID);

            this.HasRequired(t => t.Branch)
                .WithMany(t => t.Customers)
                .HasForeignKey(d => d.DefBranchID);
            
            
            
            this.HasOptional(t => t.DefCurrency)
                .WithMany(t => t.Customers)
                .HasForeignKey(d => d.DefCurrencyID);


            this.HasOptional(t => t.DefLocation)
                .WithMany(t => t.Customers)
                .HasForeignKey(d => d.DefLocationID);


            //this.HasOptional(t => t.ArCreditType)
            //    .WithMany(t => t.ArApCustomerSuppliers)
            //    .HasForeignKey(d => d.ArCreditTypeID);

            //this.HasOptional(t => t.ArApDiscount)
            //   .WithMany(t => t.ArApCustomerSuppliers)
            //   .HasForeignKey(d => d.ArApDiscountID);


        }
    }
}