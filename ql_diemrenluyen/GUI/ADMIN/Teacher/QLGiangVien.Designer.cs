using MySqlX.XDevAPI.Relational;
using ql_diemrenluyen.BUS;
using System.Windows.Forms;

namespace ql_diemrenluyen.GUI.ADMIN
{
    partial class QLGiangVien
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            panel1 = new Panel();
            pnContent = new Panel();
            tableGV = new ReaLTaiizor.Controls.PoisonDataGridView();
            Idcolumn = new DataGridViewTextBoxColumn();
            nameColumn = new DataGridViewTextBoxColumn();
            emailColumn = new DataGridViewTextBoxColumn();
            khoaColumn = new DataGridViewTextBoxColumn();
            gioiTinhColumn = new DataGridViewTextBoxColumn();
            ngaySinhColumn = new DataGridViewTextBoxColumn();
            StatusColumn = new DataGridViewTextBoxColumn();
            panel5 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            cbbFilterKhoa = new ComboBox();
            panel6 = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            btImport = new Button();
            btExport = new Button();
            button5 = new Button();
            tableLayoutPanel5 = new TableLayoutPanel();
            label2 = new Label();
            cbbStatus = new ComboBox();
            tableLayoutPanel7 = new TableLayoutPanel();
            label5 = new Label();
            txtSearch = new TextBox();
            tableLayoutPanel13 = new TableLayoutPanel();
            btnAdd = new Button();
            label3 = new Label();
            pnInput = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel2 = new Panel();
            tabPage = new TabPage();
            cbStatusCTTC = new TabControl();
            tableLayoutPanel3 = new TableLayoutPanel();
            tableLayoutPanel6 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)tableGV).BeginInit();
            panel5.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel6.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            tableLayoutPanel7.SuspendLayout();
            tableLayoutPanel13.SuspendLayout();
            panel4.SuspendLayout();
            tabPage.SuspendLayout();
            cbStatusCTTC.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 100);
            panel1.TabIndex = 0;
            // 
            // pnContent
            // 
            pnContent.Location = new Point(0, 0);
            pnContent.Name = "pnContent";
            pnContent.Size = new Size(200, 100);
            pnContent.TabIndex = 0;
            // 
            // tableGV
            // 
            tableGV.AllowDrop = true;
            tableGV.AllowUserToOrderColumns = true;
            tableGV.AllowUserToResizeRows = false;
            tableGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tableGV.BackgroundColor = Color.FromArgb(255, 255, 255);
            tableGV.BorderStyle = BorderStyle.None;
            tableGV.CellBorderStyle = DataGridViewCellBorderStyle.None;
            tableGV.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(0, 174, 219);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(111, 226, 255);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            tableGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            tableGV.ColumnHeadersHeight = 70;
            tableGV.Columns.AddRange(new DataGridViewColumn[] { Idcolumn, nameColumn, emailColumn, khoaColumn, gioiTinhColumn, ngaySinhColumn, StatusColumn });
            tableGV.Cursor = Cursors.Hand;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(136, 136, 136);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(111, 226, 255);
            dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            tableGV.DefaultCellStyle = dataGridViewCellStyle4;
            tableGV.Dock = DockStyle.Bottom;
            tableGV.EnableHeadersVisualStyles = false;
            tableGV.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            tableGV.GridColor = Color.FromArgb(255, 255, 255);
            tableGV.HighLightPercentage = 1F;
            tableGV.Location = new Point(18, 60);
            tableGV.Margin = new Padding(0, 0, 0, 22);
            tableGV.MultiSelect = false;
            tableGV.Name = "tableGV";
            tableGV.ReadOnly = true;
            tableGV.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(0, 174, 219);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(111, 226, 255);
            dataGridViewCellStyle5.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            tableGV.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            tableGV.RowHeadersVisible = false;
            tableGV.RowHeadersWidth = 51;
            tableGV.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            tableGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tableGV.Size = new Size(1070, 435);
            tableGV.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Custom;
            tableGV.TabIndex = 8;
            tableGV.CellContentClick += tableGV_CellContentClick;
            tableGV.CellDoubleClick += table_CellDoubleClick;
            // 
            // Idcolumn
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Idcolumn.DefaultCellStyle = dataGridViewCellStyle2;
            Idcolumn.HeaderText = "Giảng viên ID";
            Idcolumn.MinimumWidth = 6;
            Idcolumn.Name = "Idcolumn";
            Idcolumn.ReadOnly = true;
            // 
            // nameColumn
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            nameColumn.DefaultCellStyle = dataGridViewCellStyle3;
            nameColumn.HeaderText = "Tên Giảng viên";
            nameColumn.MinimumWidth = 6;
            nameColumn.Name = "nameColumn";
            nameColumn.ReadOnly = true;
            // 
            // emailColumn
            // 
            emailColumn.HeaderText = "Email";
            emailColumn.MinimumWidth = 6;
            emailColumn.Name = "emailColumn";
            emailColumn.ReadOnly = true;
            // 
            // khoaColumn
            // 
            khoaColumn.HeaderText = "Khoa";
            khoaColumn.MinimumWidth = 6;
            khoaColumn.Name = "khoaColumn";
            khoaColumn.ReadOnly = true;
            // 
            // gioiTinhColumn
            // 
            gioiTinhColumn.HeaderText = "Giới tính";
            gioiTinhColumn.MinimumWidth = 6;
            gioiTinhColumn.Name = "gioiTinhColumn";
            gioiTinhColumn.ReadOnly = true;
            // 
            // ngaySinhColumn
            // 
            ngaySinhColumn.HeaderText = "Ngày sinh";
            ngaySinhColumn.MinimumWidth = 7;
            ngaySinhColumn.Name = "ngaySinhColumn";
            ngaySinhColumn.ReadOnly = true;
            // 
            // StatusColumn
            // 
            StatusColumn.HeaderText = "Trạng thái";
            StatusColumn.MinimumWidth = 6;
            StatusColumn.Name = "StatusColumn";
            StatusColumn.ReadOnly = true;
            // 
            // panel5
            // 
            panel5.BackColor = Color.RoyalBlue;
            panel5.BackgroundImageLayout = ImageLayout.None;
            panel5.Controls.Add(tableLayoutPanel1);
            panel5.Controls.Add(panel6);
            panel5.Controls.Add(button5);
            panel5.Controls.Add(tableLayoutPanel5);
            panel5.Controls.Add(tableLayoutPanel7);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(3, 2);
            panel5.Margin = new Padding(44, 0, 44, 0);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(0, 38, 0, 38);
            panel5.Size = new Size(1123, 142);
            panel5.TabIndex = 11;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35.40856F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 64.59144F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(cbbFilterKhoa, 1, 0);
            tableLayoutPanel1.Location = new Point(341, 94);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tableLayoutPanel1.Size = new Size(297, 28);
            tableLayoutPanel1.TabIndex = 46;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(5, 2);
            label1.Name = "label1";
            label1.Padding = new Padding(0, 0, 0, 4);
            label1.Size = new Size(97, 24);
            label1.TabIndex = 37;
            label1.Text = "Khoa";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cbbFilterKhoa
            // 
            cbbFilterKhoa.Cursor = Cursors.Hand;
            cbbFilterKhoa.Dock = DockStyle.Fill;
            cbbFilterKhoa.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbFilterKhoa.FormattingEnabled = true;
            cbbFilterKhoa.Items.AddRange(new object[] { "Mặc định", "Hoạt động", "Không hoạt động" });
            cbbFilterKhoa.Location = new Point(110, 4);
            cbbFilterKhoa.Margin = new Padding(3, 2, 3, 2);
            cbbFilterKhoa.Name = "cbbFilterKhoa";
            cbbFilterKhoa.Size = new Size(182, 23);
            cbbFilterKhoa.TabIndex = 36;
            // 
            // panel6
            // 
            panel6.Controls.Add(tableLayoutPanel2);
            panel6.Dock = DockStyle.Right;
            panel6.Location = new Point(904, 38);
            panel6.Margin = new Padding(3, 38, 3, 2);
            panel6.Name = "panel6";
            panel6.Padding = new Padding(0, 38, 0, 0);
            panel6.Size = new Size(219, 66);
            panel6.TabIndex = 45;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 93F));
            tableLayoutPanel2.Controls.Add(btImport, 0, 0);
            tableLayoutPanel2.Controls.Add(btExport, 1, 0);
            tableLayoutPanel2.Location = new Point(15, 11);
            tableLayoutPanel2.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(186, 38);
            tableLayoutPanel2.TabIndex = 44;
            // 
            // btImport
            // 
            btImport.Dock = DockStyle.Fill;
            btImport.Location = new Point(3, 2);
            btImport.Margin = new Padding(3, 2, 3, 2);
            btImport.Name = "btImport";
            btImport.Size = new Size(87, 34);
            btImport.TabIndex = 40;
            btImport.Text = "Import";
            btImport.UseVisualStyleBackColor = true;
            btImport.Click += btImport_Click;
            // 
            // btExport
            // 
            btExport.Dock = DockStyle.Fill;
            btExport.Location = new Point(96, 2);
            btExport.Margin = new Padding(3, 2, 3, 2);
            btExport.Name = "btExport";
            btExport.Size = new Size(87, 34);
            btExport.TabIndex = 41;
            btExport.Text = "Export";
            btExport.UseVisualStyleBackColor = true;
            btExport.Click += btExport_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.Lavender;
            button5.Location = new Point(554, 47);
            button5.Margin = new Padding(3, 2, 3, 2);
            button5.Name = "button5";
            button5.Size = new Size(73, 29);
            button5.TabIndex = 39;
            button5.Text = "Reset";
            button5.UseVisualStyleBackColor = false;
            button5.Click += btnClear_Click;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
            tableLayoutPanel5.ColumnCount = 2;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35.40856F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 64.59144F));
            tableLayoutPanel5.Controls.Add(label2, 0, 0);
            tableLayoutPanel5.Controls.Add(cbbStatus, 1, 0);
            tableLayoutPanel5.Location = new Point(18, 94);
            tableLayoutPanel5.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tableLayoutPanel5.Size = new Size(297, 28);
            tableLayoutPanel5.TabIndex = 38;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(5, 2);
            label2.Name = "label2";
            label2.Padding = new Padding(0, 0, 0, 4);
            label2.Size = new Size(97, 24);
            label2.TabIndex = 37;
            label2.Text = "Trạng thái";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cbbStatus
            // 
            cbbStatus.Cursor = Cursors.Hand;
            cbbStatus.Dock = DockStyle.Fill;
            cbbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbStatus.FormattingEnabled = true;
            cbbStatus.Items.AddRange(new object[] { "Mặc định", "Hoạt động", "Không hoạt động" });
            cbbStatus.Location = new Point(110, 4);
            cbbStatus.Margin = new Padding(3, 2, 3, 2);
            cbbStatus.Name = "cbbStatus";
            cbbStatus.Size = new Size(182, 23);
            cbbStatus.TabIndex = 36;
            cbbStatus.SelectedIndexChanged += cbbStatus_SelectedIndexChanged;
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
            tableLayoutPanel7.ColumnCount = 2;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28.6353474F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 71.3646545F));
            tableLayoutPanel7.Controls.Add(label5, 0, 0);
            tableLayoutPanel7.Controls.Add(txtSearch, 1, 0);
            tableLayoutPanel7.Location = new Point(18, 50);
            tableLayoutPanel7.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 1;
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.Size = new Size(504, 28);
            tableLayoutPanel7.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ControlLightLight;
            label5.Location = new Point(5, 2);
            label5.Name = "label5";
            label5.Padding = new Padding(0, 0, 0, 4);
            label5.Size = new Size(136, 24);
            label5.TabIndex = 37;
            label5.Text = "Tìm kiếm";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtSearch
            // 
            txtSearch.Cursor = Cursors.Hand;
            txtSearch.Location = new Point(149, 4);
            txtSearch.Margin = new Padding(3, 2, 3, 2);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(350, 23);
            txtSearch.TabIndex = 38;
            txtSearch.Text = "Nhập ID,nội dung cần tìm";
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // tableLayoutPanel13
            // 
            tableLayoutPanel13.ColumnCount = 2;
            tableLayoutPanel13.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel13.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 89F));
            tableLayoutPanel13.Controls.Add(btnAdd, 1, 0);
            tableLayoutPanel13.Dock = DockStyle.Top;
            tableLayoutPanel13.Location = new Point(18, 8);
            tableLayoutPanel13.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel13.Name = "tableLayoutPanel13";
            tableLayoutPanel13.RowCount = 1;
            tableLayoutPanel13.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel13.Size = new Size(1070, 52);
            tableLayoutPanel13.TabIndex = 9;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.LimeGreen;
            btnAdd.Dock = DockStyle.Right;
            btnAdd.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = SystemColors.ControlLightLight;
            btnAdd.Location = new Point(984, 2);
            btnAdd.Margin = new Padding(3, 2, 3, 11);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(83, 39);
            btnAdd.TabIndex = 47;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // label3
            // 
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(100, 23);
            label3.TabIndex = 0;
            // 
            // pnInput
            // 
            pnInput.Location = new Point(0, 0);
            pnInput.Name = "pnInput";
            pnInput.Size = new Size(200, 100);
            pnInput.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(200, 100);
            panel3.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.AutoScroll = true;
            panel4.BackColor = SystemColors.ControlLightLight;
            panel4.Controls.Add(tableLayoutPanel13);
            panel4.Controls.Add(tableGV);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(3, 144);
            panel4.Margin = new Padding(0);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(18, 8, 18, 0);
            panel4.Size = new Size(1123, 440);
            panel4.TabIndex = 10;
            // 
            // panel2
            // 
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(200, 100);
            panel2.TabIndex = 0;
            // 
            // tabPage
            // 
            tabPage.Controls.Add(panel4);
            tabPage.Controls.Add(panel5);
            tabPage.Location = new Point(4, 24);
            tabPage.Margin = new Padding(3, 2, 3, 2);
            tabPage.Name = "tabPage";
            tabPage.Padding = new Padding(3, 2, 3, 2);
            tabPage.Size = new Size(1129, 586);
            tabPage.TabIndex = 1;
            tabPage.Text = "Quản Lý Giảng Viên";
            tabPage.UseVisualStyleBackColor = true;
            // 
            // cbStatusCTTC
            // 
            cbStatusCTTC.Controls.Add(tabPage);
            cbStatusCTTC.Dock = DockStyle.Fill;
            cbStatusCTTC.Location = new Point(44, 15);
            cbStatusCTTC.Margin = new Padding(3, 2, 3, 2);
            cbStatusCTTC.Name = "cbStatusCTTC";
            cbStatusCTTC.SelectedIndex = 0;
            cbStatusCTTC.Size = new Size(1137, 614);
            cbStatusCTTC.TabIndex = 0;
            cbStatusCTTC.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.Location = new Point(0, 0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.Size = new Size(200, 100);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.Location = new Point(0, 0);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.Size = new Size(200, 100);
            tableLayoutPanel6.TabIndex = 0;
            // 
            // QLGiangVien
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1225, 704);
            ControlBox = false;
            Controls.Add(cbStatusCTTC);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "QLGiangVien";
            Padding = new Padding(44, 15, 44, 75);
            Load += GiangVien_Load;
            ((System.ComponentModel.ISupportInitialize)tableGV).EndInit();
            panel5.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel6.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            tableLayoutPanel7.ResumeLayout(false);
            tableLayoutPanel7.PerformLayout();
            tableLayoutPanel13.ResumeLayout(false);
            panel4.ResumeLayout(false);
            tabPage.ResumeLayout(false);
            cbStatusCTTC.ResumeLayout(false);
            ResumeLayout(false);
        }

        private TabControl cbStatusCTTC;

        private Panel panel1;
        private Label label5;
        private Panel panel4;
        private Panel pnContent;
        private ReaLTaiizor.Controls.PoisonDataGridView tableGV;
        private Button button5;
        private Panel panel5;
        private Label label3;
        private Panel pnInput;
        private TextBox txtSearch;
        private Panel panel3;
        private TabPage tabPage;
        private TableLayoutPanel tableLayoutPanel13;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel6;
        private TableLayoutPanel tableLayoutPanel7;
        private TableLayoutPanel tableLayoutPanel2;

        private Button btnAdd; // Nút Thêm
        private Panel panel2;
        private Panel panel6;
        private Button btImport;
        private Button btExport;
        private TableLayoutPanel tableLayoutPanel5;
        private Label label2;
        private ComboBox cbbStatus;
        private DataGridViewTextBoxColumn covanColumn;
        private DataGridViewTextBoxColumn Idcolumn;
        private DataGridViewTextBoxColumn nameColumn;
        private DataGridViewTextBoxColumn emailColumn;
        private DataGridViewTextBoxColumn khoaColumn;
        private DataGridViewTextBoxColumn ngayTaoColumn;
        private DataGridViewTextBoxColumn ngayCapNhatColumn;
        private DataGridViewTextBoxColumn StatusColumn;
        private DataGridViewTextBoxColumn gioiTinhColumn;
        private DataGridViewTextBoxColumn ngaySinhColumn;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private ComboBox cbbFilterKhoa;
    }
}
