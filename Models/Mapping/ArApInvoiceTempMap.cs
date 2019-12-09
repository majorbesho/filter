using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace EdgeMobile.Models.Mapping
{
    public class ArApInvoiceTempMap : EntityTypeConfiguration<ArApInvoiceTemp>
    {
        public ArApInvoiceTempMap()
        {
            // Primary Key
            this.HasKey(t => t.ArApInvoiceID);

            // Properties
            this.Property(t => t.InvoiceCode)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Note)
                .HasMaxLength(100);

            this.Property(t => t.RowVersionNumber)
                .IsFixedLength()
                .HasMaxLength(8)
                .IsRowVersion();

            // Table & Column Mappings
            this.ToTable("ArApInvoiceTemp");
            this.Property(t => t.ArApInvoiceID).HasColumnName("ArApInvoiceID");
            this.Property(t => t.InvoiceCode).HasColumnName("InvoiceCode");
            this.Property(t => t.DefBranchID).HasColumnName("DefBranchID");
            this.Property(t => t.InvoiceDate).HasColumnName("InvoiceDate");
            this.Property(t => t.TransactionType).HasColumnName("TransactionType");
            this.Property(t => t.ArApReturnInvoiceID).HasColumnName("ArApReturnInvoiceID");
            this.Property(t => t.InvStoreID).HasColumnName("InvStoreID");
            this.Property(t => t.PaymentMethod).HasColumnName("PaymentMethod");
            this.Property(t => t.ArApCustomerSupplierID).HasColumnName("ArApCustomerSupplierID");
            this.Property(t => t.ArApInvoiceTypeID).HasColumnName("ArApInvoiceTypeID");
            this.Property(t => t.ArApSupplyOrderID).HasColumnName("ArApSupplyOrderID");
            this.Property(t => t.DefCurrencyID).HasColumnName("DefCurrencyID");
            this.Property(t => t.ExchangeRate).HasColumnName("ExchangeRate");
            this.Property(t => t.ArApDelegateIDMarketing).HasColumnName("ArApDelegateIDMarketing");
            this.Property(t => t.ArApDelegateID).HasColumnName("ArApDelegateID");
            this.Property(t => t.ArApDelegateIDCollection).HasColumnName("ArApDelegateIDCollection");
            this.Property(t => t.Note).HasColumnName("Note");
            this.Property(t => t.InvoiceFlag).HasColumnName("InvoiceFlag");
            this.Property(t => t.Netprice).HasColumnName("Netprice");
            this.Property(t => t.CreditPeriod).HasColumnName("CreditPeriod");
            this.Property(t => t.ApPurchasingRequestID).HasColumnName("ApPurchasingRequestID");
            this.Property(t => t.ApPriceOfferID).HasColumnName("ApPriceOfferID");
            this.Property(t => t.ApPurchasingOrderID).HasColumnName("ApPurchasingOrderID");

            this.Property(t => t.TotalDiscountPercentage).HasColumnName("TotalDiscountPercentage");
            this.Property(t => t.TotalDiscountValue).HasColumnName("TotalDiscountValue");
            this.Property(t => t.TotalEffectsValue).HasColumnName("TotalEffectsValue");
            this.Property(t => t.TotalPrice).HasColumnName("TotalPrice");
            this.Property(t => t.ArApDiscountID).HasColumnName("ArApDiscountID");
            this.Property(t => t.IsTotalsClaimCalculated).HasColumnName("IsTotalsClaimCalculated");
            this.Property(t => t.TotalSupplierEffectsValue).HasColumnName("TotalSupplierEffectsValue");

            this.Property(t => t.GlJournalID).HasColumnName("GlJournalID");
            this.Property(t => t.JournalSerial).HasColumnName("JournalSerial");
            this.Property(t => t.ArSalesOrderID).HasColumnName("ArSalesOrderID");
            this.Property(t => t.ArPriceOfferID).HasColumnName("ArPriceOfferID");
            this.Property(t => t.recipient).HasColumnName("recipient");
            this.Property(t => t.InvoiceID).HasColumnName("InvoiceID");
            this.Property(t => t.RecordOwnerID).HasColumnName("RecordOwnerID");
            this.Property(t => t.RowVersionNumber).HasColumnName("RowVersionNumber");
            this.Property(t => t.IsIssueTransactions).HasColumnName("IsIssueTransactions");

            this.Property(t => t.Amountpaid).HasColumnName("Amountpaid");
            this.Property(t => t.RemainingAmount).HasColumnName("RemainingAmount");
            this.Property(t => t.ArWindowShowTypeID).HasColumnName("ArWindowShowTypeID");


            // Relationships
            //this.HasOptional(t => t.ArApCustomerSupplier)
            //    .WithMany(t => t.ArApInvoices)
            //    .HasForeignKey(d => d.ArApCustomerSupplierID);

            //this.HasOptional(t => t.ArApCollectionDelegate)
            //    .WithMany(t => t.ArApCollectionInvoices)
            //    .HasForeignKey(d => d.ArApDelegateIDCollection);

            //this.HasOptional(t => t.ArApMarketingDelegate)
            //    .WithMany(t => t.ArApMarketingInvoices)
            //    .HasForeignKey(d => d.ArApDelegateIDMarketing);

            //this.HasRequired(t => t.ArApDelegate)
            //    .WithMany(t => t.ArApInvoices)
            //    .HasForeignKey(d => d.ArApDelegateID);

            //this.HasOptional(t => t.ArApInvoiceType)
            //    .WithMany(t => t.ArApInvoices)
            //    .HasForeignKey(d => d.ArApInvoiceTypeID);

            //this.HasRequired(t => t.DefBranch)
            //    .WithMany(t => t.ArApInvoices)
            //    .HasForeignKey(d => d.DefBranchID);

            //this.HasOptional(t => t.DefCurrency)
            //    .WithMany(t => t.ArApInvoices)
            //    .HasForeignKey(d => d.DefCurrencyID);

            //this.HasRequired(t => t.InvStore)
            //    .WithMany(t => t.ArApInvoices)
            //    .HasForeignKey(d => d.InvStoreID);

            //this.HasOptional(t => t.ApPurchasingOrder)
            //    .WithMany(t => t.ArApInvoices)
            //    .HasForeignKey(d => d.ApPurchasingOrderID);

            //this.HasOptional(t => t.ApPurchasingRequest)
            //    .WithMany(t => t.ArApInvoices)
            //    .HasForeignKey(d => d.ApPurchasingRequestID);

            //this.HasOptional(t => t.ApPriceOffer)
            //    .WithMany(t => t.ArApInvoices)
            //    .HasForeignKey(d => d.ApPriceOfferID);

            //this.HasOptional(t => t.ArPurposeOfIssue)
            //    .WithMany(t => t.ArApInvoices)
            //    .HasForeignKey(d => d.ArPurposeOfIssueID);


            //this.HasOptional(t => t.ArSalesOrder)
            //    .WithMany(t => t.ArApInvoices)
            //    .HasForeignKey(d => d.ArSalesOrderID);

            //this.HasOptional(t => t.ArPriceOffer)
            //    .WithMany(t => t.ArApInvoices)
            //    .HasForeignKey(d => d.ArPriceOfferID);
        }
    }
}