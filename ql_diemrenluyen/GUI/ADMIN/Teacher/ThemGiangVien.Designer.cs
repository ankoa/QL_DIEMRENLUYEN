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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label(); // Thêm label cho chức vụ
            this.txtMaGV = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.cBGioiTinh = new System.Windows.Forms.ComboBox();
            this.cBKhoa = new System.Windows.Forms.ComboBox();
            this.cBChucVu = new System.Windows.Forms.ComboBox(); // Thêm ComboBox cho chức vụ
            this.btnThem = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Giảng Viên:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Họ Tên:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Giới Tính:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Email:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 230);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Khoa:";
            // 
            // label6 // Thêm label cho chức vụ
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 280);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Chức Vụ:";
            // 
            // txtMaGV
            // 
            this.txtMaGV.Location = new System.Drawing.Point(140, 30);
            this.txtMaGV.Name = "txtMaGV";
            this.txtMaGV.Size = new System.Drawing.Size(200, 27);
            this.txtMaGV.TabIndex = 5;
            this.txtMaGV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaGV_KeyPress);
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(140, 80);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(200, 27);
            this.txtHoTen.TabIndex = 6;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(140, 180);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 27);
            this.txtEmail.TabIndex = 7;
            // 
            // cBGioiTinh
            // 
            this.cBGioiTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBGioiTinh.FormattingEnabled = true;
            this.cBGioiTinh.Location = new System.Drawing.Point(140, 130);
            this.cBGioiTinh.Name = "cBGioiTinh";
            this.cBGioiTinh.Size = new System.Drawing.Size(200, 28);
            this.cBGioiTinh.TabIndex = 8;
            // 
            // cBKhoa
            // 
            this.cBKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBKhoa.FormattingEnabled = true;
            this.cBKhoa.Location = new System.Drawing.Point(140, 230);
            this.cBKhoa.Name = "cBKhoa";
            this.cBKhoa.Size = new System.Drawing.Size(200, 28);
            this.cBKhoa.TabIndex = 9;
            // 
            // cBChucVu
            // 
            this.cBChucVu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBChucVu.FormattingEnabled = true;
            this.cBChucVu.Location = new System.Drawing.Point(140, 280);
            this.cBChucVu.Name = "cBChucVu";
            this.cBChucVu.Size = new System.Drawing.Size(200, 28);
            this.cBChucVu.TabIndex = 10;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(140, 320);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 30);
            this.btnThem.TabIndex = 11;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(250, 320);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(100, 30);
            this.btnHuy.TabIndex = 12;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler((sender, e) => this.Dispose());
            // 
            // ThemGiangVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 370);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.cBChucVu); // Thêm ComboBox chức vụ vào form
            this.Controls.Add(this.cBKhoa);
            this.Controls.Add(this.cBGioiTinh);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.txtMaGV);
            this.Controls.Add(this.label6); // Thêm label chức vụ
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ThemGiangVien";
            this.Text = "Thông Tin Giảng Viên";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6; // Label cho chức vụ
        private System.Windows.Forms.TextBox txtMaGV;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.ComboBox cBGioiTinh;
        private System.Windows.Forms.ComboBox cBKhoa;
        private System.Windows.Forms.ComboBox cBChucVu; 
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnHuy;
    }
}
