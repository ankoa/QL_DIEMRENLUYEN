using MySqlX.XDevAPI.Relational;
using System.Windows.Forms;

namespace ql_diemrenluyen.GUI.ADMIN
{
    partial class DotCham
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
        // Thêm cột cho DataGridView trong InitializeComponent
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            panel1 = new Panel();
            pnContent = new Panel();
            panel5 = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            btnAdd = new Button();
            tableTK = new ReaLTaiizor.Controls.PoisonDataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            pnTop = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label2 = new Label();
            cbbHocKi = new ComboBox();
            label3 = new Label();
            cbbNamHoc = new ComboBox();
            label4 = new Label();
            cbbNguoiCham = new ComboBox();
            flowLayoutPanel2 = new FlowLayoutPanel();
            label5 = new Label();
            label6 = new Label();
            flowLayoutPanel3 = new FlowLayoutPanel();
            panel2 = new Panel();
            label7 = new Label();
            pictureBox1 = new PictureBox();
            panel4 = new Panel();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            panel3 = new Panel();
            timer1 = new System.Windows.Forms.Timer(components);
            timer2 = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            pnContent.SuspendLayout();
            panel5.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tableTK).BeginInit();
            pnTop.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLightLight;
            panel1.Controls.Add(pnContent);
            panel1.Controls.Add(pnTop);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(44, 15);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(0, 15, 0, 0);
            panel1.Size = new Size(1154, 560);
            panel1.TabIndex = 5;
            // 
            // pnContent
            // 
            pnContent.AutoScroll = true;
            pnContent.BackColor = SystemColors.ControlLightLight;
            pnContent.Controls.Add(panel5);
            pnContent.Dock = DockStyle.Fill;
            pnContent.Location = new Point(0, 239);
            pnContent.Margin = new Padding(0);
            pnContent.Name = "pnContent";
            pnContent.Size = new Size(1154, 321);
            pnContent.TabIndex = 8;
            // 
            // panel5
            // 
            panel5.Controls.Add(tableLayoutPanel2);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(0, 0);
            panel5.Margin = new Padding(3, 2, 3, 2);
            panel5.Name = "panel5";
            panel5.Size = new Size(1154, 321);
            panel5.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(btnAdd, 0, 1);
            tableLayoutPanel2.Controls.Add(tableTK, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel2.Size = new Size(1154, 321);
            tableLayoutPanel2.TabIndex = 35;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = SystemColors.Highlight;
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.Dock = DockStyle.Fill;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Cascadia Code", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(3, 274);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(1148, 44);
            btnAdd.TabIndex = 32;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // tableTK
            // 
            tableTK.AllowUserToAddRows = false;
            tableTK.AllowUserToDeleteRows = false;
            tableTK.AllowUserToResizeColumns = false;
            tableTK.AllowUserToResizeRows = false;
            tableTK.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tableTK.BackgroundColor = Color.FromArgb(255, 255, 255);
            tableTK.BorderStyle = BorderStyle.None;
            tableTK.CellBorderStyle = DataGridViewCellBorderStyle.None;
            tableTK.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(0, 174, 219);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(111, 226, 255);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            tableTK.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            tableTK.ColumnHeadersHeight = 70;
            tableTK.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn8, dataGridViewTextBoxColumn6, dataGridViewTextBoxColumn7 });
            tableTK.Cursor = Cursors.Hand;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle8.ForeColor = Color.FromArgb(136, 136, 136);
            dataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(111, 226, 255);
            dataGridViewCellStyle8.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            tableTK.DefaultCellStyle = dataGridViewCellStyle8;
            tableTK.Dock = DockStyle.Fill;
            tableTK.EnableHeadersVisualStyles = false;
            tableTK.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            tableTK.GridColor = Color.FromArgb(255, 255, 255);
            tableTK.HighLightPercentage = 1F;
            tableTK.Location = new Point(0, 20);
            tableTK.Margin = new Padding(0, 20, 0, 0);
            tableTK.MultiSelect = false;
            tableTK.Name = "tableTK";
            tableTK.ReadOnly = true;
            tableTK.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = Color.FromArgb(0, 174, 219);
            dataGridViewCellStyle9.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle9.ForeColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(111, 226, 255);
            dataGridViewCellStyle9.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
            tableTK.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            tableTK.RowHeadersVisible = false;
            tableTK.RowHeadersWidth = 51;
            tableTK.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            tableTK.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tableTK.Size = new Size(1154, 251);
            tableTK.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Custom;
            tableTK.TabIndex = 34;
            tableTK.CellDoubleClick += tableTK_CellDoubleClick_1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewTextBoxColumn1.HeaderText = "ID";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewTextBoxColumn5.HeaderText = "Năm học";
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewTextBoxColumn3.HeaderText = "Học kì";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewTextBoxColumn8.HeaderText = "Người chấm";
            dataGridViewTextBoxColumn8.MinimumWidth = 6;
            dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle6;
            dataGridViewTextBoxColumn6.HeaderText = "Ngày bắt đầu";
            dataGridViewTextBoxColumn6.MinimumWidth = 6;
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewTextBoxColumn7.HeaderText = "Ngày kết thúc";
            dataGridViewTextBoxColumn7.MinimumWidth = 6;
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // pnTop
            // 
            pnTop.BackColor = Color.RoyalBlue;
            pnTop.BackgroundImageLayout = ImageLayout.None;
            pnTop.Controls.Add(tableLayoutPanel1);
            pnTop.Dock = DockStyle.Top;
            pnTop.Location = new Point(0, 15);
            pnTop.Margin = new Padding(18, 0, 18, 0);
            pnTop.Name = "pnTop";
            pnTop.Padding = new Padding(0, 38, 0, 15);
            pnTop.Size = new Size(1154, 224);
            pnTop.TabIndex = 9;
            pnTop.Paint += pnTop_Paint;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 0);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel3, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 38);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 38F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 38F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 24F));
            tableLayoutPanel1.Size = new Size(1154, 171);
            tableLayoutPanel1.TabIndex = 35;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(label2);
            flowLayoutPanel1.Controls.Add(cbbHocKi);
            flowLayoutPanel1.Controls.Add(label3);
            flowLayoutPanel1.Controls.Add(cbbNamHoc);
            flowLayoutPanel1.Controls.Add(label4);
            flowLayoutPanel1.Controls.Add(cbbNguoiCham);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(3, 2);
            flowLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1148, 60);
            flowLayoutPanel1.TabIndex = 36;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(58, 21);
            label2.TabIndex = 32;
            label2.Text = "Học kì";
            // 
            // cbbHocKi
            // 
            cbbHocKi.Cursor = Cursors.Hand;
            cbbHocKi.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbHocKi.FormattingEnabled = true;
            cbbHocKi.Items.AddRange(new object[] { "Chọn học kì", "1", "2" });
            cbbHocKi.Location = new Point(67, 2);
            cbbHocKi.Margin = new Padding(3, 2, 3, 2);
            cbbHocKi.Name = "cbbHocKi";
            cbbHocKi.Size = new Size(126, 23);
            cbbHocKi.TabIndex = 25;
            cbbHocKi.SelectedIndexChanged += cbbHocKi_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(248, 0);
            label3.Margin = new Padding(52, 0, 3, 0);
            label3.Name = "label3";
            label3.Size = new Size(79, 21);
            label3.TabIndex = 33;
            label3.Text = "Năm học";
            // 
            // cbbNamHoc
            // 
            cbbNamHoc.Cursor = Cursors.Hand;
            cbbNamHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbNamHoc.FormattingEnabled = true;
            cbbNamHoc.Items.AddRange(new object[] { "Chọn năm học" });
            cbbNamHoc.Location = new Point(333, 2);
            cbbNamHoc.Margin = new Padding(3, 2, 3, 2);
            cbbNamHoc.Name = "cbbNamHoc";
            cbbNamHoc.Size = new Size(123, 23);
            cbbNamHoc.TabIndex = 26;
            cbbNamHoc.SelectedIndexChanged += cbbNamHoc_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(511, 0);
            label4.Margin = new Padding(52, 0, 3, 0);
            label4.Name = "label4";
            label4.Size = new Size(105, 21);
            label4.TabIndex = 35;
            label4.Text = "Người chấm";
            // 
            // cbbNguoiCham
            // 
            cbbNguoiCham.Cursor = Cursors.Hand;
            cbbNguoiCham.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbNguoiCham.FormattingEnabled = true;
            cbbNguoiCham.Items.AddRange(new object[] { "Chọn người chấm", "Sinh viên", "Cố vấn", "Khoa", "Trường" });
            cbbNguoiCham.Location = new Point(622, 2);
            cbbNguoiCham.Margin = new Padding(3, 2, 3, 2);
            cbbNguoiCham.Name = "cbbNguoiCham";
            cbbNguoiCham.Size = new Size(126, 23);
            cbbNguoiCham.TabIndex = 34;
            cbbNguoiCham.SelectedIndexChanged += cbbNguoiCham_SelectedIndexChanged;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(label5);
            flowLayoutPanel2.Controls.Add(label6);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.Location = new Point(3, 67);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(1148, 58);
            flowLayoutPanel2.TabIndex = 37;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ControlLightLight;
            label5.Location = new Point(0, 0);
            label5.Margin = new Padding(0, 0, 3, 0);
            label5.Name = "label5";
            label5.Size = new Size(113, 21);
            label5.TabIndex = 37;
            label5.Text = "Ngày bắt đầu";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.ControlLightLight;
            label6.Location = new Point(168, 0);
            label6.Margin = new Padding(52, 0, 3, 0);
            label6.Name = "label6";
            label6.Size = new Size(117, 21);
            label6.TabIndex = 39;
            label6.Text = "Ngày kết thúc";
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Controls.Add(panel2);
            flowLayoutPanel3.Controls.Add(panel4);
            flowLayoutPanel3.Dock = DockStyle.Fill;
            flowLayoutPanel3.Location = new Point(3, 130);
            flowLayoutPanel3.Margin = new Padding(3, 2, 3, 2);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(1148, 39);
            flowLayoutPanel3.TabIndex = 38;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label7);
            panel2.Controls.Add(pictureBox1);
            panel2.Cursor = Cursors.Hand;
            panel2.Location = new Point(3, 2);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(109, 32);
            panel2.TabIndex = 6;
            panel2.Paint += panel2_Paint;
            panel2.MouseClick += button1_Click;
            panel2.MouseDown += panel2_MouseDown;
            panel2.MouseEnter += button1_MouseEnter;
            panel2.MouseLeave += button1_MouseLeave;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.White;
            label7.Location = new Point(34, 2);
            label7.Margin = new Padding(52, 0, 3, 0);
            label7.Name = "label7";
            label7.Size = new Size(51, 21);
            label7.TabIndex = 36;
            label7.Text = "Reset";
            label7.MouseEnter += button1_MouseEnter;
            label7.MouseLeave += button1_MouseLeave;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.reset_14435;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(34, 28);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.MouseEnter += button1_MouseEnter;
            pictureBox1.MouseLeave += button1_MouseLeave;
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(label1);
            panel4.Controls.Add(pictureBox2);
            panel4.Cursor = Cursors.Hand;
            panel4.Location = new Point(167, 2);
            panel4.Margin = new Padding(52, 2, 3, 2);
            panel4.Name = "panel4";
            panel4.Size = new Size(111, 32);
            panel4.TabIndex = 7;
            panel4.MouseClick += button2_Click;
            panel4.MouseEnter += button2_MouseEnter;
            panel4.MouseLeave += button2_MouseLeave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(34, 2);
            label1.Margin = new Padding(52, 0, 3, 0);
            label1.Name = "label1";
            label1.Size = new Size(67, 21);
            label1.TabIndex = 36;
            label1.Text = "Refresh";
            label1.MouseEnter += button2_MouseEnter;
            label1.MouseLeave += button2_MouseLeave;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.reset_14435;
            pictureBox2.Location = new Point(0, 0);
            pictureBox2.Margin = new Padding(3, 2, 3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(34, 28);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            pictureBox2.MouseEnter += button2_MouseEnter;
            pictureBox2.MouseLeave += button2_MouseLeave;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.Width = 125;
            // 
            // panel3
            // 
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(44, 15);
            panel3.Margin = new Padding(3, 15, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(1154, 37);
            panel3.TabIndex = 31;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // timer2
            // 
            timer2.Tick += timer2_Tick;
            // 
            // DotCham
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoSize = true;
            BackColor = SystemColors.ControlLightLight;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(1242, 650);
            ControlBox = false;
            Controls.Add(panel3);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "DotCham";
            Padding = new Padding(44, 15, 44, 75);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tài Khoản";
            Load += DotCham_Load;
            Resize += resize;
            panel1.ResumeLayout(false);
            pnContent.ResumeLayout(false);
            panel5.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)tableTK).EndInit();
            pnTop.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private FlowLayoutPanel flowLayoutPanel3;
        private ReaLTaiizor.Controls.PoisonDataGridView poisonDataGridView1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private Panel panel1;
        private Panel pnContent;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private Panel panel3;
        private Panel pnTop;
        private ComboBox cbbNamHoc;
        private ComboBox cbbHocKi;
        private Label label2;
        private Label label3;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label4;
        private ComboBox cbbNguoiCham;
        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label label5;
        private Label label6;
        private Panel panel2;
        private Label label7;
        private PictureBox pictureBox1;
        private Panel panel4;
        private Label label1;
        private PictureBox pictureBox2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private Panel panel5;
        private Button btnAdd;
        private ReaLTaiizor.Controls.PoisonDataGridView tableTK;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private TableLayoutPanel tableLayoutPanel2;
    }
}