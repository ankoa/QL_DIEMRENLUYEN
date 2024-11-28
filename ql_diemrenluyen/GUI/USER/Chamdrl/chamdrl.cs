using ql_diemrenluyen.BUS;
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
        private Dictionary<string, long> sttToId = new Dictionary<string, long>();
        //private System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
        private System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();


        public chamdrl()
        {
            InitializeComponent();
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
            dataGridView1.EditingControlShowing += dataGridView_EditingControlShowing;
            dataGridView1.CellMouseEnter += dgvTieuChi_CellMouseEnter;
            dataGridView1.CellMouseLeave += dgvTieuChi_CellMouseLeave;
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


            for (int i = 0; i < khoaList.Count; i++)
            {
                data1.Add(khoaList[i].TenKhoa);

            }

            cbKhoa.AutoCompleteCustomSource = data1;
            cbKhoa.DataSource = data1;
            cbKhoa.SelectedIndex = -1;

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

            //HocKyDTO lastHocKy = hockyList.Last();
            //lbhocky.Text = "Học kỳ " + lastHocKy.Name + " năm học " + lastHocKy.namhoc + " - " + lastHocKy.namhoc + 1;
            LoadHocKyToComboBox();
            //cbHocKy.SelectedIndexChanged += (s, e) =>
            //{
            //    if (cbHocKy.SelectedValue != null)
            //    {
            //        int selectedHocKyId = (int)cbHocKy.SelectedValue;
            //        MessageBox.Show($"Học kỳ được chọn có ID: {selectedHocKyId}");
            //    }
            //};





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

                row["STT"] = stt;
                row["Nội dung tiêu chí đánh giá"] = noiDung;
                row["Điểm tối đa"] = diemMax;
                row["Điểm SV tự đánh giá"] = string.Empty;
                row["Điểm CVHT"] = string.Empty;
                row["Điểm khoa"] = string.Empty;
                row["Điểm trường"] = string.Empty;
                row["Ghi chú"] = string.Empty;

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }


        //private string GetSTT(TieuChiDanhGiaDTO tieuChi, Dictionary<long, int> childCountByParent, Dictionary<long, string> parentToRoman)
        //{
        //    // Nếu là mục cha lớn nhất (không có ParentId)
        //    if (tieuChi.ParentId == 0)
        //    {
        //        // Đánh số la mã cho mục cha
        //        int romanIndex = parentToRoman.Count + 1;
        //        string roman = ConvertToRoman(romanIndex);
        //        parentToRoman[tieuChi.Id] = roman;  // Ghi lại số la mã của mục cha
        //        return roman;  // Trả về số la mã của mục cha
        //    }
        //    else  // Mục con của mục cha hoặc con của mục con
        //    {
        //        // Kiểm tra nếu mục cha đã có trong childCountByParent, nếu chưa thì khởi tạo
        //        if (!childCountByParent.ContainsKey(tieuChi.ParentId))
        //        {
        //            childCountByParent[tieuChi.ParentId] = 0; // Khởi tạo số lượng con của mục cha
        //        }

        //        // Nếu mục cha là số la mã
        //        if (parentToRoman.ContainsKey(tieuChi.ParentId))
        //        {
        //            // Nếu cha là la mã, mục con sẽ là số tự nhiên
        //            childCountByParent[tieuChi.ParentId]++;
        //            return childCountByParent[tieuChi.ParentId].ToString();
        //        }
        //        else
        //        {
        //            // Nếu cha là số tự nhiên, mục con sẽ có số thập phân (cha.số con)
        //            string parentStt = childCountByParent[tieuChi.ParentId].ToString(); // Số tự nhiên của cha
        //            childCountByParent[tieuChi.ParentId]++;
        //            return parentStt + "." + childCountByParent[tieuChi.ParentId].ToString();  // Đánh số thập phân
        //        }
        //    }
        //}
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


        //private void dgvTieuChi_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["Nội dung tiêu chí đánh giá"].Index)
        //    {
        //        // Lấy nội dung cột
        //        string cellValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

        //        // Kiểm tra nếu chứa dấu "?"
        //        if (cellValue.Contains("(?)"))
        //        {
        //            // Lấy ID của tiêu chí
        //            long tieuchidanhgiaId = GetIdByRowIndex(e.RowIndex);

        //            // Lấy danh sách chú thích
        //            List<ChuThichTieuChiDTO> chuThichList = ChuThichTieuChiDAO.GetChuThichByTieuChiId(tieuchidanhgiaId);
        //            if (chuThichList.Count > 0)
        //            {
        //                // Tạo nội dung ghi chú
        //                string content = string.Join(Environment.NewLine,
        //                    chuThichList.Select(ct => $"- {ct.Name}: {ct.Diem}đ"));

        //                // Hiển thị tooltip
        //                toolTip.Show(content, dataGridView1, e.Location.X + 15, e.Location.Y + 15, 5000); // Hiển thị 5 giây
        //            }
        //        }
        //        else
        //        {
        //            // Ẩn tooltip nếu không nằm trên dấu "?"
        //            toolTip.Hide(dataGridView1);
        //        }
        //    }
        //}
        private void dgvTieuChi_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
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
                        toolTip.Show(noteText, dataGridView1,
                        dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Location,
                        50000); // Hiển thị 5 giây
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

        }


    }
}

