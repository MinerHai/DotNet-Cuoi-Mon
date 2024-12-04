namespace QLVanChuyen_App.views
{
    partial class DashBoard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashBoard));
            panel1 = new Panel();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            lbUsername = new Label();
            panel2 = new Panel();
            panel8 = new Panel();
            label12 = new Label();
            label13 = new Label();
            panel7 = new Panel();
            label11 = new Label();
            label6 = new Label();
            panel6 = new Panel();
            label9 = new Label();
            label5 = new Label();
            panel5 = new Panel();
            label10 = new Label();
            label4 = new Label();
            panel4 = new Panel();
            label3 = new Label();
            label7 = new Label();
            panel3 = new Panel();
            label8 = new Label();
            label2 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            panel8.SuspendLayout();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.RoyalBlue;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(lbUsername);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(930, 50);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(74, 2);
            label1.Name = "label1";
            label1.Size = new Size(85, 37);
            label1.TabIndex = 3;
            label1.Text = "Menu";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(32, 6);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(36, 31);
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(790, 8);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(37, 31);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // lbUsername
            // 
            lbUsername.AutoSize = true;
            lbUsername.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbUsername.ForeColor = Color.White;
            lbUsername.Location = new Point(833, 12);
            lbUsername.Name = "lbUsername";
            lbUsername.Size = new Size(85, 21);
            lbUsername.TabIndex = 0;
            lbUsername.Text = "User name";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(224, 224, 224);
            panel2.Controls.Add(panel8);
            panel2.Controls.Add(panel7);
            panel2.Controls.Add(panel6);
            panel2.Controls.Add(panel5);
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(panel3);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 50);
            panel2.Name = "panel2";
            panel2.Size = new Size(246, 537);
            panel2.TabIndex = 1;
            // 
            // panel8
            // 
            panel8.BackColor = Color.FromArgb(224, 224, 224);
            panel8.BackgroundImageLayout = ImageLayout.Center;
            panel8.Controls.Add(label12);
            panel8.Controls.Add(label13);
            panel8.Location = new Point(0, 195);
            panel8.Name = "panel8";
            panel8.Size = new Size(249, 48);
            panel8.TabIndex = 5;
            panel8.MouseEnter += panel_MouseEnter;
            panel8.MouseLeave += panel_MouseLeave;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label12.ForeColor = Color.FromArgb(88, 88, 88);
            label12.Location = new Point(54, 15);
            label12.Name = "label12";
            label12.Size = new Size(142, 21);
            label12.TabIndex = 4;
            label12.Text = "Chi tiết đơn hàng";
            label12.MouseEnter += label_ForwardMouseEnter;
            label12.MouseLeave += label_ForwardMouseLeave;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 16F);
            label13.Image = (Image)resources.GetObject("label13.Image");
            label13.Location = new Point(9, 11);
            label13.Name = "label13";
            label13.Size = new Size(37, 30);
            label13.TabIndex = 0;
            label13.Text = "    ";
            label13.MouseEnter += label_ForwardMouseEnter;
            label13.MouseLeave += label_ForwardMouseLeave;
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(224, 224, 224);
            panel7.BackgroundImageLayout = ImageLayout.Center;
            panel7.Controls.Add(label11);
            panel7.Controls.Add(label6);
            panel7.Location = new Point(0, 141);
            panel7.Name = "panel7";
            panel7.Size = new Size(249, 48);
            panel7.TabIndex = 3;
            panel7.MouseEnter += panel_MouseEnter;
            panel7.MouseLeave += panel_MouseLeave;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label11.ForeColor = Color.FromArgb(88, 88, 88);
            label11.Location = new Point(54, 15);
            label11.Name = "label11";
            label11.Size = new Size(146, 21);
            label11.TabIndex = 4;
            label11.Text = "Quản lý đơn hàng";
            label11.MouseEnter += label_ForwardMouseEnter;
            label11.MouseLeave += label_ForwardMouseLeave;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 16F);
            label6.Image = (Image)resources.GetObject("label6.Image");
            label6.Location = new Point(9, 11);
            label6.Name = "label6";
            label6.Size = new Size(37, 30);
            label6.TabIndex = 0;
            label6.Text = "    ";
            label6.MouseEnter += label_ForwardMouseEnter;
            label6.MouseLeave += label_ForwardMouseLeave;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(224, 224, 224);
            panel6.BackgroundImageLayout = ImageLayout.Center;
            panel6.Controls.Add(label9);
            panel6.Controls.Add(label5);
            panel6.Location = new Point(0, 249);
            panel6.Name = "panel6";
            panel6.Size = new Size(249, 48);
            panel6.TabIndex = 3;
            panel6.MouseEnter += panel_MouseEnter;
            panel6.MouseLeave += panel_MouseLeave;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label9.ForeColor = Color.FromArgb(88, 88, 88);
            label9.Location = new Point(48, 14);
            label9.Name = "label9";
            label9.Size = new Size(162, 21);
            label9.TabIndex = 2;
            label9.Text = "Quản lý khách hàng";
            label9.MouseEnter += label_ForwardMouseEnter;
            label9.MouseLeave += label_ForwardMouseLeave;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 16F);
            label5.Image = (Image)resources.GetObject("label5.Image");
            label5.Location = new Point(9, 11);
            label5.Name = "label5";
            label5.Size = new Size(37, 30);
            label5.TabIndex = 0;
            label5.Text = "    ";
            label5.MouseEnter += label_ForwardMouseEnter;
            label5.MouseLeave += label_ForwardMouseLeave;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(224, 224, 224);
            panel5.BackgroundImageLayout = ImageLayout.Center;
            panel5.Controls.Add(label10);
            panel5.Controls.Add(label4);
            panel5.Location = new Point(0, 303);
            panel5.Name = "panel5";
            panel5.Size = new Size(249, 48);
            panel5.TabIndex = 3;
            panel5.MouseEnter += panel_MouseEnter;
            panel5.MouseLeave += panel_MouseLeave;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label10.ForeColor = Color.FromArgb(88, 88, 88);
            label10.Location = new Point(48, 11);
            label10.Name = "label10";
            label10.Size = new Size(168, 21);
            label10.TabIndex = 3;
            label10.Text = "Quản lý phương tiện";
            label10.MouseEnter += label_ForwardMouseEnter;
            label10.MouseLeave += label_ForwardMouseLeave;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 16F);
            label4.Image = (Image)resources.GetObject("label4.Image");
            label4.Location = new Point(9, 11);
            label4.Name = "label4";
            label4.Size = new Size(37, 30);
            label4.TabIndex = 0;
            label4.Text = "    ";
            label4.MouseEnter += label_ForwardMouseEnter;
            label4.MouseLeave += label_ForwardMouseLeave;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(224, 224, 224);
            panel4.BackgroundImageLayout = ImageLayout.Center;
            panel4.Controls.Add(label3);
            panel4.Controls.Add(label7);
            panel4.Location = new Point(0, 87);
            panel4.Name = "panel4";
            panel4.Size = new Size(246, 48);
            panel4.TabIndex = 2;
            panel4.MouseEnter += panel_MouseEnter;
            panel4.MouseLeave += panel_MouseLeave;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16F);
            label3.Image = (Image)resources.GetObject("label3.Image");
            label3.Location = new Point(9, 11);
            label3.Name = "label3";
            label3.Size = new Size(37, 30);
            label3.TabIndex = 0;
            label3.Text = "    ";
            label3.MouseEnter += label_ForwardMouseEnter;
            label3.MouseLeave += label_ForwardMouseLeave;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label7.ForeColor = Color.FromArgb(88, 88, 88);
            label7.Location = new Point(52, 15);
            label7.Name = "label7";
            label7.Size = new Size(145, 21);
            label7.TabIndex = 1;
            label7.Text = "Quản lý tài khoản";
            label7.MouseEnter += label_ForwardMouseEnter;
            label7.MouseLeave += label_ForwardMouseLeave;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(195, 193, 195);
            panel3.BackgroundImageLayout = ImageLayout.Center;
            panel3.Controls.Add(label8);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(3, 33);
            panel3.Name = "panel3";
            panel3.Size = new Size(240, 48);
            panel3.TabIndex = 1;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label8.ForeColor = Color.FromArgb(88, 88, 88);
            label8.Location = new Point(52, 15);
            label8.Name = "label8";
            label8.Size = new Size(56, 21);
            label8.TabIndex = 2;
            label8.Text = "Home";
            label8.MouseEnter += label_ForwardMouseEnter;
            label8.MouseLeave += label_ForwardMouseLeave;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16F);
            label2.Image = (Image)resources.GetObject("label2.Image");
            label2.Location = new Point(9, 11);
            label2.Name = "label2";
            label2.Size = new Size(37, 30);
            label2.TabIndex = 0;
            label2.Text = "    ";
            label2.MouseEnter += label_ForwardMouseEnter;
            label2.MouseLeave += label_ForwardMouseLeave;
            // 
            // DashBoard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(930, 587);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "DashBoard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DashBoard";
            FormClosed += DashBoard_FormClosed;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label lbUsername;
        private PictureBox pictureBox1;
        private Label label1;
        private PictureBox pictureBox2;
        private Panel panel3;
        private Label label2;
        private Panel panel4;
        private Label label3;
        private Panel panel6;
        private Label label5;
        private Panel panel5;
        private Label label4;
        private Panel panel7;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Panel panel8;
        private Label label12;
        private Label label13;
        private Label label11;
        private Label label10;
    }
}