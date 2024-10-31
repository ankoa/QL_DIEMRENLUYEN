using System.Windows.Forms;

namespace ql_diemrenluyen.GUI.ADMIN
{
    partial class QLGiangVien
    {
        
        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            panel1 = new Panel();
            pnContent = new Panel();
            tableGV = new ReaLTaiizor.Controls.PoisonDataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            pnTop = new Panel();
            label1 = new Label();
            pnInput = new Panel();
            txtSearch = new TextBox();
            label2 = new Label();
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
            pnContent.Name = "pnContent";
            pnContent.Padding = new Padding(20, 50, 20, 0);
            pnContent.Size = new Size(1319, 536);
            pnContent.TabIndex = 8;
            // 
            // tableGV
            // 
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
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            tableGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            tableGV.ColumnHeadersHeight = 70;
            tableGV.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5 });
            tableGV.Dock = DockStyle.Fill;
            tableGV.EnableHeadersVisualStyles = false;
            tableGV.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            tableGV.GridColor = Color.FromArgb(255, 255, 255);
            tableGV.Location = new Point(20, 50);
            tableGV.MultiSelect = false;
            tableGV.Name = "tableGV";
            tableGV.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(0, 174, 219);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            tableGV.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            tableGV.RowHeadersVisible = false;
            tableGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tableGV.Size = new Size(1279, 486);
            tableGV.TabIndex = 5;
            tableGV.CellDoubleClick += tableGV_CellDoubleClick;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Giảng viên ID";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Họ tên";
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
            dataGridViewTextBoxColumn5.HeaderText = "Trạng thái";
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // pnTop
            // 
            pnTop.BackColor = Color.RoyalBlue;
            pnTop.Controls.Add(label1);
            pnTop.Controls.Add(pnInput);
            pnTop.Dock = DockStyle.Top;
            pnTop.Location = new Point(0, 20);
            pnTop.Name = "pnTop";
            pnTop.Padding = new Padding(0, 50, 0, 50);
            pnTop.Size = new Size(1319, 190);
            pnTop.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(20, 137);
            label1.Name = "label1";
            label1.Size = new Size(100, 28);
            label1.TabIndex = 32;
            label1.Text = "Tìm kiếm";
            // 
            // pnInput
            // 
            pnInput.BorderStyle = BorderStyle.FixedSingle;
            pnInput.Controls.Add(txtSearch);
            pnInput.Location = new Point(20, 78);
            pnInput.Name = "pnInput";
            pnInput.Size = new Size(358, 29);
            pnInput.TabIndex = 31;
            // 
            // txtSearch
            // 
            txtSearch.Dock = DockStyle.Right;
            txtSearch.Location = new Point(108, 0);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(248, 27);
            txtSearch.TabIndex = 34;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(20, 50);
            label2.Name = "label2";
            label2.Size = new Size(130, 28);
            label2.TabIndex = 0;
            label2.Text = "Quản lý giảng viên";
            // 
            // QLGiangVien
            // 
            AutoScaleDimensions = new SizeF(8F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1369, 786);
            Controls.Add(panel1);
            Name = "QLGiangVien";
            Text = "Quản lý giảng viên";
            panel1.ResumeLayout(false);
            pnContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)tableGV).EndInit();
            pnTop.ResumeLayout(false);
            pnTop.PerformLayout();
            pnInput.ResumeLayout(false);
            pnInput.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel pnContent;
        private ReaLTaiizor.Controls.PoisonDataGridView tableGV;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private Panel pnTop;
        private Label label1;
        private Panel pnInput;
        private TextBox txtSearch;
        private Label label2;
    }
}
