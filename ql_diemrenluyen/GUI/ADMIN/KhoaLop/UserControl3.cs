using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Org.BouncyCastle.Utilities;
using ql_diemrenluyen.BUS;
using ql_diemrenluyen.DTO;

namespace ql_diemrenluyen.GUI.ADMIN.KhoaLop
{
    public partial class UserControl3 : UserControl
    {
        List<HeHocDTO> list;
        public UserControl3()
        {
            InitializeComponent();
        }
        public void loadlist(List<HeHocDTO> list)
        {
            dataGridHeHocView.DataSource = null;
            dataGridHeHocView.Rows.Clear();
            foreach (HeHocDTO item in list)
            {
                if (item.status == 1)
                {
                    int rowIndex = dataGridHeHocView.Rows.Add();
                    dataGridHeHocView.Rows[rowIndex].Cells[0].Value = item.Id;
                    dataGridHeHocView.Rows[rowIndex].Cells[1].Value = item.Name;
                }
            }
        }

        private void UserControl3_Load(object sender, EventArgs e)
        {
            list = HeHocBUS.getAllHeHoc();
            loadlist(list);
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            using (var AddHeHocForm = new AddHeHoc())
            {
                if (AddHeHocForm.ShowDialog() == DialogResult.OK)
                {
                    list = HeHocBUS.getAllHeHoc();
                    loadlist(list);
                }
            }
        }

        private void dataGridHeHocView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridHeHocView.Columns["more"].Index && e.RowIndex >= 0)
            {
                var selectColumn = dataGridHeHocView.Rows[e.RowIndex];
                HeHocDTO item = new HeHocDTO();
                if (selectColumn.Cells["id_hehoc"].Value != null)
                {
                    item.Id = int.Parse(selectColumn.Cells["id_hehoc"].Value.ToString());
                    item.Name = selectColumn.Cells["name_hehoc"].Value.ToString();
                    item.status = 1;
                    using (var update_hehoc = new UpdateHeHoc(item))
                    {
                        if (update_hehoc.ShowDialog() == DialogResult.OK)
                        {
                            List<HeHocDTO> list = HeHocBUS.getAllHeHoc();
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

        private void dataGridHeHocView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dataGridHeHocView.Columns["more"].Index && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                Image img = Image.FromFile("../../../Resources/edit.png");
                int x = e.CellBounds.Left + (e.CellBounds.Width - img.Width) / 2;
                int y = e.CellBounds.Top + (e.CellBounds.Height - img.Height) / 2;
                e.Graphics.DrawImage(img, new Rectangle(x, y, img.Width, img.Height));
                e.Handled = true;
            }
        }
        private void find_Click(object sender, EventArgs e)
        {

            List<HeHocDTO> list;
            if (textBox1.Text == "")
            {
                list = HeHocBUS.getAllHeHoc();
                loadlist(list);
            }
            else
            {
                list = HeHocBUS.findAll(textBox1.Text);
                if (list == null)
                {
                    MessageBox.Show("Giá trị không tồn tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    list = HeHocBUS.getAllHeHoc();
                    loadlist(list);
                }
                else
                {
                    loadlist(list);
                }
            }
        }
        public void Setlist(List<HeHocDTO> list)
        {
            if (list != null)
            {
                loadlist(list);
            }
            else
            {
                MessageBox.Show("Dữ liệu không tồn tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                list = HeHocBUS.getAllHeHoc();
                loadlist(list);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new HeHocSearch(this).Show();
        }
    }
}
