using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EdgeMobile.Models;
using EdgeMobile.Models.ModelRepositories;
using EdgeMobile.Models.ViewModels;


namespace EdgeMobile.Controllers
{

    public class InvGroupsController : Controller
    {
        public InvGroupRepository _InvGroupRepository;
        public ERPEdgeContext db = new ERPEdgeContext();
        public EdgeSecurityContext Sec = new EdgeSecurityContext();
        private InvGroupService invGroupService;
        //   int secUserID = int.Parse(HttpContext.Current.Session["UserID"].ToString());// == null ? string.Empty : HttpContext.Current.Session["UserID"].ToString(), out UserId) ? UserId : 0;
        public InvGroupsController()
        {
            this.invGroupService = new InvGroupService(db);
        }
        // GET: InvGroups

        public ActionResult Index()
        {
            db.Configuration.ProxyCreationEnabled = false;

            var invGroups = db.InvGroups.OrderByDescending(i => i.InvGroup1.Count).Take(3);
            return View(invGroups.ToList());
        }

        // GET: InvGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvGroup invGroup = db.InvGroups.Find(id);
            if (invGroup == null)
            {
                return HttpNotFound();
            }
            return View(invGroup);
        }

        // GET: InvGroups/Create
        public ActionResult Create()
        {
            ViewBag.ParentID = new SelectList(db.InvGroups, "InvGroupID", "GroupName");
            return View();
        }

        // POST: InvGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InvGroupID,GroupName,Notes,GroupNameEN,NotesEN,ParentID,PhotoG")] InvGroup invGroup)
        {
            if (ModelState.IsValid)
            {
                db.InvGroups.Add(invGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ParentID = new SelectList(db.InvGroups, "InvGroupID", "GroupName", invGroup.ParentID);
            return View(invGroup);
        }

        // GET: InvGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvGroup invGroup = db.InvGroups.Find(id);
            if (invGroup == null)
            {
                return HttpNotFound();
            }
            ViewBag.ParentID = new SelectList(db.InvGroups, "InvGroupID", "GroupName", invGroup.ParentID);
            return View(invGroup);
        }

        // POST: InvGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InvGroupID,GroupName,Notes,GroupNameEN,NotesEN,ParentID,PhotoG")] InvGroup invGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ParentID = new SelectList(db.InvGroups, "InvGroupID", "GroupName", invGroup.ParentID);
            return View(invGroup);
        }

