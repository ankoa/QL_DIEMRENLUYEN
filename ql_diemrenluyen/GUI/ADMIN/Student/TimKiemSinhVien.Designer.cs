namespace QLDiemRenLuyen
{
    partial class TimKiemSinhVien
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            label1 = new Label();
            panel3 = new Panel();
            txtMaSV = new TextBox();
            label2 = new Label();
            panel2 = new Panel();
            txtHoTen = new TextBox();
            label3 = new Label();
            panel4 = new Panel();
            cBLop = new ComboBox();
            label4 = new Label();
            panel5 = new Panel();
            cBKhoa = new ComboBox();
            label5 = new Label();
            button1 = new Button();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.MenuHighlight;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 1);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(593, 61);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(105, 12);
            label1.Name = "label1";
            label1.Size = new Size(256, 37);
            label1.TabIndex = 0;
            label1.Text = "Tìm kiếm sinh viên";
            // 
            // panel3
            // 
            panel3.Controls.Add(txtMaSV);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(3, 66);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(476, 40);
            panel3.TabIndex = 1;
            // 
            // txtMaSV
            // 
            txtMaSV.Location = new Point(148, 8);
            txtMaSV.Margin = new Padding(3, 2, 3, 2);
            txtMaSV.Name = "txtMaSV";
            txtMaSV.Size = new Size(323, 23);
            txtMaSV.TabIndex = 1;
            txtMaSV.TextChanged += txtMaSV_TextChanged;
            txtMaSV.KeyPress += txtMaSV_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(-2, 7);
            label2.Name = "label2";
            label2.Size = new Size(100, 21);
            label2.TabIndex = 0;
            label2.Text = "Mã sinh viên";
            // 
            // panel2
            // 
            panel2.Controls.Add(txtHoTen);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(3, 110);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(476, 40);
            panel2.TabIndex = 2;
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(148, 8);
            txtHoTen.Margin = new Padding(3, 2, 3, 2);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(323, 23);
            txtHoTen.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(-2, 7);
            label3.Name = "label3";
            label3.Size = new Size(80, 21);
            label3.TabIndex = 0;
            label3.Text = "Họ và tên";
            // 
            // panel4
            // 
            panel4.Controls.Add(cBLop);
            panel4.Controls.Add(label4);
            panel4.Location = new Point(3, 158);
            panel4.Margin = new Padding(3, 2, 3, 2);
            panel4.Name = "panel4";
            panel4.Size = new Size(476, 40);
            panel4.TabIndex = 3;
            // 
            // cBLop
            // 
            cBLop.FormattingEnabled = true;
            cBLop.Location = new Point(146, 10);
            cBLop.Margin = new Padding(3, 2, 3, 2);
            cBLop.Name = "cBLop";
            cBLop.Size = new Size(325, 23);
            cBLop.TabIndex = 1;
            cBLop.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            cBLop.SelectionChangeCommitted += cBLop_SelectionChangeCommitted;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(-2, 7);
            label4.Name = "label4";
            label4.Size = new Size(38, 21);
            label4.TabIndex = 0;
            label4.Text = "Lớp";
            // 
            // panel5
            // 
            panel5.Controls.Add(cBKhoa);
            panel5.Controls.Add(label5);
            panel5.Location = new Point(3, 213);
            panel5.Margin = new Padding(3, 2, 3, 2);
            panel5.Name = "panel5";
            panel5.Size = new Size(476, 40);
            panel5.TabIndex = 4;
            // 
            // cBKhoa
            // 
            cBKhoa.FormattingEnabled = true;
            cBKhoa.Location = new Point(146, 10);
            cBKhoa.Margin = new Padding(3, 2, 3, 2);
            cBKhoa.Name = "cBKhoa";
            cBKhoa.Size = new Size(325, 23);
            cBKhoa.TabIndex = 1;
            cBKhoa.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            cBKhoa.SelectionChangeCommitted += cBKhoa_SelectionChangeCommitted;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(-2, 7);
            label5.Name = "label5";
            label5.Size = new Size(47, 21);
            label5.TabIndex = 0;
            label5.Text = "Khoa";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.HotTrack;
            button1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.HighlightText;
            button1.Location = new Point(138, 284);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(195, 53);
            button1.TabIndex = 5;
            button1.Text = "Tìm kiếm";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // TimKiemSinhVien
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(481, 360);
            Controls.Add(button1);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel2);
            Controls.Add(panel3);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "TimKiemSinhVien";
            StartPosition = FormStartPosition.CenterScreen;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel3;
        private TextBox txtMaSV;
        private Label label2;
        private Panel panel2;
        private TextBox txtHoTen;
        private Label label3;
        private Panel panel4;
        private ComboBox cBLop;
        private Label label4;
        private Panel panel5;
        private ComboBox cBKhoa;
        private Label label5;
        private Button button1;
    }
}
