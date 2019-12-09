using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using EdgeMobile.Models;
using EdgeMobile.Models.ViewModels;

namespace EdgeMobile.Controllers
{
    public class GlCashVoucherCashesController : Controller
    {
        private ERPEdgeContext db = new ERPEdgeContext();

        // GET: GlCashVoucherCashes
        public ActionResult Index()
        {
            var glCashVoucherCashes = db.GlCashVoucherCashes.Include(g => g.ArApCustomerSupplier).Include(g => g.ArApDelegate);
            return View(glCashVoucherCashes.ToList());
        }

        // GET: GlCashVoucherCashes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GlCashVoucherCash glCashVoucherCash = db.GlCashVoucherCashes.Find(id);
            if (glCashVoucherCash == null)
            {
                return HttpNotFound();
            }
            return View(glCashVoucherCash);
        }

        // GET: GlCashVoucherCashes/Create
        public ActionResult Create()
        {
            //try
            //{
            //    var CustomerID = db.Customer/*.Where(r => r.ArApDelegateIDMarketing == SecUserID)*/
            //               .Max(r => r.ArApCustomerSupplierID).ToString();

            //    var CustomerCode = db.Customer.Find(int.Parse(CustomerID.ToString()));
            //    ViewBag.CustomerSupplierCode = (int.Parse(CustomerCode.CustomerSupplierCode) + 1).ToString();
            //}
            //catch
            //{
            //    ViewBag.CustomerSupplierCode = "1";

            //}
            try
            {
                var CashVoucherID = db.GlCashVoucherCashes/*.Where(r => r.ArApDelegateIDMarketing == SecUserID)*/
                           .Max(r => r.GlCashVoucherCID).ToString();

                var CashVoucherS = db.GlCashVoucherCashes.Find(int.Parse(CashVoucherID.ToString()));
                ViewBag.CashVoucherSerial = (int.Parse(CashVoucherS.CashVoucherSerial) + 1).ToString();
            }
            catch
            {
                ViewBag.CashVoucherSerial = "1";

            }
            ViewBag.ArApCustomerSupplierID = new SelectList(db.Customer, "ArApCustomerSupplierID", "CustomerSupplierName");
            ViewBag.ArApDelegateID = new SelectList(db.Delegates, "DelegateCode", "DelegateName");
            return View();
        }

