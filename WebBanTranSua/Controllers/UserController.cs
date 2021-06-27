using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanTranSua.Common;
using WebBanTranSua.Models.DAO;
using WebBanTranSua.Models.EF;
using PagedList;

namespace WebBanTranSua.Controllers
{
    public class UserController : BaseController
    {
        // GET: User
        public ActionResult ListUser(string searchUser, int page = 1, int pageSize = 10)
        {
            var dao = new TaiKhoanDAO();
            var model = dao.ListAllPaging(searchUser, page, pageSize);
            ViewBag.searchUser = searchUser;
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TaiKhoan user)
        {
            if (ModelState.IsValid)
            {
                var dao = new TaiKhoanDAO();

                var encryptPass = Encrypt.MD5Hash(user.matKhau);
                user.matKhau = encryptPass;

                long id = dao.insert(user);
                if (id > 0)
                {
                    return RedirectToAction("ListUser", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm tài khoản thành công!!");
                }
            }
            return View("ListUser");
        }

        public ActionResult Edit(long id)
        {
            var user = new TaiKhoanDAO().GetByID(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(TaiKhoan user)
        {
            if (ModelState.IsValid)
            {
                var dao = new TaiKhoanDAO();

                //if(!string.IsNullOrEmpty(user.matKhau))
                //{
                //    var encryptPass = Encrypt.MD5Hash(user.matKhau);
                //    user.matKhau = encryptPass;
                //}

                var result = dao.edit(user);

                if (result)
                {
                    return RedirectToAction("ListUser", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật tài khoản thành công!!");
                }
            }
            return View("ListUser");
        }

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            new TaiKhoanDAO().Delete(id);

            return RedirectToAction("ListUser", "User");
        }
    }
}