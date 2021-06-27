using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanTranSua.Models.EF;

namespace WebBanTranSua.Models.DAO
{
    public class SanPhamDAO
    {
        WTSDBContext db = null;

        public SanPhamDAO()
        {
            db = new WTSDBContext();
        }

        public IEnumerable<SanPham> ListAllPaging(string searchProducts, int page, int pageSize)
        {
            IQueryable<SanPham> model = db.SanPhams;

            if (!string.IsNullOrEmpty(searchProducts))
            {
                model = model.Where(x => x.tenSanPham.Contains(searchProducts));
            }

            return model.OrderByDescending(x => x.ngayTao).ToPagedList(page, pageSize);
        }

        public long insert(SanPham enity)
        {
            db.SanPhams.Add(enity);
            db.SaveChanges();
            return enity.maSanPham;
        }

        public bool edit(SanPham sanPham)
        {
            try
            {
                var sanPhamEdit = db.SanPhams.Find(sanPham.maSanPham);

                sanPhamEdit.LoaiSanPham = sanPham.LoaiSanPham;
                sanPhamEdit.tenSanPham = sanPham.tenSanPham;
                sanPhamEdit.hinhAnh = sanPham.hinhAnh;
                sanPhamEdit.giaBan = sanPham.giaBan;
                sanPhamEdit.dvt = sanPham.dvt;
                sanPhamEdit.giamGia = sanPham.giamGia;
                sanPhamEdit.gioiThieuSanPham = sanPham.gioiThieuSanPham;
                sanPhamEdit.sanPhamMoi = sanPham.sanPhamMoi;
                sanPhamEdit.sanPhamNoiBat = sanPham.sanPhamNoiBat;
                sanPhamEdit.ngayCapNhat = DateTime.Now;

                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public SanPham GetByID(long id)
        {
            return db.SanPhams.Find(id);
        }


        public bool Delete(long id)
        {
            try
            {
                var sanPham = db.SanPhams.Find(id);
                db.SanPhams.Remove(sanPham);
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