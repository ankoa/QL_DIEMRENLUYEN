using ql_diemrenluyen.BUS;
using ql_diemrenluyen.DAO;
using ql_diemrenluyen.DTO;
using ScottPlot;
using ScottPlot.WinForms;

namespace ql_diemrenluyen.GUI.ADMIN.Statistic
{
    public partial class Thongke : Form
    {
        private FormsPlot formsPlot1;
        private FormsPlot formsPlot2;
        private Button currentBtn;
        private String typeThongKe = "Tổng quan";
        public Thongke()
        {
            InitializeComponent();
            InitializeFormsPlot();  // Khởi tạo và thêm FormsPlot vào form
            CreatePieChart();
            CreateBarChart();
            btnTypeThongkeClick(btnTongQuan);
            lblDrlTB.Text = DiemRenLuyenSinhVienDAO.GetAverageDiemRenLuyenByFilter().ToString();
            lblSoHs.Text = SinhVienDAO.GetAllStudentsActive().Count().ToString();
            lblKhongDat.Text = DiemRenLuyenSinhVienDAO.GetSoSinhVienCanhCaoByFilter(50, "<").ToString();
            cbbHocKi.SelectedItem = "Chọn học kì";
            cbbNamHoc.SelectedItem = "Chọn năm học";
            cbbKhoa.SelectedItem = "Chọn khoa";
            cbbLop.SelectedItem = "Chọn lớp";
            cbbHocKi.Visible = false;
            cbbNamHoc.Visible = false;
            cbbKhoa.Visible = false;
            cbbLop.Visible = false;
            loadKhoa();
            loadLop();
        }

        private void InitializeFormsPlot()
        {
            // Khởi tạo FormsPlot
            formsPlot1 = new FormsPlot();
            this.panel4.Controls.Add(formsPlot1);  // Thêm FormsPlot vào panel4
            formsPlot1.Dock = DockStyle.Fill;  // Đảm bảo FormsPlot chiếm toàn bộ diện tích panel
            formsPlot1.Width = panel4.Width;  // Thiết lập chiều rộng của FormsPlot
            formsPlot1.Height = panel4.Height;  // Thiết lập chiều cao của FormsPlot
            //formsPlot1.Plot.ScaleFactor = 2;

            // Khởi tạo FormsPlot
            formsPlot2 = new FormsPlot();
            this.panel5.Controls.Add(formsPlot2);  // Thêm FormsPlot vào panel4
            formsPlot2.Dock = DockStyle.Fill;  // Đảm bảo FormsPlot chiếm toàn bộ diện tích panel
            formsPlot2.Width = panel5.Width;  // Thiết lập chiều rộng của FormsPlot
            formsPlot2.Height = panel5.Height;  // Thiết lập chiều cao của FormsPlot
        }

        private ScottPlot.Color GetColorForLabel(string label)
        {
            switch (label)
            {
                case "Xuất sắc":
                    return Colors.Green;  // Màu xanh lá cho "Xuất sắc"
                case "Tốt":
                    return Colors.Blue;   // Màu xanh dương cho "Tốt"
                case "Khá":
                    return Colors.Yellow; // Màu vàng cho "Khá"
                case "Trung bình":
                    return Colors.Orange; // Màu cam cho "Trung bình"
                case "Yếu":
                    return Colors.Red;    // Màu đỏ cho "Yếu"
                default:
                    return Colors.Gray;   // Màu xám nếu không xác định được
            }
        }


