using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanTranSua.Common
{
    [Serializable]
    public class UserLogin
    {
        private string email;

        public string Email { get => email; set => email = value; }
    }
}