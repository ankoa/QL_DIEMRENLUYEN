using ql_diemrenluyen.BUS;
using ql_diemrenluyen.DAO;
using System.Data;

namespace ql_diemrenluyen.GUI.USER
{
    public partial class Dashboard : Form
    {
        public static string nguoidung_id = Program.nguoidung_id;
        public static string role = Program.role switch
        {
            0 => "ADMIN",
            1 => "Sinh viên",
            2 => "Giảng viên",
            3 => "Cố vấn",
            4 => "Quản lý Khoa",
            5 => "Quản lý Trường",
            _ => "Unknown"
        };

        public Dashboard()
        {
            InitializeComponent();
            LoadStudentInfo();
            if (role.Equals("Sinh viên"))
            {
                LoadDrlHocKi(1);
                LoadDotChamDiemSinhVien(1, role);
            }
            else if (role.Equals("Cố vấn"))
            {
                LoadDrlHocKi(1);
                LoadDotChamDiemSinhVien(1, role);
            }

            //CustomizeDataGridView();
            //CustomizeSpecificColumns();
        }

        private void LoadStudentInfo()
        {
            try
            {
                // Lấy danh sách sinh viên từ DAO
                // Sau này đổi thành bus
                var student = SinhVienBUS.GetStudentById(1);

                lbMaSV.Text = student.Id.ToString();
                lbEmail.Text = student.Email;
                lbHovaTen.Text = student.Name;
                lbNgaySinh.Text = student.NgaySinh.ToString();
                if (student.GioiTinh == 1)
                    lbGioiTinh.Text = "Nam";
                else
                    lbGioiTinh.Text = "Nữ";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải sinh viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDotChamDiemSinhVien(int sinhVienId, string role)
        {
            // Cấu hình các cột trong DataGridView
            dataGridView2.AutoGenerateColumns = false;

            // Đảm bảo chỉ thêm cột một lần
            if (dataGridView2.Columns.Count == 0)
            {
                dataGridView2.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Học kì",
                    DataPropertyName = "HocKy",
                    Name = "HocKy"
                });

                dataGridView2.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Tên Đợt",
                    DataPropertyName = "DotChamDiem",
                    Name = "DotChamDiem"
                });

                dataGridView2.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Ngày bắt đầu",
                    DataPropertyName = "NgayBatDau",
                    Name = "NgayBatDau"
                });

                dataGridView2.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Ngày kết thúc",
                    DataPropertyName = "NgayKetThuc",
                    Name = "NgayKetThuc"
                });

                dataGridView2.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Tiến độ",
                    DataPropertyName = "HoanThanh",
                    Name = "HoanThanh"
                });
            }

            try
            {
                List<ThongTinDotChamDiemDTO> dotChamDiemList; // Khai báo biến

                if (role.Equals("Sinh viên"))
                {
                    dotChamDiemList = DotChamDiemBUS.GetDotChamDiemCuaSinhVienTheoId(sinhVienId);
                }
                else if (role.Equals("Cố vấn")) // Giả sử bạn đang kiểm tra vai trò "Cố vấn"
                {
                    dotChamDiemList = DotChamDiemBUS.GetDotChamDiemCuaCoVanTheoId(sinhVienId);
                }
                else
                {
                    // Xử lý trường hợp vai trò không hợp lệ nếu cần
                    MessageBox.Show("Vai trò không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                dataGridView2.DataSource = dotChamDiemList; // Gán nguồn dữ liệu cho DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void LoadDrlHocKi(int sinhVienId)
        {
            var diemRenLuyenChiTiet = DiemRenLuyenBUS.GetDiemRenLuyenChiTiet(sinhVienId);

            // Chuyển đổi danh sách thành DataTable
            DataTable dt = ConvertToDataTable(diemRenLuyenChiTiet);

            // Gán DataTable vào DataGridView
            dataGridView1.DataSource = dt;

        }

        //--------------------------------------------------------------

        private DataTable ConvertToDataTable(List<Dictionary<string, object>> list)
        {
            DataTable dt = new DataTable();
            if (list == null || list.Count == 0) return dt;

            // Thêm các cột vào DataTable
            foreach (var key in list[0].Keys)
            {
                dt.Columns.Add(key);
            }

            // Thêm các hàng vào DataTable
            foreach (var item in list)
            {
                DataRow row = dt.NewRow();
                foreach (var key in item.Keys)
                {
                    row[key] = item[key];
                }
                dt.Rows.Add(row);
            }

            return dt;
        }

        private void CustomizeDataGridView()
        {
            // Thiết lập màu nền và màu chữ
            dataGridView1.BackgroundColor = Color.White; // Màu nền
            dataGridView1.ForeColor = Color.Black; // Màu chữ
            dataGridView1.DefaultCellStyle.BackColor = Color.LightGray; // Màu nền ô
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black; // Màu chữ ô

            // Thay đổi font
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 10);

            // Cài đặt BorderStyle
            dataGridView1.BorderStyle = BorderStyle.FixedSingle;

            // Cài đặt kích thước cột tự động
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Ẩn đường viền ô tiêu đề
            //dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // Định dạng tiêu đề cột
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue; // Màu nền tiêu đề
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Màu chữ tiêu đề
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold); // Font tiêu đề

            // Cài đặt màu đường viền
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            // Cài đặt hiệu ứng hover cho hàng
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridView1.RowsDefaultCellStyle.SelectionBackColor = Color.LightBlue; // Màu nền khi chọn
            dataGridView1.RowsDefaultCellStyle.SelectionForeColor = Color.Black; // Màu chữ khi chọn
        }

        private void CustomizeSpecificColumns()
        {
            // Cột đầu tiên
            dataGridView1.Columns[0].Width = 150; // Đặt chiều rộng cột
            dataGridView1.Columns[0].DefaultCellStyle.BackColor = Color.LightCoral; // Màu nền cột

            // Cột thứ hai
            dataGridView1.Columns[1].Width = 100;

            // Cột thứ ba
            dataGridView1.Columns[2].Width = 200;

            // Cột thứ tư
            dataGridView1.Columns[3].Width = 250;
        }





        private void DashboardContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
