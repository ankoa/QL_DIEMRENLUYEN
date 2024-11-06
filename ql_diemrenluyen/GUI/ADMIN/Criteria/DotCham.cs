using CustomControls.RJControls;
using ql_diemrenluyen.BUS;
using ql_diemrenluyen.DAO;
using ql_diemrenluyen.GUI.ADMIN.Account;
using System.Globalization;

namespace ql_diemrenluyen.GUI.ADMIN
{
    public partial class DotCham : Form
    {
        RJDatePicker rjDatePickerStart, rjDatePickerEnd;
        private bool isInitializing = true;
        private bool selectStart = false;
        private bool selectEnd = false;

        Color oldColor;
        Color newColor = Color.FromArgb(0, Color.FromArgb(56, 142, 60));
        int alpha = 0;

        Color oldColor2;
        Color newColor2 = Color.FromArgb(0, Color.FromArgb(33, 150, 243));
        int alpha2 = 0;
        public DotCham()
        {
            InitializeComponent();

            rjDatePickerStart = new RJDatePicker
            {
                SkinColor = System.Drawing.Color.LightBlue,
                TextColor = System.Drawing.Color.White,
                BorderColor = System.Drawing.Color.Gray,
                BorderSize = 2,
                Width = 260,
                Height = 27,
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd/MM/yyyy",
            };

            rjDatePickerEnd = new RJDatePicker
            {
                SkinColor = System.Drawing.Color.LightBlue,
                TextColor = System.Drawing.Color.White,
                BorderColor = System.Drawing.Color.Gray,
                BorderSize = 2,
                Width = 260,
                Height = 27,
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd/MM/yyyy",
            };

            rjDatePickerEnd.ValueChanged += RJDatePickerEnd_ValueChanged;
            rjDatePickerStart.ValueChanged += RJDatePickerStart_ValueChanged;

            // Nếu RJDatePicker không hỗ trợ `null`, có thể cài đặt giá trị mặc định này sau khi khởi tạo.
            // Bạn cũng có thể thêm logic để hiển thị dạng "dd/MM/yyyy" mà không có ngày thực tế nào được chọn.


            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.MaximizeBox = false;
            LoadNamHocCBB();
            LoadDotChamDiemList();
            cbbHocKi.SelectedItem = "Chọn học kì";
            cbbNamHoc.SelectedItem = "Chọn năm học";
            cbbNguoiCham.SelectedItem = "Chọn người chấm";



            flowLayoutPanel2.Controls.Add(label5);
            flowLayoutPanel2.Controls.Add(rjDatePickerStart);
            flowLayoutPanel2.Controls.Add(label6);
            flowLayoutPanel2.Controls.Add(rjDatePickerEnd);

            if (this.Width < 1200)
            {
                pnContent.Padding = new Padding(50);
                pnContent.Dock = DockStyle.Fill;
            }

            isInitializing = false;

            int leftMargin = (tableLayoutPanel1.ClientSize.Width - label2.Width - label3.Width - label4.Width - cbbHocKi.Width - cbbNamHoc.Width - cbbNguoiCham.Width - 59 * 2) / 2;
            int leftMarginReset = (tableLayoutPanel1.ClientSize.Width - panel2.Width * 2 - 59) / 2;
            int leftMarginBtnAdd = (this.ClientSize.Width - btnAdd.Width * 2) / 2;
            btnAdd.Margin = new Padding(leftMarginBtnAdd, 3, 0, 0);
            label5.Margin = new Padding(leftMargin, 3, 0, 0);
            label2.Margin = new Padding(leftMargin, 3, 0, 0);
            panel2.Margin = new Padding(leftMarginReset, 3, 0, 0);
            panel2.BackColor = Color.FromArgb(76, 175, 80);
            panel4.BackColor = Color.FromArgb(66, 165, 245);
            oldColor = panel2.BackColor;
            oldColor2 = panel4.BackColor;
        }

