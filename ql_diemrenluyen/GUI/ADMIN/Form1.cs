using MySql.Data.MySqlClient;
using ql_diemrenluyen.BUS;
using ql_diemrenluyen.DAO;
using ql_diemrenluyen.DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ql_diemrenluyen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Tạo đối tượng AccountDTO và gán giá trị trực tiếp
            AccountDTO account = new AccountDTO
            {
                Role = "User", // Ví dụ: Vai trò của tài khoản
                Password = "Password123", // Mật khẩu (đảm bảo mã hóa mật khẩu khi lưu trữ)
                RememberToken = null, // Giá trị mặc định
                CreatedAt = DateTime.Now, // Thời gian tạo
                UpdatedAt = DateTime.Now, // Thời gian cập nhật
                Status = 1 // Trạng thái tài khoản (1 cho hoạt động, 0 cho không hoạt động)
            };

            // Gọi phương thức AddAccount để thêm tài khoản
            if (AccountDAO.AddAccount(account)) // Gọi phương thức từ AccountDAO
            {
                MessageBox.Show("Thêm tài khoản thành công!");
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi thêm tài khoản.");
            }

            // Lấy danh sách tài khoản
            LoadAccounts();
        }

        private void LoadAccounts()
        {
            List<AccountDTO> accounts = AccountBUS.GetAllAccounts(); // Lấy danh sách tài khoản

            listBoxStudents.Items.Clear(); // Xóa danh sách trước khi thêm dữ liệu mới

            if (accounts.Count > 0)
            {
                foreach (var account in accounts)
                {
                    // Thêm thông tin tài khoản vào ListBox
                    listBoxStudents.Items.Add($"ID: {account.Id}, Role: {account.Role}, Status: {account.Status}");
                }
                textBox1.Text = "Kết nối thành công! Dữ liệu đã được lấy.";
            }
            else
            {
                textBox1.Text = "Kết nối thành công nhưng không có dữ liệu.";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Xử lý khi nội dung textbox thay đổi (nếu cần)
        }
    }
}
