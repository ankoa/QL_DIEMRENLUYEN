using System.Windows.Forms;
using ql_diemrenluyen.BUS;
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

        private void loadSVIntoTable(List<SinhVienDTO> listStudentBUS)
        {
            listStudent=new List<SinhVienDTO>();
            listStudent = listStudentBUS;
            dataGridStudent.Rows.Clear();
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
                    khoaDTO = KhoaBUS.GetKhoaByID(lopDTO.KhoaId);
                    this.dataGridStudent.Rows[index].Cells[4].Value = khoaDTO.TenKhoa;
                }
            });


            //dataGridStudent.DataSource = listStudent;
            //autoresize each column

            dataGridStudent.AutoResizeColumn(0);

            dataGridStudent.AutoResizeColumn(1);

            dataGridStudent.AutoResizeColumn(2);
            dataGridStudent.AutoResizeColumn(3);
            dataGridStudent.AutoResizeColumn(4);
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
                ThongTinhSinhVien thongtinSVForm = new ThongTinhSinhVien(maSV,listStudent);
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

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnThemSV_Click(object sender, EventArgs e)
        {

            ThongTinhSinhVien thongtinSVForm = new ThongTinhSinhVien(listStudent);
            thongtinSVForm.ShowDialog();
            loadSVIntoTable(SinhVienBUS.GetAllStudents());
        }
    }
}
