using ql_diemrenluyen.BUS;
using ql_diemrenluyen.DTO;

namespace ql_diemrenluyen.GUI.ADMIN
{
    public partial class QLGiangVien : Form
    {
        public QLGiangVien()
        {
            InitializeComponent();
            InitializeUI();
        }

        // Hàm khởi tạo giao diện
        private void InitializeUI()
        {
            this.Dock = DockStyle.Fill; // Đặt Dock để chiếm toàn bộ không gian
            cbbRole.SelectedItem = "Mặc định";
            cbbStatus.SelectedItem = "Mặc định";
            LoadGiangVienList(tableGV);

            if (this.Width < 1200)
            {
                pnContent.Padding = new Padding(50);
                pnContent.Dock = DockStyle.Fill;
            }

            InitializePlaceholder(txtSearch, "Nhập từ khóa tìm kiếm...");
        }

        // Hàm tải danh sách giảng viên
        public static void LoadGiangVienList(DataGridView table)
        {
            try
            {
                List<GiangVienDTO> giangViens = GiangVienBUS.GetAllGiangVien();
                PopulateGiangVienTable(giangViens, table);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách giảng viên: " + ex.Message);
            }
        }

        // Hàm tìm kiếm giảng viên
        private void SearchGiangVienList()
        {
            try
            {
                string search = txtSearch.Text.Trim();
                if (search.Equals("Nhập từ khóa tìm kiếm..."))
                    search = null;

                List<GiangVienDTO> giangViens = string.IsNullOrEmpty(search)
                    ? GiangVienBUS.GetAllGiangVien()
                    : GiangVienBUS.SearchGiangVien(search);

                PopulateGiangVienTable(giangViens, tableGV);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
            }
        }

        // Hàm tái sử dụng để cập nhật bảng giảng viên
        private static void PopulateGiangVienTable(List<GiangVienDTO> giangViens, DataGridView table)
        {
            table.Rows.Clear();

            foreach (var giangVien in giangViens)
            {
                table.Rows.Add(
                    giangVien.Id,
                    giangVien.Name,
                    giangVien.Email,
                    giangVien.ChucVu,
                    giangVien.KhoaId,
                    giangVien.CreatedAt?.ToString("dd/MM/yyyy") ?? "",
                    giangVien.UpdatedAt?.ToString("dd/MM/yyyy") ?? "",
                    giangVien.Status == 1 ? "Hoạt động" : "Không hoạt động"
                );
            }

            ApplyTableStyles(table);
        }

        // Hàm áp dụng phong cách cho bảng giảng viên
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

        // Hàm khởi tạo placeholder cho TextBox
        private void InitializePlaceholder(TextBox textBox, string placeholder)
        {
            textBox.Text = placeholder;
            textBox.ForeColor = Color.Gray;

            textBox.Enter += (sender, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            };

            textBox.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = Color.Gray;
                }
            };
        }

        // Sự kiện thay đổi văn bản tìm kiếm
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchGiangVienList();
        }

        // Sự kiện nút Clear (Xóa tìm kiếm)
        private void btnClear_Click(object sender, EventArgs e)
        {
            // Reset các trường tìm kiếm
            txtSearch.Text = "Nhập từ khóa tìm kiếm...";
            txtSearch.ForeColor = Color.Gray;

            // Reload danh sách giảng viên mặc định
            LoadGiangVienList(tableGV);
        }

        // Sự kiện double click vào một hàng trong bảng giảng viên
        private void table_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = tableGV.Rows[e.RowIndex];

                long id = (long)selectedRow.Cells["IdColumn"].Value;
                string name = selectedRow.Cells["NameColumn"].Value?.ToString() ?? "";
                string email = selectedRow.Cells["EmailColumn"].Value?.ToString() ?? "";
                string chucVu = selectedRow.Cells["ChucVuColumn"].Value?.ToString() ?? "";
                string khoaId = selectedRow.Cells["KhoaColumn"].Value?.ToString() ?? "";
                string status = selectedRow.Cells["StatusColumn"].Value?.ToString() ?? "";

                // Chuyển sang form chi tiết giảng viên (khi cần sử dụng)
                // GiangVienDetailForm detailsForm = new GiangVienDetailForm(id, name, email, chucVu, khoaId, table, this);
                // detailsForm.Show();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
