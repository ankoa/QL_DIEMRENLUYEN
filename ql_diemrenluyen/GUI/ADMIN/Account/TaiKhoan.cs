using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ql_diemrenluyen.DAO;
using ql_diemrenluyen.DTO;
using ql_diemrenluyen.BUS;
using ql_diemrenluyen.GUI.ADMIN.Account;

namespace ql_diemrenluyen.GUI.ADMIN
{
    public partial class TaiKhoan : Form
    {
        public TaiKhoan()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.MaximizeBox = false;
            cbbRole.SelectedItem = "Mặc định";
            cbbStatus.SelectedItem = "Mặc định";
            LoadAccountList();

            if (this.Width < 1200)
            {
                pnContent.Padding = new Padding(50);
                pnContent.Dock = DockStyle.Fill;
            }
        }

        private void TaiKhoan_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.Dock = DockStyle.Fill;
            LoadAccountList();
        }

        private void LoadAccountList()
        {
            try
            {
                List<AccountDTO> accounts = AccountBUS.GetAllAccounts();
                tableTK.Rows.Clear();

                foreach (var account in accounts)
                {
                    tableTK.Rows.Add(
                        account.Id,
                        account.Password,
                        account.Role,
                        account.RememberToken,
                        account.CreatedAt.HasValue ? account.CreatedAt.Value.ToString("dd/MM/yyyy") : "",
                        account.UpdatedAt.HasValue ? account.UpdatedAt.Value.ToString("dd/MM/yyyy") : "",
                        account.Status == 1 ? "Hoạt động" : "Không hoạt động"
                    );
                }

                ApplyTableStyles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách tài khoản: " + ex.Message);
            }
        }
        public static void LoadAccountList(DataGridView table)
        {
            try
            {
                List<AccountDTO> accounts = AccountBUS.GetAllAccounts();
                table.Rows.Clear();

                foreach (var account in accounts)
                {
                    table.Rows.Add(
                        account.Id,
                        account.Password,
                        account.Role,
                        account.RememberToken,
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

        private void SearchAccountList()
        {
            try
            {
                string role = cbbRole.SelectedItem?.ToString() ?? "";
                int status = cbbStatus.SelectedItem != null ? (cbbStatus.SelectedIndex == 0 ? 1 : 0) : 0; // Giá trị mặc định là 0
                string search = txtSearch.Text.Trim();

                // Kiểm tra nếu ô tìm kiếm trống
                if (string.IsNullOrEmpty(search))
                {
                    // Nếu ô tìm kiếm trống, tải lại danh sách tài khoản mặc định
                    LoadAccountList(tableTK); // Gọi phương thức tải danh sách tài khoản mặc định
                    return; // Kết thúc phương thức
                }

                List<AccountDTO> accounts = AccountBUS.SearchAccounts(role, status, search);
                tableTK.Rows.Clear();

                foreach (var account in accounts)
                {
                    tableTK.Rows.Add(
                        account.Id,
                        account.Password,
                        account.Role,
                        account.RememberToken,
                        account.CreatedAt.HasValue ? account.CreatedAt.Value.ToString("dd/MM/yyyy") : "",
                        account.UpdatedAt.HasValue ? account.UpdatedAt.Value.ToString("dd/MM/yyyy") : "",
                        account.Status == 1 ? "Hoạt động" : "Không hoạt động"
                    );
                }

                ApplyTableStyles(); // Nếu phương thức này cần tham số thì hãy truyền tableTK vào đây
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm tài khoản: " + ex.Message);
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
                string role = selectedRow.Cells["dataGridViewTextBoxColumn3"].Value?.ToString() ?? "";
                string rememberToken = selectedRow.Cells["dataGridViewTextBoxColumn6"].Value?.ToString() ?? "";
                string status = selectedRow.Cells["dataGridViewTextBoxColumn4"].Value?.ToString() ?? "";

                DateTime createdAt = DateTime.TryParse(selectedRow.Cells["dataGridViewTextBoxColumn7"].Value?.ToString(), out DateTime tempCreatedAt)
                    ? tempCreatedAt : DateTime.MinValue;
                DateTime updatedAt = DateTime.TryParse(selectedRow.Cells["dataGridViewTextBoxColumn8"].Value?.ToString(), out DateTime tempUpdatedAt)
                    ? tempUpdatedAt : DateTime.MinValue;

                AccountDetailsForm detailsForm = new AccountDetailsForm(id, password, role, rememberToken, createdAt, updatedAt, status, tableTK, this);
                detailsForm.Show();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

            SearchAccountList();

        }

        private void cbbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchAccountList();
        }

        private void cbbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchAccountList();
        }
    }
}
