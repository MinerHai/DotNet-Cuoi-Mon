using Microsoft.IdentityModel.Tokens;
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
    public partial class QLDH : Form
    {
        private readonly Users user_logged;
        private readonly PhuongTienController pt_controller;
        private readonly donHangController dh_controller;
        private readonly khachHangController kh_controller;
        public QLDH(Users user_logged)
        {
            InitializeComponent();
            this.user_logged = user_logged;
            pt_controller = new PhuongTienController();
            dh_controller = new donHangController();
            kh_controller = new khachHangController();
            loadData();
            lbUsername.Text = user_logged.UserName;
            listTaiXe.DataSource = pt_controller.getDS_BienSo();
        }
        //
        public void panel_MouseEnter(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel != null)
            {
                panel.BackColor = Color.FromArgb(195, 193, 195);
            }

        }
        public void panel_MouseLeave(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel != null)
            {
                panel.BackColor = Color.FromArgb(224, 224, 224);
            }
        }
        public void label_ForwardMouseEnter(object sender, EventArgs e)
        {
            Label label = sender as Label;
            if (label != null && label.Parent is Panel parentPanel)
            {
                panel_MouseEnter(parentPanel, e);
            }
        }

        public void label_ForwardMouseLeave(object sender, EventArgs e)
        {
            Label label = sender as Label;
            if (label != null && label.Parent is Panel parentPanel)
            {
                panel_MouseLeave(parentPanel, e);
            }
        }
        public void Form_Closed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        //
        private void btnQLTK_MouseClick(object sender, MouseEventArgs e)
        {
            if (!user_logged.Role.Equals("Admin"))
            {
                MessageBox.Show("Bạn không có quyền truy cập!!!");
                return;
            }
            new QLTK(user_logged).Show();
            this.Hide();
        }
        private void btnQLKH_MouseClick(object sender, MouseEventArgs e)
        {
            new QLKH(user_logged).Show();
            this.Hide();
        }
        private void btnPhuongTien_MouseClick(object sender, MouseEventArgs e)
        {
            new QLPT(user_logged).Show();
            this.Hide();
        }
        private void btnHome_MouseClick(object sender, MouseEventArgs e)
        {
            new DashBoard(user_logged).Show();
            this.Hide();
        }
        //
        void clearTxt()
        {
            txtTenKH.Clear();
            txtDiaChi.Clear();
            txtGhiChu.Clear();
            txtSDT.Clear();
        }
        void loadData()
        {
            tableDH.DataSource = null;
            tableDH.DataSource = dh_controller.GetDonHangDataTable();
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            loadData();
            clearTxt();
        }

        private void bthTimKiem_Click(object sender, EventArgs e)
        {
            string key = txtTim.Text;
            if (key.IsNullOrEmpty())
            {
                loadData();
            }
            else
            {
                tableDH.DataSource = dh_controller.GetDonHangDataTable(key);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string? tenkh = txtTenKH.Text;
            string? diachi = txtDiaChi.Text;
            string? sdt = txtSDT.Text;
            string? ghichu = txtGhiChu.Text;
            if (tenkh.IsNullOrEmpty() || diachi.IsNullOrEmpty() || sdt.IsNullOrEmpty())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int? id_kh = kh_controller.addKhachHang(tenkh, sdt, diachi);
            if (id_kh == null)
            {
                MessageBox.Show("Có lỗi đã xảy ra!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int? id_dh = dh_controller.AddDonHang(id_kh, ghichu);
            if (id_dh == 0)
            {
                MessageBox.Show("Có lỗi đã xảy ra!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int? id_pt = pt_controller.GetID_By_BienSo(listTaiXe.SelectedItem.ToString());
            if (dh_controller.AddCTDonHang(id_dh, id_pt))
            {
                MessageBox.Show("Thêm thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearTxt();
                loadData();
            }
            else
            {
                MessageBox.Show("Có lỗi đã xảy ra!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int selectedRow = tableDH.SelectedRows.Count > 0 ? tableDH.SelectedRows[0].Index : -1;

            if (selectedRow != -1)
            {
                int id = Convert.ToInt32(tableDH.Rows[selectedRow].Cells[0].Value);

                DialogResult confirmation = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa đơn hàng: " + id + "?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmation == DialogResult.Yes)
                {
                    if (dh_controller.RemoveDonHang(id))
                    {
                        MessageBox.Show("Xóa đơn hàng: " + id + " thành công");
                        loadData();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi đã xảy ra!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn đơn hàng!!");
            }
        }

        private void tableDH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = tableDH.Rows[e.RowIndex];
                int id_dh = Convert.ToInt32(row.Cells["MaDonHang"].Value.ToString());
                int id = dh_controller.Get_MaCTHD_By_HD(id_dh);
                new ChiTiet_DonHang(id).Show();
            }
        }
    }
}
