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
using ql_diemrenluyen.DTO;

namespace QLDiemRenLuyen
{
    public partial class ThongTinhSinhVien : Form
    {
        private static SinhVienBUS SinhVienBUS = new SinhVienBUS();
        //private static List<SinhVienDTO> listStudent = new List<SinhVienDTO>();
        private static LopBUS LopBUS = new LopBUS();
        public ThongTinhSinhVien(long idSV)
        {
            InitializeComponent();
            SinhVienDTO sinhVien = new SinhVienDTO();
            sinhVien = SinhVienBUS.GetStudentById(idSV);
            txtMaSV.Text = sinhVien.Id.ToString();
            txtHoTen.Text = sinhVien.Name;
            txtGioiTinh.Text = sinhVien.toStringGender();
            txtNgaySinh.Text = sinhVien.NgaySinh.ToString();
            txtEmail.Text = sinhVien.Email;
            txtChucVu.Text = sinhVien.ChucVu.ToString();
            LopDTO lopDTO = new LopDTO();
            lopDTO = LopBUS.GetLopByID(sinhVien.LopId);
            KhoaDTO khoaDTO = new KhoaDTO();
            khoaDTO = KhoaBUS.GetKhoaByID(lopDTO.KhoaId);
            txtLop.Text = lopDTO.TenLop;
            txtKhoa.Text = khoaDTO.TenKhoa;

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
    }
}
