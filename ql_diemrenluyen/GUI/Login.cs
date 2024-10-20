using ql_diemrenluyen.BUS;
using ql_diemrenluyen.DTO;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace ql_diemrenluyen.GUI
{
    public partial class Login : Form
    {
        private bool isPasswordHidden = true;
        public Login()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.MouseDown += new MouseEventHandler(Form_MouseDown);
            this.Region = new Region(CreateRoundedRectanglePath(this.ClientRectangle, 30));
        }

        // Hàm tạo GraphicsPath với góc bo tròn
        private GraphicsPath CreateRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;

            // Góc trên-trái
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            // Góc trên-phải
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            // Góc dưới-phải
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            // Góc dưới-trái
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);

            path.CloseFigure(); // Đóng hình
            return path;
        }

        // DllImport để sử dụng API Windows
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0x112, 0xf012, 0);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var username = inputUser.Text;
            var password = inputPass.Text;
            AccountDTO accountLogin = AccountBUS.Login(username, password);
            if (accountLogin == null)
            {
                MessageBox.Show("ko");
            }
            else
            {
                MessageBox.Show("ok");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void pictureBox5_Click(object sender, EventArgs e)
        {
            isPasswordHidden = !isPasswordHidden;

            if (isPasswordHidden)
            {
                // Ẩn mật khẩu
                inputPass.PasswordChar = '●';
                pictureBox5.Image = Properties.Resources.hidden;
            }
            else
            {
                // Hiện mật khẩu
                inputPass.PasswordChar = '\0';
                pictureBox5.Image = Properties.Resources.view;
            }
        }

    }
}
