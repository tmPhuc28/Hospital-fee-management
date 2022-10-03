using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyVienPhi.Models
{
    public class Account
    {
        public string _sTaiKhoan { set; get; }
        public string _sMatKhau { set; get; }
        public string _sMANV { get; set; }
        public string _sMaLoai { set; get; }
    }
}
