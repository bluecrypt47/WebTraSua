﻿using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanTranSua.Models.EF;

namespace WebBanTranSua.Models.DAO
{
    public class HoaDonDAO
    {
        WTSDBContext db = null;

        public HoaDonDAO()
        {
            db = new WTSDBContext();
        }

        // Lấy danh sách
        public List<HoaDon> ListTypeProducts()
        {
            return db.HoaDons.ToList();
        }

        // Hiện danh sách có phân trang
        public IEnumerable<HoaDon> ListAllPaging(string searchBill, int page, int pageSize)
        {
            IQueryable<HoaDon> model = db.HoaDons;

            if (!string.IsNullOrEmpty(searchBill))
            {
                model = model.Where(x => x.tenNguoiMua.Contains(searchBill) || x.sdt.Contains(searchBill));
            }

            return model.OrderByDescending(x => x.ngayMua).ToPagedList(page, pageSize);
        }

        // Tìm ID
        public HoaDon GetByID(long id)
        {
            return db.HoaDons.Find(id);
        }

        // Xóa
        public bool Delete(long id)
        {
            try
            {
                var hoaDonDelete = db.HoaDons.Find(id);
                db.HoaDons.Remove(hoaDonDelete);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}