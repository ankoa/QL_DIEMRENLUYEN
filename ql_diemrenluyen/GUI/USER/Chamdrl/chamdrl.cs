using ql_diemrenluyen.BUS;
using ql_diemrenluyen.DAO;
using ql_diemrenluyen.DTO;
using ql_diemrenluyen.Helper;
using QLDiemRenLuyen;
using System.Data;
using System.Drawing.Imaging;
using System.Net;

namespace ql_diemrenluyen.GUI.ADMIN
{
    public partial class chamdrl : Form
    {
        AutoCompleteStringCollection data1 = new AutoCompleteStringCollection();
        List<KhoaDTO> khoaList = KhoaBUS.GetAllKhoa();
        List<LopDTO> lopList = LopBUS.getAllLop();
        List<HocKyDTO> hockyList = HocKyBUS.GetAllHocKy();
        List<SinhVienDTO> sinhvienList;
        List<TieuChiDanhGiaDTO> tieuChiList = TieuChiDanhGiaBUS.XuatAllTieuChiDanhGia();
        private Dictionary<string, long> sttToId = new Dictionary<string, long>();
        //private System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
        private System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
        long nguoiDungId = long.Parse(Program.nguoidung_id);
        int vaiTro = Program.role;
        string action = "";
        int hockiId;
        int dotchamdiemId;
        long covanId;
        long khoaId;
        private int originalValue = 0; // Biến lưu giá trị cũ của ô đang chỉnh sửa



        public chamdrl(string action, int hocky, int dotchamdiem)
        {
            //long sinhvienId, long? giangvienId = null, string action
            InitializeComponent();
            this.action = action;
            this.hockiId = hocky;
            this.dotchamdiemId = dotchamdiem;

        }

        private void chamdrl_Load(object sender, EventArgs e)
        {
            string role = this.vaiTro switch
            {
                1 => "Sinh viên",
                3 => "Cố vấn",
                4 => "Khoa",
                5 => "Trường",
                _ => "Unknown"
            };
            sinhvienList = SinhVienBUS.GetAllStudentsToChamDiem(role);
            if (vaiTro == 3 || vaiTro == 4)
            {
                cbKhoa.Enabled = false;
            }
            if (vaiTro == 1)
            {

                var selectedStudent = sinhvienList.FirstOrDefault(sv => sv.Id == nguoiDungId);


                if (selectedStudent != null)
                {
                    lbTen.Text = selectedStudent.Name;
                    lbMssv.Text = selectedStudent.Id.ToString();
                }

                tableLayoutPanel2.RowStyles[1].Height = 0;
                tableLayoutPanel2.RowStyles[2].Height = 0;
                LoadData();
            }
            else
            {
                loadCbbAndDataLabel();


                tableLayoutPanel2.RowStyles[0].SizeType = SizeType.Percent;
                tableLayoutPanel2.RowStyles[1].SizeType = SizeType.Percent;
                tableLayoutPanel2.RowStyles[2].SizeType = SizeType.Percent;

                // Thiết lập chiều cao của từng hàng (phần trăm)
                tableLayoutPanel2.RowStyles[0].Height = 28;
                tableLayoutPanel2.RowStyles[1].Height = 40;
                tableLayoutPanel2.RowStyles[2].Height = 32;
            }

            if (action == "Chấm")
            {
                btnLuu.Visible = true;
                label6.Visible = false;
                label5.Visible = false;
                button1.Visible = false;
                if (vaiTro != 1 && vaiTro != 0)
                {
                    button2.Visible = true;
                }
            }
            else if (action == "Xem")
            {
                btnLuu.Visible = false;
                label6.Visible = true;
                label5.Visible = true;
                button1.Visible = false;
                //long svID = long.Parse(lbMssv.Text);
                if (vaiTro == 1)
                {
                    DiemRenLuyenSinhVienDTO drl = DiemRenLuyenSinhVienDAO.GetDiemRenLuyenBySinhVienIdAndHocKiId(nguoiDungId, this.hockiId);
                    lbXepHang.Text = drl.Comments;
                    lbDiem.Text = drl.Score.ToString();
                    lbXepHang.Text = drl.Comments;
                    button1.Visible = true;
                }


                lbhocky.Visible = true;
                cbHocKy.Visible = true;
                cbHocKy.SelectedValue = this.hockiId;
                //cbHocKy.SelectedIndex = 1;
                //MessageBox.Show(cbHocKy.SelectedItem.ToString());
            }

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }




