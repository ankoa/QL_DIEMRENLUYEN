namespace ql_diemrenluyen.GUI.ADMIN.KhoaLop
{
    partial class UpdateLop
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
            panel4 = new Panel();
            ib_lb = new Label();
            label5 = new Label();
            panel5 = new Panel();
            created_lb = new Label();
            label8 = new Label();
            panel6 = new Panel();
            updated_lb = new Label();
            label10 = new Label();
            delete_lop = new Button();
            update_lop = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(699, 43);
            label1.TabIndex = 1;
            label1.Text = "Thông tin lớp";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            panel1.Controls.Add(text_lop);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(358, 46);
            panel1.Name = "panel1";
            panel1.Size = new Size(332, 37);
            panel1.TabIndex = 2;
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
            label2.Location = new Point(3, 6);
            label2.Name = "label2";
            label2.Size = new Size(65, 20);
            label2.TabIndex = 0;
            label2.Text = "Tên lớp :";
            // 
            // panel2
            // 
            panel2.Controls.Add(Khoa_cbb);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(10, 89);
            panel2.Name = "panel2";
            panel2.Size = new Size(332, 37);
            panel2.TabIndex = 3;
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
            panel3.Location = new Point(358, 89);
            panel3.Name = "panel3";
            panel3.Size = new Size(332, 37);
            panel3.TabIndex = 4;
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
            label4.Location = new Point(3, 6);
            label4.Name = "label4";
            label4.Size = new Size(84, 20);
            label4.TabIndex = 0;
            label4.Text = "Hệ đào tạo";
            // 
            // panel4
            // 
            panel4.Controls.Add(ib_lb);
            panel4.Controls.Add(label5);
            panel4.Location = new Point(10, 46);
            panel4.Name = "panel4";
            panel4.Size = new Size(332, 37);
            panel4.TabIndex = 3;
            // 
            // ib_lb
            // 
            ib_lb.AutoSize = true;
            ib_lb.Location = new Point(93, 6);
            ib_lb.Name = "ib_lb";
            ib_lb.Size = new Size(50, 20);
            ib_lb.TabIndex = 1;
            ib_lb.Text = "label6";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 6);
            label5.Name = "label5";
            label5.Size = new Size(63, 20);
            label5.TabIndex = 0;
            label5.Text = "Mã lớp :";
            // 
            // panel5
            // 
            panel5.Controls.Add(created_lb);
            panel5.Controls.Add(label8);
            panel5.Location = new Point(10, 132);
            panel5.Name = "panel5";
            panel5.Size = new Size(332, 37);
            panel5.TabIndex = 4;
            // 
            // created_lb
            // 
            created_lb.AutoSize = true;
            created_lb.Location = new Point(93, 6);
            created_lb.Name = "created_lb";
            created_lb.Size = new Size(50, 20);
            created_lb.TabIndex = 1;
            created_lb.Text = "label7";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(3, 6);
            label8.Name = "label8";
            label8.Size = new Size(77, 20);
            label8.TabIndex = 0;
            label8.Text = "Ngày tạo :";
            // 
            // panel6
            // 
            panel6.Controls.Add(updated_lb);
            panel6.Controls.Add(label10);
            panel6.Location = new Point(358, 132);
            panel6.Name = "panel6";
            panel6.Size = new Size(332, 37);
            panel6.TabIndex = 5;
            // 
            // updated_lb
            // 
            updated_lb.AutoSize = true;
            updated_lb.Location = new Point(121, 6);
            updated_lb.Name = "updated_lb";
            updated_lb.Size = new Size(50, 20);
            updated_lb.TabIndex = 1;
            updated_lb.Text = "label9";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(3, 6);
            label10.Name = "label10";
            label10.Size = new Size(112, 20);
            label10.TabIndex = 0;
            label10.Text = "Ngày cập nhật :";
            // 
            // delete_lop
            // 
            delete_lop.Location = new Point(13, 175);
            delete_lop.Name = "delete_lop";
            delete_lop.Size = new Size(329, 39);
            delete_lop.TabIndex = 6;
            delete_lop.Text = "Xóa lớp";
            delete_lop.UseVisualStyleBackColor = true;
            delete_lop.Click += delete_lop_Click;
            // 
            // update_lop
            // 
            update_lop.Location = new Point(358, 175);
            update_lop.Name = "update_lop";
            update_lop.Size = new Size(326, 39);
            update_lop.TabIndex = 7;
            update_lop.Text = "Cập nhật lớp";
            update_lop.UseVisualStyleBackColor = true;
            update_lop.Click += update_btn_Click;
            // 
            // UpdateLop
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(699, 227);
            Controls.Add(update_lop);
            Controls.Add(delete_lop);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "UpdateLop";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UpdateLop";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
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
        private Panel panel4;
        private Label ib_lb;
        private Label label5;
        private Panel panel5;
        private Label created_lb;
        private Label label8;
        private Panel panel6;
        private Label updated_lb;
        private Label label10;
        private Button delete_lop;
        private Button update_lop;
    }
}