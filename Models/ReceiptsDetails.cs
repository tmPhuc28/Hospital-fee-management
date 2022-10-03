using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyVienPhi.Models
{
    public class ReceiptsDetails:Receipts
    {
        public int _nKhoanCP { get; set; }
        public double _fSoTien { get; set; }
    }
}
