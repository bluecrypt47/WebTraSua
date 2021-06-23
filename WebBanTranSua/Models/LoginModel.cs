using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBanTranSua.Models
{
    public class LoginModel
    {
        [Required]
        private string email;
        private string matKhau;

        public string Email { get => email; set => email = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
    }
}