using ql_diemrenluyen.BUS;
using ql_diemrenluyen.DTO;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ql_diemrenluyen.GUI.ADMIN.Account
{
    public partial class AccountDetailsForm : Form
    {
        private long currentAccountId;
        private TaiKhoan mainForm;
        private DataGridView table;

        public AccountDetailsForm(long id, string password, int role, string rememberToken, DateTime createdAt, DateTime updatedAt, string status, DataGridView dataGridView, TaiKhoan tkform)
        {
            this.BackColor = Color.Black;
            table = dataGridView;
            mainForm = tkform;
            InitializeComponent();

            // Set các giá trị cho các trường trong form
            txtId.Text = id.ToString();
            txtId.ReadOnly = true; // Không cho phép chỉnh sửa trường ID

            txtPassword.Text = password;
            txtRememberToken.Text = rememberToken;

            // Cài đặt DateTimePicker cho CreatedAt
            DateTime minValidDate = dtpCreatedAt.MinDate;

            dtpCreatedAt.Value = createdAt >= minValidDate ? createdAt : DateTime.Now;
            dtpCreatedAt.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dtpCreatedAt.Format = DateTimePickerFormat.Custom;
            dtpCreatedAt.Enabled = false; // Không cho phép chỉnh sửa CreatedAt

            // Cài đặt DateTimePicker cho UpdatedAt
            dtpUpdatedAt.Value = updatedAt >= minValidDate ? updatedAt : DateTime.Now;
            dtpUpdatedAt.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dtpUpdatedAt.Format = DateTimePickerFormat.Custom;

            // Tạo ComboBox cho Role
            cmbRole.Items.AddRange(new object[] {
                "ADMIN",
                "Sinh viên",
                "Giảng viên",
                "Cố vấn học tập",
                "Quản lý Khoa",
                "Quản lý Trường"
            });

            // Chọn giá trị trong ComboBox dựa trên role
            switch (role)
            {
                case 0:
                    cmbRole.SelectedIndex = 0;
                    break;
                case 1:
                    cmbRole.SelectedIndex = 1;
                    break;
                case 2:
                    cmbRole.SelectedIndex = 2; 
                    break;
                case 3:
                    cmbRole.SelectedIndex = 3; 
                    break;
                case 4:
                    cmbRole.SelectedIndex = 4; 
                    break;
                case 5:
                    cmbRole.SelectedIndex = 5; 
                    break;
                default:
                    cmbRole.SelectedIndex = -1; 
                    break;
            }

            // Tải trạng thái vào ComboBox
            comboBox1.SelectedItem = status;
            comboBox1.Enabled = true; // Cho phép chọn trạng thái

            currentAccountId = id;
            /*string message = $"ID: {id}\n" +
                     $"Password: {password}\n" +
                     $"Role: {role}\n" +
                     $"Remember Token: {rememberToken}\n" +
                     $"Created At: {createdAt.ToString("yyyy-MM-dd HH:mm:ss")}\n" +
                     $"Updated At: {updatedAt.ToString("yyyy-MM-dd HH:mm:ss")}\n" +
                     $"Status: {status}";

            // Hiển thị thông báo trong MessageBox
            MessageBox.Show(message, "Thông tin Tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Information);*/
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text) || cmbRole.SelectedIndex == -1 || comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;  // Dừng lại nếu có trường nào bị rỗng
            }

            string passwordValidationMessage = AccountBUS.IsPasswordValid(txtPassword.Text);
            if (!string.IsNullOrEmpty(passwordValidationMessage))  // Nếu có thông báo lỗi
            {
                MessageBox.Show(passwordValidationMessage, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;  // Dừng lại nếu mật khẩu không hợp lệ
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn cập nhật tài khoản không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                // Lấy role từ ComboBox
                int role = cmbRole.SelectedIndex switch
                {
                    0 => 0,  // "ADMIN"
                    1 => 1,  // "Sinh viên"
                    2 => 2,  // "Giảng viên"
                    3 => 3,  // "Cố vấn học tập"
                    4 => 4,  // "Quản lý Khoa"
                    5 => 5,  // "Quản lý Trường"
                };

                AccountDTO account = new AccountDTO
                {
                    Id = currentAccountId,
                    Password = txtPassword.Text,
                    Role = role,  
                    Status = comboBox1.SelectedItem.ToString() == "Hoạt động" ? 1 : 0,
                    CreatedAt = dtpCreatedAt.Value,
                    UpdatedAt = DateTime.Now
                };

                bool result = AccountBUS.UpdateAccount(account);

                if (result)
                {
                    MessageBox.Show("Cập nhật tài khoản thành công!");

                    TaiKhoan.LoadAccountList(table);

                    this.Close(); 
                }
                else
                {
                    MessageBox.Show("Cập nhật tài khoản không thành công. Vui lòng kiểm tra lại!");
                }
            }
        }




        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
