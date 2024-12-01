namespace QLDiemRenLuyen
{
    partial class ThemGiangVien
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
            label2 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtHoTen = new TextBox();
            txtEmail = new TextBox();
            cBKhoa = new ComboBox();
            btnThem = new Button();
            btnHuy = new Button();
            clbLopcovan = new CheckedListBox();
            cbGioiTinh = new ComboBox();
            label3 = new Label();
            label7 = new Label();
            dtpNgaySinh = new DateTimePicker();
            label1 = new Label();
            cbTrangthai = new ComboBox();
            label8 = new Label();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 80);
            label2.Name = "label2";
            label2.Size = new Size(59, 20);
            label2.TabIndex = 1;
            label2.Text = "Họ Tên:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 130);
            label4.Name = "label4";
            label4.Size = new Size(49, 20);
            label4.TabIndex = 3;
            label4.Text = "Email:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(30, 180);
            label5.Name = "label5";
            label5.Size = new Size(46, 20);
            label5.TabIndex = 4;
            label5.Text = "Khoa:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(30, 330);
            label6.Name = "label6";
            label6.Size = new Size(81, 20);
            label6.TabIndex = 5;
            label6.Text = "Lớp cố vấn";
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(140, 80);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(200, 27);
            txtHoTen.TabIndex = 6;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(140, 130);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(200, 27);
            txtEmail.TabIndex = 7;
            // 
            // cBKhoa
            // 
            cBKhoa.DropDownStyle = ComboBoxStyle.DropDownList;
            cBKhoa.FormattingEnabled = true;
            cBKhoa.Location = new Point(140, 180);
            cBKhoa.Name = "cBKhoa";
            cBKhoa.Size = new Size(200, 28);
            cBKhoa.TabIndex = 9;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(40, 506);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(100, 30);
            btnThem.TabIndex = 11;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnHuy
            // 
            btnHuy.Location = new Point(255, 506);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(100, 30);
            btnHuy.TabIndex = 12;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = true;
            btnHuy.Click += btnHuy_Click;
            // 
            // clbLopcovan
            // 
            clbLopcovan.FormattingEnabled = true;
            clbLopcovan.Location = new Point(140, 330);
            clbLopcovan.Name = "clbLopcovan";
            clbLopcovan.ScrollAlwaysVisible = true;
            clbLopcovan.Size = new Size(200, 114);
            clbLopcovan.TabIndex = 13;
            // 
            // cbGioiTinh
            // 
            cbGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGioiTinh.FormattingEnabled = true;
            cbGioiTinh.Location = new Point(140, 230);
            cbGioiTinh.Name = "cbGioiTinh";
            cbGioiTinh.Size = new Size(78, 28);
            cbGioiTinh.TabIndex = 15;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 230);
            label3.Name = "label3";
            label3.Size = new Size(68, 20);
            label3.TabIndex = 14;
            label3.Text = "Giới tính:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(30, 280);
            label7.Name = "label7";
            label7.Size = new Size(77, 20);
            label7.TabIndex = 16;
            label7.Text = "Ngày sinh:";
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.Location = new Point(135, 280);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(250, 27);
            dtpNgaySinh.TabIndex = 17;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(106, 20);
            label1.Name = "label1";
            label1.Size = new Size(174, 28);
            label1.TabIndex = 18;
            label1.Text = "Thêm Giảng Viên";
            // 
            // cbTrangthai
            // 
            cbTrangthai.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTrangthai.FormattingEnabled = true;
            cbTrangthai.Items.AddRange(new object[] { "Hoạt động", "Không hoạt động" });
            cbTrangthai.Location = new Point(140, 460);
            cbTrangthai.Name = "cbTrangthai";
            cbTrangthai.Size = new Size(159, 28);
            cbTrangthai.TabIndex = 20;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(30, 460);
            label8.Name = "label8";
            label8.Size = new Size(75, 20);
            label8.TabIndex = 19;
            label8.Text = "Trạng thái";
            // 
            // ThemGiangVien
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(397, 593);
            Controls.Add(cbTrangthai);
            Controls.Add(label8);
            Controls.Add(label1);
            Controls.Add(dtpNgaySinh);
            Controls.Add(label7);
            Controls.Add(cbGioiTinh);
            Controls.Add(label3);
            Controls.Add(clbLopcovan);
            Controls.Add(btnHuy);
            Controls.Add(btnThem);
            Controls.Add(cBKhoa);
            Controls.Add(txtEmail);
            Controls.Add(txtHoTen);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ThemGiangVien";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thông Tin Giảng Viên";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6; // Label cho chức vụ
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.ComboBox cBGioiTinh;
        private System.Windows.Forms.ComboBox cBKhoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnHuy;
        private CheckedListBox clbLopcovan;
        private ComboBox cbGioiTinh;
        private Label label7;
        private DateTimePicker dtpNgaySinh;
        private Label label1;
        private ComboBox cbTrangthai;
        private Label label8;
    }
}
