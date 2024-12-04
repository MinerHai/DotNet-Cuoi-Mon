using QLVanChuyen_App.controllers;
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
    public partial class SignUp : Form
    {
        private readonly UserController user_controller;
        public SignUp()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            user_controller  = new UserController();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }

        private void SignUp_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnDangKi_Click(object sender, EventArgs e)
        {
            string? username = txtUsername.Text;
            string? password = txtPassword.Text;
            string? confirm = txtConfirm.Text;
            if (username == null  || password == null || confirm == null) {
                lbError.Text = "Vui lòng nhập đầy đủ thông tin";
                return;
            }
            if (username.Contains(' ')) { 
                lbError.Text = "Tài khoản không được chứa dấu cách";
                return;
            }
            if (username.Length < 4 || password.Length < 4)
            {
                lbError.Text = "Tài khoản và mật khẩu yêu cầu tối thiểu 4 kí tự!!";
                return;
            }
            if (password != confirm)
            {
                lbError.Text = "Mật khẩu nhập lại chưa khớp!!";
                return;
            }
            if (user_controller.SignupUser(username, password))
            {
                MessageBox.Show("Đăng kí thành công!!");
                new Form1().Show();
                this.Hide();
            }
            else
            {
                lbError.Text = "Đăng kí thất bại!!";
            }
        }
    }
}
