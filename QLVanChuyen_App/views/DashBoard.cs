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
using System.Windows.Forms.DataVisualization.Charting;

namespace QLVanChuyen_App.views
{
    public partial class DashBoard : Form
    {
        private readonly Users user_logged;
        private readonly donHangController dh_controller;
        private readonly khachHangController kh_controller;
        private readonly PhuongTienController pt_controller;

        public DashBoard(Users userLog)
        {
            InitializeComponent();
            user_logged = userLog;
            lbUsername.Text = user_logged.UserName;
            dh_controller = new donHangController();
            kh_controller = new khachHangController();
            pt_controller = new PhuongTienController();
            CreatePieChartInPanel();
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
        private void btnLogout_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }
        private void btnQLDH_MouseClick(object sender, MouseEventArgs e)
        {
            new QLDH(user_logged).Show();
            this.Hide();
        }
        private void btnPhuongTien_MouseClick(object sender, MouseEventArgs e)
        {
            new QLPT(user_logged).Show();
            this.Hide();
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            lb_dh_slg.Text = dh_controller.Get_SoLuong().ToString();
            lb_dh_desc.Text = "Số đơn đã giao: " + dh_controller.Get_SoLuong("Giao thành công").ToString();
            lb_kh_desc.Text = "Số lượng khách hàng: " + kh_controller.Get_SoLuong().ToString();
            lb_kh_slg.Text = kh_controller.Get_SoLuong().ToString();
            lb_pt_desc.Text = "Đang hoạt động: " + pt_controller.Get_SoLuong().ToString();
            lb_pt_slg.Text = pt_controller.Get_SoLuong().ToString();
        }
        private void CreatePieChartInPanel()
        {
            int chn = dh_controller.Get_SoLuong("Chờ xác nhận");
            int dvc = dh_controller.Get_SoLuong("Đang vận chuyển");
            int gtc = dh_controller.Get_SoLuong("Giao thành công");
            int tong = dh_controller.Get_SoLuong();
            Console.WriteLine($"Chờ xác nhận: {chn}, Đang vận chuyển: {dvc}, Giao thành công: {gtc}, Tổng: {tong}");

            if (tong == 0)
            {
                MessageBox.Show("Không có dữ liệu để hiển thị biểu đồ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Chart pieChart = new Chart
            {
                Dock = DockStyle.Fill,
                BackColor = SystemColors.Control
            };

            ChartArea chartArea = new ChartArea("MainArea")
            {
                BackColor = SystemColors.Control
            };
            pieChart.ChartAreas.Add(chartArea);

            Series series = new Series("Phân phối dữ liệu")
            {
                ChartType = SeriesChartType.Pie
            };

            series.Points.AddXY("Chờ xác nhận", (double)chn / tong * 100);
            series.Points.AddXY("Đang vận chuyển", (double)dvc / tong * 100);
            series.Points.AddXY("Giao thành công", (double)gtc / tong * 100);


            pieChart.Series.Add(series);

            series["PieLabelStyle"] = "Outside";
            series["PieStartAngle"] = "270";

            panelChart.Controls.Add(pieChart);
        }

        private void btnDoiMatKhau_MouseClick(object sender, MouseEventArgs e)
        {
            this.Hide();
            new DoiMatKhau(user_logged).Show();
        }

    }

}
