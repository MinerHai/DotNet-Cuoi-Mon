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
    public partial class QLPT : Form
    {
        private readonly Users user_logged;
        private readonly PhuongTienController pt_controller;
        public QLPT(Users user_logged)
        {
            InitializeComponent();
            this.user_logged = user_logged;
            lbUsername.Text = user_logged.UserName;
            pt_controller = new PhuongTienController();
            loadData();
        }
        //
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
        private void btnQLKH_MouseClick(object sender, MouseEventArgs e)
        {
            new QLKH(user_logged).Show();
            this.Hide();
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
        public void loadData()
        {
            tablePT.DataSource = pt_controller.GetPhuongTienDataTable();
        }
        void cleatTxt()
        {
            txtBienSo.Clear();
            txtTaiXe.Clear();
            txtLoaiXe.Clear();
            txtID.Clear();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string? bienso = txtBienSo.Text;
            string? taixe = txtTaiXe.Text;
            string? loaixe = txtLoaiXe.Text;
            if (bienso.IsNullOrEmpty() || taixe.IsNullOrEmpty() || loaixe.IsNullOrEmpty())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (pt_controller.addPhuongTien(bienso, taixe, loaixe))
            {
                MessageBox.Show("Thêm thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cleatTxt();
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
                tablePT.DataSource = pt_controller.GetPhuongTienDataTable(key);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtID.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Vui lòng chọn phương tiện cần xóa!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult confirmation = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa xe: {txtBienSo.Text}?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            int id = Convert.ToInt32(txtID.Text);
            if (pt_controller.RemovePhuongTien(id))
            {
                MessageBox.Show("Xóa thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cleatTxt();
                loadData();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtID.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Vui lòng chọn phương tiện cần chỉnh sửa!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string? bienso = txtBienSo.Text;
            string? taixe = txtTaiXe.Text;
            string? loaixe = txtLoaiXe.Text;
            if (bienso.IsNullOrEmpty() || taixe.IsNullOrEmpty() || loaixe.IsNullOrEmpty())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult confirmation = MessageBox.Show(
                $"Bạn có chắc chắn muốn chỉnh sửa phương tiện: {txtBienSo.Text}?",
                "Xác nhận sửa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            int id = Convert.ToInt32(txtID.Text);
            if (pt_controller.EditPhuongTien(id, bienso, taixe, loaixe))
            {
                MessageBox.Show("Chỉnh sửa thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cleatTxt();
                loadData();
            }
        }
        private void btnQLDH_MouseClick(object sender, MouseEventArgs e)
        {
            new QLDH(user_logged).Show();
            this.Hide();
        }

        private void tablePT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = tablePT.Rows[e.RowIndex];
                txtID.Text = row.Cells["MaXe"].Value.ToString();
                txtBienSo.Text = row.Cells["BienSo"].Value.ToString();
                txtTaiXe.Text = row.Cells["TaiXe"].Value.ToString();
                txtLoaiXe.Text = row.Cells["LoaiXe"].Value.ToString();
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            new XuatFile().In_DataTable_To_Excel(tablePT);
        }
        //
    }
}
