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

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            panel1 = new Panel();
            pnContent = new Panel();
            tableGV = new ReaLTaiizor.Controls.PoisonDataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            pnTop = new Panel();
            label3 = new Label();
            label2 = new Label();
            pnInput = new Panel();
            txtSearch = new TextBox();
            label1 = new Label();
            cbbStatus = new ComboBox();
            cbbRole = new ComboBox();
            panel3 = new Panel();
            btnAdd = new Button(); // Nút Thêm
            panel1.SuspendLayout();
            pnContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tableGV).BeginInit();
            pnTop.SuspendLayout();
            pnInput.SuspendLayout();
            SuspendLayout();

            // panel1
            panel1.BackColor = SystemColors.ControlLightLight;
            panel1.Controls.Add(pnContent);
            panel1.Controls.Add(pnTop);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(0, 20, 0, 0);
            panel1.Size = new Size(1319, 766);
            panel1.TabIndex = 5;

            // pnContent
            pnContent.AutoScroll = true;
            pnContent.BackColor = SystemColors.ControlLightLight;
            pnContent.Controls.Add(tableGV);
            pnContent.Dock = DockStyle.Fill;
            pnContent.Location = new Point(0, 210);
            pnContent.Margin = new Padding(0);
            pnContent.Name = "pnContent";
            pnContent.Padding = new Padding(20, 50, 20, 0);
            pnContent.Size = new Size(1319, 556);
            pnContent.TabIndex = 8;

            // tableGV
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
            tableGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            tableGV.ColumnHeadersHeight = 70;
            tableGV.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6, dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn8 });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(136, 136, 136);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            tableGV.DefaultCellStyle = dataGridViewCellStyle2;
            tableGV.Dock = DockStyle.Fill;
            tableGV.EnableHeadersVisualStyles = false;
            tableGV.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            tableGV.GridColor = Color.FromArgb(255, 255, 255);
            tableGV.Location = new Point(20, 50);
            tableGV.MultiSelect = false;
            tableGV.Name = "tableGV";
            tableGV.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(0, 174, 219);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tableGV.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            tableGV.RowHeadersVisible = false;
            tableGV.RowHeadersWidth = 51;
            tableGV.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            tableGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tableGV.Size = new Size(1279, 506);
            tableGV.TabIndex = 5;
            tableGV.CellDoubleClick += table_CellDoubleClick;

            // Các cột trong bảng
            dataGridViewTextBoxColumn1.HeaderText = "Giảng viên ID";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";

            dataGridViewTextBoxColumn2.HeaderText = "Tên Giảng viên";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";

            dataGridViewTextBoxColumn3.HeaderText = "Email";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";

            dataGridViewTextBoxColumn4.HeaderText = "Khoa";
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";

            dataGridViewTextBoxColumn5.HeaderText = "Chức vụ";
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";

            dataGridViewTextBoxColumn6.HeaderText = "Ngày tạo";
            dataGridViewTextBoxColumn6.MinimumWidth = 6;
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";

            dataGridViewTextBoxColumn7.HeaderText = "Ngày cập nhật";
            dataGridViewTextBoxColumn7.MinimumWidth = 7;
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";

            dataGridViewTextBoxColumn8.HeaderText = "Trạng thái";
            dataGridViewTextBoxColumn8.MinimumWidth = 6;
            dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";

            // pnTop
            pnTop.BackColor = Color.RoyalBlue;
            pnTop.Controls.Add(label3);
            pnTop.Controls.Add(label2);
            pnTop.Controls.Add(pnInput);
            pnTop.Controls.Add(cbbStatus);
            pnTop.Controls.Add(cbbRole);
            pnTop.Controls.Add(btnAdd); // Thêm nút "Thêm"
            pnTop.Dock = DockStyle.Top;
            pnTop.Location = new Point(0, 20);
            pnTop.Name = "pnTop";
            pnTop.Padding = new Padding(0, 20, 0, 0);
            pnTop.Size = new Size(1319, 190);
            pnTop.TabIndex = 7;

            // label3
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(121, 63);
            label3.Name = "label3";
            label3.Size = new Size(90, 35);
            label3.TabIndex = 12;
            label3.Text = "Chức vụ";

            // label2
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(581, 63);
            label2.Name = "label2";
            label2.Size = new Size(105, 35);
            label2.TabIndex = 11;
            label2.Text = "Trạng thái";

            // pnInput
            pnInput.BackColor = Color.Transparent;
            pnInput.Controls.Add(txtSearch);
            pnInput.Controls.Add(label1);
            pnInput.Location = new Point(150, 110);
            pnInput.Name = "pnInput";
            pnInput.Size = new Size(440, 60);
            pnInput.TabIndex = 0;

            // txtSearch
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(179, 15);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(246, 32);
            txtSearch.TabIndex = 3;
            txtSearch.PlaceholderText = "Tìm kiếm giảng viên";

            // label1
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(39, 15);
            label1.Name = "label1";
            label1.Size = new Size(111, 32);
            label1.TabIndex = 1;
            label1.Text = "Tìm kiếm";

            // cbbStatus
            cbbStatus.FormattingEnabled = true;
            cbbStatus.Items.AddRange(new object[] { "Tất cả", "Hoạt động", "Không hoạt động" });
            cbbStatus.Location = new Point(730, 63);
            cbbStatus.Name = "cbbStatus";
            cbbStatus.Size = new Size(207, 45);
            cbbStatus.TabIndex = 10;

            // cbbRole
            cbbRole.FormattingEnabled = true;
            cbbRole.Items.AddRange(new object[] { "Tất cả", "Giảng viên", "Cố vấn"});
            cbbRole.Location = new Point(227, 63);
            cbbRole.Name = "cbbRole";
            cbbRole.Size = new Size(207, 45);
            cbbRole.TabIndex = 9;

            // btnAdd
            btnAdd.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.White;
            btnAdd.BackColor = Color.FromArgb(0, 140, 170);
            btnAdd.Location = new Point(1000, 63);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(150, 45);
            btnAdd.TabIndex = 13;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += BtnAddGiangVien_Click;

            // panel3
            panel3.BackColor = Color.White;
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 707);
            panel3.Name = "panel3";
            panel3.Size = new Size(1319, 59);
            panel3.TabIndex = 0;

            // QLGiangVien
            AutoScaleDimensions = new SizeF(12F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1319, 766);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "QLGiangVien";
            Text = "QLGiangVien";
            panel1.ResumeLayout(false);
            pnContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)tableGV).EndInit();
            pnTop.ResumeLayout(false);
            pnTop.PerformLayout();
            pnInput.ResumeLayout(false);
            pnInput.PerformLayout();
            ResumeLayout(false);
        }

        private Panel panel1;
        private Panel pnContent;
        private ReaLTaiizor.Controls.PoisonDataGridView tableGV;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private Panel pnTop;
        private Label label3;
        private Label label2;
        private Panel pnInput;
        private TextBox txtSearch;
        private Label label1;
        private ComboBox cbbStatus;
        private ComboBox cbbRole;
        private Panel panel3;
        private Button btnAdd; // Nút Thêm
    }
}
