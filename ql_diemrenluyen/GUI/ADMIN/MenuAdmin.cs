using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ql_diemrenluyen.GUI.ADMIN
{
    public partial class MenuAdmin : Form
    {
        HomePage form_home;
        TaiKhoan form_taikhoan;
        public MenuAdmin()
        {
            InitializeComponent();
            mdiProp();
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Resize += MenuAdmin_Resize;
            this.WindowState = FormWindowState.Maximized;
            this.Resize += MenuAdmin_Resize;
        }
        private void MenuAdmin_Resize(object sender, EventArgs e)
        {
            UpdateChildFormSize(); 
        }
        private void UpdateChildFormSize()
        {
            
            if (form_home != null && !form_home.IsDisposed)
            {
                form_home.Size = this.ClientSize; 
                form_home.PerformLayout();
            }
        }
        private void MenuAdmin_Load(object sender, EventArgs e)
        {
            sidebar.Width = 99; 
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
            var mdiClient = this.Controls.OfType<MdiClient>().FirstOrDefault(); // Tìm MdiClient
            if (mdiClient != null)
            {
                mdiClient.BackColor = Color.FromArgb(255, 232, 232, 232); // Màu nền MDI
            }
        }
        private void ClearMdiForms()
        {
            // Duyệt qua tất cả các form con trong MDI parent và đóng chúng
            foreach (Form childForm in this.MdiChildren)
            {
                childForm.Close();
            }
        }

        bool sideBarExpand = false;
        private void sideBarTransiton_Tick(object sender, EventArgs e)
        {
            // Điều chỉnh chiều rộng sidebar để mở rộng hoặc thu hẹp
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
            // Cập nhật chiều rộng cho các nút
            UpdateButtonWidths();
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
            ClearMdiForms(); // Đóng tất cả các form con hiện tại trước khi mở form mới

            if (form_home == null)
            {
                form_home = new HomePage();
                form_home.FormClosed += HomePage_FormClosed;
                form_home.FormBorderStyle = FormBorderStyle.None;
                form_home.ControlBox = false;
                form_home.MdiParent = this;
                form_home.Location = new Point(0, 0);
                form_home.Size = this.ClientSize;
                form_home.Show();
            }
            else
            {
                form_home.Activate();
            }
        }

        private void HomePage_FormClosed(object sender, EventArgs e)
        {
            form_home = null;
        }
        private void btnUser_Click(object sender, EventArgs e) // Nút quản lý người dùng
        {
            ClearMdiForms(); // Đóng tất cả các form con hiện tại trước khi mở form mới

            if (form_taikhoan == null)
            {
                form_taikhoan = new TaiKhoan();
                form_taikhoan.FormClosed += HomePage_FormClosed;
                form_taikhoan.FormBorderStyle = FormBorderStyle.None; // Xóa viền
                form_taikhoan.ControlBox = false; // Ẩn thanh điều khiển
                form_taikhoan.MdiParent = this; // Đặt form parent là MenuAdmin

                form_taikhoan.Dock = DockStyle.Fill; // Đặt form con tự động vừa khít toàn bộ MDI parent
                form_taikhoan.Show();
            }
            else
            {
                form_taikhoan.Activate();
            }
        }


        private void TaiKhoan_FormClosed(object sender, EventArgs e)
        {
            form_home = null;
        }
        private void btnStudent_Click(object sender, EventArgs e) // Nút quản lý sinh viên
        {
            // TODO: Thêm chức năng cho nút quản lý sinh viên
        }

        private void btnTieuChi_Click(object sender, EventArgs e) // Nút tiêu chí
        {
            // TODO: Thêm chức năng cho nút tiêu chí
        }

        private void btnGiangVien_Click(object sender, EventArgs e) // Nút quản lý giảng viên
        {
            // TODO: Thêm chức năng cho nút quản lý giảng viên
        }

        private void btnDotCham_Click(object sender, EventArgs e) // Nút đợt chấm
        {
            // TODO: Thêm chức năng cho nút đợt chấm
        }

        private void btnClass_Click(object sender, EventArgs e) // Nút quản lý lớp
        {
            // TODO: Thêm chức năng cho nút quản lý lớp
        }

        private void btnLogOut_Click(object sender, EventArgs e) // Nút đăng xuất
        {
            // TODO: Thêm chức năng cho nút đăng xuất
        }
    }
}
