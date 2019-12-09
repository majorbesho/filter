using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace EdgeMobile.Models.Mapping
{
    public class DefCurrencyMap : EntityTypeConfiguration<DefCurrency>
    {
        public DefCurrencyMap()
        {
            // Primary Key
            this.HasKey(t => t.DefCurrencyID);

            // Properties
            this.Property(t => t.DefCurrencyID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.CurrencyName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.PettyName)
                .HasMaxLength(100);

            this.Property(t => t.Symbol)
                .HasMaxLength(20);

            this.Property(t => t.CurrencyNameEN)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.PettyNameEN)
                .HasMaxLength(100);

            this.Property(t => t.SymbolEN)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("DefCurrency");
            this.Property(t => t.DefCurrencyID).HasColumnName("DefCurrencyID");
            this.Property(t => t.CurrencyName).HasColumnName("CurrencyName");
            this.Property(t => t.ExchangeRate).HasColumnName("ExchangeRate");
            this.Property(t => t.PettyName).HasColumnName("PettyName");
            this.Property(t => t.Symbol).HasColumnName("Symbol");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.DefAnalyticalID).HasColumnName("DefAnalyticalID");
            this.Property(t => t.Notes).HasColumnName("Notes");
            this.Property(t => t.CurrencyNameEN).HasColumnName("CurrencyNameEN");
            this.Property(t => t.PettyNameEN).HasColumnName("PettyNameEN");
            this.Property(t => t.SymbolEN).HasColumnName("SymbolEN");
            this.Property(t => t.NotesEN).HasColumnName("NotesEN");

            // Relationships
            //this.HasOptional(t => t.DefAnalytical)
            //    .WithMany(t => t.DefCurrencies)
            //    .HasForeignKey(d => d.DefAnalyticalID);

        }
    }
}