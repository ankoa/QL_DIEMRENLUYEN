using MySqlX.XDevAPI.Relational;
using ql_diemrenluyen.BUS;
using ql_diemrenluyen.DTO;
using ql_diemrenluyen.GUI.ADMIN.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ql_diemrenluyen.GUI.ADMIN.Evidence
{
    public partial class QLBangChung : Form
    {
        public QLBangChung()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill; // Đặt Dock để chiếm toàn bộ không gian
            cbbTieuChi.SelectedItem = "Mặc định";
            cbbStatus.SelectedItem = "Mặc định";
            cbbHK.SelectedItem = "Mặc định";

            LoadBangChungList();

            if (this.Width < 1200)
            {
                pnContent.Padding = new Padding(50);
                pnContent.Dock = DockStyle.Fill;
            }
            InitializePlaceholder(txtSearch, "Nhập từ khóa tìm kiếm...");
        }

        private void QLBangChung_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill; // Đảm bảo chiếm toàn bộ không gian
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            LoadBangChungList();
            addItemCbbTCPandCTTC();
        }

        private void LoadBangChungList()
        {
            try
            {
                List<BangChungDTO> list = BangChungBUS.GetAllBangChung();
                tableTK.Rows.Clear();

                foreach (var bc in list)
                {

                    tableTK.Rows.Add(
                        bc.Id,
                        bc.SinhVienId,
                        bc.TieuchiDanhgiaId,  // Hiển thị tên vai trò thay vì mã vai trò
                        bc.LinkBangChung,
                        bc.CreatedAt.HasValue ? bc.CreatedAt.Value.ToString("dd/MM/yyyy") : "",
                        bc.UpdatedAt.HasValue ? bc.UpdatedAt.Value.ToString("dd/MM/yyyy") : "",
                        bc.HocKiID,
                        bc.Status == 1 ? "Hoạt động" : "Không hoạt động"
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
        public static void LoadBangChungList(DataGridView table)
        {
            try
            {
                List<BangChungDTO> list = BangChungBUS.GetAllBangChung();
                table.Rows.Clear();

                foreach (var bc in list)
                {

                    table.Rows.Add(
                        bc.Id,
                        bc.SinhVienId,
                        bc.TieuchiDanhgiaId,  // Hiển thị tên vai trò thay vì mã vai trò
                        bc.LinkBangChung,
                        bc.CreatedAt.HasValue ? bc.CreatedAt.Value.ToString("dd/MM/yyyy") : "",
                        bc.UpdatedAt.HasValue ? bc.UpdatedAt.Value.ToString("dd/MM/yyyy") : "",
                        bc.HocKiID,
                        bc.Status == 1 ? "Hoạt động" : "Không hoạt động"
                    );
                }

                ApplyTableStyles(table); // Áp dụng kiểu dáng cho bảng
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách tài khoản: " + ex.Message);
            }
        }

        // Phương thức ánh xạ mã số vai trò sang tên vai trò




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

        private void SearchBangChungList()
        {
            try
            {
                // Lấy ID từ cbbTieuChi (nếu được chọn)
                string selectedItem = cbbTieuChi.SelectedItem?.ToString();
                int? selectedId = null;
                if (selectedItem != null && selectedItem != "Mặc định")
                {
                    var parts = selectedItem.Split('-');
                    if (parts.Length > 0)
                    {
                        selectedId = int.Parse(parts[0].Trim());
                    }
                }

                // Lấy ID của HocKy từ cbbHK (nếu được chọn)
                string selectedHocKyItem = cbbHK.SelectedItem?.ToString();
                int? selectedHocKyId = null;
                if (selectedHocKyItem != null && selectedHocKyItem != "Mặc định")
                {
                    var hocKyParts = selectedHocKyItem.Split('-');
                    if (hocKyParts.Length > 0)
                    {
                        selectedHocKyId = int.Parse(hocKyParts[0].Trim());
                    }
                }

                // Lấy trạng thái từ cbbStatus
                int status = cbbStatus.SelectedItem?.ToString() == "Mặc định" ? -1 :
                             (cbbStatus.SelectedItem?.ToString() == "Hoạt động" ? 1 : 0);

                // Lấy giá trị tìm kiếm từ txtSearch
                string search = txtSearch.Text;
                if (search.Equals("Nhập từ khóa tìm kiếm..."))
                {
                    search = null;
                }

                // Kiểm tra nếu không có điều kiện nào được nhập, tải danh sách tài khoản mặc định
                if (selectedItem == null && status == -1 && string.IsNullOrEmpty(search) && selectedHocKyId == null)
                {
                    LoadBangChungList(tableTK);
                    return;
                }

                // Gọi phương thức tìm kiếm với các tham số (selectedId, status, search, selectedHocKyId)
                List<BangChungDTO> list = BangChungBUS.SearchBangChung(selectedId, status, search, selectedHocKyId);

                tableTK.Rows.Clear();

                if (list != null && list.Count > 0)
                {
                    // Đổ dữ liệu vào bảng
                    foreach (var bc in list)
                    {
                        tableTK.Rows.Add(
                            bc.Id,
                            bc.SinhVienId,
                            bc.TieuchiDanhgiaId,  // Hiển thị tên vai trò thay vì mã vai trò
                            bc.LinkBangChung,
                            bc.CreatedAt.HasValue ? bc.CreatedAt.Value.ToString("dd/MM/yyyy") : "",
                            bc.UpdatedAt.HasValue ? bc.UpdatedAt.Value.ToString("dd/MM/yyyy") : "",
                            bc.HocKiID,
                            bc.Status == 1 ? "Hoạt động" : "Không hoạt động"
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

        private void addItemCbbTCPandCTTC()
        {
            List<TieuChiDanhGiaDTO> listtieuchi = TieuChiDanhGiaBUS.GetAllTieuChiDanhGia();
            //MessageBox.Show("Lỗi khi tải danh sách tiêu chí: " + listtieuchi.Count);
            foreach (var tieuchi in listtieuchi)
            {
                if (tieuchi.ParentId == null)
                {

                    cbbTieuChi.Items.Add(tieuchi.Id + " - " + tieuchi.Name);
                }
                else
                {
                    cbbTieuChi.Items.Add(tieuchi.Id + " - " + tieuchi.Name);
                }
            }
            List<HocKyDTO> hk = HocKyBUS.GetAllHocKy();

            foreach (var hocKy in hk)
            {
                // Thêm định dạng vào ComboBox, theo yêu cầu của bạn.
                cbbHK.Items.Add(hocKy.Id + " - " + hocKy.Name + " " + hocKy.namhoc);
            }



        }

        private void tableTK_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    // Lấy hàng được chọn
                    var selectedRow = tableTK.Rows[e.RowIndex];

                    // Lấy dữ liệu từ các cột của hàng
                    int id = Convert.ToInt32(selectedRow.Cells["colID"].Value); // Cột ID
                    long sinhVienId = Convert.ToInt64(selectedRow.Cells["colIDSV"].Value); // Cột SinhVienId
                    int tieuchiDanhGiaId = Convert.ToInt32(selectedRow.Cells["colIDTC"].Value); // Cột TieuChiDanhGiaId
                    string linkBangChung = selectedRow.Cells["colURL"].Value?.ToString() ?? ""; // Cột LinkBangChung

                    // Xử lý cột CreatedAt
                    DateTime createdAt = DateTime.TryParse(selectedRow.Cells["colCreate"].Value?.ToString(), out DateTime tempCreatedAt)
                        ? tempCreatedAt : DateTime.MinValue;

                    // Xử lý cột UpdatedAt
                    DateTime updatedAt = DateTime.TryParse(selectedRow.Cells["colUpdate"].Value?.ToString(), out DateTime tempUpdatedAt)
                        ? tempUpdatedAt : DateTime.MinValue;

                    // Lấy trạng thái (Hiển thị string nhưng cần convert lại nếu cần)
                    string statusString = selectedRow.Cells["colStatus"].Value?.ToString() ?? "Không hoạt động";
                    int status = statusString == "Hoạt động" ? 1 : 0;
                    int hocKiID = Convert.ToInt32(selectedRow.Cells["colHocKiID"].Value);

                    // Chuyển thông tin sang form chi tiết hoặc xử lý logic cần thiết
                    BangChungDTO bangChung = new BangChungDTO
                    {
                        Id = id,
                        SinhVienId = sinhVienId,
                        TieuchiDanhgiaId = tieuchiDanhGiaId,
                        LinkBangChung = linkBangChung,
                        CreatedAt = createdAt,
                        UpdatedAt = updatedAt,
                        HocKiID = hocKiID,
                        Status = status
                    };

                    // Hiển thị form chi tiết (nếu cần)
                    BangChungDetailsForm detailsForm = new BangChungDetailsForm(bangChung, tableTK, this);
                    detailsForm.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xử lý dữ liệu hàng được chọn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void cbbTieuChi_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchBangChungList();
        }

        private void cbbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchBangChungList();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchBangChungList();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Reset combo boxes to "Mặc định"
            cbbTieuChi.SelectedItem = "Mặc định";
            cbbStatus.SelectedItem = "Mặc định";
            cbbHK.SelectedItem = "Mặc định";
            // Clear the search text box and reset placeholder
            txtSearch.Text = "Nhập từ khóa tìm kiếm...";
            txtSearch.ForeColor = Color.Gray; // Set placeholder color

            // Reload the account list without filters
            LoadBangChungList();
        }

        private void cbbHK_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchBangChungList();
        }
    }







}

