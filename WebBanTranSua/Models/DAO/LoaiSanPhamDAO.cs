﻿using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanTranSua.Models.EF;

namespace WebBanTranSua.Models.DAO
{
    public class LoaiSanPhamDAO
    {
        WTSDBContext db = null;

        public LoaiSanPhamDAO()
        {
            db = new WTSDBContext();
        }

        public List<LoaiSanPham> ListTypeProducts()
        {
            return db.LoaiSanPhams.ToList();
        }

        public IEnumerable<LoaiSanPham> ListAllPaging(string searchTypeProducts, int page, int pageSize)
        {
            IQueryable<LoaiSanPham> model = db.LoaiSanPhams;

            if (!string.IsNullOrEmpty(searchTypeProducts))
            {
                model = model.Where(x => x.tenLoaiSanPham.Contains(searchTypeProducts));
            }

            return model.OrderByDescending(x => x.ngayTao).ToPagedList(page, pageSize);
        }

        public long insert(LoaiSanPham enity)
        {
            db.LoaiSanPhams.Add(enity);
            db.SaveChanges();
            return enity.maLoaiSanPham;
        }

        public bool edit(LoaiSanPham loaiSanPham)
        {
            try
            {
                var loaiSanPhamEdit = db.LoaiSanPhams.Find(loaiSanPham.maLoaiSanPham);

                loaiSanPhamEdit.maLoaiSanPham = loaiSanPham.maLoaiSanPham;
                loaiSanPhamEdit.tenLoaiSanPham = loaiSanPham.tenLoaiSanPham;
                loaiSanPhamEdit.ngayCapNhat = DateTime.Now;

                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public LoaiSanPham GetByID(long id)
        {
            return db.LoaiSanPhams.Find(id);
        }


        public bool Delete(long id)
        {
            try
            {
                var loaiSanPhamDelete = db.LoaiSanPhams.Find(id);
                db.LoaiSanPhams.Remove(loaiSanPhamDelete);
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