        private void LoadData()
        {
            List<TieuChiDanhGiaDTO> tieuChiList = TieuChiDanhGiaBUS.XuatAllTieuChiDanhGia();
            DataTable dataTable;
            if (this.action == "Chấm")
            {
                dataTable = ConvertToDataTableChamDiem(tieuChiList);
            }
            else
            {
                dataTable = ConvertToDataTableXemDiem(tieuChiList);
            }


            dataGridView1.DataSource = dataTable; // Gán DataTable vào DataGridView
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns["STT"].Width = 45;

            dataGridView1.Columns["Nội dung tiêu chí đánh giá"].Width = 350;
            dataGridView1.Columns["Nội dung tiêu chí đánh giá"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowTemplate.Height = 50;

            //dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.Columns["Điểm tối đa"].Width = 100;
            dataGridView1.Refresh();

            dataGridView1.Columns["STT"].ReadOnly = true;
            dataGridView1.Columns["Nội dung tiêu chí đánh giá"].ReadOnly = true;
            dataGridView1.Columns["Điểm tối đa"].ReadOnly = true;

            // Mặc định tất cả các cột đều không chỉnh sửa được
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.ReadOnly = true;
            }

            if (this.action == "Chấm")
            {
                // Xác định vai trò và cho phép chỉnh sửa cột phù hợp
                switch (Program.role) // role = "1=Sinh Viên", "3=Cố vấn", "4=Khoa", "5=Trường"
                {
                    case 1:
                        dataGridView1.Columns["Điểm SV tự đánh giá"].ReadOnly = false;
                        //dataGridView1.Columns["Ghi Chú"].ReadOnly = false;
                        break;
                    case 3:
                        dataGridView1.Columns["Điểm CVHT"].ReadOnly = false;
                        break;
                    case 4:
                        dataGridView1.Columns["Điểm khoa"].ReadOnly = false;
                        break;
                    case 5:
                        dataGridView1.Columns["Điểm trường"].ReadOnly = false;
                        break;
                    default:
                        MessageBox.Show("Vai trò không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }


            dataGridView1.EditingControlShowing += dataGridView_EditingControlShowing;
            dataGridView1.CellClick += dgvTieuChi_CellClick;
            // dataGridView1.CellMouseLeave += dgvTieuChi_CellMouseLeave;
            dataGridView1.ShowCellToolTips = true;
            //toolTip.AutoPopDelay = 5000;  // Thời gian hiển thị tối đa
            //toolTip.InitialDelay = 200;  // Thời gian chờ trước khi hiển thị
            //toolTip.ReshowDelay = 100;   // Thời gian chờ giữa các lần hiển thị
            //toolTip.IsBalloon = true;    // Hiển thị ToolTip dạng balloon

            //dataGridView1.Columns["Điểm SV tự đánh giá"].ReadOnly = true;

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Name == "Nội dung tiêu chí đánh giá")
                {
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
                else
                {
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                column.Resizable = DataGridViewTriState.False;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            // Tùy chỉnh màu sắc của các hàng
            CustomizeRowAppearance();
            //--------LOAD LỌC DANH SÁCH------------

        }

        private void loadCbbAndDataLabel()
        {
            if (vaiTro == 3)
            {
                GiangVienDTO gv = GiangVienBUS.GetGiangVienById(nguoiDungId);
                for (int i = 0; i < khoaList.Count; i++)
                {
                    if (gv.KhoaId == khoaList[i].Id && gv.Status == 1 && khoaList[i].status == 1)
                    {
                        data1.Add(khoaList[i].TenKhoa);
                        LoadLopTheoCoVan(gv.Id);
                        break;
                    }

                }

                cbKhoa.AutoCompleteCustomSource = data1;
                cbKhoa.DataSource = data1;
                cbKhoa.SelectedIndex = 0;
            }
            else if (vaiTro == 4)
            {
                for (int i = 0; i < khoaList.Count; i++)
                {
                    GiangVienDTO gv = GiangVienBUS.GetGiangVienById(nguoiDungId);
                    if (gv.KhoaId == khoaList[i].Id && gv.Status == 1 && khoaList[i].status == 1)
                    {
                        data1.Add(khoaList[i].TenKhoa);
                        LoadLopTheoCoVan(gv.Id);
                        break;
                    }

                }

                cbKhoa.AutoCompleteCustomSource = data1;
                cbKhoa.DataSource = data1;
                cbKhoa.SelectedIndex = 0;
                LoadLopTheoKhoa();
            }
            else
            {
                for (int i = 0; i < khoaList.Count; i++)
                {
                    data1.Add(khoaList[i].TenKhoa);

                }

                cbKhoa.AutoCompleteCustomSource = data1;
                cbKhoa.DataSource = data1;
                cbKhoa.SelectedIndex = -1;
            }

            cbKhoa.SelectedIndexChanged += (s, e) =>
            {
                LoadLopTheoKhoa();

            };
            cbLop.SelectedIndexChanged += (s, e) =>
            {
                LoadSinhVienTheoLop();
            };
            cbSinhvien.SelectedIndexChanged += (s, e) =>
            {
                // Kiểm tra nếu một sinh viên được chọn
                if (cbSinhvien.SelectedItem is ComboBoxItem selectedItem)
                {
                    var selectedStudent = sinhvienList.FirstOrDefault(sv => sv.Id == selectedItem.Id);

                    if (selectedStudent != null)
                    {
                        lbTen.Text = selectedStudent.Name;
                        lbMssv.Text = selectedStudent.Id.ToString();
                        DiemRenLuyenSinhVienDTO drl = DiemRenLuyenSinhVienDAO.GetDiemRenLuyenBySinhVienIdAndHocKiId(selectedStudent.Id, this.hockiId);
                        if (drl != null)
                        {
                            lbXepHang.Text = drl.Comments;
                            lbDiem.Text = drl.Score.ToString();
                            lbXepHang.Text = drl.Comments;
                        }
                        else
                        {
                            lbXepHang.Text = "";
                            lbDiem.Text = "";
                            lbXepHang.Text = "";
                        }
                    }
                    else
                    {
                        lbXepHang.Text = "";
                        lbDiem.Text = "";
                        lbXepHang.Text = "";
                    }

                    LoadData();

                }
                else
                {
                    // Xóa nội dung các label nếu không có sinh viên nào được chọn
                    EmptyInforLabel();
                }
            };
            LoadHocKyToComboBox();

            IfRoleIsSinhvien(vaiTro, nguoiDungId);
        }

        private DataTable ConvertToDataTableChamDiem(List<TieuChiDanhGiaDTO> tieuChiList)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("STT", typeof(string));
            dataTable.Columns.Add("Nội dung tiêu chí đánh giá", typeof(string));
            dataTable.Columns.Add("Điểm tối đa", typeof(string));
            dataTable.Columns.Add("Điểm SV tự đánh giá", typeof(string));
            dataTable.Columns.Add("Điểm CVHT", typeof(string));
            dataTable.Columns.Add("Điểm khoa", typeof(string));
            dataTable.Columns.Add("Điểm trường", typeof(string));
            //dataTable.Columns.Add("Ghi chú", typeof(string));

            // Tạo Dictionary để theo dõi STT cha - con
            Dictionary<long, int> childCountByParent = new Dictionary<long, int>();
            Dictionary<long, string> parentToRoman = new Dictionary<long, string>();
            foreach (var item in tieuChiList)
            {
                DataRow row = dataTable.NewRow();

                string stt = GetSTT(item.Id, item.ParentId, childCountByParent, parentToRoman);

                // Lưu STT và Id vào Dictionary
                sttToId[stt] = item.Id;

                // Kiểm tra nếu có chú thích thì thêm dấu "?"
                List<ChuThichTieuChiDTO> chuThichList = ChuThichTieuChiBUS.GetChuThichByTieuChiId(item.Id);
                string noiDung = chuThichList.Any() ? $"{item.Name} (?)" : item.Name;

                int diemMax = item.DiemMax;
                if (diemMax == 0)
                {
                    // Lấy điểm cao nhất từ tập con
                    int maxDiem = chuThichList.Any() ? chuThichList.Max(ct => ct.Diem) : 0;
                    diemMax = maxDiem > 0 ? maxDiem : 0; // Nếu cao nhất là âm, đặt = 0
                }



                if (vaiTro == 1)
                {
                    row["STT"] = stt;
                    row["Nội dung tiêu chí đánh giá"] = noiDung;
                    row["Điểm tối đa"] = diemMax;
                    row["Điểm SV tự đánh giá"] = string.Empty;
                    row["Điểm CVHT"] = string.Empty;
                    row["Điểm khoa"] = string.Empty;
                    row["Điểm trường"] = string.Empty;
                    //row["Ghi chú"] = string.Empty;
                }
                else if (vaiTro == 3)
                {
                    long svId = long.Parse(lbMssv.Text.ToString());
                    int? diemSV = ChiTietDotChamDAO.GetDiem(sinhVienID: svId, tieuChiDanhGiaID: item.Id, dotchamdiemID: DotChamDiemBUS.GetIdVoiHocKyVaName(this.hockiId, "Sinh viên"));
                    row["STT"] = stt;
                    row["Nội dung tiêu chí đánh giá"] = noiDung;
                    row["Điểm tối đa"] = diemMax;
                    row["Điểm SV tự đánh giá"] = diemSV.HasValue ? diemSV.Value.ToString() : string.Empty;
                    row["Điểm CVHT"] = string.Empty;
                    row["Điểm khoa"] = string.Empty;
                    row["Điểm trường"] = string.Empty;
                    //row["Ghi chú"] = string.Empty;
                }
                else if (vaiTro == 4)
                {
                    long svId = long.Parse(lbMssv.Text.ToString());
                    int? diemSV = ChiTietDotChamDAO.GetDiem(sinhVienID: svId, tieuChiDanhGiaID: item.Id, dotchamdiemID: DotChamDiemBUS.GetIdVoiHocKyVaName(this.hockiId, "Sinh viên"));
                    int? diemCV = ChiTietDotChamDAO.GetDiem(sinhVienID: svId, tieuChiDanhGiaID: item.Id, dotchamdiemID: DotChamDiemBUS.GetIdVoiHocKyVaName(this.hockiId, "Cố vấn"), coVanID: this.covanId);
                    row["STT"] = stt;
                    row["Nội dung tiêu chí đánh giá"] = noiDung;
                    row["Điểm tối đa"] = diemMax;
                    row["Điểm SV tự đánh giá"] = diemSV.HasValue ? diemSV.Value.ToString() : string.Empty;
                    row["Điểm CVHT"] = diemCV.HasValue ? diemCV.Value.ToString() : string.Empty;
                    row["Điểm khoa"] = string.Empty;
                    row["Điểm trường"] = string.Empty;
                    //row["Ghi chú"] = string.Empty;
                }
                else if (vaiTro == 5)
                {
                    long svId = long.Parse(lbMssv.Text.ToString());
                    int? diemSV = ChiTietDotChamDAO.GetDiem(sinhVienID: svId, tieuChiDanhGiaID: item.Id, dotchamdiemID: DotChamDiemBUS.GetIdVoiHocKyVaName(this.hockiId, "Sinh viên"));
                    int? diemCV = ChiTietDotChamDAO.GetDiem(sinhVienID: svId, tieuChiDanhGiaID: item.Id, dotchamdiemID: DotChamDiemBUS.GetIdVoiHocKyVaName(this.hockiId, "Cố vấn"), coVanID: this.covanId);
                    int? diemK = ChiTietDotChamDAO.GetDiem(sinhVienID: svId, tieuChiDanhGiaID: item.Id, dotchamdiemID: DotChamDiemBUS.GetIdVoiHocKyVaName(this.hockiId, "Khoa"), khoaID: this.khoaId);
                    row["STT"] = stt;
                    row["Nội dung tiêu chí đánh giá"] = noiDung;
                    row["Điểm tối đa"] = diemMax;
                    row["Điểm SV tự đánh giá"] = diemSV.HasValue ? diemSV.Value.ToString() : string.Empty;
                    row["Điểm CVHT"] = diemCV.HasValue ? diemCV.Value.ToString() : string.Empty;
                    row["Điểm khoa"] = diemK.HasValue ? diemK.Value.ToString() : string.Empty;
                    row["Điểm trường"] = string.Empty;
                    //row["Ghi chú"] = string.Empty;
                }

                dataTable.Rows.Add(row);


            }
            if (vaiTro == 1)
                SetupDataGridView(dataGridView1, dataTable);
            else
            {
                SetupDataGridView2(dataGridView1, dataTable);
            }

            return dataTable;
        }


        private DataTable ConvertToDataTableXemDiem(List<TieuChiDanhGiaDTO> tieuChiList)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("STT", typeof(string));
            dataTable.Columns.Add("Nội dung tiêu chí đánh giá", typeof(string));
            dataTable.Columns.Add("Điểm tối đa", typeof(string));
            dataTable.Columns.Add("Điểm SV tự đánh giá", typeof(string));
            dataTable.Columns.Add("Điểm CVHT", typeof(string));
            dataTable.Columns.Add("Điểm khoa", typeof(string));
            dataTable.Columns.Add("Điểm trường", typeof(string));
            //dataTable.Columns.Add("Ghi chú", typeof(string));

            // Tạo Dictionary để theo dõi STT cha - con
            Dictionary<long, int> childCountByParent = new Dictionary<long, int>();
            Dictionary<long, string> parentToRoman = new Dictionary<long, string>();
            foreach (var item in tieuChiList)
            {
                DataRow row = dataTable.NewRow();

                string stt = GetSTT(item.Id, item.ParentId, childCountByParent, parentToRoman);

                // Lưu STT và Id vào Dictionary
                sttToId[stt] = item.Id;

                // Kiểm tra nếu có chú thích thì thêm dấu "?"
                List<ChuThichTieuChiDTO> chuThichList = ChuThichTieuChiBUS.GetChuThichByTieuChiId(item.Id);
                string noiDung = chuThichList.Any() ? $"{item.Name} (?)" : item.Name;

                int diemMax = item.DiemMax;
                if (diemMax == 0)
                {
                    // Lấy điểm cao nhất từ tập con
                    int maxDiem = chuThichList.Any() ? chuThichList.Max(ct => ct.Diem) : 0;
                    diemMax = maxDiem > 0 ? maxDiem : 0; // Nếu cao nhất là âm, đặt = 0
                }

                long svId = long.Parse(lbMssv.Text.ToString());
                SinhVienDTO sv = SinhVienBUS.GetStudentById(svId);
                LopDTO lop = LopBUS.GetLopByID(sv.LopId);
                int? diemSV = ChiTietDotChamDAO.GetDiem(sinhVienID: svId, tieuChiDanhGiaID: item.Id, dotchamdiemID: DotChamDiemBUS.GetIdVoiHocKyVaName(this.hockiId, "Sinh viên"));
                int? diemCV = ChiTietDotChamDAO.GetDiem(sinhVienID: svId, tieuChiDanhGiaID: item.Id, dotchamdiemID: DotChamDiemBUS.GetIdVoiHocKyVaName(this.hockiId, "Cố vấn"), coVanID: lop.CoVanId);
                int? diemK = ChiTietDotChamDAO.GetDiem(sinhVienID: svId, tieuChiDanhGiaID: item.Id, dotchamdiemID: DotChamDiemBUS.GetIdVoiHocKyVaName(this.hockiId, "Khoa"), khoaID: lop.Khoa.Id);
                int? diemT = ChiTietDotChamDAO.GetDiem(sinhVienID: svId, tieuChiDanhGiaID: item.Id, dotchamdiemID: DotChamDiemBUS.GetIdVoiHocKyVaName(this.hockiId, "Trường"), final: 1);
                row["STT"] = stt;
                row["Nội dung tiêu chí đánh giá"] = noiDung;
                row["Điểm tối đa"] = diemMax;
                row["Điểm SV tự đánh giá"] = diemSV.HasValue ? diemSV.Value.ToString() : string.Empty;
                row["Điểm CVHT"] = diemCV.HasValue ? diemCV.Value.ToString() : string.Empty;
                row["Điểm khoa"] = diemK.HasValue ? diemK.Value.ToString() : string.Empty;
                row["Điểm trường"] = diemT.HasValue ? diemT.Value.ToString() : string.Empty;


                dataTable.Rows.Add(row);
            }

            SetupDataGridView2(dataGridView1, dataTable);


            return dataTable;
        }

        //private DataTable ConvertToDataTableXemDiem(List<TieuChiDanhGiaDTO> tieuChiList)
        //{
        //    DataTable dataTable = new DataTable();
        //    dataTable.Columns.Add("STT", typeof(string));
        //    dataTable.Columns.Add("Nội dung tiêu chí đánh giá", typeof(string));
        //    dataTable.Columns.Add("Điểm tối đa", typeof(string));
        //    dataTable.Columns.Add("Điểm SV tự đánh giá", typeof(string));
        //    dataTable.Columns.Add("Điểm CVHT", typeof(string));
        //    dataTable.Columns.Add("Điểm khoa", typeof(string));
        //    dataTable.Columns.Add("Điểm trường", typeof(string));
        //    //dataTable.Columns.Add("Ghi chú", typeof(string));

        //    // Tạo Dictionary để theo dõi STT cha - con
        //    Dictionary<long, int> childCountByParent = new Dictionary<long, int>();
        //    Dictionary<long, string> parentToRoman = new Dictionary<long, string>();

        //    foreach (var item in tieuChiList)
        //    {
        //        DataRow row = dataTable.NewRow();

        //        string stt = GetSTT(item.Id, item.ParentId, childCountByParent, parentToRoman);

        //        // Lưu STT và Id vào Dictionary
        //        sttToId[stt] = item.Id;

        //        // Kiểm tra nếu có chú thích thì thêm dấu "?"
        //        List<ChuThichTieuChiDTO> chuThichList = ChuThichTieuChiBUS.GetChuThichByTieuChiId(item.Id);
        //        string noiDung = chuThichList.Any() ? $"{item.Name} (?)" : item.Name;

        //        int diemMax = item.DiemMax;
        //        if (diemMax == 0)
        //        {
        //            // Lấy điểm cao nhất từ tập con
        //            int maxDiem = chuThichList.Any() ? chuThichList.Max(ct => ct.Diem) : 0;
        //            diemMax = maxDiem > 0 ? maxDiem : 0; // Nếu cao nhất là âm, đặt = 0
        //        }

        //        if (vaiTro == 1)
        //        {
        //            int? diemSV = ChiTietDotChamDAO.GetDiem(sinhVienID: nguoiDungId, tieuChiDanhGiaID: item.Id, dotchamdiemID: dotchamdiemId);
        //            row["STT"] = stt;
        //            row["Nội dung tiêu chí đánh giá"] = noiDung;
        //            row["Điểm tối đa"] = diemMax;
        //            row["Điểm SV tự đánh giá"] = diemSV.HasValue ? diemSV.Value.ToString() : string.Empty;
        //            row["Điểm CVHT"] = string.Empty;
        //            row["Điểm khoa"] = string.Empty;
        //            row["Điểm trường"] = string.Empty;
        //            row["Ghi chú"] = string.Empty;
        //        }
        //        else if (vaiTro == 3)
        //        {
        //            long svId = long.Parse(lbMssv.Text.ToString());
        //            int? diemSV = ChiTietDotChamDAO.GetDiem(sinhVienID: svId, tieuChiDanhGiaID: item.Id, dotchamdiemID: DotChamDiemBUS.GetIdVoiHocKyVaName(this.hockiId, "Sinh viên"));
        //            int? diemCV = ChiTietDotChamDAO.GetDiem(sinhVienID: svId, tieuChiDanhGiaID: item.Id, dotchamdiemID: dotchamdiemId, coVanID: nguoiDungId);
        //            row["STT"] = stt;
        //            row["Nội dung tiêu chí đánh giá"] = noiDung;
        //            row["Điểm tối đa"] = diemMax;
        //            row["Điểm SV tự đánh giá"] = diemSV.HasValue ? diemSV.Value.ToString() : string.Empty;
        //            row["Điểm CVHT"] = diemCV.HasValue ? diemCV.Value.ToString() : string.Empty;
        //            row["Điểm khoa"] = string.Empty;
        //            row["Điểm trường"] = string.Empty;
        //            row["Ghi chú"] = string.Empty;
        //        }
        //        else if (vaiTro == 4)
        //        {
        //            int? diemSV = ChiTietDotChamDAO.GetDiem(sinhVienID: nguoiDungId, tieuChiDanhGiaID: item.Id, dotchamdiemID: DotChamDiemBUS.GetIdVoiHocKyVaName(this.hockiId, "Sinh viên"));
        //            int? diemCV = ChiTietDotChamDAO.GetDiem(sinhVienID: nguoiDungId, tieuChiDanhGiaID: item.Id, dotchamdiemID: DotChamDiemBUS.GetIdVoiHocKyVaName(this.hockiId, "Cố vấn"), coVanID: 1);
        //            int? diemK = ChiTietDotChamDAO.GetDiem(sinhVienID: nguoiDungId, tieuChiDanhGiaID: item.Id, dotchamdiemID: dotchamdiemId, khoaID: 1);
        //            row["STT"] = stt;
        //            row["Nội dung tiêu chí đánh giá"] = noiDung;
        //            row["Điểm tối đa"] = diemMax;
        //            row["Điểm SV tự đánh giá"] = diemSV.HasValue ? diemSV.Value.ToString() : string.Empty;
        //            row["Điểm CVHT"] = string.Empty;
        //            row["Điểm khoa"] = string.Empty;
        //            row["Điểm trường"] = string.Empty;
        //            row["Điểm CVHT"] = diemCV.HasValue ? diemCV.Value.ToString() : string.Empty;
        //            row["Điểm khoa"] = diemK.HasValue ? diemK.Value.ToString() : string.Empty;
        //            row["Điểm trường"] = string.Empty;
        //            row["Ghi chú"] = string.Empty;
        //        }
        //        else if (vaiTro == 5)
        //        {
        //            int? diemT = ChiTietDotChamDAO.GetDiem(sinhVienID: nguoiDungId, tieuChiDanhGiaID: item.Id, dotchamdiemID: 2, final: 1);
        //            int? diemSV = ChiTietDotChamDAO.GetDiem(sinhVienID: nguoiDungId, tieuChiDanhGiaID: item.Id, dotchamdiemID: dotchamdiemId);
        //            int? diemCV = ChiTietDotChamDAO.GetDiem(sinhVienID: nguoiDungId, tieuChiDanhGiaID: item.Id, dotchamdiemID: 4, coVanID: 1);
        //            int? diemK = ChiTietDotChamDAO.GetDiem(sinhVienID: nguoiDungId, tieuChiDanhGiaID: item.Id, dotchamdiemID: 1, khoaID: 1);
        //            row["STT"] = stt;
        //            row["Nội dung tiêu chí đánh giá"] = noiDung;
        //            row["Điểm tối đa"] = diemMax;
        //            row["Điểm SV tự đánh giá"] = diemSV.HasValue ? diemSV.Value.ToString() : string.Empty;
        //            row["Điểm CVHT"] = string.Empty;
        //            row["Điểm khoa"] = string.Empty;
        //            row["Điểm trường"] = string.Empty;
        //            row["Điểm CVHT"] = diemCV.HasValue ? diemCV.Value.ToString() : string.Empty;
        //            row["Điểm khoa"] = diemK.HasValue ? diemK.Value.ToString() : string.Empty;
        //            row["Điểm trường"] = diemT.HasValue ? diemT.Value.ToString() : string.Empty;
        //            row["Ghi chú"] = string.Empty;
        //        }

        //        dataTable.Rows.Add(row);
        //    }

        //    return dataTable;
        //}

        private void SetupDataGridView(DataGridView dgv, DataTable dataTable)
        {
            // Đặt lại DataSource cho DataGridView
            dgv.DataSource = dataTable;

            // Xóa cột ghi chú nếu đã tồn tại
            if (dgv.Columns.Contains("GhiChuButton"))
            {
                dgv.Columns.Remove("GhiChuButton");
            }

            // Xóa cột ImagePath nếu đã tồn tại
            if (dgv.Columns.Contains("ImagePath"))
            {
                dgv.Columns.Remove("ImagePath");
            }

            // Xóa cột Mota nếu đã tồn tại
            if (dgv.Columns.Contains("Mota"))
            {
                dgv.Columns.Remove("Mota");
            }

            // Thêm cột nút vào DataGridView
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn
            {
                Name = "GhiChuButton",
                HeaderText = "Ghi chú",
                Text = "Chi tiết",
                UseColumnTextForButtonValue = true, // Hiển thị text lên nút
            };
            dgv.Columns.Add(buttonColumn);

            // Thêm cột ẩn để lưu trữ đường dẫn ảnh hoặc ID
            DataGridViewTextBoxColumn imageColumn = new DataGridViewTextBoxColumn
            {
                Name = "ImagePath", // Cột lưu thông tin ảnh (ví dụ đường dẫn hoặc ID ảnh)
                Visible = false // Cột này sẽ không hiển thị
            };
            dgv.Columns.Add(imageColumn);

            // Thêm cột ẩn để lưu trữ thông tin mô tả
            DataGridViewTextBoxColumn motaColumn = new DataGridViewTextBoxColumn
            {
                Name = "Mota", // Cột lưu thông tin mô tả
                Visible = false // Cột này sẽ không hiển thị
            };
            dgv.Columns.Add(motaColumn);

            // Kiểm tra giá trị trong cột STT và ẩn nút "Chi tiết" nếu STT là số nguyên
            dgv.CellPainting += (sender, e) =>
            {
                if (e.ColumnIndex == dgv.Columns["GhiChuButton"].Index && e.RowIndex >= 0)
                {
                    var sttValue = dgv.Rows[e.RowIndex].Cells["STT"].Value;
                    if (sttValue != null && int.TryParse(sttValue.ToString(), out _))
                    {
                        // Nếu STT là số nguyên, không vẽ nút
                        e.PaintBackground(e.ClipBounds, true);
                        e.Handled = true;
                    }
                }
            };

            // Đăng ký sự kiện Click cho DataGridView
            dgv.CellContentClick += DataGridView_CellContentClick;
        }


        private void SetupDataGridView2(DataGridView dgv, DataTable dataTable)
        {
            // Gán lại DataSource
            dgv.DataSource = dataTable;

            // Xóa các cột cũ nếu đã tồn tại
            if (dgv.Columns.Contains("GhiChuButton"))
            {
                dgv.Columns.Remove("GhiChuButton");
            }
            if (dgv.Columns.Contains("ImagePath"))
            {
                dgv.Columns.Remove("ImagePath");
            }
            if (dgv.Columns.Contains("Mota"))
            {
                dgv.Columns.Remove("Mota");
            }

            // Thêm cột nút vào DataGridView
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn
            {
                Name = "GhiChuButton",
                HeaderText = "Ghi chú",
                Text = "Chi tiết",
                UseColumnTextForButtonValue = true, // Hiển thị text lên nút
            };
            dgv.Columns.Add(buttonColumn);

            // Thêm cột ẩn để lưu trữ đường dẫn ảnh hoặc ID
            DataGridViewTextBoxColumn imageColumn = new DataGridViewTextBoxColumn
            {
                Name = "ImagePath", // Cột lưu thông tin ảnh (ví dụ đường dẫn hoặc ID ảnh)
                Visible = false // Cột này sẽ không hiển thị
            };
            dgv.Columns.Add(imageColumn);

            // Thêm cột ẩn để lưu trữ thông tin mô tả
            DataGridViewTextBoxColumn motaColumn = new DataGridViewTextBoxColumn
            {
                Name = "Mota", // Cột lưu thông tin mô tả
                Visible = false // Cột này sẽ không hiển thị
            };
            dgv.Columns.Add(motaColumn);

            // Tiền xử lý thông tin dữ liệu để tránh truy vấn lặp lại trong CellPainting
            PreprocessDetails(dgv);

            // Gỡ bỏ các sự kiện cũ để tránh đăng ký lại nhiều lần
            dgv.CellPainting -= DataGridView_CellPainting;
            dgv.CellContentClick -= DataGridView_CellContentClick;

            // Kiểm tra giá trị trong cột STT và thay đổi giao diện nút
            dgv.CellPainting += DataGridView_CellPainting;

            // Đăng ký sự kiện Click cho DataGridView
            dgv.CellContentClick += DataGridView_CellContentClick;
        }

        // Xử lý sự kiện CellPainting riêng biệt
        private void DataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv == null) return;

            if (e.ColumnIndex == dgv.Columns["GhiChuButton"].Index && e.RowIndex >= 0)
            {
                var hasDetails = dgv.Rows[e.RowIndex].Cells["ImagePath"].Value != null;
                if (!hasDetails)
                {
                    // Nếu không có thông tin, không hiển thị nút
                    e.PaintBackground(e.ClipBounds, true);
                    e.Handled = true;
                }
            }
        }


