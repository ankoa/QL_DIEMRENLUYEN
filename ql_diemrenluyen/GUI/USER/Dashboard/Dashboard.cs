using ql_diemrenluyen.BUS;
using ql_diemrenluyen.DAO;
using ql_diemrenluyen.DTO;
using ql_diemrenluyen.GUI.ADMIN;
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
            4 => "Khoa",
            5 => "Trường",
            _ => "Unknown"
        };
        ////82778917

        //public static string nguoidung_id = "3121410000";
        //public static string role = 1 switch
        //{
        //    0 => "ADMIN",
        //    1 => "Sinh viên",
        //    2 => "Giảng viên",
        //    3 => "Cố vấn",
        //    4 => "Quản lý Khoa",
        //    5 => "Quản lý Trường",
        //    _ => "Unknown"
        //};

        //public static string nguoidung_id = Program.nguoidung_id;
        //public static string role = Program.role switch
        //{
        //    0 => "ADMIN",
        //    1 => "Sinh viên",
        //    2 => "Giảng viên",
        //    3 => "Cố vấn",
        //    4 => "Quản lý Khoa",
        //    5 => "Quản lý Trường",
        //    _ => "Unknown"
        //};
        public Dashboard()
        {
            InitializeComponent();
            LoadInfo();
            LoadInfoClass();
            if (role.Equals("Sinh viên"))
            {
                LoadDrlHocKi(1);

            }
            else
            {
                LoadDrlHocKi2();
            }
            LoadDotChamDiemSinhVien(long.Parse(nguoidung_id), role);
            //CustomizeDataGridView();
            //CustomizeSpecificColumns();
        }

        private void LoadInfo()
        {
            if (role.Equals("Sinh viên"))
            {
                lbStudentInfo.Text = "Thông tin sinh viên";
                try
                {
                    // Lấy danh sách sinh viên từ DAO
                    // Sau này đổi thành bus
                    var student = SinhVienBUS.GetStudentById(long.Parse(nguoidung_id));

                    lbMaSV.Text = student.Id.ToString();
                    lbEmail.Text = student.Email;
                    lbHovaTen.Text = student.Name;
                    lbNgaySinh.Text = student.NgaySinh.ToString("dd/MM/yyyy"); // Định dạng ngày sinh
                    lbGioiTinh.Text = student.GioiTinh == 1 ? "Nam" : "Nữ";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tải sinh viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                lbStudentInfo.Text = "Thông tin giảng viên";
                label2.Text = "Mã GV";
                try
                {
                    // Lấy danh sách giảng viên từ DAO
                    // Sau này đổi thành bus
                    var giangvien = GiangVienBUS.GetGiangVienById(long.Parse(nguoidung_id));

                    lbMaSV.Text = giangvien.Id.ToString();
                    lbEmail.Text = giangvien.Email;
                    lbHovaTen.Text = giangvien.Name;
                    lbNgaySinh.Text = giangvien.NgaySinh.ToString("dd/MM/yyyy"); // Định dạng ngày sinh
                    lbGioiTinh.Text = giangvien.GioiTinh == 1 ? "Nam" : "Nữ";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tải giảng viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadInfoClass()
        {
            if (role.Equals("Sinh viên"))
            {
                tableLayoutPanel10.RowStyles[1] = new RowStyle(SizeType.Percent, 0);
                tableLayoutPanel10.RowStyles[0] = new RowStyle(SizeType.Percent, 100);
                try
                {
                    // Lấy danh sách sinh viên từ DAO
                    // Sau này đổi thành bus
                    var student = LopDAO.GetLopDetailsBySinhVienId(long.Parse(nguoidung_id));

                    lbLop.Text = student.TenLop;
                    lbKhoa.Text = student.TenKhoa;
                    lbCoVan.Text = student.CoVan;
                    lbKhoas.Text = "K" + student.TenLop.Substring(4, 2);
                    //lbNgaySinh.Text = student.NgaySinh.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tải lớp   : {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (role.Equals("Cố vấn"))
            {
                // Cập nhật tiêu đề label1
                label1.Text = "Lớp học bạn cố vấn";
                tableLayoutPanel10.RowStyles[0] = new RowStyle(SizeType.Percent, 0);
                tableLayoutPanel10.RowStyles[1] = new RowStyle(SizeType.Percent, 100);

                // Cấu hình các cột trong DataGridView
                dataGridView3.AutoGenerateColumns = false;

                // Đảm bảo chỉ thêm cột một lần
                if (dataGridView3.Columns.Count == 0)
                {
                    // Cột số thứ tự
                    dataGridView3.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        HeaderText = "STT",
                        DataPropertyName = "STT",
                        Name = "STT",
                    });

                    // Cột Tên Lớp
                    dataGridView3.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        HeaderText = "Tên Lớp",
                        DataPropertyName = "TenLop",
                        Name = "TenLop"
                    });

                    // Cột Tên Khoa
                    dataGridView3.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        HeaderText = "Tên Khoa",
                        DataPropertyName = "TenKhoa",
                        Name = "TenKhoa"
                    });

                    // Cột Số Lượng Sinh Viên
                    dataGridView3.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        HeaderText = "SL",
                        DataPropertyName = "SoLuong",
                        Name = "SoLuong"
                    });
                }

                try
                {
                    List<LopDetailsDTO> lopDetailsList; // Khai báo biến

                    // Lấy thông tin lớp học của cố vấn theo ID
                    lopDetailsList = LopDAO.GetLopHocCuaCoVanById(long.Parse(nguoidung_id));

                    // Thêm số thứ tự vào mỗi dòng dữ liệu
                    for (int i = 0; i < lopDetailsList.Count; i++)
                    {
                        lopDetailsList[i].STT = i + 1; // Gán số thứ tự bắt đầu từ 1
                    }

                    // Gán nguồn dữ liệu cho DataGridView
                    dataGridView3.DataSource = lopDetailsList;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                studentContainer.RowStyles[0] = new RowStyle(SizeType.Percent, 100);
                studentContainer.RowStyles[1] = new RowStyle(SizeType.Percent, 0);
            }
        }

        private void LoadDotChamDiemSinhVien(long sinhVienId, string role)
        {
            // Cấu hình các cột trong DataGridView2
            dataGridView2.AutoGenerateColumns = false;
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

            // Cấu hình các cột trong DataGridView4 (nếu chưa cấu hình)
            dataGridView4.AutoGenerateColumns = false;
            if (dataGridView4.Columns.Count == 0)
            {
                dataGridView4.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Thông báo",
                    DataPropertyName = "ThongBao",
                    Name = "ThongBao"
                });
            }

            try
            {
                List<ThongTinDotChamDiemDTO> dotChamDiemList;

                if (role.Equals("Sinh viên"))
                {
                    dotChamDiemList = DotChamDiemBUS.GetDotChamDiemCuaSinhVienTheoId(sinhVienId);
                }
                else if (role.Equals("Cố vấn"))
                {

                    dotChamDiemList = DotChamDiemBUS.GetDotChamDiemCuaCoVanTheoId(sinhVienId);
                }
                else if (role.Equals("Khoa"))
                {
                    GiangVienDTO gv = GiangVienBUS.GetGiangVienById(sinhVienId);
                    dotChamDiemList = DotChamDiemBUS.GetDotChamDiemCuaKhoaTheoId(gv.KhoaId);
                }
                else if (role.Equals("Trường"))
                {

                    dotChamDiemList = DotChamDiemBUS.GetDotChamDiemCuaTruong();
                }
                else
                {
                    MessageBox.Show("Vai trò không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Gán nguồn dữ liệu cho DataGridView2
                dataGridView2.DataSource = dotChamDiemList;

                // Danh sách thông báo để hiển thị trên DataGridView4
                var thongBaoList = new List<dynamic>();
                var now = DateTime.Now;

                foreach (var dot in dotChamDiemList)
                {
                    var ngayBatDau = dot.NgayBatDau;
                    var ngayKetThuc = dot.NgayKetThuc;

                    if (ngayBatDau <= now.AddDays(7) && ngayBatDau > now)
                    {
                        thongBaoList.Add(new { ThongBao = $"Đợt {dot.DotChamDiem} sắp bắt đầu trong {Math.Ceiling((ngayBatDau - now).TotalDays)} ngày!" });
                    }
                    else if (ngayKetThuc <= now.AddDays(3) && ngayKetThuc > now)
                    {
                        thongBaoList.Add(new { ThongBao = $"Đợt {dot.DotChamDiem} sắp kết thúc trong {Math.Ceiling((ngayKetThuc - now).TotalDays)} ngày!" });
                    }
                }

                // Gán thông báo vào DataGridView4
                dataGridView4.DataSource = thongBaoList;

                // Xử lý sự kiện double-click trên DataGridView2
                dataGridView2.CellDoubleClick += (sender, e) =>
                {
                    if (e.RowIndex >= 0)  // Kiểm tra nếu đã chọn một hàng hợp lệ
                    {
                        var selectedRow = dataGridView2.Rows[e.RowIndex];
                        var dotChamDiem = (ThongTinDotChamDiemDTO)selectedRow.DataBoundItem; // Lấy đối tượng DTO từ dòng đã chọn
                        chamdrl otpForm = new chamdrl("Chấm", dotChamDiem.HocKyId, dotChamDiem.Id);


                        // Đảm bảo rằng khi form mới đóng, form hiện tại được hiển thị lại
                        //otpForm.FormClosed += (s, args) => this.Show();

                        otpForm.Show();  // Hiển thị form mới
                        //MessageBox.Show($"ID của ThongTinDotChamDiemDTO: {dotChamDiem.Id}", "Thông tin đợt chấm điểm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                };
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

            // Xử lý sự kiện double-click trên DataGridView2
            dataGridView1.CellDoubleClick += (sender, e) =>
            {
                if (e.RowIndex >= 0)  // Kiểm tra nếu đã chọn một hàng hợp lệ
                {
                    var selectedRow = dataGridView1.Rows[e.RowIndex];

                    // Lấy dữ liệu từ cột thứ nhất và thứ hai
                    string hocki = selectedRow.Cells[0].Value?.ToString(); // Cột đầu tiên (Index = 0)
                    int namhoc = Convert.ToInt32(selectedRow.Cells[1].Value);
                    chamdrl otpForm = new chamdrl("Xem", HocKyBUS.GetHocKyByNameAndYear(hocki, namhoc).Id, 2);


                    // Đảm bảo rằng khi form mới đóng, form hiện tại được hiển thị lại
                    //otpForm.FormClosed += (s, args) => this.Show();

                    otpForm.Show();  // Hiển thị form mới
                    //MessageBox.Show($"ID của ThongTinDotChamDiemDTO: {dotChamDiem.Id}", "Thông tin đợt chấm điểm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };

        }

        private void LoadDrlHocKi2()
        {
            var diemRenLuyenChiTiet = DiemRenLuyenBUS.GetHocKyVaNamHoc();

            // Chuyển đổi danh sách thành DataTable
            DataTable dt = ConvertToDataTable(diemRenLuyenChiTiet);

            // Gán DataTable vào DataGridView
            dataGridView1.DataSource = dt;

            // Xử lý sự kiện double-click trên DataGridView
            dataGridView1.CellDoubleClick += (sender, e) =>
            {
                if (e.RowIndex >= 0)  // Kiểm tra nếu đã chọn một hàng hợp lệ
                {
                    var selectedRow = dataGridView1.Rows[e.RowIndex];

                    // Lấy dữ liệu từ cột thứ nhất và thứ hai
                    string hocki = selectedRow.Cells[0].Value?.ToString(); // Cột "Học kì"
                    int namhoc = Convert.ToInt32(selectedRow.Cells[1].Value); // Cột "Năm học"

                    // Mở form với thông tin học kỳ và năm học đã chọn
                    chamdrl otpForm = new chamdrl("Xem", HocKyBUS.GetHocKyByNameAndYear(hocki, namhoc).Id, 2);
                    otpForm.Show();  // Hiển thị form mới
                }
            };
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

        // Hàm chuyển đổi List<Dictionary<string, string>> thành DataTable
        private DataTable ConvertToDataTable(List<Dictionary<string, string>> data)
        {
            DataTable dt = new DataTable();

            if (data.Count > 0)
            {
                // Thêm cột
                foreach (var key in data[0].Keys)
                {
                    dt.Columns.Add(key);
                }

                // Thêm dữ liệu
                foreach (var dictionary in data)
                {
                    DataRow row = dt.NewRow();
                    foreach (var key in dictionary.Keys)
                    {
                        row[key] = dictionary[key];
                    }
                    dt.Rows.Add(row);
                }
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
