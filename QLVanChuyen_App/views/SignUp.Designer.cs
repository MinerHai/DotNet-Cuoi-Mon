namespace QLVanChuyen_App.views
{
    partial class SignUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignUp));
            panel4 = new Panel();
            lbError = new Label();
            panel7 = new Panel();
            btnBack = new Button();
            txtConfirm = new TextBox();
            panel6 = new Panel();
            label5 = new Label();
            txtPassword = new TextBox();
            panel5 = new Panel();
            btnDangKi = new Button();
            label4 = new Label();
            label3 = new Label();
            txtUsername = new TextBox();
            label2 = new Label();
            panel1 = new Panel();
            panel3 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            panel4.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel4.BackColor = Color.FromArgb(242, 242, 242);
            panel4.Controls.Add(lbError);
            panel4.Controls.Add(panel7);
            panel4.Controls.Add(btnBack);
            panel4.Controls.Add(txtConfirm);
            panel4.Controls.Add(panel6);
            panel4.Controls.Add(label5);
            panel4.Controls.Add(txtPassword);
            panel4.Controls.Add(panel5);
            panel4.Controls.Add(btnDangKi);
            panel4.Controls.Add(label4);
            panel4.Controls.Add(label3);
            panel4.Controls.Add(txtUsername);
            panel4.Controls.Add(label2);
            panel4.Location = new Point(418, -1);
            panel4.Name = "panel4";
            panel4.Size = new Size(430, 571);
            panel4.TabIndex = 3;
            panel4.Paint += panel4_Paint;
            // 
            // lbError
            // 
            lbError.AutoSize = true;
            lbError.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbError.ForeColor = Color.Red;
            lbError.Location = new Point(52, 363);
            lbError.Name = "lbError";
            lbError.Size = new Size(0, 17);
            lbError.TabIndex = 14;
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(0, 92, 103);
            panel7.Location = new Point(52, 330);
            panel7.Name = "panel7";
            panel7.Size = new Size(333, 1);
            panel7.TabIndex = 13;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(0, 92, 103);
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(290, 423);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(95, 37);
            btnBack.TabIndex = 11;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // txtConfirm
            // 
            txtConfirm.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            txtConfirm.BackColor = Color.FromArgb(242, 242, 242);
            txtConfirm.BorderStyle = BorderStyle.None;
            txtConfirm.Font = new Font("Segoe UI", 12F);
            txtConfirm.Location = new Point(52, 302);
            txtConfirm.Name = "txtConfirm";
            txtConfirm.PasswordChar = '*';
            txtConfirm.Size = new Size(333, 22);
            txtConfirm.TabIndex = 12;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(0, 92, 103);
            panel6.Location = new Point(52, 253);
            panel6.Name = "panel6";
            panel6.Size = new Size(333, 1);
            panel6.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(52, 278);
            label5.Name = "label5";
            label5.Size = new Size(137, 21);
            label5.TabIndex = 11;
            label5.Text = "Nhập lại mật khẩu";
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            txtPassword.BackColor = Color.FromArgb(242, 242, 242);
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Segoe UI", 12F);
            txtPassword.Location = new Point(52, 229);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(333, 22);
            txtPassword.TabIndex = 9;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(0, 92, 103);
            panel5.Location = new Point(52, 168);
            panel5.Name = "panel5";
            panel5.Size = new Size(333, 1);
            panel5.TabIndex = 8;
            // 
            // btnDangKi
            // 
            btnDangKi.BackColor = Color.FromArgb(0, 92, 103);
            btnDangKi.FlatStyle = FlatStyle.Flat;
            btnDangKi.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDangKi.ForeColor = Color.White;
            btnDangKi.Location = new Point(52, 423);
            btnDangKi.Name = "btnDangKi";
            btnDangKi.Size = new Size(95, 37);
            btnDangKi.TabIndex = 7;
            btnDangKi.Text = "Đăng kí";
            btnDangKi.UseVisualStyleBackColor = false;
            btnDangKi.Click += btnDangKi_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(52, 201);
            label4.Name = "label4";
            label4.Size = new Size(76, 21);
            label4.TabIndex = 6;
            label4.Text = "Password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(52, 108);
            label3.Name = "label3";
            label3.Size = new Size(81, 21);
            label3.TabIndex = 4;
            label3.Text = "Username";
            // 
            // txtUsername
            // 
            txtUsername.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            txtUsername.BackColor = Color.FromArgb(242, 242, 242);
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Font = new Font("Segoe UI", 12F);
            txtUsername.Location = new Point(52, 140);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(333, 22);
            txtUsername.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(0, 92, 103);
            label2.Location = new Point(157, 22);
            label2.Name = "label2";
            label2.Size = new Size(150, 47);
            label2.TabIndex = 2;
            label2.Text = "Sign Up";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 92, 103);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(-18, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(437, 532);
            panel1.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.Location = new Point(440, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(200, 100);
            panel3.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(255, 200, 0);
            label1.Location = new Point(47, 314);
            label1.Name = "label1";
            label1.Size = new Size(344, 47);
            label1.TabIndex = 1;
            label1.Text = "Quản lý vận chuyển";
            // 
            // panel2
            // 
            panel2.BackgroundImage = (Image)resources.GetObject("panel2.BackgroundImage");
            panel2.Location = new Point(104, 108);
            panel2.Name = "panel2";
            panel2.Size = new Size(227, 182);
            panel2.TabIndex = 0;
            // 
            // SignUp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(829, 530);
            Controls.Add(panel4);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "SignUp";
            Text = "SignUp";
            FormClosed += SignUp_FormClosed;
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel4;
        private Panel panel6;
        private TextBox txtPassword;
        private Panel panel5;
        private Button btnDangKi;
        private Label label4;
        private Label label3;
        private TextBox txtUsername;
        private Label label2;
        private Panel panel1;
        private Panel panel3;
        private Label label1;
        private Panel panel2;
        private Panel panel7;
        private Button btnBack;
        private TextBox txtConfirm;
        private Label label5;
        private Label lbError;
    }
}