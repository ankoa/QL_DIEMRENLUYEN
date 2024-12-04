using ql_diemrenluyen.BUS;
using ql_diemrenluyen.DTO;
using ql_diemrenluyen.GUI.ADMIN.Account;
using ql_diemrenluyen.Util.ExcelImporter;

namespace ql_diemrenluyen.GUI.ADMIN
{
    public partial class TaiKhoan : Form
    {
        public TaiKhoan()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill; // Đặt Dock để chiếm toàn bộ không gian
            cbbRole.SelectedItem = "Mặc định";
            cbbStatus.SelectedItem = "Mặc định";
            //LoadAccountList();

            if (this.Width < 1200)
            {
                pnContent.Padding = new Padding(50);
                pnContent.Dock = DockStyle.Fill;
            }
            InitializePlaceholder(txtSearch, "Nhập từ khóa tìm kiếm...");
        }

        private void TaiKhoan_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill; // Đảm bảo chiếm toàn bộ không gian
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            LoadAccountList();
        }

        private void LoadAccountList()
        {
            try
            {
                List<AccountDTO> accounts = AccountBUS.GetAllAccounts();
                tableTK.Rows.Clear();

                foreach (var account in accounts.Where(acc => acc.Id != 0))
                {
                    // Ánh xạ vai trò từ mã số thành tên vai trò
                    string roleName = GetRoleName(account.Role);  // Dùng phương thức GetRoleName để lấy tên vai trò

                    tableTK.Rows.Add(
                        account.Id,
                        account.Password,
                        roleName,  // Hiển thị tên vai trò thay vì mã vai trò
                        account.CreatedAt.HasValue ? account.CreatedAt.Value.ToString("dd/MM/yyyy") : "",
                        account.UpdatedAt.HasValue ? account.UpdatedAt.Value.ToString("dd/MM/yyyy") : "",
                        account.Status == 1 ? "Hoạt động" : "Không hoạt động"
                    );
                }

                ApplyTableStyles(); // Áp dụng kiểu dáng cho bảng
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách tài khoản: " + ex.Message);
            }
        }
        private void InitializePlaceholder(TextBox textBox, string placeholder)
        {
            // Gán giá trị ban đầu cho TextBox là placeholder
            textBox.Text = placeholder;
            textBox.ForeColor = Color.Gray; // Màu chữ placeholder (màu xám)

            // Sự kiện khi người dùng click vào TextBox (enter vào TextBox)
            textBox.Enter += (sender, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black; // Màu chữ khi người dùng bắt đầu nhập liệu
                }
            };

            // Sự kiện khi người dùng rời khỏi TextBox (leave khỏi TextBox)
            textBox.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = Color.Gray; // Màu chữ placeholder khi TextBox trống
                }
            };
        }
        public static void LoadAccountList(DataGridView table)
        {
            try
            {
                List<AccountDTO> accounts = AccountBUS.GetAllAccounts();
                table.Rows.Clear();

                foreach (var account in accounts.Where(acc => acc.Id != 0))
                {
                    string roleName = GetRoleName(account.Role);  // Ánh xạ mã số vai trò sang tên vai trò

                    table.Rows.Add(
                        account.Id,
                        account.Password,
                        roleName,  // Hiển thị tên vai trò thay vì mã số vai trò
                        account.CreatedAt.HasValue ? account.CreatedAt.Value.ToString("dd/MM/yyyy") : "",
                        account.UpdatedAt.HasValue ? account.UpdatedAt.Value.ToString("dd/MM/yyyy") : "",
                        account.Status == 1 ? "Hoạt động" : "Không hoạt động"
                    );
                }

                ApplyTableStyles(table); // Gọi phương thức để áp dụng kiểu dáng
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách tài khoản: " + ex.Message);
            }
        }

        // Phương thức ánh xạ mã số vai trò sang tên vai trò
        private static string GetRoleName(int role)
        {
            return role switch
            {
                0 => "ADMIN",               // ADMIN
                1 => "Sinh viên",           // Sinh viên
                2 => "Giảng viên",          // Giảng viên
                3 => "Cố vấn học tập",      // Cố vấn học tập
                4 => "Quản lý Khoa",        // Quản lý Khoa
                5 => "Quản lý Trường",      // Quản lý Trường
                _ => "Mặc định"             // Mặc định nếu không khớp
            };
        }



        // Hàm áp dụng style cho bảng
        private void ApplyTableStyles()
        {
            tableTK.RowTemplate.Height = 40;
            tableTK.BorderStyle = BorderStyle.Fixed3D;
            tableTK.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle
            {
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                BackColor = Color.RoyalBlue,
                ForeColor = Color.White
            };

            tableTK.ColumnHeadersDefaultCellStyle = headerStyle;
            tableTK.EnableHeadersVisualStyles = false;
            tableTK.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            tableTK.DefaultCellStyle.SelectionForeColor = Color.Black;
        }
        // Định nghĩa lại phương thức ApplyTableStyles
        private static void ApplyTableStyles(DataGridView table)
        {
            table.RowTemplate.Height = 40;
            table.BorderStyle = BorderStyle.Fixed3D;
            table.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle
            {
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                BackColor = Color.RoyalBlue,
                ForeColor = Color.White
            };

            table.ColumnHeadersDefaultCellStyle = headerStyle;
            table.EnableHeadersVisualStyles = false;
            table.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            table.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        // Hàm tìm kiếm tài khoản theo role, status và search term

        // Cập nhật phương thức SearchAccountList
        private void SearchAccountList()
        {
            try
            {
                int role = cbbRole.SelectedItem?.ToString() switch
                {
                    "Mặc định" => -1,
                    "ADMIN" => 0,
                    "Sinh viên" => 1,
                    "Giảng viên" => 2,
                    "Cố vấn học tập" => 3,
                    "Quản lý Khoa" => 4,
                    "Quản lý Trường" => 5,
                    _ => -1
                };

                int status = cbbStatus.SelectedItem?.ToString() == "Mặc định" ? -1 :
                             (cbbStatus.SelectedItem?.ToString() == "Hoạt động" ? 1 : 0);

                string search = txtSearch.Text;
                //MessageBox.Show(role +"   "+ status+"  " +search, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (search.Equals("Nhập từ khóa tìm kiếm..."))
                {
                    search = null;
                }

                // Kiểm tra nếu không có điều kiện nào được nhập, tải danh sách tài khoản mặc định
                if (role == -1 && status == -1 && string.IsNullOrEmpty(search))
                {
                    LoadAccountList(tableTK);
                    return;
                }

                List<AccountDTO> accounts = AccountBUS.SearchAccounts(role, status, search);

                tableTK.Rows.Clear();

                if (accounts != null && accounts.Count > 0)
                {
                    // Xóa các hàng cũ trong table

                    // Đổ dữ liệu vào bảng
                    foreach (var account in accounts.Where(acc => acc.Id != 0))
                    {
                        tableTK.Rows.Add(
                            account.Id,
                            account.Password,
                            GetRoleName(account.Role),  // Sử dụng phương thức GetRoleName để lấy tên vai trò
                            account.CreatedAt.HasValue ? account.CreatedAt.Value.ToString("dd/MM/yyyy") : "",
                            account.UpdatedAt.HasValue ? account.UpdatedAt.Value.ToString("dd/MM/yyyy") : "",
                            account.Status == 1 ? "Hoạt động" : "Không hoạt động"
                        );
                    }

                    ApplyTableStyles(); // Áp dụng style cho bảng
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
            }
        }


        // Hàm tìm kiếm khi thay đổi nội dung trong các textbox hoặc combobox



        private void tableTK_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = tableTK.Rows[e.RowIndex];

                long id = (long)selectedRow.Cells["dataGridViewTextBoxColumn1"].Value;
                string password = selectedRow.Cells["dataGridViewTextBoxColumn5"].Value?.ToString() ?? "";

                // Chuyển giá trị role từ string sang int?
                string roleString = selectedRow.Cells["dataGridViewTextBoxColumn3"].Value?.ToString() ?? "";
                int role = roleString switch
                {
                    "Mặc định" => -1,
                    "ADMIN" => 0,
                    "Sinh viên" => 1,
                    "Giảng viên" => 2,
                    "Cố vấn học tập" => 3,
                    "Quản lý Khoa" => 4,
                    "Quản lý Trường" => 5,
                };

                string status = selectedRow.Cells["dataGridViewTextBoxColumn4"].Value?.ToString() ?? "";

                DateTime createdAt = DateTime.TryParse(selectedRow.Cells["dataGridViewTextBoxColumn7"].Value?.ToString(), out DateTime tempCreatedAt)
                    ? tempCreatedAt : DateTime.MinValue;
                DateTime updatedAt = DateTime.TryParse(selectedRow.Cells["dataGridViewTextBoxColumn8"].Value?.ToString(), out DateTime tempUpdatedAt)
                    ? tempUpdatedAt : DateTime.MinValue;

                // Chuyển thông tin sang form chi tiết
                AccountDetailsForm detailsForm = new AccountDetailsForm(id, role, createdAt, updatedAt, status, tableTK, this);
                detailsForm.Show();
            }
        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

            SearchAccountList();

        }

        private void cbbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            int role = -1;  // Mặc định là -1 nếu không chọn gì
            if (cbbRole.SelectedItem != null)
            {
                role = cbbRole.SelectedItem.ToString() switch
                {
                    "ADMIN" => 0,
                    "Sinh viên" => 1,
                    "Giảng viên" => 2,
                    "Cố vấn học tập" => 3,
                    "Quản lý Khoa" => 4,
                    "Quản lý Trường" => 5,
                    _ => -1
                };
            }

            // Thực hiện tìm kiếm sau khi cập nhật giá trị role
            SearchAccountList();
        }

        private void cbbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchAccountList();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Reset combo boxes to "Mặc định"
            cbbRole.SelectedItem = "Mặc định";
            cbbStatus.SelectedItem = "Mặc định";

            // Clear the search text box and reset placeholder
            txtSearch.Text = "Nhập từ khóa tìm kiếm...";
            txtSearch.ForeColor = Color.Gray; // Set placeholder color

            // Reload the account list without filters
            LoadAccountList();
        }

        private void pnTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Chuyển đổi danh sách sang List<Dictionary<string, string>>
            var dictionaryList = ExcelExporter.ConvertListToDictionaryList(LopBUS.GetLopHocToExports());

            // Xuất ra Excel
            ExcelExporter.ExportListToExcel(dictionaryList);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xlsx;*.xls";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    try
                    {
                        ImportLop importer = new ImportLop();
                        var importedStudents = importer.ImportFromExcel(filePath);

                        MessageBox.Show($"Import thành công {importedStudents.Count} sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi import dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
