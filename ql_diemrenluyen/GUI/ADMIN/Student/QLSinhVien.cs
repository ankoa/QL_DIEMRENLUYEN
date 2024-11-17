using System.Collections.Generic;
using System.Windows.Forms;
using Org.BouncyCastle.Utilities;
using ql_diemrenluyen.BUS;
using ql_diemrenluyen.DAO;
using ql_diemrenluyen.DTO;

namespace QLDiemRenLuyen
{
    public partial class QLSinhVien : UserControl
    {
        private static SinhVienBUS SinhVienBUS = new SinhVienBUS();
        private List<SinhVienDTO> listStudent = new List<SinhVienDTO>();
        private static LopBUS LopBUS = new LopBUS();
        public QLSinhVien()
        {
            InitializeComponent();
            loadSVIntoTable(SinhVienBUS.GetAllStudents());
        }
        public void setListStudent(List<SinhVienDTO> listStudentSearch)
        {
            loadSVIntoTable(listStudentSearch);
        }
        private void loadSVIntoTable(List<SinhVienDTO> listStudentBUS)
        {
            listStudent = new List<SinhVienDTO>();
            listStudent = listStudentBUS;
            dataGridStudent.Rows.Clear();
            if (listStudent.Count > 0)
            {
                listStudent.ForEach(student =>
                {
                    if (student.status == 1)
                    {
                        var index = this.dataGridStudent.Rows.Add();
                        this.dataGridStudent.Rows[index].Cells[0].Value = student.Id;
                        this.dataGridStudent.Rows[index].Cells[1].Value = student.Name;
                        this.dataGridStudent.Rows[index].Cells[2].Value = student.toStringGender();
                        LopDTO lopDTO = new LopDTO();
                        lopDTO = LopBUS.GetLopByID(student.LopId);
                        this.dataGridStudent.Rows[index].Cells[3].Value = lopDTO.TenLop;
                        KhoaDTO khoaDTO = new KhoaDTO();
                        khoaDTO = KhoaBUS.GetKhoaByID(lopDTO.Khoa.Id);
                        this.dataGridStudent.Rows[index].Cells[4].Value = khoaDTO.TenKhoa;
                    }
                });
            }


            //dataGridStudent.DataSource = listStudent;
            //autoresize each column


        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void QLSinhVien_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridStudent.Columns["btnXemTT"].Index && e.RowIndex >= 0)
            {
                long maSV = (long)dataGridStudent.Rows[e.RowIndex].Cells[0].Value;
                ThongTinhSinhVien thongtinSVForm = new ThongTinhSinhVien(maSV, listStudent);
                thongtinSVForm.ShowDialog();
                loadSVIntoTable(SinhVienBUS.GetAllStudents());
            }
            if (e.ColumnIndex == dataGridStudent.Columns["btnXoa"].Index && e.RowIndex >= 0)
            {
                long maSV = (long)dataGridStudent.Rows[e.RowIndex].Cells[0].Value;

                DialogResult result = MessageBox.Show("Bạn có muốn xóa sinh viên này không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    SinhVienBUS.DeleteStudent(maSV);
                    MessageBox.Show("Xóa sinh viên thành công !");
                    loadSVIntoTable(SinhVienBUS.GetAllStudents());
                }
                else if (result == DialogResult.No)
                {
                    MessageBox.Show("Xóa không thành công ");
                }
                else
                {
                    MessageBox.Show("Xóa không thành công ");
                }
              

            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String str = txtSearch.Text.Trim();
            loadSVIntoTable(SinhVienBUS.basicSearch(str));
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            TimKiemSinhVien timKiemSinhVien = new TimKiemSinhVien(this, listStudent);
            timKiemSinhVien.ShowDialog();

        }

        private void btnThemSV_Click(object sender, EventArgs e)
        {

            ThongTinhSinhVien thongtinSVForm = new ThongTinhSinhVien(listStudent);
            thongtinSVForm.ShowDialog();
            loadSVIntoTable(SinhVienBUS.GetAllStudents());
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}