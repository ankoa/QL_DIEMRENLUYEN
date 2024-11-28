using MySqlX.XDevAPI.Relational;
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        // Thêm cột cho DataGridView trong InitializeComponent
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            panel1 = new Panel();
            pnContent = new Panel();
            tableTK = new ReaLTaiizor.Controls.PoisonDataGridView();
            colID = new DataGridViewTextBoxColumn();
            colTen = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colNS = new DataGridViewTextBoxColumn();
            colGT = new DataGridViewTextBoxColumn();
            colKhoa = new DataGridViewTextBoxColumn();
            colCreate = new DataGridViewTextBoxColumn();
            colupdate = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            pnTop = new Panel();
            panel2 = new Panel();
            tableLayoutPanel4 = new TableLayoutPanel();
            button2 = new Button();
            button3 = new Button();
            btnClear = new Button();
            tableLayoutPanel3 = new TableLayoutPanel();
            label3 = new Label();
            cbbStatus = new ComboBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            label2 = new Label();
            cbbRole = new ComboBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            txtSearch = new TextBox();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            panel3 = new Panel();
            panel1.SuspendLayout();
            pnContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tableTK).BeginInit();
            pnTop.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLightLight;
            panel1.Controls.Add(pnContent);
            panel1.Controls.Add(pnTop);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(50, 20);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(0, 20, 0, 0);
            panel1.Size = new Size(1319, 747);
            panel1.TabIndex = 5;
            // 
            // pnContent
            // 
            pnContent.AutoScroll = true;
            pnContent.BackColor = SystemColors.ControlLightLight;
            pnContent.Controls.Add(tableTK);
            pnContent.Dock = DockStyle.Fill;
            pnContent.Location = new Point(0, 209);
            pnContent.Margin = new Padding(0);
            pnContent.Name = "pnContent";
            pnContent.Padding = new Padding(21, 29, 21, 0);
            pnContent.Size = new Size(1319, 538);
            pnContent.TabIndex = 8;
            // 
            // tableTK
            // 
            tableTK.AllowDrop = true;
            tableTK.AllowUserToOrderColumns = true;
            tableTK.AllowUserToResizeRows = false;
            tableTK.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tableTK.BackgroundColor = Color.FromArgb(255, 255, 255);
            tableTK.BorderStyle = BorderStyle.None;
            tableTK.CellBorderStyle = DataGridViewCellBorderStyle.None;
            tableTK.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(0, 174, 219);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(111, 226, 255);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            tableTK.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            tableTK.ColumnHeadersHeight = 70;
            tableTK.Columns.AddRange(new DataGridViewColumn[] { colID, colTen, colEmail, colNS, colGT, colKhoa, colCreate, colupdate, colStatus });
            tableTK.Cursor = Cursors.Hand;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle9.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle9.ForeColor = Color.FromArgb(136, 136, 136);
            dataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(111, 226, 255);
            dataGridViewCellStyle9.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.False;
            tableTK.DefaultCellStyle = dataGridViewCellStyle9;
            tableTK.Dock = DockStyle.Fill;
            tableTK.EnableHeadersVisualStyles = false;
            tableTK.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            tableTK.GridColor = Color.FromArgb(255, 255, 255);
            tableTK.HighLightPercentage = 1F;
            tableTK.Location = new Point(21, 29);
            tableTK.Margin = new Padding(0, 0, 0, 29);
            tableTK.MultiSelect = false;
            tableTK.Name = "tableTK";
            tableTK.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = Color.FromArgb(0, 174, 219);
            dataGridViewCellStyle10.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle10.ForeColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle10.SelectionBackColor = Color.FromArgb(111, 226, 255);
            dataGridViewCellStyle10.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.True;
            tableTK.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            tableTK.RowHeadersVisible = false;
            tableTK.RowHeadersWidth = 51;
            tableTK.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            tableTK.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tableTK.Size = new Size(1277, 509);
            tableTK.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Custom;
            tableTK.TabIndex = 7;
            // 
            // colID
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colID.DefaultCellStyle = dataGridViewCellStyle2;
            colID.HeaderText = "ID";
            colID.MinimumWidth = 6;
            colID.Name = "colID";
            // 
            // colTen
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colTen.DefaultCellStyle = dataGridViewCellStyle3;
            colTen.HeaderText = "Tên";
            colTen.MinimumWidth = 6;
            colTen.Name = "colTen";
            // 
            // colEmail
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colEmail.DefaultCellStyle = dataGridViewCellStyle4;
            colEmail.HeaderText = "Email";
            colEmail.MinimumWidth = 6;
            colEmail.Name = "colEmail";
            // 
            // colNS
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colNS.DefaultCellStyle = dataGridViewCellStyle5;
            colNS.HeaderText = "Ngày sinh";
            colNS.MinimumWidth = 6;
            colNS.Name = "colNS";
            // 
            // colGT
            // 
            colGT.HeaderText = "Giới tính";
            colGT.MinimumWidth = 6;
            colGT.Name = "colGT";
            // 
            // colKhoa
            // 
            colKhoa.HeaderText = "Khoa";
            colKhoa.MinimumWidth = 6;
            colKhoa.Name = "colKhoa";
            // 
            // colCreate
            // 
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colCreate.DefaultCellStyle = dataGridViewCellStyle6;
            colCreate.HeaderText = "Ngày tạo";
            colCreate.MinimumWidth = 6;
            colCreate.Name = "colCreate";
            // 
            // colupdate
            // 
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colupdate.DefaultCellStyle = dataGridViewCellStyle7;
            colupdate.HeaderText = "Ngày cập nhật";
            colupdate.MinimumWidth = 6;
            colupdate.Name = "colupdate";
            // 
            // colStatus
            // 
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colStatus.DefaultCellStyle = dataGridViewCellStyle8;
            colStatus.HeaderText = "Trạng thái";
            colStatus.MinimumWidth = 6;
            colStatus.Name = "colStatus";
            // 
            // pnTop
            // 
            pnTop.BackColor = Color.RoyalBlue;
            pnTop.BackgroundImageLayout = ImageLayout.None;
            pnTop.Controls.Add(panel2);
            pnTop.Controls.Add(btnClear);
            pnTop.Controls.Add(tableLayoutPanel3);
            pnTop.Controls.Add(tableLayoutPanel2);
            pnTop.Controls.Add(tableLayoutPanel1);
            pnTop.Dock = DockStyle.Top;
            pnTop.Location = new Point(0, 20);
            pnTop.Margin = new Padding(50, 0, 50, 0);
            pnTop.Name = "pnTop";
            pnTop.Padding = new Padding(0, 51, 0, 51);
            pnTop.Size = new Size(1319, 189);
            pnTop.TabIndex = 9;
            // 
            // panel2
            // 
            panel2.Controls.Add(tableLayoutPanel4);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(1069, 51);
            panel2.Margin = new Padding(3, 51, 3, 3);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(0, 51, 0, 0);
            panel2.Size = new Size(250, 87);
            panel2.TabIndex = 45;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 106F));
            tableLayoutPanel4.Controls.Add(button2, 0, 0);
            tableLayoutPanel4.Controls.Add(button3, 1, 0);
            tableLayoutPanel4.Location = new Point(17, 15);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Size = new Size(213, 51);
            tableLayoutPanel4.TabIndex = 44;
            // 
            // button2
            // 
            button2.Dock = DockStyle.Fill;
            button2.Location = new Point(3, 3);
            button2.Name = "button2";
            button2.Size = new Size(101, 45);
            button2.TabIndex = 40;
            button2.Text = "Import";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Dock = DockStyle.Fill;
            button3.Location = new Point(110, 3);
            button3.Name = "button3";
            button3.Size = new Size(100, 45);
            button3.TabIndex = 41;
            button3.Text = "Export";
            button3.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(619, 125);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(83, 39);
            btnClear.TabIndex = 39;
            btnClear.Text = "Reset";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35.40856F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 64.59144F));
            tableLayoutPanel3.Controls.Add(label3, 0, 0);
            tableLayoutPanel3.Controls.Add(cbbStatus, 1, 0);
            tableLayoutPanel3.Location = new Point(269, 125);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new Size(328, 37);
            tableLayoutPanel3.TabIndex = 38;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(5, 2);
            label3.Name = "label3";
            label3.Padding = new Padding(0, 0, 0, 5);
            label3.Size = new Size(108, 33);
            label3.TabIndex = 37;
            label3.Text = "Trạng thái";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cbbStatus
            // 
            cbbStatus.Cursor = Cursors.Hand;
            cbbStatus.Dock = DockStyle.Fill;
            cbbStatus.FormattingEnabled = true;
            cbbStatus.Items.AddRange(new object[] { "Mặc định", "Hoạt động", "Không hoạt động" });
            cbbStatus.Location = new Point(121, 5);
            cbbStatus.Name = "cbbStatus";
            cbbStatus.Size = new Size(202, 28);
            cbbStatus.TabIndex = 36;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35.40856F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 64.59144F));
            tableLayoutPanel2.Controls.Add(label2, 0, 0);
            tableLayoutPanel2.Controls.Add(cbbRole, 1, 0);
            tableLayoutPanel2.Location = new Point(21, 125);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(231, 37);
            tableLayoutPanel2.TabIndex = 37;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(5, 2);
            label2.Name = "label2";
            label2.Padding = new Padding(0, 0, 0, 5);
            label2.Size = new Size(73, 33);
            label2.TabIndex = 37;
            label2.Text = "Quyền";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cbbRole
            // 
            cbbRole.Cursor = Cursors.Hand;
            cbbRole.Dock = DockStyle.Fill;
            cbbRole.FormattingEnabled = true;
            cbbRole.Items.AddRange(new object[] { "Mặc định", "ADMIN", "Sinh viên", "Giảng viên", "Cố vấn học tập", "Quản lý Khoa", "Quản lý Trường" });
            cbbRole.Location = new Point(86, 5);
            cbbRole.Name = "cbbRole";
            cbbRole.Size = new Size(140, 28);
            cbbRole.TabIndex = 35;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28.6353474F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 71.3646545F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(txtSearch, 1, 0);
            tableLayoutPanel1.Location = new Point(21, 67);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(576, 37);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(5, 2);
            label1.Name = "label1";
            label1.Padding = new Padding(0, 0, 0, 5);
            label1.Size = new Size(157, 33);
            label1.TabIndex = 37;
            label1.Text = "Tìm kiếm";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtSearch
            // 
            txtSearch.Cursor = Cursors.Hand;
            txtSearch.Location = new Point(170, 5);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(399, 27);
            txtSearch.TabIndex = 38;
            txtSearch.Text = "Nhập ID cần tìm";
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.Width = 125;
            // 
            // panel3
            // 
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(50, 20);
            panel3.Margin = new Padding(3, 20, 3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(1319, 49);
            panel3.TabIndex = 31;
            // 
            // QLGiangVien
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoSize = true;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1419, 867);
            ControlBox = false;
            Controls.Add(panel3);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "QLGiangVien";
            Padding = new Padding(50, 20, 50, 100);
            panel1.ResumeLayout(false);
            pnContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)tableTK).EndInit();
            pnTop.ResumeLayout(false);
            panel2.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private FlowLayoutPanel flowLayoutPanel2;
        private FlowLayoutPanel flowLayoutPanel3;
        private ReaLTaiizor.Controls.PoisonDataGridView poisonDataGridView1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private Panel panel1;
        private Panel pnContent;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private Panel panel3;
        private Panel pnTop;
        private Label label2;
        private Label label3;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private TextBox txtSearch;
        private ComboBox cbbRole;
        private ComboBox cbbStatus;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private ReaLTaiizor.Controls.PoisonDataGridView tableTK;
        private Button btnClear;
        private TableLayoutPanel tableLayoutPanel4;
        private Button button2;
        private Button button3;
        private Panel panel2;
        private DataGridViewTextBoxColumn colID;
        private DataGridViewTextBoxColumn colTen;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colNS;
        private DataGridViewTextBoxColumn colGT;
        private DataGridViewTextBoxColumn colKhoa;
        private DataGridViewTextBoxColumn colCreate;
        private DataGridViewTextBoxColumn colupdate;
        private DataGridViewTextBoxColumn colStatus;
    }
}