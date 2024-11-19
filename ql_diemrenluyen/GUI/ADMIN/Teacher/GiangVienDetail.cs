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
        private QLGiangVien mainForm;

        public GiangVienDetailForm(string id, string name, string email, string chucvu, string khoa, bool trangThai, DataGridView dataGridView, QLGiangVien gvform)
        {
            table = dataGridView;
            mainForm = gvform;
            InitializeComponent();

            // Cập nhật các trường thông tin giảng viên
            txtId.Text = id;
            txtTenGV.Text = name;
            txtEmail.Text = email;
            comboBoxChucVu.SelectedItem = chucvu;
            txtKhoa.Text = khoa;

            // Đặt trạng thái cho comboBox
            comboBoxTrangThai.SelectedItem = trangThai ? "Hoạt động" : "Không hoạt động";

            currentGiangVienId = id;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Kiểm tra các trường nhập liệu có rỗng không
            if (string.IsNullOrWhiteSpace(txtTenGV.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(comboBoxChucVu.Text) ||
                string.IsNullOrWhiteSpace(txtKhoa.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra email hợp lệ
            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Địa chỉ email không hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra trạng thái giảng viên
            if (comboBoxTrangThai.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn trạng thái giảng viên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác nhận việc chỉnh sửa
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn cập nhật thông tin giảng viên không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                // Cập nhật thông tin giảng viên
                UpdateGiangVienInfo();
            }
        }

        private void UpdateGiangVienInfo()
        {
            // Tạo đối tượng GiangVienDTO để lưu trữ thông tin giảng viên
            GiangVienDTO giangVien = new GiangVienDTO
            {
                Id = txtId.Text,
                Name = txtTenGV.Text,
                Email = txtEmail.Text,
                ChucVu = comboBoxChucVu.SelectedItem?.ToString(),  // Fix: Use comboBoxChucVu for ChucVu
                KhoaId = txtKhoa.Text,
                TrangThai = (comboBoxTrangThai.SelectedItem?.ToString() == "Hoạt động") // Fix: Check TrangThai properly
            };

            // Gọi hàm cập nhật giảng viên từ lớp GiangVienBUS
            bool result = GiangVienBUS.UpdateGiangVien(giangVien);

            if (result)
            {
                // Cập nhật bảng giảng viên sau khi chỉnh sửa thành công
                MessageBox.Show("Cập nhật thông tin giảng viên thành công!");
                TaiKhoan.LoadAccountList(table);
                this.Close();
            }
            else
            {
                // Thông báo nếu cập nhật không thành công
                MessageBox.Show("Cập nhật thông tin giảng viên không thành công. Vui lòng kiểm tra lại!");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // Đóng form khi người dùng bấm nút "Đóng"
            this.Close();
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                // Kiểm tra email hợp lệ bằng cách tạo đối tượng MailAddress
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
