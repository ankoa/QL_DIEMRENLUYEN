namespace ql_diemrenluyen.GUI.ADMIN
{
    partial class TaiKhoan
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            flowLayoutPanel1 = new FlowLayoutPanel();
            pnTop = new Panel();
            txtFind = new ReaLTaiizor.Controls.TextBoxEdit();
            label1 = new Label();
            flowLayoutPanel2 = new FlowLayoutPanel();
            tableTK = new ReaLTaiizor.Controls.PoisonDataGridView();
            btnADD = new Button();
            cbbRole = new ComboBox();
            cbbStatus = new ComboBox();
            flowLayoutPanel1.SuspendLayout();
            pnTop.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tableTK).BeginInit();
            SuspendLayout();

            // Cấu hình thêm các cột cho bảng tableTK
            tableTK.Columns.Add("Column1", "Tài khoản ID");
            tableTK.Columns.Add("Column2", "Tên người dùng");
            tableTK.Columns.Add("Column3", "Quyền");
            tableTK.Columns.Add("Column4", "Trạng thái");

            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(pnTop);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel2);
            flowLayoutPanel1.Location = new Point(1, 3);
            flowLayoutPanel1.Margin = new Padding(20);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1200, 680);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // pnTop
            // 
            pnTop.Controls.Add(cbbStatus);
            pnTop.Controls.Add(cbbRole);
            pnTop.Controls.Add(btnADD);
            pnTop.Controls.Add(txtFind);
            pnTop.Controls.Add(label1);
            pnTop.Location = new Point(3, 3);
            pnTop.Name = "pnTop";
            pnTop.Size = new Size(1197, 151);
            pnTop.TabIndex = 0;
            // 
            // txtFind
            // 
            txtFind.BackColor = Color.BlanchedAlmond;
            txtFind.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFind.ForeColor = Color.Black;
            txtFind.Image = null;
            txtFind.Location = new Point(207, 17);
            txtFind.MaxLength = 32767;
            txtFind.Multiline = false;
            txtFind.Name = "txtFind";
            txtFind.ReadOnly = false;
            txtFind.Size = new Size(403, 50);
            txtFind.TabIndex = 1;
            txtFind.Text = "textBoxEdit1";
            txtFind.TextAlignment = HorizontalAlignment.Left;
            txtFind.UseSystemPasswordChar = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(110, 30);
            label1.Name = "label1";
            label1.Size = new Size(91, 28);
            label1.TabIndex = 0;
            label1.Text = "Tìm kiếm";
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(tableTK);
            flowLayoutPanel2.Location = new Point(3, 160);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(1197, 520);
            flowLayoutPanel2.TabIndex = 1;
            // 
            // tableTK
            // 
            tableTK.AllowUserToAddRows = false;
            tableTK.AllowUserToDeleteRows = false;
            tableTK.AllowUserToResizeRows = false;
            tableTK.BackgroundColor = Color.FromArgb(192, 255, 255);
            tableTK.BorderStyle = BorderStyle.Fixed3D;
            tableTK.CellBorderStyle = DataGridViewCellBorderStyle.None;
            tableTK.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(0, 174, 219);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(0, 198, 247);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            tableTK.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            tableTK.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(136, 136, 136);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(0, 198, 247);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            tableTK.DefaultCellStyle = dataGridViewCellStyle2;
            tableTK.EnableHeadersVisualStyles = false;
            tableTK.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            tableTK.GridColor = Color.FromArgb(192, 255, 255);
            tableTK.Location = new Point(10, 10);
            tableTK.Margin = new Padding(10, 10, 0, 0);
            tableTK.Name = "tableTK";
            tableTK.ReadOnly = true;
            tableTK.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(0, 174, 219);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(0, 198, 247);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            tableTK.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            tableTK.RowHeadersWidth = 51;
            tableTK.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            tableTK.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tableTK.Size = new Size(1175, 499);
            tableTK.TabIndex = 0;

            // Thêm các cột cho tableTK
            tableTK.Columns.Add("ID", "Tài khoản ID");
            tableTK.Columns.Add("UserName", "Tên người dùng");
            tableTK.Columns.Add("Role", "Quyền");
            tableTK.Columns.Add("Status", "Trạng thái");

            // 
            // btnADD
            // 
            btnADD.BackColor = SystemColors.ActiveCaption;
            btnADD.Location = new Point(1026, 74);
            btnADD.Name = "btnADD";
            btnADD.Size = new Size(159, 59);
            btnADD.TabIndex = 2;
            btnADD.Text = "Thêm tài khoản";
            btnADD.UseVisualStyleBackColor = false;
            // 
            // cbbRole
            // 
            cbbRole.FormattingEnabled = true;
            cbbRole.Location = new Point(110, 90);
            cbbRole.Name = "cbbRole";
            cbbRole.Size = new Size(151, 28);
            cbbRole.TabIndex = 3;
            // 
            // cbbStatus
            // 
            cbbStatus.FormattingEnabled = true;
            cbbStatus.Location = new Point(287, 90);
            cbbStatus.Name = "cbbStatus";
            cbbStatus.Size = new Size(152, 28);
            cbbStatus.TabIndex = 4;
            // 
            // TaiKhoan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1187, 679);
            Controls.Add(flowLayoutPanel1);
            Name = "TaiKhoan";
            Text = "Tài Khoản";
            flowLayoutPanel1.ResumeLayout(false);
            pnTop.ResumeLayout(false);
            pnTop.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)tableTK).EndInit();
            ResumeLayout(false);
        }


        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Panel pnTop;
        private Label label1;
        private ReaLTaiizor.Controls.TextBoxEdit txtFind;
        private FlowLayoutPanel flowLayoutPanel2;
        private ReaLTaiizor.Controls.PoisonDataGridView tableTK;
        private ComboBox cbbRole;
        private Button btnADD;
        private ComboBox cbbStatus;
    }
}