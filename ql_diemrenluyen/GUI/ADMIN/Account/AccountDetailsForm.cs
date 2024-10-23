using ql_diemrenluyen.BUS;
using ql_diemrenluyen.DTO;
using System;
using System.Windows.Forms;

namespace ql_diemrenluyen.GUI.ADMIN.Account
{
    public partial class AccountDetailsForm : Form
    {
        private long currentAccountId;
        private TaiKhoan mainForm;
        private DataGridView table;
        public AccountDetailsForm(long id, string password, string role, string rememberToken, DateTime createdAt, DateTime updatedAt, string status, DataGridView dataGridView, TaiKhoan tkform)
        {
            table = dataGridView;
            mainForm = tkform;
            InitializeComponent();

            // Set the values for the form fields
            txtId.Text = id.ToString();
            txtPassword.Text = password;
            txtRole.Text = role;
            txtRememberToken.Text = rememberToken;

            DateTime minValidDate = dtpCreatedAt.MinDate;

            if (createdAt >= minValidDate)
            {
                dtpCreatedAt.Value = createdAt;
            }
            else
            {
                dtpCreatedAt.Value = DateTime.Now;
            }
            dtpCreatedAt.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dtpCreatedAt.Format = DateTimePickerFormat.Custom;

            // Configure DateTimePicker for UpdatedAt
            if (updatedAt >= minValidDate)
            {
                dtpUpdatedAt.Value = updatedAt;
            }
            else
            {
                dtpUpdatedAt.Value = DateTime.Now; // Fallback to current date if the value is invalid
            }
            dtpUpdatedAt.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dtpUpdatedAt.Format = DateTimePickerFormat.Custom;

            // Load status into ComboBox
            comboBox1.SelectedItem = status;

            dtpCreatedAt.Enabled = false; // Chỉ cho phép chọn trường CreatedAt
            txtPassword.ReadOnly = false; // Cho phép chỉnh sửa trường mật khẩu
            comboBox1.Enabled = true; // Cho phép chọn trạng thái

            // Lưu ID của tài khoản hiện tại để sử dụng khi cập nhật
            currentAccountId = id;
        }



        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Thực hiện cập nhật tài khoản ngay khi nhấn nút Sửa
            AccountDTO account = new AccountDTO
            {
                Id = currentAccountId,
                Password = txtPassword.Text,
                Status = (comboBox1.SelectedItem.ToString() == "Hoạt động") ? 1 : 0,
                CreatedAt = dtpCreatedAt.Value,
                UpdatedAt = DateTime.Now
            };

            // Gọi phương thức cập nhật tài khoản
            bool result = AccountBUS.UpdateAccount(account);

            if (result)
            {
                MessageBox.Show("Cập nhật tài khoản thành công!");

                // Gọi phương thức để tải lại bảng trong TaiKhoan
                TaiKhoan.LoadAccountList(table); // Gọi qua tên lớp

                this.Close(); // Đóng form sau khi cập nhật thành công
            }
            else
            {
                MessageBox.Show("Cập nhật tài khoản không thành công. Vui lòng kiểm tra lại!");
            }
        }



        private void btnClose_Click(object sender, EventArgs e)
        {

        }
    }
}
