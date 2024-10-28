using MySqlX.XDevAPI.Relational;
using System.Windows.Forms;

namespace ql_diemrenluyen.GUI.ADMIN
{
    partial class DotCham
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
        // Thêm cột cho DataGridView trong InitializeComponent
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            panel1 = new Panel();
            pnContent = new Panel();
            tableTK = new ReaLTaiizor.Controls.PoisonDataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            pnTop = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label2 = new Label();
            cbbRole = new ComboBox();
            label3 = new Label();
            cbbStatus = new ComboBox();
            label4 = new Label();
            comboBox1 = new ComboBox();
            pnInput = new Panel();
            txtSearch = new TextBox();
            label1 = new Label();
            flowLayoutPanel2 = new FlowLayoutPanel();
            label5 = new Label();
            comboBox2 = new ComboBox();
            label6 = new Label();
            comboBox3 = new ComboBox();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            panel3 = new Panel();
            panel1.SuspendLayout();
            pnContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tableTK).BeginInit();
            pnTop.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            pnInput.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLightLight;
            panel1.Controls.Add(pnContent);
            panel1.Controls.Add(pnTop);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(44, 15);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(0, 15, 0, 0);
            panel1.Size = new Size(1154, 560);
            panel1.TabIndex = 5;
            // 
            // pnContent
            // 
            pnContent.AutoScroll = true;
            pnContent.BackColor = SystemColors.ControlLightLight;
            pnContent.Controls.Add(tableTK);
            pnContent.Dock = DockStyle.Fill;
            pnContent.Location = new Point(0, 210);
            pnContent.Margin = new Padding(0);
            pnContent.Name = "pnContent";
            pnContent.Padding = new Padding(18, 38, 18, 0);
            pnContent.Size = new Size(1154, 350);
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
            tableTK.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn8, dataGridViewTextBoxColumn6, dataGridViewTextBoxColumn7 });
            tableTK.Cursor = Cursors.Hand;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle8.ForeColor = Color.FromArgb(136, 136, 136);
            dataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(111, 226, 255);
            dataGridViewCellStyle8.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            tableTK.DefaultCellStyle = dataGridViewCellStyle8;
            tableTK.Dock = DockStyle.Fill;
            tableTK.EnableHeadersVisualStyles = false;
            tableTK.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            tableTK.GridColor = Color.FromArgb(255, 255, 255);
            tableTK.HighLightPercentage = 1F;
            tableTK.Location = new Point(18, 38);
            tableTK.Margin = new Padding(0, 0, 0, 22);
            tableTK.MultiSelect = false;
            tableTK.Name = "tableTK";
            tableTK.ReadOnly = true;
            tableTK.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = Color.FromArgb(0, 174, 219);
            dataGridViewCellStyle9.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle9.ForeColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(111, 226, 255);
            dataGridViewCellStyle9.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
            tableTK.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            tableTK.RowHeadersVisible = false;
            tableTK.RowHeadersWidth = 51;
            tableTK.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            tableTK.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tableTK.Size = new Size(1118, 312);
            tableTK.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Custom;
            tableTK.TabIndex = 5;
            tableTK.CellContentClick += tableTK_CellContentClick;
            tableTK.CellDoubleClick += tableTK_CellDoubleClick_1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewTextBoxColumn1.HeaderText = "ID";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewTextBoxColumn5.HeaderText = "Năm học";
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewTextBoxColumn3.HeaderText = "Học kì";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewTextBoxColumn8.HeaderText = "Người chấm";
            dataGridViewTextBoxColumn8.MinimumWidth = 6;
            dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle6;
            dataGridViewTextBoxColumn6.HeaderText = "Ngày bắt đầu";
            dataGridViewTextBoxColumn6.MinimumWidth = 6;
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewTextBoxColumn7.HeaderText = "Ngày kết thúc";
            dataGridViewTextBoxColumn7.MinimumWidth = 6;
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // pnTop
            // 
            pnTop.BackColor = Color.RoyalBlue;
            pnTop.BackgroundImageLayout = ImageLayout.None;
            pnTop.Controls.Add(tableLayoutPanel1);
            pnTop.Dock = DockStyle.Top;
            pnTop.Location = new Point(0, 15);
            pnTop.Margin = new Padding(18, 0, 18, 0);
            pnTop.Name = "pnTop";
            pnTop.Padding = new Padding(0, 38, 0, 38);
            pnTop.Size = new Size(1154, 195);
            pnTop.TabIndex = 9;
            pnTop.Paint += pnTop_Paint;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 1);
            tableLayoutPanel1.Controls.Add(pnInput, 0, 0);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel2, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 38);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.34F));
            tableLayoutPanel1.Size = new Size(1154, 119);
            tableLayoutPanel1.TabIndex = 35;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(label2);
            flowLayoutPanel1.Controls.Add(cbbRole);
            flowLayoutPanel1.Controls.Add(label3);
            flowLayoutPanel1.Controls.Add(cbbStatus);
            flowLayoutPanel1.Controls.Add(label4);
            flowLayoutPanel1.Controls.Add(comboBox1);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(3, 41);
            flowLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1148, 35);
            flowLayoutPanel1.TabIndex = 36;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(58, 21);
            label2.TabIndex = 32;
            label2.Text = "Học kì";
            // 
            // cbbRole
            // 
            cbbRole.Cursor = Cursors.Hand;
            cbbRole.FormattingEnabled = true;
            cbbRole.Items.AddRange(new object[] { "Mặc định", "Sinh viên", "Giảng viên", "Cố vấn học tập", "Quản lý Khoa", "Quản lý Trường" });
            cbbRole.Location = new Point(67, 2);
            cbbRole.Margin = new Padding(3, 2, 3, 2);
            cbbRole.Name = "cbbRole";
            cbbRole.Size = new Size(126, 23);
            cbbRole.TabIndex = 25;
            cbbRole.SelectedIndexChanged += cbbRole_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(248, 0);
            label3.Margin = new Padding(52, 0, 3, 0);
            label3.Name = "label3";
            label3.Size = new Size(79, 21);
            label3.TabIndex = 33;
            label3.Text = "Năm học";
            // 
            // cbbStatus
            // 
            cbbStatus.Cursor = Cursors.Hand;
            cbbStatus.FormattingEnabled = true;
            cbbStatus.Items.AddRange(new object[] { "Mặc định", "Hoạt động", "Không hoạt động" });
            cbbStatus.Location = new Point(333, 2);
            cbbStatus.Margin = new Padding(3, 2, 3, 2);
            cbbStatus.Name = "cbbStatus";
            cbbStatus.Size = new Size(123, 23);
            cbbStatus.TabIndex = 26;
            cbbStatus.SelectedIndexChanged += cbbStatus_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(511, 0);
            label4.Margin = new Padding(52, 0, 3, 0);
            label4.Name = "label4";
            label4.Size = new Size(105, 21);
            label4.TabIndex = 35;
            label4.Text = "Người chấm";
            // 
            // comboBox1
            // 
            comboBox1.Cursor = Cursors.Hand;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Mặc định", "Sinh viên", "Giảng viên", "Cố vấn học tập", "Quản lý Khoa", "Quản lý Trường" });
            comboBox1.Location = new Point(622, 2);
            comboBox1.Margin = new Padding(3, 2, 3, 2);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(126, 23);
            comboBox1.TabIndex = 34;
            // 
            // pnInput
            // 
            pnInput.Controls.Add(txtSearch);
            pnInput.Controls.Add(label1);
            pnInput.Location = new Point(3, 2);
            pnInput.Margin = new Padding(3, 2, 3, 2);
            pnInput.Name = "pnInput";
            pnInput.Size = new Size(587, 22);
            pnInput.TabIndex = 31;
            // 
            // txtSearch
            // 
            txtSearch.Cursor = Cursors.Hand;
            txtSearch.Dock = DockStyle.Right;
            txtSearch.Location = new Point(84, 0);
            txtSearch.Margin = new Padding(3, 2, 3, 2);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(503, 23);
            txtSearch.TabIndex = 34;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(-1, 0);
            label1.Name = "label1";
            label1.Size = new Size(81, 21);
            label1.TabIndex = 33;
            label1.Text = "Tìm kiếm";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(label5);
            flowLayoutPanel2.Controls.Add(comboBox2);
            flowLayoutPanel2.Controls.Add(label6);
            flowLayoutPanel2.Controls.Add(comboBox3);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.Location = new Point(3, 81);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(1148, 35);
            flowLayoutPanel2.TabIndex = 37;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ControlLightLight;
            label5.Location = new Point(0, 0);
            label5.Margin = new Padding(0, 0, 3, 0);
            label5.Name = "label5";
            label5.Size = new Size(113, 21);
            label5.TabIndex = 37;
            label5.Text = "Ngày bắt đầu";
            // 
            // comboBox2
            // 
            comboBox2.Cursor = Cursors.Hand;
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Mặc định", "Sinh viên", "Giảng viên", "Cố vấn học tập", "Quản lý Khoa", "Quản lý Trường" });
            comboBox2.Location = new Point(119, 2);
            comboBox2.Margin = new Padding(3, 2, 3, 2);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(126, 23);
            comboBox2.TabIndex = 36;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.ControlLightLight;
            label6.Location = new Point(300, 0);
            label6.Margin = new Padding(52, 0, 3, 0);
            label6.Name = "label6";
            label6.Size = new Size(117, 21);
            label6.TabIndex = 39;
            label6.Text = "Ngày kết thúc";
            // 
            // comboBox3
            // 
            comboBox3.Cursor = Cursors.Hand;
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "Mặc định", "Sinh viên", "Giảng viên", "Cố vấn học tập", "Quản lý Khoa", "Quản lý Trường" });
            comboBox3.Location = new Point(423, 2);
            comboBox3.Margin = new Padding(3, 2, 3, 2);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(126, 23);
            comboBox3.TabIndex = 38;
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
            panel3.Location = new Point(44, 15);
            panel3.Margin = new Padding(3, 15, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(1154, 37);
            panel3.TabIndex = 31;
            // 
            // DotCham
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoSize = true;
            BackColor = SystemColors.ControlLightLight;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(1242, 650);
            ControlBox = false;
            Controls.Add(panel3);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "DotCham";
            Padding = new Padding(44, 15, 44, 75);
            Text = "Tài Khoản";
            panel1.ResumeLayout(false);
            pnContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)tableTK).EndInit();
            pnTop.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            pnInput.ResumeLayout(false);
            pnInput.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
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
        private ReaLTaiizor.Controls.PoisonDataGridView tableTK;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private Panel pnInput;
        private Panel panel3;
        private Panel pnTop;
        private TextBox txtSearch;
        private Label label1;
        private ComboBox cbbStatus;
        private ComboBox cbbRole;
        private Label label2;
        private Label label3;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label4;
        private ComboBox comboBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label label5;
        private ComboBox comboBox2;
        private Label label6;
        private ComboBox comboBox3;
    }
}