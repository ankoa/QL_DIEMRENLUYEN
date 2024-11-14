using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ql_diemrenluyen.BUS;
using ql_diemrenluyen.DAO;
using ql_diemrenluyen.DTO;

namespace QLDiemRenLuyen
{
    public partial class TimKiemSinhVien : Form
    {
        private QLSinhVien parentForm;
        private static SinhVienBUS SinhVienBUS = new SinhVienBUS();
        private static LopBUS LopBUS = new LopBUS();
        private static KhoaBUS KhoaBUS = new KhoaBUS();
        private List<KhoaDTO> listKhoa = new List<KhoaDTO>();
        private List<LopDTO> listLop = new List<LopDTO>();

        private List<SinhVienDTO> listStudent = new List<SinhVienDTO>();
        public TimKiemSinhVien(QLSinhVien parent,List<SinhVienDTO> listStudent)
        {
            this.listStudent = listStudent;
            InitializeComponent();
            parentForm = parent;
            var dataSource = new List<LopDTO>();
            LopDTO lopTatCa = new LopDTO();
            lopTatCa.Id = -1;
            lopTatCa.TenLop = "Tất cả";
            listLop = LopBUS.getAllLop();
            listLop.Insert(0, lopTatCa);
            dataSource = listLop;
            cBLop.DataSource = dataSource;
            cBLop.DisplayMember = "TenLop";
            cBLop.ValueMember = "Id";
            cBLop.DropDownStyle = ComboBoxStyle.DropDownList;



            var dataSourceKhoa = new List<KhoaDTO>();
            KhoaDTO khoaDto = new KhoaDTO();
            khoaDto.Id = -1;
            khoaDto.TenKhoa = "Tất cả";

            listKhoa = KhoaBUS.GetAllKhoa();
            listKhoa.Insert(0, khoaDto);
            dataSourceKhoa = listKhoa;
            cBKhoa.DataSource = dataSourceKhoa;
            cBKhoa.DisplayMember = "TenKhoa";
            cBKhoa.ValueMember = "Id";

            cBKhoa.SelectedIndex = 0;
            cBKhoa.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        //private void setValueForListStatic()
        //{
        //    if ((listKhoa == null) || (listLop == null))
        //    {
        //        listLop = new List<LopDTO>();
        //        listLop = LopBUS.GetAllLop();

        //        KhoaDTO khoaDto = new KhoaDTO();                          // gán list Khoa
        //        khoaDto.Id = -1;
        //        khoaDto.TenKhoa = "Tất cả";
        //        List<KhoaDTO> listKhoa = new List<KhoaDTO>();
        //        listKhoa = KhoaBUS.GetAllKhoa();
        //        listKhoa.Insert(0, khoaDto);


        //    }
        //}
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private List<LopDTO> filterLopByKhoa()
        {
            if (cBKhoa.SelectedIndex != 0)
            {

                List<LopDTO> list = new List<LopDTO>();

                KhoaDTO khoaDTO = new KhoaDTO();
                khoaDTO = cBKhoa.SelectedItem as KhoaDTO;

                foreach (LopDTO lop in listLop)
                {
                    if (lop.KhoaId == khoaDTO.Id)
                    {
                        list.Add(lop);
                    }
                }
                LopDTO lopTatCa = new LopDTO();
                lopTatCa.Id = -1;
                lopTatCa.TenLop = "Tất cả";
                list.Insert(0, lopTatCa);
                return list;
            }

            return listLop;
        }

        private void cBKhoa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var dataSource = new List<LopDTO>();


            dataSource = filterLopByKhoa();
            if (cBLop.DataSource != null)
                cBLop.DataSource = null;
            cBLop.DataSource = dataSource;
            cBLop.DisplayMember = "TenLop";
            cBLop.ValueMember = "Id";
            cBLop.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void cBLop_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cBLop.SelectedIndex != 0)
            {
                LopDTO lopDTO = new LopDTO();
                lopDTO = cBLop.SelectedItem as LopDTO;

                cBKhoa.SelectedValue = lopDTO.KhoaId;
            }

        }

        private void txtMaSV_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMaSV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ngăn không cho ký tự không hợp lệ được nhập vào
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtMaSV.Text.Trim().Length > 10)

            {
                MessageBox.Show("Mã số sinh viên tìm kiếm không được quá 10 số tự nhiên !");
                return;
            }
            Regex r = new Regex("[0-9\\.,\\-_()\\[\\]{}\\:;?!@#\\$%\\^&\\*\\+=/\\\\|<>~\"']");
            if (r.IsMatch(txtHoTen.Text.Trim()))
               {
                    MessageBox.Show("Họ tên không chứa số và ký tự đặc biệt !");
                    return;
               }

            
            MessageBox.Show("Tìm kiếm thành công !");
            String maSV =txtMaSV.Text.Trim();
            String hoTen= txtHoTen.Text.Trim();
            long lopID= long.Parse(cBLop.SelectedValue.ToString());
            long khoaID =long.Parse(cBKhoa.SelectedValue.ToString());
            parentForm.setListStudent(SinhVienBUS.advancedSearch(maSV, hoTen, lopID, khoaID));
            this.Dispose();
        }
    }
}
