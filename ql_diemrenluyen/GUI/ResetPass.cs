using ql_diemrenluyen.DTO;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace ql_diemrenluyen.GUI
{
    public partial class ResetPass : Form
    {
        private TextBox[] otpInputs;
        private bool isPasswordHidden = true;
        object user = null;
        private SinhVienDTO sinhvien;
        private GiangVienDTO giangvien;
        private readonly string accountType;

        public ResetPass(Object user, string accountType)
        {
            InitializeComponent();
            loadUser();
            InitializeOTPInputs();
            this.FormBorderStyle = FormBorderStyle.None;
            this.MouseDown += new MouseEventHandler(Form_MouseDown);
            this.Region = new Region(CreateRoundedRectanglePath(this.ClientRectangle, 30));
            this.user = user;
            this.accountType = accountType;
            this.inputUser.Enabled = false;
        }

        // Khởi tạo các TextBox OTP trong FlowLayoutPanel
        private void InitializeOTPInputs()
        {
            int otpLength = 6; // Số ký tự OTP
            otpInputs = new TextBox[otpLength];

            for (int i = 0; i < otpLength; i++)
            {
                TextBox txt = new TextBox
                {
                    Width = 40,
                    MaxLength = 1,
                    TextAlign = HorizontalAlignment.Center,
                    Font = new Font("Arial", 16),
                    Margin = new Padding(10)
                };

                txt.TextChanged += TextBox_TextChanged;
                txt.KeyDown += TextBox_KeyDown;
                otpInputs[i] = txt;
                flowLayoutPanel1.Controls.Add(txt); // Thêm vào FlowLayoutPanel
            }

            otpInputs[0].Focus(); // Đặt focus vào ô đầu tiên
        }

        // Khi nhập xong 1 ký tự, tự chuyển sang ô tiếp theo
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox currentTextBox = sender as TextBox;
            int index = Array.IndexOf(otpInputs, currentTextBox);

            if (!string.IsNullOrEmpty(currentTextBox.Text) && index < otpInputs.Length - 1)
            {
                otpInputs[index + 1].Focus();
            }
        }

        // Xử lý phím Backspace để quay lại ô trước đó
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox currentTextBox = sender as TextBox;
            int index = Array.IndexOf(otpInputs, currentTextBox);

            if (e.KeyCode == Keys.Back && string.IsNullOrEmpty(currentTextBox.Text) && index > 0)
            {
                otpInputs[index - 1].Focus();
                otpInputs[index - 1].SelectAll();
            }
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

        private async void loadUser()
        {
            if (user != null)
            {
                // Gán giá trị cho biến user dựa trên kiểu tài khoản
                if (accountType == "Sinh viên")
                {
                    user = user as SinhVienDTO;
                }
                else if (accountType == "Giảng viên")
                {
                    user = user as GiangVienDTO;
                }

                if (user is SinhVienDTO sinhVien)
                {
                    this.sinhvien = sinhVien;
                    this.inputUser.Text = this.sinhvien.Email;
                }
                else if (user is GiangVienDTO giangVien)
                {
                    this.giangvien = giangVien;
                    this.inputUser.Text = this.giangvien.Email;
                }
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //if (user != null)
            //{
            //    // Gán giá trị cho biến user dựa trên kiểu tài khoản
            //    if (accountType == "Sinh viên")
            //    {
            //        user = user as SinhVienDTO;
            //    }
            //    else if (accountType == "Giảng viên")
            //    {
            //        user = user as GiangVienDTO;
            //    }

            //    // Gửi email reset mật khẩu
            //    string otp = RNG.GenerateSixDigitNumber().ToString();
            //    if (user is SinhVienDTO sinhVien)
            //    {
            //        await SendMail.SendPasswordResetEmailAsync(sinhVien.Email, otp);
            //    }
            //    else if (user is GiangVienDTO giangVien)
            //    {
            //        await SendMail.SendPasswordResetEmailAsync(giangVien.Email, otp);
            //    }

            //    MessageBox.Show("Email đã được gửi thành công!");
            //}
            //else
            //{
            //    MessageBox.Show("Không tìm thấy tài khoản với email đã nhập.");
            //}
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}
