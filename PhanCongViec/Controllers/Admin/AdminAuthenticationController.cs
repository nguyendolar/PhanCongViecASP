using PhanCongViec.Daos;
using PhanCongViec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhanCongViec.Controllers.Admin
{
    public class AdminAuthenticationController : Controller
    {
        NguoiDungDao nguoiDungDao = new NguoiDungDao();

        // GET: AdminAuthentication
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            NguoiDung user = new NguoiDung()
            {
                taiKhoan = form["taikhoan"],
                matKhau = form["password"]
            };
            bool checkLogin = nguoiDungDao.checkLogin(user.taiKhoan, user.matKhau);
            if (checkLogin)
            {
                var userInformation = nguoiDungDao.getUserByEmail(user.taiKhoan);
                Session.Add("ADMIN", userInformation);
                if(userInformation.idQuyen == 1)
                {
                    return RedirectToAction("Index", "NguoiDung");
                }
                return RedirectToAction("CongViecPC", "NguoiDung");

            }
            else
            {
                ViewBag.mess = "Thông tin tài khoản hoặc mật khẩu không chính xác";
                return View("Login");
            }

        }

        public ActionResult Logout()
        {
            Session.Remove("ADMIN");
            return Redirect("/AdminHome/Index");
        }
    }
}