using ql_diemrenluyen.BUS;
using ql_diemrenluyen.DTO;
using ql_diemrenluyen.Util.ExcelImporter;
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
                //cbbRole.SelectedItem = "Mặc định";
                cbbStatus.SelectedItem = "Mặc định";
                var khoaList = KhoaBUS.GetAllKhoa();
                var khoaListWithDefault = new List<KhoaDTO>
                {
                    new KhoaDTO { Id = -1, TenKhoa = "Mặc định" }
                };
                khoaListWithDefault.AddRange(khoaList);
                cbbFilterKhoa.DataSource = khoaListWithDefault;
                cbbFilterKhoa.DisplayMember = "TenKhoa";
                cbbFilterKhoa.ValueMember = "Id";
                cbbFilterKhoa.SelectedIndexChanged += cbbFilterKhoa_SelectedIndexChanged;

                listGiangVien = GiangVienBUS.GetAllGiangVien();
                //PopulateGiangVienTable(tableGV);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi khởi tạo giao diện: " + ex.Message);
            }
        }
        //private void LoadStandardsList()
        //{
        //    try
        //    {
        //        List<GiangVienDTO> listgiangvien = GiangVienBUS.GetAllGiangVien();
        //        tableGV.Rows.Clear();

        //        foreach (var giangVien in listgiangvien)
        //        {
        //            if (giangVien.KhoaId == null)
        //            {
        //                tableGV.Rows.Add(
        //                                       giangVien.Id,
        //                                       giangVien.Name,
        //                                       giangVien.Email,
        //                                       giangVien.KhoaId >0 ? giangVien.KhoaId.ToString() : null, 

        //                                       giangVien.CreatedAt.HasValue ? giangVien.CreatedAt.Value.ToString("dd/MM/yyyy") : "",
        //                                       giangVien.UpdatedAt.HasValue ? giangVien.UpdatedAt.Value.ToString("dd/MM/yyyy") : "",
        //                                       giangVien.Status == 1 ? "Hoạt động" : "Không hoạt động"
        //                                   );
        //            }

        //        }

        //        ApplyTableStyles(tableGV);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Lỗi khi tải danh sách tiêu chí: " + ex.Message);
        //    }

        //}

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


        private void SearchGiangVienList()
        {
            try
            {
                // Lấy giá trị tìm kiếm từ TextBox
                string search = txtSearch.Text?.Trim().ToLower();
                if (search == "nhập id, nội dung cần tìm...")
                {
                    search = string.Empty;
                }

                // Lấy giá trị lọc từ ComboBox
                string selectedStatus = cbbStatus.SelectedItem?.ToString();
                int? statusFilter = null; // `null` nghĩa là không lọc theo trạng thái
                if (selectedStatus == "Hoạt động")
                {
                    statusFilter = 1;
                }
                else if (selectedStatus == "Không hoạt động")
                {
                    statusFilter = 0;
                }
                // Lấy giá trị lọc từ ComboBox khoa (Tên khoa)
                string selectedKhoa = cbbFilterKhoa.SelectedItem?.ToString();

                bool isDefaultKhoa = selectedKhoa == "Mặc định"; // Kiểm tra nếu chọn "Mặc định"

                // Lọc danh sách giảng viên
                var filteredList = listGiangVien.Where(giangVien =>
                    (string.IsNullOrEmpty(search) ||
                     giangVien.Id.ToString().Contains(search) ||
                     (!string.IsNullOrEmpty(giangVien.Name) && giangVien.Name.ToLower().Contains(search)) ||
                     (!string.IsNullOrEmpty(giangVien.Email) && giangVien.Email.ToLower().Contains(search))
                     //||
                     //(!string.IsNullOrEmpty(giangVien.KhoaId.ToString()) && giangVien.KhoaId.ToString().Contains(search))
                     ) &&
                    (!statusFilter.HasValue || giangVien.Status == statusFilter.Value) &&
                   (isDefaultKhoa || KhoaBUS.GetKhoaByID(giangVien.KhoaId)?.TenKhoa == selectedKhoa)
                ).ToList();

                //MessageBox.Show(cbbFilterKhoa.SelectedItem?.ToString());
                // Cập nhật DataGridView

                tableGV.Rows.Clear();
                foreach (var giangVien in filteredList)
                {
                    //var khoaName = KhoaBUS.GetKhoaByID(giangVien.KhoaId);
                    //MessageBox.Show($"Tên khoa của giảng viên {giangVien.Name}: {khoaName?.TenKhoa ?? "N/A"}",
                    //                "Kiểm tra Tên Khoa",
                    //                MessageBoxButtons.OK,
                    //                MessageBoxIcon.Information);
                    KhoaDTO khoaName = KhoaBUS.GetKhoaByID(giangVien.KhoaId);

                    tableGV.Rows.Add(
                        giangVien.Id,
                        giangVien.Name ?? "N/A",
                        giangVien.Email ?? "N/A",
                        khoaName?.TenKhoa ?? "N/A",
                        giangVien.GioiTinh == 1 ? "Nam" : "Nữ",
                        giangVien.NgaySinh.ToString("dd/MM/yyyy"),
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
                    KhoaDTO khoaName = KhoaBUS.GetKhoaByID(giangVien.KhoaId);
                    table.Rows.Add(
                        giangVien.Id,
                        giangVien.Name ?? "N/A",
                        giangVien.Email ?? "N/A",

                        khoaName.TenKhoa,
                        giangVien.GioiTinh == 1 ? "Nam" : "Nữ",
                        giangVien.NgaySinh.ToString("dd/MM/yyyy"),

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
            cbbStatus.SelectedItem = "Mặc định";
            cbbFilterKhoa.SelectedIndex = 0;
            LoadGiangVienList(tableGV);
        }

        private void cbbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchGiangVienList();
        }
        private void cbbFilterKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Gọi lại phương thức tìm kiếm với bộ lọc mới
                SearchGiangVienList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc giảng viên theo khoa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                    // Lấy thông tin từ hàng được chọn
                    long idGV = Convert.ToInt64(selectedRow.Cells["IdColumn"].Value ?? 0);


                    // Truyền danh sách giảng viên vào form (nếu cần)
                    // List<GiangVienDTO> danhSachGiangVien = GiangVienBUS.GetAllGiangVien();
                    //MessageBox.Show($"Ngày sinh:");


                    // Khởi tạo form ThemGiangVien
                    ThemGiangVien form = new ThemGiangVien(idGV);

                    // Hiển thị form
                    form.Show();

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

            cbbStatus.SelectedItem = "Mặc định";
            cbbFilterKhoa.SelectedIndex = 0;

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

        private void btExport_Click(object sender, EventArgs e)
        {
            var dictionaryList = ExcelExporter.ConvertListToDictionaryList(GiangVienBUS.GetAllGiangVien());

            // Xuất ra Excel
            ExcelExporter.ExportListToExcel(dictionaryList);
        }

        private void btImport_Click(object sender, EventArgs e)
        {
            try
            {
                // Hiển thị hộp thoại chọn file
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Excel Files|*.xlsx;*.xls";
                    openFileDialog.Title = "Chọn file Excel";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = openFileDialog.FileName;

                        // Tạo đối tượng ImportGiangVien và gọi phương thức ImportFromExcel
                        ImportGiangVien importer = new ImportGiangVien();
                        List<GiangVienDTO> importedGiangVien = importer.ImportFromExcel(filePath);

                        // Cập nhật giao diện (nếu cần)
                        MessageBox.Show($"Import thành công {importedGiangVien.Count} giảng viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Tải lại danh sách giảng viên trên giao diện
                        listGiangVien = GiangVienBUS.GetAllGiangVien(); // Lấy danh sách giảng viên mới
                        PopulateGiangVienTable(tableGV); // Hiển thị lại bảng
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi import: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
