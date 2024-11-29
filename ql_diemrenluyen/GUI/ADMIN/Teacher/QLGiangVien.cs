using Google.Rpc;
using ql_diemrenluyen.BUS;
using ql_diemrenluyen.DTO;
using QLDiemRenLuyen;

namespace ql_diemrenluyen.GUI.ADMIN
{
    public partial class QLGiangVien : Form
    {
        private List<GiangVienDTO> listGiangVien = new List<GiangVienDTO>();

        public QLGiangVien()
        {
            InitializeComponent();
            InitializeUI();
        }

        // Hàm khởi tạo giao diện
        private void InitializeUI()
        {
            try
            {
                this.Dock = DockStyle.Fill; // Đặt Dock để chiếm toàn bộ không gian
                InitializePlaceholder(txtSearch, "Nhập ID, nội dung cần tìm...");
                cbbRole.SelectedItem = "Mặc định";
                cbbStatus.SelectedItem = "Mặc định";

                // Kiểm tra bảng giảng viên trước khi tải
                if (tableGV != null)
                {
                    LoadGiangVienList(tableGV);
                }
                else
                {
                    MessageBox.Show("Bảng dữ liệu giảng viên chưa được khởi tạo.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi khởi tạo giao diện: " + ex.Message);
            }
        }

        private void GiangVien_Load(object sender, EventArgs e)
        {
            try
            {
                this.Dock = DockStyle.Fill; // Đảm bảo chiếm toàn bộ không gian
                this.ControlBox = false;
                PopulateGiangVienTable(tableGV);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu giảng viên: " + ex.Message);
            }
        }

        // Hàm tải danh sách giảng viên
        public static void LoadGiangVienList(DataGridView table)
        {
            try
            {
                List<GiangVienDTO> giangViens = GiangVienBUS.GetAllGiangVien();
                if (giangViens == null || giangViens.Count == 0)
                {
                    MessageBox.Show("Danh sách giảng viên rỗng.");
                    return;
                }
                PopulateGiangVienTable(table);
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
                int status = cbbStatus.SelectedItem?.ToString() == "Mặc định" ? -1 :
                             (cbbStatus.SelectedItem?.ToString() == "Hoạt động" ? 1 : 0);

                string selectedItem = cbbRole.SelectedItem?.ToString();

                int? selectedId = null;
                if (!string.IsNullOrEmpty(selectedItem) && selectedItem != "Mặc định")
                {
                    var parts = selectedItem.Split('-');
                    if (parts.Length > 0)
                    {
                        selectedId = int.Parse(parts[0].Trim());
                    }
                }

                string search = txtSearch.Text;
                if (search.Equals("Nhập ID, nội dung cần tìm..."))
                {
                    search = null;
                }

                if (status == -1 && string.IsNullOrEmpty(search) && selectedId == null)
                {
                    LoadGiangVienList(tableGV);
                    return;
                }     

                tableGV.Rows.Clear();
                foreach (var giangVien in listGiangVien)
                {
                    tableGV.Rows.Add(
                        giangVien.Id,
                        giangVien.Name ?? "N/A",
                        giangVien.Email ?? "N/A",
                        giangVien.ChucVu  ,
                        giangVien.KhoaId  ,
                        giangVien.CreatedAt?.ToString("dd/MM/yyyy") ?? "",
                        giangVien.UpdatedAt?.ToString("dd/MM/yyyy") ?? "",
                        giangVien.Status == 1 ? "Hoạt động" : "Không hoạt động"
                    );
                }
                ApplyTableStyles(tableGV);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
            }
        }

        // Hàm tái sử dụng để cập nhật bảng giảng viên
        private static void PopulateGiangVienTable(DataGridView table)
        {
            try
            {
                List<GiangVienDTO> listGiangVien = GiangVienBUS.GetAllGiangVien();
                if (listGiangVien == null || listGiangVien.Count == 0)
                {
                    MessageBox.Show("Danh sách giảng viên rỗng.");
                    return;
                }

                table.Rows.Clear();
                foreach (var giangVien in listGiangVien)
                {
                    table.Rows.Add(
                        giangVien.Id,
                        giangVien.Name ?? "N/A",
                        giangVien.Email ?? "N/A",
                        giangVien.ChucVu  ,
                        giangVien.KhoaId  ,
                        giangVien.CreatedAt?.ToString("dd/MM/yyyy") ?? "",
                        giangVien.UpdatedAt?.ToString("dd/MM/yyyy") ?? "",
                        giangVien.Status == 1 ? "Hoạt động" : "Không hoạt động"
                    );
                }
                ApplyTableStyles(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật bảng giảng viên: " + ex.Message);
            }
        }

        // Hàm áp dụng phong cách cho bảng giảng viên
        private static void ApplyTableStyles(DataGridView table)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi áp dụng kiểu dáng cho bảng: " + ex.Message);
            }
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
            txtSearch.Text = "Nhập ID, nội dung cần tìm...";
            txtSearch.ForeColor = Color.Gray;
            LoadGiangVienList(tableGV);
        }

        private void cbbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchGiangVienList();
        }

        private void cbbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchGiangVienList();
        }

        private void table_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    var selectedRow = tableGV.Rows[e.RowIndex];

                    long id = Convert.ToInt64(selectedRow.Cells["Idcolumn"].Value ?? 0);
                    string name = selectedRow.Cells["nameColumn"].Value?.ToString() ?? "";
                    string email = selectedRow.Cells["emailColumn"].Value?.ToString() ?? "";
                    string chucVu = selectedRow.Cells["chucVuColumn"].Value?.ToString() ?? "";
                    string khoaId = selectedRow.Cells["khoaIdColumn"].Value?.ToString() ?? "";
                    string status = selectedRow.Cells["StatusColumn"].Value?.ToString() ?? "";

                    // Hiển thị form chi tiết giảng viên (tùy chỉnh theo yêu cầu)
                   // MessageBox.Show($"Chi tiết:\nID: {id}\nTên: {name}\nEmail: {email}\nChức vụ: {chucVu}\nKhoa: {khoaId}\nTrạng thái: {status}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xử lý double click: " + ex.Message);
            }
        }
            private void btnAdd_Click(object sender, EventArgs e)
        {
            ThemGiangVien cttcform = new ThemGiangVien(listGiangVien);
            cttcform.Show();
        }

        private void clearFilter()
        {
            txtSearch.Text = "Nhập ID, nội dung cần tìm...";
            // Reset combo boxes to "Mặc định"

            // Reset combo boxes to "Mặc định"
            
            cbbStatus.SelectedItem = "Mặc định";
            // Reset combo boxes to "Mặc định"
            cbbRole.SelectedItem = "Mặc định";
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = cbStatusCTTC.SelectedIndex;

            switch (selectedIndex)
            {
                case 0:
                    clearFilter();
                    break;
                case 1:
                    clearFilter();
                    break;
                case 2:
                    clearFilter();
                    break;
                default:
                    break;
            }
        }
    }
}
