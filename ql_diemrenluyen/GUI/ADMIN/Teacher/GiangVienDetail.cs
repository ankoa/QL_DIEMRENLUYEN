using ql_diemrenluyen.BUS;
using ql_diemrenluyen.DTO;
using System;
using System.Windows.Forms;

namespace ql_diemrenluyen.GUI.ADMIN.Teacher
{
    public partial class GiangVienDetailForm : Form
    {
        private string currentGiangVienId;
        private DataGridView table;
        private TaiKhoan mainForm;

        public GiangVienDetailForm(string id, string tenGV, string email, string khoa, bool trangThai, DataGridView dataGridView, TaiKhoan tkform)
        {
            table = dataGridView;
            mainForm = tkform;
            InitializeComponent();

            // Set the values for the form fields
            txtId.Text = id;
            txtTenGV.Text = tenGV;
            txtEmail.Text = email;
            txtKhoa.Text = khoa;
            comboBoxTrangThai.SelectedItem = trangThai ? "Hoạt động" : "Ngừng hoạt động";

            // Lưu ID của giảng viên hiện tại để sử dụng khi cập nhật
            currentGiangVienId = id;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận trước khi cập nhật giảng viên
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn cập nhật thông tin giảng viên không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                // Thực hiện cập nhật thông tin giảng viên khi nhấn nút Sửa
                GiangVienDTO giangVien = new GiangVienDTO
                {
                    MaGV = currentGiangVienId,
                    TenGV = txtTenGV.Text,
                    Email = txtEmail.Text,
                    Khoa = txtKhoa.Text,
                    TrangThai = (comboBoxTrangThai.SelectedItem.ToString() == "Hoạt động")
                };

                // Gọi phương thức cập nhật giảng viên
                bool result = GiangVienBUS.UpdateGiangVien(giangVien);

                if (result)
                {
                    MessageBox.Show("Cập nhật thông tin giảng viên thành công!");

                    // Gọi phương thức để tải lại bảng trong TaiKhoan
                    TaiKhoan.LoadAccountList(table); // Gọi qua tên lớp

                    this.Close(); // Đóng form sau khi cập nhật thành công
                }
                else
                {
                    MessageBox.Show("Cập nhật thông tin giảng viên không thành công. Vui lòng kiểm tra lại!");
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