        private void CreatePieChart(long? khoaId = null, long? lopId = null, int? hockiId = null, int? namhocId = null)
        {
            // Clear the existing plot
            //formsPlot1 = new FormsPlot();
            formsPlot1.Plot.Clear();
            formsPlot1.Refresh();


            // Lấy dữ liệu danh gia từ cơ sở dữ liệu
            var danhGiaData = DiemRenLuyenSinhVienDAO.GetXepLoai(khoaId, lopId, hockiId, namhocId);

            // Tạo danh sách PieSlice từ kết quả trả về
            List<PieSlice> slices = danhGiaData.Select(d => new PieSlice
            {
                Label = d.Key, // Đánh giá (ví dụ: "Tốt", "Khá", ...)
                Value = d.Value, // Số lượng
                FillColor = GetColorForLabel(d.Key) // Màu sắc tương ứng với từng đánh giá
            }).ToList();

            // Tạo biểu đồ pie từ danh sách slices
            var pie = formsPlot1.Plot.Add.Pie(slices);
            //pie.ExplodeFraction = .1;
            pie.SliceLabelDistance = .6;

            double total = pie.Slices.Select(x => x.Value).Sum();
            MessageBox.Show(total.ToString());
            for (int i = 0; i < pie.Slices.Count; i++)
            {
                pie.Slices[i].LabelFontSize = 14;
                pie.Slices[i].Label = $"{pie.Slices[i].Label}";

                // Thêm số lượng và phần trăm vào LegendText
                double percentage = pie.Slices[i].Value / total * 100;
                pie.Slices[i].LegendText = $"{pie.Slices[i].Label}: {pie.Slices[i].Value} ({percentage:0.0}%)";
            }

            // Tô màu chữ của label theo màu sắc của slice
            slices.ForEach(x => x.LabelFontColor = ScottPlot.Colors.White);

            // Ẩn các thành phần không cần thiết của biểu đồ
            formsPlot1.Plot.HideGrid();
            formsPlot1.Plot.ShowLegend(Edge.Bottom);

            // Làm mới biểu đồ
            formsPlot1.Refresh();
        }


        //private void CreatePieChart()
        //{
        //    PieSlice slice1 = new() { Value = 5, FillColor = Colors.Red, Label = "alpha" };
        //    PieSlice slice2 = new() { Value = 2, FillColor = Colors.Orange, Label = "beta" };
        //    PieSlice slice3 = new() { Value = 8, FillColor = Colors.Gold, Label = "gamma" };
        //    PieSlice slice4 = new() { Value = 4, FillColor = Colors.Green, Label = "delta" };
        //    PieSlice slice5 = new() { Value = 8, FillColor = Colors.Blue, Label = "epsilon" };

        //    List<PieSlice> slices = new() { slice1, slice2, slice3, slice4, slice5 };

        //    // setup the pie to display slice labels
        //    var pie = formsPlot1.Plot.Add.Pie(slices);
        //    pie.ExplodeFraction = .1;
        //    pie.SliceLabelDistance = .5;

        //    double total = pie.Slices.Select(x => x.Value).Sum();
        //    for (int i = 0; i < pie.Slices.Count; i++)
        //    {
        //        pie.Slices[i].LabelFontSize = 20;
        //        pie.Slices[i].Label = $"{pie.Slices[i].Label}";
        //        pie.Slices[i].LegendText = $"{pie.Slices[i].Label} " +
        //            $"({pie.Slices[i].Value / total:p1})";
        //    }

        //    // color each label's text to match the slice
        //    slices.ForEach(x => x.LabelFontColor = x.FillColor.Darken(.5));

        //    // hide unnecessary plot components
        //    //formsPlot1.Plot.Axes.Frameless();
        //    //formsPlot2.Plot.Axes.AutoScale();
        //    formsPlot1.Plot.HideGrid();
        //    formsPlot1.Plot.ShowLegend(Edge.Bottom);
        //    //formsPlot1.Plot.Axes.SetLimitsY(-1, 1);
        //    //formsPlot1.Plot.Axes.SetLimitsX(-1, 1);

        //    formsPlot1.Refresh();
        //}

        //private void CreateBarChart()
        //{
        //    formsPlot2.Plot.Add.Bar(position: 1, value: 30);
        //    formsPlot2.Plot.Add.Bar(position: 2, value: 50);
        //    formsPlot2.Plot.Add.Bar(position: 3, value: 70);
        //    formsPlot2.Plot.Add.Bar(position: 4, value: 90);