        private void PreprocessDetails(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                // Bỏ qua hàng cuối cùng nếu đó là hàng mới
                if (row.IsNewRow)
                    continue;

                string stt = row.Cells["STT"].Value?.ToString();
                if (!long.TryParse(stt, out long parsedStt))
                {
                    long svId = long.Parse(lbMssv.Text); // ID sinh viên
                    long id = GetOriginalId(stt, sttToId); // ID dữ liệu
                    var (imageUrl, mota) = ChiTietDotChamDAO.GetBangChung(
                        svId,
                        id,
                        DotChamDiemBUS.GetIdVoiHocKyVaName(this.hockiId, "Sinh viên")
                    );

                    if (!string.IsNullOrEmpty(imageUrl) || !string.IsNullOrEmpty(mota))
                    {
                        row.Cells["ImagePath"].Value = imageUrl;
                        row.Cells["Mota"].Value = mota;
                        row.Cells["GhiChuButton"].Style = new DataGridViewCellStyle { BackColor = Color.LightBlue }; // Nút có thông tin
                    }
                }
            }
        }



        private List<ImageData> imageList = new List<ImageData>(); // Danh sách lưu thông tin ảnh

        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra cột là cột nút "Ghi chú"
            if (e.ColumnIndex == ((DataGridView)sender).Columns["GhiChuButton"].Index)
            {
                int rowIndex = e.RowIndex;
                if (rowIndex >= 0)
                {
                    // Lấy thông tin hàng hiện tại
                    DataGridViewRow row = ((DataGridView)sender).Rows[rowIndex];

                    // Lấy thông tin từ các cột
                    string tentieuchi = row.Cells["Nội dung tiêu chí đánh giá"].Value?.ToString();
                    string stt = row.Cells["STT"].Value?.ToString();
                    string mota = row.Cells["Mota"].Value?.ToString();

                    // Mở form ThongTinBangChung để chọn ảnh
                    long id = GetOriginalId(stt, sttToId);

                    string image = null;
                    // Kiểm tra nếu cột "ImagePath" không rỗng
                    if (row.Cells["ImagePath"].Value != DBNull.Value && row.Cells["ImagePath"].Value != null)
                    {
                        // Chuyển byte array từ ImagePath thành ảnh
                        image = row.Cells["ImagePath"].Value?.ToString();
                    }

                    // Tạo loading animation
                    var loading = Loading.CreateLoadingControl(this);
                    Helper.Loading.ShowLoading(loading);

                    // Khởi tạo đối tượng ThongTinBangChung
                    ThongTinBangChung ttbc = null;

                    // Chạy tác vụ nặng trong Task để không khóa giao diện
                    Task.Run(() =>
                    {
                        if (this.action == "Chấm")
                            ttbc = new ThongTinBangChung(id, tentieuchi, image, mota, vaiTro);
                        else
                            ttbc = new ThongTinBangChung(id, tentieuchi, image, mota, 3);
                        // Cập nhật giao diện phải thực hiện trên UI thread
                        this.Invoke(new Action(() =>
                        {
                            Loading.HideLoading(loading); // Ẩn loading
                        }));
                    }).ContinueWith((t) =>
                    {
                        // Kiểm tra nếu đối tượng ThongTinBangChung đã sẵn sàng
                        if (ttbc != null && ttbc.ShowDialog() == DialogResult.OK)
                        {
                            // Lấy ảnh và STT khi người dùng nhấn OK
                            if (ttbc.SelectedImageUrl != null)
                            {
                                ImageData imageData = new ImageData(id, ttbc.SelectedImageUrl, ttbc.Mota);
                                imageList.Add(imageData); // Lưu vào danh sách

                                // Kiểm tra nếu cột "ImagePath" chưa có thì tạo nó
                                if (!((DataGridView)sender).Columns.Contains("ImagePath"))
                                {
                                    DataGridViewTextBoxColumn imageColumn = new DataGridViewTextBoxColumn();
                                    imageColumn.Name = "ImagePath";
                                    imageColumn.HeaderText = "Ảnh";
                                    ((DataGridView)sender).Columns.Add(imageColumn);
                                }

                                // Chuyển ảnh thành byte array và lưu vào cột ImagePath
                                row.Cells["ImagePath"].Value = ttbc.SelectedImageUrl;
                            }
                            else
                            {
                                row.Cells["ImagePath"].Value = string.Empty;
                            }

                            // Lấy ảnh và STT khi người dùng nhấn OK
                            if (ttbc.Mota != null && ttbc.Mota != "")
                            {
                                row.Cells["Mota"].Value = ttbc.Mota;
                            }
                            else
                            {
                                row.Cells["Mota"].Value = string.Empty;
                            }
                        }
                    }, TaskScheduler.FromCurrentSynchronizationContext()); // Ensures the continuation runs on the UI thread
                }
            }
        }



        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Png); // Lưu ảnh vào MemoryStream dưới định dạng PNG
                return ms.ToArray(); // Trả về mảng byte
            }
        }

        private Image ByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms); // Chuyển mảng byte về Image
            }
        }

        private byte[] DownloadImageAsBytes(string imageUrl)
        {
            using (WebClient client = new WebClient())
            {
                return client.DownloadData(imageUrl);
            }
        }



        private string GetSTT(long id, long? parentId, Dictionary<long, int> childCountByParent, Dictionary<long, string> parentToRoman)
        {
            if (parentId == null || parentId == 0)
            {
                // Nếu là mục cha, tăng số thứ tự
                int romanIndex = parentToRoman.Count + 1;
                string roman = romanIndex.ToString(); // Số thứ tự cho mục cha là số nguyên
                parentToRoman[id] = roman;
                childCountByParent[id] = 0; // Khởi tạo bộ đếm con cho mục cha
                return roman;
            }
            else
            {
                // Nếu là mục con, kiểm tra và khởi tạo bộ đếm
                if (!childCountByParent.ContainsKey(parentId.Value))
                {
                    childCountByParent[parentId.Value] = 0; // Khởi tạo nếu chưa tồn tại
                }
                childCountByParent[parentId.Value]++;
                return $"{parentToRoman[parentId.Value]}.{childCountByParent[parentId.Value]}";
            }
        }




        // Phương thức để lấy Id gốc từ STT
        private long GetOriginalId(string stt, Dictionary<string, long> sttToId)
        {
            if (sttToId.ContainsKey(stt))
            {
                return sttToId[stt];
            }
            throw new Exception("STT không tồn tại!");
        }



        private void LoadLopTheoKhoa()
        {
            string tenkhoa = (string)cbKhoa.SelectedItem;
            cbLop.Items.Clear();
            cbSinhvien.Items.Clear();
            cbLop.SelectedIndex = -1;
            cbSinhvien.SelectedIndex = -1;
            EmptyInforLabel();
            if (cbKhoa.SelectedIndex != -1)
            {
                long khoaId = 0;

                // Tìm khoaId dựa trên tên khoa
                for (int i = 0; i < khoaList.Count; i++)
                {
                    if (khoaList[i].TenKhoa == tenkhoa && khoaList[i].status == 1)
                    {
                        khoaId = khoaList[i].Id;
                        this.khoaId = khoaId;
                        break;
                    }
                }
                // Lọc và thêm các lớp vào ComboBox cbLop dựa trên khoaId
                for (int i = 0; i < lopList.Count; i++)
                {
                    if (lopList[i].Khoa.Id == khoaId && lopList[i].status == 1)
                    {
                        cbLop.Items.Add(lopList[i].TenLop);

                    }
                }
            }
        }

        private void LoadLopTheoCoVan(long covanId)
        {
            // Xóa thông tin cũ trong các ComboBox
            cbLop.Items.Clear();
            cbSinhvien.Items.Clear();
            cbLop.SelectedIndex = -1;
            cbSinhvien.SelectedIndex = -1;
            EmptyInforLabel();

            List<LopDTO> list = LopDAO.GetLopByCoVanID(covanId);

            for (int i = 0; i < list.Count; i++)
            {
                cbLop.Items.Add(list[i].TenLop);
            }

        }


        private void LoadSinhVienTheoLop()
        {
            string tenlop = (string)cbLop.SelectedItem;
            cbSinhvien.Items.Clear();
            cbSinhvien.SelectedIndex = -1;
            EmptyInforLabel();
            if (cbKhoa.SelectedIndex != -1)
            {
                long lopId = 0;

                // Tìm lopId dựa trên tên lớp
                for (int i = 0; i < lopList.Count; i++)
                {
                    if (lopList[i].TenLop == tenlop)
                    {
                        lopId = lopList[i].Id; // Sử dụng Id của lớp thay vì vị trí
                        covanId = lopList[i].CoVanId ?? 0;
                        break;
                    }
                }


                // Lọc và thêm các sinh viên vào ComboBox cbSinhvien dựa trên lopId
                for (int i = 0; i < sinhvienList.Count; i++)
                {
                    if (sinhvienList[i].LopId == lopId && sinhvienList[i].status == 1)
                    {
                        // Tạo đối tượng ComboBoxItem chứa Name và Id của sinh viên
                        var item = new ComboBoxItem
                        {
                            Name = sinhvienList[i].Name,
                            Id = sinhvienList[i].Id
                        };
                        cbSinhvien.Items.Add(item);
                    }
                }
            }
        }
        private void LoadHocKyToComboBox()
        {
            // Lấy danh sách học kỳ từ BUS
            List<HocKyDTO> hockyList = HocKyBUS.GetAllHocKy();

            // Gắn dữ liệu vào ComboBox
            cbHocKy.DisplayMember = "DisplayText"; // Hiển thị text theo format
            cbHocKy.ValueMember = "Id";           // Gắn Id vào Value
            cbHocKy.DataSource = hockyList.Select(hk => new
            {
                Id = hk.Id,
                DisplayText = $"Học kỳ {hk.Name} năm học {hk.namhoc} - {hk.namhoc + 1}"
            }).ToList();
            cbHocKy.SelectedIndex = -1;
        }

        private class ComboBoxItem
        {
            public string Name { get; set; }
            public long Id { get; set; }

            public override string ToString()
            {
                return Name; // Chỉ hiển thị tên sinh viên trong ComboBox
            }
        }
        private void EmptyInforLabel()
        {
            lbTen.Text = string.Empty;
            lbMssv.Text = string.Empty;
            lbDiem.Text = string.Empty;
            lbXepHang.Text = string.Empty;
        }

        private void dataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // Kiểm tra nếu ô đang được chỉnh sửa thuộc cột 4 hoặc 5
            if (dataGridView1.CurrentCell.ColumnIndex == 3 ||
                dataGridView1.CurrentCell.ColumnIndex == 4 ||
                dataGridView1.CurrentCell.ColumnIndex == 5 ||
                dataGridView1.CurrentCell.ColumnIndex == 6)
            {
                // Xóa các sự kiện KeyPress trước đó để tránh việc xử lý nhiều lần
                e.Control.KeyPress -= OnlyAllowNumbers;

                // Thêm sự kiện KeyPress cho ô chỉ cho phép nhập số
                e.Control.KeyPress += OnlyAllowNumbers;
            }
            else
            {
                // Gỡ sự kiện nếu không phải cột 4 hoặc 5
                e.Control.KeyPress -= OnlyAllowNumbers;
            }
        }

        // Hàm chỉ cho phép nhập số
        private void OnlyAllowNumbers(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra nếu ký tự là dấu âm
            if (e.KeyChar == '-')
            {
                // Chỉ cho phép nhập dấu âm nếu là ký tự đầu tiên
                DataGridViewTextBoxEditingControl textBox = (DataGridViewTextBoxEditingControl)sender;
                if (textBox.Text.Length > 0 || textBox.SelectionLength > 0) // Nếu có văn bản hoặc đang chỉnh sửa
                {
                    e.Handled = true; // Chặn việc nhập dấu âm
                }
            }
            // Kiểm tra nếu ký tự không phải là số và không phải phím backspace
            else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Chặn ký tự không hợp lệ
            }
        }


        private void CustomizeRowAppearance()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["STT"].Value != null)
                {
                    string stt = row.Cells["STT"].Value.ToString();

                    // Các hàng có STT là số nguyên (1, 2, 3,...)
                    if (int.TryParse(stt, out _))
                    {
                        row.DefaultCellStyle.BackColor = Color.LightBlue;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                        row.DefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);
                        row.Cells["Điểm SV tự đánh giá"].ReadOnly = true;
                        row.Cells["Điểm CVHT"].ReadOnly = true;
                        row.Cells["Điểm khoa"].ReadOnly = true;
                        row.Cells["Điểm trường"].ReadOnly = true;
                    }
                }
            }
        }

        private void dgvTieuChi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu là cột "Nội dung tiêu chí đánh giá" và có dấu "?"
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["Nội dung tiêu chí đánh giá"].Index)
            {
                // Lấy nội dung của ô "Nội dung tiêu chí đánh giá"
                string content = dataGridView1.Rows[e.RowIndex].Cells["Nội dung tiêu chí đánh giá"].Value.ToString();

                // Kiểm tra xem có dấu "?" trong nội dung hay không
                if (content.Contains("?"))
                {
                    // Lấy STT từ cột "STT"
                    string stt = dataGridView1.Rows[e.RowIndex].Cells["STT"].Value.ToString();

                    try
                    {
                        // Lấy ID gốc từ STT
                        long originalId = GetOriginalId(stt, sttToId);

                        // Hiển thị ghi chú liên quan đến originalId hoặc thực hiện hành động khác
                        //ShowNotesForId(originalId, e.RowIndex, e.ColumnIndex);

                        var notes = GetNotesByTieuChiId(originalId);
                        string noteText = string.Join("\n", notes);
                        //toolTip.Show(noteText, dataGridView1,
                        //dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Location,
                        //50000); // Hiển thị 5 giây
                        MessageBox.Show(noteText, "Ghi chú", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ShowNotesForId(long originalId, int rowIndex, int columnIndex)
        {
            // Lấy dữ liệu ghi chú từ Id (hoặc từ cơ sở dữ liệu)
            var notes = GetNotesByTieuChiId(originalId);
            string noteText = string.Join("\n", notes);

            // Sử dụng ToolTip để hiển thị ghi chú
            System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
            toolTip.SetToolTip(dataGridView1, noteText);
            toolTip.Show(noteText, dataGridView1, dataGridView1.GetCellDisplayRectangle(columnIndex, rowIndex, true).Location);
        }

        private List<string> GetNotesByTieuChiId(long originalId)
        {
            // Lấy dữ liệu ghi chú từ ChuThichTieuChiDTO
            List<string> notes = new List<string>();

            // Giả sử bạn đã có danh sách `ChuThichTieuChiDTO`
            var noteItems = ChuThichTieuChiBUS.GetChuThichByTieuChiId(originalId);

            foreach (var item in noteItems)
            {
                string note = $"{item.Name}: {item.Diem}đ";
                notes.Add(note);
            }

            return notes;
        }
        private void dgvTieuChi_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            // Không cần thực hiện gì đặc biệt khi chuột rời khỏi ô, nhưng nếu cần thêm logic, hãy thêm tại đây
        }


        //private void dgvTieuChi_MouseLeave(object sender, EventArgs e)
        //{
        //    toolTip.Hide(dataGridView1);
        //}

        private void btnLuu_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Chỉ được chấm 1 lần duy nhất", "Are you sure?", MessageBoxButtons.YesNo); //Gets users input by showing the message box
            if (result == DialogResult.Yes)
            {
                string vaiTroString;

                switch (vaiTro)
                {
                    case 1:
                        vaiTroString = "Sinh viên";
                        break;
                    case 3:
                        vaiTroString = "Cố vấn";
                        break;
                    case 4:
                        vaiTroString = "Khoa";
                        break;
                    case 5:
                        vaiTroString = "Trường";
                        break;
                    default:
                        vaiTroString = "Vai trò không xác định"; // Xử lý nếu vai trò không hợp lệ
                        break;
                }


                // Tạo loading animation
                //var loading = Loading.CreateLoadingControl(this);
                //Helper.Loading.ShowLoading(loading);

                // Chạy tác vụ nặng trong Task để không khóa giao diện
                //Task.Run(() =>
                //{
                Cham(vaiTroString, nguoiDungId);

                // Cập nhật giao diện phải thực hiện trên UI thread
                //    this.Invoke(new Action(() =>
                //    {
                //        Loading.HideLoading(loading); // Ẩn loading
                //    }));
                //});
            }
        }
        private void IfRoleIsSinhvien(int vaiTro, long nguoiDungId)
        {
            if (vaiTro == 1)
            {
                SinhVienDTO sinhvien = SinhVienBUS.GetStudentById(nguoiDungId);
                lbTen.Text = sinhvien.Name;
                lbMssv.Text = nguoiDungId.ToString();
                cbKhoa.Enabled = false;
                cbLop.Enabled = false;
                cbSinhvien.Enabled = false;
            }
        }
        private void Cham(String vaiTro, long nguoiDungId)
        {
            if (lbTen.Text == "" || lbMssv.Text == "")
            {
                MessageBox.Show("Chưa chọn sinh viên", "Thông báo");
                return;
            }

            GiangVienDTO gv = new GiangVienDTO();

            if (vaiTro == "Khoa")
            {
                gv = GiangVienBUS.GetGiangVienById(nguoiDungId);
            }
            //else if (cbHocKy.SelectedIndex == -1)
            //{
            //    MessageBox.Show("Chưa chọn học kì", "Thông báo");
            //    return;
            //}
            try
            {
                //int hockyid = Convert.ToInt32(cbHocKy.SelectedValue);
                int iddotcham = dotchamdiemId;
                //MessageBox.Show("Đang gọi GetIdVoiHocKyVaName " + iddotcham);
                // Lấy ID thông tin đợt chấm
                object result;
                if (vaiTro == "Khoa")
                {
                    result = ThongTinDotChamBUS.GetThongTinDotChamId(dotchamdiemId, vaiTro, Convert.ToInt64(lbMssv.Text), gv.KhoaId);
                    //MessageBox.Show(dotchamdiemId.ToString());
                    //MessageBox.Show(vaiTro.ToString());
                    //MessageBox.Show(lbMssv.Text.ToString());
                    //MessageBox.Show(nguoiDungId.ToString());
                }
                else if (vaiTro == "Trường")
                {
                    result = ThongTinDotChamBUS.GetThongTinDotChamId(dotchamdiemId, vaiTro, Convert.ToInt64(lbMssv.Text), 1);

                }
                else if (vaiTro == "Cố vấn")
                {
                    result = ThongTinDotChamBUS.GetThongTinDotChamId(dotchamdiemId, vaiTro, Convert.ToInt64(lbMssv.Text), nguoiDungId);


                }
                else
                {
                    result = ThongTinDotChamBUS.GetThongTinDotChamId(dotchamdiemId, vaiTro, Convert.ToInt64(lbMssv.Text), nguoiDungId);

                }

                if (result == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin đợt chấm!", "Lỗi");
                    return;
                }



                long idthongtindotcham = (long)result;
                //long idthongtindotcham = (long)ThongTinDotChamBUS.GetThongTinDotChamId(Convert.ToInt64(iddotcham), vaiTro, Convert.ToInt64(lbMssv.Text), nguoiDungId);
                // MessageBox.Show("Đang gọi idTTDC " + idthongtindotcham);
                int totalScore = 0;
                // Kiểm tra sự tồn tại của thongTinDotChamDiemId
                if (ChiTietDotChamBUS.IsChiTietDotChamExist(idthongtindotcham))
                {
                    MessageBox.Show("Không thể chấm lại!", "Thông báo");
                    return;
                }

                //Xác định cột điểm cần lấy dựa trên vai trò
                string diemColumn = vaiTro switch
                {
                    "Sinh viên" => "Điểm SV tự đánh giá",
                    "Cố vấn" => "Điểm CVHT",
                    "Khoa" => "Điểm khoa",
                    "Trường" => "Điểm trường",
                    _ => throw new Exception("Vai trò không hợp lệ!" + vaiTro)
                };

                // Lấy danh sách Id và điểm từ DataGridView hoặc DataTable
                //Dictionary<string, long> sttToId = GetSttToIdMapping(); // Map STT -> Id
                List<ChiTietDotChamDTO> chiTietList = new List<ChiTietDotChamDTO>();

                //foreach (DataGridViewRow row in dataGridView1.Rows)
                //{
                //    // Bỏ qua hàng trống
                //    if (row.IsNewRow) continue;

                //    string stt = row.Cells["STT"].Value?.ToString();
                //    string diemStr = row.Cells[diemColumn].Value?.ToString();

                //    if (!string.IsNullOrEmpty(stt) && !string.IsNullOrEmpty(diemStr))
                //    {
                //        // Chuyển STT sang Id
                //        long id = GetOriginalId(stt, sttToId);

                //        // Chuyển điểm sang số nguyên
                //        if (int.TryParse(diemStr, out int diem))
                //        {
                //            // Thêm vào danh sách kết quả
                //            totalScore += diem; // Cộng tổng điểm
                //            chiTietList.Add(new ChiTietDotChamDTO
                //            {
                //                TieuchiDanhgiaId = id,
                //                Diem = diem,
                //                ThongTinDotChamDiemId = idthongtindotcham,
                //                CreatedAt = DateTime.Now,
                //                UpdatedAt = DateTime.Now,
                //                Status = 1 // Trạng thái mặc định
                //            });
                //        }
                //        else
                //        {
                //            MessageBox.Show($"Điểm không hợp lệ ở dòng có STT: {stt}", "Thông báo");
                //        }
                //    }
                //}
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    // Bỏ qua hàng trống
                    if (row.IsNewRow) continue;

                    string stt = row.Cells["STT"].Value?.ToString();
                    string diemStr = row.Cells[diemColumn]?.Value?.ToString();
                    string imageUrl = row.Cells["ImagePath"]?.Value?.ToString();
                    string mota = row.Cells["Mota"]?.Value?.ToString();
                    string imageLink = "";

                    if (!string.IsNullOrEmpty(stt) && !string.IsNullOrEmpty(diemStr))
                    {
                        // Upload ảnh nếu có
                        if (imageUrl != null && imageUrl.Length > 0 && this.vaiTro == 1)
                        {
                            try
                            {
                                // Upload hình ảnh lên Cloudinary
                                imageLink = Program.cloudinaryService.UploadImage(imageUrl);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Lỗi khi upload ảnh: {ex.Message}");
                            }
                        }

                        // Kiểm tra nếu STT là số nguyên
                        if (int.TryParse(stt, out int _)) // `_` là biến không sử dụng
                        {
                            // Chuyển STT sang Id
                            long id = GetOriginalId(stt, sttToId);

                            // Chuyển điểm sang số nguyên
                            if (int.TryParse(diemStr, out int diem))
                            {
                                // Cộng điểm vào tổng
                                totalScore += diem;

                                // Thêm vào danh sách kết quả
                                chiTietList.Add(new ChiTietDotChamDTO
                                {
                                    TieuchiDanhgiaId = id,
                                    Diem = diem,
                                    ThongTinDotChamDiemId = idthongtindotcham,
                                    ImageUrl = imageLink,
                                    MoTa = mota,
                                    CreatedAt = DateTime.Now,
                                    UpdatedAt = DateTime.Now,
                                    Status = 1 // Trạng thái mặc định
                                });
                            }
                            else
                            {
                                MessageBox.Show($"Điểm không hợp lệ ở dòng có STT: {stt}", "Thông báo");
                            }
                        }
                        else
                        {
                            // Nếu STT không phải là số nguyên, chỉ lưu dữ liệu mà không cộng điểm
                            if (int.TryParse(diemStr, out int diem))
                            {
                                long id = GetOriginalId(stt, sttToId);
                                chiTietList.Add(new ChiTietDotChamDTO
                                {
                                    TieuchiDanhgiaId = id,
                                    Diem = diem,
                                    ThongTinDotChamDiemId = idthongtindotcham,
                                    ImageUrl = imageLink,
                                    MoTa = mota,
                                    CreatedAt = DateTime.Now,
                                    UpdatedAt = DateTime.Now,
                                    Status = 1
                                });
                            }
                        }
                    }
                }


                // Lưu dữ liệu vào cơ sở dữ liệu
                foreach (var chiTiet in chiTietList)
                {
                    ChiTietDotChamBUS.AddChiTietDotCham(chiTiet);
                }
                // Tạo đánh giá từ tổng điểm
                string danhGia = totalScore switch
                {
                    >= 90 => "Xuất sắc",
                    >= 80 => "Tốt",
                    >= 65 => "Khá",
                    >= 50 => "Trung bình",
                    >= 35 => "Yếu",
                    _ => "Kém"
                };

                // Lưu kết quả đợt chấm
                //var ketQuaDotCham = new KetQuaDotChamDTO(0, idthongtindotcham, totalScore, danhGia, DateTime.Now, 1);

                //KetQuaDotChamBUS.AddKetQuaDotCham(ketQuaDotCham);
                if (vaiTro == "Trường")
                {
                    ThongTinDotChamBUS.UpdateThongTinDotCham(iddotcham, vaiTro, Convert.ToInt64(lbMssv.Text), 1, totalScore, danhGia);
                }
                else if (vaiTro == "Khoa")
                {
                    ThongTinDotChamBUS.UpdateThongTinDotCham(iddotcham, vaiTro, Convert.ToInt64(lbMssv.Text), gv.KhoaId, totalScore, danhGia);
                }
                else if (vaiTro == "Cố vấn")
                {
                    ThongTinDotChamBUS.UpdateThongTinDotCham(iddotcham, vaiTro, Convert.ToInt64(lbMssv.Text), covanId, totalScore, danhGia);
                }
                else
                {
                    ThongTinDotChamBUS.UpdateThongTinDotCham(iddotcham, vaiTro, Convert.ToInt64(lbMssv.Text), Convert.ToInt64(lbMssv.Text), totalScore, danhGia);
                }

                if (vaiTro == "Trường")
                {
                    DiemRenLuyenSinhVienDTO drl = new DiemRenLuyenSinhVienDTO
                    {
                        Score = totalScore < 0 ? 0 : totalScore,
                        Comments = danhGia,
                        SemesterId = this.hockiId,
                        SinhVienId = Convert.ToInt64(lbMssv.Text)
                    };
                    DiemRenLuyenSinhVienDAO.AddDiemRenLuyen(drl);
                }

                MessageBox.Show("Chấm điểm thành công!", "Thông báo");
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi");
            }
        }
        public void loadDiemToTable(int hockyid, long mssv)
        {
            // Lấy danh sách ID của các đợt chấm trong học kỳ
            List<int> listDotChamId = DotChamDiemBUS.GetDotChamDiemIdsByHocKiId(hockyid);

            // Chuẩn bị ánh xạ STT -> TieuchiDanhgiaId từ cột "STT"
            Dictionary<string, long> sttToId = new Dictionary<string, long>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["STT"] != null && row.Cells["STT"].Value != null)
                {
                    string stt = row.Cells["STT"].Value.ToString();
                    long tieuchiId = Convert.ToInt64(row.Cells["TieuchiDanhgiaId"].Value);
                    sttToId[stt] = tieuchiId;
                }
            }

            // Xóa tất cả các cột điểm trước khi thêm cột mới
            for (int i = dataGridView1.Columns.Count - 1; i >= 0; i--)
            {
                if (dataGridView1.Columns[i].Name.StartsWith("Điểm "))
                {
                    dataGridView1.Columns.RemoveAt(i);
                }
            }

            // Duyệt qua từng đợt chấm
            foreach (int dotChamDiemId in listDotChamId)
            {
                // Lấy ThongTinDotChamDiemId
                long? thongTinDotChamDiemId = ThongTinDotChamBUS.GetThongTinDotChamDiemId(dotChamDiemId, mssv);
                if (thongTinDotChamDiemId == null)
                {
                    continue; // Bỏ qua nếu không tìm thấy thông tin đợt chấm
                }

                // Lấy vai trò người chấm
                string nguoiCham = ThongTinDotChamBUS.GetNguoiChamById(thongTinDotChamDiemId.Value);

                // Tạo tên cột điểm
                string tenCot = "";
                switch (nguoiCham)
                {
                    case "Sinh viên":
                        tenCot = "Điểm SV tự đánh giá";
                        break;
                    case "Cố vấn":
                        tenCot = "Điểm CVHT";
                        break;
                    case "Khoa":
                        tenCot = "Điểm khoa";
                        break;
                    case "Trường":
                        tenCot = "Điểm trường";
                        break;
                }

                // Kiểm tra xem cột đã tồn tại chưa, nếu chưa thì thêm mới
                if (!dataGridView1.Columns.Contains(tenCot))
                {
                    dataGridView1.Columns.Add(tenCot, tenCot);
                }

                // Lấy danh sách các tiêu chí và điểm
                List<ChiTietDotChamDTO> listChiTietDotCham = ChiTietDotChamBUS.GetListChiTietDotChamByThongTinDotChamId(thongTinDotChamDiemId.Value);

                // Gán điểm vào đúng hàng dựa trên TieuchiDanhgiaId
                foreach (ChiTietDotChamDTO chiTiet in listChiTietDotCham)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells["STT"] != null && row.Cells["STT"].Value != null)
                        {
                            long originalId = GetOriginalId(row.Cells["STT"].Value.ToString(), sttToId);
                            if (originalId == chiTiet.TieuchiDanhgiaId)
                            {
                                row.Cells[tenCot].Value = chiTiet.Diem;
                            }
                        }
                    }
                }
            }
        }

        private void cbLop_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbSinhvien_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbHocKy.SelectedIndex != -1)
                this.hockiId = Convert.ToInt32(cbHocKy.SelectedValue);
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem giá trị vừa nhập có hợp lệ không
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Đảm bảo hàng và cột hợp lệ
            {
                var editedCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

                // Kiểm tra nếu giá trị của ô chỉnh sửa là hợp lệ
                if (editedCell.Value == null || string.IsNullOrEmpty(editedCell.Value.ToString()))
                {
                    return;
                }

                int editedValue;
                // Kiểm tra nếu giá trị có thể chuyển đổi thành số nguyên
                if (!int.TryParse(editedCell.Value.ToString(), out editedValue))
                {
                    return;
                }

                // Lấy giá trị của cột STT từ hàng đang được chỉnh sửa
                string sttValue = dataGridView1.Rows[e.RowIndex].Cells["STT"].Value.ToString();
                long id = GetOriginalId(sttValue, sttToId);

                // Kiểm tra nếu STT của hàng là nguyên (không phải hàng con)


                // Nếu là hàng chính (STT nguyên), không áp dụng các điều kiện kiểm tra điểm
                if (sttValue != null && !int.TryParse(sttValue.ToString(), out _))
                {
                    // Kiểm tra giá trị của cột "Điểm tối đa" trong hàng hiện tại
                    int maxScore = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Điểm tối đa"].Value);

                    if (maxScore < 0 && editedValue > 0)
                    {
                        MessageBox.Show("Giá trị nhập vào trường này là điểm trừ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        editedCell.Value = string.Empty;
                        return; // Dừng lại, không cập nhật giá trị
                    }

                    if (maxScore > 0 && editedValue < 0)
                    {
                        MessageBox.Show("Giá trị nhập vào trường này là điểm cộng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        editedCell.Value = string.Empty;
                        return; // Dừng lại, không cập nhật giá trị
                    }

                    if (maxScore < 0 && editedValue < 0 && editedValue < maxScore)
                    {
                        MessageBox.Show("Giá trị nhập vào không được vượt quá điểm trừ tối đa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        editedCell.Value = string.Empty;
                        return; // Dừng lại, không cập nhật giá trị
                    }

                    // Kiểm tra nếu giá trị vừa nhập lớn hơn điểm tối đa
                    if (maxScore > 0 && editedValue > 0 && editedValue > maxScore)
                    {
                        MessageBox.Show("Giá trị nhập vào không được vượt quá điểm tối đa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        editedCell.Value = string.Empty;
                        return; // Dừng lại, không cập nhật giá trị
                    }
                }

                // Lấy hàng có STT = 1
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++) // Duyệt đến dòng cuối cùng
                {
                    DataGridViewRow row = dataGridView1.Rows[i]; // Lấy hàng hiện tại

                    // Kiểm tra nếu ID cha trùng với giá trị ID của hàng hiện tại
                    if (GetOriginalId(row.Cells["STT"].Value.ToString(), sttToId) == TieuChiDanhGiaBUS.GetIdTieuChiCha(id))
                    {
                        if (vaiTro == 1)
                        {
                            // Kiểm tra nếu cột "Điểm SV tự đánh giá" đã có giá trị
                            if (row.Cells["Điểm SV tự đánh giá"].Value != null &&
                                 !string.IsNullOrEmpty(row.Cells["Điểm SV tự đánh giá"].Value.ToString()))
                            {
                                // Nếu có giá trị, thực hiện phép tính: (Giá trị cũ - Giá trị cũ của cell) + Giá trị mới của cell
                                int currentValue = Convert.ToInt32(row.Cells["Điểm SV tự đánh giá"].Value); // Giá trị hiện tại của ô
                                int newValue = currentValue - originalValue + Convert.ToInt32(editedCell.Value); // Cập nhật giá trị mới
                                if (newValue > Convert.ToInt32(row.Cells["Điểm tối đa"].Value))
                                {
                                    row.Cells["Điểm SV tự đánh giá"].Value = row.Cells["Điểm tối đa"].Value;
                                }
                                else
                                    row.Cells["Điểm SV tự đánh giá"].Value = newValue;
                            }
                            else
                            {
                                // Nếu không có giá trị, gán giá trị mới vào cột
                                row.Cells["Điểm SV tự đánh giá"].Value = editedCell.Value;
                            }
                            return;
                        }
                        else if (vaiTro == 3)
                        {
                            // Kiểm tra nếu cột "Điểm SV tự đánh giá" đã có giá trị
                            if (row.Cells["Điểm CVHT"].Value != null &&
                                 !string.IsNullOrEmpty(row.Cells["Điểm CVHT"].Value.ToString()))
                            {
                                // Nếu có giá trị, thực hiện phép tính: (Giá trị cũ - Giá trị cũ của cell) + Giá trị mới của cell
                                int currentValue = Convert.ToInt32(row.Cells["Điểm CVHT"].Value); // Giá trị hiện tại của ô
                                int newValue = currentValue - originalValue + Convert.ToInt32(editedCell.Value); // Cập nhật giá trị mới
                                if (newValue > Convert.ToInt32(row.Cells["Điểm tối đa"].Value))
                                {
                                    row.Cells["Điểm CVHT"].Value = row.Cells["Điểm tối đa"].Value;
                                }
                                else
                                    row.Cells["Điểm CVHT"].Value = newValue;
                            }
                            else
                            {
                                // Nếu không có giá trị, gán giá trị mới vào cột
                                row.Cells["Điểm CVHT"].Value = editedCell.Value;
                            }
                            return;
                        }
                        else if (vaiTro == 4)
                        {
                            // Kiểm tra nếu cột "Điểm SV tự đánh giá" đã có giá trị
                            if (row.Cells["Điểm khoa"].Value != null &&
                                 !string.IsNullOrEmpty(row.Cells["Điểm khoa"].Value.ToString()))
                            {
                                // Nếu có giá trị, thực hiện phép tính: (Giá trị cũ - Giá trị cũ của cell) + Giá trị mới của cell
                                int currentValue = Convert.ToInt32(row.Cells["Điểm khoa"].Value); // Giá trị hiện tại của ô
                                int newValue = currentValue - originalValue + Convert.ToInt32(editedCell.Value); // Cập nhật giá trị mới
                                if (newValue > Convert.ToInt32(row.Cells["Điểm tối đa"].Value))
                                {
                                    row.Cells["Điểm khoa"].Value = row.Cells["Điểm tối đa"].Value;
                                }
                                else
                                    row.Cells["Điểm khoa"].Value = newValue;
                            }
                            else
                            {
                                // Nếu không có giá trị, gán giá trị mới vào cột
                                row.Cells["Điểm khoa"].Value = editedCell.Value;
                            }
                            return;
                        }
                        else if (vaiTro == 5)
                        {
                            // Kiểm tra nếu cột "Điểm SV tự đánh giá" đã có giá trị
                            if (row.Cells["Điểm trường"].Value != null &&
                                 !string.IsNullOrEmpty(row.Cells["Điểm trường"].Value.ToString()))
                            {
                                // Nếu có giá trị, thực hiện phép tính: (Giá trị cũ - Giá trị cũ của cell) + Giá trị mới của cell
                                int currentValue = Convert.ToInt32(row.Cells["Điểm trường"].Value); // Giá trị hiện tại của ô
                                int newValue = currentValue - originalValue + Convert.ToInt32(editedCell.Value); // Cập nhật giá trị mới
                                if (newValue > Convert.ToInt32(row.Cells["Điểm tối đa"].Value))
                                {
                                    row.Cells["Điểm trường"].Value = row.Cells["Điểm tối đa"].Value;
                                }
                                else
                                    row.Cells["Điểm trường"].Value = newValue;
                            }
                            else
                            {
                                // Nếu không có giá trị, gán giá trị mới vào cột
                                row.Cells["Điểm trường"].Value = editedCell.Value;
                            }
                            return;
                        }
                    }
                }
            }
        }




        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Lưu giá trị ban đầu của ô vào biến originalValue khi bắt đầu chỉnh sửa
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var cellValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                // Kiểm tra nếu ô có giá trị hay không
                if (cellValue != null && !string.IsNullOrEmpty(cellValue.ToString()))
                {
                    // Nếu có giá trị, chuyển đổi giá trị sang int
                    originalValue = Convert.ToInt32(cellValue);
                }
                else
                {
                    // Nếu ô rỗng, gán giá trị mặc định là 0
                    originalValue = 0;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (vaiTro == 1)
            {
                ExcelExporter.ExportDataGridViewToExcelWithColors(dataGridView1, 7);
            }
            else
            {
                if (cbKhoa.SelectedIndex < 0 && cbLop.SelectedIndex < 0 && cbSinhvien.SelectedIndex < 0)
                {
                    MessageBox.Show("Chọn thông tin để xuất");
                    return;
                }
                //ExcelExporter.ExportDataGridViewToExcelWithColors(dataGridView1);
            }
        }

        public static void CopyDataToDiemTruongColumn(DataGridView dataGridView, string diemTruongColumnName)
        {
            // Tìm cột "Điểm trường"
            int diemTruongColumnIndex = -1;

            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                if (column.HeaderText == diemTruongColumnName)
                {
                    diemTruongColumnIndex = column.Index;
                    break;
                }
            }

            // Kiểm tra nếu không tìm thấy cột "Điểm trường"
            if (diemTruongColumnIndex == -1)
            {
                MessageBox.Show($"Không tìm thấy cột '{diemTruongColumnName}'!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy dữ liệu từ cột bên trái và sao chép vào cột "Điểm trường"
            for (int row = 0; row < dataGridView.Rows.Count; row++)
            {
                // Lấy cột bên trái cột "Điểm trường"
                int leftColumnIndex = diemTruongColumnIndex - 1;

                // Nếu cột bên trái hợp lệ (không nhỏ hơn 0)
                if (leftColumnIndex >= 0)
                {
                    // Lấy giá trị từ cột bên trái
                    var leftCellValue = dataGridView.Rows[row].Cells[leftColumnIndex].Value;

                    // Gán giá trị vào cột "Điểm trường"
                    dataGridView.Rows[row].Cells[diemTruongColumnIndex].Value = leftCellValue;
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string role = this.vaiTro switch
            {
                3 => "Điểm CVHT",
                4 => "Điểm khoa",
                5 => "Điểm trường",
                _ => "Unknown"
            };
            dataGridView1.CellValueChanged -= dataGridView1_CellValueChanged;
            CopyDataToDiemTruongColumn(dataGridView1, role);
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
        }






        //private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    // Kiểm tra xem giá trị vừa nhập có hợp lệ không
        //    if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Đảm bảo hàng và cột hợp lệ
        //    {
        //        var editedCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

        //        // Lấy giá trị của cột STT từ hàng đang được chỉnh sửa
        //        string sttValue = dataGridView1.Rows[e.RowIndex].Cells["STT"].Value.ToString();
        //        int editedValue = Convert.ToInt32(editedCell.Value);
        //        long id = GetOriginalId(sttValue, sttToId);

        //        // Hiển thị giá trị STT trong MessageBox
        //        //MessageBox.Show($"Giá trị của cột STT trong hàng hiện tại là: {sttValue}");

        //        //Lấy hàng có STT = 1
        //        foreach (DataGridViewRow row in dataGridView1.Rows)
        //        {
        //            if (GetOriginalId(row.Cells["STT"].Value.ToString(), sttToId) == TieuChiDanhGiaBUS.GetIdTieuChiCha(id))
        //            {
        //                if (vaiTro == 1)
        //                {
        //                    row.Cells["Điểm SV tự đánh giá"].Value = editedCell.Value;
        //                    return;
        //                }
        //                //// Lấy giá trị vừa nhập và gán vào cell "test" trong hàng có STT = 1
        //                //if (row.Cells["test"] != null)
        //                //{
        //                //    row.Cells["test"].Value = editedCell.Value;
        //                //}
        //                //break;

        //                //row["Điểm SV tự đánh giá"] = diemSV.HasValue ? diemSV.Value.ToString() : string.Empty;
        //                //row["Điểm CVHT"] = string.Empty;
        //                //row["Điểm khoa"] = string.Empty;
        //                //row["Điểm trường"] = string.Empty;
        //            }
        //        }
        //    }
        //}


    }

    public class ImageData
    {
        public long TieuChiId { get; set; }
        public string Image { get; set; }
        public string MoTa { get; set; }

        public ImageData(long tieuChiId, string image, string MoTa)
        {
            TieuChiId = tieuChiId;
            Image = image;
            MoTa = MoTa;
        }
    }

}

