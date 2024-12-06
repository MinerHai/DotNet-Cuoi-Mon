using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLVanChuyen_App.models
{
    internal class KhachHang
    {
        public KhachHang(int id, string? tenKhachHang, string? sdt, string? diachi)
        {
            Id = id;
            this.tenKhachHang = tenKhachHang;
            this.sdt = sdt;
            this.diachi = diachi;
        }

        public int Id { set; get; }
        public string? tenKhachHang { set; get; }
        public string? sdt { set; get; }
        public string? diachi { set; get; }
    }
}
