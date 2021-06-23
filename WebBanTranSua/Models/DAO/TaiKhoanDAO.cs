﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebBanTranSua.Models.EF;

namespace WebBanTranSua.Models.DAO
{
    public class TaiKhoanDAO
    {
        WTSDBContext db = null;
        public TaiKhoanDAO()
        {
            db = new WTSDBContext();
        }

        public string insert(TaiKhoan enity)
        {
            db.TaiKhoans.Add(enity);
            db.SaveChanges();
            return enity.email;
        }

        public bool login(string email, string password)
        {
            object[] sqlParam =
            {
                new SqlParameter("@email", email),
                new SqlParameter("@matkhau", password)
            };

            var result = db.Database.SqlQuery<bool>("login @email, @matkhau", sqlParam).SingleOrDefault();

            return result;
        }
    }
}