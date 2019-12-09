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
    public class ArApInvoiceTempsController : Controller
    {

        public ERPEdgeContext db = new ERPEdgeContext();
        public ERPEdgeContext context = new ERPEdgeContext();
        //protected internal WebReport RViewerInvoice;


 //       public List<InvoiceReportModel> GetInvoiceLst(string invoiceCode, int UserID)
 //       {
 //           // custom date format 
 //           FastReport.Format.CustomFormat customFormat = new FastReport.Format.CustomFormat();
 //           customFormat.Format = "yyyy/MM";

 //           // Get invoices
 //           var invoiceQuery = (from invoice in context.ArApInvoiceTemps
 //                               where 
 //                               //(invoice.InvoiceFlag == (int)BaseEnum.InvoiceFlag.Sales)&& 
                                     
 //(string.Compare(invoice.InvoiceCode, invoiceCode) == default(int) && invoice.ArApDelegateID == UserID)
 //                               select new
 //                               {
 //                                   InvoiceCode = invoice.InvoiceCode,
 //                                   ArApInvoiceID = invoice.ArApInvoiceID,
 //                                   ArApDelegateIDSales = invoice.ArApDelegateID,
 //                                //   ArApDelegateIDMarketing = invoice.ArApDelegateIDMarketing,
 //                                   ArApCustomerSupplierID = invoice.ArApCustomerSupplierID,
 //                               }).ToList();

 //           // Header of invoice
 //           var invoiceDelegate = new List<InvoiceReportModel>();

 //           if (invoiceQuery.Count > default(int))
 //           {
 //               //invoiceDelegate = (from invoice in invoiceQuery
 //               //                   join delegte in context.Delegates on invoice.ArApDelegateIDSales equals delegte.ArApDelegateID
 //               //                   join customer in context.Customer on invoice.ArApCustomerSupplierID equals customer.ArApCustomerSupplierID
 //               //                   let marketingDelegateCode = context.Delegates.Where(d => d.ArApDelegateID == invoice.ArApDelegateIDMarketing).Select(c => c.DelegateCode).FirstOrDefault()
 //               //                   select new InvoiceReportModel
 //               //                   {
 //               //                       InvoiceID = invoice.ArApInvoiceID,
 //               //                       InvoiceCode = invoice.InvoiceCode,
 //               //                       DelegateSalesCode = delegte.DelegateCode,
 //               //                       CustomerSupplierCode = customer.CustomerSupplierCode,
 //               //                       CustomerSupplierName = customer.CustomerSupplierName,
 //               //                       CustomerSupplierNameEN = customer.CustomerSupplierNameEN,
 //               //                       Address = customer.Address,
 //               //                       MarketingDelegateCode = marketingDelegateCode,
 //               //                       // InvoiceDetails = new List<ArInvoiceDetailsReportModel>()
 //               //                   }).ToList();

 //               // Details Of Invoice
 //               foreach (var q in invoiceDelegate)
 //               {
 //                   q.InvoiceDetails = new List<InvoiceDetailsReportModel>();

 //                   var invoiceDetails = from invoice in invoiceDelegate
 //                                        join invoiceItem in context.ArApInvoiceItemTemps on invoice.InvoiceID equals invoiceItem.ArApInvoiceID into invoiceItemGroups
 //                                        from invoiceItemGroup in invoiceItemGroups.DefaultIfEmpty()
 //                                      //  join invoiceItemDetails in context.ArApInvoiceItemDetails on invoiceItemGroup.ArApInvoiceItemID equals invoiceItemDetails.ArApInvoiceItemID into invoiceItemDetailsGroups
 //                                     //   from invoiceItemDetailsGroup in invoiceItemDetailsGroups.DefaultIfEmpty()
 //                                        join itemStore in context.InvItemStores on invoiceItemGroup.InvItemStoreID equals itemStore.InvItemStoreID into itemStoreGroups
 //                                        from itemStoreGroup in itemStoreGroups.DefaultIfEmpty()
 //                                        join item in context.InvItems on itemStoreGroup.InvItemID equals item.InvItemID into itemGroups
 //                                        from itemGroup in itemGroups.DefaultIfEmpty()
 //                              //          join supplier in context.InvItemSuppliers on itemGroup.InvItemID equals supplier.InvItemID into supplierGroups
 //                                       // from supplierGroup in supplierGroups.DefaultIfEmpty()


 //                                            // join invoiceItemEffects in context.ArApInvoiceItemEffects on invoiceItem.ArApInvoiceItemID equals invoiceItemEffects.ArApInvoiceItemID
 //                                        where invoice.InvoiceID == q.InvoiceID

 //                                        let salesTax = invoiceItemGroup == null ? default(decimal) :
 //                                                        (from effect in context.InvEffects
 //                                                         join invoiceItemEffects in context.ArApInvoiceItemEffects on effect.InvEffectID equals invoiceItemEffects.InvEffectID
 //                                                         where invoiceItemEffects.ArApInvoiceItemID == invoiceItemGroup.ArApInvoiceItemID && effect.IsTax == (int)BaseEnum.SalesTax.SalesTax
 //                                                         select invoiceItemEffects.CalculatedEffectValue).FirstOrDefault()
 //                                        let ExpiryDate = invoiceItemDetailsGroup == null ? string.Empty : customFormat.FormatValue(invoiceItemDetailsGroup.ExpiryDate) // تاريخ الصلاحية
 //                                        let BatchNo = invoiceItemDetailsGroup == null ? string.Empty : invoiceItemDetailsGroup.BatchID  // رقم الباتش
 //                                        let OriginSupplierName = supplierGroup == null ? string.Empty : supplierGroup.OriginSupplierName  // الشركة المصنعة
 //                                        select new InvoiceDetailsReportModel
 //                                        {
 //                                            ItemName = itemGroup == null ? string.Empty : itemGroup.ItemName,                     // اسم الصنف 
 //                                            ItemDetails = OriginSupplierName + " Exp." + ExpiryDate + " B.No." + BatchNo,
 //                                            Quantity = invoiceItemDetailsGroup == null ? default(decimal) : invoiceItemDetailsGroup.Quantity, // الكمية
 //                                            FreeQuantity = invoiceItemGroup == null ? default(decimal) : invoiceItemGroup.FreeQuantity, // الكمية المجانية
 //                                            PeoplePrice = invoiceItemGroup == null ? default(decimal) : invoiceItemGroup.Price,  // سعر الجمهور
 //                                            SalesTax = salesTax,   // ضريبة المبيعات                                      //invoiceItem.Price *  0.034m,
 //                                            InvoiceID = q.InvoiceID,
 //                                            PharmacistDisCount = 0.00m,// خصم صيدلي
 //                                            TotalQuantityWithoutFree = invoiceItemGroup == null ? default(decimal) : invoiceItemGroup.Quantity,


 //                                        };

 //                   q.InvoiceDetails.AddRange(invoiceDetails);
 //               }

 //               return invoiceDelegate.ToList();
 //           }
 //           return invoiceDelegate.ToList();

 //       }
 //       internal void ConstructReport(Report report)
 //       {

 //       }

            // GET: ArApInvoiceTemps
        public ActionResult Index()
        {
            //int ID =int.Parse(id.ToString());//int.Parse(Session["ArApInvoiceID"].ToString());//23;
            int SecUserID = int.Parse(Session["SecUserID"].ToString());//1;

            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            List<ArApInvoiceTemp> ArApInvoiceTemp = db.ArApInvoiceTemps.ToList();
            List<Models.Delegate> Delegate = db.Delegates.ToList();
            List<Customer> customer = db.Customer.ToList();
            List<Branch> Branch = db.Branches.ToList();


            var Invv = (from inv in ArApInvoiceTemp
                        join cust in customer.DefaultIfEmpty() on inv.ArApCustomerSupplierID equals cust.ArApCustomerSupplierID
                        join delc in Delegate.DefaultIfEmpty() on inv.ArApDelegateID equals delc.ArApDelegateID
                        join bran in Branch.DefaultIfEmpty() on inv.DefBranchID equals bran.DefBranchID
                        where  (inv.ArApDelegateID == SecUserID)
                        select new InvoiceTViewModel
                        {
                            ArApInvoiceID = inv.ArApInvoiceID,
                            InvoiceCode = inv.InvoiceCode,
                            InvoiceDate = inv.InvoiceDate,
                            DelegateName = delc.DelegateName,
                            BranchName = bran.BranchName,
                            CustomerSupplierName = cust.CustomerSupplierName,
                            Netprice = (inv.Netprice == null) ? 0 : inv.Netprice
                        }
                                               );

            return View(Invv);
        }

        // GET: ArApInvoiceTemps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArApInvoiceTemp arApInvoiceTemp = db.ArApInvoiceTemps.Find(id);
            if (arApInvoiceTemp == null)
            {
                return HttpNotFound();
            }
            return View(arApInvoiceTemp);
        }
        public ActionResult Details_Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Session["ArApInvoiceID"] = id;
            // return RedirectToAction("LoadItems_Edit", "InvGroups");


           // int id = int.Parse(Session["ArApInvoiceID"].ToString());//23;
            int SecUserID = int.Parse(Session["SecUserID"].ToString());//1;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            #region
            //List<InvItem> items = db.InvItems.ToList();
            //List<InvUnit> invUnit = db.InvUnits.ToList();
            //List<InvItemStore> invItemStore = db.InvItemStores.ToList();
            //List<InvItemBalanceEvaluate> InvItemBalanceEvaluate = db.InvItemBalanceEvaluates.ToList();
            //List<InvStore> invStore = db.InvStores.ToList();
            //List<InvGroup> invGroup = db.InvGroups.ToList();
            // List<ArApInvoiceItemTemp> ArApInvoiceItemTemp = db.ArApInvoiceItemTemps.ToList();
            #endregion
            List<ArApInvoiceTemp> ArApInvoiceTemp = db.ArApInvoiceTemps.ToList();
            List<Models.Delegate> Delegate = db.Delegates.ToList();
            List<Customer> customer = db.Customer.ToList();
            List<Branch> Branch = db.Branches.ToList();


            var Invv = (from inv in ArApInvoiceTemp
                        join cust in customer.DefaultIfEmpty() on inv.ArApCustomerSupplierID equals cust.ArApCustomerSupplierID
                        join delc in Delegate.DefaultIfEmpty() on inv.ArApDelegateID equals delc.ArApDelegateID
                        join bran in Branch.DefaultIfEmpty() on inv.DefBranchID equals bran.DefBranchID
                        where (inv.ArApInvoiceID == id) && (inv.ArApDelegateID == SecUserID)
                        select new InvoiceTViewModel
                        {
                            ArApInvoiceID = inv.ArApInvoiceID,
                            InvoiceCode = inv.InvoiceCode,
                            InvoiceDate = inv.InvoiceDate,
                            DelegateName = delc.DelegateName,
                            BranchName = bran.BranchName,
                            CustomerSupplierName = cust.CustomerSupplierName,
                            Netprice = (inv.Netprice == null) ? 0 : inv.Netprice
                        }
                                               );

            return View(Invv);

            return View();
        }

        public ActionResult DetailsInv()
        {
            int id =  int.Parse(Session["ArApInvoiceID"].ToString());//23;
            int SecUserID = int.Parse(Session["SecUserID"].ToString());//1;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            #region
            //List<InvItem> items = db.InvItems.ToList();
            //List<InvUnit> invUnit = db.InvUnits.ToList();
            //List<InvItemStore> invItemStore = db.InvItemStores.ToList();
            //List<InvItemBalanceEvaluate> InvItemBalanceEvaluate = db.InvItemBalanceEvaluates.ToList();
            //List<InvStore> invStore = db.InvStores.ToList();
            //List<InvGroup> invGroup = db.InvGroups.ToList();
            // List<ArApInvoiceItemTemp> ArApInvoiceItemTemp = db.ArApInvoiceItemTemps.ToList();
            #endregion
            List<ArApInvoiceTemp> ArApInvoiceTemp = db.ArApInvoiceTemps.ToList();
            List<Models.Delegate> Delegate = db.Delegates.ToList();
            List<Customer> customer = db.Customer.ToList();
            List<Branch> Branch = db.Branches.ToList();


            var Invv = (from inv in ArApInvoiceTemp
                                   join cust in customer.DefaultIfEmpty() on inv.ArApCustomerSupplierID equals cust.ArApCustomerSupplierID
                                   join delc in Delegate.DefaultIfEmpty() on inv.ArApDelegateID equals delc.ArApDelegateID
                                   join bran in Branch.DefaultIfEmpty() on inv.DefBranchID equals bran.DefBranchID
                                   where (inv.ArApInvoiceID == id) && (inv.ArApDelegateID == SecUserID)
                                               select new InvoiceTViewModel
                                               {
                                                   ArApInvoiceID = inv.ArApInvoiceID,
                                                   InvoiceCode =  inv.InvoiceCode,
                                                   InvoiceDate =inv.InvoiceDate,
                                                   DelegateName = delc.DelegateName,
                                                   BranchName  =  bran.BranchName,
                                                   CustomerSupplierName = cust.CustomerSupplierName,
                                                   Netprice = (inv.Netprice == null ) ? 0 : inv.Netprice
                                               }
                                               );
            
            return View(Invv);
        }

        // GET: ArApInvoiceTemps/Create
        public ActionResult Create()
        {
            ViewBag.ArApCustomerSupplierID = new SelectList(db.Customer, "ArApCustomerSupplierID", "CustomerSupplierName");
           // ViewBag.ArApCustomerSupplierID = new SelectList(db.Delegates, "ArApCustomerSupplierID", "CustomerSupplierName");
            ViewBag.DefBranchID = new SelectList(db.Branches, "DefBranchID", "BranchName");
            ViewBag.DefCurrencyID = new SelectList(db.DefCurrencies, "DefCurrencyID", "CurrencyName");
            ViewBag.InvStoreID = new SelectList(db.InvStores, "InvStoreID", "StoreName");
            ViewBag.InvoiceDate = DateTime.Now.ToShortDateString();

            try
            {
                Session["SecUserID"] = Session["SecUserID"];
            }
            catch
            {
                //Session["SecUserID"] = 1;
                return View("Index", "Home");
            }
            int SecUserID = int.Parse(Session["SecUserID"].ToString());
            try
            {
                var max_ArApInvoiceID = db.ArApInvoiceTemps.Where(r => r.ArApDelegateIDMarketing == SecUserID)
                            .Max(r => r.ArApInvoiceID).ToString();

                var max_InvoiceCode = db.ArApInvoiceTemps.Find(int.Parse(max_ArApInvoiceID.ToString()));
                ViewBag.InvoiceCode = (int.Parse(max_InvoiceCode.InvoiceCode) + 1).ToString();

            }
            catch
            {
                ViewBag.InvoiceCode = "1";

            }
            return View();
          
        }

        // POST: ArApInvoiceTemps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArApInvoiceTemp arApInvoiceTemp)
        {
            /*[Bind(Include = "ArApInvoiceID,InvoiceCode,DefBranchID,InvoiceDate,DueDate,TransactionType,ArApReturnInvoiceID,InvStoreID,PaymentMethod,ArApCustomerSupplierID,ArApInvoiceTypeID,ArApSupplyOrderID,DefCurrencyID,ExchangeRate,ArApDelegateIDMarketing,ArApDelegateID,ArApDelegateIDCollection,Note,InvoiceFlag,Netprice,CreditPeriod,ApPurchasingOrderID,ApPurchasingRequestID,ApPriceOfferID,TotalDiscountPercentage,TotalDiscountValue,TotalEffectsValue,TotalPrice,ArApDiscountID,IsTotalsClaimCalculated,TotalSupplierEffectsValue,GlJournalID,JournalSerial,ArPurposeOfIssueID,ArSalesOrderID,ArPriceOfferID,IsIssueTransactions,recipient,InvoiceID,RecordOwnerID,RowVersionNumber,Amountpaid,RemainingAmount,ArWindowShowTypeID")] */
            if (ModelState.IsValid)
            {
                int ArApInvoiceID = 0;
                try
                {
                    Session["SecUserID"] = Session["SecUserID"];
                }
                catch
                {
                    //Session["SecUserID"] = 1;
                    return RedirectToAction("Index","Home");
                }
                int SecUserID = int.Parse(Session["SecUserID"].ToString());
                try
                {
                    var max_ArApInvoiceID = db.ArApInvoiceTemps.Where(r => r.ArApDelegateID ==SecUserID)
                                .Max(r => r.ArApInvoiceID).ToString();

                    var max_InvoiceCode =db.ArApInvoiceTemps.Find(int.Parse(max_ArApInvoiceID.ToString())); //(from invtrmp in db.ArApInvoiceTemps
                                                                                                            //                       where (invtrmp.ArApInvoiceID ==int.Parse(max_ArApInvoiceID.ToString()))
                                                                                                            //                       select invtrmp.);
                                                                                                            //

                    ArApInvoiceID =int.Parse(max_ArApInvoiceID.ToString());
                    arApInvoiceTemp.InvoiceCode = (int.Parse(max_InvoiceCode.InvoiceCode) + 1).ToString();
                    
                }
                catch (Exception ex)
                {
                    arApInvoiceTemp.InvoiceCode = "1";
                }


               
                arApInvoiceTemp.ArApDelegateIDMarketing = int.Parse(Session["SecUserID"].ToString());
                
                arApInvoiceTemp.InvoiceDate = DateTime.Now.Date;
               arApInvoiceTemp.TotalDiscountValue = 0;
                arApInvoiceTemp.TotalEffectsValue = 0;
                arApInvoiceTemp.TotalPrice = 0;
                arApInvoiceTemp.TransactionType =0;

                
              
                arApInvoiceTemp.InvoiceFlag =1;
                arApInvoiceTemp.ArApDelegateID = int.Parse(Session["SecUserID"].ToString());
                arApInvoiceTemp.DefBranchID = 1;
                arApInvoiceTemp.DueDate = DateTime.Now.Date;
                arApInvoiceTemp.ArApInvoiceTypeID = 2;

//arApInvoiceTemp.PaymentMethod =1;



                Session["PaymentMethod"] = arApInvoiceTemp.PaymentMethod;
                Session["ArApCustomerSupplierID"] = arApInvoiceTemp.ArApCustomerSupplierID;
                Session["InvStoreID"] = arApInvoiceTemp.InvStoreID;
                Session["Note"] = arApInvoiceTemp.Note;
                // Session["max_ArApInvoiceID"] = ArApInvoiceID;
                //Session["InvoiceCode"] = arApInvoiceTemp.InvoiceCode;
                

               // db.ArApInvoiceTemps.Add(arApInvoiceTemp);
               // db.SaveChanges();
                return RedirectToAction("LoadItems", "InvGroups", Session["InvoiceCode"]);
            }

            ViewBag.ArApCustomerSupplierID = new SelectList(db.Customer, "ArApCustomerSupplierID", "CustomerSupplierName", arApInvoiceTemp.ArApCustomerSupplierID);
            ViewBag.DefBranchID = new SelectList(db.Branches, "DefBranchID", "BranchName", arApInvoiceTemp.DefBranchID);
            ViewBag.DefCurrencyID = new SelectList(db.DefCurrencies, "DefCurrencyID", "CurrencyName", arApInvoiceTemp.DefCurrencyID);
            ViewBag.InvStoreID = new SelectList(db.InvStores, "InvStoreID", "StoreName", arApInvoiceTemp.InvStoreID);
            return View(arApInvoiceTemp);
        }

        // GET: ArApInvoiceTemps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArApInvoiceTemp arApInvoiceTemp = db.ArApInvoiceTemps.Find(id);
            if (arApInvoiceTemp == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArApCustomerSupplierID = new SelectList(db.Customer, "ArApCustomerSupplierID", "CustomerSupplierCode", arApInvoiceTemp.ArApCustomerSupplierID);
            ViewBag.DefBranchID = new SelectList(db.Branches, "DefBranchID", "BranchName", arApInvoiceTemp.DefBranchID);
            ViewBag.DefCurrencyID = new SelectList(db.DefCurrencies, "DefCurrencyID", "CurrencyName", arApInvoiceTemp.DefCurrencyID);
            ViewBag.InvStoreID = new SelectList(db.InvStores, "InvStoreID", "StoreName", arApInvoiceTemp.InvStoreID);
            return View(arApInvoiceTemp);
        }

        // POST: ArApInvoiceTemps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArApInvoiceID,InvoiceCode,DefBranchID,InvoiceDate,DueDate,TransactionType,ArApReturnInvoiceID,InvStoreID,PaymentMethod,ArApCustomerSupplierID,ArApInvoiceTypeID,ArApSupplyOrderID,DefCurrencyID,ExchangeRate,ArApDelegateIDMarketing,ArApDelegateID,ArApDelegateIDCollection,Note,InvoiceFlag,Netprice,CreditPeriod,ApPurchasingOrderID,ApPurchasingRequestID,ApPriceOfferID,TotalDiscountPercentage,TotalDiscountValue,TotalEffectsValue,TotalPrice,ArApDiscountID,IsTotalsClaimCalculated,TotalSupplierEffectsValue,GlJournalID,JournalSerial,ArPurposeOfIssueID,ArSalesOrderID,ArPriceOfferID,IsIssueTransactions,recipient,InvoiceID,RecordOwnerID,RowVersionNumber,Amountpaid,RemainingAmount,ArWindowShowTypeID")] ArApInvoiceTemp arApInvoiceTemp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(arApInvoiceTemp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArApCustomerSupplierID = new SelectList(db.Customer, "ArApCustomerSupplierID", "CustomerSupplierCode", arApInvoiceTemp.ArApCustomerSupplierID);
            ViewBag.DefBranchID = new SelectList(db.Branches, "DefBranchID", "BranchName", arApInvoiceTemp.DefBranchID);
            ViewBag.DefCurrencyID = new SelectList(db.DefCurrencies, "DefCurrencyID", "CurrencyName", arApInvoiceTemp.DefCurrencyID);
            ViewBag.InvStoreID = new SelectList(db.InvStores, "InvStoreID", "StoreName", arApInvoiceTemp.InvStoreID);
            return View(arApInvoiceTemp);
        }

        // GET: ArApInvoiceTemps/Delete/5

        //    public  RepData()
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
        //    var invoiceQuery = (from inv in db.ArApInvoiceTemps
        //                            // join invitem in ArApInvoiceItemTemp on inv.ArApInvoiceID equals invitem.ArApInvoiceID
        //                        join delc in db.Delegates on inv.ArApDelegateID equals delc.ArApDelegateID
        //                        // join bran in Branch on inv.DefBranchID equals bran.DefBranchID
        //                        //  join str in invItemStore on invitem.InvItemStoreID equals str.InvItemStoreID
        //                        //  join item in items on str.InvItemID equals item.InvItemID
        //                        join cust in db.Customer on inv.ArApCustomerSupplierID equals cust.ArApCustomerSupplierID
        //                        where (inv.ArApInvoiceID == id) && (inv.ArApDelegateID == SecUserID)
        //                        select new
        //                        {
        //                            ArApInvoiceID = inv.ArApInvoiceID,
        //                            InvoiceCode = inv.InvoiceCode,
        //                            InvoiceDate = inv.InvoiceDate,
        //                            NetpriceInv = inv.Netprice,
        //                            ArApDelegateID = inv.ArApDelegateID,
        //                            DelegateName = delc.DelegateName,
        //                            CustomerSupplierName = cust.CustomerSupplierName,
        //                            CustomerSupplierCode = cust.CustomerSupplierCode,
        //                        }
        //                 ).ToList();

        //    var invoice = new List<RepInvoiceViewModel>();

        //    if (invoiceQuery.Count > default(int))
        //    {
        //        invoice = (from Invoice in invoiceQuery
        //                   select new RepInvoiceViewModel
        //                   {
        //                       InvoiceID = Invoice.ArApInvoiceID,
        //                       InvoiceCode = Invoice.InvoiceCode,
        //                       InvoiceDate = Invoice.InvoiceDate,
        //                       //  NetpriceInv = (NetpriceInv == null) ? default(decimal) : Invoice.NetpriceInv,
        //                       ArApDelegateID = Invoice.ArApDelegateID,
        //                       DelegateName = Invoice.DelegateName,
        //                       CustomerSupplierName = Invoice.CustomerSupplierName,
        //                       CustomerSupplierCode = Invoice.CustomerSupplierCode,
        //                   }
        //                   ).ToList();
        //        foreach (var q in invoice)
        //        {
        //            q.InvoiceDetails = new List<ArInvoiceDetailsReportModel>();
        //            var invoiceDetails = from inv in invoice
        //                                 join invoiceItem in db.ArApInvoiceItemTemps on inv.InvoiceID equals invoiceItem.ArApInvoiceID into invoiceItemGroups

        //                                 from invoiceItemGroup in invoiceItemGroups.DefaultIfEmpty()
        //                                     //join invoiceItemDetails in context.ArApInvoiceItemDetails on invoiceItemGroup.ArApInvoiceItemID equals invoiceItemDetails.ArApInvoiceItemID into invoiceItemDetailsGroups
        //                                     //from invoiceItemDetailsGroup in invoiceItemDetailsGroups.DefaultIfEmpty()
        //                                 join itemStore in db.InvItemStores on invoiceItemGroup.InvItemStoreID equals itemStore.InvItemStoreID into itemStoreGroups
        //                                 from itemStoreGroup in itemStoreGroups.DefaultIfEmpty()

        //                                 join item in db.InvItems on itemStoreGroup.InvItemID equals item.InvItemID into itemGroups
        //                                 from itemGroup in itemGroups.DefaultIfEmpty()
        //                                     // join 
        //                                     //join supplier in context.InvItemSuppliers on itemGroup.InvItemID equals supplier.InvItemID into supplierGroups
        //                                     //from supplierGroup in supplierGroups.DefaultIfEmpty()
        //                                     // join invoiceItemEffects in context.ArApInvoiceItemEffects on invoiceItem.ArApInvoiceItemID equals invoiceItemEffects.ArApInvoiceItemID
        //                                 where inv.InvoiceID == q.InvoiceID

        //                                 //let salesTax = invoiceItemGroup == null ? default(decimal) :
        //                                 //                (from effect in context.InvEffects
        //                                 //                 join invoiceItemEffects in context.ArApInvoiceItemEffects on effect.InvEffectID equals invoiceItemEffects.InvEffectID
        //                                 //                 where invoiceItemEffects.ArApInvoiceItemID == invoiceItemGroup.ArApInvoiceItemID && effect.IsTax == (int)BaseEnum.SalesTax.SalesTax
        //                                 //                 select invoiceItemEffects.CalculatedEffectValue).FirstOrDefault()
        //                                 //let ExpiryDate = invoiceItemDetailsGroup == null ? string.Empty : customFormat.FormatValue(invoiceItemDetailsGroup.ExpiryDate) // تاريخ الصلاحية
        //                                 //let BatchNo = invoiceItemDetailsGroup == null ? string.Empty : invoiceItemDetailsGroup.BatchID  // رقم الباتش
        //                                 //let OriginSupplierName = supplierGroup == null ? string.Empty : supplierGroup.OriginSupplierName  // الشركة المصنعة

        //                                 select new ArInvoiceDetailsReportModel
        //                                 {
        //                                     InvoiceID = invoiceItemGroup.ArApInvoiceID,
        //                                     InvoiceCode = inv.InvoiceCode,
        //                                     InvoiceDate = inv.InvoiceDate,
        //                                     NetpriceInv = inv.NetpriceInv,
        //                                     ArApDelegateID = inv.ArApDelegateID,
        //                                     DelegateName = inv.DelegateName,
        //                                     CustomerSupplierName = inv.CustomerSupplierName,
        //                                     CustomerSupplierCode = inv.CustomerSupplierCode,
        //                                     ItemCode = itemGroup.ItemCode,
        //                                     ItemName = itemGroup.ItemName,                     // اسم الصنف 
        //                                     Quantity = invoiceItemGroup.Quantity,//invoiceItemDetailsGroup == null ? default(decimal) : invoiceItemDetailsGroup.Quantity, // الكمية
        //                                     SellingPrice = invoiceItemGroup == null ? default(decimal) : invoiceItemGroup.SellingPrice,  // سعر الجمهور
        //                                     Netprice = invoiceItemGroup.NetPrice,

        //                                 };

        //            q.InvoiceDetails.AddRange(invoiceDetails);
        //        }
        //        return invoice.ToList();
        //    }

        //}
        
        public ActionResult Save()
        {
            int id = int.Parse(Session["ArApInvoiceID"].ToString());//23; //
            int SecUserID = int.Parse(Session["SecUserID"].ToString());// = 1;
                                                                       // int ArApInvoiceID = id;
            if (id == null)
            {
                return RedirectToAction("Cat", "Home");
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


            var invtemp = new ArApInvoiceTemp();
            var invitemt = new ArApInvoiceItemTemp();
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

            //var integers = invitemt.ArApInvoiceTemp.Select(s => s.ArApInvoiceID).ToList();
            var iteminv = (from itemt in db.ArApInvoiceItemTemps
                           join str in db.InvItemStores on itemt.InvItemStoreID equals str.InvItemStoreID
                           join item in db.InvItems on str.InvItemID equals item.InvItemID
                           where (itemt.ArApInvoiceID == id)
                           select  new RInvoiceViewModel
                           {
                                 ItemCode = item.ItemCode,
                                 ItemName = item.ItemName,
                               InvoiceID= itemt.ArApInvoiceID,
                               Quantity = itemt.Quantity,//invoiceItemDetailsGroup == null ? default(decimal) : invoiceItemDetailsGroup.Quantity, // الكمية
                               SellingPrice = itemt.SellingPrice,  // سعر الجمهور
                               Netprice = itemt.NetPrice

                           }
                           ).ToList();


            var invoice = (from inv in db.ArApInvoiceTemps
                           join delc in db.Delegates.DefaultIfEmpty() on inv.ArApDelegateID equals delc.ArApDelegateID
                           join cust in db.Customer.DefaultIfEmpty() on inv.ArApCustomerSupplierID equals cust.ArApCustomerSupplierID
                         //  join invitem in db.ArApInvoiceItemTemps on inv.ArApInvoiceID equals invitem.ArApInvoiceID
                                
                                // join bran in Branch on inv.DefBranchID equals bran.DefBranchID
                                // join str in db.InvItemStores on invitem.InvItemStoreID equals str.InvItemStoreID
                              //   join item in items.DefaultIfEmpty() on str.InvItemID equals item.InvItemID
                                
                                where (inv.ArApInvoiceID == id) && (inv.ArApDelegateID == SecUserID)
                                select new RInvoiceViewModel
                                {
                                    InvoiceID = inv.ArApInvoiceID,
                                    InvoiceCode = inv.InvoiceCode,
                                    InvoiceDate = inv.InvoiceDate,
                                    //NetpriceInv = inv.Netprice,
                                    ArApDelegateID = inv.ArApDelegateID,
                                    ArApCustomerSupplierID = cust.ArApCustomerSupplierID,
                                    DelegateName = delc.DelegateName,
                                    CustomerSupplierName = cust.CustomerSupplierName,
                                    CustomerSupplierCode = cust.CustomerSupplierCode,
                                 //  ItemCode = item.ItemCode,
                                  //  ItemName = item.ItemName,                     // اسم الصنف 
                                    //Quantity = invitem.Quantity,//invoiceItemDetailsGroup == null ? default(decimal) : invoiceItemDetailsGroup.Quantity, // الكمية
                                    //SellingPrice = invitem.SellingPrice,  // سعر الجمهور
                                    //Netprice = invitem.NetPrice
                                }
                         ).Distinct().ToList();




            var result = (from tempinv in invoice
                          join tempitem in iteminv on tempinv.InvoiceID equals tempitem.InvoiceID
                          where (tempinv.InvoiceID == id)&& (tempitem.InvoiceID == id) &&(tempitem.InvoiceID== tempinv.InvoiceID)
                          
                          select new RInvoiceViewModel
                          { 
                              InvoiceID = tempinv.InvoiceID,
                              InvoiceCode = tempinv.InvoiceCode,
                              InvoiceDate = tempinv.InvoiceDate,
                              //   NetpriceInv = inv.Netprice,
                              ArApDelegateID = tempinv.ArApDelegateID,
                              DelegateName = tempinv.DelegateName,
                              CustomerSupplierName = tempinv.CustomerSupplierName,
                                 CustomerSupplierCode = tempinv.CustomerSupplierCode,
                                ItemCode = tempitem.ItemCode,
                                ItemName = tempitem.ItemName,                     // اسم الصنف 
                              Quantity = tempitem.Quantity,//invoiceItemDetailsGroup == null ? default(decimal) : invoiceItemDetailsGroup.Quantity, // الكمية
                              SellingPrice = tempitem.SellingPrice,  // سعر الجمهور
                              Netprice = tempitem.Netprice
                          }
                          ).Distinct().ToList();

            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("~/Reports/InvoiceR.rpt"));
             rd.SetDataSource(result.ToList());


          


            ViewBag.Msgg = 1;
            
            ModelState.Clear();
            


            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            return File(stream, "application/pdf", "Invoice.pdf");


            return RedirectToAction("Cat", "Home");
        
        
        
        }
        
     
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArApInvoiceTemp arApInvoiceTemp = db.ArApInvoiceTemps.Find(id);
            db.ArApInvoiceTemps.Remove(arApInvoiceTemp);
            db.ArApInvoiceItemTemps.RemoveRange(db.ArApInvoiceItemTemps.Where(c => c.ArApInvoiceID == id));
            db.SaveChanges();
            TempData["message"] = "تم الحذف بنجاح";
            return RedirectToAction("Cat", "Home");
        }

        // POST: ArApInvoiceTemps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArApInvoiceTemp arApInvoiceTemp = db.ArApInvoiceTemps.Find(id);
            db.ArApInvoiceTemps.Remove(arApInvoiceTemp);
            db.SaveChanges();
            return RedirectToAction("Cat","Home");
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
