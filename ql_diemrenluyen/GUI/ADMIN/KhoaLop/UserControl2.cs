using ql_diemrenluyen.BUS;
using ql_diemrenluyen.DTO;
using ql_diemrenluyen.Util.ExcelImporter;

namespace ql_diemrenluyen.GUI.ADMIN.KhoaLop
{
    public partial class UserControl2 : UserControl
    {
        List<LopDTO> list;
        public UserControl2()
        {
            InitializeComponent();
        }
        public void loadlist(List<LopDTO> list)
        {
            dataGridLopView.DataSource = null;
            dataGridLopView.Rows.Clear();
            foreach (LopDTO item in list)
            {
                if (item.status == 1)
                {
                    int rowIndex = dataGridLopView.Rows.Add();
                    dataGridLopView.Rows[rowIndex].Cells[0].Value = item.Id;
                    dataGridLopView.Rows[rowIndex].Cells[1].Value = item.TenLop;
                    dataGridLopView.Rows[rowIndex].Cells[2].Value = item.Khoa.TenKhoa;
                    dataGridLopView.Rows[rowIndex].Cells[3].Value = item.HeDaoTao.Name;
                    dataGridLopView.Rows[rowIndex].Cells[4].Value = item.CoVanId;

                    // Xử lý tên giảng viên nếu CoVanId không null
                    dataGridLopView.Rows[rowIndex].Cells[5].Value = item.CoVanId.HasValue
                        ? GiangVienBUS.GetGiangVienById(item.CoVanId.Value).Name
                        : "";
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            using (var AddLopForm = new AddLop())
            {
                if (AddLopForm.ShowDialog() == DialogResult.OK)
                {
                    list = LopBUS.getAllLop();
                    loadlist(list);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void UserControl2_Load(object sender, EventArgs e)
        {
            list = LopBUS.getAllLop();
            loadlist(list);
        }

        private void dataGridLopView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dataGridLopView.Columns["more"].Index && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                Image img = Image.FromFile("../../../Resources/edit.png");
                int x = e.CellBounds.Left + (e.CellBounds.Width - img.Width) / 2;
                int y = e.CellBounds.Top + (e.CellBounds.Height - img.Height) / 2;
                e.Graphics.DrawImage(img, new Rectangle(x, y, img.Width, img.Height));
                e.Handled = true;
            }
        }

        private void dataGridLopView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridLopView.Columns["more"].Index && e.RowIndex >= 0)
            {
                var selectColumn = dataGridLopView.Rows[e.RowIndex];
                LopDTO item = new LopDTO();
                if (selectColumn.Cells["id_lop"].Value != null)
                {
                    item = LopBUS.GetLopByID(long.Parse(selectColumn.Cells["id_lop"].Value.ToString()));
                    using (var update_lop = new UpdateLop(item))
                    {
                        if (update_lop.ShowDialog() == DialogResult.OK)
                        {
                            List<LopDTO> list = LopBUS.getAllLop();
                            loadlist(list);

                        }
                    }
                }
                else
                {
                    MessageBox.Show("Hãy chọn dòng có giá trị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void find_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                list = LopBUS.getAllLop();
                loadlist(list);
            }
            else
            {
                list = LopBUS.findAll(textBox1.Text);
                if (list == null)
                {
                    MessageBox.Show("Giá trị không tồn tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    list = LopBUS.getAllLop();
                    loadlist(list);
                }
                else
                {
                    loadlist(list);
                }
            }
        }
        public void Setlist(List<LopDTO> list)
        {
            if (list != null)
            {
                loadlist(list);
            }
            else
            {
                MessageBox.Show("Dữ liệu không tồn tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                list = LopBUS.getAllLop();
                loadlist(list);
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            new LopSearch(this).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Chuyển đổi danh sách sang List<Dictionary<string, string>>
            var dictionaryList = ExcelExporter.ConvertListToDictionaryList(LopBUS.GetLopHocToExports());

            // Xuất ra Excel
            ExcelExporter.ExportListToExcel(dictionaryList);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xlsx;*.xls";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    try
                    {
                        ImportLop importer = new ImportLop();
                        var importedStudents = importer.ImportFromExcel(filePath);

                        MessageBox.Show($"Import thành công {importedStudents.Count} lớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        list = LopBUS.getAllLop();
                        loadlist(list);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi import dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
