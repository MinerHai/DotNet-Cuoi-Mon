using QLVanChuyen_App.controllers;
using QLVanChuyen_App.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVanChuyen_App.views
{
    public partial class ChiTiet_DonHang : Form
    {
        private readonly int id;
        private readonly khachHangController kh_controller;
        private readonly donHangController dh_controller;
        private readonly PhuongTienController pt_controller;
        public ChiTiet_DonHang(int id)
        {
            InitializeComponent();
            this.id = id;
            lbTitle.Text = $"Chi tiết đơn hàng: {id}";
            kh_controller = new khachHangController();
            dh_controller = new donHangController();
            pt_controller = new PhuongTienController();
            loadData();
        }
        void loadData()
        {
            int id_dh = dh_controller.Get_MaDH_By_CTDH(id);
            int id_xe = dh_controller.Get_MaXe_By_CTDH(id);
            DonHang? dh = dh_controller.GetDH_By_ID(id_dh);
            KhachHang? kh = kh_controller.GetKH_By_ID(dh.ID_KhachHang);
            PhuongTien? pt = pt_controller.GetPT_By_ID(id_xe);

            txtBienSo.Text = pt.BienSo;
            txtTaiXe.Text = pt.TaiXe;
            txtMaPT.Text = pt.ID.ToString();
            txtLoaiPT.Text = pt.LoaiXe;

            txtMaKH.Text = kh.Id.ToString();
            txtTenKH.Text = kh.tenKhachHang;
            txtSDT.Text = kh.sdt;
            txtDiaChi.Text = kh.diachi;

            txtMaDH.Text = dh.ID.ToString();
            txtGhiChu.Text = dh.GhiChu;
            txtNgay.Text = dh.NgayDatHang.ToString();

            string? trangthai = dh.Trangthai;
            if (trangthai.Equals("Chờ xác nhận"))
                rbCXN.Checked = true;
            else if (trangthai.Equals("Đang vận chuyển"))
                rbDVC.Checked = true;
            else if (trangthai.Equals("Giao thành công"))
                rbGTC.Checked = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult confirmation = MessageBox.Show(
                   "Bạn có chắc chắn muốn xóa đơn hàng: " + id + "?",
                   "Xác nhận xóa",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question
               );

            if (confirmation == DialogResult.Yes)
            {
                if (dh_controller.RemoveDonHang(dh_controller.Get_MaDH_By_CTDH(id)))
                {
                    MessageBox.Show("Xóa thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Có lỗi đã xảy ra!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string? trangthai = "Chờ xác nhận";
            if (rbDVC.Checked)
                trangthai = "Đang vận chuyển";
            else if (rbGTC.Checked)
                trangthai = "Giao thành công";
            else
                trangthai = "Chờ xác nhận";
            if (dh_controller.CapNhat_TrangThai(dh_controller.Get_MaDH_By_CTDH(id), trangthai))
            {
                MessageBox.Show("Lưu thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            }
        }

        private void ChiTiet_DonHang_Load(object sender, EventArgs e)
        {

        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            string data = $"Phiếu đơn hàng\n"
                        + "-------------------------\n"
                        + "Mã đơn hàng: " +txtMaDH.Text + "\n"
                        + "Ngày tạo đơn: " + txtNgay.Text + "\n"
                        + "Mã khách hàng: " + txtMaKH.Text  + "\n"
                        + "Tên khách hàng: " + txtTenKH.Text + "\n"
                        + "Số điện thoại: " + txtSDT.Text + "\n"
                        + "Địa chỉ: " + txtDiaChi.Text + "\n"
                        + "Ghi chú: " + txtGhiChu.Text + "\n"
                        + "-------------------------\n"
                        + "Ngày in: " + DateTime.Now.ToString("dd/MM/yyyy");

            new XuatFile().InData(data);
        }
    }
}