        //    Tick[] ticks =
        //        {
        //            new(1, "Apple"),
        //            new(2, "Orange"),
        //            new(3, "Pear"),
        //            new(4, "Banana"),
        //        };

        //    formsPlot2.Plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(ticks);
        //    formsPlot2.Plot.Axes.Bottom.MajorTickStyle.Length = 0;
        //    formsPlot2.Plot.HideGrid();
        //    formsPlot2.Plot.Axes.AutoScale();
        //    formsPlot2.Plot.Axes.SetLimitsY(0, 100);
        //    formsPlot2.Plot.Axes.Left.TickGenerator = new ScottPlot.TickGenerators.NumericFixedInterval(20);

        //    formsPlot2.Refresh();
        //}

        private void CreateBarChart(int? hockiId = null, int? namhocId = null)
        {
            // Lấy dữ liệu điểm trung bình theo khoa
            var diemTrungBinhCuaCacKhoa = DiemRenLuyenSinhVienDAO.GetDiemTrungBinhCuaCacKhoa(hockiId, namhocId);

            // Xóa dữ liệu cũ trên biểu đồ
            formsPlot2.Plot.Clear();

            // Sử dụng List<Tick> để lưu nhãn cho các cột
            List<Tick> ticks = new List<Tick>();

            // Vị trí ban đầu trên trục X
            int position = 1;

            // Thêm dữ liệu vào biểu đồ
            foreach (var item in diemTrungBinhCuaCacKhoa)
            {
                string khoaId = item.Key;         // ID của khoa
                double diemTrungBinh = item.Value; // Điểm trung bình của khoa

                // Thêm nhãn cho trục X
                ticks.Add(new Tick(position, $"{khoaId}"));

                // Thêm cột vào biểu đồ
                formsPlot2.Plot.Add.Bar(position: position, value: diemTrungBinh);

                position++;
            }

            // Cài đặt nhãn cho trục X
            formsPlot2.Plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(ticks.ToArray());

            // Tùy chỉnh biểu đồ
            formsPlot2.Plot.Axes.Bottom.MajorTickStyle.Length = 0; // Ẩn dấu tick lớn ở trục X
            formsPlot2.Plot.HideGrid(); // Ẩn lưới
            formsPlot2.Plot.Axes.AutoScale(); // Tự động scale trục
            formsPlot2.Plot.Axes.SetLimitsY(0, 100); // Giới hạn trục Y từ 0 đến 100
            formsPlot2.Plot.Axes.Left.TickGenerator = new ScottPlot.TickGenerators.NumericFixedInterval(20); // Tick trục Y cách đều 20

            // Vẽ lại biểu đồ
            formsPlot2.Refresh();
        }



        private void UpdateChartSize()
        {
            formsPlot1.Width = panel4.Width;
            formsPlot1.Height = panel4.Height;
            formsPlot1.Refresh(); // Làm mới để áp dụng thay đổi

            formsPlot2.Width = panel5.Width;
            formsPlot2.Height = panel5.Height;
            formsPlot2.Refresh(); // Làm mới để áp dụng thay đổi
        }

        private void Panel5_SizeChanged(object sender, EventArgs e)
        {
            UpdateChartSize(); // Cập nhật kích thước FormsPlot khi Panel thay đổi kích thước
        }

        private void resize(object sender, EventArgs e)
        {
            formsPlot1.Refresh();
        }




        private void dungeonComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void loadLop(long? khoaId = null)
        {
            //MessageBox.Show("load lop");
            List<LopDTO> lopList = new List<LopDTO>();

            if (khoaId != null)
            {
                lopList = LopBUS.getLopByKhoaId(khoaId.ToString());
            }
            else
            {
                lopList = LopBUS.getAllLop();
            }
            //MessageBox.Show(lopList.Count().ToString());

            LopDTO defaultItem = new LopDTO
            {
                Id = -1,
                TenLop = "Chọn lớp"
            };

            // Thêm đối tượng mặc định vào danh sách
            lopList.Insert(0, defaultItem);

            // Đặt dữ liệu vào ComboBox
            cbbLop.DataSource = lopList;
            cbbLop.DisplayMember = "TenLop";
            cbbLop.ValueMember = "Id";

            // Cài đặt chế độ tìm kiếm tự động cho ComboBox
            //cbbLop.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbbLop.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbbLop.SelectedIndex = 0;
            //MessageBox.Show("load lop");
        }

