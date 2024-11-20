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
    public partial class LopSearch : Form
    {
        UserControl2 main;
        public LopSearch(UserControl2 value)
        {
            InitializeComponent();
            List<KhoaDTO> listKhoa = KhoaBUS.GetAllKhoa();
            List<HeHocDTO> listHeHoc = HeHocBUS.getAllHeHoc();
            comboBox1.Items.Add("--Chọn--");
            comboBox2.Items.Add("--Chọn--");
            foreach (KhoaDTO item in listKhoa)
            {
                if (item.status == 1)
                {
                    comboBox1.Items.Add(item.TenKhoa);
                }
            }
            foreach (HeHocDTO item in listHeHoc)
            {
                if (item.status == 1)
                {
                    comboBox2.Items.Add(item.Name);
                }
            }
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
            if (comboBox2.Items.Count > 0)
            {
                comboBox2.SelectedIndex = 0;
            }
            main = value;
        }
        public List<LopDTO> Setlist()
        {
            String sql = "";
            if (textBox1.Text != "")
            {
                sql += " lop.id like '%" + textBox1.Text.ToString() + "%'";
                if(textBox2.Text != "" || comboBox1.SelectedIndex > 0 || comboBox2.SelectedIndex > 0)
                {
                    sql += " and";
                }
            }
            if (textBox2.Text != "")
            {
                sql += " lop.tenlop like '%" + textBox2.Text.ToString() + "%'";
                if (comboBox1.SelectedIndex > 0 || comboBox2.SelectedIndex > 0)
                {
                    sql += " and";
                }
            }
            if (comboBox1.SelectedIndex > 0)
            {
                sql += " lop.khoa_id =" + KhoaBUS.GetKhoaByName(comboBox1.Text).Id.ToString();
                if (comboBox2.SelectedIndex > 0)
                {
                    sql += " and";
                }
            }
            if (comboBox2.SelectedIndex > 0)
            {
                sql += " lop.hedaotao =" + HeHocBUS.GetHeHocByName(comboBox2.Text).Id.ToString();
            }
            if (sql == "")
            {
                return LopBUS.getAllLop();
            }
            return LopBUS.GetListBySearch(sql);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            main.Setlist(Setlist());
            this.Close();
        }
    }
}
