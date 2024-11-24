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
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel2 = new Panel();
            label1 = new Label();
            dataGridStudent = new DataGridView();
            maSV = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            gioiTinh = new DataGridViewTextBoxColumn();
            lop = new DataGridViewTextBoxColumn();
            khoa = new DataGridViewTextBoxColumn();
            btnXemTT = new DataGridViewButtonColumn();
            btnXoa = new DataGridViewButtonColumn();
            tableLayoutPanel2 = new TableLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            btnSearch = new Button();
            button2 = new Button();
            buttonImport = new Button();
            button3 = new Button();
            btnThemSV = new Button();
            label2 = new Label();
            txtSearch = new TextBox();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridStudent).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.BackColor = SystemColors.ControlLight;
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1469, 666);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel2, 0, 0);
            tableLayoutPanel1.Controls.Add(dataGridStudent, 0, 2);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1469, 666);
            tableLayoutPanel1.TabIndex = 9;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // panel2
            // 
            panel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel2.BackColor = SystemColors.MenuHighlight;
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 2);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(1463, 96);
            panel2.TabIndex = 6;
            panel2.Paint += panel2_Paint;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Arial", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(1463, 96);
            label1.TabIndex = 6;
            label1.Text = "Quản lý sinh viên";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click_1;
            // 
            // dataGridStudent
            // 
            dataGridStudent.AllowUserToAddRows = false;
            dataGridStudent.AllowUserToResizeColumns = false;
            dataGridStudent.AllowUserToResizeRows = false;
            dataGridStudent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridStudent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridStudent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridStudent.Columns.AddRange(new DataGridViewColumn[] { maSV, Column1, gioiTinh, lop, khoa, btnXemTT, btnXoa });
            dataGridStudent.Location = new Point(3, 162);
            dataGridStudent.Margin = new Padding(3, 2, 3, 2);
            dataGridStudent.MultiSelect = false;
            dataGridStudent.Name = "dataGridStudent";
            dataGridStudent.ReadOnly = true;
            dataGridStudent.RowHeadersWidth = 51;
            dataGridStudent.Size = new Size(1463, 502);
            dataGridStudent.TabIndex = 0;
            dataGridStudent.CellContentClick += dataGridView1_CellContentClick;
            // 
            // maSV
            // 
            maSV.HeaderText = "Mã sinh viên";
            maSV.MinimumWidth = 6;
            maSV.Name = "maSV";
            maSV.ReadOnly = true;
            // 
            // Column1
            // 
            Column1.HeaderText = "Họ và Tên";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // gioiTinh
            // 
            gioiTinh.HeaderText = "Giới tính ";
            gioiTinh.MinimumWidth = 6;
            gioiTinh.Name = "gioiTinh";
            gioiTinh.ReadOnly = true;
            // 
            // lop
            // 
            lop.HeaderText = "Lớp";
            lop.MinimumWidth = 6;
            lop.Name = "lop";
            lop.ReadOnly = true;
            // 
            // khoa
            // 
            khoa.HeaderText = "Khoa";
            khoa.MinimumWidth = 6;
            khoa.Name = "khoa";
            khoa.ReadOnly = true;
            // 
            // btnXemTT
            // 
            btnXemTT.HeaderText = "Xem Thông tin";
            btnXemTT.MinimumWidth = 6;
            btnXemTT.Name = "btnXemTT";
            btnXemTT.ReadOnly = true;
            btnXemTT.Text = "Xem";
            btnXemTT.UseColumnTextForButtonValue = true;
            // 
            // btnXoa
            // 
            btnXoa.HeaderText = "Xóa";
            btnXoa.MinimumWidth = 6;
            btnXoa.Name = "btnXoa";
            btnXoa.ReadOnly = true;
            btnXoa.Text = "Xóa ";
            btnXoa.UseColumnTextForButtonValue = true;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 250F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 420F));
            tableLayoutPanel2.Controls.Add(flowLayoutPanel2, 2, 0);
            tableLayoutPanel2.Controls.Add(label2, 0, 0);
            tableLayoutPanel2.Controls.Add(txtSearch, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 103);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(1463, 54);
            tableLayoutPanel2.TabIndex = 10;
            tableLayoutPanel2.Paint += tableLayoutPanel2_Paint;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(btnSearch);
            flowLayoutPanel2.Controls.Add(button2);
            flowLayoutPanel2.Controls.Add(buttonImport);
            flowLayoutPanel2.Controls.Add(button3);
            flowLayoutPanel2.Controls.Add(btnThemSV);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.Location = new Point(1046, 3);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(414, 48);
            flowLayoutPanel2.TabIndex = 7;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = SystemColors.ButtonFace;
            btnSearch.Image = (Image)resources.GetObject("btnSearch.Image");
            btnSearch.Location = new Point(0, 2);
            btnSearch.Margin = new Padding(0, 2, 3, 2);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(60, 37);
            btnSearch.TabIndex = 3;
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ButtonFace;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.Location = new Point(66, 2);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(60, 37);
            button2.TabIndex = 4;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // buttonImport
            // 
            buttonImport.BackColor = SystemColors.Control;
            buttonImport.Font = new Font("Segoe UI Emoji", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonImport.ForeColor = SystemColors.MenuHighlight;
            buttonImport.Location = new Point(132, 2);
            buttonImport.Margin = new Padding(3, 2, 3, 3);
            buttonImport.Name = "buttonImport";
            buttonImport.Size = new Size(70, 37);
            buttonImport.TabIndex = 8;
            buttonImport.Text = "Import";
            buttonImport.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.Control;
            button3.Font = new Font("Segoe UI Emoji", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = SystemColors.MenuHighlight;
            button3.Location = new Point(208, 2);
            button3.Margin = new Padding(3, 2, 3, 3);
            button3.Name = "button3";
            button3.Size = new Size(70, 37);
            button3.TabIndex = 9;
            button3.Text = "Export";
            button3.UseVisualStyleBackColor = false;
            // 
            // btnThemSV
            // 
            btnThemSV.BackColor = SystemColors.Highlight;
            btnThemSV.Font = new Font("Segoe UI Emoji", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThemSV.ForeColor = SystemColors.ControlLightLight;
            btnThemSV.Location = new Point(284, 2);
            btnThemSV.Margin = new Padding(3, 2, 3, 3);
            btnThemSV.Name = "btnThemSV";
            btnThemSV.Size = new Size(125, 37);
            btnThemSV.TabIndex = 7;
            btnThemSV.Text = "Thêm Sinh Viên";
            btnThemSV.UseVisualStyleBackColor = false;
            btnThemSV.Click += btnThemSV_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(3, 5);
            label2.Margin = new Padding(3, 5, 3, 0);
            label2.Name = "label2";
            label2.Size = new Size(230, 32);
            label2.TabIndex = 5;
            label2.Text = "Danh sách sinh viên";
            label2.Click += label2_Click;
            // 
            // txtSearch
            // 
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(250, 8);
            txtSearch.Margin = new Padding(0, 8, 0, 3);
            txtSearch.MaxLength = 70;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(793, 33);
            txtSearch.TabIndex = 8;
            // 
            // QLSinhVien
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "QLSinhVien";
            Size = new Size(1469, 666);
            Load += QLSinhVien_Load;
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridStudent).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Button btnSearch;
        private Button button2;
        private Panel panel2;
        private Button btnThemSV;
        private DataGridView dataGridStudent;
        private DataGridViewTextBoxColumn maSV;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn gioiTinh;
        private DataGridViewTextBoxColumn lop;
        private DataGridViewTextBoxColumn khoa;
        private DataGridViewButtonColumn btnXemTT;
        private DataGridViewButtonColumn btnXoa;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label2;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label label1;
        private TextBox txtSearch;
        private Button button1;
        private Button button3;
        private Button buttonImport;
    }
}