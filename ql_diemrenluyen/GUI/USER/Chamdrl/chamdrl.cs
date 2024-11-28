using ql_diemrenluyen.BUS;
using ql_diemrenluyen.DAO;
using ql_diemrenluyen.DTO;
using System.Data;

namespace ql_diemrenluyen.GUI.ADMIN
{
    public partial class chamdrl : Form
    {
        AutoCompleteStringCollection data1 = new AutoCompleteStringCollection();
        List<KhoaDTO> khoaList = KhoaBUS.GetAllKhoa();
        List<LopDTO> lopList = LopBUS.getAllLop();
        List<HocKyDTO> hockyList = HocKyBUS.GetAllHocKy();
        List<SinhVienDTO> sinhvienList = SinhVienBUS.GetAllStudents();
        List<TieuChiDanhGiaDTO> tieuChiList = TieuChiDanhGiaBUS.XuatAllTieuChiDanhGia();
        private Dictionary<string, long> sttToId = new Dictionary<string, long>();
        //private System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
        private System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
        long nguoiDungId = long.Parse(Program.nguoidung_id);
        int vaiTro = Program.role;
        string action = "";
        int hockiId;
        int dotchamdiemId;
        long svID;


        public chamdrl(string action, int hocky, int dotchamdiem, long sinhVienId)
        {
            //long sinhvienId, long? giangvienId = null, string action
            InitializeComponent();
            this.action = action;
            this.hockiId = hocky;
            this.dotchamdiemId = dotchamdiem;
            this.svID = sinhVienId;
            if (action == "Chấm")
            {
                btnLuu.Visible = true;
            }
            else if (action == "Xem")
            {
                btnLuu.Visible = false;
            }
        }

        private void chamdrl_Load(object sender, EventArgs e)
        {
            LoadData();
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
            DataTable dataTable = ConvertToDataTable(tieuChiList);

            dataGridView1.DataSource = dataTable; // Gán DataTable vào DataGridView
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

            // Xác định vai trò và cho phép chỉnh sửa cột phù hợp
            switch (Program.role) // role = "1=Sinh Viên", "3=Cố vấn", "4=Khoa", "5=Trường"
            {
                case 1:
                    dataGridView1.Columns["Điểm SV tự đánh giá"].ReadOnly = false;
                    dataGridView1.Columns["Ghi Chú"].ReadOnly = false;
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

            if (vaiTro == 3)
            {
                GiangVienDTO gv = GiangVienBUS.GetGiangVienById(nguoiDungId);
                for (int i = 0; i < khoaList.Count; i++)
                {
                    if (gv.KhoaId == khoaList[i].Id)
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
                    if (gv.KhoaId == khoaList[i].Id)
                    {
                        data1.Add(khoaList[i].TenKhoa);
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
                    }
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

        private DataTable ConvertToDataTable(List<TieuChiDanhGiaDTO> tieuChiList)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("STT", typeof(string));
            dataTable.Columns.Add("Nội dung tiêu chí đánh giá", typeof(string));
            dataTable.Columns.Add("Điểm tối đa", typeof(string));
            dataTable.Columns.Add("Điểm SV tự đánh giá", typeof(string));
            dataTable.Columns.Add("Điểm CVHT", typeof(string));
            dataTable.Columns.Add("Điểm khoa", typeof(string));
            dataTable.Columns.Add("Điểm trường", typeof(string));
            dataTable.Columns.Add("Ghi chú", typeof(string));

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
                    row["Ghi chú"] = string.Empty;
                }
                else if (vaiTro == 3)
                {
                    int? diemSV = ChiTietDotChamDAO.GetDiem(sinhVienID: svID, tieuChiDanhGiaID: item.Id, dotchamdiemID: dotchamdiemId);
                    row["STT"] = stt;
                    row["Nội dung tiêu chí đánh giá"] = noiDung;
                    row["Điểm tối đa"] = diemMax;
                    row["Điểm SV tự đánh giá"] = diemSV.HasValue ? diemSV.Value.ToString() : string.Empty;
                    row["Điểm CVHT"] = string.Empty;
                    row["Điểm khoa"] = string.Empty;
                    row["Điểm trường"] = string.Empty;
                    row["Ghi chú"] = string.Empty;
                }
                else if (vaiTro == 4)
                {
                    int? diemSV = ChiTietDotChamDAO.GetDiem(sinhVienID: svID, tieuChiDanhGiaID: item.Id, dotchamdiemID: dotchamdiemId);
                    int? diemCV = ChiTietDotChamDAO.GetDiem(sinhVienID: svID, tieuChiDanhGiaID: item.Id, dotchamdiemID: 4, coVanID: 1);
                    row["STT"] = stt;
                    row["Nội dung tiêu chí đánh giá"] = noiDung;
                    row["Điểm tối đa"] = diemMax;
                    row["Điểm SV tự đánh giá"] = diemSV.HasValue ? diemSV.Value.ToString() : string.Empty;
                    row["Điểm CVHT"] = diemCV.HasValue ? diemCV.Value.ToString() : string.Empty;
                    row["Điểm khoa"] = string.Empty;
                    row["Điểm trường"] = string.Empty;
                    row["Ghi chú"] = string.Empty;
                }
                else if (vaiTro == 5)
                {
                    int? diemSV = ChiTietDotChamDAO.GetDiem(sinhVienID: svID, tieuChiDanhGiaID: item.Id, dotchamdiemID: dotchamdiemId);
                    int? diemCV = ChiTietDotChamDAO.GetDiem(sinhVienID: svID, tieuChiDanhGiaID: item.Id, dotchamdiemID: 4, coVanID: 1);
                    int? diemK = ChiTietDotChamDAO.GetDiem(sinhVienID: svID, tieuChiDanhGiaID: item.Id, dotchamdiemID: 1, khoaID: 1);
                    row["STT"] = stt;
                    row["Nội dung tiêu chí đánh giá"] = noiDung;
                    row["Điểm tối đa"] = diemMax;
                    row["Điểm SV tự đánh giá"] = diemSV.HasValue ? diemSV.Value.ToString() : string.Empty;
                    row["Điểm CVHT"] = string.Empty;
                    row["Điểm khoa"] = string.Empty;
                    row["Điểm trường"] = string.Empty;
                    row["Điểm CVHT"] = diemCV.HasValue ? diemCV.Value.ToString() : string.Empty;
                    row["Điểm khoa"] = diemK.HasValue ? diemK.Value.ToString() : string.Empty;
                    row["Điểm trường"] = string.Empty;
                    row["Ghi chú"] = string.Empty;
                }
                //int? diemT = ChiTietDotChamDAO.GetDiem(sinhVienID: svID, tieuChiDanhGiaID: item.Id, dotchamdiemID: 2, final: 1);







                dataTable.Rows.Add(row);
            }

            return dataTable;
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
                    if (khoaList[i].TenKhoa == tenkhoa)
                    {
                        //MessageBox.Show("ddmádasdasd");
                        khoaId = khoaList[i].Id;
                        break;
                    }
                }
                // Lọc và thêm các lớp vào ComboBox cbLop dựa trên khoaId
                for (int i = 0; i < lopList.Count; i++)
                {
                    //MessageBox.Show(lopList[i].KhoaId);
                    if (lopList[i].Khoa.Id == khoaId)
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
                        break;
                    }
                }

