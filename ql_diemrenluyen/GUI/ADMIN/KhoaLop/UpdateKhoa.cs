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

namespace ql_diemrenluyen.GUI.ADMIN.KhoaLop
{
    public partial class UpdateKhoa : Form
    {
        KhoaDTO khoaDTO;
        public UpdateKhoa(KhoaDTO value)
        {
            InitializeComponent();
            khoaDTO = value;
            ma_lb.Text= khoaDTO.Id.ToString();
            create_lb.Text= khoaDTO.CreatedAt.ToString();
            update_lb.Text = khoaDTO.UpdatedAt.ToString();
            text_khoa.Text = khoaDTO.TenKhoa.ToString();
        }
        private bool check(String value)
        {
            bool rs = true;
            bool strResult = Regex.IsMatch(value, @"[^a-zA-Z0-9 ]+");
            if (value == "")
            {
                MessageBox.Show("Không được để trống dữ liệu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rs = false;
            }
            else if (isNumber(value))
            {
                MessageBox.Show("Dữ liệu nhập không hợp lệ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rs = false;
            }
            //else if (strResult)
            //{
            //    MessageBox.Show("Dữ liệu nhập không hợp lệ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    rs = false;
            //}
            return rs;
        }
        private bool isNumber(String value)
        {
            bool rs = true;
            foreach (char c in value)
            {
                if (!char.IsDigit(c))
                {
                    rs = false;
                }
            }
            return rs;
        }
        private void update_btn_Click(object sender, EventArgs e)
        {
            if (check(text_khoa.Text))
            {
                KhoaDTO value = new KhoaDTO();
                value.Id = khoaDTO.Id;
                value.TenKhoa = text_khoa.Text;
                value.CreatedAt = khoaDTO.CreatedAt;
                value.UpdatedAt = DateTime.Now;
                value.status = khoaDTO.status;
                bool isUpdate = KhoaBUS.UpdatedKhoa(value);
                if (isUpdate)
                {
                    MessageBox.Show("Cập nhật khoa thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK; // Đặt kết quả form là OK nếu thêm thành công
                    this.Close(); // Đóng form
                }
            }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            var rs = MessageBox.Show("Bạn có chắc muốn xóa khoa này chứ ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (rs == DialogResult.OK)
            {
                List<LopDTO> list = LopBUS.findByKhoaId(khoaDTO.TenKhoa);
                if(list != null)
                {
                    int dem = 0;
                    foreach (LopDTO item in list) { 
                        if(item.status != 0)
                        {
                            dem++;
                        }
                    }
                    if (dem > 0) {
                        MessageBox.Show("Khoa đang có các lớp học hoạt động. Xóa khoa không thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        bool isDeleted = KhoaBUS.DeleteKhoa(khoaDTO.Id);
                        if (isDeleted)
                        {
                            MessageBox.Show("Xóa khoa thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK; // Đặt kết quả form là OK nếu thêm thành công
                            this.Close(); // Đóng form
                        }
                    }

                }
                else
                {
                    bool isDeleted = KhoaBUS.DeleteKhoa(khoaDTO.Id);
                    if (isDeleted)
                    {
                        MessageBox.Show("Xóa khoa thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK; // Đặt kết quả form là OK nếu thêm thành công
                        this.Close(); // Đóng form
                    }
                }
                
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
