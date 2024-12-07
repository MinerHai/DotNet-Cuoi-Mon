namespace QLVanChuyen_App.views
{
    partial class DoiMatKhau
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
            lbError = new Label();
            panel7 = new Panel();
            txtConfirm = new TextBox();
            panel6 = new Panel();
            label5 = new Label();
            txtPassword = new TextBox();
            label4 = new Label();
            panel1 = new Panel();
            lbErr = new Label();
            label8 = new Label();
            btnBack = new Button();
            btnDangKi = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lbError
            // 
            lbError.AutoSize = true;
            lbError.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbError.ForeColor = Color.Red;
            lbError.Location = new Point(34, 262);
            lbError.Name = "lbError";
            lbError.Size = new Size(0, 17);
            lbError.TabIndex = 24;
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(0, 92, 103);
            panel7.Location = new Point(33, 148);
            panel7.Name = "panel7";
            panel7.Size = new Size(333, 1);
            panel7.TabIndex = 23;
            // 
            // txtConfirm
            // 
            txtConfirm.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            txtConfirm.BackColor = Color.FromArgb(242, 242, 242);
            txtConfirm.BorderStyle = BorderStyle.None;
            txtConfirm.Font = new Font("Segoe UI", 12F);
            txtConfirm.Location = new Point(33, 120);
            txtConfirm.Name = "txtConfirm";
            txtConfirm.PasswordChar = '*';
            txtConfirm.Size = new Size(333, 22);
            txtConfirm.TabIndex = 22;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(0, 92, 103);
            panel6.Location = new Point(33, 71);
            panel6.Name = "panel6";
            panel6.Size = new Size(333, 1);
            panel6.TabIndex = 20;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(33, 96);
            label5.Name = "label5";
            label5.Size = new Size(137, 21);
            label5.TabIndex = 21;
            label5.Text = "Nhập lại mật khẩu";
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            txtPassword.BackColor = Color.FromArgb(242, 242, 242);
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Segoe UI", 12F);
            txtPassword.Location = new Point(33, 43);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(333, 22);
            txtPassword.TabIndex = 19;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(33, 19);
            label4.Name = "label4";
            label4.Size = new Size(76, 21);
            label4.TabIndex = 17;
            label4.Text = "Password";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(242, 242, 242);
            panel1.Controls.Add(lbErr);
            panel1.Controls.Add(panel7);
            panel1.Controls.Add(lbError);
            panel1.Controls.Add(txtConfirm);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(panel6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(txtPassword);
            panel1.Location = new Point(107, 85);
            panel1.Name = "panel1";
            panel1.Size = new Size(405, 208);
            panel1.TabIndex = 25;
            // 
            // lbErr
            // 
            lbErr.AutoSize = true;
            lbErr.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbErr.ForeColor = Color.Red;
            lbErr.Location = new Point(34, 167);
            lbErr.Name = "lbErr";
            lbErr.Size = new Size(0, 17);
            lbErr.TabIndex = 25;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Cursor = Cursors.Hand;
            label8.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label8.ForeColor = Color.FromArgb(88, 88, 88);
            label8.Location = new Point(208, 36);
            label8.Name = "label8";
            label8.Size = new Size(189, 37);
            label8.TabIndex = 26;
            label8.Text = "Đổi mật khẩu";
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(0, 92, 103);
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(378, 343);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(95, 37);
            btnBack.TabIndex = 28;
            btnBack.Text = "Quit";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // btnDangKi
            // 
            btnDangKi.BackColor = Color.FromArgb(0, 92, 103);
            btnDangKi.FlatStyle = FlatStyle.Flat;
            btnDangKi.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDangKi.ForeColor = Color.White;
            btnDangKi.Location = new Point(140, 343);
            btnDangKi.Name = "btnDangKi";
            btnDangKi.Size = new Size(95, 37);
            btnDangKi.TabIndex = 27;
            btnDangKi.Text = "Xác nhận";
            btnDangKi.UseVisualStyleBackColor = false;
            btnDangKi.Click += btnDangKi_Click;
            // 
            // DoiMatKhau
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(195, 193, 195);
            ClientSize = new Size(619, 404);
            Controls.Add(btnBack);
            Controls.Add(btnDangKi);
            Controls.Add(label8);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "DoiMatKhau";
            StartPosition = FormStartPosition.CenterParent;
            Text = "DoiMatKhau";
            FormClosed += DoiMatKhau_FormClosed;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbError;
        private Panel panel7;
        private TextBox txtConfirm;
        private Panel panel6;
        private Label label5;
        private TextBox txtPassword;
        private Label label4;
        private Panel panel1;
        private Label label8;
        private Button btnBack;
        private Button btnDangKi;
        private Label lbErr;
    }
}