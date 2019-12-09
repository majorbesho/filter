using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EdgeMobile.Models;
using EdgeMobile.Models.ViewModels;
//using FastReport;
//using FastReport.Web;

namespace EdgeMobile.Controllers
{
    public class ArApInvoiceItemTempsController : Controller
    {
        private ERPEdgeContext db = new ERPEdgeContext();

        // GET: ArApInvoiceItemTemps
        public ActionResult Index()
        {
           
            return View(db.ArApInvoiceItemTemps.ToList());
        }

        // GET: ArApInvoiceItemTemps/Details/5
        public ActionResult Details()
        {
            int id =int.Parse(Session["ArApInvoiceID"].ToString());//23; //
            int SecUserID= int.Parse(Session["SecUserID"].ToString());// = 1;
           // int ArApInvoiceID = id;
            if (id == null )
            {
                return RedirectToAction("Cat", "Home");
               // return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if(SecUserID == null)
            {
                return RedirectToAction("Index", "Home");
            }
            //ArApInvoiceItemTemp arApInvoiceItemTemp = db.ArApInvoiceItemTemps.Find(id);
            //if (arApInvoiceItemTemp == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(arApInvoiceItemTemp);

            

            List<InvItem> items = db.InvItems.ToList();
            List<InvUnit> invUnit = db.InvUnits.ToList();
            List<InvItemStore> invItemStore = db.InvItemStores.ToList();
            List<InvItemBalanceEvaluate> InvItemBalanceEvaluate = db.InvItemBalanceEvaluates.ToList();
            List<InvStore> invStore = db.InvStores.ToList();
            List<InvGroup> invGroup = db.InvGroups.ToList();
            List <ArApInvoiceTemp> ArApInvoiceTemp = db.ArApInvoiceTemps.ToList();
            List <ArApInvoiceItemTemp> ArApInvoiceItemTemp = db.ArApInvoiceItemTemps.ToList();
            List <Models.Delegate> Delegate = db.Delegates.ToList();
            List <Customer> customer = db.Customer.ToList();
            List <Branch> Branch = db.Branches.ToList();

            var Invoice = (from inv in ArApInvoiceTemp
                           join invitem in ArApInvoiceItemTemp.DefaultIfEmpty() on inv.ArApInvoiceID equals invitem.ArApInvoiceID
                        //   join delc in Delegate.DefaultIfEmpty() on inv.ArApDelegateID equals delc.ArApDelegateID
                         //join bran in Branch.DefaultIfEmpty() on inv.DefBranchID equals bran.DefBranchID
                         join str in invItemStore.DefaultIfEmpty() on invitem.InvItemStoreID equals str.InvItemStoreID
                         join item in items.DefaultIfEmpty() on str.InvItemID equals item.InvItemID
                    //    join cust in customer.DefaultIfEmpty() on inv.ArApCustomerSupplierID equals cust.ArApCustomerSupplierID
                           join grp in invGroup.DefaultIfEmpty() on item.InvGroupID equals grp.InvGroupID
                           where (inv.ArApInvoiceID == id) && (inv.ArApDelegateID == SecUserID)
                           select new InvoiceViewModel
                           {
                           //    InvoiceCode=inv.InvoiceCode,
                          //     InvoiceDate= inv.InvoiceDate,

                              // NetpriceInv = (inv.Netprice==null)?0 :inv.Netprice,
                              ArApInvoiceID = invitem.ArApInvoiceID,
                             ItemCode= item.ItemCode,
                             ItemName= item.ItemName,
                               Quantity=   invitem.Quantity,
                               SellingPrice= invitem.SellingPrice,
                               Netprice = invitem.NetPrice,
                              // DelegateName=delc.DelegateName,
                            // BranchName=bran.BranchName,
                            // CustomerSupplierName= cust.CustomerSupplierName,
                             GroupName=  grp.GroupName
                           }
                          );
            return View(Invoice);
        }

        //public ActionResult RepDetails()
        //{
        //    int id = int.Parse(Session["ArApInvoiceID"].ToString());//23; //
        //    int SecUserID = int.Parse(Session["SecUserID"].ToString());// = 1;
        //                                                               // int ArApInvoiceID = id;
        //    if (id == null)
        //    {
        //        return RedirectToAction("Cat", "Home");
        //        // return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    if (SecUserID == null)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //    //ArApInvoiceItemTemp arApInvoiceItemTemp = db.ArApInvoiceItemTemps.Find(id);
        //    //if (arApInvoiceItemTemp == null)
        //    //{
        //    //    return HttpNotFound();
        //    //}
        //    //return View(arApInvoiceItemTemp);



        //    List<InvItem> items = db.InvItems.ToList();
        //    List<InvUnit> invUnit = db.InvUnits.ToList();
        //    List<InvItemStore> invItemStore = db.InvItemStores.ToList();
        //    List<InvItemBalanceEvaluate> InvItemBalanceEvaluate = db.InvItemBalanceEvaluates.ToList();
        //    List<InvStore> invStore = db.InvStores.ToList();
        //    List<InvGroup> invGroup = db.InvGroups.ToList();
        //    List<ArApInvoiceTemp> ArApInvoiceTemp = db.ArApInvoiceTemps.ToList();
        //    List<ArApInvoiceItemTemp> ArApInvoiceItemTemp = db.ArApInvoiceItemTemps.ToList();
        //    List<Models.Delegate> Delegate = db.Delegates.ToList();
        //    List<Customer> customer = db.Customer.ToList();
        //    List<Branch> Branch = db.Branches.ToList();

        //    var Invoice = (from inv in ArApInvoiceTemp
        //                   join invitem in ArApInvoiceItemTemp.DefaultIfEmpty() on inv.ArApInvoiceID equals invitem.ArApInvoiceID
        //                      join delc in Delegate.DefaultIfEmpty() on inv.ArApDelegateID equals delc.ArApDelegateID
        //                   join bran in Branch.DefaultIfEmpty() on inv.DefBranchID equals bran.DefBranchID
        //                   join str in invItemStore.DefaultIfEmpty() on invitem.InvItemStoreID equals str.InvItemStoreID
        //                   join item in items.DefaultIfEmpty() on str.InvItemID equals item.InvItemID
        //                       join cust in customer.DefaultIfEmpty() on inv.ArApCustomerSupplierID equals cust.ArApCustomerSupplierID
        //                   join grp in invGroup.DefaultIfEmpty() on item.InvGroupID equals grp.InvGroupID
        //                   where (inv.ArApInvoiceID == id) && (inv.ArApDelegateID == SecUserID)
        //                   select new RepInvoiceViewModel
        //                   {
        //                           InvoiceCode=inv.InvoiceCode,
        //                           InvoiceDate= inv.InvoiceDate,
        //                       NetpriceInv = (inv.Netprice==null)?0 :inv.Netprice,
        //                       ItemCode = item.ItemCode,
        //                       ItemName = item.ItemName,
        //                       Quantity = invitem.Quantity,
        //                       SellingPrice = invitem.SellingPrice,
        //                       Netprice = invitem.NetPrice,
        //                        DelegateName=delc.DelegateName,
        //                        BranchName=bran.BranchName,
        //                        CustomerSupplierName= cust.CustomerSupplierName//,
        //                       GroupName = grp.GroupName
        //                   }
        //                  );




        //    //var webReport = new Report();
        //    //webReport.Load("~/Reports/ArReportInvoice.frx");
        //    //    /*HttpContext.Current.Server.MapPath("~/Arabic/AccountReceivable/FlatLayout/Reports/FrxDesign/ArReportInvoice.frx");*/

        //    //webReport.RegisterData(Invoice.ToList(), "Table");

        //    return View(Invoice);
        //}
        public ActionResult DetailsT()
        {
            int id =int.Parse(Session["ArApInvoiceID"].ToString());// 23; //
            int SecUserID = int.Parse(Session["SecUserID"].ToString());// 1;//
                              // int ArApInvoiceID = id;
            if (id == null)
            {
                return View("Cat", "Home");
                // return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (SecUserID == null)
            {
                return RedirectToAction("Index", "Home");
            }
            //ArApInvoiceItemTemp arApInvoiceItemTemp = db.ArApInvoiceItemTemps.Find(id);
            //if (arApInvoiceItemTemp == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(arApInvoiceItemTemp);



            List<InvItem> items = db.InvItems.ToList();
            List<InvUnit> invUnit = db.InvUnits.ToList();
            List<InvItemStore> invItemStore = db.InvItemStores.ToList();
            List<InvItemBalanceEvaluate> InvItemBalanceEvaluate = db.InvItemBalanceEvaluates.ToList();
            List<InvStore> invStore = db.InvStores.ToList();
            List<InvGroup> invGroup = db.InvGroups.ToList();
            List<ArApInvoiceTemp> ArApInvoiceTemp = db.ArApInvoiceTemps.ToList();
            List<ArApInvoiceItemTemp> ArApInvoiceItemTemp = db.ArApInvoiceItemTemps.ToList();
            List<Models.Delegate> Delegate = db.Delegates.ToList();
            List<Customer> customer = db.Customer.ToList();
            List<Branch> Branch = db.Branches.ToList();

            var Invoice = (from inv in ArApInvoiceTemp
                           join invitem in ArApInvoiceItemTemp.DefaultIfEmpty() on inv.ArApInvoiceID equals invitem.ArApInvoiceID
                           //   join delc in Delegate.DefaultIfEmpty() on inv.ArApDelegateID equals delc.ArApDelegateID
                           //join bran in Branch.DefaultIfEmpty() on inv.DefBranchID equals bran.DefBranchID
                           join str in invItemStore.DefaultIfEmpty() on invitem.InvItemStoreID equals str.InvItemStoreID
                           join item in items.DefaultIfEmpty() on str.InvItemID equals item.InvItemID
                           //    join cust in customer.DefaultIfEmpty() on inv.ArApCustomerSupplierID equals cust.ArApCustomerSupplierID
                           join grp in invGroup.DefaultIfEmpty() on item.InvGroupID equals grp.InvGroupID
                           where (inv.ArApInvoiceID == id) && (inv.ArApDelegateID == SecUserID)
                           select new InvoiceViewModel
                           {
                               //    InvoiceCode=inv.InvoiceCode,
                               //     InvoiceDate= inv.InvoiceDate,

                               // NetpriceInv = (inv.Netprice==null)?0 :inv.Netprice,
                               ArApInvoiceID = invitem.ArApInvoiceID,
                               ItemCode = item.ItemCode,
                               ItemName = item.ItemName,
                               Quantity = invitem.Quantity,
                               SellingPrice = invitem.SellingPrice,
                               Netprice = invitem.NetPrice,
                               // DelegateName=delc.DelegateName,
                               // BranchName=bran.BranchName,
                               // CustomerSupplierName= cust.CustomerSupplierName,
                               GroupName = grp.GroupName
                           }
                          );
            return View(Invoice);
        }
        // GET: ArApInvoiceItemTemps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArApInvoiceItemTemps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArApInvoiceItemID,ArApInvoiceID,ArApInvoiceCode,InvItemStoreID,InvUnitID,ConvertFactor,Quantity,Price,EffectsValue,NetPrice,InvoiceItemFlag,FreeQuantity,ItemCostPrice,ItemCostPriceFromSupplier,InvSizeID,InvColorID,ApPurchasingRequestOrderDetailID,SellingPrice,ArSalesOrderDetailID,OperationType,RecordOwnerID,UserID")] ArApInvoiceItemTemp arApInvoiceItemTemp)
        {
            if (ModelState.IsValid)
            {
                db.ArApInvoiceItemTemps.Add(arApInvoiceItemTemp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(arApInvoiceItemTemp);
        }

        // GET: ArApInvoiceItemTemps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArApInvoiceItemTemp arApInvoiceItemTemp = db.ArApInvoiceItemTemps.Find(id);
            if (arApInvoiceItemTemp == null)
            {
                return HttpNotFound();
            }
            return View(arApInvoiceItemTemp);
        }

        // POST: ArApInvoiceItemTemps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArApInvoiceItemID,ArApInvoiceID,ArApInvoiceCode,InvItemStoreID,InvUnitID,ConvertFactor,Quantity,Price,EffectsValue,NetPrice,InvoiceItemFlag,FreeQuantity,ItemCostPrice,ItemCostPriceFromSupplier,InvSizeID,InvColorID,ApPurchasingRequestOrderDetailID,SellingPrice,ArSalesOrderDetailID,OperationType,RecordOwnerID,UserID")] ArApInvoiceItemTemp arApInvoiceItemTemp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(arApInvoiceItemTemp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(arApInvoiceItemTemp);
        }

        // GET: ArApInvoiceItemTemps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArApInvoiceItemTemp arApInvoiceItemTemp = db.ArApInvoiceItemTemps.Find(id);
            if (arApInvoiceItemTemp == null)
            {
                return HttpNotFound();
            }
            return View(arApInvoiceItemTemp);
        }

        // POST: ArApInvoiceItemTemps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArApInvoiceItemTemp arApInvoiceItemTemp = db.ArApInvoiceItemTemps.Find(id);
            db.ArApInvoiceItemTemps.Remove(arApInvoiceItemTemp);
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
    }
}
