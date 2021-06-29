﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanTranSua.Models.DAO;
using WebBanTranSua.Models.EF;

namespace WebBanTranSua.Controllers
{
    public class LoaiSanPhamController : BaseController
    {
        // GET: LoaiSanPham
        public ActionResult ListTypeProucts(string searchTypeProducts, int page = 1, int pageSize = 10)
        {
            var dao = new LoaiSanPhamDAO();
            var model = dao.ListAllPaging(searchTypeProducts, page, pageSize);
            ViewBag.searchProducts = searchTypeProducts;
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(LoaiSanPham loaiSanPham)
        {
            if (ModelState.IsValid)
            {
                var dao = new LoaiSanPhamDAO();

                long id = dao.insert(loaiSanPham);
                if (id > 0)
                {
                    return RedirectToAction("ListTypeProucts", "LoaiSanPham");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm loại sản phẩm thành công!!");
                }
            }
            return View("ListTypeProucts");
        }

        public ActionResult Edit(long id)
        {
            var loaiSanPham = new LoaiSanPhamDAO().GetByID(id);
            return View(loaiSanPham);
        }

        [HttpPost]
        public ActionResult Edit(LoaiSanPham loaiSanPham)
        {
            if (ModelState.IsValid)
            {
                var dao = new LoaiSanPhamDAO();

                var result = dao.edit(loaiSanPham);

                if (result)
                {
                    return RedirectToAction("ListTypeProucts", "LoaiSanPham");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật loại sản phẩm thành công!!");
                }
            }
            return View("ListTypeProucts");
        }

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            new LoaiSanPhamDAO().Delete(id);

            return RedirectToAction("ListTypeProucts", "LoaiSanPham");
        }
    }
}