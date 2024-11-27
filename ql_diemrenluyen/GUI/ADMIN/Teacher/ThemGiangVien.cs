using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ql_diemrenluyen.BUS;
using ql_diemrenluyen.DTO;

namespace QLDiemRenLuyen
{
    public partial class ThemGiangVien : Form
    {
        private static GiangVienBUS GiangVienBUS = new GiangVienBUS();
        private static KhoaBUS KhoaBUS = new KhoaBUS();
        private AccountBUS AccountBUS = new AccountBUS();
        private List<GiangVienDTO> listGiangVien = new List<GiangVienDTO>();
        private GiangVienDTO giangVienEdit;

        public ThemGiangVien(List<GiangVienDTO> listGiangVien)
        {
            InitializeComponent();
            this.listGiangVien = listGiangVien;
            txtMaGV.ReadOnly = false;

            // ComboBox giới tính
            Dictionary<string, long> dictGioiTinh = new Dictionary<string, long>()
            {
                {"Nữ", 0},
                {"Nam", 1}
            };
            cBGioiTinh.DataSource = new BindingSource(dictGioiTinh, null);
            cBGioiTinh.DisplayMember = "Key";
            cBGioiTinh.ValueMember = "Value";
            cBGioiTinh.SelectedIndex = 0;
            cBGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;

            // ComboBox chức vụ
            Dictionary<string, int> dictChucVu = new Dictionary<string, int>()
            {
                {"Cố vấn", 0},
                {"Giảng viên", 1}
            };
            cBChucVu.DataSource = new BindingSource(dictChucVu, null);
            cBChucVu.DisplayMember = "Key";
            cBChucVu.ValueMember = "Value";
            cBChucVu.SelectedIndex = 0; // Mặc định là "Cố vấn"
            cBChucVu.DropDownStyle = ComboBoxStyle.DropDownList;

            // ComboBox khoa
            var khoaList = KhoaBUS.GetAllKhoa();
            cBKhoa.DataSource = khoaList;
            cBKhoa.DisplayMember = "TenKhoa";
            cBKhoa.ValueMember = "Id";
            cBKhoa.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public ThemGiangVien(long idGV, List<GiangVienDTO> listGiangVien)
        {
            InitializeComponent();
            this.listGiangVien = listGiangVien;
            btnThem.Text = "Sửa";
            GiangVienDTO giangVien = GiangVienBUS.GetGiangVienById(idGV);
            giangVienEdit = giangVien;

            txtMaGV.Text = giangVien.Id.ToString();
            txtHoTen.Text = giangVien.Name;
            txtEmail.Text = giangVien.Email;

            // ComboBox giới tính
            Dictionary<string, long> dictGioiTinh = new Dictionary<string, long>()
            {
                {"Nữ", 0},
                {"Nam", 1}
            };
            cBGioiTinh.DataSource = new BindingSource(dictGioiTinh, null);
            cBGioiTinh.DisplayMember = "Key";
            cBGioiTinh.ValueMember = "Value";
            cBGioiTinh.SelectedIndex = giangVien.GioiTinh;
            cBGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;

            // ComboBox chức vụ
            Dictionary<string, int> dictChucVu = new Dictionary<string, int>()
            {
                {"Cố vấn", 0},
                {"Giảng viên", 1}
            };
            cBChucVu.DataSource = new BindingSource(dictChucVu, null);
            cBChucVu.DisplayMember = "Key";
            cBChucVu.ValueMember = "Value";
            cBChucVu.SelectedIndex = giangVien.ChucVu; // Gán giá trị chức vụ hiện tại
            cBChucVu.DropDownStyle = ComboBoxStyle.DropDownList;

            // ComboBox khoa
            var khoaList = KhoaBUS.GetAllKhoa();
            cBKhoa.DataSource = khoaList;
            cBKhoa.DisplayMember = "TenKhoa";
            cBKhoa.ValueMember = "Id";
            cBKhoa.DropDownStyle = ComboBoxStyle.DropDownList;
            cBKhoa.SelectedValue = giangVien.KhoaId;
        }

        private Boolean checkExistMaGV(long id)
        {
            foreach (GiangVienDTO giangVien in this.listGiangVien)
            {
                if (giangVien.Id == id) return true;
            }
            return false;
        }

        private Boolean checkEmailExist(string email)
        {
            foreach (GiangVienDTO giangVien in this.listGiangVien)
            {
                if (giangVien.Email.Equals(email))
                {
                    if (giangVienEdit == null)
                        return true;
                    else if (!giangVienEdit.Email.Equals(email))
                        return true;
                }
            }
            return false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra mã giảng viên
            if (txtMaGV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng không để trống mã giảng viên!");
                return;
            }
            else if (checkExistMaGV(long.Parse(txtMaGV.Text.Trim())))
            {
                MessageBox.Show("Mã giảng viên đã tồn tại trong hệ thống!");
                return;
            }

            // Kiểm tra họ và tên
            if (txtHoTen.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng không để trống họ và tên!");
                return;
            }
            else
            {
                Regex r = new Regex("[0-9\\.,\\-_()\\[\\]{}\\:;?!@#\\$%\\^&\\*\\+=/\\\\|<>~\"']");
                if (r.IsMatch(txtHoTen.Text.Trim()))
                {
                    MessageBox.Show("Họ tên không hợp lệ!");
                    return;
                }
            }

            // Kiểm tra email
            if (txtEmail.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng không để trống email!");
                return;
            }
            else
            {
                Regex r = new Regex("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$");
                if (!r.IsMatch(txtEmail.Text.Trim()))
                {
                    MessageBox.Show("Email không hợp lệ!");
                    return;
                }
                if (checkEmailExist(txtEmail.Text.Trim()))
                {
                    MessageBox.Show("Email đã tồn tại trong hệ thống!");
                    return;
                }
            }

            
            GiangVienDTO giangVienAction = new GiangVienDTO
            {
                Id = long.Parse(txtMaGV.Text.Trim()),
                Name = txtHoTen.Text.Trim(),
                GioiTinh = int.Parse(cBGioiTinh.SelectedValue.ToString()),
                ChucVu = int.Parse(cBChucVu.SelectedValue.ToString()), 
                KhoaId = long.Parse(cBKhoa.SelectedValue.ToString()),
                Email = txtEmail.Text.Trim()
            };

            Boolean status;
            if (giangVienEdit == null)
            {
                status = GiangVienBUS.AddGiangVien(giangVienAction);
                AccountDTO accountDTO = new AccountDTO
                {
                    Id = giangVienAction.Id,
                    Password = "defaultPassword" // Đặt mật khẩu mặc định
                };
                AccountBUS.AddAccountGV(accountDTO);
            }
            else
            {
                status = GiangVienBUS.UpdateGiangVien(giangVienAction);
            }

            MessageBox.Show(status ? btnThem.Text + " thông tin giảng viên thành công!" : btnThem.Text + " thông tin giảng viên không thành công!");
            this.Dispose();
        }

        private void txtMaGV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
