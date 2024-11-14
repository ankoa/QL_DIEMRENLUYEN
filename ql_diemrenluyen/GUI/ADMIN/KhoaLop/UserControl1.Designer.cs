namespace ql_diemrenluyen.GUI.ADMIN.KhoaLop
{
    partial class UserControl1
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
            dataGridKhoaView = new DataGridView();
            id = new DataGridViewTextBoxColumn();
            name = new DataGridViewTextBoxColumn();
            created_day = new DataGridViewTextBoxColumn();
            updated_day = new DataGridViewTextBoxColumn();
            more = new DataGridViewButtonColumn();
            label1 = new Label();
            button1 = new Button();
            panel1 = new Panel();
            find = new Button();
            textBox1 = new TextBox();
            comboBox1 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridKhoaView).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridKhoaView
            // 
            dataGridKhoaView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridKhoaView.Columns.AddRange(new DataGridViewColumn[] { id, name, created_day, updated_day, more });
            dataGridKhoaView.Location = new Point(0, 114);
            dataGridKhoaView.Margin = new Padding(3, 4, 3, 4);
            dataGridKhoaView.Name = "dataGridKhoaView";
            dataGridKhoaView.RowHeadersWidth = 62;
            dataGridKhoaView.Size = new Size(898, 414);
            dataGridKhoaView.TabIndex = 0;
            dataGridKhoaView.CellContentClick += dataGridView1_CellContentClick_1;
            dataGridKhoaView.CellPainting += dataGridKhoaView_CellPainting;
            // 
            // id
            // 
            id.HeaderText = "Mã khoa";
            id.MinimumWidth = 8;
            id.Name = "id";
            id.ReadOnly = true;
            id.Width = 120;
            // 
            // name
            // 
            name.HeaderText = "Tên khoa";
            name.MinimumWidth = 8;
            name.Name = "name";
            name.ReadOnly = true;
            name.Width = 214;
            // 
            // created_day
            // 
            created_day.HeaderText = "Ngày tạo";
            created_day.MinimumWidth = 8;
            created_day.Name = "created_day";
            created_day.ReadOnly = true;
            created_day.Width = 180;
            // 
            // updated_day
            // 
            updated_day.HeaderText = "Ngày cập nhật";
            updated_day.MinimumWidth = 8;
            updated_day.Name = "updated_day";
            updated_day.ReadOnly = true;
            updated_day.Width = 180;
            // 
            // more
            // 
            more.HeaderText = "Xem chi tiết";
            more.MinimumWidth = 8;
            more.Name = "more";
            more.ReadOnly = true;
            more.Text = "Chi tiết";
            more.Width = 140;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 14);
            label1.Name = "label1";
            label1.Size = new Size(187, 32);
            label1.TabIndex = 1;
            label1.Text = "Thông tin khoa";
            label1.Click += label1_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(733, 536);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(165, 36);
            button1.TabIndex = 2;
            button1.Text = "Thêm khoa";
            button1.UseVisualStyleBackColor = false;
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
            panel1.TabIndex = 3;
            panel1.Paint += panel1_Paint;
            // 
            // find
            // 
            find.BackColor = Color.White;
            find.Image = Properties.Resources.search__2_;
            find.Location = new Point(786, 1);
            find.Name = "find";
            find.Size = new Size(112, 32);
            find.TabIndex = 3;
            find.UseVisualStyleBackColor = false;
            find.Click += find_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(343, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(311, 27);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Tất cả", "Mã khoa", "Tên khoa" });
            comboBox1.Location = new Point(660, 3);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(120, 28);
            comboBox1.TabIndex = 1;
            comboBox1.Tag = "";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // UserControl1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(dataGridKhoaView);
            Margin = new Padding(3, 4, 3, 4);
            Name = "UserControl1";
            Size = new Size(898, 572);
            Load += UserControl1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridKhoaView).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridKhoaView;
        private Label label1;
        private Button button1;
        private Panel panel1;
        private TextBox textBox1;
        private ComboBox comboBox1;
        private Button find;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn created_day;
        private DataGridViewTextBoxColumn updated_day;
        private DataGridViewButtonColumn more;
    }
}