        // GET: InvGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvGroup invGroup = db.InvGroups.Find(id);
            if (invGroup == null)
            {
                return HttpNotFound();
            }
            return View(invGroup);
        }

        // POST: InvGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InvGroup invGroup = db.InvGroups.Find(id);
            db.InvGroups.Remove(invGroup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        public ActionResult LoadItems()
        {

            List<InvItem> invItems = db.InvItems.ToList();
            List<InvItemStore> invItemStores = db.InvItemStores.ToList();
            List<InvUnit> invUnits = db.InvUnits.ToList();
            List<InvStore> invStores = db.InvStores.ToList();
            List<InvItemBalanceEvaluate> invItemBalanceEvaluates = db.InvItemBalanceEvaluates.ToList();
            List<InvGroup> invGroups = db.InvGroups.ToList();

            var itemG = (from i in invItems
                         join s in invItemStores.DefaultIfEmpty() on i.InvItemID equals s.InvItemID
                         join st in invStores.DefaultIfEmpty() on s.InvStoreID equals st.InvStoreID
                         join u in invUnits.DefaultIfEmpty() on i.InvUnitID equals u.InvUnitID
                         //join baln in invItemBalanceEvaluates.DefaultIfEmpty() on s.InvItemStoreID equals baln.InvItemStoreID
                         join grp in invGroups.DefaultIfEmpty() on i.InvGroupID equals grp.InvGroupID
                         orderby grp.InvGroupID descending


                         //where // ((storeID == null) || s.InvStoreID == storeID) &&
                         // (/*(groupID == null) || */i.InvGroupID == ID)
                         select new InvItemViewModel
                         {
                             InvItemID = i.InvItemID,
                             ItemName = i.ItemName,
                             ItemCode = i.ItemCode,
                             UnitName = u.UnitName,
                             InvUnitID = u.InvUnitID,
                             GroupName = grp.GroupName,
                             InvGroupID = grp.InvGroupID,
                             InvItemStoreID = s.InvItemStoreID,
                             SellingPrice = s.SellingPrice

                         }

     );



            return View(itemG);
        }
        public ActionResult LoadItems_pp(int ID)
        {
            if (ID == null)
            {
                return View();//new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<InvItem> invItems = db.InvItems.ToList();
            List<InvItemStore> invItemStores = db.InvItemStores.ToList();
            List<InvUnit> invUnits = db.InvUnits.ToList();
            List<InvStore> invStores = db.InvStores.ToList();
            List<InvItemBalanceEvaluate> invItemBalanceEvaluates = db.InvItemBalanceEvaluates.ToList();
            List<InvGroup> invGroups = db.InvGroups.ToList();

            var itemG = (from i in invItems
                         join s in invItemStores on i.InvItemID equals s.InvItemID
                         join st in invStores on s.InvStoreID equals st.InvStoreID
                         join u in invUnits on i.InvUnitID equals u.InvUnitID
                         join baln in invItemBalanceEvaluates on s.InvItemStoreID equals baln.InvItemStoreID
                         join grp in invGroups on i.InvGroupID equals grp.InvGroupID
                         //    join ph in this.context.InvItemPhotoes on i.InvItemID equals ph.InvItemID

                         where // ((storeID == null) || s.InvStoreID == storeID) &&
                          (/*(groupID == null) || */i.InvGroupID == ID)
                         select new InvItemViewModel
                         {
                             InvItemID = i.InvItemID,
                             ItemName = i.ItemName,
                             ItemCode = i.ItemCode,
                             UnitName = u.UnitName,
                             GroupName = grp.GroupName,
                             InvGroupID = grp.InvGroupID
                             //invStore = st,
                             //invUnit = u,
                             //InvItemBalanceEvaluate = baln
                         }

     );



            //return Json(result);
            return View(itemG);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult LoadItems(FormCollection form)
        {
            ArApInvoiceItemTemp arApInvoiceItemTemp = new ArApInvoiceItemTemp();           // string UserName = form["UserName"].ToString();
            ArApInvoiceTemp arApInvoiceTemp = new ArApInvoiceTemp();
            int ArApInvoiceID = 0;
            string InvoiceCode = "";
            string UserName = form["UserName"].ToString();

            #region Get UserID


            var User_ID = (from U in Sec.SecUsers
                           where U.UserName == UserName.ToString()
                           select new { U.SecUserID }
                      ).FirstOrDefault();


            #endregion
            int UUserID = int.Parse(User_ID.SecUserID.ToString());
            try
            {
                var max_ArApInvoiceID = db.ArApInvoiceTemps.Where(r => r.ArApDelegateID == UUserID)
                            .Max(r => r.ArApInvoiceID).ToString();

                var max_InvoiceCode = db.ArApInvoiceTemps.Find(int.Parse(max_ArApInvoiceID.ToString())); //(from invtrmp in db.ArApInvoiceTemps
                                                                                                         //                       where (invtrmp.ArApInvoiceID ==int.Parse(max_ArApInvoiceID.ToString()))
                                                                                                         //                       select invtrmp.);
                                                                                                         //

                ArApInvoiceID = int.Parse(max_ArApInvoiceID.ToString());
                arApInvoiceTemp.InvoiceCode = (int.Parse(max_InvoiceCode.InvoiceCode) + 1).ToString();
                InvoiceCode = (int.Parse(max_InvoiceCode.InvoiceCode) + 1).ToString();
            }
            catch (Exception ex)
            {
                arApInvoiceTemp.InvoiceCode = "1";
                InvoiceCode = "1";
            }

            string Quan = form["Quan"].ToString();//InvItemStore.InvItemStoreID; 
            string ItemCode = form["ItemCode"].ToString();
            string InvItemStoreID = form["InvItemStoreID"].ToString();
            string InvUnitID = form["InvUnitID"].ToString();
            string SellingPrice = form["SellingPrice"].ToString();

            #region Get UserID


            //var User_ID = (from U in Sec.SecUsers
            //              where U.UserName == UserName.ToString()
            //              select new { U.SecUserID}
            //          ).FirstOrDefault();


            #endregion

            #region Master Data
            arApInvoiceTemp.InvoiceCode = InvoiceCode;
            arApInvoiceTemp.ArApDelegateIDMarketing = int.Parse(Session["SecUserID"].ToString());
            arApInvoiceTemp.InvoiceDate = DateTime.Now.Date;
            arApInvoiceTemp.TotalDiscountValue = 0;
            arApInvoiceTemp.TotalEffectsValue = 0;
            arApInvoiceTemp.TotalPrice = 0;
            arApInvoiceTemp.TransactionType = 0;
            arApInvoiceTemp.InvoiceFlag = 1;
            arApInvoiceTemp.ArApDelegateID = int.Parse(Session["SecUserID"].ToString());
            arApInvoiceTemp.DefBranchID = 1;
            arApInvoiceTemp.DueDate = DateTime.Now.Date;
            arApInvoiceTemp.ArApInvoiceTypeID = 2;
            arApInvoiceTemp.DefBranchID = int.Parse(db.Branches.Select(x => x.DefBranchID).FirstOrDefault().ToString());

            arApInvoiceTemp.PaymentMethod = short.Parse(Session["PaymentMethod"].ToString());
            arApInvoiceTemp.ArApCustomerSupplierID = int.Parse(Session["ArApCustomerSupplierID"].ToString());
            arApInvoiceTemp.InvStoreID = int.Parse(Session["InvStoreID"].ToString());
            try
            {
                arApInvoiceTemp.Note = Session["Note"].ToString();
            }
            catch
            { }
            // (inv.Netprice == null) ? 0 : inv.Netprice

            try
            {
                db.ArApInvoiceTemps.Add(arApInvoiceTemp);
                db.SaveChanges();
            }
            catch
            {

            }
            #endregion

            #region get invoice id

            var Inv_ID = (from invtemp in db.ArApInvoiceTemps
                          where (invtemp.InvoiceCode == InvoiceCode) && (invtemp.ArApDelegateID == UUserID)
                          select new { invtemp.ArApInvoiceID }
                ).FirstOrDefault();
            #endregion
            decimal TotalNet = 0;
            if (Quan != null)
            {
                string[] values_Quan = Quan.Split(',');
                string[] values_ItemCode = ItemCode.Split(',');
                string[] values_InvItemStoreID = InvItemStoreID.Split(',');
                string[] values_InvUnitID = InvUnitID.Split(',');
                string[] values_SellingPrice = SellingPrice.Split(',');
                for (int i = 0; i < values_Quan.Length; i++)
                {
                    if (values_Quan[i] != "")
                    {
                        arApInvoiceItemTemp.Quantity = Convert.ToDecimal(values_Quan[i].Trim().ToString());
                        arApInvoiceItemTemp.InvItemStoreID = int.Parse(values_InvItemStoreID[i].Trim().ToString());
                        arApInvoiceItemTemp.InvUnitID = int.Parse(values_InvUnitID[i].Trim().ToString());
                        try
                        {
                            arApInvoiceItemTemp.SellingPrice = Convert.ToDecimal(values_SellingPrice[i].Trim());
                        }
                        catch
                        {
                            arApInvoiceItemTemp.SellingPrice = 0;
                        }
                        arApInvoiceItemTemp.NetPrice = Convert.ToDecimal(arApInvoiceItemTemp.SellingPrice * arApInvoiceItemTemp.Quantity);
                        TotalNet = TotalNet + arApInvoiceItemTemp.NetPrice;
                        #region
                        //values_ItemCode[i] = values_ItemCode[i].Trim();
                        //values_InvItemStoreID[i] = values_InvItemStoreID[i].Trim();
                        //values_InvUnitID[i] = values_InvUnitID[i].Trim();
                        //values_SellingPrice[i] = values_SellingPrice[i].Trim();


                        //customer.Logn_line = values[0].ToString();
                        // customer.Latit_Line = values[1].ToString();
                        #endregion
                        #region static data
                        arApInvoiceItemTemp.ConvertFactor = 1;
                        arApInvoiceItemTemp.EffectsValue = 0;
                        arApInvoiceItemTemp.InvoiceItemFlag = 1;
                        arApInvoiceItemTemp.FreeQuantity = 0;
                        #endregion
                        arApInvoiceItemTemp.UserID = int.Parse(User_ID.SecUserID.ToString());
                        arApInvoiceItemTemp.ArApInvoiceID = int.Parse(Inv_ID.ArApInvoiceID.ToString());
                        arApInvoiceItemTemp.ArApInvoiceCode = InvoiceCode.ToString();
                        try
                        {
                            db.ArApInvoiceItemTemps.Add(arApInvoiceItemTemp);
                            db.SaveChanges();

                        }
                        catch (Exception ex)
                        {

                        }

                    }
                }
                Session["ArApInvoiceID"] = arApInvoiceItemTemp.ArApInvoiceID;
                #region Update Master Invoice Adding Total Price For Invoice
                var InvoiceT = db.ArApInvoiceTemps.Where(x => x.ArApInvoiceID == arApInvoiceItemTemp.ArApInvoiceID).FirstOrDefault();
                if (InvoiceT != null)
                {
                    InvoiceT.Netprice = TotalNet;
                    db.Entry(InvoiceT).State = EntityState.Modified;
                    db.SaveChanges();
                }
                #endregion
                return RedirectToAction("DetailsInv", "ArApInvoiceTemps", Session["ArApInvoiceID"]);

            }
            // }
            return RedirectToAction("Cat", "Home");
        }




        public ActionResult LoadItems_Edit()
        {

            List<InvItem> invItems = db.InvItems.ToList();
            List<InvItemStore> invItemStores = db.InvItemStores.ToList();
            List<InvUnit> invUnits = db.InvUnits.ToList();
            List<InvStore> invStores = db.InvStores.ToList();
            List<InvItemBalanceEvaluate> invItemBalanceEvaluates = db.InvItemBalanceEvaluates.ToList();
            List<InvGroup> invGroups = db.InvGroups.ToList();

            var itemG = (from i in invItems
                         join s in invItemStores.DefaultIfEmpty() on i.InvItemID equals s.InvItemID
                         join st in invStores.DefaultIfEmpty() on s.InvStoreID equals st.InvStoreID
                         join u in invUnits.DefaultIfEmpty() on i.InvUnitID equals u.InvUnitID
                         //join baln in invItemBalanceEvaluates on s.InvItemStoreID equals baln.InvItemStoreID
                         join grp in invGroups.DefaultIfEmpty() on i.InvGroupID equals grp.InvGroupID
                         orderby grp.InvGroupID descending


                         //where // ((storeID == null) || s.InvStoreID == storeID) &&
                         // (/*(groupID == null) || */i.InvGroupID == ID)
                         select new InvItemViewModel
                         {
                             InvItemID = i.InvItemID,
                             ItemName = i.ItemName,
                             ItemCode = i.ItemCode,
                             UnitName = u.UnitName,
                             InvUnitID = u.InvUnitID,
                             GroupName = grp.GroupName,
                             InvGroupID = grp.InvGroupID,
                             InvItemStoreID = s.InvItemStoreID,
                             SellingPrice = s.SellingPrice

                         }

     );



            return View(itemG);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult LoadItems_Edit(FormCollection form)
        {
            ArApInvoiceItemTemp arApInvoiceItemTemp = new ArApInvoiceItemTemp();
            // string UserName = form["UserName"].ToString();

            //try
            //{
            string UserName = form["UserName"].ToString();
            //}
            //catch
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            string Quan = form["Quan"].ToString();//InvItemStore.InvItemStoreID; 
            string ItemCode = form["ItemCode"].ToString();
            string InvItemStoreID = form["InvItemStoreID"].ToString();
            string InvUnitID = form["InvUnitID"].ToString();
            string SellingPrice = form["SellingPrice"].ToString();

            int ArApInvoiceID = int.Parse(form["ArApInvoiceID"].ToString());
            // string InvoiceCode = form["InvoiceCode"].ToString();
            #region Get UserID


            var User_ID = (from U in Sec.SecUsers
                           where U.UserName == UserName.ToString()
                           select new { U.SecUserID }
                      ).FirstOrDefault();


            #endregion
            #region get invoice id
            int UUserID = int.Parse(User_ID.SecUserID.ToString());
            var Inv_ID = (from invtemp in db.ArApInvoiceTemps
                          where (invtemp.ArApInvoiceID == ArApInvoiceID) && (invtemp.ArApDelegateID == UUserID)
                          select new { invtemp.InvoiceCode }
                ).FirstOrDefault();
            #endregion

            decimal TotalNet = 0;

            if (Quan != null)
            {

                string[] values_Quan = Quan.Split(',');
                string[] values_ItemCode = ItemCode.Split(',');
                string[] values_InvItemStoreID = InvItemStoreID.Split(',');
                string[] values_InvUnitID = InvUnitID.Split(',');
                string[] values_SellingPrice = SellingPrice.Split(',');
                if (Quan != "")
                {
                    db.ArApInvoiceItemTemps.RemoveRange(db.ArApInvoiceItemTemps.Where(c => c.ArApInvoiceID == ArApInvoiceID));
                    db.SaveChanges();
                }
                for (int i = 0; i < values_Quan.Length; i++)
                {
                    if (values_Quan[i] != "")
                    {
                        arApInvoiceItemTemp.Quantity = Convert.ToDecimal(values_Quan[i].Trim().ToString());
                        arApInvoiceItemTemp.InvItemStoreID = int.Parse(values_InvItemStoreID[i].Trim().ToString());
                        arApInvoiceItemTemp.InvUnitID = int.Parse(values_InvUnitID[i].Trim().ToString());
                        try
                        {
                            arApInvoiceItemTemp.SellingPrice = Convert.ToDecimal(values_SellingPrice[i].Trim());
                        }
                        catch
                        {
                            arApInvoiceItemTemp.SellingPrice = 0;
                        }
                        arApInvoiceItemTemp.NetPrice = Convert.ToDecimal(arApInvoiceItemTemp.SellingPrice * arApInvoiceItemTemp.Quantity);

                        TotalNet = TotalNet + arApInvoiceItemTemp.NetPrice;
                        #region
                        //values_ItemCode[i] = values_ItemCode[i].Trim();
                        //values_InvItemStoreID[i] = values_InvItemStoreID[i].Trim();
                        //values_InvUnitID[i] = values_InvUnitID[i].Trim();
                        //values_SellingPrice[i] = values_SellingPrice[i].Trim();


                        //customer.Logn_line = values[0].ToString();
                        // customer.Latit_Line = values[1].ToString();
                        #endregion
                        #region static data
                        arApInvoiceItemTemp.ConvertFactor = 1;
                        arApInvoiceItemTemp.EffectsValue = 0;
                        arApInvoiceItemTemp.InvoiceItemFlag = 1;
                        arApInvoiceItemTemp.FreeQuantity = 0;
                        #endregion
                        arApInvoiceItemTemp.UserID = int.Parse(User_ID.SecUserID.ToString());
                        arApInvoiceItemTemp.ArApInvoiceID = ArApInvoiceID; //int.Parse(Inv_ID.ArApInvoiceID.ToString());
                        arApInvoiceItemTemp.ArApInvoiceCode = Inv_ID.InvoiceCode.ToString();//InvoiceCode.ToString();
                        try
                        {
                            db.ArApInvoiceItemTemps.Add(arApInvoiceItemTemp);
                            db.SaveChanges();

                        }
                        catch (Exception ex)
                        {

                        }

                    }
                }
                Session["ArApInvoiceID"] = ArApInvoiceID;


                #region Update Master Invoice Adding Total Price For Invoice
                var InvoiceT = db.ArApInvoiceTemps.Where(x => x.ArApInvoiceID == ArApInvoiceID).FirstOrDefault();
                if (InvoiceT != null)
                {
                    InvoiceT.Netprice = TotalNet;
                    db.Entry(InvoiceT).State = EntityState.Modified;
                    db.SaveChanges();
                }
                #endregion
                return RedirectToAction("DetailsInv", "ArApInvoiceTemps", Session["ArApInvoiceID"]);

            }
            // }
            return RedirectToAction("Cat", "Home");
        }
        #region test
        //   public ActionResult LoadItems_Read([DataSourceRequest] DataSourceRequest request, int ID)
        //   {

        //       List<InvItem> invItems = db.InvItems.ToList();
        //       List<InvItemStore> invItemStores = db.InvItemStores.ToList();
        //       List<InvUnit> invUnits = db.InvUnits.ToList();
        //       List<InvStore> invStores = db.InvStores.ToList();
        //       List<InvItemBalanceEvaluate> invItemBalanceEvaluates = db.InvItemBalanceEvaluates.ToList();

        //       var itemG = (from i in invItems
        //                    join s in invItemStores on i.InvItemID equals s.InvItemID
        //                    join st in invStores on s.InvStoreID equals st.InvStoreID
        //                    join u in invUnits on i.InvUnitID equals u.InvUnitID
        //                    join baln in invItemBalanceEvaluates on s.InvItemStoreID
        //                 equals baln.InvItemStoreID
        //                    //    join ph in this.context.InvItemPhotoes on i.InvItemID equals ph.InvItemID

        //                    where // ((storeID == null) || s.InvStoreID == storeID) &&
        //                     (/*(groupID == null) || */i.InvGroupID == ID)
        //                    select new InvItemViewModel
        //                    {
        //                        InvItemID = i.InvItemID,
        //                        ItemName = i.ItemName//,
        //                        //invStore = st,
        //                        //invUnit = u,
        //                        //InvItemBalanceEvaluate = baln
        //                    }

        //);

        //       return Json(request);
        //   }

        //   public ActionResult Remote_Data_Binding()
        //   {
        //       return View();
        //   }

        //   public ActionResult Remote_Data_Binding_Read([DataSourceRequest] DataSourceRequest request)
        //   {
        //       return Json(invGroupService.Read().ToDataSourceResult(request));
        //   }
        #endregion

    }
}
