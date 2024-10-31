using CustomControls.RJControls;
using ql_diemrenluyen.BUS;
using ql_diemrenluyen.DAO;

namespace ql_diemrenluyen.GUI.ADMIN
{
    public partial class DotCham : Form
    {
        RJDatePicker rjDatePickerStart, rjDatePickerEnd;
        public DotCham()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.MaximizeBox = false;
            LoadNamHocCBB();
            LoadDotChamDiemList();
            cbbHocKi.SelectedItem = "Chọn học kì";
            cbbNamHoc.SelectedItem = "Mặc định";
            cbbNguoiCham.SelectedItem = "Chọn người chấm";

            rjDatePickerStart = new RJDatePicker
            {
                //Location = new System.Drawing.Point(50, 50), // Vị trí trên form
                SkinColor = System.Drawing.Color.LightBlue,
                TextColor = System.Drawing.Color.White,
                BorderColor = System.Drawing.Color.Gray,
                BorderSize = 2,
                Width = 260,
                Height = 27,
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd/MM/yyyy",
                Value = DateTime.Now
            };

            rjDatePickerEnd = new RJDatePicker
            {
                //Location = new System.Drawing.Point(50, 50), // Vị trí trên form
                SkinColor = System.Drawing.Color.LightBlue,
                TextColor = System.Drawing.Color.White,
                BorderColor = System.Drawing.Color.Gray,
                BorderSize = 2,
                Width = 260,
                Height = 27,
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd/MM/yyyy",
                Value = DateTime.Now
            };

            flowLayoutPanel2.Controls.Add(label5);
            flowLayoutPanel2.Controls.Add(rjDatePickerStart);
            flowLayoutPanel2.Controls.Add(label6);
            flowLayoutPanel2.Controls.Add(rjDatePickerEnd);

            if (this.Width < 1200)
            {
                pnContent.Padding = new Padding(50);
                pnContent.Dock = DockStyle.Fill;
            }

            //int leftMargin = (tableLayoutPanel1.ClientSize.Width - pnInput.Width) / 2;
            //pnInput.Margin = new Padding(leftMargin, 3, 0, 0);
            //label5.Margin = new Padding(leftMargin, 3, 0, 0);
            //label2.Margin = new Padding(leftMargin - 120, 3, 0, 0);
        }

