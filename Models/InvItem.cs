using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace EdgeMobile.Models
{
    public partial class InvItem
    {
        public InvItem()
        {
            //this.ApPriceOfferDetails = new List<ApPriceOfferDetail>();
            //this.ArPriceOfferDetails = new List<ArPriceOfferDetail>();
            //this.ApPurchasingRequestOrderDetails = new List<ApPurchasingRequestOrderDetail>();
            //this.ArApCustomerGroupItems = new List<ArApCustomerGroupItem>();
            //this.ArSalesPlanBranchDelegeteProducts = new List<ArSalesPlanBranchDelegeteProduct>();
            //this.ArSalesPlanPeriodBranchDistributions = new List<ArSalesPlanPeriodBranchDistribution>();
            //this.InvAlternativeItems = new List<InvAlternativeItem>();
            //this.InvAlternativeItems1 = new List<InvAlternativeItem>();
            //this.InvItemAdditionalDatas = new List<InvItemAdditionalData>();
            //this.InvItemColors = new List<InvItemColor>();
            //this.InvItemEffects = new List<InvItemEffect>();
            //this.InvItemPhotoes = new List<InvItemPhoto>();
            //this.InvItemSizes = new List<InvItemSize>();
            //this.InvItemSizeColors = new List<InvItemSizeColor>();
            this.InvItemStores = new List<InvItemStore>();
            //this.InvItemUnitFactors = new List<InvItemUnitFactor>();
            //this.InvKits = new List<InvKit>();
            //this.InvKits1 = new List<InvKit>();
            //this.MFItemEmployees = new List<MFItemEmployee>();

        }

        public int InvItemID { get; set; }
        [DisplayName("كود الصنف")]
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ItemNameEN { get; set; }
        public int InvGroupID { get; set; }
        public Nullable<int> InvUnitID { get; set; }
        public Nullable<short> HasExpierDate { get; set; }
        public Nullable<short> IsKit { get; set; }
        public Nullable<short> HasSerialNo { get; set; }
        public string ItemAnalytical { get; set; }
        public string ShortName { get; set; }
        public string ShortNameEN { get; set; }
        public string PackageName { get; set; }
        public string PackageNameEN { get; set; }
        public string PackageSize { get; set; }
        public Nullable<int> SalesWarranty { get; set; }
        public Nullable<int> PurchaseWarranty { get; set; }
        public string ExtendedName { get; set; }
        public string ExtendedNameEN { get; set; }
        public Nullable<short> IsActive { get; set; }
        public Nullable<short> IsReturned { get; set; }
        public Nullable<int> PeriodOfReturn { get; set; }
        public short SellingPriceType { get; set; }
        public Nullable<decimal> SellingPrice { get; set; }
        public Nullable<short> WholeSaleType { get; set; }
        public Nullable<decimal> WholeSalePrice { get; set; }
        public Nullable<short> DistributorPriceType { get; set; }
        public Nullable<decimal> DistributorPrice { get; set; }
        public short IsColored { get; set; }
        public Nullable<int> NotificationValueExpireDate { get; set; }
        public short ItemType { get; set; }
        public Nullable<decimal> TransferePrice { get; set; }



        public decimal GuideCostPrice { get; set; }
    //    public virtual ICollection<ApPriceOfferDetail> ApPriceOfferDetails { get; set; }
    //    public virtual ICollection<ArPriceOfferDetail> ArPriceOfferDetails { get; set; }

      //  public virtual ICollection<ApPurchasingRequestOrderDetail> ApPurchasingRequestOrderDetails { get; set; }
      //  public virtual ICollection<ArApCustomerGroupItem> ArApCustomerGroupItems { get; set; }
      //  public virtual ICollection<ArSalesPlanBranchDelegeteProduct> ArSalesPlanBranchDelegeteProducts { get; set; }
       // public virtual ICollection<ArSalesPlanPeriodBranchDistribution> ArSalesPlanPeriodBranchDistributions { get; set; }
       // public virtual ICollection<InvAlternativeItem> InvAlternativeItems { get; set; }
       // public virtual ICollection<InvAlternativeItem> InvAlternativeItems1 { get; set; }
        public virtual InvGroup InvGroup { get; set; }
    //    public virtual InvUnit InvUnit { get; set; }
     //   public virtual ICollection<InvItemAdditionalData> InvItemAdditionalDatas { get; set; }
      //  public virtual ICollection<InvItemColor> InvItemColors { get; set; }
      //  public virtual ICollection<InvItemEffect> InvItemEffects { get; set; }
      //  public virtual ICollection<InvItemPhoto> InvItemPhotoes { get; set; }
      //  public virtual ICollection<InvItemSize> InvItemSizes { get; set; }
      //  public virtual ICollection<InvItemSizeColor> InvItemSizeColors { get; set; }
        public virtual ICollection<InvItemStore> InvItemStores { get; set; }
      //  public virtual ICollection<InvItemUnitFactor> InvItemUnitFactors { get; set; }
    //    public virtual ICollection<InvKit> InvKits { get; set; }
    //    public virtual ICollection<InvKit> InvKits1 { get; set; }

      //  public virtual ICollection<MFItemEmployee> MFItemEmployees { get; set; }
    }
}