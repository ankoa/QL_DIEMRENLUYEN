using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ql_diemrenluyen.DAO;
using ql_diemrenluyen.DTO;
using ql_diemrenluyen.BUS;
using ql_diemrenluyen.GUI.ADMIN.Teacher;

namespace ql_diemrenluyen.GUI.ADMIN.Teacher
{
    public partial class QLGiangVien : Form
    {
        public QLGiangVien()
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

        private void QLGiangVien_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.Dock = DockStyle.Fill;
            LoadGiangVienList();
        }

        private List<GiangVienDTO> giangViens;

        private void LoadGiangVienList()
        {
            try
            {
                if (giangViens == null)
                {
                    giangViens = GiangVienBUS.GetAllGiangViens(); // Tải dữ liệu một lần
                }

                dataGridGiangVien.Rows.Clear();

                foreach (var giangVien in giangViens)
                {
                    dataGridGiangVien.Rows.Add(
                        giangVien.MaGV,
                        giangVien.TenGV,
                        giangVien.Email,
                        giangVien.Khoa,
                        "Xem", // Nút xem thông tin
                        "Xóa"  // Nút xóa
                    );
                }

                ApplyTableStyles();
            }
            catch (Exception ex)
            {
                LogError(ex); // Ghi log lỗi
                MessageBox.Show("Lỗi khi tải danh sách giảng viên: " + ex.Message);
            }
        }
        private void LogError(Exception ex)
        {
            System.IO.File.AppendAllText("log.txt", $"{DateTime.Now}: {ex.Message}\n{ex.StackTrace}\n");
        }


        // Hàm áp dụng style cho bảng
        private void ApplyTableStyles()
        {
            dataGridGiangVien.RowTemplate.Height = 40;
            dataGridGiangVien.BorderStyle = BorderStyle.Fixed3D;
            dataGridGiangVien.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle
            {
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                BackColor = Color.RoyalBlue,
                ForeColor = Color.White
            };

            dataGridGiangVien.ColumnHeadersDefaultCellStyle = headerStyle;
            dataGridGiangVien.EnableHeadersVisualStyles = false;
            dataGridGiangVien.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dataGridGiangVien.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Thêm hiệu ứng cho hàng đang chọn
            dataGridGiangVien.DefaultCellStyle.BackColor = Color.White;
            dataGridGiangVien.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridGiangVien.RowsDefaultCellStyle.SelectionBackColor = Color.LightGray;
            dataGridGiangVien.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
        }


        private void tableGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu nhấn vào cột "Xem"
            if (e.RowIndex >= 0 && e.ColumnIndex == tableGV.Columns["btnXem"].Index)
            {
                // Lấy thông tin giảng viên từ dòng tương ứng
                var maGV = tableGV.Rows[e.RowIndex].Cells["MaGV"].Value;
                // Thực hiện hành động xem thông tin giảng viên
                MessageBox.Show("Thông tin giảng viên: " + maGV.ToString());
            }
            // Kiểm tra nếu nhấn vào cột "Xóa"
            else if (e.RowIndex >= 0 && e.ColumnIndex == tableGV.Columns["btnXoa"].Index)
            {
                // Xác nhận trước khi xóa
                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa giảng viên này không?", "Xác nhận xóa", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    // Thực hiện xóa giảng viên
                    tableGV.Rows.RemoveAt(e.RowIndex);
                    // Có thể thêm mã để xóa giảng viên từ danh sách dữ liệu của bạn
                }
            }
        }


        private void ViewGiangVienDetails(int rowIndex)
        {
            var maGV = dataGridGiangVien.Rows[rowIndex].Cells["MaGV"].Value.ToString();
            // Mở một form hoặc dialog để hiển thị thông tin chi tiết của giảng viên
            GiangVienDetailsForm detailsForm = new GiangVienDetailsForm(maGV);
            detailsForm.ShowDialog();
        }

        private void DeleteGiangVien(int rowIndex)
        {
            var maGV = dataGridGiangVien.Rows[rowIndex].Cells["MaGV"].Value.ToString();

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa giảng viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    GiangVienBUS.DeleteGiangVien(maGV); // Xóa giảng viên
                    LoadGiangVienList(); // Cập nhật lại danh sách
                    MessageBox.Show("Đã xóa giảng viên thành công.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa giảng viên: " + ex.Message);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Tìm kiếm giảng viên khi thay đổi nội dung textbox
            SearchGiangVien();
        }

        private void SearchGiangVien()
        {
            string searchTerm = textBox1.Text.ToLower();
            var filteredGiangViens = giangViens.FindAll(gv =>
                gv.TenGV.ToLower().Contains(searchTerm) ||
                gv.MaGV.ToLower().Contains(searchTerm) ||
                gv.Email.ToLower().Contains(searchTerm));

            dataGridGiangVien.Rows.Clear();
            foreach (var giangVien in filteredGiangViens)
            {
                dataGridGiangVien.Rows.Add(
                    giangVien.MaGV,
                    giangVien.TenGV,
                    giangVien.Email,
                    giangVien.Khoa,
                    "Xem", // Nút xem thông tin
                    "Xóa"  // Nút xóa
                );
            }
        }
    }
}
