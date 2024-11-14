namespace ql_diemrenluyen.GUI.ADMIN.KhoaLop
{
    partial class UpdateHeHoc
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
            ma_lb = new Label();
            label2 = new Label();
            text_hehoc = new TextBox();
            panel2 = new Panel();
            update_btn = new Button();
            delete_btn = new Button();
            panel3 = new Panel();
            label3 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = SystemColors.Control;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(397, 42);
            label1.TabIndex = 2;
            label1.Text = "Thông tin hệ học";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(ma_lb);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(12, 51);
            panel1.Name = "panel1";
            panel1.Size = new Size(372, 37);
            panel1.TabIndex = 3;
            // 
            // ma_lb
            // 
            ma_lb.AutoSize = true;
            ma_lb.Location = new Point(95, 3);
            ma_lb.Name = "ma_lb";
            ma_lb.Size = new Size(50, 20);
            ma_lb.TabIndex = 1;
            ma_lb.Text = "label4";
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 9F);
            label2.Location = new Point(0, 3);
            label2.Name = "label2";
            label2.Size = new Size(89, 27);
            label2.TabIndex = 0;
            label2.Text = "Mã hệ học";
            // 
            // text_hehoc
            // 
            text_hehoc.Location = new Point(89, 3);
            text_hehoc.Name = "text_hehoc";
            text_hehoc.Size = new Size(283, 27);
            text_hehoc.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(update_btn);
            panel2.Controls.Add(delete_btn);
            panel2.Location = new Point(12, 137);
            panel2.Name = "panel2";
            panel2.Size = new Size(372, 43);
            panel2.TabIndex = 4;
            // 
            // update_btn
            // 
            update_btn.BackColor = Color.White;
            update_btn.Dock = DockStyle.Right;
            update_btn.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            update_btn.Location = new Point(192, 0);
            update_btn.Name = "update_btn";
            update_btn.Size = new Size(180, 43);
            update_btn.TabIndex = 3;
            update_btn.Text = "Cập nhật hệ học";
            update_btn.UseVisualStyleBackColor = false;
            update_btn.Click += update_btn_Click;
            // 
            // delete_btn
            // 
            delete_btn.Dock = DockStyle.Left;
            delete_btn.Location = new Point(0, 0);
            delete_btn.Name = "delete_btn";
            delete_btn.Size = new Size(180, 43);
            delete_btn.TabIndex = 0;
            delete_btn.Text = "Xóa hệ học";
            delete_btn.UseVisualStyleBackColor = true;
            delete_btn.Click += delete_btn_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(label3);
            panel3.Controls.Add(text_hehoc);
            panel3.Location = new Point(12, 94);
            panel3.Name = "panel3";
            panel3.Size = new Size(375, 37);
            panel3.TabIndex = 5;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 9F);
            label3.Location = new Point(-2, 6);
            label3.Name = "label3";
            label3.Size = new Size(89, 27);
            label3.TabIndex = 4;
            label3.Text = "Hệ học";
            // 
            // UpdateHeHoc
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(397, 195);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "UpdateHeHoc";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UpdateHeHoc";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private TextBox text_hehoc;
        private Label label2;
        private Panel panel2;
        private Button update_btn;
        private Button delete_btn;
        private Panel panel3;
        private Label label3;
        private Label ma_lb;
    }
}