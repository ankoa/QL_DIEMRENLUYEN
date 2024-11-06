namespace ql_diemrenluyen.GUI
{
    partial class ChangePassword
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
            components = new System.ComponentModel.Container();
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
            timer1 = new System.Windows.Forms.Timer(components);
            pictureBox6 = new PictureBox();
            inputConfirm = new TextBox();
            label7 = new Label();
            label8 = new Label();
            pictureBox7 = new PictureBox();
            pictureBox8 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Image = Properties.Resources.close;
            pictureBox1.Location = new Point(483, 29);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(45, 43);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.sgu_logo;
            pictureBox2.Location = new Point(143, 64);
            pictureBox2.Margin = new Padding(3, 4, 3, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(265, 253);
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
            inputUser.Location = new Point(63, 401);
            inputUser.Margin = new Padding(3, 4, 3, 4);
            inputUser.Name = "inputUser";
            inputUser.PasswordChar = '●';
            inputUser.Size = new Size(425, 28);
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
            label1.Location = new Point(51, 414);
            label1.Name = "label1";
            label1.Size = new Size(462, 28);
            label1.TabIndex = 3;
            label1.Text = "..........................................................................................";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Cascadia Code", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(106, 353);
            label2.Name = "label2";
            label2.Size = new Size(168, 32);
            label2.TabIndex = 4;
            label2.Text = "Mật khẩu cũ";
            label2.Click += label2_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Cascadia Code", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(110, 256);
            label4.Name = "label4";
            label4.Size = new Size(337, 58);
            label4.TabIndex = 6;
            label4.Text = "ĐỔI MẬT KHẨU";
            label4.Click += label4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Cascadia Code", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(106, 482);
            label3.Name = "label3";
            label3.Size = new Size(182, 32);
            label3.TabIndex = 7;
            label3.Text = "Mật khẩu mới";
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.user;
            pictureBox3.Location = new Point(63, 337);
            pictureBox3.Margin = new Padding(3, 4, 3, 4);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(39, 49);
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
            inputPass.Location = new Point(63, 527);
            inputPass.Margin = new Padding(3, 4, 3, 4);
            inputPass.Name = "inputPass";
            inputPass.PasswordChar = '●';
            inputPass.Size = new Size(395, 28);
            inputPass.TabIndex = 9;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.padlock;
            pictureBox4.Location = new Point(63, 466);
            pictureBox4.Margin = new Padding(3, 4, 3, 4);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(39, 49);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 12;
            pictureBox4.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(51, 541);
            label6.Name = "label6";
            label6.Size = new Size(462, 28);
            label6.TabIndex = 10;
            label6.Text = "..........................................................................................";
            // 
            // pictureBox5
            // 
            pictureBox5.Cursor = Cursors.Hand;
            pictureBox5.Image = Properties.Resources.view;
            pictureBox5.Location = new Point(464, 506);
            pictureBox5.Margin = new Padding(3, 4, 3, 4);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(39, 49);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 13;
            pictureBox5.TabStop = false;
            pictureBox5.Click += pictureBox5_Click;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = SystemColors.Highlight;
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Cascadia Code", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(143, 742);
            btnLogin.Margin = new Padding(3, 4, 3, 4);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(274, 100);
            btnLogin.TabIndex = 14;
            btnLogin.Text = "Xác nhận";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += button1_Click;
            // 
            // pictureBox6
            // 
            pictureBox6.Cursor = Cursors.Hand;
            pictureBox6.Image = Properties.Resources.view;
            pictureBox6.Location = new Point(463, 617);
            pictureBox6.Margin = new Padding(3, 4, 3, 4);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(39, 49);
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.TabIndex = 20;
            pictureBox6.TabStop = false;
            // 
            // inputConfirm
            // 
            inputConfirm.BackColor = Color.SkyBlue;
            inputConfirm.BorderStyle = BorderStyle.None;
            inputConfirm.Font = new Font("Cascadia Code", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            inputConfirm.ForeColor = Color.White;
            inputConfirm.Location = new Point(62, 638);
            inputConfirm.Margin = new Padding(3, 4, 3, 4);
            inputConfirm.Name = "inputConfirm";
            inputConfirm.PasswordChar = '●';
            inputConfirm.Size = new Size(395, 28);
            inputConfirm.TabIndex = 17;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(50, 652);
            label7.Name = "label7";
            label7.Size = new Size(462, 28);
            label7.TabIndex = 18;
            label7.Text = "..........................................................................................";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Cascadia Code", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
            label8.Location = new Point(105, 593);
            label8.Name = "label8";
            label8.Size = new Size(182, 32);
            label8.TabIndex = 16;
            label8.Text = "Xác nhận lại";
            // 
            // pictureBox7
            // 
            pictureBox7.Image = Properties.Resources.padlock;
            pictureBox7.Location = new Point(62, 577);
            pictureBox7.Margin = new Padding(3, 4, 3, 4);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(39, 49);
            pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox7.TabIndex = 19;
            pictureBox7.TabStop = false;
            // 
            // pictureBox8
            // 
            pictureBox8.Cursor = Cursors.Hand;
            pictureBox8.Image = Properties.Resources.view;
            pictureBox8.Location = new Point(463, 380);
            pictureBox8.Margin = new Padding(3, 4, 3, 4);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(39, 49);
            pictureBox8.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox8.TabIndex = 21;
            pictureBox8.TabStop = false;
            // 
            // ChangePassword
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SkyBlue;
            ClientSize = new Size(553, 881);
            Controls.Add(pictureBox8);
            Controls.Add(pictureBox6);
            Controls.Add(inputConfirm);
            Controls.Add(pictureBox7);
            Controls.Add(label7);
            Controls.Add(label8);
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
            Margin = new Padding(3, 4, 3, 4);
            Name = "ChangePassword";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += Login_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
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
        private System.Windows.Forms.Timer timer1;
        private PictureBox pictureBox6;
        private TextBox inputConfirm;
        private Label label7;
        private Label label8;
        private PictureBox pictureBox7;
        private PictureBox pictureBox8;
    }
}