        // POST: GlCashVoucherCashes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GlCashVoucherCash glCashVoucherCash)//[Bind(Include = "GlCashVoucherCID,CashVoucherSerial,CashVoucherDate,ArApCustomerSupplierID,ArApDelegateID,CashVouchertype,CashVoucherValue,CashVoucherNote,RecordOwnerID,RowVersionNumber,IsDeleted,IsPosted")] GlCashVoucherCash glCashVoucherCash)
        {
            //if (ModelState.IsValid)
            glCashVoucherCash.CashVoucherDate = DateTime.Now.Date;
            glCashVoucherCash.CashVouchertype = 0;
            try
            {
                var CashVoucherID = db.GlCashVoucherCashes/*.Where(r => r.ArApDelegateIDMarketing == SecUserID)*/
                           .Max(r => r.GlCashVoucherCID).ToString();

                var CashVoucherS = db.GlCashVoucherCashes.Find(int.Parse(CashVoucherID.ToString()));
                glCashVoucherCash.CashVoucherSerial = (int.Parse(CashVoucherS.CashVoucherSerial) + 1).ToString();
            }
            catch
            {
                glCashVoucherCash.CashVoucherSerial = "1";

            }
            try
            {
                List<GlCashVoucherCash> cashVoucherCashes = db.GlCashVoucherCashes.Where(x => x.CashVoucherSerial == glCashVoucherCash.CashVoucherSerial).ToList();
                if (cashVoucherCashes.Count >0)
                {
                    ModelState.AddModelError("CashVoucherSerial", "برجاء ادخال سيريال غير مستخدم");
                }
                else
                {
                db.GlCashVoucherCashes.Add(glCashVoucherCash);
                db.SaveChanges();


                ViewBag.Msgg =1;

                    ReportDocument rd = new ReportDocument();
                    rd.Load(Server.MapPath("~/Reports/CashVouserR.rpt"));
                    var cashv = (from cash in db.GlCashVoucherCashes
                                 join cust in db.Customer on cash.ArApCustomerSupplierID equals cust.ArApCustomerSupplierID
                                 where cash.CashVoucherSerial == glCashVoucherCash.CashVoucherSerial
                                 select new RepCashVoucherViewModel
                                 {
                                  CashVoucherSerial=  cash.CashVoucherSerial,
                                     CashVoucherValue= cash.CashVoucherValue,
                                     CashVoucherDate= cash.CashVoucherDate,
                                     CustomerSupplierName= cust.CustomerSupplierName,
                                 GlCashVoucherCID = cash.GlCashVoucherCID,
                                 ArApDelegateID = cash.ArApDelegateID,
                                     CashVoucherNote= cash.CashVoucherNote
                                 }) ;
                    rd.SetDataSource(cashv.ToList());
                   

                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    stream.Seek(0, SeekOrigin.Begin);
                    
                    //rd.SetDataSource(db.GlCashVoucherCashes.Where(x=>x.CashVoucherSerial== glCashVoucherCash.CashVoucherSerial).Select(x=>x.CashVoucherSerial, ).ToList());
                  
                    ModelState.Clear();


                    try
                    {
                        var CashVoucherID = db.GlCashVoucherCashes/*.Where(r => r.ArApDelegateIDMarketing == SecUserID)*/
                                   .Max(r => r.GlCashVoucherCID).ToString();

                        var CashVoucherS = db.GlCashVoucherCashes.Find(int.Parse(CashVoucherID.ToString()));
                        glCashVoucherCash.CashVoucherSerial = (int.Parse(CashVoucherS.CashVoucherSerial) + 1).ToString();
                    }
                    catch
                    {
                        glCashVoucherCash.CashVoucherSerial = "1";

                    }
                    ViewBag.CashVoucherSerial = glCashVoucherCash.CashVoucherSerial;
                    ViewBag.ArApCustomerSupplierID = new SelectList(db.Customer, "ArApCustomerSupplierID", "CustomerSupplierName", glCashVoucherCash.ArApCustomerSupplierID);
                    ViewBag.ArApDelegateID = new SelectList(db.Delegates, "ArApDelegateID", "DelegateName", glCashVoucherCash.ArApDelegateID);


                    Response.Buffer = false;
                    Response.ClearContent();
                    Response.ClearHeaders();
                    return File(stream, "application/pdf", "CashVoucher.pdf");
                   
                    
                    return View();
                   // return RedirectToAction("Cat", "Home"); 
                }
            }
           catch(Exception ex)
            {

            }

            ViewBag.ArApCustomerSupplierID = new SelectList(db.Customer, "ArApCustomerSupplierID", "CustomerSupplierName", glCashVoucherCash.ArApCustomerSupplierID);
            ViewBag.ArApDelegateID = new SelectList(db.Delegates, "ArApDelegateID", "DelegateName", glCashVoucherCash.ArApDelegateID);
            try
            {
                var CashVoucherID = db.GlCashVoucherCashes/*.Where(r => r.ArApDelegateIDMarketing == SecUserID)*/
                           .Max(r => r.GlCashVoucherCID).ToString();

                var CashVoucherS = db.GlCashVoucherCashes.Find(int.Parse(CashVoucherID.ToString()));
                glCashVoucherCash.CashVoucherSerial = (int.Parse(CashVoucherS.CashVoucherSerial) + 1).ToString();
            }
            catch
            {
                glCashVoucherCash.CashVoucherSerial = "1";

            }
            ViewBag.CashVoucherSerial = glCashVoucherCash.CashVoucherSerial;
            return View(glCashVoucherCash);
        }

        // GET: GlCashVoucherCashes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GlCashVoucherCash glCashVoucherCash = db.GlCashVoucherCashes.Find(id);
            if (glCashVoucherCash == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArApCustomerSupplierID = new SelectList(db.Customer, "ArApCustomerSupplierID", "CustomerSupplierCode", glCashVoucherCash.ArApCustomerSupplierID);
            ViewBag.ArApDelegateID = new SelectList(db.Delegates, "ArApDelegateID", "DelegateCode", glCashVoucherCash.ArApDelegateID);
            return View(glCashVoucherCash);
        }

        // POST: GlCashVoucherCashes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GlCashVoucherCID,CashVoucherSerial,CashVoucherDate,ArApCustomerSupplierID,ArApDelegateID,CashVouchertype,CashVoucherValue,CashVoucherNote,RecordOwnerID,RowVersionNumber,IsDeleted,IsPosted")] GlCashVoucherCash glCashVoucherCash)
        {
            if (ModelState.IsValid)
            {
                db.Entry(glCashVoucherCash).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArApCustomerSupplierID = new SelectList(db.Customer, "ArApCustomerSupplierID", "CustomerSupplierCode", glCashVoucherCash.ArApCustomerSupplierID);
            ViewBag.ArApDelegateID = new SelectList(db.Delegates, "ArApDelegateID", "DelegateCode", glCashVoucherCash.ArApDelegateID);
            return View(glCashVoucherCash);
        }

        // GET: GlCashVoucherCashes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GlCashVoucherCash glCashVoucherCash = db.GlCashVoucherCashes.Find(id);
            if (glCashVoucherCash == null)
            {
                return HttpNotFound();
            }
            return View(glCashVoucherCash);
        }

        // POST: GlCashVoucherCashes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GlCashVoucherCash glCashVoucherCash = db.GlCashVoucherCashes.Find(id);
            db.GlCashVoucherCashes.Remove(glCashVoucherCash);
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
