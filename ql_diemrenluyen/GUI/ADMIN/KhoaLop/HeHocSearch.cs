using ql_diemrenluyen.BUS;
using ql_diemrenluyen.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ql_diemrenluyen.GUI.ADMIN.KhoaLop
{
    public partial class HeHocSearch : Form
    {
        UserControl3 main;
        public HeHocSearch(UserControl3 value)
        {
            InitializeComponent();
            main = value;
            List<HeHocDTO> list = HeHocBUS.getAllHeHoc();
            comboBox1.Items.Add("--Chọn--");
            foreach (HeHocDTO item in list)
            {
                if (item.status == 1)
                {
                    comboBox1.Items.Add(item.Name);
                }
            }
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
        }
        public List<HeHocDTO> Setlist()
        {
            String sql = "";
            if (textBox1.Text != "")
            {
                sql += " hehoc.id like '%" + textBox1.Text + "%'";
                if (comboBox1.SelectedIndex > 0)
                {
                    sql += " and";
                }
            }
            if (comboBox1.SelectedIndex > 0)
            {
                sql += " hehoc.name like '%" + comboBox1.Text.ToString() + "%'";
            }
            if (sql == "")
            {
                return HeHocBUS.getAllHeHoc();
            }
            return HeHocBUS.GetListBySearch(sql);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            main.Setlist(Setlist());
            this.Close();
        }
    }
}
