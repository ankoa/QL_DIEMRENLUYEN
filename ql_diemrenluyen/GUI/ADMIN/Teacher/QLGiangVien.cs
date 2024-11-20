using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ql_diemrenluyen.DAO;
using ql_diemrenluyen.DTO;
using ql_diemrenluyen.BUS;
using ql_diemrenluyen.GUI.ADMIN.Teacher;

namespace ql_diemrenluyen.GUI.ADMIN
{
    public partial class QLGiangVien : Form
    {
        public QLGiangVien()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.MaximizeBox = false;
            LoadGiangVienList();
        }

        private void QLGiangVien_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.Dock = DockStyle.Fill;
            LoadGiangVienList();
        }

        private void LoadGiangVienList()
        {
            try
            {
                List<GiangVienDTO> giangViens = GiangVienBUS.GetAllGiangVien();
                tableGV.Rows.Clear();

                foreach (var giangVien in giangViens)
                {
                    tableGV.Rows.Add(
                        giangVien.Id,
                        giangVien.Name,
                        giangVien.Email,
                        giangVien.ChucVu,
                        giangVien.KhoaId,
                        giangVien.CreatedAt,
                        giangVien.UpdatedAt,
                        "Xem",
                        "Xóa"
                    );
                }

                ApplyTableStyles(tableGV);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách giảng viên: " + ex.Message);
            }
        }

        public static void LoadGiangVienList(DataGridView table)
        {
            try
            {
                List<GiangVienDTO> giangViens = GiangVienBUS.GetAllGiangVien();
                table.Rows.Clear();

                foreach (var giangVien in giangViens)
                {
                    table.Rows.Add(
                        giangVien.Id,
                        giangVien.Name,
                        giangVien.Email,
                        giangVien.ChucVu,
                        giangVien.KhoaId,
                        giangVien.CreatedAt,
                        giangVien.UpdatedAt,
                        "Xem",
                        "Xóa"
                    );
                }

                ApplyTableStyles(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách giảng viên: " + ex.Message);
            }
        }

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

        private void SearchGiangVienList()
        {
            try
            {
                string search = txtSearch.Text.Trim();

                if (string.IsNullOrEmpty(search))
                {
                    LoadGiangVienList(tableGV);
                    return;
                }

                List<GiangVienDTO> giangViens;

                if (long.TryParse(search, out long id))
                {
                    var giangVien = GiangVienBUS.GetGiangVienById(id);
                    giangViens = giangVien != null ? new List<GiangVienDTO> { giangVien } : new List<GiangVienDTO>();
                }
                else
                {
                    giangViens = GiangVienBUS.SearchGiangVien(search);
                }

                tableGV.Rows.Clear();

                foreach (var giangVien in giangViens)
                {
                    tableGV.Rows.Add(
                        giangVien.Id,
                        giangVien.Name,
                        giangVien.Email,
                        giangVien.ChucVu,
                        giangVien.KhoaId,
                        giangVien.CreatedAt,
                        giangVien.UpdatedAt,
                        "Xem",
                        "Xóa"
                    );
                }

                ApplyTableStyles(tableGV);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm giảng viên: " + ex.Message);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchGiangVienList();
        }

        private void tableGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = tableGV.Rows[e.RowIndex];
                long id = Convert.ToInt64(selectedRow.Cells[0].Value);
                string name = selectedRow.Cells[1].Value?.ToString() ?? ""; // Tên giảng viên
                string email = selectedRow.Cells[2].Value?.ToString() ?? ""; // Email giảng viên
                string chucVu = selectedRow.Cells[3].Value?.ToString() ?? ""; // Chức vụ giảng viên
                string khoa = selectedRow.Cells[4].Value?.ToString() ?? ""; // Khoa giảng viên (nên là tên khoa)

                // Lấy thông tin giảng viên từ cơ sở dữ liệu
                GiangVienDTO giangVien = GiangVienBUS.GetGiangVienById(id);

                if (giangVien != null)
                {
                    // Khởi tạo GiangVienDetailForm với các tham số đúng
                    GiangVienDetailForm detailsForm = new GiangVienDetailForm(
                        id.ToString(),
                        giangVien.Name,
                        giangVien.Email,
                        giangVien.ChucVu,
                        giangVien.KhoaId, // KhoaId có thể cần chuyển đổi sang tên khoa nếu cần
                        giangVien.TrangThai, // Đảm bảo rằng thuộc tính TrangThai tồn tại
                        tableGV,
                        this // Gửi đối tượng hiện tại cho form chi tiết
                    );

                    detailsForm.Show();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy giảng viên.");
                }
            }
        }

    }
}
