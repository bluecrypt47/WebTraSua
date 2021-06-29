using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanTranSua.Models.DAO;
using WebBanTranSua.Models.EF;

namespace WebBanTranSua.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Product
        public ActionResult ListProucts(string searchProducts, int page = 1, int pageSize = 10)
        {
            var dao = new SanPhamDAO();
            var model = dao.ListAllPaging(searchProducts, page, pageSize);
            ViewBag.searchProducts = searchProducts;
            return View(model);
        }

        public void SetViewBag(long? selectedId = null)
        {
            var dao = new LoaiSanPhamDAO();
            ViewBag.MaLoaiSanPham = new SelectList(dao.ListTypeProducts(), "maLoaiSanPham", "tenLoaiSanPham", selectedId);
        }

        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        [HttpPost]
        public ActionResult Create(SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                var dao = new SanPhamDAO();

                long id = dao.insert(sanPham);
                if (id > 0)
                {
                    return RedirectToAction("ListProucts", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm sản phẩm thành công!!");
                }
            }
            return View("ListProucts");
        }

        public ActionResult Edit(long id)
        {
            var sanPham = new SanPhamDAO().GetByID(id);
            SetViewBag();
            return View(sanPham);
        }

        [HttpPost]
        public ActionResult Edit(SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                var dao = new SanPhamDAO();

                //if(!string.IsNullOrEmpty(user.matKhau))
                //{
                //    var encryptPass = Encrypt.MD5Hash(user.matKhau);
                //    user.matKhau = encryptPass;
                //}

                var result = dao.edit(sanPham);

                if (result)
                {
                    return RedirectToAction("ListProucts", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật sản phẩm thành công!!");
                }
            }
            return View("ListProucts");
        }

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            new SanPhamDAO().Delete(id);

            return RedirectToAction("ListProucts", "Product");
        }
    }
}