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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            panel1 = new Panel();
            pnContent = new Panel();
            tableGV = new ReaLTaiizor.Controls.PoisonDataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            pnTop = new Panel();
            label3 = new Label();
            label2 = new Label();
            pnInput = new Panel();
            txtSearch = new TextBox();
            label1 = new Label();
            cbbStatus = new ComboBox();
            cbbRole = new ComboBox();
            panel3 = new Panel();
            panel1.SuspendLayout();
            pnContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tableGV).BeginInit();
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
            panel1.Location = new Point(50, 20);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(0, 20, 0, 0);
            panel1.Size = new Size(1319, 746);
            panel1.TabIndex = 5;

            // 
            // pnContent
            // 
            pnContent.AutoScroll = true;
            pnContent.BackColor = SystemColors.ControlLightLight;
            pnContent.Controls.Add(tableGV);
            pnContent.Dock = DockStyle.Fill;
            pnContent.Location = new Point(0, 210);
            pnContent.Margin = new Padding(0);
            pnContent.Name = "pnContent";
            pnContent.Padding = new Padding(20, 50, 20, 0);
            pnContent.Size = new Size(1319, 536);
            pnContent.TabIndex = 8;

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

            // Set up header style
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(0, 174, 219);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(255, 255, 255);
            tableGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            tableGV.ColumnHeadersHeight = 70;
            tableGV.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6 });
            tableGV.Dock = DockStyle.Fill;

            // Set up default cell style
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(136, 136, 136);
            tableGV.DefaultCellStyle = dataGridViewCellStyle2;

            tableGV.EnableHeadersVisualStyles = false;
            tableGV.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            tableGV.GridColor = Color.FromArgb(255, 255, 255);
            tableGV.Location = new Point(20, 50);
            tableGV.MultiSelect = false;
            tableGV.Name = "tableGV";
            tableGV.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // Set up row header style
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(0, 174, 219);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tableGV.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            tableGV.RowHeadersVisible = false;
            tableGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tableGV.Size = new Size(1279, 486);
            tableGV.TabIndex = 5;

            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Giảng viên ID";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";

            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Tên Giảng viên";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";

            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Chuyên ngành";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";

            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Email";
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";

            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Ngày sinh";
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";

            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.HeaderText = "Trạng thái";
            dataGridViewTextBoxColumn6.MinimumWidth = 6;
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";

            // 
            // pnTop
            // 
            pnTop.BackColor = Color.RoyalBlue;
            pnTop.Controls.Add(label3);
            pnTop.Controls.Add(label2);
            pnTop.Controls.Add(pnInput);
            pnTop.Controls.Add(cbbStatus);
            pnTop.Controls.Add(cbbRole);
            pnTop.Dock = DockStyle.Top;
            pnTop.Location = new Point(0, 20);
            pnTop.Name = "pnTop";
            pnTop.Padding = new Padding(0, 50, 0, 50);
            pnTop.Size = new Size(1319, 190);
            pnTop.TabIndex = 7;

            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(131, 63);
            label3.Name = "label3";
            label3.Size = new Size(138, 28);
            label3.TabIndex = 3;
            label3.Text = "Quản lý Giảng viên";

            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(804, 122);
            label2.Name = "label2";
            label2.Size = new Size(137, 28);
            label2.TabIndex = 2;
            label2.Text = "Trạng thái:";

            // 
            // pnInput
            // 
            pnInput.Controls.Add(txtSearch);
            pnInput.Controls.Add(label1);
            pnInput.Location = new Point(50, 122);
            pnInput.Name = "pnInput";
            pnInput.Size = new Size(390, 55);
            pnInput.TabIndex = 1;

            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(175, 10);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(213, 29);
            txtSearch.TabIndex = 1;

            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 13);
            label1.Name = "label1";
            label1.Size = new Size(166, 21);
            label1.TabIndex = 0;
            label1.Text = "Tìm kiếm giảng viên:";

            // 
            // cbbStatus
            // 
            cbbStatus.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbbStatus.FormattingEnabled = true;
            cbbStatus.Items.AddRange(new object[] { "Đang dạy", "Nghỉ hưu", "Tạm nghỉ" });
            cbbStatus.Location = new Point(1005, 122);
            cbbStatus.Name = "cbbStatus";
            cbbStatus.Size = new Size(213, 29);
            cbbStatus.TabIndex = 0;

            // 
            // cbbRole
            // 
            cbbRole.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbbRole.FormattingEnabled = true;
            cbbRole.Items.AddRange(new object[] { "Giảng viên", "Trợ giảng", "Giảng viên thỉnh giảng" });
            cbbRole.Location = new Point(1005, 63);
            cbbRole.Name = "cbbRole";
            cbbRole.Size = new Size(213, 29);
            cbbRole.TabIndex = 0;

            // 
            // panel3
            // 
            panel3.BackColor = Color.Red;
            panel3.Location = new Point(0, 190);
            panel3.Name = "panel3";
            panel3.Size = new Size(1319, 50);
            panel3.TabIndex = 8;

            // 
            // QLGiangVien
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1319, 766);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
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
        private Panel pnTop;
        private Label label3;
        private Label label2;
        private Panel pnInput;
        private TextBox txtSearch;
        private Label label1;
        private ComboBox cbbStatus;
        private ComboBox cbbRole;
        private Panel panel3;
    }
}
