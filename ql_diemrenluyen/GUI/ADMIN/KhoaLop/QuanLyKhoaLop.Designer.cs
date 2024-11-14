namespace ql_diemrenluyen.GUI.ADMIN.KhoaLop
{
    partial class QuanLyKhoaLop
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            userControl11 = new UserControl1();
            tabPage2 = new TabPage();
            userControl21 = new UserControl2();
            tabPage3 = new TabPage();
            userControl31 = new UserControl3();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = SystemColors.Control;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ImageAlign = ContentAlignment.TopCenter;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(926, 41);
            label1.TabIndex = 0;
            label1.Text = "Quản lý khoa, lớp và hệ học";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 41);
            tabControl1.Margin = new Padding(3, 4, 3, 4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(926, 625);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(userControl11);
            tabPage1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Margin = new Padding(3, 4, 3, 4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 4, 3, 4);
            tabPage1.Size = new Size(918, 592);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Khoa ";
            tabPage1.UseVisualStyleBackColor = true;
            tabPage1.Click += tabPage1_Click;
            // 
            // userControl11
            // 
            userControl11.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            userControl11.Location = new Point(9, 12);
            userControl11.Margin = new Padding(6, 8, 6, 8);
            userControl11.Name = "userControl11";
            userControl11.Size = new Size(898, 572);
            userControl11.TabIndex = 0;
            userControl11.Load += userControl11_Load;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(userControl21);
            tabPage2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Margin = new Padding(3, 4, 3, 4);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 4, 3, 4);
            tabPage2.Size = new Size(918, 592);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Lớp";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // userControl21
            // 
            userControl21.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            userControl21.Location = new Point(9, 12);
            userControl21.Margin = new Padding(6, 8, 6, 8);
            userControl21.Name = "userControl21";
            userControl21.Size = new Size(898, 572);
            userControl21.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(userControl31);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(918, 592);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Hệ học";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // userControl31
            // 
            userControl31.Location = new Point(9, 12);
            userControl31.Name = "userControl31";
            userControl31.Size = new Size(898, 572);
            userControl31.TabIndex = 0;
            // 
            // QuanLyKhoaLop
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(926, 666);
            Controls.Add(tabControl1);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "QuanLyKhoaLop";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private UserControl1 userControl11;
        private UserControl2 userControl21;
        private TabPage tabPage3;
        private UserControl3 userControl31;
    }
}
