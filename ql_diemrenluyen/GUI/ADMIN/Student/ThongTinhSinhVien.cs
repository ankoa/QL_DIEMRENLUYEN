using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
        public ThongTinhSinhVien(long idSV)
        {
            InitializeComponent();
            SinhVienDTO sinhVien = new SinhVienDTO();
            sinhVien = SinhVienBUS.GetStudentById(idSV);
            txtMaSV.Text = sinhVien.Id.ToString();
            txtHoTen.Text = sinhVien.Name;

            dPNgaySinh.Value = sinhVien.NgaySinh;
            txtEmail.Text = sinhVien.Email;
            txtChucVu.Text = sinhVien.ChucVu.ToString();
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
            khoaDto = KhoaBUS.GetKhoaByID(lopDTO.Id);
            txtKhoa.Text = khoaDto.TenKhoa;




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
    }
}
