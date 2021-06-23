using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanTranSua.Code
{
    public class SessionHelper
    {
        public static void setSession(TaiKhoanSession session)
        {
            HttpContext.Current.Session["loginSession"] = session;
        }

        public static TaiKhoanSession getSession()
        {
            var session = HttpContext.Current.Session["loginSession"];
            if(session == null)
            {
                return null;
            }
            else
            {
                return session as TaiKhoanSession;
            }
        }
    }
}