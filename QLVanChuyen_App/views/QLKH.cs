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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QLVanChuyen_App.views
{
    public partial class QLKH : Form
    {
        private readonly Users user_logged;
        private readonly khachHangController kh_controller;
        public QLKH(Users user_logged)
        {
            InitializeComponent();
            this.user_logged = user_logged;
            lbUsername.Text = user_logged.UserName;
            kh_controller = new khachHangController();
            loadData();
        }

        void loadData()
        {
            tableKH.DataSource = null;
            tableKH.DataSource = kh_controller.GetKhachHangDataTable();
        }
        void clearTXt()
        {
            txtDiaChi.Clear();
            txtID.Clear();
            txtSDT.Clear();
            txtHoTen.Clear();
        }
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

        private void btnHome_MouseClick(object sender, MouseEventArgs e)
        {
            new DashBoard(user_logged).Show();
            this.Hide();
        }
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
        private void btnPhuongTien_MouseClick(object sender, MouseEventArgs e)
        {
            new QLPT(user_logged).Show();
            this.Hide();
        }
        private void btnQLDH_MouseClick(object sender, MouseEventArgs e)
        {
            new QLDH(user_logged).Show();
            this.Hide();
        }
        private void tableKH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = tableKH.Rows[e.RowIndex];
                txtID.Text = row.Cells["MaKhachHang"].Value.ToString();
                txtHoTen.Text = row.Cells["TenKhachHang"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                txtSDT.Text = row.Cells["SDT"].Value.ToString();
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string? hoten = txtHoTen.Text;
            string? diachi = txtDiaChi.Text;
            string? sdt = txtSDT.Text;
            if (hoten.IsNullOrEmpty() || diachi.IsNullOrEmpty() || sdt.IsNullOrEmpty())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (kh_controller.addKhachHang(hoten, sdt, diachi) != null)
            {
                MessageBox.Show("Thêm thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearTXt();
                loadData();
            }
            else
                MessageBox.Show("Có lỗi xảy ra!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                tableKH.DataSource = kh_controller.GetKhachHangDataTable(key);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (txtID.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần xóa!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult confirmation = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa người dùng: {txtHoTen.Text}?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            int id = Convert.ToInt32(txtID.Text);
            if (kh_controller.RemoveKhachHang(id))
            {
                MessageBox.Show("Xóa thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearTXt();
                loadData();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtID.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần chỉnh sửa!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string? hoten = txtHoTen.Text;
            string? diachi = txtDiaChi.Text;
            string? sdt = txtSDT.Text;
            if (hoten.IsNullOrEmpty() || diachi.IsNullOrEmpty() || sdt.IsNullOrEmpty())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult confirmation = MessageBox.Show(
                $"Bạn có chắc chắn muốn chỉnh sửa khách hàng: {txtHoTen.Text}?",
                "Xác nhận sửa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (confirmation == DialogResult.Yes)
            {
                int id = Convert.ToInt32(txtID.Text);
                if (kh_controller.EditKhachHang(id, hoten, sdt, diachi))
                {
                    MessageBox.Show("Chỉnh sửa thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearTXt();
                    loadData();
                }
            }

        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            new XuatFile().In_DataTable_To_Excel(tableKH);
        }
    }
}
