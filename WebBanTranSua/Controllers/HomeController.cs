﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanTranSua.Models.DAO;

namespace WebBanTranSua.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Categorys = new LoaiSanPhamDAO().ListTypeProducts();
            ViewBag.Slides = new SlideDAO().ListSlides();
            ViewBag.SlidesNewProducts = new SanPhamDAO().SlideListSanPhamMoi();
            ViewBag.HighlightProducts = new SanPhamDAO().ListSanPhamNoiBat();
            return View();
        }

        [ChildActionOnly]
        public ActionResult Menus()
        {
            var model = new MenuDAO().listMenus();
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            var model = new FooterDAO().GetFooter();
            return PartialView(model);
        }
    }
}