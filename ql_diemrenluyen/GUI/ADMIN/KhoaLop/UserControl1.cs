using ql_diemrenluyen.BUS;
using ql_diemrenluyen.DTO;

namespace ql_diemrenluyen.GUI.ADMIN.KhoaLop
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            List<KhoaDTO> list = KhoaBUS.GetAllKhoa();
            loadlist(list);

        }
        public void loadlist(List<KhoaDTO> list)
        {
            dataGridKhoaView.DataSource = null;
            dataGridKhoaView.Rows.Clear();
            foreach (KhoaDTO item in list)
            {
                if (item.status == 1)
                {
                    int rowIndex = dataGridKhoaView.Rows.Add();
                    dataGridKhoaView.Rows[rowIndex].Cells[0].Value = item.Id;
                    dataGridKhoaView.Rows[rowIndex].Cells[1].Value = item.TenKhoa;
                }
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridKhoaView.Columns["more"].Index && e.RowIndex >= 0)
            {
                var selectColumn = dataGridKhoaView.Rows[e.RowIndex];
                KhoaDTO item;
                if (selectColumn.Cells["id"].Value != null)
                {
                    item = KhoaBUS.GetKhoaByID(long.Parse(selectColumn.Cells["id"].Value.ToString()));
                    using (var update_Khoa = new UpdateKhoa(item))
                    {
                        if (update_Khoa.ShowDialog() == DialogResult.OK)
                        {
                            List<KhoaDTO> list = KhoaBUS.GetAllKhoa();
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

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            using (var addKhoaForm = new AddKhoa())
            {
                if (addKhoaForm.ShowDialog() == DialogResult.OK)
                {
                    List<KhoaDTO> list = KhoaBUS.GetAllKhoa();
                    loadlist(list);
                }
            }
        }

        private void find_Click(object sender, EventArgs e)
        {

            List<KhoaDTO> list;
            if (textBox1.Text == "")
            {
                list = KhoaBUS.GetAllKhoa();
                loadlist(list);
            }
            else
            {
                list = KhoaBUS.findAll(textBox1.Text);
                if (list == null)
                {
                    MessageBox.Show("Giá trị không tồn tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    list = KhoaBUS.GetAllKhoa();
                    loadlist(list);
                }
                else
                {
                    loadlist(list);
                }
            }
        }

        private void dataGridKhoaView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Kiểm tra xem có phải là nút không
            if (e.ColumnIndex == dataGridKhoaView.Columns["more"].Index && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                Image img = Image.FromFile("../../../Resources/edit.png");
                int x = e.CellBounds.Left + (e.CellBounds.Width - img.Width) / 2;
                int y = e.CellBounds.Top + (e.CellBounds.Height - img.Height) / 2;
                e.Graphics.DrawImage(img, new Rectangle(x, y, img.Width, img.Height));
                e.Handled = true;
            }
        }
        public void Setlist(List<KhoaDTO> list)
        {
            if (list != null)
            {
                loadlist(list);
            }
            else
            {
                MessageBox.Show("Dữ liệu không tồn tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                list = KhoaBUS.GetAllKhoa();
                loadlist(list);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            new KhoaSearch(this).Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            // Chuyển đổi danh sách sang List<Dictionary<string, string>>
            var dictionaryList = ExcelExporter.ConvertListToDictionaryList(KhoaBUS.GetAllKhoa());

            // Xuất ra Excel
            ExcelExporter.ExportListToExcel(dictionaryList);
        }
    }
}
