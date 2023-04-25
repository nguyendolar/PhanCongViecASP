using PhanCongViec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YTeAspMVC.Controllers.Admin
{
    public class AdminHomeController : Controller
    {
        // GET: AdminHome
        public ActionResult Index()
        {
            NguoiDung user = (NguoiDung)Session["ADMIN"];
            if (user == null)
            {
                return RedirectToAction("Login", "AdminAuthentication");
            }
            else
            {
                return View();
            }
        }


    }
}