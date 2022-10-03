using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyVienPhi.Models
{
    public class Receipts:Patients
    {
        public int _nSoBienLai { get; set; }
        public DateTime _dNgayThanhToan { get; set; }
        public double _fTongTien { get; set; }
        public string _sTaiKhoan { get; set; }
    }
}
