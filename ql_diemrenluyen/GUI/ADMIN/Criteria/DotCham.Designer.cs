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
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            pnTop = new Panel();
            label3 = new Label();
            label2 = new Label();
            pnInput = new Panel();
            txtSearch = new TextBox();
            label1 = new Label();
            cbbStatus = new ComboBox();
            cbbRole = new ComboBox();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            panel3 = new Panel();
            panel1.SuspendLayout();
            pnContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tableTK).BeginInit();
            pnTop.SuspendLayout();
            pnInput.SuspendLayout();
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
            pnContent.Location = new Point(0, 157);
            pnContent.Margin = new Padding(0);
            pnContent.Name = "pnContent";
            pnContent.Padding = new Padding(18, 38, 18, 0);
            pnContent.Size = new Size(1154, 403);
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
            tableTK.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn6, dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn8, dataGridViewTextBoxColumn4 });
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
            tableTK.Location = new Point(18, 38);
            tableTK.Margin = new Padding(0, 0, 0, 22);
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
            tableTK.Size = new Size(1118, 365);
            tableTK.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Custom;
            tableTK.TabIndex = 5;
            tableTK.CellContentClick += tableTK_CellContentClick;
            tableTK.CellDoubleClick += tableTK_CellDoubleClick_1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewTextBoxColumn1.HeaderText = "Tài khoản ID";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewTextBoxColumn5.HeaderText = "Mật khẩu";
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewTextBoxColumn3.HeaderText = "Quyền";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewTextBoxColumn6.HeaderText = "Remember Token";
            dataGridViewTextBoxColumn6.MinimumWidth = 6;
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle6;
            dataGridViewTextBoxColumn7.HeaderText = "Ngày tạo";
            dataGridViewTextBoxColumn7.MinimumWidth = 6;
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewTextBoxColumn8.HeaderText = "Ngày cập nhật";
            dataGridViewTextBoxColumn8.MinimumWidth = 6;
            dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle8;
            dataGridViewTextBoxColumn4.HeaderText = "Trạng thái";
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // pnTop
            // 
            pnTop.BackColor = Color.RoyalBlue;
            pnTop.BackgroundImageLayout = ImageLayout.None;
            pnTop.Controls.Add(label3);
            pnTop.Controls.Add(label2);
            pnTop.Controls.Add(pnInput);
            pnTop.Controls.Add(cbbStatus);
            pnTop.Controls.Add(cbbRole);
            pnTop.Dock = DockStyle.Top;
            pnTop.Location = new Point(0, 15);
            pnTop.Margin = new Padding(18, 0, 18, 0);
            pnTop.Name = "pnTop";
            pnTop.Padding = new Padding(0, 38, 0, 38);
            pnTop.Size = new Size(1154, 142);
            pnTop.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(267, 106);
            label3.Name = "label3";
            label3.Size = new Size(89, 21);
            label3.TabIndex = 33;
            label3.Text = "Tình trạng";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(18, 103);
            label2.Name = "label2";
            label2.Size = new Size(60, 21);
            label2.TabIndex = 32;
            label2.Text = "Quyền";
            // 
            // pnInput
            // 
            pnInput.BorderStyle = BorderStyle.FixedSingle;
            pnInput.Controls.Add(txtSearch);
            pnInput.Controls.Add(label1);
            pnInput.Location = new Point(18, 58);
            pnInput.Margin = new Padding(3, 2, 3, 2);
            pnInput.Name = "pnInput";
            pnInput.Size = new Size(314, 22);
            pnInput.TabIndex = 31;
            // 
            // txtSearch
            // 
            txtSearch.Cursor = Cursors.Hand;
            txtSearch.Dock = DockStyle.Right;
            txtSearch.Location = new Point(94, 0);
            txtSearch.Margin = new Padding(3, 2, 3, 2);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(218, 23);
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
            // cbbStatus
            // 
            cbbStatus.Cursor = Cursors.Hand;
            cbbStatus.FormattingEnabled = true;
            cbbStatus.Items.AddRange(new object[] { "Mặc định", "Hoạt động", "Không hoạt động" });
            cbbStatus.Location = new Point(369, 109);
            cbbStatus.Margin = new Padding(3, 2, 3, 2);
            cbbStatus.Name = "cbbStatus";
            cbbStatus.Size = new Size(123, 23);
            cbbStatus.TabIndex = 26;
            cbbStatus.SelectedIndexChanged += cbbStatus_SelectedIndexChanged;
            // 
            // cbbRole
            // 
            cbbRole.Cursor = Cursors.Hand;
            cbbRole.FormattingEnabled = true;
            cbbRole.Items.AddRange(new object[] { "Mặc định", "Sinh viên", "Giảng viên", "Cố vấn học tập", "Quản lý Khoa", "Quản lý Trường" });
            cbbRole.Location = new Point(87, 106);
            cbbRole.Margin = new Padding(3, 2, 3, 2);
            cbbRole.Name = "cbbRole";
            cbbRole.Size = new Size(126, 23);
            cbbRole.TabIndex = 25;
            cbbRole.SelectedIndexChanged += cbbRole_SelectedIndexChanged;
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
            pnTop.PerformLayout();
            pnInput.ResumeLayout(false);
            pnInput.PerformLayout();
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
        private ReaLTaiizor.Controls.PoisonDataGridView tableTK;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private Panel pnInput;
        private Panel panel3;
        private Panel pnTop;
        private TextBox txtSearch;
        private Label label1;
        private ComboBox cbbStatus;
        private ComboBox cbbRole;
        private Label label2;
        private Label label3;
    }
}