                // Lọc và thêm các sinh viên vào ComboBox cbSinhvien dựa trên lopId
                for (int i = 0; i < sinhvienList.Count; i++)
                {
                    if (sinhvienList[i].LopId == lopId)
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
            Cham(vaiTroString, nguoiDungId);
        }
        private void IfRoleIsSinhvien(int vaiTro, long nguoiDungId)
        {
            if (vaiTro == 1)
            {
                SinhVienDTO sinhvien = SinhVienBUS.GetStudentById(nguoiDungId);
                lbTen.Text = sinhvien.Name;
                lbMssv.Text = sinhvien.Id.ToString();
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
                object result = ThongTinDotChamBUS.GetThongTinDotChamId(Convert.ToInt64(iddotcham), vaiTro, Convert.ToInt64(lbMssv.Text), nguoiDungId);

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
                    string diemStr = row.Cells[diemColumn].Value?.ToString();

                    if (!string.IsNullOrEmpty(stt) && !string.IsNullOrEmpty(diemStr))
                    {
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

                ThongTinDotChamBUS.UpdateThongTinDotCham(iddotcham, vaiTro, Convert.ToInt64(lbMssv.Text), nguoiDungId, totalScore, danhGia);

                if (vaiTro == "Trường")
                {
                    DiemRenLuyenSinhVienDTO drl = new DiemRenLuyenSinhVienDTO
                    {
                        Score = totalScore,
                        Comments = danhGia,
                        SemesterId = Convert.ToInt32(cbHocKy.SelectedValue),
                        SinhVienId = Convert.ToInt64(lbMssv.Text)
                    };
                    DiemRenLuyenSinhVienDAO.AddDiemRenLuyen(drl);
                }

                MessageBox.Show("Chấm điểm thành công!", "Thông báo");
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
    }
}

