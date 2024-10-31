namespace QLDiemRenLuyen
{
    partial class QLSinhVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QLSinhVien));
            label1 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            label2 = new Label();
            button2 = new Button();
            btnSearch = new Button();
            textBox1 = new TextBox();
            dataGridStudent = new DataGridView();
            maSV = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            gioiTinh = new DataGridViewTextBoxColumn();
            lop = new DataGridViewTextBoxColumn();
            khoa = new DataGridViewTextBoxColumn();
            btnXemTT = new DataGridViewButtonColumn();
            btnXemDiem = new DataGridViewButtonColumn();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridStudent).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.MenuHighlight;
            label1.Font = new Font("Segoe UI Black", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(0, 12);
            label1.Name = "label1";
            label1.Size = new Size(331, 50);
            label1.TabIndex = 0;
            label1.Text = "Quản lý sinh viên";
            label1.Click += label1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLightLight;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(btnSearch);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(dataGridStudent);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1079, 599);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.MenuHighlight;
            panel2.Controls.Add(label1);
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1099, 71);
            panel2.TabIndex = 6;
            panel2.Paint += panel2_Paint;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(73, 91);
            label2.Name = "label2";
            label2.Size = new Size(288, 41);
            label2.TabIndex = 5;
            label2.Text = "Danh sách sinh viên";
            label2.Click += label2_Click;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ButtonFace;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.Location = new Point(837, 91);
            button2.Name = "button2";
            button2.Size = new Size(90, 51);
            button2.TabIndex = 4;
            button2.UseVisualStyleBackColor = false;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = SystemColors.ButtonFace;
            btnSearch.Image = (Image)resources.GetObject("btnSearch.Image");
            btnSearch.Location = new Point(781, 91);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(51, 51);
            btnSearch.TabIndex = 3;
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.ButtonFace;
            textBox1.Font = new Font("Segoe UI", 18F);
            textBox1.Location = new Point(451, 91);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(380, 47);
            textBox1.TabIndex = 2;
            textBox1.Text = "\r\n";
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // dataGridStudent
            // 
            dataGridStudent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridStudent.Columns.AddRange(new DataGridViewColumn[] { maSV, Column1, gioiTinh, lop, khoa, btnXemTT, btnXemDiem });
            dataGridStudent.Location = new Point(16, 147);
            dataGridStudent.MultiSelect = false;
            dataGridStudent.Name = "dataGridStudent";
            dataGridStudent.ReadOnly = true;
            dataGridStudent.RowHeadersWidth = 51;
            dataGridStudent.Size = new Size(1066, 493);
            dataGridStudent.TabIndex = 0;
            dataGridStudent.CellContentClick += dataGridView1_CellContentClick;
            // 
            // maSV
            // 
            maSV.HeaderText = "Mã sinh viên";
            maSV.MinimumWidth = 6;
            maSV.Name = "maSV";
            maSV.ReadOnly = true;
            maSV.Width = 125;
            // 
            // Column1
            // 
            Column1.HeaderText = "Họ và Tên";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Width = 125;
            // 
            // gioiTinh
            // 
            gioiTinh.HeaderText = "Giới tính ";
            gioiTinh.MinimumWidth = 6;
            gioiTinh.Name = "gioiTinh";
            gioiTinh.ReadOnly = true;
            gioiTinh.Width = 125;
            // 
            // lop
            // 
            lop.HeaderText = "Lớp";
            lop.MinimumWidth = 6;
            lop.Name = "lop";
            lop.ReadOnly = true;
            lop.Width = 125;
            // 
            // khoa
            // 
            khoa.HeaderText = "Khoa";
            khoa.MinimumWidth = 6;
            khoa.Name = "khoa";
            khoa.ReadOnly = true;
            khoa.Width = 125;
            // 
            // btnXemTT
            // 
            btnXemTT.HeaderText = "Xem Thông tin";
            btnXemTT.MinimumWidth = 6;
            btnXemTT.Name = "btnXemTT";
            btnXemTT.ReadOnly = true;
            btnXemTT.Text = "Xem";
            btnXemTT.UseColumnTextForButtonValue = true;
            btnXemTT.Width = 125;
            // 
            // btnXemDiem
            // 
            btnXemDiem.HeaderText = "Xem / Sửa điểm";
            btnXemDiem.MinimumWidth = 6;
            btnXemDiem.Name = "btnXemDiem";
            btnXemDiem.ReadOnly = true;
            btnXemDiem.Text = "Xem";
            btnXemDiem.UseColumnTextForButtonValue = true;
            btnXemDiem.Width = 125;
            // 
            // QLSinhVien
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1079, 599);
            Controls.Add(panel1);
            Name = "QLSinhVien";
            Load += QLSinhVien_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridStudent).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private TextBox textBox1;
        private Button btnSearch;
        private Button button2;
        private Label label2;
        private Panel panel2;
        private DataGridView dataGridStudent;
        private DataGridViewTextBoxColumn maSV;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn gioiTinh;
        private DataGridViewTextBoxColumn lop;
        private DataGridViewTextBoxColumn khoa;
        private DataGridViewButtonColumn btnXemTT;
        private DataGridViewButtonColumn btnXemDiem;
    }
}
