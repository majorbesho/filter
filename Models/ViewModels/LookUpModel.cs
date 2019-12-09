using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace EdgeMobile.Models.ViewModels
{
    [DataObject]
    public class LookUpModel
    {
        //common properties
        public int ID { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public string Note { get; set; }
        public string EnglishNote { get; set; }

        //-------completeall fk for all entities

        //store Properties
        public int DefBranchID { get; set; }
        public Int64? GlStoreAccountID { get; set; }
        public Int64? GlStoreCostAccountID { get; set; }
        //entity Properties
        public Int64? GlEntityAccountID { get; set; }
        //adjustment Properties
        public Int64? GLAdjustmentAccountID { get; set; }
        //group Properties
        public int? ParentID { get; set; }
        //effect properties
        public Int16 EffectMethod { get; set; }
        public Int16 EffectTo { get; set; }
        public Int16 EffectType { get; set; }
        public decimal EffectValue { get; set; }
        public Int64? GlCreditAccountID { get; set; }
        public Int64? GlDebitAccountID { get; set; }

        //public InvStore ToStoreModel()
        //{
        //    return new InvStore
        //    {
        //        InvStoreID = this.ID,
        //        StoreName = this.ArabicName,
        //        StoreNameEN = this.EnglishName,
        //        Notes = this.Note,
        //        NotesEN = this.EnglishNote,
        //        DefBranchID = this.DefBranchID,
        //        GlStoreAccountID = this.GlStoreAccountID,
        //        GlStoreCostAccountID = this.GlStoreCostAccountID
        //    };
        //}
        //public InvUnit ToUnitModel()
        //{
        //    return new InvUnit
        //    {
        //        InvUnitID = this.ID,
        //        UnitName = this.ArabicName,
        //        UnitNameEN = this.EnglishName,
        //        Notes = this.Note,
        //        NotesEN = this.EnglishNote


        //    };
        //}
        //public InvColor ToColorModel()
        //{
        //    return new InvColor
        //    {
        //        InvColorID = this.ID,
        //        ColorName = this.ArabicName,
        //        ColorNameEN = this.EnglishName,
        //        Notes = this.Note,
        //        NotesEN = this.EnglishNote

        //    };
        //}
        //public InvSize ToSizeModel()
        //{
        //    return new InvSize
        //    {
        //        InvSizeID = this.ID,
        //        SizeName = this.ArabicName,
        //        SizeNameEN = this.EnglishName,
        //        Notes = this.Note,
        //        NotesEN = this.EnglishNote

        //    };
        //}
        //public InvEffect ToEffectModel()
        //{
        //    return new InvEffect
        //    {
        //        InvEffectID = this.ID,
        //        EffectName = this.ArabicName,
        //        EffectNameEN = this.EnglishName,
        //        Notes = this.Note,
        //        NotesEN = this.EnglishNote,
        //        EffectMethod = this.EffectMethod,
        //        EffectTo = this.EffectTo,
        //        EffectType = this.EffectType,
        //        EffectValue = this.EffectValue,
        //        GlCreditAccountID = this.GlCreditAccountID,
        //        GlDebitAccountID = this.GlDebitAccountID

        //    };
        //}

        public InvGroup ToGroupModel()
        {
            return new InvGroup
            {
                InvGroupID = this.ID,
                GroupName = this.ArabicName,
                GroupNameEN = this.EnglishName,
                Notes = this.Note,
                NotesEN = this.EnglishNote,
                ParentID = this.ParentID

            };
        }
        //public InvEntity ToEntityModel()
        //{
        //    return new InvEntity
        //    {
        //        InvEntityID = this.ID,
        //        EntityName = this.ArabicName,
        //        EntityNameEN = this.EnglishName,
        //        Notes = this.Note,
        //        NotesEN = this.EnglishNote,
        //        GlEntityAccountID = this.GlEntityAccountID

        //    };
        //}
        ////public InvAdjustmentType ToAdjustmentModel()
        //{
        //    return new InvAdjustmentType
        //    {
        //        InvAdjustmentTypeID = this.ID,
        //        AdjustmentTypeName = this.ArabicName,
        //        AdjustmentTypeNameEN = this.EnglishName,
        //        Notes = this.Note,
        //        NotesEN = this.EnglishNote,
        //        GLAdjustmentAccountID = this.GLAdjustmentAccountID

        //    };
        //}
    }
}