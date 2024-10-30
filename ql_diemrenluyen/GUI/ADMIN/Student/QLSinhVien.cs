using System.Windows.Forms;
using ql_diemrenluyen.BUS;
using ql_diemrenluyen.DTO;

namespace QLDiemRenLuyen
{
    public partial class QLSinhVien : UserControl
    {
        private static SinhVienBUS SinhVienBUS = new SinhVienBUS();
        private static List<SinhVienDTO> listStudent = new List<SinhVienDTO>();
        private static LopBUS LopBUS = new LopBUS();
        public QLSinhVien()
        {
            InitializeComponent();
            listStudent = SinhVienBUS.GetAllStudents();
            listStudent.ForEach(student => {
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
            });

            
            //dataGridStudent.DataSource = listStudent;
            //autoresize each column

            dataGridStudent.AutoResizeColumn(0);

            dataGridStudent.AutoResizeColumn(1);

            dataGridStudent.AutoResizeColumn(2);
        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void QLSinhVien_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex ==dataGridStudent.Columns["btnXemTT"].Index && e.RowIndex >= 0)
            {
                long maSV = (long)dataGridStudent.Rows[e.RowIndex].Cells[0].Value;
                ThongTinhSinhVien thongtinSVForm = new ThongTinhSinhVien(maSV);
                thongtinSVForm.ShowDialog();
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

       
    }
}
