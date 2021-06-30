using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanTranSua.Models.EF;

namespace WebBanTranSua.Models.DAO
{
    public class MenuDAO
    {
        WTSDBContext db = null;

        public MenuDAO()
        {
            db = new WTSDBContext();
        }

        // Trả về listmenu
        public List<Menu> listMenus()
        {
            return db.Menus.OrderBy(x => x.maMenu).ToList();
        }
    }
}