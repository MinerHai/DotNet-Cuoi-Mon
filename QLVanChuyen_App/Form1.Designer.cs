namespace QLVanChuyen_App
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            panel3 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            panel4 = new Panel();
            lbError = new Label();
            linkLabel1 = new LinkLabel();
            label5 = new Label();
            panel6 = new Panel();
            txtPassword = new TextBox();
            panel5 = new Panel();
            btnLogin = new Button();
            label4 = new Label();
            label3 = new Label();
            txtUsername = new TextBox();
            label2 = new Label();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 92, 103);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(-4, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(437, 530);
            panel1.TabIndex = 0;
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
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel4.BackColor = Color.FromArgb(242, 242, 242);
            panel4.Controls.Add(lbError);
            panel4.Controls.Add(linkLabel1);
            panel4.Controls.Add(label5);
            panel4.Controls.Add(panel6);
            panel4.Controls.Add(txtPassword);
            panel4.Controls.Add(panel5);
            panel4.Controls.Add(btnLogin);
            panel4.Controls.Add(label4);
            panel4.Controls.Add(label3);
            panel4.Controls.Add(txtUsername);
            panel4.Controls.Add(label2);
            panel4.Location = new Point(432, 1);
            panel4.Name = "panel4";
            panel4.Size = new Size(401, 530);
            panel4.TabIndex = 1;
            panel4.Paint += panel4_Paint;
            // 
            // lbError
            // 
            lbError.AutoSize = true;
            lbError.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbError.ForeColor = Color.Red;
            lbError.Location = new Point(52, 299);
            lbError.Name = "lbError";
            lbError.Size = new Size(0, 17);
            lbError.TabIndex = 13;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Segoe UI", 12F);
            linkLabel1.LinkColor = Color.Red;
            linkLabel1.Location = new Point(201, 395);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(65, 21);
            linkLabel1.TabIndex = 12;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Sign Up";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(52, 395);
            label5.Name = "label5";
            label5.Size = new Size(134, 21);
            label5.TabIndex = 11;
            label5.Text = "Chưa có tài khoản";
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(0, 92, 103);
            panel6.Location = new Point(52, 271);
            panel6.Name = "panel6";
            panel6.Size = new Size(333, 1);
            panel6.TabIndex = 10;
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            txtPassword.BackColor = Color.FromArgb(242, 242, 242);
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Segoe UI", 12F);
            txtPassword.Location = new Point(52, 243);
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
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(0, 92, 103);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(52, 343);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(95, 37);
            btnLogin.TabIndex = 7;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(52, 219);
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
            txtUsername.TextChanged += txtUsername_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(0, 92, 103);
            label2.Location = new Point(157, 22);
            label2.Name = "label2";
            label2.Size = new Size(112, 47);
            label2.TabIndex = 2;
            label2.Text = "Login";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(829, 530);
            Controls.Add(panel4);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            Text = "Login";
            FormClosed += Form1_FormClosed;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private Panel panel3;
        private Panel panel4;
        private Label label2;
        private Label label3;
        private TextBox txtUsername;
        private Label label4;
        private Button btnLogin;
        private Panel panel5;
        private Panel panel6;
        private TextBox txtPassword;
        private LinkLabel linkLabel1;
        private Label label5;
        private Label lbError;
    }
}
