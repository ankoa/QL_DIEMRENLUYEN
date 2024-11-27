using ql_diemrenluyen.BUS;
using ql_diemrenluyen.DTO;

namespace ql_diemrenluyen.GUI.ADMIN.Account
{
    public partial class AccountDetailsForm : Form
    {
        private long currentAccountId;
        private TaiKhoan mainForm;
        private DataGridView table;
        private long id;
        String status;
        public AccountDetailsForm(long id, string password, int role, string rememberToken, DateTime createdAt, DateTime updatedAt, string status, DataGridView dataGridView, TaiKhoan tkform)
        {
            this.BackColor = Color.Black;
            table = dataGridView;
            mainForm = tkform;
            this.id = id;
            this.status = status;
            InitializeComponent();

            // Set các giá trị cho các trường trong form
            txtId.Text = id.ToString();
            txtId.ReadOnly = true; // Không cho phép chỉnh sửa trường ID

            txtPassword.Text = password;
            txtRememberToken.Text = rememberToken;

            // Cài đặt DateTimePicker cho CreatedAt
            DateTime minValidDate = dtpCreatedAt.MinDate;
            dtpCreatedAt.Value = createdAt >= minValidDate ? createdAt : DateTime.Now;
            dtpCreatedAt.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dtpCreatedAt.Format = DateTimePickerFormat.Custom;
            dtpCreatedAt.Enabled = false; // Không cho phép chỉnh sửa CreatedAt

            // Cài đặt DateTimePicker cho UpdatedAt
            dtpUpdatedAt.Value = updatedAt >= minValidDate ? updatedAt : DateTime.Now;
            dtpUpdatedAt.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dtpUpdatedAt.Format = DateTimePickerFormat.Custom;

            // Tạo ComboBox cho Role
            cmbRole.Items.AddRange(new object[] {
        "ADMIN",
        "Sinh viên",
        "Giảng viên",
        "Cố vấn học tập",
        "Quản lý Khoa",
        "Quản lý Trường"
    });

            // Chọn giá trị trong ComboBox dựa trên role
            cmbRole.SelectedIndex = role;

            // Tải trạng thái vào ComboBox
            comboBox1.SelectedItem = status;
            comboBox1.Enabled = true; // Cho phép chọn trạng thái

            currentAccountId = id;

            // Hiển thị thông báo cảnh báo về trạng thái tài khoản
            //MessageBox.Show($"Trạng thái tài khoản: {status}", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            // Điều chỉnh trạng thái của nút Delete
            btnDelete.Enabled = status == "Hoạt động"; // Nếu tài khoản không phải "Hoạt động", cho phép xóa
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text) || cmbRole.SelectedIndex == -1 || comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;  // Dừng lại nếu có trường nào bị rỗng
            }

            string passwordValidationMessage = AccountBUS.IsPasswordValid(txtPassword.Text);
            if (!string.IsNullOrEmpty(passwordValidationMessage))  // Nếu có thông báo lỗi
            {
                MessageBox.Show(passwordValidationMessage, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;  // Dừng lại nếu mật khẩu không hợp lệ
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn cập nhật tài khoản không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                // Lấy role từ ComboBox
                int role = cmbRole.SelectedIndex switch
                {
                    0 => 0,  // "ADMIN"
                    1 => 1,  // "Sinh viên"
                    2 => 2,  // "Giảng viên"
                    3 => 3,  // "Cố vấn học tập"
                    4 => 4,  // "Quản lý Khoa"
                    5 => 5,  // "Quản lý Trường"
                };

                AccountDTO account = new AccountDTO
                {
                    Id = currentAccountId,
                    Password = txtPassword.Text,
                    Role = role,
                    Status = comboBox1.SelectedItem.ToString() == "Hoạt động" ? 1 : 0,
                    CreatedAt = dtpCreatedAt.Value,
                    UpdatedAt = DateTime.Now
                };

                bool result = AccountBUS.UpdateAccount(account);

                if (result)
                {
                    MessageBox.Show("Cập nhật tài khoản thành công!");

                    TaiKhoan.LoadAccountList(table);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cập nhật tài khoản không thành công. Vui lòng kiểm tra lại!");
                }
            }
        }
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Cấu hình border
            int borderWidth = 5; // Độ dày của border
            Color borderColor = Color.Black; // Màu của border (màu đen)

            // Vẽ border (viền thẳng, không bo góc)
            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None; // Tắt làm mịn (anti-aliasing)
                e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, this.ClientSize.Width - borderWidth, this.ClientSize.Height - borderWidth));
            }
        }


        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn ngừng hoạt động tài khoản này?",
                                  "Xác nhận",
                                  MessageBoxButtons.YesNo,
                                  MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                bool isDeactivated = AccountBUS.DeleteAccount(id);
                if (isDeactivated)
                {
                    MessageBox.Show("Tài khoản đã được ngừng hoạt động.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TaiKhoan.LoadAccountList(table);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra khi ngừng hoạt động tài khoản.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Hành động đã bị hủy bỏ.", "Hủy bỏ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void AccountDetailsForm_Load(object sender, EventArgs e)
        {

            btnDelete.Enabled = status == "Hoạt động"; // Nếu tài khoản không phải "Hoạt động", cho phép xóa
        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
