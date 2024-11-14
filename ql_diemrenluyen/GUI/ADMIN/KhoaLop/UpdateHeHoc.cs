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
using ql_diemrenluyen.DTO;

namespace ql_diemrenluyen.GUI.ADMIN.KhoaLop
{
    public partial class UpdateHeHoc : Form
    {
        HeHocDTO hehoc;
        public UpdateHeHoc(HeHocDTO value)
        {
            InitializeComponent();
            hehoc = value;
            ma_lb.Text = hehoc.Id.ToString();
            text_hehoc.Text = hehoc.Name.ToString();
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
            if (check(text_hehoc.Text))
            {
                HeHocDTO value = new HeHocDTO();
                value.Id = hehoc.Id;
                value.Name = text_hehoc.Text;
                value.status = hehoc.status;
                bool isUpdate = HeHocBUS.UpdateHeHoc(value);
                if (isUpdate)
                {
                    MessageBox.Show("Cập nhật hệ học thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK; // Đặt kết quả form là OK nếu thêm thành công
                    this.Close(); // Đóng form
                }
            }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            var rs = MessageBox.Show("Bạn có chắc muốn xóa hệ học này chứ ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (rs == DialogResult.OK)
            {
                List<LopDTO> list = LopBUS.findByHeHoc(hehoc.Name);
                if (list != null) {
                    int dem = 0;
                    foreach (LopDTO item in list)
                    {
                        if (item.status != 0)
                        {
                            dem++;
                        }
                    }
                    if (dem > 0) {
                        MessageBox.Show("Hệ học đang có các lớp học hoạt động. Xóa hệ học không thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        bool isDeleted = HeHocBUS.DeleteHeHoc(hehoc.Id);
                        if (isDeleted)
                        {
                            MessageBox.Show("Xóa hệ học thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK; // Đặt kết quả form là OK nếu thêm thành công
                            this.Close(); // Đóng form
                        }
                    }
                }
                else
                {
                    bool isDeleted = HeHocBUS.DeleteHeHoc(hehoc.Id);
                    if (isDeleted)
                    {
                        MessageBox.Show("Xóa hệ học thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK; // Đặt kết quả form là OK nếu thêm thành công
                        this.Close(); // Đóng form
                    }
                }

               
            }
        }
    }
}