        private void TaiKhoan_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.Dock = DockStyle.Fill;
            LoadDotChamDiemList();
        }

        private void LoadDotChamDiemList()
        {
            try
            {
                List<ThongTinDotChamDiemDTO> dotChamDiemList = DotChamDiemBUS.GetAllDotChamDiemVoiHocKiVaNamHoc();
                tableTK.Rows.Clear();

                foreach (var dotChamDiem in dotChamDiemList)
                {
                    tableTK.Rows.Add(
                         dotChamDiem.Id,
                        dotChamDiem.NamHoc,
                        dotChamDiem.HocKy,
                        dotChamDiem.DotChamDiem,
                        dotChamDiem.NgayBatDau.ToString("dd/MM/yyyy"),
                        dotChamDiem.NgayKetThuc.ToString("dd/MM/yyyy")
                    );
                }

                ApplyTableStyles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách đợt chấm: " + ex.Message);
            }
        }
        public static void LoadDotChamDiemList(DataGridView table)
        {
            try
            {
                List<ThongTinDotChamDiemDTO> dotChamDiemList = DotChamDiemBUS.GetAllDotChamDiemVoiHocKiVaNamHoc();
                table.Rows.Clear();

                foreach (var dotChamDiem in dotChamDiemList)
                {
                    table.Rows.Add(
                        dotChamDiem.Id,
                        dotChamDiem.NamHoc,
                        dotChamDiem.HocKy,
                        dotChamDiem.DotChamDiem,
                        dotChamDiem.NgayBatDau.ToString("dd/MM/yyyy"),
                        dotChamDiem.NgayKetThuc.ToString("dd/MM/yyyy")
                    );
                }

                ApplyTableStyles(table); // Gọi hàm áp dụng kiểu cho bảng nếu có
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách đợt chấm điểm: " + ex.Message);
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

        private void LoadNamHocCBB()
        {
            try
            {
                // Lấy danh sách năm học từ phương thức GetAllNamHoc
                List<string> danhSachNamHoc = HocKyBUS.GetAllNamHoc();

                // Thêm từng năm học vào ComboBox
                foreach (var namHoc in danhSachNamHoc)
                {
                    cbbNamHoc.Items.Add(namHoc);
                }

                // Chọn mục đầu tiên (nếu danh sách không rỗng)
                if (cbbNamHoc.Items.Count > 0)
                {
                    cbbNamHoc.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có lỗi trong quá trình load dữ liệu
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Hàm tìm kiếm tài khoản theo role, status và search term

        private void SearchAccountList()
        {
            try
            {
                string hocki = cbbHocKi.SelectedItem?.ToString() ?? ""; // Sử dụng toán tử null-coalescing
                string namhoc = cbbNamHoc.SelectedItem?.ToString() ?? "";
                string nguoicham = cbbNguoiCham.SelectedItem?.ToString() ?? "";

                if (string.IsNullOrEmpty(hocki) || string.IsNullOrEmpty(namhoc) || string.IsNullOrEmpty(nguoicham))
                {
                    MessageBox.Show("Vui lòng chọn đầy đủ thông tin trước khi tìm kiếm.");
                    return; // Dừng lại nếu không có thông tin cần thiết
                }

                DateTime selectedDateStart = rjDatePickerStart.Value;
                DateTime selectedDateEnd = rjDatePickerEnd.Value;

                List<ThongTinDotChamDiemDTO> accounts = DotChamDiemBUS.TimKiemDotChamDiem(hocki, namhoc, nguoicham, selectedDateStart, selectedDateEnd);
                tableTK.Rows.Clear();

                foreach (var dotChamDiem in accounts)
                {
                    tableTK.Rows.Add(
                        dotChamDiem.Id,
                        dotChamDiem.NamHoc,
                        dotChamDiem.HocKy,
                        dotChamDiem.DotChamDiem,
                        dotChamDiem.NgayBatDau.ToString("dd/MM/yyyy"),
                        dotChamDiem.NgayKetThuc.ToString("dd/MM/yyyy")
                    );
                }

                ApplyTableStyles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm đợt chấm: " + ex.Message);
            }
        }




        // Hàm tìm kiếm khi thay đổi nội dung trong các textbox hoặc combobox



        private void tableTK_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0)
            //{
            //    var selectedRow = tableTK.Rows[e.RowIndex];

            //    long id = (long)selectedRow.Cells["dataGridViewTextBoxColumn1"].Value;
            //    string password = selectedRow.Cells["dataGridViewTextBoxColumn5"].Value?.ToString() ?? "";
            //    string role = selectedRow.Cells["dataGridViewTextBoxColumn3"].Value?.ToString() ?? "";
            //    string rememberToken = selectedRow.Cells["dataGridViewTextBoxColumn6"].Value?.ToString() ?? "";
            //    string status = selectedRow.Cells["dataGridViewTextBoxColumn4"].Value?.ToString() ?? "";

            //    DateTime createdAt = DateTime.TryParse(selectedRow.Cells["dataGridViewTextBoxColumn7"].Value?.ToString(), out DateTime tempCreatedAt)
            //        ? tempCreatedAt : DateTime.MinValue;
            //    DateTime updatedAt = DateTime.TryParse(selectedRow.Cells["dataGridViewTextBoxColumn8"].Value?.ToString(), out DateTime tempUpdatedAt)
            //        ? tempUpdatedAt : DateTime.MinValue;

            //    //AccountDetailsForm detailsForm = new AccountDetailsForm(id, password, role, rememberToken, createdAt, updatedAt, status, tableTK, this);
            //    //detailsForm.Show();
            //}
        }

        private void cbbHocKi_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchAccountList();
        }

        private void cbbNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchAccountList();
        }

        private void cbbNguoiCham_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchAccountList();
        }

        private void tableTK_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnTop_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
