using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ql_diemrenluyen.BUS;
using ql_diemrenluyen.DTO;

namespace ql_diemrenluyen.GUI.ADMIN.KhoaLop
{
    public partial class AddLop : Form
    {
        public AddLop()
        {
            InitializeComponent();
            List<KhoaDTO> khoa_list = KhoaBUS.GetAllKhoa();
            List<HeHocDTO> hehoc_list = HeHocBUS.getAllHeHoc();
            Khoa_cbb.Items.Add("--Chọn--");
            Hdt_cbb.Items.Add("--Chọn--");
            foreach (KhoaDTO khoa in khoa_list)
            {
                if (khoa.status == 1)
                {
                    Khoa_cbb.Items.Add(khoa.TenKhoa);
                }
            }
            foreach (HeHocDTO hehoc in hehoc_list)
            {
                if (hehoc.status == 1)
                {
                    Hdt_cbb.Items.Add(hehoc.Name);
                }

            }
            if (Khoa_cbb.Items.Count > 0)
            {
                Khoa_cbb.SelectedIndex = 0;
            }
            if (Hdt_cbb.Items.Count > 0)
            {
                Hdt_cbb.SelectedIndex = 0;
            }
        }
        private bool check(String value)
        {
            bool rs = true;
            bool strResult = Regex.IsMatch(value, @"[^a-zA-Z0-9" + " " + "]");
            if (value == "")
            {
                MessageBox.Show("Không được để trống dữ liệu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rs = false;
            }
            else if (strResult)
            {
                MessageBox.Show("Dữ liệu nhập không hợp lệ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rs = false;
            }
            return rs;
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            if (check(text_lop.Text))
            {
                if(Khoa_cbb.SelectedIndex > 0)
                {
                    if(Hdt_cbb.SelectedIndex > 0)
                    {
                        List<LopDTO> list = LopBUS.getAllLop();
                        KhoaDTO khoa = KhoaBUS.GetKhoaByName(Khoa_cbb.Text.ToString());
                        HeHocDTO hehoc = HeHocBUS.GetHeHocByName(Hdt_cbb.Text.ToString());
                        LopDTO value = new LopDTO();
                        LopDTO index = list[list.Count - 1];
                        value.Id = index.Id + 1;
                        value.TenLop = text_lop.Text;
                        value.Khoa = khoa;
                        value.HeDaoTao = hehoc;
                        value.CreatedAt = DateTime.Now;
                        value.UpdatedAt = DateTime.Now;
                        value.status = 1;
                        bool isAdded = LopBUS.AddLop(value);
                        if (isAdded)
                        {
                            MessageBox.Show("Thêm hệ học thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không được để trống dữ liệu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Không được để trống dữ liệu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
