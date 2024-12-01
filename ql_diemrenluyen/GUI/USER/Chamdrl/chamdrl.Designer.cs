namespace ql_diemrenluyen.GUI.ADMIN
{
    partial class chamdrl
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            cbLop = new ComboBox();
            cbSinhvien = new ComboBox();
            cbKhoa = new ComboBox();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label1 = new Label();
            lbhocky = new Label();
            cbHocKy = new ComboBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            dataGridView1 = new DataGridView();
            groupBox1 = new GroupBox();
            lbXepHang = new Label();
            lbDiem = new Label();
            lbMssv = new Label();
            lbTen = new Label();
            btnLuu = new Button();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label2 = new Label();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // mySqlCommand1
            // 
            mySqlCommand1.CacheAge = 0;
            mySqlCommand1.Connection = null;
            mySqlCommand1.EnableCaching = false;
            mySqlCommand1.Transaction = null;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 29.0384617F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 70.96154F));
            tableLayoutPanel1.Size = new Size(1167, 668);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 6;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19F));
            tableLayoutPanel2.Controls.Add(cbLop, 5, 1);
            tableLayoutPanel2.Controls.Add(cbSinhvien, 5, 2);
            tableLayoutPanel2.Controls.Add(cbKhoa, 3, 1);
            tableLayoutPanel2.Controls.Add(label7, 2, 1);
            tableLayoutPanel2.Controls.Add(label8, 4, 1);
            tableLayoutPanel2.Controls.Add(label9, 4, 2);
            tableLayoutPanel2.Controls.Add(label1, 2, 0);
            tableLayoutPanel2.Controls.Add(lbhocky, 0, 1);
            tableLayoutPanel2.Controls.Add(cbHocKy, 1, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 2);
            tableLayoutPanel2.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.Padding = new Padding(26, 0, 26, 0);
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 28.96552F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 39.3103447F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 31.7241383F));
            tableLayoutPanel2.Size = new Size(1161, 189);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // cbLop
            // 
            cbLop.Dock = DockStyle.Fill;
            cbLop.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLop.FormattingEnabled = true;
            cbLop.Location = new Point(924, 56);
            cbLop.Margin = new Padding(3, 2, 3, 2);
            cbLop.Name = "cbLop";
            cbLop.Size = new Size(208, 23);
            cbLop.TabIndex = 8;
            cbLop.SelectedIndexChanged += cbLop_SelectedIndexChanged;
            // 
            // cbSinhvien
            // 
            cbSinhvien.Dock = DockStyle.Fill;
            cbSinhvien.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSinhvien.FormattingEnabled = true;
            cbSinhvien.Location = new Point(924, 130);
            cbSinhvien.Margin = new Padding(3, 2, 3, 2);
            cbSinhvien.Name = "cbSinhvien";
            cbSinhvien.Size = new Size(208, 23);
            cbSinhvien.TabIndex = 9;
            cbSinhvien.SelectedIndexChanged += cbSinhvien_SelectedIndexChanged;
            // 
            // cbKhoa
            // 
            cbKhoa.Dock = DockStyle.Fill;
            cbKhoa.DropDownStyle = ComboBoxStyle.DropDownList;
            cbKhoa.FormattingEnabled = true;
            cbKhoa.Location = new Point(504, 56);
            cbKhoa.Margin = new Padding(3, 2, 3, 2);
            cbKhoa.Name = "cbKhoa";
            cbKhoa.Size = new Size(204, 23);
            cbKhoa.TabIndex = 10;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Location = new Point(461, 54);
            label7.Name = "label7";
            label7.Size = new Size(37, 15);
            label7.TabIndex = 13;
            label7.Text = "Khoa:";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Location = new Point(888, 54);
            label8.Name = "label8";
            label8.Size = new Size(30, 15);
            label8.TabIndex = 14;
            label8.Text = "Lớp:";
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Location = new Point(806, 128);
            label9.Name = "label9";
            label9.Size = new Size(112, 15);
            label9.TabIndex = 15;
            label9.Text = "Danh sách sinh viên";
            // 
            // label1
            // 
            label1.AutoSize = true;
            tableLayoutPanel2.SetColumnSpan(label1, 3);
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(338, 0);
            label1.Name = "label1";
            label1.Size = new Size(580, 54);
            label1.TabIndex = 16;
            label1.Text = "CHẤM ĐIỂM RÈN LUYỆN SINH VIÊN";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbhocky
            // 
            lbhocky.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbhocky.AutoSize = true;
            lbhocky.Location = new Point(42, 54);
            lbhocky.Name = "lbhocky";
            lbhocky.Size = new Size(47, 15);
            lbhocky.TabIndex = 17;
            lbhocky.Text = "Học kỳ:";
            lbhocky.Visible = false;
            // 
            // cbHocKy
            // 
            cbHocKy.Dock = DockStyle.Fill;
            cbHocKy.DropDownStyle = ComboBoxStyle.DropDownList;
            cbHocKy.FormattingEnabled = true;
            cbHocKy.Location = new Point(95, 56);
            cbHocKy.Margin = new Padding(3, 2, 3, 2);
            cbHocKy.Name = "cbHocKy";
            cbHocKy.Size = new Size(237, 23);
            cbHocKy.TabIndex = 18;
            cbHocKy.Visible = false;
            cbHocKy.SelectedIndexChanged += cbHocKy_SelectedIndexChanged;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.BackColor = SystemColors.ControlLightLight;
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel3.Controls.Add(dataGridView1, 0, 0);
            tableLayoutPanel3.Controls.Add(groupBox1, 1, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 195);
            tableLayoutPanel3.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
            tableLayoutPanel3.Size = new Size(1161, 471);
            tableLayoutPanel3.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.RoyalBlue;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Location = new Point(3, 2);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(806, 452);
            dataGridView1.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lbXepHang);
            groupBox1.Controls.Add(lbDiem);
            groupBox1.Controls.Add(lbMssv);
            groupBox1.Controls.Add(lbTen);
            groupBox1.Controls.Add(btnLuu);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label2);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(815, 2);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(343, 452);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin sinh viên";
            // 
            // lbXepHang
            // 
            lbXepHang.AutoSize = true;
            lbXepHang.Location = new Point(91, 101);
            lbXepHang.Name = "lbXepHang";
            lbXepHang.Size = new Size(13, 15);
            lbXepHang.TabIndex = 8;
            lbXepHang.Text = "  ";
            // 
            // lbDiem
            // 
            lbDiem.AutoSize = true;
            lbDiem.Location = new Point(91, 75);
            lbDiem.Name = "lbDiem";
            lbDiem.Size = new Size(13, 15);
            lbDiem.TabIndex = 7;
            lbDiem.Text = "  ";
            // 
            // lbMssv
            // 
            lbMssv.AutoSize = true;
            lbMssv.Location = new Point(91, 49);
            lbMssv.Name = "lbMssv";
            lbMssv.Size = new Size(13, 15);
            lbMssv.TabIndex = 6;
            lbMssv.Text = "  ";
            // 
            // lbTen
            // 
            lbTen.AutoSize = true;
            lbTen.Location = new Point(91, 25);
            lbTen.Name = "lbTen";
            lbTen.Size = new Size(13, 15);
            lbTen.TabIndex = 5;
            lbTen.Text = "  ";
            // 
            // btnLuu
            // 
            btnLuu.Dock = DockStyle.Bottom;
            btnLuu.Location = new Point(3, 414);
            btnLuu.Margin = new Padding(3, 2, 3, 2);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(337, 36);
            btnLuu.TabIndex = 4;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(18, 101);
            label6.Name = "label6";
            label6.Size = new Size(65, 15);
            label6.TabIndex = 3;
            label6.Text = "Xếp Hạng: ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(18, 75);
            label5.Name = "label5";
            label5.Size = new Size(71, 15);
            label5.TabIndex = 2;
            label5.Text = "Tổng Điểm: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(18, 49);
            label4.Name = "label4";
            label4.Size = new Size(43, 15);
            label4.TabIndex = 1;
            label4.Text = "MSSV: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 25);
            label2.Name = "label2";
            label2.Size = new Size(65, 15);
            label2.TabIndex = 0;
            label2.Text = "Họ và Tên: ";
            // 
            // chamdrl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1167, 668);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "chamdrl";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += chamdrl_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private DataGridView dataGridView1;
        private GroupBox groupBox1;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label2;
        private Button btnLuu;
        private ComboBox cbLop;
        private ComboBox cbSinhvien;
        private ComboBox cbKhoa;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label1;
        //private Label lbhocky;
        private Label lbXepHang;
        private Label lbDiem;
        private Label lbMssv;
        private Label lbTen;
        private Label lbhocky;
        private ComboBox cbHocKy;
    }
}