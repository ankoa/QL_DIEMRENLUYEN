using ql_diemrenluyen.BUS;
using ql_diemrenluyen.DTO;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace ql_diemrenluyen.GUI
{
    public partial class ChangePassword : Form
    {
        private bool isPasswordHidden = true;
        string id;
        public ChangePassword(string id)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.MouseDown += new MouseEventHandler(Form_MouseDown);
            this.Region = new Region(CreateRoundedRectanglePath(this.ClientRectangle, 30));
            oldColor = btnLogin.BackColor;
            this.id = id;
        }

        public async Task RunImageAnalysis(string imagePath)
        {
            try
            {
                List<string> labels = await ImageAnalysisService.AnalyzeImage(imagePath);

                // Chỉ hiển thị thông báo nếu labels là null hoặc rỗng
                if (labels == null || labels.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy nhãn nào.");
                    return; // Thoát sớm nếu không có nhãn
                }

                string result = string.Join(", ", labels);
                MessageBox.Show($"Nội dung ảnh: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                MessageBox.Show($"Lỗi: {ex.Message}"); // Hiển thị lỗi cụ thể
            }
        }



        Color oldColor;
        Color newColor = Color.FromArgb(0, Color.MediumAquamarine);  // your pick, including Black
        int alpha = 0;

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            alpha = 0;
            timer1.Interval = 15;
            timer1.Start();
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            timer1.Stop();
            btnLogin.BackColor = oldColor;
            btnLogin.ForeColor = Color.Black;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            alpha += 17;  // change this for greater or less speed
            btnLogin.BackColor = Color.FromArgb(alpha, newColor);
            if (alpha >= 255) timer1.Stop();
            if (btnLogin.BackColor.GetBrightness() < 0.3) btnLogin.ForeColor = Color.White;
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
            var oldpass = inputUser.Text;
            var newpass = inputPass.Text;
            var passconfirm = inputConfirm.Text;

            // Kiểm tra tài khoản với mật khẩu cũ
            AccountDTO accountLogin = AccountBUS.Login(id, oldpass);
            if (accountLogin == null)
            {
                MessageBox.Show("Mật khẩu cũ sai");
                return;
            }

            // Kiểm tra xác nhận mật khẩu mới
            if (newpass != passconfirm)
            {
                MessageBox.Show("Xác nhận mật khẩu sai");
                return;
            }

            // Thực hiện đổi mật khẩu
            bool isChanged = AccountBUS.ChangePassword(Convert.ToInt64(id), oldpass, newpass);
            if (!isChanged)
            {
                MessageBox.Show("Có lỗi khi đổi mật khẩu");
                return;
            }

            MessageBox.Show("Đổi mật khẩu thành công");
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
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

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();  // Ẩn form hiện tại
            FindEmail otpForm = new FindEmail();

            // Đảm bảo rằng khi form mới đóng, form hiện tại được hiển thị lại
            //otpForm.FormClosed += (s, args) => this.Show();

            otpForm.Show();  // Hiển thị form mới
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


        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
