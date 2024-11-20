namespace ql_diemrenluyen.GUI.ADMIN
{
    partial class MenuAdmin
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuAdmin));
            panel1 = new Panel();
            label1 = new Label();
            btnHam = new PictureBox();
            sidebar = new FlowLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel2 = new Panel();
            btnHomepage = new Button();
            panel3 = new Panel();
            btnUser = new Button();
            panel4 = new Panel();
            btnStudent = new Button();
            panel5 = new Panel();
            btnClass = new Button();
            panel9 = new Panel();
            btnGiangVien = new Button();
            panel8 = new Panel();
            btnDotCham = new Button();
            panel6 = new Panel();
            btnTieuChi = new Button();
            panel10 = new Panel();
            btnBangchung = new Button();
            panel11 = new Panel();
            btnThongke = new Button();
            panel7 = new Panel();
            btnLogOut = new Button();
            sideBarTransiton = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnHam).BeginInit();
            sidebar.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel9.SuspendLayout();
            panel8.SuspendLayout();
            panel6.SuspendLayout();
            panel10.SuspendLayout();
            panel11.SuspendLayout();
            panel7.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLightLight;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnHam);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1600, 83);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.RoyalBlue;
            label1.Location = new Point(110, 28);
            label1.Name = "label1";
            label1.Size = new Size(634, 38);
            label1.TabIndex = 2;
            label1.Text = "PHẦN MỀM QUẢN LÝ CHẤM ĐIỂM RÈN LUYỆN";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnHam
            // 
            btnHam.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            btnHam.BackgroundImageLayout = ImageLayout.Center;
            btnHam.Cursor = Cursors.Hand;
            btnHam.Image = (Image)resources.GetObject("btnHam.Image");
            btnHam.Location = new Point(21, 12);
            btnHam.Name = "btnHam";
            btnHam.Size = new Size(61, 54);
            btnHam.TabIndex = 0;
            btnHam.TabStop = false;
            btnHam.Click += pictureBox1_Click;
            // 
            // sidebar
            // 
            sidebar.BackColor = Color.RoyalBlue;
            sidebar.Controls.Add(flowLayoutPanel1);
            sidebar.Controls.Add(panel7);
            sidebar.Dock = DockStyle.Left;
            sidebar.Location = new Point(0, 83);
            sidebar.Margin = new Padding(0);
            sidebar.Name = "sidebar";
            sidebar.Size = new Size(326, 756);
            sidebar.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.RoyalBlue;
            flowLayoutPanel1.Controls.Add(panel2);
            flowLayoutPanel1.Controls.Add(panel3);
            flowLayoutPanel1.Controls.Add(panel4);
            flowLayoutPanel1.Controls.Add(panel5);
            flowLayoutPanel1.Controls.Add(panel9);
            flowLayoutPanel1.Controls.Add(panel8);
            flowLayoutPanel1.Controls.Add(panel6);
            flowLayoutPanel1.Controls.Add(panel10);
            flowLayoutPanel1.Controls.Add(panel11);
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(320, 682);
            flowLayoutPanel1.TabIndex = 8;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnHomepage);
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(317, 70);
            panel2.TabIndex = 2;
            // 
            // btnHomepage
            // 
            btnHomepage.BackColor = Color.RoyalBlue;
            btnHomepage.BackgroundImageLayout = ImageLayout.Zoom;
            btnHomepage.Dock = DockStyle.Fill;
            btnHomepage.FlatAppearance.BorderColor = Color.RoyalBlue;
            btnHomepage.FlatAppearance.BorderSize = 0;
            btnHomepage.FlatStyle = FlatStyle.Flat;
            btnHomepage.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHomepage.ForeColor = SystemColors.ControlLightLight;
            btnHomepage.Image = Properties.Resources.icons8_homepage_50;
            btnHomepage.ImageAlign = ContentAlignment.MiddleLeft;
            btnHomepage.Location = new Point(0, 0);
            btnHomepage.Margin = new Padding(10);
            btnHomepage.Name = "btnHomepage";
            btnHomepage.Padding = new Padding(10, 0, 0, 0);
            btnHomepage.Size = new Size(317, 70);
            btnHomepage.TabIndex = 3;
            btnHomepage.Text = "Trang chủ";
            btnHomepage.UseVisualStyleBackColor = false;
            btnHomepage.Click += button1_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(btnUser);
            panel3.Location = new Point(3, 79);
            panel3.Name = "panel3";
            panel3.Size = new Size(317, 70);
            panel3.TabIndex = 4;
            // 
            // btnUser
            // 
            btnUser.BackColor = Color.RoyalBlue;
            btnUser.BackgroundImageLayout = ImageLayout.Zoom;
            btnUser.Dock = DockStyle.Fill;
            btnUser.FlatAppearance.BorderColor = Color.RoyalBlue;
            btnUser.FlatAppearance.BorderSize = 0;
            btnUser.FlatStyle = FlatStyle.Flat;
            btnUser.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUser.ForeColor = SystemColors.ControlLightLight;
            btnUser.Image = Properties.Resources.icons8_user_60;
            btnUser.ImageAlign = ContentAlignment.MiddleLeft;
            btnUser.Location = new Point(0, 0);
            btnUser.Margin = new Padding(10);
            btnUser.Name = "btnUser";
            btnUser.Padding = new Padding(10, 0, 0, 0);
            btnUser.Size = new Size(317, 70);
            btnUser.TabIndex = 3;
            btnUser.Text = "Tài khoản";
            btnUser.UseVisualStyleBackColor = false;
            btnUser.Click += btnUser_Click;
            // 
            // panel4
            // 
            panel4.Controls.Add(btnStudent);
            panel4.Location = new Point(3, 155);
            panel4.Name = "panel4";
            panel4.Size = new Size(317, 70);
            panel4.TabIndex = 5;
            // 
            // btnStudent
            // 
            btnStudent.BackColor = Color.RoyalBlue;
            btnStudent.BackgroundImageLayout = ImageLayout.Zoom;
            btnStudent.Dock = DockStyle.Fill;
            btnStudent.FlatAppearance.BorderColor = Color.RoyalBlue;
            btnStudent.FlatAppearance.BorderSize = 0;
            btnStudent.FlatStyle = FlatStyle.Flat;
            btnStudent.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnStudent.ForeColor = SystemColors.ControlLightLight;
            btnStudent.Image = Properties.Resources.icons8_student_50;
            btnStudent.ImageAlign = ContentAlignment.MiddleLeft;
            btnStudent.Location = new Point(0, 0);
            btnStudent.Margin = new Padding(10);
            btnStudent.Name = "btnStudent";
            btnStudent.Padding = new Padding(10, 0, 0, 0);
            btnStudent.Size = new Size(317, 70);
            btnStudent.TabIndex = 3;
            btnStudent.Text = "Sinh viên";
            btnStudent.UseVisualStyleBackColor = false;
            btnStudent.Click += btnStudent_Click;
            // 
            // panel5
            // 
            panel5.Controls.Add(btnClass);
            panel5.Location = new Point(3, 231);
            panel5.Name = "panel5";
            panel5.Size = new Size(317, 70);
            panel5.TabIndex = 6;
            // 
            // btnClass
            // 
            btnClass.BackColor = Color.RoyalBlue;
            btnClass.BackgroundImageLayout = ImageLayout.Zoom;
            btnClass.Dock = DockStyle.Fill;
            btnClass.FlatAppearance.BorderColor = Color.RoyalBlue;
            btnClass.FlatAppearance.BorderSize = 0;
            btnClass.FlatStyle = FlatStyle.Flat;
            btnClass.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClass.ForeColor = SystemColors.ControlLightLight;
            btnClass.Image = Properties.Resources.icons8_class_50__1_;
            btnClass.ImageAlign = ContentAlignment.MiddleLeft;
            btnClass.Location = new Point(0, 0);
            btnClass.Margin = new Padding(10);
            btnClass.Name = "btnClass";
            btnClass.Padding = new Padding(10, 0, 0, 0);
            btnClass.Size = new Size(317, 70);
            btnClass.TabIndex = 3;
            btnClass.Text = "Khoa, lớp";
            btnClass.UseVisualStyleBackColor = false;
            btnClass.Click += btnClass_Click;
            // 
            // panel9
            // 
            panel9.Controls.Add(btnGiangVien);
            panel9.Location = new Point(3, 307);
            panel9.Name = "panel9";
            panel9.Size = new Size(317, 70);
            panel9.TabIndex = 7;
            // 
            // btnGiangVien
            // 
            btnGiangVien.AutoSize = true;
            btnGiangVien.BackColor = Color.RoyalBlue;
            btnGiangVien.BackgroundImageLayout = ImageLayout.Zoom;
            btnGiangVien.Dock = DockStyle.Fill;
            btnGiangVien.FlatAppearance.BorderColor = Color.RoyalBlue;
            btnGiangVien.FlatAppearance.BorderSize = 0;
            btnGiangVien.FlatStyle = FlatStyle.Flat;
            btnGiangVien.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGiangVien.ForeColor = SystemColors.ControlLightLight;
            btnGiangVien.Image = Properties.Resources.icons8_teacher_64;
            btnGiangVien.ImageAlign = ContentAlignment.MiddleLeft;
            btnGiangVien.Location = new Point(0, 0);
            btnGiangVien.Margin = new Padding(10);
            btnGiangVien.Name = "btnGiangVien";
            btnGiangVien.Padding = new Padding(10, 0, 0, 0);
            btnGiangVien.Size = new Size(317, 70);
            btnGiangVien.TabIndex = 3;
            btnGiangVien.Text = "Giảng viên";
            btnGiangVien.UseVisualStyleBackColor = false;
            btnGiangVien.Click += btnGiangVien_Click;
            // 
            // panel8
            // 
            panel8.Controls.Add(btnDotCham);
            panel8.Location = new Point(3, 383);
            panel8.Name = "panel8";
            panel8.Size = new Size(317, 70);
            panel8.TabIndex = 5;
            // 
            // btnDotCham
            // 
            btnDotCham.BackColor = Color.RoyalBlue;
            btnDotCham.BackgroundImageLayout = ImageLayout.Zoom;
            btnDotCham.Dock = DockStyle.Fill;
            btnDotCham.FlatAppearance.BorderColor = Color.RoyalBlue;
            btnDotCham.FlatAppearance.BorderSize = 0;
            btnDotCham.FlatStyle = FlatStyle.Flat;
            btnDotCham.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDotCham.ForeColor = SystemColors.ControlLightLight;
            btnDotCham.Image = Properties.Resources.icons8_semester_64;
            btnDotCham.ImageAlign = ContentAlignment.MiddleLeft;
            btnDotCham.Location = new Point(0, 0);
            btnDotCham.Margin = new Padding(10);
            btnDotCham.Name = "btnDotCham";
            btnDotCham.Padding = new Padding(10, 0, 0, 0);
            btnDotCham.Size = new Size(317, 70);
            btnDotCham.TabIndex = 3;
            btnDotCham.Text = "Đợt chấm";
            btnDotCham.UseVisualStyleBackColor = false;
            btnDotCham.Click += btnDotCham_Click;
            // 
            // panel6
            // 
            panel6.Controls.Add(btnTieuChi);
            panel6.Location = new Point(3, 459);
            panel6.Name = "panel6";
            panel6.Size = new Size(317, 70);
            panel6.TabIndex = 6;
            // 
            // btnTieuChi
            // 
            btnTieuChi.AutoSize = true;
            btnTieuChi.BackColor = Color.RoyalBlue;
            btnTieuChi.BackgroundImageLayout = ImageLayout.Zoom;
            btnTieuChi.Dock = DockStyle.Fill;
            btnTieuChi.FlatAppearance.BorderColor = Color.RoyalBlue;
            btnTieuChi.FlatAppearance.BorderSize = 0;
            btnTieuChi.FlatStyle = FlatStyle.Flat;
            btnTieuChi.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTieuChi.ForeColor = SystemColors.ControlLightLight;
            btnTieuChi.Image = Properties.Resources.icons8_compliance_50;
            btnTieuChi.ImageAlign = ContentAlignment.MiddleLeft;
            btnTieuChi.Location = new Point(0, 0);
            btnTieuChi.Margin = new Padding(10);
            btnTieuChi.Name = "btnTieuChi";
            btnTieuChi.Padding = new Padding(10, 0, 0, 0);
            btnTieuChi.Size = new Size(317, 70);
            btnTieuChi.TabIndex = 3;
            btnTieuChi.Text = "             Tiêu chí đánh giá";
            btnTieuChi.UseVisualStyleBackColor = false;
            btnTieuChi.Click += btnTieuChi_Click;
            // 
            // panel10
            // 
            panel10.Controls.Add(btnBangchung);
            panel10.Location = new Point(3, 535);
            panel10.Name = "panel10";
            panel10.Size = new Size(317, 70);
            panel10.TabIndex = 7;
            // 
            // btnBangchung
            // 
            btnBangchung.BackColor = Color.RoyalBlue;
            btnBangchung.BackgroundImageLayout = ImageLayout.Zoom;
            btnBangchung.Dock = DockStyle.Fill;
            btnBangchung.FlatAppearance.BorderColor = Color.RoyalBlue;
            btnBangchung.FlatAppearance.BorderSize = 0;
            btnBangchung.FlatStyle = FlatStyle.Flat;
            btnBangchung.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBangchung.ForeColor = SystemColors.ControlLightLight;
            btnBangchung.Image = Properties.Resources.icons8_photo_50;
            btnBangchung.ImageAlign = ContentAlignment.MiddleLeft;
            btnBangchung.Location = new Point(0, 0);
            btnBangchung.Margin = new Padding(10);
            btnBangchung.Name = "btnBangchung";
            btnBangchung.Padding = new Padding(10, 0, 0, 0);
            btnBangchung.Size = new Size(317, 70);
            btnBangchung.TabIndex = 3;
            btnBangchung.Text = "Bằng chứng";
            btnBangchung.UseVisualStyleBackColor = false;
            btnBangchung.Click += btnBangchung_Click;
            // 
            // panel11
            // 
            panel11.Controls.Add(btnThongke);
            panel11.Location = new Point(3, 611);
            panel11.Name = "panel11";
            panel11.Size = new Size(317, 70);
            panel11.TabIndex = 8;
            // 
            // btnThongke
            // 
            btnThongke.AutoSize = true;
            btnThongke.BackColor = Color.RoyalBlue;
            btnThongke.BackgroundImageLayout = ImageLayout.Zoom;
            btnThongke.Dock = DockStyle.Fill;
            btnThongke.FlatAppearance.BorderColor = Color.RoyalBlue;
            btnThongke.FlatAppearance.BorderSize = 0;
            btnThongke.FlatStyle = FlatStyle.Flat;
            btnThongke.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThongke.ForeColor = SystemColors.ControlLightLight;
            btnThongke.Image = Properties.Resources.icons8_statistics_50;
            btnThongke.ImageAlign = ContentAlignment.MiddleLeft;
            btnThongke.Location = new Point(0, 0);
            btnThongke.Margin = new Padding(10);
            btnThongke.Name = "btnThongke";
            btnThongke.Padding = new Padding(10, 0, 0, 0);
            btnThongke.Size = new Size(317, 70);
            btnThongke.TabIndex = 3;
            btnThongke.Text = "Thống kê";
            btnThongke.UseVisualStyleBackColor = false;
            btnThongke.Click += btnThongke_Click;
            // 
            // panel7
            // 
            panel7.Controls.Add(btnLogOut);
            panel7.Dock = DockStyle.Bottom;
            panel7.Location = new Point(3, 685);
            panel7.Name = "panel7";
            panel7.Size = new Size(317, 70);
            panel7.TabIndex = 7;
            // 
            // btnLogOut
            // 
            btnLogOut.BackColor = Color.RoyalBlue;
            btnLogOut.BackgroundImageLayout = ImageLayout.Zoom;
            btnLogOut.Dock = DockStyle.Fill;
            btnLogOut.FlatAppearance.BorderColor = Color.RoyalBlue;
            btnLogOut.FlatAppearance.BorderSize = 0;
            btnLogOut.FlatStyle = FlatStyle.Flat;
            btnLogOut.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogOut.ForeColor = SystemColors.ControlLightLight;
            btnLogOut.Image = Properties.Resources.icons8_log_out_50;
            btnLogOut.ImageAlign = ContentAlignment.MiddleLeft;
            btnLogOut.Location = new Point(0, 0);
            btnLogOut.Margin = new Padding(10);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Padding = new Padding(10, 0, 0, 0);
            btnLogOut.Size = new Size(317, 70);
            btnLogOut.TabIndex = 3;
            btnLogOut.Text = "Đăng xuất";
            btnLogOut.UseVisualStyleBackColor = false;
            btnLogOut.Click += btnLogOut_Click;
            // 
            // sideBarTransiton
            // 
            sideBarTransiton.Interval = 10;
            sideBarTransiton.Tick += sideBarTransiton_Tick;
            // 
            // MenuAdmin
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.RoyalBlue;
            ClientSize = new Size(1600, 839);
            Controls.Add(sidebar);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            IsMdiContainer = true;
            Name = "MenuAdmin";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MenuAdmin";
            Load += MenuAdmin_Load;
            MouseDown += Form_MouseDown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btnHam).EndInit();
            sidebar.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panel8.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel10.ResumeLayout(false);
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            panel7.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox btnHam;
        private FlowLayoutPanel sidebar;
        private Panel panel2;
        private Button btnHomepage;
        private Panel panel3;
        private Button btnUser;
        private Panel panel4;
        private Button btnStudent;
        private Panel panel5;
        private Button btnClass;
        private Panel panel6;
        private Button btnTieuChi;
        private System.Windows.Forms.Timer sideBarTransiton;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel7;
        private Button btnLogOut;
        private Panel panel8;
        private Button btnDotCham;
        private Label label1;
        private Panel panel9;
        private Button btnGiangVien;
        private Panel panel10;
        private Button btnBangchung;
        private Panel panel11;
        private Button btnThongke;
    }
}