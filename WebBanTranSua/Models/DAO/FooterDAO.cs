using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanTranSua.Models.EF;

namespace WebBanTranSua.Models.DAO
{
    public class FooterDAO
    {
        WTSDBContext db = null;

        public FooterDAO()
        {
            db = new WTSDBContext();
        }

        public Footer GetFooter()
        {
            return db.Footers.SingleOrDefault(x => x.trangThai == true);
        }
    }
}