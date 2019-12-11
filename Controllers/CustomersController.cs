using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Providers.Entities;
using EdgeMobile.Models;
using EdgeMobile.Models.ViewModels;
using PagedList;

namespace EdgeMobile.Controllers
{
    public class CustomersController : Controller
    {
        private ERPEdgeContext db = new ERPEdgeContext();
        //Session["SecUserID"] = Session["SecUserID"];
        //Session["UserName"] = Session["UserName"] ;
        // GET: Customers
        public ActionResult Index()
        {
            Session["SecUserID"] = Session["SecUserID"];
            Session["UserName"] = Session["UserName"];
            var customer = db.Customer.Include(c => c.Branch).Include(c => c.CustomerType).Include(c => c.DefCurrency).Include(c => c.DefLocation).Include(c => c.ArApMarketingDelegate);
            return View(customer.ToList());
        }

        public ActionResult Search()
        {
            ViewBag.ArApCustomerSupplierID = new SelectList(db.Customer, "CustomerSupplierCode", "CustomerSupplierName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(FormCollection form)
        {
         //   ViewBag.ArApCustomerSupplierID = new SelectList(db.Customer, "ArApCustomerSupplierID", "CustomerSupplierName");
            string strDDLValue =Request.Form["ArApCustomerSupplierID"].ToString();
          if (strDDLValue == null)
            {
                return View();
            }
            var customer = db.Customer.Where(m => m.CustomerSupplierCode== strDDLValue).Select(e => e.CustomerSupplierCode).ToList();//.Find(strDDLValue);
            return View(customer);
        }
        // GET: Customers/Details/5
        public ActionResult Details(FormCollection form)
        {
          
            string strDDLValue = Request.Form["Telephone1"].ToString();
            int ArApCustomerSupplierID = db.Customer.Where(m => m.Telephone1 == strDDLValue || m.Telephone2==strDDLValue).Select(e => e.ArApCustomerSupplierID).FirstOrDefault();
            if (strDDLValue == "")
            {
               return RedirectToAction("IndexbyUserIDP");
            }
            Customer customer = db.Customer.Find(ArApCustomerSupplierID);
            if (customer == null)
            {
                ModelState.AddModelError("Telephone1", "جوال غير مستخدم");
                return View("Search");
            }
            return View(new[] { customer });
        }

        public ActionResult Details2(int? id)
        {
            Customer customer = db.Customer.Find(id);
            return View(customer);
            //string strDDLValue = Request.Form["Telephone1"].ToString();
            //int ArApCustomerSupplierID = db.Customer.Where(m => m.Telephone1 == strDDLValue || m.Telephone2 == strDDLValue).Select(e => e.ArApCustomerSupplierID).FirstOrDefault();
            //if (strDDLValue == "")
            //{
            //    return RedirectToAction("IndexbyUserIDP");
            //}
            //Customer customer = db.Customer.Find(ArApCustomerSupplierID);
            //if (customer == null)
            //{
            //    ModelState.AddModelError("Telephone1", "جوال غير مستخدم");
            //    return View("Search");
            //}
            //return View(new[] { customer });
        }
        public ActionResult IndexbyUserIDP(int? page)
        {
            List<Customer> customer = db.Customer.ToList();
            int   DelegateID =int.Parse(Session["SecUserID"].ToString());
            var Cust = (from customeri in customer
                        where customeri.ArApDelegateID == DelegateID
                        orderby customeri.ArApCustomerSupplierID descending
                        select new CustomerViewModel
                        {
                          ArApCustomerSupplierID=  customeri.ArApCustomerSupplierID,
                            CustomerSupplierCode= customeri.CustomerSupplierCode,
                            CustomerSupplierName=    customeri.CustomerSupplierName,
                            Telephone1= customeri.Telephone1,
                            Telephone2 = customeri.Telephone2,
                            Address = customeri.Address
                        }
                        );
            //db.Customer.Where(x => x.ArApDelegateID == DelegateID).Select(x=>x.Telephone1,);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(Cust.ToPagedList(pageNumber, pageSize));
            //return View(Cust);
        }
        // GET: Customers/Create
        public ActionResult Create()
        {
            try
            { 
            var CustomerID = db.Customer/*.Where(r => r.ArApDelegateIDMarketing == SecUserID)*/
                       .Max(r => r.ArApCustomerSupplierID).ToString();

            var CustomerCode = db.Customer.Find(int.Parse(CustomerID.ToString()));
            ViewBag.CustomerSupplierCode = (int.Parse(CustomerCode.CustomerSupplierCode) + 1).ToString();
            }
            catch
            {
                ViewBag.CustomerSupplierCode = "1";

            }
            


            ViewBag.DefBranchID = new SelectList(db.Branches, "DefBranchID", "BranchName");
            ViewBag.ArApCustomerSupplierTypeID = new SelectList(db.CustomerTypes, "ArApCustomerSupplierTypeID", "CustomerSupplierTypeCode");
            ViewBag.DefCurrencyID = new SelectList(db.DefCurrencies, "DefCurrencyID", "CurrencyName");
            ViewBag.DefLocationID = new SelectList(db.DefLocations, "DefLocationID", "LocationName");
            ViewBag.ArApDelegateIDMarketing = new SelectList(db.Delegates, "ArApDelegateID", "DelegateName");
            //var maxId = (db.Customer.Select(x => (int?)x.CustomerSupplierCode).Max() ?? 0) + 1
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)//[Bind(Include = "ArApCustomerSupplierID,CustomerSupplierCode,CustomerSupplierName,CustomerSupplierNameEN,DefBranchID,DefLocationID,DefCurrencyID,ArApCustomerSupplierTypeID,ArApCustomerSupplierCategoryID,GlAccountID,GlSubAccountID,DealingStartDate,Status,BusinessName,POBox,PostalCode,RecordTrading,Telephone1,Telephone2,Telephone3,Fax,Email,ResponsibleName,Address,HasCreditLimit,CreditLimit,InitialCredit,ArApPaymentPeriodID,ArApCustomerSupplierGroupID,CustomerSupplierFlag,LocalDebit,LocalCredit,ArApDelegateIDMarketing,ArApDelegateID,ArApDelegateIDCollection,NotificationValueCreditLimit,ArCreditTypeID,ArApDiscountID,CreditPeriod,SellingPriceType,PaymentMethod,CustomerSupplierType,RecordOwnerID,RowVersionNumber,Logn_line,Latit_Line")] Customer customer)
        {

            try
            {
                var CustomerID = db.Customer/*.Where(r => r.ArApDelegateIDMarketing == SecUserID)*/
                           .Max(r => r.ArApCustomerSupplierID).ToString();

                var CustomerCode = db.Customer.Find(int.Parse(CustomerID.ToString()));
               customer.CustomerSupplierCode = (int.Parse(CustomerCode.CustomerSupplierCode) + 1).ToString();
            }
            catch
            {
                customer.CustomerSupplierCode = "1";

            }
            Session["SecUserID"] = Session["SecUserID"];
            Session["UserName"] = Session["UserName"];
            customer.Status = 2;
            customer.PaymentMethod = 0;
            customer.HasCreditLimit = 1;
            customer.CustomerSupplierFlag = 2;
            customer.ArApCustomerSupplierGroupID = 1;
            customer.CustomerSupplierNameEN = customer.CustomerSupplierName;
            customer.ArApCustomerSupplierTypeID = 1;
            customer.DefBranchID = 1;
            try
            {
                customer.ArApDelegateID = Convert.ToInt32(Session["SecUserID"].ToString());
            }
            catch
            {
                return RedirectToAction("Index", "Home");
                //customer.ArApDelegateID = 1;
            }
            string s = customer.Logn_Latit;
            if (s != null)
            {
                string[] values = s.Split(',');
                for (int i = 0; i < values.Length; i++)
                {
                    values[0] = values[0].Trim();
                    values[1] = values[1].Trim();
                    customer.Logn_line = values[0].ToString();
                    customer.Latit_Line = values[1].ToString();
                }
            }

            try
            {
                List<Customer> customersCode = db.Customer.Where(x => x.CustomerSupplierCode == customer.CustomerSupplierCode).ToList();
                List<Customer> customersTel1 = db.Customer.Where(x => x.Telephone1 == customer.Telephone1 || x.Telephone2 == customer.Telephone1).ToList();
                //List<Customer> customersTel2 = db.Customer.Where(x => x.Telephone1 == customer.Telephone2 || x.Telephone2 == customer.Telephone2).ToList();
                List<Customer> customersEmail = db.Customer.Where(x => x.Email == customer.Email).ToList(); 
                if (customersCode.Count > 0)
                {
                    ModelState.AddModelError("CustomerSupplierCode", "برجاء ادخال كود عميل غير مستعمل من قبل");
                    #region
                    //ViewBag.DefBranchID = new SelectList(db.Branches, "DefBranchID", "BranchName", customer.DefBranchID);
                    //ViewBag.ArApCustomerSupplierTypeID = new SelectList(db.CustomerTypes, "ArApCustomerSupplierTypeID", "CustomerSupplierTypeCode", customer.ArApCustomerSupplierTypeID);
                    //ViewBag.DefCurrencyID = new SelectList(db.DefCurrencies, "DefCurrencyID", "CurrencyName", customer.DefCurrencyID);
                    //ViewBag.DefLocationID = new SelectList(db.DefLocations, "DefLocationID", "LocationName", customer.DefLocationID);
                    //ViewBag.ArApDelegateIDMarketing = new SelectList(db.Delegates, "ArApDelegateID", "DelegateCode", customer.ArApDelegateIDMarketing);
                    //return View(customer);
                    #endregion
                }
                else if (customersTel1.Count > 0)
                {
                    ModelState.AddModelError("Telephone1", "برجاء ادخال رقم جوال غير مستعمل من قبل");
                }
                //else if(customersTel2.Count > 0)
                //{
                //    ModelState.AddModelError("Telephone2", "برجاء ادخال رقم جوال غير مستعمل من قبل");
                //}
                
                  //else if (customersEmail.Count > 0 && customer.Email != null)
                  //  {
                  //  ModelState.AddModelError("Email", "برجاء ادخال بريد الكتروني  غير مستعمل من قبل");
                  //  }
                
                else
                {
                    db.Customer.Add(customer);
                    db.SaveChanges();
                    
                    ViewBag.DefBranchID = new SelectList(db.Branches, "DefBranchID", "BranchName", customer.DefBranchID);
                    ViewBag.ArApCustomerSupplierTypeID = new SelectList(db.CustomerTypes, "ArApCustomerSupplierTypeID", "CustomerSupplierTypeCode", customer.ArApCustomerSupplierTypeID);
                    ViewBag.DefCurrencyID = new SelectList(db.DefCurrencies, "DefCurrencyID", "CurrencyName", customer.DefCurrencyID);
                    ViewBag.DefLocationID = new SelectList(db.DefLocations, "DefLocationID", "LocationName", customer.DefLocationID);
                    ViewBag.ArApDelegateIDMarketing = new SelectList(db.Delegates, "ArApDelegateID", "DelegateCode", customer.ArApDelegateIDMarketing);
                    ViewBag.CustomerSupplierCode = customer.CustomerSupplierCode;
                    ViewBag.Msgg = 1;
                    //   HR_COE();
                    ModelState.Clear();
                    try
                    {
                        var CustomerID = db.Customer/*.Where(r => r.ArApDelegateIDMarketing == SecUserID)*/
                                   .Max(r => r.ArApCustomerSupplierID).ToString();

                        var CustomerCode = db.Customer.Find(int.Parse(CustomerID.ToString()));
                        customer.CustomerSupplierCode = (int.Parse(CustomerCode.CustomerSupplierCode) + 1).ToString();
                    }
                    catch
                    {
                        customer.CustomerSupplierCode = "1";

                    }
                    ViewBag.CustomerSupplierCode = customer.CustomerSupplierCode;
                    return View();

                }
              
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                //throw;
            }
      

           ViewBag.DefBranchID = new SelectList(db.Branches, "DefBranchID", "BranchName", customer.DefBranchID);
            ViewBag.ArApCustomerSupplierTypeID = new SelectList(db.CustomerTypes, "ArApCustomerSupplierTypeID", "CustomerSupplierTypeCode", customer.ArApCustomerSupplierTypeID);
            ViewBag.DefCurrencyID = new SelectList(db.DefCurrencies, "DefCurrencyID", "CurrencyName", customer.DefCurrencyID);
           ViewBag.DefLocationID = new SelectList(db.DefLocations, "DefLocationID", "LocationName", customer.DefLocationID);
            ViewBag.ArApDelegateIDMarketing = new SelectList(db.Delegates, "ArApDelegateID", "DelegateCode", customer.ArApDelegateIDMarketing);
            ViewBag.CustomerSupplierCode = customer.CustomerSupplierCode;
            return View(customer);
        }
        public ContentResult HR_COE()
        {
            return Content("<script language='javascript' type='text/javascript'>alert     ('Requested Successfully ');</script>");
        }
        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customer.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.DefBranchID = new SelectList(db.Branches, "DefBranchID", "BranchName", customer.DefBranchID);
            ViewBag.ArApCustomerSupplierTypeID = new SelectList(db.CustomerTypes, "ArApCustomerSupplierTypeID", "CustomerSupplierTypeCode", customer.ArApCustomerSupplierTypeID);
            ViewBag.DefCurrencyID = new SelectList(db.DefCurrencies, "DefCurrencyID", "CurrencyName", customer.DefCurrencyID);
            ViewBag.DefLocationID = new SelectList(db.DefLocations, "DefLocationID", "LocationName", customer.DefLocationID);
            ViewBag.ArApDelegateIDMarketing = new SelectList(db.Delegates, "ArApDelegateID", "DelegateCode", customer.ArApDelegateIDMarketing);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArApCustomerSupplierID,CustomerSupplierCode,CustomerSupplierName,CustomerSupplierNameEN,DefBranchID,DefLocationID,DefCurrencyID,ArApCustomerSupplierTypeID,ArApCustomerSupplierCategoryID,GlAccountID,GlSubAccountID,DealingStartDate,Status,BusinessName,POBox,PostalCode,RecordTrading,Telephone1,Telephone2,Telephone3,Fax,Email,ResponsibleName,Address,HasCreditLimit,CreditLimit,InitialCredit,ArApPaymentPeriodID,ArApCustomerSupplierGroupID,CustomerSupplierFlag,LocalDebit,LocalCredit,ArApDelegateIDMarketing,ArApDelegateID,ArApDelegateIDCollection,NotificationValueCreditLimit,ArCreditTypeID,ArApDiscountID,CreditPeriod,SellingPriceType,PaymentMethod,CustomerSupplierType,RecordOwnerID,RowVersionNumber,Logn_line,Latit_Line")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DefBranchID = new SelectList(db.Branches, "DefBranchID", "BranchName", customer.DefBranchID);
            ViewBag.ArApCustomerSupplierTypeID = new SelectList(db.CustomerTypes, "ArApCustomerSupplierTypeID", "CustomerSupplierTypeCode", customer.ArApCustomerSupplierTypeID);
            ViewBag.DefCurrencyID = new SelectList(db.DefCurrencies, "DefCurrencyID", "CurrencyName", customer.DefCurrencyID);
            ViewBag.DefLocationID = new SelectList(db.DefLocations, "DefLocationID", "LocationName", customer.DefLocationID);
            ViewBag.ArApDelegateIDMarketing = new SelectList(db.Delegates, "ArApDelegateID", "DelegateCode", customer.ArApDelegateIDMarketing);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customer.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customer.Find(id);
            db.Customer.Remove(customer);
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