        private void loadKhoa()
        {
            List<KhoaDTO> khoaList = new List<KhoaDTO>();
            khoaList = KhoaDAO.GetAllKhoa();

            KhoaDTO defaultItem = new KhoaDTO
            {
                Id = -1,
                TenKhoa = "Chọn khoa"
            };

            // Thêm đối tượng mặc định vào danh sách
            khoaList.Insert(0, defaultItem);

            // Đặt dữ liệu vào ComboBox
            cbbKhoa.DataSource = khoaList;
            cbbKhoa.DisplayMember = "TenKhoa";
            cbbKhoa.ValueMember = "Id";

            // Cài đặt chế độ tìm kiếm tự động cho ComboBox
            //cbbKhoa.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbbKhoa.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbbKhoa.SelectedIndex = 0;
        }


        private void btnTypeThongkeClick(object sender)
        {
            var btn = (Button)sender;

            // Thiết lập trạng thái nút mới được chọn
            btn.BackColor = btnTongQuan.FlatAppearance.BorderColor; // Đặt màu nền của nút
            btn.ForeColor = System.Drawing.Color.Black; // Đặt màu chữ của nút

            // Nếu tồn tại nút trước đó và khác với nút hiện tại
            if (currentBtn != null && currentBtn != btn)
            {
                // Trả về trạng thái ban đầu của nút trước đó
                currentBtn.BackColor = System.Drawing.Color.RoyalBlue; // Hoặc màu nền gốc của nút
                currentBtn.ForeColor = System.Drawing.Color.White; // Hoặc màu chữ gốc của nút
            }

            // Cập nhật nút hiện tại
            currentBtn = btn;
        }


        private void btnTongQuan_Click(object sender, EventArgs e)
        {
            btnTypeThongkeClick(sender);
            //CreatePieChart();
            //CreateBarChart();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            btnTypeThongkeClick(sender);
            typeThongKe = "Lớp";
            cbbHocKi.Visible = true;
            cbbNamHoc.Visible = true;
            cbbKhoa.Visible = true;
            cbbLop.Visible = true;
            loadLop();
            cbbKhoa.SelectedIndex = 0;
            cbbLop.SelectedIndex = 0;
        }



        private void button3_Click(object sender, EventArgs e)
        {
            btnTypeThongkeClick(sender);
            typeThongKe = "Khoa";
            cbbHocKi.Visible = true;
            cbbNamHoc.Visible = true;
            cbbKhoa.Visible = true;
            cbbLop.Visible = false;
            cbbKhoa.SelectedIndex = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            btnTypeThongkeClick(sender);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem có mục nào được chọn không
            if (cbbKhoa.SelectedIndex != 0)
            {
                KhoaDTO khoa = (KhoaDTO)cbbKhoa.SelectedItem;
                //MessageBox.Show(khoa.Id.ToString());
                loadLop(khoa.Id); // Gọi hàm loadLop với Id của khoa
            }
            else
            {
                loadLop(); // Gọi loadLop mà không có điều kiện khoaId nếu không có lựa chọn
            }
        }

        private void cbbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem có mục nào được chọn không
            if (cbbLop.SelectedIndex != 0)
            {
                LopDTO lop = (LopDTO)cbbLop.SelectedItem;
                //MessageBox.Show(khoa.Id.ToString());
                CreatePieChart(lopId: lop.Id);
            }
            else
            {
                //loadLop(); // Gọi loadLop mà không có điều kiện khoaId nếu không có lựa chọn
            }
        }
    }
}
