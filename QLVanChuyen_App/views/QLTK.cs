 using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
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
    public partial class QLTK : Form
    {
        public Users user_logged { set; get; }
        private readonly UserController user_controller;
        public QLTK(Users userLog)
        {
            InitializeComponent();
            user_logged = userLog;
            lbUsername.Text = user_logged.UserName;
            user_controller = new UserController();
            loadData();
        }

        void loadData()
        {
            tableUser.DataSource = null;
            tableUser.DataSource = user_controller.GetUserDataTable();
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
        private void btnQLDH_MouseClick(object sender, MouseEventArgs e)
        {
            new QLDH(user_logged).Show();
            this.Hide();
        }
        void Cleartxt()
        {
            txtID.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            listRole.SelectedIndex = 0;
        }
        private void tableUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Cleartxt();
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = tableUser.Rows[e.RowIndex];
                txtID.Text = row.Cells["Userid"].Value.ToString();
                txtUsername.Text = row.Cells["Username"].Value.ToString();
                int index = listRole.Items.IndexOf(row.Cells["Role"].Value.ToString());
                if (index >= 0)
                {
                    listRole.SelectedIndex = index;
                }

            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string? username = txtUsername.Text;
            string? password = txtPassword.Text;
            if (username == null || password == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            if (username.Contains(' '))
            {
                MessageBox.Show("Tài khoản không được chứa dấu cách");
                return;
            }
            if (username.Length < 4 || password.Length < 4)
            {
                MessageBox.Show("Tài khoản và mật khẩu yêu cầu tối thiểu 4 kí tự!!");
                return;
            }
            if (user_controller.SignupUser(username, password))
            {
                MessageBox.Show("Thêm thành công!!");
                loadData();
                Cleartxt();
            }
            else
                MessageBox.Show("Có lỗi xảy ra!!");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string? username = txtUsername.Text;
            if (username == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản!!");
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa người dùng này?",
                                      "Xác nhận xóa",
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (user_controller.RemoveUser(username))
                {
                    MessageBox.Show("Xóa thành công!");
                    loadData();
                    Cleartxt();
                }
                else
                    MessageBox.Show("Có lỗi xảy ra!!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string role = listRole.SelectedItem.ToString();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Thông tin không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmation = MessageBox.Show(
                $"Bạn có chắc chắn muốn thay đổi người dùng: {username}?",
                "Xác nhận thay đổi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmation == DialogResult.Yes)
            {
                if (!string.IsNullOrEmpty(password))
                {
                    if (password.Length <= 3)
                    {
                        MessageBox.Show("Mật khẩu thiết lập phải có độ dài kí tự lớn hơn 3", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    user_controller.ChangePassword(username, password);
                }

                if (user_controller.ChangeRole(username, role))
                {
                    MessageBox.Show("Thay đổi thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Cleartxt();
                    loadData();
                }
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string? timkiem = txtTim.Text;
            if (timkiem.IsNullOrEmpty())
            {
                loadData();
            }
            else
            {
                tableUser.DataSource = null;
                tableUser.DataSource = user_controller.GetUserDataTable(timkiem);
            }

        }

        private void z(object sender, PaintEventArgs e)
        {

        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            new XuatFile().In_DataTable_To_Excel(tableUser);
        }
    }
}
