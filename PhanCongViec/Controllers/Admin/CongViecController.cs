using PhanCongViec.Daos;
using PhanCongViec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhanCongViec.Controllers.Admin
{
    public class CongViecController : Controller
    {
        CongViecDao congViecDao = new CongViecDao();
        public ActionResult Index(string msg)
        {
            ViewBag.Msg = msg;
            ViewBag.List = congViecDao.getAll();
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(CongViec congViec)
        {
            congViecDao.Add(congViec);
            return RedirectToAction("Index", new { msg = "1" });
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(CongViec congViec)
        {
            congViecDao.Update(congViec);
            return RedirectToAction("Index", new { msg = "1" });
        }

        public ActionResult Delete(CongViec congViec)
        {
            var check = congViecDao.getPhanCongByCV(congViec.idCongViec);
            if (check.Count == 0)
            {
                congViecDao.Delete(congViec.idCongViec);
                return RedirectToAction("Index", new { msg = "1" });
            }
            else
            {
                return RedirectToAction("Index", new { msg = "2" });
            }
        }
    }
}