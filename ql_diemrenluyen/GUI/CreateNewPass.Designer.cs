namespace ql_diemrenluyen.GUI
{
    partial class CreateNewPass
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
            mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            label4 = new Label();
            label3 = new Label();
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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
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
            // mySqlCommand1
            // 
            mySqlCommand1.CacheAge = 0;
            mySqlCommand1.Connection = null;
            mySqlCommand1.EnableCaching = false;
            mySqlCommand1.Transaction = null;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Cascadia Code", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(59, 192);
            label4.Name = "label4";
            label4.Size = new Size(356, 46);
            label4.TabIndex = 6;
            label4.Text = "TẠO MẬT KHẨU MỚI";
            label4.Click += label4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Cascadia Code", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(93, 299);
            label3.Name = "label3";
            label3.Size = new Size(144, 25);
            label3.TabIndex = 7;
            label3.Text = "Mật khẩu mới";
            // 
            // inputPass
            // 
            inputPass.BackColor = Color.SkyBlue;
            inputPass.BorderStyle = BorderStyle.None;
            inputPass.Font = new Font("Cascadia Code", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            inputPass.ForeColor = Color.White;
            inputPass.Location = new Point(55, 332);
            inputPass.Name = "inputPass";
            inputPass.PasswordChar = '●';
            inputPass.Size = new Size(346, 23);
            inputPass.TabIndex = 9;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.padlock;
            pictureBox4.Location = new Point(55, 287);
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
            label6.Location = new Point(45, 343);
            label6.Name = "label6";
            label6.Size = new Size(370, 21);
            label6.TabIndex = 10;
            label6.Text = "..........................................................................................";
            // 
            // pictureBox5
            // 
            pictureBox5.Cursor = Cursors.Hand;
            pictureBox5.Image = Properties.Resources.view;
            pictureBox5.Location = new Point(406, 317);
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
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Cascadia Code", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(125, 493);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(240, 75);
            btnLogin.TabIndex = 14;
            btnLogin.Text = "Xác nhận";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += button1_Click;
            // 
            // pictureBox6
            // 
            pictureBox6.Cursor = Cursors.Hand;
            pictureBox6.Image = Properties.Resources.view;
            pictureBox6.Location = new Point(405, 400);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(34, 37);
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
            inputConfirm.Location = new Point(54, 415);
            inputConfirm.Name = "inputConfirm";
            inputConfirm.PasswordChar = '●';
            inputConfirm.Size = new Size(346, 23);
            inputConfirm.TabIndex = 17;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(44, 426);
            label7.Name = "label7";
            label7.Size = new Size(370, 21);
            label7.TabIndex = 18;
            label7.Text = "..........................................................................................";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Cascadia Code", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
            label8.Location = new Point(92, 382);
            label8.Name = "label8";
            label8.Size = new Size(144, 25);
            label8.TabIndex = 16;
            label8.Text = "Xác nhận lại";
            // 
            // pictureBox7
            // 
            pictureBox7.Image = Properties.Resources.padlock;
            pictureBox7.Location = new Point(54, 370);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(34, 37);
            pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox7.TabIndex = 19;
            pictureBox7.TabStop = false;
            // 
            // CreateNewPass
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SkyBlue;
            ClientSize = new Size(484, 661);
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
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CreateNewPass";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += Login_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private Label label4;
        private Label label3;
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
    }
}