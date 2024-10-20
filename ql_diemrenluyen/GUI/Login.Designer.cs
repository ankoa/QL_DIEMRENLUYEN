namespace ql_diemrenluyen.GUI
{
    partial class Login
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
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            inputUser = new TextBox();
            mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            label3 = new Label();
            pictureBox3 = new PictureBox();
            inputPass = new TextBox();
            pictureBox4 = new PictureBox();
            label6 = new Label();
            pictureBox5 = new PictureBox();
            btnLogin = new Button();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Image = Properties.Resources.close;
            pictureBox1.Location = new Point(423, 22);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(39, 32);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.sgu_logo;
            pictureBox2.Location = new Point(125, 48);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(232, 190);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // inputUser
            // 
            inputUser.BackColor = Color.SkyBlue;
            inputUser.BorderStyle = BorderStyle.None;
            inputUser.Font = new Font("Cascadia Code", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            inputUser.ForeColor = Color.White;
            inputUser.Location = new Point(68, 320);
            inputUser.Name = "inputUser";
            inputUser.Size = new Size(347, 23);
            inputUser.TabIndex = 2;
            inputUser.TextChanged += textBox1_TextChanged;
            // 
            // mySqlCommand1
            // 
            mySqlCommand1.CacheAge = 0;
            mySqlCommand1.Connection = null;
            mySqlCommand1.EnableCaching = false;
            mySqlCommand1.Transaction = null;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(55, 330);
            label1.Name = "label1";
            label1.Size = new Size(370, 21);
            label1.TabIndex = 3;
            label1.Text = "..........................................................................................";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Cascadia Code", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(93, 284);
            label2.Name = "label2";
            label2.Size = new Size(155, 25);
            label2.TabIndex = 4;
            label2.Text = "Tên đăng nhập";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Cascadia Code", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(148, 192);
            label4.Name = "label4";
            label4.Size = new Size(209, 46);
            label4.TabIndex = 6;
            label4.Text = "ĐĂNG NHẬP";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Cascadia Code", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(93, 386);
            label3.Name = "label3";
            label3.Size = new Size(100, 25);
            label3.TabIndex = 7;
            label3.Text = "Mật khẩu";
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.user;
            pictureBox3.Location = new Point(55, 272);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(34, 37);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 8;
            pictureBox3.TabStop = false;
            // 
            // inputPass
            // 
            inputPass.BackColor = Color.SkyBlue;
            inputPass.BorderStyle = BorderStyle.None;
            inputPass.Font = new Font("Cascadia Code", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            inputPass.ForeColor = Color.White;
            inputPass.Location = new Point(68, 420);
            inputPass.Name = "inputPass";
            inputPass.PasswordChar = '●';
            inputPass.Size = new Size(306, 23);
            inputPass.TabIndex = 9;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.padlock;
            pictureBox4.Location = new Point(55, 374);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(34, 37);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 12;
            pictureBox4.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(55, 430);
            label6.Name = "label6";
            label6.Size = new Size(370, 21);
            label6.TabIndex = 10;
            label6.Text = "..........................................................................................";
            // 
            // pictureBox5
            // 
            pictureBox5.Image = Properties.Resources.view;
            pictureBox5.Location = new Point(381, 406);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(34, 37);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 13;
            pictureBox5.TabStop = false;
            pictureBox5.Click += pictureBox5_Click;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = SystemColors.Highlight;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Cascadia Code", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(117, 507);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(240, 75);
            btnLogin.TabIndex = 14;
            btnLogin.Text = "Đăng nhập";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += button1_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Cascadia Code", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(295, 460);
            label5.Name = "label5";
            label5.Size = new Size(120, 17);
            label5.TabIndex = 15;
            label5.Text = "Quên mật khẩu?";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SkyBlue;
            ClientSize = new Size(484, 661);
            Controls.Add(label5);
            Controls.Add(btnLogin);
            Controls.Add(pictureBox5);
            Controls.Add(inputPass);
            Controls.Add(pictureBox4);
            Controls.Add(label6);
            Controls.Add(inputUser);
            Controls.Add(pictureBox3);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private TextBox inputUser;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private Label label1;
        private Label label2;
        private Label label4;
        private Label label3;
        private PictureBox pictureBox3;
        private TextBox inputPass;
        private PictureBox pictureBox4;
        private Label label6;
        private PictureBox pictureBox5;
        private Button btnLogin;
        private Label label5;
    }
}