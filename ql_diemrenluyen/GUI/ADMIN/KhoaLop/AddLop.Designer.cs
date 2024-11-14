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
            panel1 = new Panel();
            text_lop = new TextBox();
            label2 = new Label();
            panel2 = new Panel();
            Khoa_cbb = new ComboBox();
            label3 = new Label();
            panel3 = new Panel();
            Hdt_cbb = new ComboBox();
            label4 = new Label();
            reset_btn = new Button();
            add_btn = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(355, 47);
            label1.TabIndex = 0;
            label1.Text = "Thêm lớp";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            panel1.Controls.Add(text_lop);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(12, 50);
            panel1.Name = "panel1";
            panel1.Size = new Size(332, 37);
            panel1.TabIndex = 1;
            // 
            // text_lop
            // 
            text_lop.Location = new Point(93, 3);
            text_lop.Name = "text_lop";
            text_lop.Size = new Size(233, 27);
            text_lop.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F);
            label2.Location = new Point(3, 6);
            label2.Name = "label2";
            label2.Size = new Size(65, 20);
            label2.TabIndex = 0;
            label2.Text = "Tên lớp :";
            label2.Click += label2_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(Khoa_cbb);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(12, 93);
            panel2.Name = "panel2";
            panel2.Size = new Size(332, 37);
            panel2.TabIndex = 2;
            // 
            // Khoa_cbb
            // 
            Khoa_cbb.DropDownStyle = ComboBoxStyle.DropDownList;
            Khoa_cbb.FormattingEnabled = true;
            Khoa_cbb.Location = new Point(93, 3);
            Khoa_cbb.Name = "Khoa_cbb";
            Khoa_cbb.Size = new Size(233, 28);
            Khoa_cbb.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F);
            label3.Location = new Point(3, 6);
            label3.Name = "label3";
            label3.Size = new Size(43, 20);
            label3.TabIndex = 0;
            label3.Text = "Khoa";
            // 
            // panel3
            // 
            panel3.Controls.Add(Hdt_cbb);
            panel3.Controls.Add(label4);
            panel3.Location = new Point(12, 136);
            panel3.Name = "panel3";
            panel3.Size = new Size(332, 37);
            panel3.TabIndex = 2;
            // 
            // Hdt_cbb
            // 
            Hdt_cbb.DropDownStyle = ComboBoxStyle.DropDownList;
            Hdt_cbb.FormattingEnabled = true;
            Hdt_cbb.Location = new Point(93, 3);
            Hdt_cbb.Name = "Hdt_cbb";
            Hdt_cbb.Size = new Size(233, 28);
            Hdt_cbb.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F);
            label4.Location = new Point(3, 6);
            label4.Name = "label4";
            label4.Size = new Size(84, 20);
            label4.TabIndex = 0;
            label4.Text = "Hệ đào tạo";
            // 
            // reset_btn
            // 
            reset_btn.Location = new Point(15, 184);
            reset_btn.Name = "reset_btn";
            reset_btn.Size = new Size(152, 43);
            reset_btn.TabIndex = 3;
            reset_btn.Text = "Xóa trắng";
            reset_btn.UseVisualStyleBackColor = true;
            // 
            // add_btn
            // 
            add_btn.Location = new Point(188, 184);
            add_btn.Name = "add_btn";
            add_btn.Size = new Size(150, 43);
            add_btn.TabIndex = 4;
            add_btn.Text = "Thêm lớp";
            add_btn.UseVisualStyleBackColor = true;
            add_btn.Click += add_btn_Click;
            // 
            // AddLop
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(355, 239);
            Controls.Add(add_btn);
            Controls.Add(reset_btn);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "AddLop";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddLop";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private TextBox text_lop;
        private Label label2;
        private Panel panel2;
        private ComboBox Khoa_cbb;
        private Label label3;
        private Panel panel3;
        private ComboBox Hdt_cbb;
        private Label label4;
        private Button reset_btn;
        private Button add_btn;
    }
}