using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLVanChuyen_App.models
{
    internal class PhuongTien
    {
        public PhuongTien(int iD, string? bienSo, string? taiXe, string? loaiXe)
        {
            ID = iD;
            BienSo = bienSo;
            TaiXe = taiXe;
            LoaiXe = loaiXe;
        }

        public int ID { set; get; } 
        public string? BienSo {  set; get; }
        public string? TaiXe {  set; get; }
        public string? LoaiXe {  set; get; }
    }
}
