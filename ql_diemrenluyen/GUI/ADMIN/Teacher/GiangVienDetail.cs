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

            txtId.Text = id;
            txtTenGV.Text = name;
            txtEmail.Text = email;
            txtChucVu.Text = chucvu;
            txtKhoa.Text = khoa;
            comboBoxTrangThai.SelectedItem = trangThai ? "Hoạt động" : "Không hoạt động";

            currentGiangVienId = id;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenGV.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtChucVu.Text) ||
                string.IsNullOrWhiteSpace(txtKhoa.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Địa chỉ email không hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBoxTrangThai.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn trạng thái giảng viên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn cập nhật thông tin giảng viên không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                UpdateGiangVienInfo();
            }
        }

        private void UpdateGiangVienInfo()
        {
            GiangVienDTO giangVien = new GiangVienDTO
            {
                Id = txtId.Text,
                Name = txtTenGV.Text,
                Email = txtEmail.Text,
                ChucVu = txtChucVu.Text,
                KhoaId = txtKhoa.Text,
                TrangThai = (comboBoxTrangThai.SelectedItem?.ToString() == "Hoạt động")
            };

            bool result = GiangVienBUS.UpdateGiangVien(giangVien);

            if (result)
            {
                MessageBox.Show("Cập nhật thông tin giảng viên thành công!");
                TaiKhoan.LoadAccountList(table);
                this.Close();
            }
            else
            {
                MessageBox.Show("Cập nhật thông tin giảng viên không thành công. Vui lòng kiểm tra lại!");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool IsValidEmail(string email)
        {
            try
            {
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
