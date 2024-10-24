using AuthService.Helper;
using ql_diemrenluyen.BUS;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace ql_diemrenluyen.GUI
{
    public partial class FindEmail : Form
    {
        private bool isPasswordHidden = true;
        public FindEmail()
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

        private async void button1_Click(object sender, EventArgs e)
        {
            var username = inputUser.Text;
            var (account, accountType) = AccountBUS.findAccountByEmail(username);

            if (account == null)
            {
                MessageBox.Show("Không tìm thấy user");
            }
            else
            {
                pictureBox4.Visible = true;
                try
                {
                    var codeReset = RNG.GenerateSixDigitNumber().ToString();
                    //await SendMail.SendPasswordResetEmailAsync(username, codeReset);
                    PasswordResetBUS.AddPasswordReset(username, codeReset);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}");
                }
                finally
                {
                    pictureBox4.Visible = false;
                    this.Dispose();  // Ẩn form hiện tại
                    // Chuyển sang OTPForm và truyền username
                    ResetPass otpForm = new ResetPass(account, accountType);
                    otpForm.Show();  // Hiển thị form mới

                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        private void pictureBox5_Click(object sender, EventArgs e)
        {
            isPasswordHidden = !isPasswordHidden;

            //if (isPasswordHidden)
            //{
            //    // Ẩn mật khẩu
            //    inputPass.PasswordChar = '●';
            //    pictureBox5.Image = Properties.Resources.hidden;
            //}
            //else
            //{
            //    // Hiện mật khẩu
            //    inputPass.PasswordChar = '\0';
            //    pictureBox5.Image = Properties.Resources.view;
            //}
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ResetPass_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            if (lbl != null)
            {
                lbl.Font = new Font(lbl.Font, FontStyle.Underline); // Thêm gạch dưới
            }
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            if (lbl != null)
            {
                lbl.Font = new Font(lbl.Font, FontStyle.Regular); // Bỏ gạch dưới
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();  // Ẩn form hiện tại
            Login otpForm = new Login();

            // Đảm bảo rằng khi form mới đóng, form hiện tại được hiển thị lại
            //otpForm.FormClosed += (s, args) => this.Show();

            otpForm.Show();  // Hiển thị form mới
        }
    }
}
