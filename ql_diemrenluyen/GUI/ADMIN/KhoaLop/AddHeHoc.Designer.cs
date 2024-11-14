namespace ql_diemrenluyen.GUI.ADMIN.KhoaLop
{
    partial class AddHeHoc
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
            text_hehoc = new TextBox();
            label2 = new Label();
            panel2 = new Panel();
            add_btn = new Button();
            reset_btn = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(450, 42);
            label1.TabIndex = 1;
            label1.Text = "Thêm hệ học";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(text_hehoc);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(12, 51);
            panel1.Name = "panel1";
            panel1.Size = new Size(431, 37);
            panel1.TabIndex = 2;
            // 
            // text_hehoc
            // 
            text_hehoc.Dock = DockStyle.Right;
            text_hehoc.Location = new Point(72, 0);
            text_hehoc.Name = "text_hehoc";
            text_hehoc.Size = new Size(359, 27);
            text_hehoc.TabIndex = 1;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Left;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(72, 37);
            label2.TabIndex = 0;
            label2.Text = "Hệ học";
            // 
            // panel2
            // 
            panel2.Controls.Add(add_btn);
            panel2.Controls.Add(reset_btn);
            panel2.Location = new Point(12, 94);
            panel2.Name = "panel2";
            panel2.Size = new Size(428, 43);
            panel2.TabIndex = 3;
            // 
            // add_btn
            // 
            add_btn.Dock = DockStyle.Right;
            add_btn.Location = new Point(233, 0);
            add_btn.Name = "add_btn";
            add_btn.Size = new Size(195, 43);
            add_btn.TabIndex = 3;
            add_btn.Text = "Thêm hệ học";
            add_btn.UseVisualStyleBackColor = true;
            add_btn.Click += add_btn_Click;
            // 
            // reset_btn
            // 
            reset_btn.Dock = DockStyle.Left;
            reset_btn.Location = new Point(0, 0);
            reset_btn.Name = "reset_btn";
            reset_btn.Size = new Size(195, 43);
            reset_btn.TabIndex = 0;
            reset_btn.Text = "Xóa trắng";
            reset_btn.UseVisualStyleBackColor = true;
            reset_btn.Click += reset_btn_Click;
            // 
            // AddHeHoc
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(450, 148);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "AddHeHoc";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddHeHoc";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private TextBox text_hehoc;
        private Label label2;
        private Panel panel2;
        private Button add_btn;
        private Button reset_btn;
    }
}