        private void TaiKhoan_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.Dock = DockStyle.Fill;
            LoadDotChamDiemList();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            alpha = 0;
            timer1.Interval = 15;
            timer1.Start();
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            timer1.Stop();
            panel2.BackColor = oldColor;
            panel2.ForeColor = Color.Black;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cbbHocKi.SelectedItem = "Chọn học kì";
            cbbNamHoc.SelectedItem = "Chọn năm học";
            cbbNguoiCham.SelectedItem = "Chọn người chấm";
            rjDatePickerStart = new RJDatePicker
            {
                SkinColor = System.Drawing.Color.LightBlue,
                TextColor = System.Drawing.Color.White,
                BorderColor = System.Drawing.Color.Gray,
                BorderSize = 2,
                Width = 260,
                Height = 27,
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd/MM/yyyy",
            };
            selectEnd = false;
            selectStart = false;
            rjDatePickerStart = new RJDatePicker
            {
                SkinColor = System.Drawing.Color.LightBlue,
                TextColor = System.Drawing.Color.White,
                BorderColor = System.Drawing.Color.Gray,
                BorderSize = 2,
                Width = 260,
                Height = 27,
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd/MM/yyyy",
            };
            SearchAccountList();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            alpha += 17;  // change this for greater or less speed
            panel2.BackColor = Color.FromArgb(alpha, newColor);
            if (alpha >= 255) timer1.Stop();
            if (panel2.BackColor.GetBrightness() < 0.3) panel2.ForeColor = Color.White;
        }
        private void button2_MouseEnter(object sender, EventArgs e)
        {
            alpha2 = 0;
            timer2.Interval = 15;
            timer2.Start();
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            timer2.Stop();
            panel4.BackColor = oldColor2;
            panel4.ForeColor = Color.Black;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            alpha2 += 17;  // change this for greater or less speed
            panel4.BackColor = Color.FromArgb(alpha2, newColor2);
            if (alpha2 >= 255) timer2.Stop();
            if (panel4.BackColor.GetBrightness() < 0.3) panel4.ForeColor = Color.White;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SearchAccountList();
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

        public void SearchAccountList()
        {
            try
            {
                string hocki = cbbHocKi.SelectedItem?.ToString() ?? "";
                string namhoc = cbbNamHoc.SelectedItem?.ToString() ?? "";
                string nguoicham = cbbNguoiCham.SelectedItem?.ToString() ?? "";

                if (string.IsNullOrEmpty(hocki) || string.IsNullOrEmpty(namhoc) || string.IsNullOrEmpty(nguoicham))
                {
                    return;
                }

                DateTime? selectedDateStart = selectStart ? (DateTime?)rjDatePickerStart.Value : null;
                DateTime? selectedDateEnd = selectEnd ? (DateTime?)rjDatePickerEnd.Value : null;

                List<ThongTinDotChamDiemDTO> accounts = DotChamDiemBUS.TimKiemDotChamDiem(hocki, namhoc, nguoicham, selectedDateStart, selectedDateEnd);
                tableTK.Rows.Clear();

                foreach (var dotChamDiem in accounts)
                {
                    string statusText = dotChamDiem.Status switch
                    {
                        1 => "Active",
                        0 => "Unactive",
                        -1 => "Delete",
                        _ => "Unknown"
                    };

                    tableTK.Rows.Add(
                        dotChamDiem.Id,
                        dotChamDiem.NamHoc,
                        dotChamDiem.HocKy,
                        dotChamDiem.DotChamDiem,
                        dotChamDiem.NgayBatDau.ToString("dd/MM/yyyy"),
                        dotChamDiem.NgayKetThuc.ToString("dd/MM/yyyy"),
                        statusText
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
            if (e.RowIndex >= 0)
            {
                var selectedRow = tableTK.Rows[e.RowIndex];

                int id = (int)selectedRow.Cells["dataGridViewTextBoxColumn1"].Value;
                string hocky = selectedRow.Cells["dataGridViewTextBoxColumn3"].Value?.ToString() ?? "";
                string namhoc = selectedRow.Cells["dataGridViewTextBoxColumn5"].Value?.ToString() ?? "";
                string nguoicham = selectedRow.Cells["dataGridViewTextBoxColumn8"].Value?.ToString() ?? "";

                DateTime createdAt = DateTime.TryParseExact(
                    selectedRow.Cells["dataGridViewTextBoxColumn6"].Value?.ToString(),
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime tempCreatedAt
                ) ? tempCreatedAt : DateTime.MinValue;

                DateTime updatedAt = DateTime.TryParseExact(
                    selectedRow.Cells["dataGridViewTextBoxColumn7"].Value?.ToString(),
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime tempUpdatedAt
                ) ? tempUpdatedAt : DateTime.MinValue;


                AddDotCham detailsForm = new AddDotCham(id, hocky, namhoc, nguoicham, createdAt, updatedAt, tableTK, this);
                detailsForm.Show();
            }
        }

        private void cbbHocKi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isInitializing)
                SearchAccountList();
        }

        private void cbbNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isInitializing)
                SearchAccountList();
        }

        private void cbbNguoiCham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isInitializing)
                SearchAccountList();
        }

        // Hàm sự kiện khi chọn ngày
        private void RJDatePickerEnd_ValueChanged(object sender, EventArgs e)
        {
            selectEnd = true;
            if (!isInitializing)
                SearchAccountList();
            // Hoặc xuất ra label:
            // labelDate.Text = "Ngày đã chọn: " + selectedDate.ToString("dd/MM/yyyy");
        }

        private void RJDatePickerStart_ValueChanged(object sender, EventArgs e)
        {
            selectStart = true;
            if (!isInitializing)
                SearchAccountList();
            // Hoặc xuất ra label:
            // labelDate.Text = "Ngày đã chọn: " + selectedDate.ToString("dd/MM/yyyy");
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

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //int id = (int)selectedRow.Cells["dataGridViewTextBoxColumn1"].Value;
            //string hocky = selectedRow.Cells["dataGridViewTextBoxColumn3"].Value?.ToString() ?? "";
            //string namhoc = selectedRow.Cells["dataGridViewTextBoxColumn5"].Value?.ToString() ?? "";
            //string nguoicham = selectedRow.Cells["dataGridViewTextBoxColumn8"].Value?.ToString() ?? "";

            //DateTime createdAt = DateTime.TryParseExact(
            //    selectedRow.Cells["dataGridViewTextBoxColumn6"].Value?.ToString(),
            //    "dd/MM/yyyy",
            //    CultureInfo.InvariantCulture,
            //    DateTimeStyles.None,
            //    out DateTime tempCreatedAt
            //) ? tempCreatedAt : DateTime.MinValue;

            //DateTime updatedAt = DateTime.TryParseExact(
            //    selectedRow.Cells["dataGridViewTextBoxColumn7"].Value?.ToString(),
            //    "dd/MM/yyyy",
            //    CultureInfo.InvariantCulture,
            //    DateTimeStyles.None,
            //    out DateTime tempUpdatedAt
            //) ? tempUpdatedAt : DateTime.MinValue;


            ThemDotCham detailsForm = new ThemDotCham(tableTK, this);
            detailsForm.ShowDialog();

        }
    }
}
