using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyVienPhi.Models
{
    public class Physician
    {
        public string _sMaBS { get; set; }
        public string _sHoTen { get; set; }
        public DateTime _dNgaySinh { get; set; }
        public string _sDiaChi { get; set; }
        public string _sGioiTinh { get; set; }
        public string _sSDT { get; set; }
        public string _sEmail { get; set; }
        public int _nPhongKham { get; set; }
        public string _sKhoa { get; set; }
    }
}
