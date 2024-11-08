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
using ql_diemrenluyen.DAO;
using ql_diemrenluyen.DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLDiemRenLuyen
{
    public partial class ThongTinhSinhVien : Form
    {
        private static SinhVienBUS SinhVienBUS = new SinhVienBUS();
        //private static List<SinhVienDTO> listStudent = new List<SinhVienDTO>();
        private static LopBUS LopBUS = new LopBUS();
        private static KhoaBUS KhoaBUS = new KhoaBUS();
        private AccountBUS AccountBUS = new AccountBUS();
        private List<SinhVienDTO> listStudent = new List<SinhVienDTO>();
        private SinhVienDTO sinhVienEdit;
        public ThongTinhSinhVien(List<SinhVienDTO> listStudent)
        {
            InitializeComponent();
            dPNgaySinh.MaxDate = DateTime.Today.AddYears(-18);
            dPNgaySinh.MinDate = DateTime.Today.AddYears(-25);
            this.listStudent = listStudent;
            txtMaSV.ReadOnly = false;
            Dictionary<string, long> dict1 = new Dictionary<string, long>()
            {
                 {"Không có",0 },
                 {"QL ĐRL Khoa",1 },
                 {"QL ĐRL Trường",2 }

            };

            cbChucVu.DataSource = new BindingSource(dict1, null);
            cbChucVu.DisplayMember = "Key";
            cbChucVu.ValueMember = "Value";
            cbChucVu.SelectedIndex = 0;
            cbChucVu.DropDownStyle = ComboBoxStyle.DropDownList;

            Dictionary<string, long> dict = new Dictionary<string, long>()
            {
                 {"Nữ",0 },
                 {"Nam",1 }

            };

            cBGioiTinh.DataSource = new BindingSource(dict, null);
            cBGioiTinh.DisplayMember = "Key";
            cBGioiTinh.ValueMember = "Value";
            cBGioiTinh.SelectedIndex = 0;
            cBGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;

            var dataSource = new List<LopDTO>();
            dataSource = LopBUS.GetAllLop();
            cBLop.DataSource = dataSource;
            cBLop.DisplayMember = "TenLop";
            cBLop.ValueMember = "Id";
            cBLop.DropDownStyle = ComboBoxStyle.DropDownList;


            KhoaDTO khoaDto = new KhoaDTO();
            LopDTO lopDTO = new LopDTO();
            lopDTO = cBLop.SelectedItem as LopDTO;

            khoaDto = KhoaBUS.GetKhoaByID(lopDTO.KhoaId);
            txtKhoa.Text = khoaDto.TenKhoa;
        }
        public ThongTinhSinhVien(long idSV, List<SinhVienDTO> listStudent)
        {
            InitializeComponent();
            this.listStudent = listStudent;
            btnThem.Text = "Sửa";
            SinhVienDTO sinhVien = new SinhVienDTO();
            sinhVien = SinhVienBUS.GetStudentById(idSV);
            sinhVienEdit = sinhVien;
            txtMaSV.Text = sinhVien.Id.ToString();
            txtHoTen.Text = sinhVien.Name;

            dPNgaySinh.Value = sinhVien.NgaySinh;
            txtEmail.Text = sinhVien.Email;

            Dictionary<string, long> dict1 = new Dictionary<string, long>()
            {
                 {"Không có",0 },
                 {"QL ĐRL Khoa",1 },
                 {"QL ĐRL Trường",2 }

            };

            cbChucVu.DataSource = new BindingSource(dict1, null);
            cbChucVu.DisplayMember = "Key";
            cbChucVu.ValueMember = "Value";
            cbChucVu.SelectedIndex = sinhVien.ChucVu;
            cbChucVu.DropDownStyle = ComboBoxStyle.DropDownList;


            LopDTO lopDTO = new LopDTO();
            lopDTO = LopBUS.GetLopByID(sinhVien.LopId);
            KhoaDTO khoaDTO = new KhoaDTO();
            khoaDTO = KhoaBUS.GetKhoaByID(lopDTO.KhoaId);
            //txtLop.Text = lopDTO.TenLop;
            //txtKhoa.Text = khoaDTO.TenKhoa;
            Dictionary<string, long> dict = new Dictionary<string, long>()
            {
                 {"Nữ",0 },
                 {"Nam",1 }

            };

            cBGioiTinh.DataSource = new BindingSource(dict, null);
            cBGioiTinh.DisplayMember = "Key";
            cBGioiTinh.ValueMember = "Value";
            cBGioiTinh.SelectedIndex = sinhVien.GioiTinh;
            cBGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;

            var dataSource = new List<LopDTO>();
            dataSource = LopBUS.GetAllLop();
            cBLop.DataSource = dataSource;
            cBLop.DisplayMember = "TenLop";
            cBLop.ValueMember = "Id";
            cBLop.DropDownStyle = ComboBoxStyle.DropDownList;
            cBLop.SelectedValue = lopDTO.Id;

            KhoaDTO khoaDto = new KhoaDTO();
            khoaDto = KhoaBUS.GetKhoaByID(lopDTO.KhoaId);
            txtKhoa.Text = khoaDto.TenKhoa;




        }
        private Boolean checkExistMaSV(long id)
        {
            foreach (SinhVienDTO sinhVien in this.listStudent)
            {
                if (sinhVien.Id == id) return true;
            }
            return false;
        }
        private Boolean checkEmailExist(string email)
        {
            foreach (SinhVienDTO sinhVien in this.listStudent)
            {
                if (sinhVien.Email.Equals(email))
                    if (sinhVienEdit == null)       //Nếu là thêm sinh viên 
                        return true;
                    else                       //Nếu là sửa sinh viên
                    {
                        if (sinhVienEdit.Email.Equals(email) == false) return true;       // Nếu email được sửa lại trùng với email đã có và không phải là email trước khi sửa 
                    }
            }
            return false;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtNgaySinh_TextChanged(object sender, EventArgs e)
        {

        }

        private void cBLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            KhoaDTO khoaDto = new KhoaDTO();
            LopDTO lopDTO = new LopDTO();
            lopDTO = cBLop.SelectedItem as LopDTO;
            khoaDto = KhoaBUS.GetKhoaByID(lopDTO.KhoaId);
            txtKhoa.Text = khoaDto.TenKhoa;

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaSV.Text.Trim().Length != 10)

            {
                MessageBox.Show("Mã số sinh viên không hợp lệ ! (Yêu cầu : 10 số tự nhiên )");
                return;
            }
            else
            {
                if ((sinhVienEdit == null) & (checkExistMaSV(long.Parse(txtMaSV.Text.Trim())) == true))        // Nếu là Thêm và mã sinh viên có tồn tại
                {
                    MessageBox.Show("Mã số sinh viên tồn tại trong hệ thống ");
                    return;
                }
            }

            if (txtHoTen.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng không để trống họ và tên");
                return;
            }
            else
            {
                Regex r = new Regex("[0-9\\.,\\-_()\\[\\]{}\\:;?!@#\\$%\\^&\\*\\+=/\\\\|<>~\"']");
                if (r.IsMatch(txtHoTen.Text.Trim()))
                {
                    MessageBox.Show("Họ tên không hợp lệ !");
                    return;
                }

            }

            if (txtEmail.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng không để trống email");
                return;
            }
            else
            {
                Regex r = new Regex("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$");
                if (!r.IsMatch(txtEmail.Text.Trim()))
                {
                    MessageBox.Show("Email không hợp lệ !");
                    return;
                }
                if (checkEmailExist(txtEmail.Text.Trim()))
                {
                    MessageBox.Show("Email đã tồn tại trong hệ thống dữ liệu ! Vui lòng nhập email hợp lệ ");
                    return;
                }
            }
            SinhVienDTO sinhVienAction = new SinhVienDTO();
            sinhVienAction.Id = long.Parse(txtMaSV.Text.Trim());
            sinhVienAction.Name = txtHoTen.Text.Trim();
            sinhVienAction.GioiTinh = int.Parse(cBGioiTinh.SelectedValue.ToString());
            sinhVienAction.ChucVu = int.Parse(cbChucVu.SelectedValue.ToString());
            sinhVienAction.LopId = long.Parse(cBLop.SelectedValue.ToString());
            sinhVienAction.Email = txtEmail.Text.Trim();
            sinhVienAction.NgaySinh = dPNgaySinh.Value;



            Boolean status = false;
            if (sinhVienEdit == null)              // Nếu là thêm mới sinh viên
            {
                status = SinhVienBUS.AddStudent(sinhVienAction);
                AccountDTO accountDTO = new AccountDTO();
                accountDTO.Id = sinhVienAction.Id;
                accountDTO.Password = sinhVienAction.NgaySinh.ToString("yyyy-MM-dd");
                AccountBUS.AddAccountSV(accountDTO);


            }
            else
            {
                status = SinhVienBUS.UpdateStudent(sinhVienAction);
            }
            if (status == true)
                MessageBox.Show(btnThem.Text + " thông tin sinh viên thành công !");
            else
                MessageBox.Show(btnThem.Text + " thông tin sinh viên không thành công !");
            this.Dispose();
        }

        private void txtMaSV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ngăn không cho ký tự không hợp lệ được nhập vào
            }
        }

        private void ThongTinhSinhVien_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
