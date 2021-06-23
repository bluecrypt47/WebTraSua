using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebBanTranSua.Code;
using WebBanTranSua.Models;
using WebBanTranSua.Models.DAO;
using WebBanTranSua.Models.EF;

namespace WebBanTranSua.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel login)
        {
            var result = new TaiKhoanDAO().login(login.Email, login.MatKhau);
            if(result && ModelState.IsValid)
            {
                SessionHelper.setSession(new TaiKhoanSession() { email = login.Email });
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng!!!");
            }
            return View(login);
        }

        public ActionResult logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}