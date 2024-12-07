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
    public partial class DoiMatKhau : Form
    {
        private readonly Users user_logged;
        private readonly UserController user_controller;
        public DoiMatKhau(Users _user_logged)
        {
            InitializeComponent();
            user_logged = _user_logged;
            user_controller = new UserController();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new DashBoard(user_logged).Show();
        }

        private void btnDangKi_Click(object sender, EventArgs e)
        {
            string? password = txtPassword.Text;
            string? confirm = txtConfirm.Text;
            if (password == null || confirm == null)
            {
                lbErr.Text = "Vui lòng nhập đầy đủ thông tin";
                return;
            }
            if (password.Length < 4)
            {
                lbErr.Text = "Mật khẩu yêu cầu tối thiểu 4 kí tự!!";
                return;
            }
            if (password != confirm)
            {
                lbErr.Text = "Mật khẩu nhập lại chưa khớp!!";
                return;
            }
            if (user_controller.ChangePassword(user_logged.UserName, password))
            {
                MessageBox.Show("Đổi mật khẩu thành công!!");
                new Form1().Show();
                this.Hide();
            }
        }

        private void DoiMatKhau_FormClosed(object sender, FormClosedEventArgs e)
        {
            new DashBoard(user_logged).Show();
        }
    }
}
