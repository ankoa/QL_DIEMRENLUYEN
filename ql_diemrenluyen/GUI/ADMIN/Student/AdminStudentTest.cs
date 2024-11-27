using QLDiemRenLuyen;

namespace ql_diemrenluyen.GUI.ADMIN.Student
{
    public partial class AdminStudentTest : Form
    {
        public AdminStudentTest()
        {
            InitializeComponent();
            QLSinhVien qLSinhVien = new QLSinhVien();
            qLSinhVien.Dock = DockStyle.Fill;
            this.Controls.Add(qLSinhVien);
            //this.Dock = DockStyle.Fill;
        }

        private void AdminStudentTest_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;

            this.Dock = DockStyle.Fill;
            this.ControlBox = false;

        }
    }
}
