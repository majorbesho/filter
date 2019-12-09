using EdgeMobile.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdgeMobile.Models
{

    public class InvGroupService
    {
        private static bool UpdateDatabase = true;


        private ERPEdgeContext db;

        public InvGroupService(ERPEdgeContext db)
        {
            this.db = db;
        }


        public IList<InvGroupViewModel> GetAll()
        {
            var result = HttpContext.Current.Session["InvGroup"] as IList<InvGroupViewModel>;

            if (result == null || UpdateDatabase)
            {
               
                    result = db.InvGroups.Select(invGroup => new InvGroupViewModel
                    {
                        InvGroupID = invGroup.InvGroupID,
                        GroupName = invGroup.GroupName//,
                      //  Notes = invGroup.Notes//.UnitPrice.HasValue ? product.UnitPrice.Value : default(decimal),
                        //UnitsInStock = product.UnitsInStock.HasValue ? product.UnitsInStock.Value : default(short),
                        //QuantityPerUnit = product.QuantityPerUnit,
                        //Discontinued = product.Discontinued,
                        //UnitsOnOrder = product.UnitsOnOrder.HasValue ? (int)product.UnitsOnOrder.Value : default(int),
                        //CategoryID = product.CategoryID,
                        //Category = new CategoryViewModel()
                        //{
                        //    CategoryID = product.Category.CategoryID,
                        //    CategoryName = product.Category.CategoryName
                        //},
                        //LastSupply = DateTime.Today
                    }).ToList();
               
                HttpContext.Current.Session["InvGroup"] = result;
            }

            return result;
        }

        public IEnumerable<InvGroupViewModel> Read()
        {
            return GetAll();
        }

        public IList<InvItemViewModel> GellData()
        {
            List<InvItem> invItems = db.InvItems.ToList();
            List<InvItemStore> invItemStores = db.InvItemStores.ToList();
            List<InvUnit> invUnits = db.InvUnits.ToList();
            List<InvStore> invStores = db.InvStores.ToList();
            List<InvItemBalanceEvaluate> invItemBalanceEvaluates = db.InvItemBalanceEvaluates.ToList();
            
            var itemG = HttpContext.Current.Session["Invitem"] as IList<InvItemViewModel>;

            if (itemG == null || UpdateDatabase)
            {
                 itemG = (from i in invItems
                             join s in invItemStores on i.InvItemID equals s.InvItemID
                             join st in invStores on s.InvStoreID equals st.InvStoreID
                             join u in invUnits on i.InvUnitID equals u.InvUnitID
                             join baln in invItemBalanceEvaluates on s.InvItemStoreID
                          equals baln.InvItemStoreID
                             //    join ph in this.context.InvItemPhotoes on i.InvItemID equals ph.InvItemID

                             //where // ((storeID == null) || s.InvStoreID == storeID) &&
                             // (/*(groupID == null) || */i.InvGroupID == ID)
                             select new InvItemViewModel
                             {
                                 InvItemID = i.InvItemID,
                                 ItemName = i.ItemName//,
                                                      //invStore = st,
                                                      //invUnit = u,
                                                      //InvItemBalanceEvaluate = baln
                             }

     ).ToList();
                HttpContext.Current.Session["Invitem"] = itemG;
            }
            return (itemG);

        }
        public IEnumerable<InvItemViewModel> GellData_Read()
        {
            return GellData();//(ID);
        }
        //public void Create(ProductViewModel product)
        //{
        //    if (!UpdateDatabase)
        //    {
        //        var first = GetAll().OrderByDescending(e => e.ProductID).FirstOrDefault();
        //        var id = (first != null) ? first.ProductID : 0;

        //        product.ProductID = id + 1;

        //        if (product.CategoryID == null)
        //        {
        //            product.CategoryID = 1;
        //        }

        //        if (product.Category == null)
        //        {
        //            product.Category = new CategoryViewModel() { CategoryID = 1, CategoryName = "Beverages" };
        //        }

        //        GetAll().Insert(0, product);
        //    }
        //    else
        //    {
        //        var entity = new Product();

        //        entity.ProductName = product.ProductName;
        //        entity.UnitPrice = product.UnitPrice;
        //        entity.UnitsInStock = (short)product.UnitsInStock;
        //        entity.Discontinued = product.Discontinued;
        //        entity.CategoryID = product.CategoryID;

        //        if (entity.CategoryID == null)
        //        {
        //            entity.CategoryID = 1;
        //        }

        //        if (product.Category != null)
        //        {
        //            entity.CategoryID = product.Category.CategoryID;
        //        }

        //        entities.Products.Add(entity);
        //        entities.SaveChanges();

        //        product.ProductID = entity.ProductID;
        //    }
        //}

        //public void Update(ProductViewModel product)
        //{
        //    if (!UpdateDatabase)
        //    {
        //        var target = One(e => e.ProductID == product.ProductID);

        //        if (target != null)
        //        {
        //            target.ProductName = product.ProductName;
        //            target.UnitPrice = product.UnitPrice;
        //            target.UnitsInStock = product.UnitsInStock;
        //            target.Discontinued = product.Discontinued;

        //            if (product.CategoryID == null)
        //            {
        //                product.CategoryID = 1;
        //            }

        //            if (product.Category != null)
        //            {
        //                product.CategoryID = product.Category.CategoryID;
        //            }
        //            else
        //            {
        //                product.Category = new CategoryViewModel()
        //                {
        //                    CategoryID = (int)product.CategoryID,
        //                    CategoryName = entities.Categories.Where(s => s.CategoryID == product.CategoryID).Select(s => s.CategoryName).First()
        //                };
        //            }

        //            target.CategoryID = product.CategoryID;
        //            target.Category = product.Category;
        //        }
        //    }
        //    else
        //    {
        //        var entity = new Product();

        //        entity.ProductID = product.ProductID;
        //        entity.ProductName = product.ProductName;
        //        entity.UnitPrice = product.UnitPrice;
        //        entity.UnitsInStock = (short)product.UnitsInStock;
        //        entity.Discontinued = product.Discontinued;
        //        entity.CategoryID = product.CategoryID;

        //        if (product.Category != null)
        //        {
        //            entity.CategoryID = product.Category.CategoryID;
        //        }

        //        entities.Products.Attach(entity);
        //        entities.Entry(entity).State = EntityState.Modified;
        //        entities.SaveChanges();
        //    }
        //}

        public void Destroy(InvGroupViewModel InvGroup)
        {
            if (!UpdateDatabase)
            {
                var target = GetAll().FirstOrDefault(p => p.InvGroupID == InvGroup.InvGroupID);
                if (target != null)
                {
                    GetAll().Remove(target);
                }
            }
            else
            {
                var entity = new InvGroup();

                entity.InvGroupID = InvGroup.InvGroupID;

                db.InvGroups.Attach(entity);

                db.InvGroups.Remove(entity);

                //var orderDetails = db.Order_Details.Where(pd => pd.ProductID == entity.ProductID);

                //foreach (var orderDetail in orderDetails)
                //{
                //    db.Order_Details.Remove(orderDetail);
                //}

                db.SaveChanges();
            }
        }

        //public ProductViewModel One(Func<ProductViewModel, bool> predicate)
        //{
        //    return GetAll().FirstOrDefault(predicate);
        //}

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
