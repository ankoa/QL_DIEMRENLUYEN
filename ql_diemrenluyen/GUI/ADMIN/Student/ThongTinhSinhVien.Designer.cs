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
            btnThem = new Button();
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
            cbChucVu = new ComboBox();
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
            tableLayoutPanel1 = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            flowLayoutPanel3 = new FlowLayoutPanel();
            flowLayoutPanel4 = new FlowLayoutPanel();
            panel1.SuspendLayout();
            panel10.SuspendLayout();
            panel9.SuspendLayout();
            panel8.SuspendLayout();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            flowLayoutPanel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.MenuHighlight;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 2);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(969, 87);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.ImeMode = ImeMode.NoControl;
            label1.Location = new Point(366, 26);
            label1.Name = "label1";
            label1.Size = new Size(261, 37);
            label1.TabIndex = 0;
            label1.Text = "Thông tin sinh viên";
            label1.Click += label1_Click;
            // 
            // btnThem
            // 
            btnThem.Anchor = AnchorStyles.None;
            btnThem.BackColor = SystemColors.MenuHighlight;
            btnThem.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnThem.ForeColor = SystemColors.ControlLightLight;
            btnThem.ImeMode = ImeMode.NoControl;
            btnThem.Location = new Point(388, 341);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(198, 43);
            btnThem.TabIndex = 6;
            btnThem.Text = "Thêm ";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // panel10
            // 
            panel10.Controls.Add(txtEmail);
            panel10.Controls.Add(label9);
            panel10.Location = new Point(3, 2);
            panel10.Margin = new Padding(3, 2, 3, 2);
            panel10.Name = "panel10";
            panel10.Size = new Size(476, 40);
            panel10.TabIndex = 5;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(148, 8);
            txtEmail.Margin = new Padding(3, 2, 3, 2);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(323, 23);
            txtEmail.TabIndex = 1;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label9.ImeMode = ImeMode.NoControl;
            label9.Location = new Point(-2, 7);
            label9.Name = "label9";
            label9.Size = new Size(48, 21);
            label9.TabIndex = 0;
            label9.Text = "Email";
            // 
            // panel9
            // 
            panel9.Controls.Add(txtKhoa);
            panel9.Controls.Add(label8);
            panel9.Location = new Point(485, 2);
            panel9.Margin = new Padding(3, 2, 3, 2);
            panel9.Name = "panel9";
            panel9.Size = new Size(476, 40);
            panel9.TabIndex = 4;
            // 
            // txtKhoa
            // 
            txtKhoa.Location = new Point(147, 7);
            txtKhoa.Margin = new Padding(3, 2, 3, 2);
            txtKhoa.Name = "txtKhoa";
            txtKhoa.ReadOnly = true;
            txtKhoa.Size = new Size(323, 23);
            txtKhoa.TabIndex = 2;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label8.ImeMode = ImeMode.NoControl;
            label8.Location = new Point(-2, 7);
            label8.Name = "label8";
            label8.Size = new Size(47, 21);
            label8.TabIndex = 0;
            label8.Text = "Khoa";
            // 
            // panel8
            // 
            panel8.Controls.Add(cBLop);
            panel8.Controls.Add(label7);
            panel8.Location = new Point(3, 2);
            panel8.Margin = new Padding(3, 2, 3, 2);
            panel8.Name = "panel8";
            panel8.Size = new Size(476, 40);
            panel8.TabIndex = 4;
            // 
            // cBLop
            // 
            cBLop.DisplayMember = "Nam";
            cBLop.FormattingEnabled = true;
            cBLop.Location = new Point(148, 7);
            cBLop.Margin = new Padding(3, 2, 3, 2);
            cBLop.Name = "cBLop";
            cBLop.Size = new Size(322, 23);
            cBLop.TabIndex = 7;
            cBLop.SelectedIndexChanged += cBLop_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label7.ImeMode = ImeMode.NoControl;
            label7.Location = new Point(-2, 7);
            label7.Name = "label7";
            label7.Size = new Size(38, 21);
            label7.TabIndex = 0;
            label7.Text = "Lớp";
            // 
            // panel7
            // 
            panel7.Controls.Add(cbChucVu);
            panel7.Controls.Add(label6);
            panel7.Location = new Point(485, 2);
            panel7.Margin = new Padding(3, 2, 3, 2);
            panel7.Name = "panel7";
            panel7.Size = new Size(476, 40);
            panel7.TabIndex = 4;
            // 
            // cbChucVu
            // 
            cbChucVu.DisplayMember = "Nam";
            cbChucVu.FormattingEnabled = true;
            cbChucVu.Location = new Point(147, 9);
            cbChucVu.Margin = new Padding(3, 2, 3, 2);
            cbChucVu.Name = "cbChucVu";
            cbChucVu.Size = new Size(322, 23);
            cbChucVu.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label6.ImeMode = ImeMode.NoControl;
            label6.Location = new Point(-2, 7);
            label6.Name = "label6";
            label6.Size = new Size(68, 21);
            label6.TabIndex = 0;
            label6.Text = "Chức vụ";
            // 
            // panel6
            // 
            panel6.Controls.Add(cBGioiTinh);
            panel6.Controls.Add(label5);
            panel6.Location = new Point(485, 2);
            panel6.Margin = new Padding(3, 2, 3, 2);
            panel6.Name = "panel6";
            panel6.Size = new Size(476, 40);
            panel6.TabIndex = 4;
            // 
            // cBGioiTinh
            // 
            cBGioiTinh.DisplayMember = "Nam";
            cBGioiTinh.FormattingEnabled = true;
            cBGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ" });
            cBGioiTinh.Location = new Point(148, 8);
            cBGioiTinh.Margin = new Padding(3, 2, 3, 2);
            cBGioiTinh.Name = "cBGioiTinh";
            cBGioiTinh.Size = new Size(322, 23);
            cBGioiTinh.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label5.ImeMode = ImeMode.NoControl;
            label5.Location = new Point(-2, 7);
            label5.Name = "label5";
            label5.Size = new Size(71, 21);
            label5.TabIndex = 0;
            label5.Text = "Giới tính";
            // 
            // panel5
            // 
            panel5.Controls.Add(dPNgaySinh);
            panel5.Controls.Add(label4);
            panel5.Location = new Point(3, 2);
            panel5.Margin = new Padding(3, 2, 3, 2);
            panel5.Name = "panel5";
            panel5.Size = new Size(476, 40);
            panel5.TabIndex = 3;
            // 
            // dPNgaySinh
            // 
            dPNgaySinh.Location = new Point(147, 8);
            dPNgaySinh.Margin = new Padding(3, 2, 3, 2);
            dPNgaySinh.Name = "dPNgaySinh";
            dPNgaySinh.Size = new Size(323, 23);
            dPNgaySinh.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label4.ImeMode = ImeMode.NoControl;
            label4.Location = new Point(-2, 7);
            label4.Name = "label4";
            label4.Size = new Size(81, 21);
            label4.TabIndex = 0;
            label4.Text = "Ngày sinh";
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel4.Controls.Add(txtHoTen);
            panel4.Controls.Add(label3);
            panel4.Location = new Point(485, 2);
            panel4.Margin = new Padding(3, 2, 3, 2);
            panel4.Name = "panel4";
            panel4.Size = new Size(476, 40);
            panel4.TabIndex = 2;
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(148, 8);
            txtHoTen.Margin = new Padding(3, 2, 3, 2);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(323, 23);
            txtHoTen.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.ImeMode = ImeMode.NoControl;
            label3.Location = new Point(-2, 7);
            label3.Name = "label3";
            label3.Size = new Size(80, 21);
            label3.TabIndex = 0;
            label3.Text = "Họ và tên";
            // 
            // panel3
            // 
            panel3.Controls.Add(txtMaSV);
            panel3.Controls.Add(label2);
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(3, 2);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(476, 40);
            panel3.TabIndex = 0;
            // 
            // txtMaSV
            // 
            txtMaSV.Location = new Point(148, 8);
            txtMaSV.Margin = new Padding(3, 2, 3, 2);
            txtMaSV.Name = "txtMaSV";
            txtMaSV.ReadOnly = true;
            txtMaSV.Size = new Size(323, 23);
            txtMaSV.TabIndex = 1;
            txtMaSV.KeyPress += txtMaSV_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.ImeMode = ImeMode.NoControl;
            label2.Location = new Point(-2, 7);
            label2.Name = "label2";
            label2.Size = new Size(100, 21);
            label2.TabIndex = 0;
            label2.Text = "Mã sinh viên";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(btnThem, 0, 5);
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 1);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel2, 0, 2);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel3, 0, 3);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel4, 0, 4);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tableLayoutPanel1.Size = new Size(975, 455);
            tableLayoutPanel1.TabIndex = 2;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.Controls.Add(panel3);
            flowLayoutPanel1.Controls.Add(panel4);
            flowLayoutPanel1.Location = new Point(3, 93);
            flowLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(969, 40);
            flowLayoutPanel1.TabIndex = 7;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(panel5);
            flowLayoutPanel2.Controls.Add(panel6);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.Location = new Point(3, 138);
            flowLayoutPanel2.Margin = new Padding(3, 2, 3, 2);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(969, 41);
            flowLayoutPanel2.TabIndex = 8;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Controls.Add(panel10);
            flowLayoutPanel3.Controls.Add(panel7);
            flowLayoutPanel3.Dock = DockStyle.Fill;
            flowLayoutPanel3.Location = new Point(3, 183);
            flowLayoutPanel3.Margin = new Padding(3, 2, 3, 2);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(969, 41);
            flowLayoutPanel3.TabIndex = 9;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.Controls.Add(panel8);
            flowLayoutPanel4.Controls.Add(panel9);
            flowLayoutPanel4.Dock = DockStyle.Fill;
            flowLayoutPanel4.Location = new Point(3, 228);
            flowLayoutPanel4.Margin = new Padding(3, 2, 3, 2);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new Size(969, 41);
            flowLayoutPanel4.TabIndex = 10;
            // 
            // ThongTinhSinhVien
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(975, 455);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "ThongTinhSinhVien";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hi";
            Load += ThongTinhSinhVien_Load;
            panel1.ResumeLayout(false);
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
            tableLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
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
        private ComboBox cbChucVu;
        private Button btnThem;
        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
        private FlowLayoutPanel flowLayoutPanel3;
        private FlowLayoutPanel flowLayoutPanel4;
    }
}
