using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLVanChuyen_App.models
{
    internal class DonHang
    {
        public DonHang(int iD, int iD_KhachHang, DateTime ngayDatHang, string? trangthai, string? ghiChu)
        {
            ID = iD;
            ID_KhachHang = iD_KhachHang;
            NgayDatHang = ngayDatHang;
            Trangthai = trangthai;
            GhiChu = ghiChu;
        }

        public int ID { get; set; }
        public int ID_KhachHang {  get; set; }
        public DateTime NgayDatHang {  get; set; }
        public string? Trangthai {  get; set; }
        public string? GhiChu {  get; set; }
    }
}
