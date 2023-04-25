using PhanCongViec.Daos;
using PhanCongViec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhanCongViec.Controllers.Admin
{
    public class NguoiDungController : Controller
    {
        NguoiDungDao nguoidungDao = new NguoiDungDao();
        public ActionResult Index(string msg)
        {
            ViewBag.Msg = msg;
            ViewBag.List = nguoidungDao.getUser();
            return View();
        }

        public ActionResult CongViecPC()
        {
            var userInfomatiom = (NguoiDung)Session["ADMIN"];
            ViewBag.List = nguoidungDao.getPhanCongByND(userInfomatiom.idNguoiDung);
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(NguoiDung nguoiDung)
        {
            var check = nguoidungDao.checkExistEmail(nguoiDung.taiKhoan);
            if(!check)
            {
                nguoidungDao.Add(nguoiDung);
                return RedirectToAction("Index", new { msg = "1" });
            }
            return RedirectToAction("Index", new { msg = "2" });
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(NguoiDung nguoiDung)
        {
            nguoidungDao.Update(nguoiDung);
            return RedirectToAction("Index", new { msg = "1" });
        }

        public ActionResult Delete(NguoiDung nguoiDung)
        {
            var check = nguoidungDao.getPhanCongByND(nguoiDung.idNguoiDung);
            if (check.Count == 0)
            {
                nguoidungDao.Delete(nguoiDung.idNguoiDung);
                return RedirectToAction("Index", new { msg = "1" });
            }
            else
            {
                return RedirectToAction("Index", new { msg = "2" });
            }
        }
    }
}