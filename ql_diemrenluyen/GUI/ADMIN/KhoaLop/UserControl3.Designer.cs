namespace ql_diemrenluyen.GUI.ADMIN.KhoaLop
{
    partial class UserControl3
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
            panel1 = new Panel();
            find = new Button();
            textBox1 = new TextBox();
            comboBox1 = new ComboBox();
            dataGridHeHocView = new DataGridView();
            id_hehoc = new DataGridViewTextBoxColumn();
            name_hehoc = new DataGridViewTextBoxColumn();
            more = new DataGridViewButtonColumn();
            add_btn = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridHeHocView).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 14);
            label1.Name = "label1";
            label1.Size = new Size(196, 31);
            label1.TabIndex = 0;
            label1.Text = "Thông tin hệ học";
            // 
            // panel1
            // 
            panel1.Controls.Add(find);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(comboBox1);
            panel1.Location = new Point(0, 73);
            panel1.Name = "panel1";
            panel1.Size = new Size(898, 34);
            panel1.TabIndex = 6;
            // 
            // find
            // 
            find.Image = Properties.Resources.search__2_;
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
            comboBox1.Items.AddRange(new object[] { "Tất cả", "Mã hệ học", "Tên hệ học" });
            comboBox1.Location = new Point(660, 3);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(120, 28);
            comboBox1.TabIndex = 1;
            comboBox1.Tag = "";
            // 
            // dataGridHeHocView
            // 
            dataGridHeHocView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridHeHocView.Columns.AddRange(new DataGridViewColumn[] { id_hehoc, name_hehoc, more });
            dataGridHeHocView.Location = new Point(0, 114);
            dataGridHeHocView.Margin = new Padding(3, 4, 3, 4);
            dataGridHeHocView.Name = "dataGridHeHocView";
            dataGridHeHocView.RowHeadersWidth = 62;
            dataGridHeHocView.Size = new Size(898, 414);
            dataGridHeHocView.TabIndex = 7;
            dataGridHeHocView.CellContentClick += dataGridHeHocView_CellContentClick;
            dataGridHeHocView.CellPainting += dataGridHeHocView_CellPainting;
            // 
            // id_hehoc
            // 
            id_hehoc.HeaderText = "Mã hệ học";
            id_hehoc.MinimumWidth = 6;
            id_hehoc.Name = "id_hehoc";
            id_hehoc.ReadOnly = true;
            id_hehoc.Width = 204;
            // 
            // name_hehoc
            // 
            name_hehoc.HeaderText = "Tên hệ học";
            name_hehoc.MinimumWidth = 6;
            name_hehoc.Name = "name_hehoc";
            name_hehoc.ReadOnly = true;
            name_hehoc.Width = 450;
            // 
            // more
            // 
            more.HeaderText = "Xem chi tiết";
            more.MinimumWidth = 6;
            more.Name = "more";
            more.ReadOnly = true;
            more.Resizable = DataGridViewTriState.True;
            more.SortMode = DataGridViewColumnSortMode.Automatic;
            more.Width = 180;
            // 
            // add_btn
            // 
            add_btn.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            add_btn.Location = new Point(733, 536);
            add_btn.Margin = new Padding(3, 4, 3, 4);
            add_btn.Name = "add_btn";
            add_btn.Size = new Size(165, 36);
            add_btn.TabIndex = 8;
            add_btn.Text = "Thêm hệ học";
            add_btn.UseVisualStyleBackColor = true;
            add_btn.Click += add_btn_Click;
            // 
            // UserControl3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(add_btn);
            Controls.Add(dataGridHeHocView);
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "UserControl3";
            Size = new Size(898, 572);
            Load += UserControl3_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridHeHocView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Button find;
        private TextBox textBox1;
        private ComboBox comboBox1;
        private DataGridView dataGridHeHocView;
        private Button add_btn;
        private DataGridViewTextBoxColumn id_hehoc;
        private DataGridViewTextBoxColumn name_hehoc;
        private DataGridViewButtonColumn more;
    }
}
