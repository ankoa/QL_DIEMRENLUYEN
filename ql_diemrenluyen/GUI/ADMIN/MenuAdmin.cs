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
            //this.Resize += MenuAdmin_Resize;
            this.WindowState = FormWindowState.Maximized;
            this.Activated += MenuAdmin_Activated; // Thêm sự kiện Activated
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
            // Tính toán kích thước còn lại của vùng MDI
            var clientSize = this.ClientSize;

            // Nếu có form_home, cập nhật kích thước
            if (form_home != null && !form_home.IsDisposed)
            {
                form_home.Size = clientSize;
                form_home.Location = new Point(0, 0); // Đặt ở vị trí (0, 0)
                form_home.PerformLayout();
            }

            // Nếu có form_taikhoan, cập nhật kích thước
            if (form_taikhoan != null && !form_taikhoan.IsDisposed)
            {
                form_taikhoan.Size = clientSize;
                form_taikhoan.Location = new Point(0, 0); // Đặt ở vị trí (0, 0)
                form_taikhoan.PerformLayout();
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

        bool sideBarExpand = false;
        

        private void sideBarTransiton_Tick(object sender, EventArgs e)
        {
            int formMinWidth = 1200;
            if (this.Width >formMinWidth)
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

            if (form_home == null)
            {
                form_home = new HomePage();
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

        private void HomePage_FormClosed(object sender, EventArgs e)
        {
            form_home = null;
        }

        private void btnUser_Click(object sender, EventArgs e) // Nút quản lý người dùng
        {
            ClearMdiForms();

            if (form_taikhoan == null)
            {
                form_taikhoan = new TaiKhoan();
                form_taikhoan.FormClosed += TaiKhoan_FormClosed;
                form_taikhoan.FormBorderStyle = FormBorderStyle.None;
                form_taikhoan.ControlBox = false;
                form_taikhoan.MdiParent = this;
                form_taikhoan.Dock = DockStyle.Fill; // Đặt DockStyle.Fill để tự động chiếm toàn bộ không gian MDI
                form_taikhoan.Show();
            }
            else
            {
                form_taikhoan.Activate();
            }
        }

        private void TaiKhoan_FormClosed(object sender, EventArgs e)
        {
            form_taikhoan = null; // Đặt biến thành null khi form bị đóng
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
