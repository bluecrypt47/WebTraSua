using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebBanTranSua.Models.EF;
using PagedList;

namespace WebBanTranSua.Models.DAO
{
    public class TaiKhoanDAO
    {
        WTSDBContext db = null;
        public TaiKhoanDAO()
        {
            db = new WTSDBContext();
        }

        public long insert(TaiKhoan enity)
        {
            db.TaiKhoans.Add(enity);
            db.SaveChanges();
            return enity.id;
        }

        public bool edit(TaiKhoan taiKhoan)
        {
            try
            {
                var user = db.TaiKhoans.Find(taiKhoan.id);

                user.email = taiKhoan.email;
                if(!string.IsNullOrEmpty(taiKhoan.matKhau))
                {
                    user.matKhau = taiKhoan.matKhau;
                }
                user.tenNguoiDung = taiKhoan.tenNguoiDung;
                user.diaChi = taiKhoan.diaChi;
                user.sdt = taiKhoan.sdt;

                db.SaveChanges();

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<TaiKhoan> ListAllPaging(int page, int pageSize)
        {
            return db.TaiKhoans.OrderByDescending(x => x.id).ToPagedList(page, pageSize);
        }

        public TaiKhoan getByEmail(string email)
        {
            return db.TaiKhoans.SingleOrDefault(x => x.email == email);
        }

        public TaiKhoan GetByID(long id)
        {
            return db.TaiKhoans.Find(id);
        }

        public bool Login(string email, string password)
        {
            object[] sqlParam =
            {
                new SqlParameter("@email", email),
                new SqlParameter("@matkhau", password)
            };

            //var result = db.Database.SqlQuery<bool>("login @email, @matkhau", sqlParam).SingleOrDefault();

            var result = db.TaiKhoans.Count(x => x.email == email && x.matKhau == password);
            if(result >0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}