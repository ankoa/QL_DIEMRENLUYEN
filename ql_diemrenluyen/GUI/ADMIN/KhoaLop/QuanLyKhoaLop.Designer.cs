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
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            label1 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            userControl11 = new UserControl1();
            tabPage2 = new TabPage();
            userControl21 = new UserControl2();
            tabPage3 = new TabPage();
            userControl31 = new UserControl3();
            tableLayoutPanel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.RoyalBlue;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.ImageAlign = ContentAlignment.TopCenter;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(819, 35);
            label1.TabIndex = 0;
            label1.Text = "Quản lý khoa, lớp và hệ học";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(tabControl1, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 93F));
            tableLayoutPanel1.Size = new Size(825, 500);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabControl1.Location = new Point(3, 38);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(819, 459);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(userControl11);
            tabPage1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tabPage1.Location = new Point(4, 30);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(811, 425);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Khoa ";
            tabPage1.UseVisualStyleBackColor = true;
            tabPage1.Click += tabPage1_Click;
            // 
            // userControl11
            // 
            userControl11.Dock = DockStyle.Fill;
            userControl11.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            userControl11.Location = new Point(3, 3);
            userControl11.Name = "userControl11";
            userControl11.Size = new Size(805, 419);
            userControl11.TabIndex = 0;
            userControl11.Load += userControl11_Load;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(userControl21);
            tabPage2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tabPage2.Location = new Point(4, 30);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(811, 425);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Lớp";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // userControl21
            // 
            userControl21.Dock = DockStyle.Fill;
            userControl21.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            userControl21.Location = new Point(3, 3);
            userControl21.Margin = new Padding(5, 6, 5, 6);
            userControl21.Name = "userControl21";
            userControl21.Size = new Size(805, 419);
            userControl21.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(userControl31);
            tabPage3.Location = new Point(4, 30);
            tabPage3.Margin = new Padding(3, 2, 3, 2);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3, 2, 3, 2);
            tabPage3.Size = new Size(192, 66);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Hệ học";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // userControl31
            // 
            userControl31.Dock = DockStyle.Fill;
            userControl31.Location = new Point(3, 2);
            userControl31.Margin = new Padding(4, 3, 4, 3);
            userControl31.Name = "userControl31";
            userControl31.Size = new Size(186, 62);
            userControl31.TabIndex = 0;
            // 
            // QuanLyKhoaLop
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(825, 500);
            Controls.Add(tableLayoutPanel1);
            Name = "QuanLyKhoaLop";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += QuanLyKhoaLop_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private TableLayoutPanel tableLayoutPanel1;
        private UserControl1 userControl11;
        private Button button1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private UserControl2 userControl21;
        private TabPage tabPage3;
        private UserControl3 userControl31;
    }
}
