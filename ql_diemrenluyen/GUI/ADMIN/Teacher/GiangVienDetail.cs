using ql_diemrenluyen.BUS;
using ql_diemrenluyen.DTO;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Windows.Forms;

namespace ql_diemrenluyen.GUI.ADMIN.Teacher
{
    public partial class GiangVienDetailForm : Form
    {
        private string currentGiangVienId;
        private DataGridView table;
        private QLGiangVien mainForm;
        private Dictionary<int, string> trangThaiMapping = new Dictionary<int, string>
        {
            { 1, "Hoạt động" },
            { 0, "Không hoạt động" }
        };

        public GiangVienDetailForm(long id, string name, string email, string chucvu, string khoa, int trangThai, DataGridView dataGridView, QLGiangVien gvform)
        {
            table = dataGridView;
            mainForm = gvform;
            InitializeComponent();
            txtId.Text = id.ToString(); // Hiển thị dưới dạng chuỗi trong TextBox
            txtTenGV.Text = name;
            txtEmail.Text = email;
            comboBoxChucVu.SelectedIndex = comboBoxChucVu.Items.IndexOf(chucvu);
            txtKhoa.Text = khoa;
            comboBoxTrangThai.SelectedItem = trangThaiMapping[trangThai];
            currentGiangVienId = id.ToString(); // Giữ ID dưới dạng chuỗi nếu cần xử lý sau
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenGV.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(comboBoxChucVu.Text) || string.IsNullOrWhiteSpace(txtKhoa.Text) ||
                comboBoxTrangThai.SelectedItem == null || !IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng kiểm tra lại thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn cập nhật thông tin giảng viên không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                UpdateGiangVienInfo();
            }
        }

        private void UpdateGiangVienInfo()
        {
            if (!long.TryParse(txtId.Text, out long id))
            {
                MessageBox.Show("ID không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var giangVien = new GiangVienDTO
            {
                Id = id, // Chuyển đổi từ string sang long
                Name = txtTenGV.Text,
                Email = txtEmail.Text,
                ChucVu = comboBoxChucVu.SelectedItem?.ToString(),
                KhoaId = txtKhoa.Text,
                Status = string.Equals(comboBoxTrangThai.SelectedItem?.ToString(), "Hoạt động", StringComparison.OrdinalIgnoreCase) ? 1 : 0
            };

            if (GiangVienBUS.UpdateGiangVien(giangVien))
            {
                MessageBox.Show("Cập nhật thông tin giảng viên thành công!");
                mainForm.ReloadData();
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
                return new MailAddress(email).Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
