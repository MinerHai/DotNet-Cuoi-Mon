using Microsoft.IdentityModel.Tokens;
using QLVanChuyen_App.controllers;
using QLVanChuyen_App.views;

namespace QLVanChuyen_App
{
    public partial class Form1 : Form
    {
        private readonly UserController user_controller;
        public Form1()
        {
            InitializeComponent();
            user_controller = new UserController();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string? username = txtUsername.Text;
            string? password = txtPassword.Text;
            if (username.IsNullOrEmpty() || password.IsNullOrEmpty())
            {
                MessageBox.Show("Vui lòng nhập đầu đủ thông tin");
                lbError.Text = "Vui lòng nhập đầy đủ thông tin";
                return;
            }
            if (user_controller.LoginUser(username, password) != null)
            {
                this.Hide();
                new DashBoard(user_controller.LoginUser(username, password)).Show();
            }
            else
            {
                lbError.Text = "Tài khoản mật khẩu không chính xác!!";
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new SignUp().Show();
            this.Hide();
        }
    }
}
