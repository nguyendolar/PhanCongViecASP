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
        NguoiDungDao nguoiDungDao = new NguoiDungDao();
        CongViecDao congViecDao = new CongViecDao();
        public ActionResult Index(string msg)
        {
            ViewBag.Msg = msg;
            ViewBag.List = phanCongDao.getAll();
            ViewBag.Nguoidungs = nguoiDungDao.getNguoiDung();
            ViewBag.Congviecs = congViecDao.getAll();
            return View();
        }

        [HttpPost]
        public ActionResult Add(PhanCong phanCong)
        {
            phanCong.ngayGiao = DateTime.Now.ToString();
            phanCong.tinhTrang = "Chưa làm";
            phanCongDao.Add(phanCong);
            return RedirectToAction("Index", new { msg = "1" });
        }

        public ActionResult Delete(PhanCong phanCong)
        {
            phanCongDao.Delete(phanCong.idPhanCong);
            return RedirectToAction("Index", new { msg = "1" });
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(PhanCong phanCong)
        {
            phanCongDao.Update(phanCong);
            return RedirectToAction("Index", new { msg = "1" });
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CapNhatTienDo(PhanCong phanCong)
        {
            phanCongDao.CapNhatTienDo(phanCong);
            return RedirectToAction("CongViecPC","NguoiDung", new { msg = "1" });
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult DanhGia(PhanCong phanCong)
        {
            phanCongDao.DanhGia(phanCong);
            return RedirectToAction("Index", new { msg = "1" });
        }
    }
}