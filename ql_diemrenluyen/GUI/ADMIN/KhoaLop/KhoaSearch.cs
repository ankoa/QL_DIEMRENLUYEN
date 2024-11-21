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
using ql_diemrenluyen.DTO;
using ql_diemrenluyen.BUS;

namespace ql_diemrenluyen.GUI.ADMIN.KhoaLop
{
    public partial class KhoaSearch : Form
    {
        UserControl1 main;
        public KhoaSearch(UserControl1 value)
        {
            InitializeComponent();
            List<KhoaDTO> list = KhoaBUS.GetAllKhoa();
            comboBox1.Items.Add("--Chọn--");
            foreach (KhoaDTO item in list)
            {
                if (item.status == 1)
                {
                    comboBox1.Items.Add(item.TenKhoa);
                }
            }
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
            main = value;
        }
        public List<KhoaDTO> getlist()
        {
            String sql = "";
            if (textBox1.Text != "")
            {
                sql += " khoa.id like '%" + textBox1.Text.ToString() + "%'";
                if (comboBox1.SelectedIndex > 0)
                {
                    sql += " and";
                }
            }
            if (comboBox1.SelectedIndex > 0)
            {
                sql += " khoa.tenkhoa like '%" + comboBox1.Text.ToString() + "%'";
            }
            
            if (sql == "")
            {
                return KhoaBUS.GetAllKhoa();
            }
            return KhoaBUS.GetListBySearch(sql);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            main.Setlist(getlist());
            this.Close();
        }
    }
}
