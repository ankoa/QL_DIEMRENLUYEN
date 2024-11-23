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
            find = new Button();
            textBox1 = new TextBox();
            dataGridHeHocView = new DataGridView();
            id_hehoc = new DataGridViewTextBoxColumn();
            name_hehoc = new DataGridViewTextBoxColumn();
            more = new DataGridViewButtonColumn();
            add_btn = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            button1 = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            label1 = new Label();
            flowLayoutPanel2 = new FlowLayoutPanel();
            button3 = new Button();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridHeHocView).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // find
            // 
            find.Image = Properties.Resources.search__3_;
            find.Location = new Point(903, 2);
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
            textBox1.Location = new Point(597, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(300, 30);
            textBox1.TabIndex = 2;
            // 
            // dataGridHeHocView
            // 
            dataGridHeHocView.AllowUserToAddRows = false;
            dataGridHeHocView.AllowUserToDeleteRows = false;
            dataGridHeHocView.AllowUserToResizeColumns = false;
            dataGridHeHocView.AllowUserToResizeRows = false;
            dataGridHeHocView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridHeHocView.BackgroundColor = Color.White;
            dataGridHeHocView.BorderStyle = BorderStyle.None;
            dataGridHeHocView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridHeHocView.Columns.AddRange(new DataGridViewColumn[] { id_hehoc, name_hehoc, more });
            dataGridHeHocView.Dock = DockStyle.Fill;
            dataGridHeHocView.Location = new Point(3, 84);
            dataGridHeHocView.Margin = new Padding(3, 4, 3, 4);
            dataGridHeHocView.Name = "dataGridHeHocView";
            dataGridHeHocView.RowHeadersVisible = false;
            dataGridHeHocView.RowHeadersWidth = 62;
            dataGridHeHocView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridHeHocView.Size = new Size(1132, 449);
            dataGridHeHocView.TabIndex = 7;
            dataGridHeHocView.CellContentClick += dataGridHeHocView_CellContentClick;
            dataGridHeHocView.CellPainting += dataGridHeHocView_CellPainting;
            // 
            // id_hehoc
            // 
            id_hehoc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            id_hehoc.HeaderText = "Mã hệ học";
            id_hehoc.MinimumWidth = 6;
            id_hehoc.Name = "id_hehoc";
            id_hehoc.ReadOnly = true;
            // 
            // name_hehoc
            // 
            name_hehoc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            name_hehoc.HeaderText = "Tên hệ học";
            name_hehoc.MinimumWidth = 6;
            name_hehoc.Name = "name_hehoc";
            name_hehoc.ReadOnly = true;
            // 
            // more
            // 
            more.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            more.HeaderText = "Xem chi tiết";
            more.MinimumWidth = 6;
            more.Name = "more";
            more.ReadOnly = true;
            more.Resizable = DataGridViewTriState.True;
            more.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // add_btn
            // 
            add_btn.BackColor = Color.RoyalBlue;
            add_btn.Dock = DockStyle.Right;
            add_btn.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            add_btn.ForeColor = Color.White;
            add_btn.Location = new Point(935, 541);
            add_btn.Margin = new Padding(3, 4, 3, 4);
            add_btn.Name = "add_btn";
            add_btn.Size = new Size(200, 27);
            add_btn.TabIndex = 8;
            add_btn.Text = "Thêm hệ học";
            add_btn.UseVisualStyleBackColor = false;
            add_btn.Click += add_btn_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 1);
            tableLayoutPanel1.Controls.Add(add_btn, 0, 3);
            tableLayoutPanel1.Controls.Add(dataGridHeHocView, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6F));
            tableLayoutPanel1.Size = new Size(1138, 572);
            tableLayoutPanel1.TabIndex = 9;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(button1);
            flowLayoutPanel1.Controls.Add(find);
            flowLayoutPanel1.Controls.Add(textBox1);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(3, 43);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1132, 34);
            flowLayoutPanel1.TabIndex = 10;
            // 
            // button1
            // 
            button1.Image = Properties.Resources.setting__1_;
            button1.Location = new Point(1019, 2);
            button1.Margin = new Padding(3, 2, 3, 3);
            button1.Name = "button1";
            button1.Size = new Size(110, 32);
            button1.TabIndex = 4;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
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
            tableLayoutPanel2.Size = new Size(1132, 34);
            tableLayoutPanel2.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Left;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(196, 34);
            label1.TabIndex = 0;
            label1.Text = "Thông tin hệ học";
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(button3);
            flowLayoutPanel2.Controls.Add(button4);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel2.Location = new Point(566, 0);
            flowLayoutPanel2.Margin = new Padding(0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(566, 34);
            flowLayoutPanel2.TabIndex = 1;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.Location = new Point(453, 0);
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
            button4.Location = new Point(337, 0);
            button4.Margin = new Padding(3, 0, 3, 3);
            button4.Name = "button4";
            button4.Size = new Size(110, 32);
            button4.TabIndex = 1;
            button4.Text = "Import";
            button4.UseVisualStyleBackColor = true;
            // 
            // UserControl3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "UserControl3";
            Size = new Size(1138, 572);
            Load += UserControl3_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridHeHocView).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button find;
        private TextBox textBox1;
        private DataGridView dataGridHeHocView;
        private Button add_btn;
        private TableLayoutPanel tableLayoutPanel1;
        private DataGridViewTextBoxColumn id_hehoc;
        private DataGridViewTextBoxColumn name_hehoc;
        private DataGridViewButtonColumn more;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button button1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button button3;
        private Button button4;
    }
}
