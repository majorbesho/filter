using EdgeMobile.Models.ViewModels;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace EdgeMobile.Models.ModelRepositories
{
    public class InvGroupRepository : IInvGroupRepository
    {
        #region Context
        ERPEdgeContext context = new ERPEdgeContext();
        #endregion
        #region Constructors
        public InvGroupRepository()
        {
            this.context.Configuration.LazyLoadingEnabled = false;
        }
        #endregion

        #region Common Method Implementations
        public IQueryable<InvGroup> All
        {
            get { return context.InvGroups; }
        }

        public IQueryable<InvGroup> AllIncluding(params Expression<Func<InvGroup, object>>[] includeProperties)
        {
            IQueryable<InvGroup> query = context.InvGroups;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public InvGroup Find(int id)
        {
            return context.InvGroups.Find(id);
        }

        public void InsertOrUpdate(InvGroup invgroup)
        {
            if (Find(invgroup.InvGroupID) == null)
            {
                // New entity
                context.InvGroups.Add(invgroup);
            }
            else
            {
                // Existing entity
                context.Entry(context.Set<InvGroup>().Find(invgroup.InvGroupID)).CurrentValues.SetValues(invgroup);
                // context.Entry(invgroup).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var invgroup = context.InvGroups.Find(id);
            context.InvGroups.Remove(invgroup);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
        #endregion
        #region Custom Method Implementations
        public IQueryable<InvGroupViewModel> Search(int Language)
        {
            //return this.All;
            var q = (from a in this.All
                     select new InvGroupViewModel { GroupName = a.GroupName , InvGroupID = a.InvGroupID, });
            return q;
        }
        public List<InvGroup> GetSearchResult(string groupId, string name)
        {
            var sql = @"SELECT DISTINCT * FROM dbo.InvGroup where InvGroupID <> 0";
            if (groupId != "")
            {
                sql = sql + " and (dbo.InvGroup.InvGroupID ={0})";
            }
            if (name != "")
            {
                sql = sql + " and (dbo.InvGroup.GroupName like N'%{1}%')";
            }


            sql = string.Format(sql, groupId, name);
            sql = sql + " order by dbo.InvGroup.GroupName";
            var quary = context.Database.SqlQuery<InvGroup>(sql);
            return quary.ToList();
        }
        public int GetNextExpectedIdentity()
        {
            InvGroup group = context.InvGroups.Where(u => u.InvGroupID == context.InvGroups.Max(n => n.InvGroupID)).SingleOrDefault();
            if (group != null)
                return group.InvGroupID + 1;
            else
                return 1;
        }
        public int GetMinIdentity()
        {
            InvGroup group = context.InvGroups.Where(u => u.InvGroupID == context.InvGroups.Min(n => n.InvGroupID)).SingleOrDefault();
            if (group != null)
                return group.InvGroupID;
            else
                return 0;
        }
        public int GetMaxIdentity()
        {
            InvGroup group = context.InvGroups.Where(u => u.InvGroupID == context.InvGroups.Max(n => n.InvGroupID)).SingleOrDefault();
            if (group != null)
                return group.InvGroupID;
            else
                return 0;
        }
        public int GetListMaxIdentity(List<InvGroup> list)
        {
            InvGroup group = list.Where(u => u.InvGroupID == list.Max(n => n.InvGroupID)).SingleOrDefault();
            if (group != null)
                return group.InvGroupID;
            else
                return 0;
        }
        public int GetListMinIdentity(List<InvGroup> list)
        {
            InvGroup group = list.Where(u => u.InvGroupID == list.Min(n => n.InvGroupID)).SingleOrDefault();
            if (group != null)
                return group.InvGroupID;
            else
                return 0;
        }
        //public int GetNavigationId(BaseEnum.PageSignEnum sign, int currentId = 0)
        //{
        //    InvGroup group = null;
        //    if (sign == BaseEnum.PageSignEnum.last)
        //        group = context.InvGroups.Where(u => u.InvGroupID == context.InvGroups.Max(n => n.InvGroupID)).SingleOrDefault();
        //    else if (sign == BaseEnum.PageSignEnum.First)
        //        group = context.InvGroups.Where(u => u.InvGroupID == context.InvGroups.Min(n => n.InvGroupID)).SingleOrDefault();
        //    else if (sign == BaseEnum.PageSignEnum.Next)
        //        group = context.InvGroups.Where(u => u.InvGroupID > currentId).FirstOrDefault();
        //    else if (sign == BaseEnum.PageSignEnum.Prev)
        //        group = context.InvGroups.Where(u => u.InvGroupID < currentId).AsEnumerable().LastOrDefault();

        //    if (group != null)
        //        return group.InvGroupID;
        //    else
        //        return 0;
        //}
        //public int GetNavigationId(BaseEnum.PageSignEnum sign, List<InvGroup> searchResultList, int currentId = 0)
        //{
        //    InvGroup group = null;
        //    if (sign == BaseEnum.PageSignEnum.last)
        //        group = searchResultList.Where(u => u.InvGroupID == searchResultList.Max(n => n.InvGroupID)).SingleOrDefault();
        //    else if (sign == BaseEnum.PageSignEnum.First)
        //        group = searchResultList.Where(u => u.InvGroupID == searchResultList.Min(n => n.InvGroupID)).SingleOrDefault();
        //    else if (sign == BaseEnum.PageSignEnum.Next)
        //        group = searchResultList.Where(u => u.InvGroupID > currentId).FirstOrDefault();
        //    else if (sign == BaseEnum.PageSignEnum.Prev)
        //        group = searchResultList.Where(u => u.InvGroupID < currentId).AsEnumerable().LastOrDefault();

        //    if (group != null)
        //        return group.InvGroupID;
        //    else
        //        return 0;
        //}

        public List<LookUpModel> GetLookUp()
        {
            var query = (from g in context.InvGroups
                         select new LookUpModel
                         {
                             ID = g.InvGroupID,
                             ArabicName = g.GroupName,
                             EnglishName = g.GroupNameEN,
                             Note = g.Notes,
                             EnglishNote = g.Notes,
                             ParentID = g.ParentID

                         }).ToList();
            return query;

        }

        public InvGroup GetInvGroupFromLookUpModel(LookUpModel lookUpModel)
        {
            InvGroup group;
            if (lookUpModel.ID == 0)
            {
                group = new InvGroup();
            }
            else
            {
                group = this.Find(lookUpModel.ID);
            }
            group.InvGroupID = lookUpModel.ID;
            group.GroupName = lookUpModel.ArabicName;
            group.GroupNameEN = lookUpModel.EnglishName;
            return group;
        }

        public IEnumerable GetGroupLookup(string query, int Language)
        {
            //var groups = ((IObjectContextAdapter)this.context).ObjectContext.CreateObjectSet<InvGroup>().Where("(StartsWith(CAST(it.InvGroupID AS System.String), @p) OR Contains(it.GroupName, @p)) ", new ObjectParameter("p", query))
            //    .Select(it => new { it.InvGroupID, it.GroupName, it.ParentID, ParentName = "" });

            //var groupsWithParent = from g in groups.AsEnumerable()

            //                       from gParents in context.InvGroups.Where(gruppe => gruppe.InvGroupID == g.ParentID).DefaultIfEmpty()
            //                       select new { g.InvGroupID, g.GroupName, g.ParentID, ParentName = (gParents!=null)? gParents.GroupName:"" };

            var groupsWithParent = (from i in this.context.InvGroups.Where(ii => ii.InvGroupID.ToString().StartsWith(query) || ii.GroupName.Contains(query))
                                    from gParents in context.InvGroups.Where(gruppe => gruppe.InvGroupID == i.ParentID).DefaultIfEmpty()

                                    select new InvGroupViewModel
                                    {
                                        InvGroupID = i.InvGroupID,
                                        GroupName = i.GroupName ,
                                        ParentID = i.ParentID,
                                        ParentName =  gParents.GroupName
                                    });

            return groupsWithParent;
        }

        //public IEnumerable GetToGroupLookup(int? fromGroupId, string query, int Language)
        //{
        //    int fromGroup = Convert.ToInt32(fromGroupId);
        //    if (fromGroup == 0)
        //        return ((IObjectContextAdapter)this.context).ObjectContext.CreateObjectSet<InvGroup>().Where("(StartsWith(CAST(it.InvGroupID AS System.String), @p) OR Contains(it.GroupName, @p)) ", new ObjectParameter("p", query))
        //            .Select(it => new { it.InvGroupID, GroupName = it.GroupName });
        //    else
        //    {
        //        return ((IObjectContextAdapter)this.context).ObjectContext.CreateObjectSet<InvGroup>().Where("((StartsWith(CAST(it.InvGroupID AS System.String), @p) OR Contains(it.GroupName, @p) ) And it.InvGroupID >= @f ) ", new ObjectParameter("p", query), new ObjectParameter("f", fromGroup))
        //      .Select(it => new { it.InvGroupID, GroupName = it.GroupName });
        //    }

        //}

        //public List<InvItemViewModel> LoadItems(int ID)
        //{
        //    //       var testt = (from i in this.context.InvItems
        //    //                    join s in this.context.InvItemStores on i.InvItemID equals s.InvItemID
        //    //                    join st in this.context.InvStores on s.InvStoreID equals st.InvStoreID
        //    //                    join u in this.context.InvUnits on i.InvUnitID equals u.InvUnitID
        //    //                    join baln in this.context.InvItemBalanceEvaluates on s.InvItemStoreID
        //    //                    equals baln.InvItemStoreID
        //    //                    //    join ph in this.context.InvItemPhotoes on i.InvItemID equals ph.InvItemID

        //    //                    where // ((storeID == null) || s.InvStoreID == storeID) &&
        //    //                     (/*(groupID == null) || */i.InvGroupID == ID)
        //    //                    //select new InvItemModel { InvItemID = i.InvItemID, ItemCode = i.ItemCode, ItemName = i.ItemName, InvUnitID = u.InvUnitID, UnitName = u.UnitName, ConvertFactor = 1, InvItemStoreID = s.InvItemStoreID, OpeningBalance = s.OpeningBalance ?? 0, HasExpierDate = i.HasExpierDate, IsColored = i.IsColored }
        //    //                    select new InvItemViewModel { InvItemID= i.InvItemID, ItemCode= i.ItemCode, ItemName= i.ItemName, InvUnitID= u.InvUnitID, UnitName=u.UnitName, InvItemStoreID= s.InvItemStoreID, Quantity= baln.Quantity, SellingPrice= s.SellingPrice }
        //    //                    // select new { i.InvItemID, i.ItemCode, i.ItemName, u.InvUnitID, u.UnitName, s.InvItemStoreID, baln.Quantity, s.SellingPrice }
        //    //);

        //    //       return testt.ToList();


        //    //ItemListView.DataSource = testt.ToList();
        //    //ItemListView.DataBind();

        //}
        #endregion
    }

    public interface IInvGroupRepository : IDisposable
    {
        #region Common Method Signatures
        IQueryable<InvGroup> All { get; }
        IQueryable<InvGroup> AllIncluding(params Expression<Func<InvGroup, object>>[] includeProperties);
        InvGroup Find(int id);
        void InsertOrUpdate(InvGroup invgroup);
        void Delete(int id);
        void Save();
        #endregion
        #region Custom Method Signatures
        IQueryable<InvGroupViewModel> Search(int Language);
        List<InvGroup> GetSearchResult(string groupId, string name);
        int GetNextExpectedIdentity();
        int GetMaxIdentity();
        int GetMinIdentity();
        int GetListMaxIdentity(List<InvGroup> list);
        int GetListMinIdentity(List<InvGroup> list);
        //int GetNavigationId(BaseEnum.PageSignEnum sign, int currentId = 0);
       /// int GetNavigationId(BaseEnum.PageSignEnum sign, List<InvGroup> searchResultList, int currentId = 0);
        List<LookUpModel> GetLookUp();
        InvGroup GetInvGroupFromLookUpModel(LookUpModel lookUpModel);
        IEnumerable GetGroupLookup(string query, int Language);
        //IEnumerable GetToGroupLookup(int? fromGroupId, string query, int Language);
       // List<InvItemViewModel> LoadItems(int ID);
        #endregion
    }
}