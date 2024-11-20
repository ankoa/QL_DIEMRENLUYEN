using ql_diemrenluyen.BUS;
using ql_diemrenluyen.DTO;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ql_diemrenluyen.GUI.ADMIN.KhoaLop
{
    public partial class UpdateLop : Form
    {
        LopDTO lop;
        public UpdateLop(LopDTO value)
        {
            InitializeComponent();
            List<KhoaDTO> khoa_list = KhoaBUS.GetAllKhoa();
            List<HeHocDTO> hehoc_list = HeHocBUS.getAllHeHoc();
            lop = value;
            text_lop.Text = lop.TenLop.ToString();
            ib_lb.Text = lop.Id.ToString();
            created_lb.Text = lop.CreatedAt.ToString();
            updated_lb.Text = lop.UpdatedAt.ToString();
            Khoa_cbb.Items.Add("--Chọn--");
            Hdt_cbb.Items.Add("--Chọn--");
            foreach (KhoaDTO khoa in khoa_list)
            {
                if (khoa.status == 1)
                {
                    Khoa_cbb.Items.Add(khoa.TenKhoa);
                    if (Khoa_cbb.Text.Equals(lop.Khoa.TenKhoa))
                    {
                        Khoa_cbb.SelectedIndex = Khoa_cbb.Items.IndexOf(lop.Khoa.TenKhoa);
                    }
                }
            }
            foreach (HeHocDTO hehoc in hehoc_list)
            {
                if (hehoc.status == 1)
                {
                    Hdt_cbb.Items.Add(hehoc.Name);
                }

            }
            int khoa_index = Khoa_cbb.Items.IndexOf(lop.Khoa.TenKhoa);
            int hdt_index = Hdt_cbb.Items.IndexOf(lop.HeDaoTao.Name);
            if (khoa_index != -1)
            {
                Khoa_cbb.SelectedIndex = khoa_index;
            }
            if (hdt_index != -1)
            {
                Hdt_cbb.SelectedIndex = hdt_index;
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
            //else if (strResult)
            //{
            //    MessageBox.Show("Dữ liệu nhập không hợp lệ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    rs = false;
            //}
            return rs;
        }
        private void update_btn_Click(object sender, EventArgs e)
        {
            if (check(text_lop.Text))
            {
                if (Khoa_cbb.SelectedIndex > 0)
                {
                    if (Hdt_cbb.SelectedIndex > 0)
                    {
                        KhoaDTO khoa = KhoaBUS.GetKhoaByName(Khoa_cbb.Text.ToString());
                        HeHocDTO hehoc = HeHocBUS.GetHeHocByName(Hdt_cbb.Text.ToString());
                        LopDTO value = new LopDTO();
                        value.Id = lop.Id;
                        value.TenLop = text_lop.Text;
                        value.Khoa = khoa;
                        value.HeDaoTao = hehoc;
                        value.CreatedAt = lop.CreatedAt;
                        value.UpdatedAt = DateTime.Now;
                        value.status = 1;
                        bool isUpdate = LopBUS.UpdateLop(value);
                        if (isUpdate)
                        {
                            MessageBox.Show("Cập nhật hệ học thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void delete_lop_Click(object sender, EventArgs e)
        {
            var rs = MessageBox.Show("Bạn có chắc muốn xóa lớp này chứ ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (rs == DialogResult.OK)
            {
                bool isDeleted = LopBUS.DeleteLop(lop.Id);
                if (isDeleted)
                {
                    MessageBox.Show("Xóa lớp thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK; 
                    this.Close(); 
                }
            }
        }
    }
}
