using ql_diemrenluyen.GUI.ADMIN.Evidence;
using ql_diemrenluyen.GUI.ADMIN.KhoaLop;
using ql_diemrenluyen.GUI.ADMIN.Statistic;
using ql_diemrenluyen.GUI.ADMIN.Student;
using ql_diemrenluyen.GUI.ADMIN.TieuChi;
using ql_diemrenluyen.GUI.USER;
using ql_diemrenluyen.Helper;
using QLDiemRenLuyen;
using System.Runtime.InteropServices;

namespace ql_diemrenluyen.GUI.ADMIN
{
    public partial class MenuAdmin : Form
    {
        Dashboard form_home;
        TaiKhoan form_taikhoan;
        AdminStudentTest form_student;
        DotCham form_DotCham;
        QLTieuChi form_TieuChi;
        QLGiangVien form_GiangVien;
        QuanLyKhoaLop form_QuanLyKhoaLop;
        QLBangChung form_QLBangChung;
        Thongke form_ThongKe;
        public static PictureBox loading;

        [DllImport("user32.dll")]
        private static extern void ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern void SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }


        public MenuAdmin()
        {
            InitializeComponent();
            //mdiProp();
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.ControlBox = false;
            //this.Resize += MenuAdmin_Resize;
            this.WindowState = FormWindowState.Maximized;
            this.Activated += MenuAdmin_Activated; // Thêm sự kiện Activated
            this.MouseDown += Form_MouseDown;
            panel1.MouseDown += Panel1_MouseDown; // Gắn sự kiện MouseDown cho panel1

            // Khởi tạo PictureBox loading
            loading = Loading.CreateLoadingControl(this);

            if (Program.role == 3)
            {
                panel11.Visible = true;
                panel4.Visible = true;
                panel2.Visible = true;
                TimKiemSinhVien tk = new TimKiemSinhVien(null, null);
            }
            else if (Program.role == 4)
            {
                panel11.Visible = true;
                panel4.Visible = true;
                panel5.Visible = true;
                panel9.Visible = true;
                panel2.Visible = true;
            }
            else
            {
                panel11.Visible = true;
                panel4.Visible = true;
                panel5.Visible = true;
                panel9.Visible = true;
                panel8.Visible = true;
                panel6.Visible = true;
                panel3.Visible = true;
                if (Program.role == 5)
                {
                    panel2.Visible = true;
                    panel3.Visible = false;
                }
                else panel2.Visible = false;
            }




        }
        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture(); // Giải phóng chuột để nhận sự kiện kéo
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0); // Gửi thông báo kéo đến Windows
            }
        }



        // Hàm để di chuyển form khi người dùng nhấn và kéo
        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void MenuAdmin_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                UpdateChildFormSize();
            }
            else if (this.WindowState == FormWindowState.Minimized)
            {
                // Khi thu nhỏ, đặt padding trái và phải là 50 pixel
                int padding = 50;

                foreach (Form childForm in this.MdiChildren)
                {
                    childForm.Size = new Size(this.ClientSize.Width - (padding * 2), this.ClientSize.Height);
                    childForm.Location = new Point(padding, 0); // Đặt vị trí để tạo padding
                }
            }
        }


        private void MenuAdmin_Activated(object sender, EventArgs e)
        {

            UpdateChildFormSize(); // Cập nhật kích thước khi cửa sổ được khôi phục

        }

        private void UpdateChildFormSize()
        {
            //// Tính toán kích thước còn lại của vùng MDI
            //var clientSize = this.ClientSize;

            //// Nếu có form_home, cập nhật kích thước
            //if (form_home != null && !form_home.IsDisposed)
            //{
            //    form_home.Size = clientSize;
            //    form_home.Location = new Point(0, 0); // Đặt ở vị trí (0, 0)
            //    form_home.PerformLayout();
            //}

            //// Nếu có form_taikhoan, cập nhật kích thước
            //if (form_taikhoan != null && !form_taikhoan.IsDisposed)
            //{
            //    form_taikhoan.Size = clientSize;
            //    form_taikhoan.Location = new Point(0, 0); // Đặt ở vị trí (0, 0)
            //    form_taikhoan.PerformLayout();
            //}

            //// Nếu có form_student, cập nhật kích thước
            //if (form_student != null && !form_student.IsDisposed)
            //{
            //    form_student.Size = clientSize;
            //    form_student.Location = new Point(0, 0); // Đặt ở vị trí (0, 0)
            //    form_student.PerformLayout();
            //}
            //// Nếu có form_student, cập nhật kích thước
            //if (form_student != null && !form_student.IsDisposed)
            //{
            //    form_student.Size = clientSize;
            //    form_student.Location = new Point(0, 0); // Đặt ở vị trí (0, 0)
            //    form_student.PerformLayout();
            //}
        }

        private void MenuAdmin_Load(object sender, EventArgs e)
        {
            // Sidebar và các thiết lập khác
            sidebar.Width = 300;
            this.MouseDown += Form_MouseDown;


            // Kiểm tra điều kiện về role
            if (Program.role == 0)
            {
                // Nếu role == 0, load form_taikhoan
                btnUser.BackColor = Color.LightBlue;
                if (form_taikhoan == null)
                {
                    form_taikhoan = new TaiKhoan(); // Giả sử form_taikhoan là TaiKhoanForm
                    form_taikhoan.FormClosed += TaiKhoan_FormClosed;
                    form_taikhoan.FormBorderStyle = FormBorderStyle.None;
                    form_taikhoan.ControlBox = false;
                    form_taikhoan.MdiParent = this;
                    form_taikhoan.Location = new Point(0, 0);
                    form_taikhoan.Size = this.ClientSize; // Kích thước form_taikhoan bằng kích thước vùng MDI
                    form_taikhoan.Show();
                }
                else
                {
                    form_taikhoan.Activate();
                }
            }
            else
            {
                // Nếu role khác 0, load form_home
                btnHomepage.BackColor = Color.LightBlue;
                if (form_home == null)
                {
                    form_home = new Dashboard();
                    form_home.FormClosed += HomePage_FormClosed;
                    form_home.FormBorderStyle = FormBorderStyle.None;
                    form_home.ControlBox = false;
                    form_home.MdiParent = this;
                    form_home.Location = new Point(0, 0);
                    form_home.Size = this.ClientSize; // Kích thước form_home bằng kích thước vùng MDI
                    form_home.Show();
                }
                else
                {
                    form_home.Activate();
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            sideBarTransiton.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // TODO: Thêm chức năng cho button2
        }

        private void mdiProp()
        {
            this.SetBevel(false);
            var mdiClient = this.Controls.OfType<MdiClient>().FirstOrDefault();
            if (mdiClient != null)
            {
                mdiClient.BackColor = Color.FromArgb(255, 232, 232, 232);
            }
        }

        private void ClearMdiForms()
        {
            foreach (Form childForm in this.MdiChildren)
            {
                childForm.Close();
            }
        }

        bool sideBarExpand = true;

        //Thanh sidebar menu
        private void sideBarTransiton_Tick(object sender, EventArgs e)
        {
            int formMinWidth = 1200;
            if (this.Width > formMinWidth)
            {
                if (sideBarExpand)
                {
                    sidebar.Width -= 20;
                    if (sidebar.Width <= 99)
                    {
                        sideBarExpand = false;
                        sideBarTransiton.Stop();
                    }
                }
                else
                {
                    sidebar.Width += 20;
                    if (sidebar.Width >= 300)
                    {
                        sideBarExpand = true;
                        sideBarTransiton.Stop();
                    }
                }
                UpdateButtonWidths();
            }

        }

        private void UpdateButtonWidths()
        {
            btnHomepage.Width = sidebar.Width;
            btnUser.Width = sidebar.Width;
            btnStudent.Width = sidebar.Width;
            btnTieuChi.Width = sidebar.Width;
            btnGiangVien.Width = sidebar.Width;
            btnDotCham.Width = sidebar.Width;
            btnClass.Width = sidebar.Width;
            btnLogOut.Width = sidebar.Width;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearMdiForms();
            btnHomepage.BackColor = Color.LightBlue;
            if (form_home == null)
            {
                form_home = new Dashboard();
                form_home.FormClosed += HomePage_FormClosed;
                form_home.FormBorderStyle = FormBorderStyle.None;
                form_home.ControlBox = false;
                form_home.MdiParent = this;
                form_home.Dock = DockStyle.Fill; // Đặt DockStyle.Fill để tự động chiếm toàn bộ không gian MDI
                form_home.Show();
            }
            else
            {
                form_home.Activate();
            }
        }

        private void HomePage_FormClosed(object sender, EventArgs e)
        {
            btnHomepage.BackColor = Color.RoyalBlue;
            form_home = null;
        }

        private void btnUser_Click(object sender, EventArgs e) // Nút quản lý người dùng
        {
            ClearMdiForms();
            btnUser.BackColor = Color.LightBlue;
            if (form_taikhoan == null)
            {
                form_taikhoan = new TaiKhoan();
                form_taikhoan.FormClosed += TaiKhoan_FormClosed;
                form_taikhoan.MdiParent = this;
                form_taikhoan.Dock = DockStyle.Fill; // Đặt DockStyle.Fill để tự động chiếm toàn bộ không gian MDI
                form_taikhoan.Show();
            }
            else
            {
                form_taikhoan.Activate();
            }

            //// Tạo loading animation
            //var loading = Loading.CreateLoadingControl(this);
            //Helper.Loading.ShowLoading(loading);

            //Task.Run(() =>
            //{
            //    if (form_taikhoan == null)
            //    {
            //        form_taikhoan = new TaiKhoan();
            //        // Tạo form tài khoản trên UI thread
            //        this.Invoke(new Action(() =>
            //        {

            //            form_taikhoan.FormClosed += TaiKhoan_FormClosed;
            //            form_taikhoan.FormBorderStyle = FormBorderStyle.None;
            //            form_taikhoan.ControlBox = false;
            //            form_taikhoan.MdiParent = this;
            //            form_taikhoan.Dock = DockStyle.Fill; // Đặt DockStyle.Fill để tự động chiếm toàn bộ không gian MDI
            //            form_taikhoan.Show();

            //            Loading.HideLoading(loading); // Ẩn loading sau khi form hiển thị
            //        }));
            //    }
            //    else
            //    {
            //        this.Invoke(new Action(() =>
            //        {
            //            form_taikhoan.Activate();
            //            Loading.HideLoading(loading); // Ẩn loading nếu form đã tồn tại
            //        }));
            //    }
            //});
        }

        private void TaiKhoan_FormClosed(object sender, EventArgs e)
        {
            btnUser.BackColor = Color.RoyalBlue;
            form_taikhoan = null; // Đặt biến thành null khi form bị đóng
        }

        private void btnStudent_Click(object sender, EventArgs e) // Nút quản lý sinh viên
        {
            ClearMdiForms();
            btnStudent.BackColor = Color.LightBlue;
            if (form_student == null)
            {
                form_student = new AdminStudentTest();
                form_student.FormClosed += AdminStudentTest_FormClosed;
                form_student.FormBorderStyle = FormBorderStyle.None;
                form_student.ControlBox = false;
                form_student.MdiParent = this;
                form_student.Dock = DockStyle.Fill;
                form_student.Show();
                form_student.WindowState = FormWindowState.Normal;
            }
            else
            {
                form_student.Activate();
            }
        }
        private void AdminStudentTest_FormClosed(object sender, EventArgs e)
        {
            btnStudent.BackColor = Color.RoyalBlue;

            form_student = null; // Đặt biến thành null khi form bị đóng
        }
        private void btnTieuChi_Click(object sender, EventArgs e) // Nút tiêu chí
        {
            ClearMdiForms();
            btnTieuChi.BackColor = Color.LightBlue;

            if (form_TieuChi == null)
            {
                form_TieuChi = new QLTieuChi();
                form_TieuChi.FormClosed += FormTieuChi_FormClosed; // Gán sự kiện FormClosed cho form_TieuChi
                form_TieuChi.FormBorderStyle = FormBorderStyle.None;
                form_TieuChi.ControlBox = false;
                form_TieuChi.MdiParent = this;
                form_TieuChi.Dock = DockStyle.Fill; // Đặt DockStyle.Fill để tự động chiếm toàn bộ không gian MDI
                form_TieuChi.Show();
            }
            else
            {
                form_TieuChi.Activate();
            }
        }
        private void FormTieuChi_FormClosed(object sender, EventArgs e)
        {
            btnTieuChi.BackColor = Color.RoyalBlue;

            form_TieuChi = null; // Đặt form_TieuChi về null khi form bị đóng
        }
        private void btnGiangVien_Click(object sender, EventArgs e) // Nút quản lý giảng viên
        {
            ClearMdiForms();
            btnGiangVien.BackColor = Color.LightBlue;

            if (form_GiangVien == null)
            {
                form_GiangVien = new QLGiangVien();
                form_GiangVien.FormClosed += QLGiangVien_FormClosed; // Gán sự kiện FormClosed cho form_GiangVien
                form_GiangVien.FormBorderStyle = FormBorderStyle.None;
                form_GiangVien.ControlBox = false;
                form_GiangVien.MdiParent = this;
                form_GiangVien.Dock = DockStyle.Fill; // Đặt DockStyle.Fill để tự động chiếm toàn bộ không gian MDI
                form_GiangVien.Show();
            }
            else
            {
                form_GiangVien.Activate();
            }
        }
        private void QLGiangVien_FormClosed(object sender, EventArgs e)
        {
            btnGiangVien.BackColor = Color.RoyalBlue;

            form_GiangVien = null; // Đặt form_DotCham về null khi form bị đóng
        }
        private void btnDotCham_Click(object sender, EventArgs e) // Nút đợt chấm
        {
            ClearMdiForms();
            btnDotCham.BackColor = Color.LightBlue;
            if (form_DotCham == null)
            {
                form_DotCham = new DotCham();
                form_DotCham.FormClosed += DotCham_FormClosed; // Gán sự kiện FormClosed cho form_DotCham
                form_DotCham.FormBorderStyle = FormBorderStyle.None;
                form_DotCham.ControlBox = false;
                form_DotCham.MdiParent = this;
                form_DotCham.Dock = DockStyle.Fill; // Đặt DockStyle.Fill để tự động chiếm toàn bộ không gian MDI
                form_DotCham.Show();
            }
            else
            {
                form_DotCham.Activate();
            }
        }
        private void DotCham_FormClosed(object sender, EventArgs e)
        {
            btnDotCham.BackColor = Color.RoyalBlue;

            form_DotCham = null; // Đặt form_DotCham về null khi form bị đóng
        }
        private void btnClass_Click(object sender, EventArgs e) // Nút quản lý lớp
        {
            ClearMdiForms();
            btnClass.BackColor = Color.LightBlue;

            if (form_QuanLyKhoaLop == null)
            {
                form_QuanLyKhoaLop = new QuanLyKhoaLop();
                form_QuanLyKhoaLop.FormClosed += QuanLyKhoaLop_FormClosed; // Gán sự kiện FormClosed cho form_QuanLyKhoaLop
                form_QuanLyKhoaLop.FormBorderStyle = FormBorderStyle.None;
                form_QuanLyKhoaLop.ControlBox = false;
                form_QuanLyKhoaLop.MdiParent = this;
                form_QuanLyKhoaLop.Dock = DockStyle.Fill; // Đặt DockStyle.Fill để tự động chiếm toàn bộ không gian MDI
                form_QuanLyKhoaLop.Show();
            }
            else
            {
                form_QuanLyKhoaLop.Activate();
            }
        }
        private void QuanLyKhoaLop_FormClosed(object sender, EventArgs e)
        {
            btnClass.BackColor = Color.RoyalBlue;

            form_QuanLyKhoaLop = null; // Đặt form_DotCham về null khi form bị đóng
        }
        private void btnLogOut_Click(object sender, EventArgs e) // Nút đăng xuất
        {
            this.Close();
            Login nextForm = new Login(); // Form cho admin
            nextForm.Show();
        }

        private void btnThongke_Click(object sender, EventArgs e)
        {
            ClearMdiForms();
            btnThongke.BackColor = Color.LightBlue;

            if (form_ThongKe == null)
            {
                form_ThongKe = new Thongke();
                form_ThongKe.FormClosed += ThongKe_FormClosed; // Gán sự kiện FormClosed cho form_QuanLyKhoaLop
                form_ThongKe.FormBorderStyle = FormBorderStyle.None;
                form_ThongKe.ControlBox = false;
                form_ThongKe.MdiParent = this;
                form_ThongKe.Dock = DockStyle.Fill; // Đặt DockStyle.Fill để tự động chiếm toàn bộ không gian MDI
                form_ThongKe.Show();
            }
            else
            {
                form_ThongKe.Activate();
            }
        }
        private void ThongKe_FormClosed(object sender, EventArgs e)
        {
            btnThongke.BackColor = Color.RoyalBlue;

            form_ThongKe = null; // Đặt form_DotCham về null khi form bị đóng
        }
        private void btnBangchung_Click(object sender, EventArgs e)
        {
            ClearMdiForms();
            btnBangchung.BackColor = Color.LightBlue;

            if (form_QLBangChung == null)
            {
                form_QLBangChung = new QLBangChung();
                form_QLBangChung.FormClosed += QLBangChung_FormClosed; // Gán sự kiện FormClosed cho form_QuanLyKhoaLop
                form_QLBangChung.FormBorderStyle = FormBorderStyle.None;
                form_QLBangChung.ControlBox = false;
                form_QLBangChung.MdiParent = this;
                form_QLBangChung.Dock = DockStyle.Fill; // Đặt DockStyle.Fill để tự động chiếm toàn bộ không gian MDI
                form_QLBangChung.Show();
            }
            else
            {
                form_QLBangChung.Activate();
            }
        }
        private void QLBangChung_FormClosed(object sender, EventArgs e)
        {
            btnBangchung.BackColor = Color.RoyalBlue;

            form_QLBangChung = null; // Đặt form_DotCham về null khi form bị đóng
        }
    }
}
