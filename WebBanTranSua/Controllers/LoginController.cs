﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebBanTranSua.Code;
using WebBanTranSua.Common;
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
            if(ModelState.IsValid)
            {
                var dao = new TaiKhoanDAO();
                var result = dao.login(login.Email, Encrypt.MD5Hash(login.MatKhau));
                if (result && ModelState.IsValid)
                {
                    //SessionHelper.setSession(new TaiKhoanSession() { email = login.Email });
                    var user = dao.getByEmail(login.Email);
                    var userSession = new UserLogin();
                    userSession.Email = user.email;
                    Session.Add(CommenConstants.USER_SESSION, userSession);

                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng!!!");
                }
                //return View(login);
            }
            
            return View("Index");
        }

        public ActionResult logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}