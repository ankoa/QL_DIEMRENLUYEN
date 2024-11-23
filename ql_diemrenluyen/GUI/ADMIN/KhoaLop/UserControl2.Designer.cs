namespace ql_diemrenluyen.GUI.ADMIN.KhoaLop
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
            dataGridLopView = new DataGridView();
            id_lop = new DataGridViewTextBoxColumn();
            name_lop = new DataGridViewTextBoxColumn();
            name_khoa = new DataGridViewTextBoxColumn();
            name_hdt = new DataGridViewTextBoxColumn();
            more = new DataGridViewButtonColumn();
            button1 = new Button();
            find = new Button();
            textBox1 = new TextBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            button2 = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            label1 = new Label();
            flowLayoutPanel2 = new FlowLayoutPanel();
            button3 = new Button();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridLopView).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridLopView
            // 
            dataGridLopView.AllowUserToAddRows = false;
            dataGridLopView.AllowUserToDeleteRows = false;
            dataGridLopView.AllowUserToResizeColumns = false;
            dataGridLopView.AllowUserToResizeRows = false;
            dataGridLopView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridLopView.BackgroundColor = Color.White;
            dataGridLopView.BorderStyle = BorderStyle.None;
            dataGridLopView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridLopView.Columns.AddRange(new DataGridViewColumn[] { id_lop, name_lop, name_khoa, name_hdt, more });
            dataGridLopView.Dock = DockStyle.Fill;
            dataGridLopView.Location = new Point(3, 84);
            dataGridLopView.Margin = new Padding(3, 4, 3, 4);
            dataGridLopView.Name = "dataGridLopView";
            dataGridLopView.ReadOnly = true;
            dataGridLopView.RowHeadersVisible = false;
            dataGridLopView.RowHeadersWidth = 62;
            dataGridLopView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridLopView.Size = new Size(1158, 449);
            dataGridLopView.TabIndex = 3;
            dataGridLopView.CellContentClick += dataGridLopView_CellContentClick;
            dataGridLopView.CellPainting += dataGridLopView_CellPainting;
            // 
            // id_lop
            // 
            id_lop.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            id_lop.HeaderText = "Mã lớp";
            id_lop.MinimumWidth = 8;
            id_lop.Name = "id_lop";
            id_lop.ReadOnly = true;
            // 
            // name_lop
            // 
            name_lop.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            name_lop.HeaderText = "Tên lớp";
            name_lop.MinimumWidth = 8;
            name_lop.Name = "name_lop";
            name_lop.ReadOnly = true;
            // 
            // name_khoa
            // 
            name_khoa.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            name_khoa.HeaderText = "Khoa";
            name_khoa.MinimumWidth = 8;
            name_khoa.Name = "name_khoa";
            name_khoa.ReadOnly = true;
            // 
            // name_hdt
            // 
            name_hdt.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            name_hdt.HeaderText = "Hệ đào tạo";
            name_hdt.MinimumWidth = 8;
            name_hdt.Name = "name_hdt";
            name_hdt.ReadOnly = true;
            // 
            // more
            // 
            more.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            more.HeaderText = "Xem chi tiết";
            more.MinimumWidth = 8;
            more.Name = "more";
            more.ReadOnly = true;
            // 
            // button1
            // 
            button1.BackColor = Color.RoyalBlue;
            button1.Dock = DockStyle.Right;
            button1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(961, 541);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(200, 27);
            button1.TabIndex = 4;
            button1.Text = "Thêm lớp";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // find
            // 
            find.Image = Properties.Resources.search__3_;
            find.Location = new Point(929, 2);
            find.Margin = new Padding(3, 2, 3, 3);
            find.Name = "find";
            find.Size = new Size(110, 32);
            find.TabIndex = 3;
            find.UseVisualStyleBackColor = true;
            find.Click += find_Click;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(623, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(300, 30);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged_1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 1);
            tableLayoutPanel1.Controls.Add(button1, 0, 3);
            tableLayoutPanel1.Controls.Add(dataGridLopView, 0, 2);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6F));
            tableLayoutPanel1.Size = new Size(1164, 572);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(button2);
            flowLayoutPanel1.Controls.Add(find);
            flowLayoutPanel1.Controls.Add(textBox1);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(3, 43);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1158, 34);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // button2
            // 
            button2.BackgroundImage = Properties.Resources.setting__1_;
            button2.BackgroundImageLayout = ImageLayout.Center;
            button2.Location = new Point(1045, 2);
            button2.Margin = new Padding(3, 2, 3, 3);
            button2.Name = "button2";
            button2.Size = new Size(110, 32);
            button2.TabIndex = 4;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(label1, 0, 0);
            tableLayoutPanel2.Controls.Add(flowLayoutPanel2, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(1158, 34);
            tableLayoutPanel2.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Left;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(160, 34);
            label1.TabIndex = 0;
            label1.Text = "Thông tin lớp";
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(button3);
            flowLayoutPanel2.Controls.Add(button4);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel2.Location = new Point(579, 0);
            flowLayoutPanel2.Margin = new Padding(0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(579, 34);
            flowLayoutPanel2.TabIndex = 1;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.Location = new Point(466, 0);
            button3.Margin = new Padding(3, 0, 3, 3);
            button3.Name = "button3";
            button3.Size = new Size(110, 32);
            button3.TabIndex = 0;
            button3.Text = "Export";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.Location = new Point(350, 0);
            button4.Margin = new Padding(3, 0, 3, 3);
            button4.Name = "button4";
            button4.Size = new Size(110, 32);
            button4.TabIndex = 1;
            button4.Text = "Import";
            button4.UseVisualStyleBackColor = true;
            // 
            // UserControl2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "UserControl2";
            Size = new Size(1164, 572);
            Load += UserControl2_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridLopView).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dataGridLopView;
        private Button button1;
        private Button find;
        private TextBox textBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private DataGridViewTextBoxColumn id_lop;
        private DataGridViewTextBoxColumn name_lop;
        private DataGridViewTextBoxColumn name_khoa;
        private DataGridViewTextBoxColumn name_hdt;
        private DataGridViewButtonColumn more;
        private Button button2;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button button3;
        private Button button4;
    }
}
