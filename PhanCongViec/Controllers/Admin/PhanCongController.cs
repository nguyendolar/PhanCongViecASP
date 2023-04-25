using PhanCongViec.Daos;
using PhanCongViec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhanCongViec.Controllers.Admin
{
    public class PhanCongController : Controller
    {
        PhanCongDao phanCongDao = new PhanCongDao();
        public ActionResult Index(string msg)
        {
            ViewBag.Msg = msg;
            ViewBag.List = phanCongDao.getAll();
            return View();
        }
    }
}