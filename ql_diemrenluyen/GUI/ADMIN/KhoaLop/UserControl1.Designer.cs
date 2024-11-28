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
            more = new DataGridViewButtonColumn();
            tableLayoutPanel1 = new TableLayoutPanel();
            button1 = new Button();
            label1 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            button2 = new Button();
            find = new Button();
            textBox1 = new TextBox();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridKhoaView).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridKhoaView
            // 
            dataGridKhoaView.AllowUserToAddRows = false;
            dataGridKhoaView.AllowUserToDeleteRows = false;
            dataGridKhoaView.AllowUserToResizeColumns = false;
            dataGridKhoaView.AllowUserToResizeRows = false;
            dataGridKhoaView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridKhoaView.BackgroundColor = Color.White;
            dataGridKhoaView.BorderStyle = BorderStyle.None;
            dataGridKhoaView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridKhoaView.Columns.AddRange(new DataGridViewColumn[] { id, name, more });
            dataGridKhoaView.Dock = DockStyle.Fill;
            dataGridKhoaView.Location = new Point(3, 75);
            dataGridKhoaView.MultiSelect = false;
            dataGridKhoaView.Name = "dataGridKhoaView";
            dataGridKhoaView.ReadOnly = true;
            dataGridKhoaView.RowHeadersVisible = false;
            dataGridKhoaView.RowHeadersWidth = 62;
            dataGridKhoaView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridKhoaView.Size = new Size(960, 411);
            dataGridKhoaView.TabIndex = 0;
            dataGridKhoaView.CellContentClick += dataGridView1_CellContentClick_1;
            dataGridKhoaView.CellPainting += dataGridKhoaView_CellPainting;
            // 
            // id
            // 
            id.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            id.HeaderText = "Mã khoa";
            id.MinimumWidth = 8;
            id.Name = "id";
            id.ReadOnly = true;
            // 
            // name
            // 
            name.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            name.HeaderText = "Tên khoa";
            name.MinimumWidth = 8;
            name.Name = "name";
            name.ReadOnly = true;
            // 
            // more
            // 
            more.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            more.HeaderText = "Xem chi tiết";
            more.MinimumWidth = 8;
            more.Name = "more";
            more.ReadOnly = true;
            more.Text = "Chi tiết";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(dataGridKhoaView, 0, 2);
            tableLayoutPanel1.Controls.Add(button1, 0, 3);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6F));
            tableLayoutPanel1.Size = new Size(966, 522);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // button1
            // 
            button1.BackColor = Color.RoyalBlue;
            button1.Dock = DockStyle.Right;
            button1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(788, 492);
            button1.Name = "button1";
            button1.Size = new Size(175, 27);
            button1.TabIndex = 4;
            button1.Text = "Thêm khoa";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(960, 36);
            label1.TabIndex = 5;
            label1.Text = "Thông tin khoa";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(button4);
            flowLayoutPanel1.Controls.Add(button2);
            flowLayoutPanel1.Controls.Add(find);
            flowLayoutPanel1.Controls.Add(textBox1);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(3, 38);
            flowLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(960, 32);
            flowLayoutPanel1.TabIndex = 6;
            // 
            // button2
            // 
            button2.Image = Properties.Resources.setting__1_;
            button2.Location = new Point(780, 2);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(96, 24);
            button2.TabIndex = 3;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // find
            // 
            find.BackColor = Color.White;
            find.BackgroundImage = Properties.Resources.search__3_;
            find.BackgroundImageLayout = ImageLayout.Center;
            find.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            find.Location = new Point(678, 2);
            find.Margin = new Padding(3, 2, 3, 2);
            find.Name = "find";
            find.Size = new Size(96, 24);
            find.TabIndex = 0;
            find.UseVisualStyleBackColor = false;
            find.Click += find_Click;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(409, 2);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(263, 26);
            textBox1.TabIndex = 2;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.Location = new Point(882, 3);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 5;
            button4.Text = "Export";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // UserControl1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "UserControl1";
            Size = new Size(966, 522);
            Load += UserControl1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridKhoaView).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridKhoaView;
        private TableLayoutPanel tableLayoutPanel1;
        private Button button1;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button find;
        private TextBox textBox1;
        private Button button2;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn name;
        private DataGridViewButtonColumn more;
        private Button button4;
    }
}
