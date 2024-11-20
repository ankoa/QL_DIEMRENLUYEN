namespace ql_diemrenluyen.GUI.ADMIN.KhoaLop
{
    partial class AddLop
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
            label1 = new Label();
            text_lop = new TextBox();
            label2 = new Label();
            Khoa_cbb = new ComboBox();
            label3 = new Label();
            Hdt_cbb = new ComboBox();
            label4 = new Label();
            reset_btn = new Button();
            add_btn = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel5 = new TableLayoutPanel();
            tableLayoutPanel4 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.RoyalBlue;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(438, 51);
            label1.TabIndex = 0;
            label1.Text = "Thêm lớp";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // text_lop
            // 
            text_lop.Dock = DockStyle.Fill;
            text_lop.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            text_lop.Location = new Point(107, 10);
            text_lop.Margin = new Padding(3, 10, 3, 3);
            text_lop.Name = "text_lop";
            text_lop.Size = new Size(328, 30);
            text_lop.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(3, 12);
            label2.Margin = new Padding(3, 12, 3, 0);
            label2.Name = "label2";
            label2.Size = new Size(70, 23);
            label2.TabIndex = 0;
            label2.Text = "Tên lớp ";
            label2.Click += label2_Click;
            // 
            // Khoa_cbb
            // 
            Khoa_cbb.Dock = DockStyle.Fill;
            Khoa_cbb.DropDownStyle = ComboBoxStyle.DropDownList;
            Khoa_cbb.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Khoa_cbb.FormattingEnabled = true;
            Khoa_cbb.Location = new Point(107, 10);
            Khoa_cbb.Margin = new Padding(3, 10, 3, 3);
            Khoa_cbb.Name = "Khoa_cbb";
            Khoa_cbb.Size = new Size(328, 31);
            Khoa_cbb.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(3, 12);
            label3.Margin = new Padding(3, 12, 3, 0);
            label3.Name = "label3";
            label3.Size = new Size(49, 23);
            label3.TabIndex = 0;
            label3.Text = "Khoa";
            // 
            // Hdt_cbb
            // 
            Hdt_cbb.Dock = DockStyle.Fill;
            Hdt_cbb.DropDownStyle = ComboBoxStyle.DropDownList;
            Hdt_cbb.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Hdt_cbb.FormattingEnabled = true;
            Hdt_cbb.Location = new Point(107, 10);
            Hdt_cbb.Margin = new Padding(3, 10, 3, 3);
            Hdt_cbb.Name = "Hdt_cbb";
            Hdt_cbb.Size = new Size(328, 31);
            Hdt_cbb.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(3, 12);
            label4.Margin = new Padding(3, 12, 3, 0);
            label4.Name = "label4";
            label4.Size = new Size(95, 23);
            label4.TabIndex = 0;
            label4.Text = "Hệ đào tạo";
            // 
            // reset_btn
            // 
            reset_btn.Dock = DockStyle.Left;
            reset_btn.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            reset_btn.Location = new Point(3, 3);
            reset_btn.Name = "reset_btn";
            reset_btn.Size = new Size(195, 49);
            reset_btn.TabIndex = 3;
            reset_btn.Text = "Xóa trắng";
            reset_btn.UseVisualStyleBackColor = true;
            // 
            // add_btn
            // 
            add_btn.BackColor = Color.RoyalBlue;
            add_btn.Dock = DockStyle.Right;
            add_btn.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            add_btn.ForeColor = Color.White;
            add_btn.Location = new Point(240, 3);
            add_btn.Name = "add_btn";
            add_btn.Size = new Size(195, 49);
            add_btn.TabIndex = 4;
            add_btn.Text = "Thêm lớp";
            add_btn.UseVisualStyleBackColor = false;
            add_btn.Click += add_btn_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel5, 0, 4);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel4, 0, 3);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 2);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 17.6470585F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20.5882359F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20.5882359F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20.5882359F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20.5882359F));
            tableLayoutPanel1.Size = new Size(444, 292);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 2;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Controls.Add(add_btn, 1, 0);
            tableLayoutPanel5.Controls.Add(reset_btn, 0, 0);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(3, 234);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel5.Size = new Size(438, 55);
            tableLayoutPanel5.TabIndex = 6;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.8095245F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 76.1904755F));
            tableLayoutPanel4.Controls.Add(Hdt_cbb, 1, 0);
            tableLayoutPanel4.Controls.Add(label4, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 174);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Size = new Size(438, 54);
            tableLayoutPanel4.TabIndex = 6;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.8095245F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 76.1904755F));
            tableLayoutPanel3.Controls.Add(Khoa_cbb, 1, 0);
            tableLayoutPanel3.Controls.Add(label3, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 114);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(438, 54);
            tableLayoutPanel3.TabIndex = 6;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.8095245F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 76.1904755F));
            tableLayoutPanel2.Controls.Add(text_lop, 1, 0);
            tableLayoutPanel2.Controls.Add(label2, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 54);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(438, 54);
            tableLayoutPanel2.TabIndex = 6;
            // 
            // AddLop
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(444, 292);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddLop";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddLop";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private TextBox text_lop;
        private Label label2;
        private ComboBox Khoa_cbb;
        private Label label3;
        private ComboBox Hdt_cbb;
        private Label label4;
        private Button reset_btn;
        private Button add_btn;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel5;
        private TableLayoutPanel tableLayoutPanel4;
    }
}