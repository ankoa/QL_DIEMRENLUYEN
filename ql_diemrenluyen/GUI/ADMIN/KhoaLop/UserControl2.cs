using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ql_diemrenluyen.DTO;
using ql_diemrenluyen.BUS;

namespace ql_diemrenluyen.GUI.ADMIN.KhoaLop
{
    public partial class UserControl2 : UserControl
    {
        List<LopDTO> list;
        public UserControl2()
        {
            InitializeComponent();
            if (comboBox1.Items.Count > 0) {
                comboBox1.SelectedIndex = 0;
            }
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
                Image img = Image.FromFile("C:\\Users\\User\\Downloads\\edit.png");
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
                if (comboBox1.SelectedIndex == 0)
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
                else if (comboBox1.SelectedIndex == 1)
                {
                    list = LopBUS.findById(textBox1.Text);
                    if (list == null)
                    {
                        MessageBox.Show("Mã lớp không tồn tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        list = LopBUS.getAllLop();
                        loadlist(list);
                    }
                    else
                    {
                        loadlist(list);
                    }
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    list = LopBUS.findByName(textBox1.Text);
                    if (list == null)
                    {
                        MessageBox.Show("Tên không tồn tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        list = LopBUS.getAllLop();
                        loadlist(list);
                    }
                    else
                    {
                        loadlist(list);
                    }
                }
                else if (comboBox1.SelectedIndex == 3)
                {
                    list = LopBUS.findByKhoaId(textBox1.Text);
                    if (list == null)
                    {
                        MessageBox.Show("Khoa không tồn tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        list = LopBUS.getAllLop();
                        loadlist(list);
                    }
                    else
                    {
                        loadlist(list);
                        
                    }
                }
                else if (comboBox1.SelectedIndex == 4)
                {
                    list = LopBUS.findByHeHoc(textBox1.Text);
                    if (list == null)
                    {
                        MessageBox.Show("Hệ đào tạo không tồn tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        list = LopBUS.getAllLop();
                        loadlist(list);
                    }
                    else
                    {
                        loadlist(list);                        
                    }
                }
            }
        }
    }
}
