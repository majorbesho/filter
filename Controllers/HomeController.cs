using EdgeMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EdgeMobile.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Cat()
        {
           return View("Cat2");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(SecUser objUser)
        {
            ERPEdgeContext context = new ERPEdgeContext(); 
            //EdgeSecurityContext securityContext = new EdgeSecurityContext();
            using (EdgeSecurityContext db = new EdgeSecurityContext())

            {
                var obj = db.SecUsers.Where(a => (a.UserName == objUser.UserName) && (a.Password == objUser.Password)).FirstOrDefault();
                //return RedirectToAction("Cat", "Home");
                
                #region
                if (obj != null)
                {
                    //               var itemG = (from i in invItems
                    //                            join s in invItemStores on i.InvItemID equals s.InvItemID
                    //                            join st in invStores on s.InvStoreID equals st.InvStoreID
                    //                            join u in invUnits on i.InvUnitID equals u.InvUnitID
                    //                            join baln in invItemBalanceEvaluates on s.InvItemStoreID equals baln.InvItemStoreID
                    //                            join grp in invGroups on i.InvGroupID equals grp.InvGroupID
                    //                            orderby grp.InvGroupID descending


                    //                            //where // ((storeID == null) || s.InvStoreID == storeID) &&
                    //                            // (/*(groupID == null) || */i.InvGroupID == ID)
                    //                            select new InvItemViewModel
                    //                            {
                    //                                InvItemID = i.InvItemID,
                    //                                ItemName = i.ItemName,
                    //                                ItemCode = i.ItemCode,
                    //                                UnitName = u.UnitName,
                    //                                InvUnitID = u.InvUnitID,
                    //                                GroupName = grp.GroupName,
                    //                                InvGroupID = grp.InvGroupID,
                    //                                InvItemStoreID = s.InvItemStoreID,
                    //                                SellingPrice = s.SellingPrice

                    //                            }

                    //);

                    //string ResponsibleID = obj.ResponsibleID.ToString();
                    //var empData = (from emp in context.DefEmployees
                    //          //     join wp in context.PslWorkPlaces on emp.PslWorkPlaceID equals wp.PslWorkPlaceID
                    //           //    join bran in context.Branches on emp.DefBranchID equals bran.DefBranchID
                    //               where (emp.EmployeeCode == obj.ResponsibleID)
                    //               select new { emp.DefEmployeeID, emp.EmployeeName, /*bran.BranchName,*/ emp.EmployeeCode/*, wp.WorkPlaceName, wp.PslWorkPlaceID*/ }).FirstOrDefault();
                    //if (empData != null)
                    //{
                        Session["SecUserID"] =obj.SecUserID;
                        //Session["EmployeeCode"] = empData.EmployeeCode.ToString();
                        Session["UserName"] = obj.UserName.ToString();
                        //Session["WorkPlaceName"] = empData.WorkPlaceName;
                        //Session["PslWorkPlaceID"] = empData.PslWorkPlaceID.ToString();
                    //}
                    //else
                    //{
                    //    return View("Index");
                    //}
                    // Session["City"] = obj.br
                    return RedirectToAction("Cat", "Home");
                }
                else
                {
                    //ModelState.AddModelError("", "The Email or password provided is incorrect.");
                    ViewBag.msg = 1;

                }
                #endregion
            }
            //}
            //for data securty
            return View("Index", objUser);
        }
    }
}