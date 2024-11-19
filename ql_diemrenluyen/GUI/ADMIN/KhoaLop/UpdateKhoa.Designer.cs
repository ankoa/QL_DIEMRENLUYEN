namespace ql_diemrenluyen.GUI.ADMIN.KhoaLop
{
    partial class UpdateKhoa
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
            text_khoa = new TextBox();
            label2 = new Label();
            update_btn = new Button();
            delete_btn = new Button();
            ma_lb = new Label();
            label3 = new Label();
            create_lb = new Label();
            label5 = new Label();
            update_lb = new Label();
            label8 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel6 = new TableLayoutPanel();
            tableLayoutPanel5 = new TableLayoutPanel();
            tableLayoutPanel4 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
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
            label1.Size = new Size(441, 48);
            label1.TabIndex = 1;
            label1.Text = "Thông tin khoa";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // text_khoa
            // 
            text_khoa.Dock = DockStyle.Fill;
            text_khoa.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            text_khoa.Location = new Point(149, 10);
            text_khoa.Margin = new Padding(3, 10, 3, 3);
            text_khoa.Name = "text_khoa";
            text_khoa.Size = new Size(289, 30);
            text_khoa.TabIndex = 1;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(3, 12);
            label2.Margin = new Padding(3, 12, 3, 0);
            label2.Name = "label2";
            label2.Size = new Size(140, 38);
            label2.TabIndex = 0;
            label2.Text = "Tên khoa\r\n";
            // 
            // update_btn
            // 
            update_btn.BackColor = Color.RoyalBlue;
            update_btn.Dock = DockStyle.Right;
            update_btn.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            update_btn.ForeColor = Color.White;
            update_btn.Location = new Point(258, 3);
            update_btn.Name = "update_btn";
            update_btn.Size = new Size(180, 47);
            update_btn.TabIndex = 3;
            update_btn.Text = "Cập nhật khoa";
            update_btn.UseVisualStyleBackColor = false;
            update_btn.Click += update_btn_Click;
            // 
            // delete_btn
            // 
            delete_btn.BackColor = Color.Red;
            delete_btn.Dock = DockStyle.Left;
            delete_btn.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            delete_btn.ForeColor = Color.White;
            delete_btn.Location = new Point(3, 3);
            delete_btn.Name = "delete_btn";
            delete_btn.Size = new Size(180, 47);
            delete_btn.TabIndex = 0;
            delete_btn.Text = "Xóa khoa";
            delete_btn.UseVisualStyleBackColor = false;
            delete_btn.Click += delete_btn_Click;
            // 
            // ma_lb
            // 
            ma_lb.AutoSize = true;
            ma_lb.Dock = DockStyle.Fill;
            ma_lb.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ma_lb.Location = new Point(149, 12);
            ma_lb.Margin = new Padding(3, 12, 3, 0);
            ma_lb.Name = "ma_lb";
            ma_lb.Size = new Size(289, 38);
            ma_lb.TabIndex = 1;
            ma_lb.Text = "label4";
            // 
            // label3
            // 
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(3, 12);
            label3.Margin = new Padding(3, 12, 3, 0);
            label3.Name = "label3";
            label3.Size = new Size(140, 38);
            label3.TabIndex = 0;
            label3.Text = "Mã khoa";
            label3.Click += label3_Click;
            // 
            // create_lb
            // 
            create_lb.AutoSize = true;
            create_lb.Dock = DockStyle.Fill;
            create_lb.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            create_lb.Location = new Point(149, 12);
            create_lb.Margin = new Padding(3, 12, 3, 0);
            create_lb.Name = "create_lb";
            create_lb.Size = new Size(289, 38);
            create_lb.TabIndex = 2;
            create_lb.Text = "label6";
            create_lb.Click += label6_Click;
            // 
            // label5
            // 
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(3, 12);
            label5.Margin = new Padding(3, 12, 3, 0);
            label5.Name = "label5";
            label5.Size = new Size(140, 38);
            label5.TabIndex = 2;
            label5.Text = "Ngày tạo ";
            // 
            // update_lb
            // 
            update_lb.AutoSize = true;
            update_lb.Dock = DockStyle.Fill;
            update_lb.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            update_lb.Location = new Point(149, 12);
            update_lb.Margin = new Padding(3, 12, 3, 0);
            update_lb.Name = "update_lb";
            update_lb.Size = new Size(289, 38);
            update_lb.TabIndex = 2;
            update_lb.Text = "label7";
            update_lb.Click += label7_Click;
            // 
            // label8
            // 
            label8.Dock = DockStyle.Fill;
            label8.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(3, 12);
            label8.Margin = new Padding(3, 12, 3, 0);
            label8.Name = "label8";
            label8.Size = new Size(140, 38);
            label8.TabIndex = 2;
            label8.Text = "Ngày cập nhật";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel6, 0, 5);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel5, 0, 4);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel4, 0, 3);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 2);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.6341467F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 17.0731716F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 17.0731716F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 17.0731716F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 17.0731716F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 17.0731716F));
            tableLayoutPanel1.Size = new Size(447, 331);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 2;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.Controls.Add(update_btn, 1, 0);
            tableLayoutPanel6.Controls.Add(delete_btn, 0, 0);
            tableLayoutPanel6.Dock = DockStyle.Fill;
            tableLayoutPanel6.Location = new Point(3, 275);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 1;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel6.Size = new Size(441, 53);
            tableLayoutPanel6.TabIndex = 7;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 2;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 66.6666641F));
            tableLayoutPanel5.Controls.Add(update_lb, 1, 0);
            tableLayoutPanel5.Controls.Add(label8, 0, 0);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(3, 219);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel5.Size = new Size(441, 50);
            tableLayoutPanel5.TabIndex = 7;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 66.6666641F));
            tableLayoutPanel4.Controls.Add(create_lb, 1, 0);
            tableLayoutPanel4.Controls.Add(label5, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 163);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.Size = new Size(441, 50);
            tableLayoutPanel4.TabIndex = 7;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 66.6666641F));
            tableLayoutPanel3.Controls.Add(text_khoa, 1, 0);
            tableLayoutPanel3.Controls.Add(label2, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 107);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Size = new Size(441, 50);
            tableLayoutPanel3.TabIndex = 7;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 66.6666641F));
            tableLayoutPanel2.Controls.Add(ma_lb, 1, 0);
            tableLayoutPanel2.Controls.Add(label3, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 51);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(441, 50);
            tableLayoutPanel2.TabIndex = 7;
            // 
            // UpdateKhoa
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(447, 331);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UpdateKhoa";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UpdateKhoa";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel6.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
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
        private TextBox text_khoa;
        private Label label2;
        private Button update_btn;
        private Button delete_btn;
        private Label ma_lb;
        private Label label3;
        private Label create_lb;
        private Label label5;
        private Label update_lb;
        private Label label8;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel6;
        private TableLayoutPanel tableLayoutPanel5;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel3;
    }
}