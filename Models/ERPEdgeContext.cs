using EdgeMobile.Models.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EdgeMobile.Models
{
    public partial class ERPEdgeContext : DbContext
    {
        static ERPEdgeContext()
        {
            Database.SetInitializer<ERPEdgeContext>(null);
        }

        public ERPEdgeContext()
            : base("Name=ERPEdgeContext")
        {
        }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Delegate> Delegates { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CustomerType> CustomerTypes { get; set; }
        public DbSet<DefCurrency> DefCurrencies { get; set; }
        public DbSet<DefLocation> DefLocations { get; set; }
        public DbSet<DefLocationType> DefLocationTypes { get; set; }
        public DbSet<GlCashVoucherCash> GlCashVoucherCashes { get; set; }

        public DbSet<InvGroup> InvGroups { get; set; }
        public DbSet<InvItem> InvItems { get; set; }
        public DbSet<InvItemStore> InvItemStores { get; set; }
        public DbSet<InvStore> InvStores { get; set; }
        public DbSet<InvUnit> InvUnits { get; set; }
        public DbSet<InvItemBalanceEvaluate> InvItemBalanceEvaluates {get; set;}
        public DbSet<ArApInvoiceItemTemp> ArApInvoiceItemTemps { get; set; }
        public DbSet<ArApInvoiceTemp> ArApInvoiceTemps { get; set; }
        public DbSet<DefEmployee> DefEmployees { get; set; }
        public DbSet<PslWorkPlace> PslWorkPlaces { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new DelegateMap());
            modelBuilder.Configurations.Add(new BranchMap());
            modelBuilder.Configurations.Add(new CompanyMap());
            modelBuilder.Configurations.Add(new CustomerTypeMap());
            modelBuilder.Configurations.Add(new DefCurrencyMap());
            modelBuilder.Configurations.Add(new DefLocationMap());
            modelBuilder.Configurations.Add(new DefLocationTypeMap());
            modelBuilder.Configurations.Add(new GlCashVoucherCashMap());
            modelBuilder.Configurations.Add(new InvGroupMap());
            modelBuilder.Configurations.Add(new InvItemMap());
            modelBuilder.Configurations.Add(new InvItemStoreMap());
            modelBuilder.Configurations.Add(new InvStoreMap());
            modelBuilder.Configurations.Add(new InvUnitMap());
            modelBuilder.Configurations.Add(new InvItemBalanceEvaluateMap());
            modelBuilder.Configurations.Add(new ArApInvoiceItemTempMap());
            modelBuilder.Configurations.Add(new ArApInvoiceTempMap());
            modelBuilder.Configurations.Add(new DefEmployeeMap());
            modelBuilder.Configurations.Add(new PslWorkPlaceMap());
        }

        public System.Data.Entity.DbSet<EdgeMobile.Models.ViewModels.InvItemViewModel> InvItemViewModels { get; set; }

        public System.Data.Entity.DbSet<EdgeMobile.Models.ViewModels.InvGroupViewModel> InvGroupViewModels { get; set; }

        public System.Data.Entity.DbSet<EdgeMobile.Models.ViewModels.InvoiceViewModel> InvoiceViewModels { get; set; }

        public System.Data.Entity.DbSet<EdgeMobile.Models.ViewModels.InvoiceTViewModel> InvoiceTViewModels { get; set; }

        public System.Data.Entity.DbSet<EdgeMobile.Models.ViewModels.CustomerViewModel> CustomerViewModels { get; set; }
    }
}