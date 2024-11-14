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
            panel1 = new Panel();
            text_khoa = new TextBox();
            label2 = new Label();
            panel2 = new Panel();
            update_btn = new Button();
            delete_btn = new Button();
            panel3 = new Panel();
            ma_lb = new Label();
            label3 = new Label();
            panel4 = new Panel();
            create_lb = new Label();
            label5 = new Label();
            panel5 = new Panel();
            update_lb = new Label();
            label8 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(403, 45);
            label1.TabIndex = 1;
            label1.Text = "Thông tin khoa";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(text_khoa);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(7, 91);
            panel1.Name = "panel1";
            panel1.Size = new Size(388, 37);
            panel1.TabIndex = 2;
            // 
            // text_khoa
            // 
            text_khoa.Location = new Point(117, 3);
            text_khoa.Name = "text_khoa";
            text_khoa.Size = new Size(268, 27);
            text_khoa.TabIndex = 1;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(5, 6);
            label2.Name = "label2";
            label2.Size = new Size(72, 30);
            label2.TabIndex = 0;
            label2.Text = "Tên khoa\r\n";
            // 
            // panel2
            // 
            panel2.Controls.Add(update_btn);
            panel2.Controls.Add(delete_btn);
            panel2.Location = new Point(12, 220);
            panel2.Name = "panel2";
            panel2.Size = new Size(380, 43);
            panel2.TabIndex = 3;
            // 
            // update_btn
            // 
            update_btn.Dock = DockStyle.Right;
            update_btn.Location = new Point(200, 0);
            update_btn.Name = "update_btn";
            update_btn.Size = new Size(180, 43);
            update_btn.TabIndex = 3;
            update_btn.Text = "Cập nhật";
            update_btn.UseVisualStyleBackColor = true;
            update_btn.Click += update_btn_Click;
            // 
            // delete_btn
            // 
            delete_btn.Dock = DockStyle.Left;
            delete_btn.Location = new Point(0, 0);
            delete_btn.Name = "delete_btn";
            delete_btn.Size = new Size(180, 43);
            delete_btn.TabIndex = 0;
            delete_btn.Text = "Xóa ";
            delete_btn.UseVisualStyleBackColor = true;
            delete_btn.Click += delete_btn_Click;
            // 
            // panel3
            // 
            panel3.AutoSize = true;
            panel3.Controls.Add(ma_lb);
            panel3.Controls.Add(label3);
            panel3.Location = new Point(7, 48);
            panel3.Name = "panel3";
            panel3.Size = new Size(388, 37);
            panel3.TabIndex = 3;
            // 
            // ma_lb
            // 
            ma_lb.AutoSize = true;
            ma_lb.Location = new Point(117, 7);
            ma_lb.Name = "ma_lb";
            ma_lb.Size = new Size(50, 20);
            ma_lb.TabIndex = 1;
            ma_lb.Text = "label4";
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(5, 7);
            label3.Name = "label3";
            label3.Size = new Size(72, 30);
            label3.TabIndex = 0;
            label3.Text = "Mã khoa";
            label3.Click += label3_Click;
            // 
            // panel4
            // 
            panel4.Controls.Add(create_lb);
            panel4.Controls.Add(label5);
            panel4.Location = new Point(7, 134);
            panel4.Name = "panel4";
            panel4.Size = new Size(388, 37);
            panel4.TabIndex = 4;
            // 
            // create_lb
            // 
            create_lb.AutoSize = true;
            create_lb.Location = new Point(117, 7);
            create_lb.Name = "create_lb";
            create_lb.Size = new Size(50, 20);
            create_lb.TabIndex = 2;
            create_lb.Text = "label6";
            create_lb.Click += label6_Click;
            // 
            // label5
            // 
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(3, 7);
            label5.Name = "label5";
            label5.Size = new Size(72, 30);
            label5.TabIndex = 2;
            label5.Text = "Ngày tạo :";
            // 
            // panel5
            // 
            panel5.Controls.Add(update_lb);
            panel5.Controls.Add(label8);
            panel5.Location = new Point(7, 177);
            panel5.Name = "panel5";
            panel5.Size = new Size(388, 37);
            panel5.TabIndex = 5;
            // 
            // update_lb
            // 
            update_lb.AutoSize = true;
            update_lb.Location = new Point(117, 7);
            update_lb.Name = "update_lb";
            update_lb.Size = new Size(50, 20);
            update_lb.TabIndex = 2;
            update_lb.Text = "label7";
            update_lb.Click += label7_Click;
            // 
            // label8
            // 
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(3, 7);
            label8.Name = "label8";
            label8.Size = new Size(108, 30);
            label8.TabIndex = 2;
            label8.Text = "Ngày cập nhật";
            // 
            // UpdateKhoa
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(403, 274);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "UpdateKhoa";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UpdateKhoa";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private TextBox text_khoa;
        private Label label2;
        private Panel panel2;
        private Button update_btn;
        private Button delete_btn;
        private Panel panel3;
        private Label ma_lb;
        private Label label3;
        private Panel panel4;
        private Label create_lb;
        private Label label5;
        private Panel panel5;
        private Label update_lb;
        private Label label8;
    }
}