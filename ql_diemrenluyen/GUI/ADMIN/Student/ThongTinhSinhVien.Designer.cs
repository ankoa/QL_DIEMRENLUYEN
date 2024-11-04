namespace QLDiemRenLuyen
{
    partial class ThongTinhSinhVien
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            panel10 = new Panel();
            txtEmail = new TextBox();
            label9 = new Label();
            panel9 = new Panel();
            txtKhoa = new TextBox();
            label8 = new Label();
            panel8 = new Panel();
            cBLop = new ComboBox();
            label7 = new Label();
            panel7 = new Panel();
            txtChucVu = new TextBox();
            label6 = new Label();
            panel6 = new Panel();
            cBGioiTinh = new ComboBox();
            label5 = new Label();
            panel5 = new Panel();
            dPNgaySinh = new DateTimePicker();
            label4 = new Label();
            panel4 = new Panel();
            txtHoTen = new TextBox();
            label3 = new Label();
            panel3 = new Panel();
            txtMaSV = new TextBox();
            label2 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel10.SuspendLayout();
            panel9.SuspendLayout();
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
            panel1.BackColor = SystemColors.MenuHighlight;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1099, 83);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(363, 15);
            label1.Name = "label1";
            label1.Size = new Size(327, 46);
            label1.TabIndex = 0;
            label1.Text = "Thông tin sinh viên";
            label1.Click += label1_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel10);
            panel2.Controls.Add(panel9);
            panel2.Controls.Add(panel8);
            panel2.Controls.Add(panel7);
            panel2.Controls.Add(panel6);
            panel2.Controls.Add(panel5);
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(panel3);
            panel2.Location = new Point(0, 83);
            panel2.Name = "panel2";
            panel2.Size = new Size(1095, 424);
            panel2.TabIndex = 1;
            panel2.Paint += panel2_Paint;
            // 
            // panel10
            // 
            panel10.Controls.Add(txtEmail);
            panel10.Controls.Add(label9);
            panel10.Location = new Point(555, 4);
            panel10.Name = "panel10";
            panel10.Size = new Size(544, 53);
            panel10.TabIndex = 5;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(169, 11);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(369, 27);
            txtEmail.TabIndex = 1;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(-2, 9);
            label9.Name = "label9";
            label9.Size = new Size(60, 28);
            label9.TabIndex = 0;
            label9.Text = "Email";
            // 
            // panel9
            // 
            panel9.Controls.Add(txtKhoa);
            panel9.Controls.Add(label8);
            panel9.Location = new Point(555, 181);
            panel9.Name = "panel9";
            panel9.Size = new Size(544, 53);
            panel9.TabIndex = 4;
            // 
            // txtKhoa
            // 
            txtKhoa.Location = new Point(168, 9);
            txtKhoa.Name = "txtKhoa";
            txtKhoa.ReadOnly = true;
            txtKhoa.Size = new Size(369, 27);
            txtKhoa.TabIndex = 2;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(-2, 9);
            label8.Name = "label8";
            label8.Size = new Size(58, 28);
            label8.TabIndex = 0;
            label8.Text = "Khoa";
            // 
            // panel8
            // 
            panel8.Controls.Add(cBLop);
            panel8.Controls.Add(label7);
            panel8.Location = new Point(555, 123);
            panel8.Name = "panel8";
            panel8.Size = new Size(544, 53);
            panel8.TabIndex = 4;
            // 
            // cBLop
            // 
            cBLop.DisplayMember = "Nam";
            cBLop.FormattingEnabled = true;
            cBLop.Location = new Point(169, 9);
            cBLop.Name = "cBLop";
            cBLop.Size = new Size(368, 28);
            cBLop.TabIndex = 7;
            cBLop.SelectedIndexChanged += cBLop_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(-2, 9);
            label7.Name = "label7";
            label7.Size = new Size(46, 28);
            label7.TabIndex = 0;
            label7.Text = "Lớp";
            // 
            // panel7
            // 
            panel7.Controls.Add(txtChucVu);
            panel7.Controls.Add(label6);
            panel7.Location = new Point(555, 63);
            panel7.Name = "panel7";
            panel7.Size = new Size(544, 53);
            panel7.TabIndex = 4;
            // 
            // txtChucVu
            // 
            txtChucVu.Location = new Point(169, 11);
            txtChucVu.Name = "txtChucVu";
            txtChucVu.Size = new Size(369, 27);
            txtChucVu.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(-2, 9);
            label6.Name = "label6";
            label6.Size = new Size(85, 28);
            label6.TabIndex = 0;
            label6.Text = "Chức vụ";
            // 
            // panel6
            // 
            panel6.Controls.Add(cBGioiTinh);
            panel6.Controls.Add(label5);
            panel6.Location = new Point(3, 181);
            panel6.Name = "panel6";
            panel6.Size = new Size(544, 53);
            panel6.TabIndex = 4;
            // 
            // cBGioiTinh
            // 
            cBGioiTinh.DisplayMember = "Nam";
            cBGioiTinh.FormattingEnabled = true;
            cBGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ" });
            cBGioiTinh.Location = new Point(169, 10);
            cBGioiTinh.Name = "cBGioiTinh";
            cBGioiTinh.Size = new Size(368, 28);
            cBGioiTinh.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(-2, 9);
            label5.Name = "label5";
            label5.Size = new Size(90, 28);
            label5.TabIndex = 0;
            label5.Text = "Giới tính";
            // 
            // panel5
            // 
            panel5.Controls.Add(dPNgaySinh);
            panel5.Controls.Add(label4);
            panel5.Location = new Point(3, 123);
            panel5.Name = "panel5";
            panel5.Size = new Size(544, 53);
            panel5.TabIndex = 3;
            // 
            // dPNgaySinh
            // 
            dPNgaySinh.Location = new Point(168, 10);
            dPNgaySinh.Name = "dPNgaySinh";
            dPNgaySinh.Size = new Size(369, 27);
            dPNgaySinh.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(-2, 9);
            label4.Name = "label4";
            label4.Size = new Size(103, 28);
            label4.TabIndex = 0;
            label4.Text = "Ngày sinh";
            // 
            // panel4
            // 
            panel4.Controls.Add(txtHoTen);
            panel4.Controls.Add(label3);
            panel4.Location = new Point(3, 63);
            panel4.Name = "panel4";
            panel4.Size = new Size(544, 53);
            panel4.TabIndex = 2;
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(169, 11);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(369, 27);
            txtHoTen.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(-2, 9);
            label3.Name = "label3";
            label3.Size = new Size(101, 28);
            label3.TabIndex = 0;
            label3.Text = "Họ và tên";
            // 
            // panel3
            // 
            panel3.Controls.Add(txtMaSV);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(2, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(544, 53);
            panel3.TabIndex = 0;
            // 
            // txtMaSV
            // 
            txtMaSV.Location = new Point(169, 11);
            txtMaSV.Name = "txtMaSV";
            txtMaSV.ReadOnly = true;
            txtMaSV.Size = new Size(369, 27);
            txtMaSV.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(-2, 9);
            label2.Name = "label2";
            label2.Size = new Size(128, 28);
            label2.TabIndex = 0;
            label2.Text = "Mã sinh viên";
            // 
            // ThongTinhSinhVien
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1083, 523);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "ThongTinhSinhVien";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
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
        private Label label1;
        private Panel panel2;
        private Panel panel3;
        private Label label2;
        private Panel panel4;
        private TextBox txtHoTen;
        private Label label3;
        private TextBox txtMaSV;
        private Panel panel9;
        private Label label8;
        private Panel panel8;
        private Label label7;
        private Panel panel7;
        private TextBox txtChucVu;
        private Label label6;
        private Panel panel6;
        private Label label5;
        private Panel panel5;
        private TextBox txtNgaySinh;
        private Label label4;
        private Panel panel10;
        private TextBox txtEmail;
        private Label label9;
        private DateTimePicker dPNgaySinh;
        private ComboBox cBGioiTinh;
        private ComboBox cBLop;
        private TextBox txtKhoa;
    }
}
