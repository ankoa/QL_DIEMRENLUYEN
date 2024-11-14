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
    public partial class AddHeHoc : Form
    {
        public AddHeHoc()
        {
            InitializeComponent();
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
            else if (isNumber(value))
            {
                MessageBox.Show("Dữ liệu nhập không hợp lệ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rs = false;
            }
            else if (strResult)
            {
                MessageBox.Show("Dữ liệu nhập không hợp lệ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rs = false;
            }
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

        private void add_btn_Click(object sender, EventArgs e)
        {
            if (check(text_hehoc.Text))
            {
                List<HeHocDTO> list = HeHocBUS.getAllHeHoc();
                HeHocDTO value = new HeHocDTO();
                HeHocDTO index = list[list.Count - 1];
                value.Id = index.Id + 1;
                value.Name = text_hehoc.Text;
                value.status = 1;
                bool isAdded = HeHocBUS.AddHeHoc(value);
                if (isAdded)
                {
                    MessageBox.Show("Thêm hệ học thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK; 
                    this.Close(); 
                }
            }
        }

        private void reset_btn_Click(object sender, EventArgs e)
        {
            var rs = MessageBox.Show("Bạn có chắc muốn xóa trắng ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (rs == DialogResult.OK)
            {
                text_hehoc.Text = "";
            }
        }
    }
}

