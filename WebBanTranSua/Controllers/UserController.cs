using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanTranSua.Common;
using WebBanTranSua.Models.DAO;
using WebBanTranSua.Models.EF;

namespace WebBanTranSua.Controllers
{
    public class UserController : BaseController
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TaiKhoan user)
        {
            if(ModelState.IsValid)
            {
                var dao = new TaiKhoanDAO();

                var encryptPass = Encrypt.MD5Hash(user.matKhau);
                user.matKhau = encryptPass;

                long id = dao.insert(user);
                if(id> 0)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm tài khoản thành công!!");
                }
            }
            return View("Index");
        }
    }
}