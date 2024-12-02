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
            label2.Location = new Point(26, 60);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 1;
            label2.Text = "Họ Tên:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(26, 98);
            label4.Name = "label4";
            label4.Size = new Size(39, 15);
            label4.TabIndex = 3;
            label4.Text = "Email:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(26, 135);
            label5.Name = "label5";
            label5.Size = new Size(37, 15);
            label5.TabIndex = 4;
            label5.Text = "Khoa:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(26, 248);
            label6.Name = "label6";
            label6.Size = new Size(65, 15);
            label6.TabIndex = 5;
            label6.Text = "Lớp cố vấn";
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(122, 60);
            txtHoTen.Margin = new Padding(3, 2, 3, 2);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(176, 23);
            txtHoTen.TabIndex = 6;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(122, 98);
            txtEmail.Margin = new Padding(3, 2, 3, 2);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(176, 23);
            txtEmail.TabIndex = 7;
            // 
            // cBKhoa
            // 
            cBKhoa.DropDownStyle = ComboBoxStyle.DropDownList;
            cBKhoa.FormattingEnabled = true;
            cBKhoa.Location = new Point(122, 135);
            cBKhoa.Margin = new Padding(3, 2, 3, 2);
            cBKhoa.Name = "cBKhoa";
            cBKhoa.Size = new Size(176, 23);
            cBKhoa.TabIndex = 9;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(35, 380);
            btnThem.Margin = new Padding(3, 2, 3, 2);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(88, 22);
            btnThem.TabIndex = 11;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnHuy
            // 
            btnHuy.Location = new Point(223, 380);
            btnHuy.Margin = new Padding(3, 2, 3, 2);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(88, 22);
            btnHuy.TabIndex = 12;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = true;
            btnHuy.Click += btnHuy_Click;
            // 
            // clbLopcovan
            // 
            clbLopcovan.FormattingEnabled = true;
            clbLopcovan.Location = new Point(122, 248);
            clbLopcovan.Margin = new Padding(3, 2, 3, 2);
            clbLopcovan.Name = "clbLopcovan";
            clbLopcovan.ScrollAlwaysVisible = true;
            clbLopcovan.Size = new Size(176, 76);
            clbLopcovan.TabIndex = 13;
            // 
            // cbGioiTinh
            // 
            cbGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGioiTinh.FormattingEnabled = true;
            cbGioiTinh.Location = new Point(122, 172);
            cbGioiTinh.Margin = new Padding(3, 2, 3, 2);
            cbGioiTinh.Name = "cbGioiTinh";
            cbGioiTinh.Size = new Size(69, 23);
            cbGioiTinh.TabIndex = 15;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 172);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 14;
            label3.Text = "Giới tính:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(26, 210);
            label7.Name = "label7";
            label7.Size = new Size(63, 15);
            label7.TabIndex = 16;
            label7.Text = "Ngày sinh:";
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.Location = new Point(118, 210);
            dtpNgaySinh.Margin = new Padding(3, 2, 3, 2);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(180, 23);
            dtpNgaySinh.TabIndex = 17;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(108, 9);
            label1.Name = "label1";
            label1.Size = new Size(141, 21);
            label1.TabIndex = 18;
            label1.Text = "Thêm Giảng Viên";
            // 
            // cbTrangthai
            // 
            cbTrangthai.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTrangthai.FormattingEnabled = true;
            cbTrangthai.Items.AddRange(new object[] { "Hoạt động", "Không hoạt động" });
            cbTrangthai.Location = new Point(122, 345);
            cbTrangthai.Margin = new Padding(3, 2, 3, 2);
            cbTrangthai.Name = "cbTrangthai";
            cbTrangthai.Size = new Size(140, 23);
            cbTrangthai.TabIndex = 20;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(26, 345);
            label8.Name = "label8";
            label8.Size = new Size(59, 15);
            label8.TabIndex = 19;
            label8.Text = "Trạng thái";
            // 
            // ThemGiangVien
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(347, 445);
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
            Margin = new Padding(3, 2, 3, 2);
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
