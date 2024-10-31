namespace ql_diemrenluyen.GUI
{
    partial class ResetPass
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
            pictureBox3 = new PictureBox();
            btnLogin = new Button();
            pictureBox4 = new PictureBox();
            label3 = new Label();
            label5 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label6 = new Label();
            pictureBox5 = new PictureBox();
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
            pictureBox2.Location = new Point(125, 23);
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
            inputUser.Enabled = false;
            inputUser.Font = new Font("Cascadia Code", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            inputUser.ForeColor = Color.White;
            inputUser.Location = new Point(55, 274);
            inputUser.Name = "inputUser";
            inputUser.Size = new Size(368, 23);
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
            label1.Location = new Point(38, 284);
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
            label2.Location = new Point(92, 238);
            label2.Name = "label2";
            label2.Size = new Size(67, 25);
            label2.TabIndex = 4;
            label2.Text = "Email";
            label2.Click += label2_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Cascadia Code", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(81, 167);
            label4.Name = "label4";
            label4.Size = new Size(314, 46);
            label4.TabIndex = 6;
            label4.Text = "RESET MẬT KHẨU";
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.user;
            pictureBox3.Location = new Point(54, 226);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(34, 37);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 8;
            pictureBox3.TabStop = false;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = SystemColors.Highlight;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Cascadia Code", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(117, 505);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(240, 75);
            btnLogin.TabIndex = 14;
            btnLogin.Text = "Xác nhận";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += button1_Click;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.user;
            pictureBox4.Location = new Point(54, 320);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(34, 37);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 18;
            pictureBox4.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Cascadia Code", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(92, 332);
            label3.Name = "label3";
            label3.Size = new Size(78, 25);
            label3.TabIndex = 17;
            label3.Text = "Mã OTP";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(54, 378);
            label5.Name = "label5";
            label5.Size = new Size(0, 21);
            label5.TabIndex = 16;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Location = new Point(73, 378);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(308, 51);
            flowLayoutPanel1.TabIndex = 19;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Cascadia Code", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(302, 454);
            label6.Name = "label6";
            label6.Size = new Size(122, 25);
            label6.TabIndex = 17;
            label6.Text = "Gửi lại mã";
            label6.Click += label6_Click;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = Properties.Resources.refresh_icon_removebg_preview;
            pictureBox5.Location = new Point(267, 449);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(34, 37);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 18;
            pictureBox5.TabStop = false;
            // 
            // ResetPass
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SkyBlue;
            ClientSize = new Size(484, 661);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(pictureBox5);
            Controls.Add(pictureBox4);
            Controls.Add(label6);
            Controls.Add(label3);
            Controls.Add(label5);
            Controls.Add(btnLogin);
            Controls.Add(inputUser);
            Controls.Add(pictureBox3);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ResetPass";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += ResetPass_Load;
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
        private PictureBox pictureBox3;
        private Button btnLogin;
        private PictureBox pictureBox4;
        private Label label3;
        private Label label5;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label6;
        private PictureBox pictureBox5;
    }
}