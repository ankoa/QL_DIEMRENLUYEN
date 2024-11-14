﻿namespace ql_diemrenluyen.GUI.ADMIN.KhoaLop
{
    partial class UserControl2
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
            label1 = new Label();
            dataGridLopView = new DataGridView();
            id_lop = new DataGridViewTextBoxColumn();
            name_lop = new DataGridViewTextBoxColumn();
            name_khoa = new DataGridViewTextBoxColumn();
            name_hdt = new DataGridViewTextBoxColumn();
            more = new DataGridViewButtonColumn();
            button1 = new Button();
            panel1 = new Panel();
            find = new Button();
            textBox1 = new TextBox();
            comboBox1 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridLopView).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 14);
            label1.Name = "label1";
            label1.Size = new Size(169, 32);
            label1.TabIndex = 2;
            label1.Text = "Thông tin lớp";
            // 
            // dataGridLopView
            // 
            dataGridLopView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridLopView.Columns.AddRange(new DataGridViewColumn[] { id_lop, name_lop, name_khoa, name_hdt, more });
            dataGridLopView.Location = new Point(0, 114);
            dataGridLopView.Margin = new Padding(3, 4, 3, 4);
            dataGridLopView.Name = "dataGridLopView";
            dataGridLopView.RowHeadersWidth = 62;
            dataGridLopView.Size = new Size(898, 414);
            dataGridLopView.TabIndex = 3;
            dataGridLopView.CellContentClick += dataGridLopView_CellContentClick;
            dataGridLopView.CellPainting += dataGridLopView_CellPainting;
            // 
            // id_lop
            // 
            id_lop.HeaderText = "Mã lớp";
            id_lop.MinimumWidth = 8;
            id_lop.Name = "id_lop";
            id_lop.ReadOnly = true;
            id_lop.Width = 130;
            // 
            // name_lop
            // 
            name_lop.HeaderText = "Tên lớp";
            name_lop.MinimumWidth = 8;
            name_lop.Name = "name_lop";
            name_lop.ReadOnly = true;
            name_lop.Width = 150;
            // 
            // name_khoa
            // 
            name_khoa.HeaderText = "Khoa";
            name_khoa.MinimumWidth = 8;
            name_khoa.Name = "name_khoa";
            name_khoa.ReadOnly = true;
            name_khoa.Width = 214;
            // 
            // name_hdt
            // 
            name_hdt.HeaderText = "Hệ đào tạo";
            name_hdt.MinimumWidth = 8;
            name_hdt.Name = "name_hdt";
            name_hdt.ReadOnly = true;
            name_hdt.Width = 200;
            // 
            // more
            // 
            more.HeaderText = "Xem chi tiết";
            more.MinimumWidth = 8;
            more.Name = "more";
            more.ReadOnly = true;
            more.Width = 140;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(733, 536);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(165, 36);
            button1.TabIndex = 4;
            button1.Text = "Thêm lớp";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(find);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(comboBox1);
            panel1.Location = new Point(0, 73);
            panel1.Name = "panel1";
            panel1.Size = new Size(898, 34);
            panel1.TabIndex = 5;
            // 
            // find
            // 
            //find.Image = Properties.Resources.search__2_;
            find.Location = new Point(786, 1);
            find.Name = "find";
            find.Size = new Size(112, 32);
            find.TabIndex = 3;
            find.UseVisualStyleBackColor = true;
            find.Click += find_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(343, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(311, 27);
            textBox1.TabIndex = 2;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Tất cả", "Mã lớp", "Tên lớp", "Khoa", "Hệ đào tạo" });
            comboBox1.Location = new Point(660, 3);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(120, 28);
            comboBox1.TabIndex = 1;
            comboBox1.Tag = "";
            // 
            // UserControl2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(button1);
            Controls.Add(dataGridLopView);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "UserControl2";
            Size = new Size(898, 572);
            Load += UserControl2_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridLopView).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dataGridLopView;
        private Button button1;
        private Panel panel1;
        private Button find;
        private TextBox textBox1;
        private ComboBox comboBox1;
        private DataGridViewTextBoxColumn id_lop;
        private DataGridViewTextBoxColumn name_lop;
        private DataGridViewTextBoxColumn name_khoa;
        private DataGridViewTextBoxColumn name_hdt;
        private DataGridViewButtonColumn more;
    }
}
