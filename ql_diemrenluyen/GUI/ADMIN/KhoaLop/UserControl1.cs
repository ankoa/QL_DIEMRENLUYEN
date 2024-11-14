using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlX.XDevAPI.Relational;
using ql_diemrenluyen.BUS;
using ql_diemrenluyen.DTO;

namespace ql_diemrenluyen.GUI.ADMIN.KhoaLop
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }

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
                    dataGridKhoaView.Rows[rowIndex].Cells[2].Value = item.CreatedAt;
                    dataGridKhoaView.Rows[rowIndex].Cells[3].Value = item.UpdatedAt;
                }
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridKhoaView.Columns["more"].Index && e.RowIndex >= 0)
            {
                var selectColumn = dataGridKhoaView.Rows[e.RowIndex];
                KhoaDTO item = new KhoaDTO();
                if(selectColumn.Cells["id"].Value != null)
                {
                    item.Id = long.Parse(selectColumn.Cells["id"].Value.ToString());
                    item.TenKhoa = selectColumn.Cells["name"].Value.ToString();
                    item.CreatedAt = DateTime.Parse(selectColumn.Cells["created_day"].Value.ToString());
                    item.UpdatedAt = DateTime.Parse(selectColumn.Cells["updated_day"].Value.ToString());
                    item.status = 1;
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
            List<KhoaDTO> list = KhoaBUS.GetAllKhoa();
            loadlist(list);
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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
                if (comboBox1.SelectedIndex == 0)
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
                else if (comboBox1.SelectedIndex == 1)
                {
                    list = KhoaBUS.GetListKhoaById(long.Parse(textBox1.Text));
                    if (list == null)
                    {
                        MessageBox.Show("Mã khoa không tồn tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        list = KhoaBUS.GetAllKhoa();
                        loadlist(list);
                    }
                    else
                    {
                        loadlist(list);
                    }
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    list = KhoaBUS.findName(textBox1.Text);
                    if (list == null)
                    {
                        MessageBox.Show("Tên không tồn tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        list = KhoaBUS.GetAllKhoa();
                        loadlist(list);
                    }
                    else
                    {
                        loadlist(list);
                    }
                }
            }
        }

        private void dataGridKhoaView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Kiểm tra xem có phải là nút không
            if (e.ColumnIndex == dataGridKhoaView.Columns["more"].Index && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                Image img = Image.FromFile("C:\\Users\\User\\Downloads\\edit.png");
                int x = e.CellBounds.Left + (e.CellBounds.Width - img.Width) / 2;
                int y = e.CellBounds.Top + (e.CellBounds.Height - img.Height) / 2;
                e.Graphics.DrawImage(img, new Rectangle(x, y, img.Width, img.Height));
                e.Handled = true;
            }
        }
    }
}
