using ql_diemrenluyen.BUS;
using ql_diemrenluyen.DTO;
using System.Net.Mail;

namespace ql_diemrenluyen.GUI.ADMIN.Teacher
{
    public partial class GiangVienDetailForm : Form
    {
        private long currentGiangVienId;
        private DataGridView table;
        private QLGiangVien mainForm;
        private string status;

        private Dictionary<int, string> statusMapping = new Dictionary<int, string>
        {
            { 1, "Hoạt động" },
            { 0, "Không hoạt động" }
        };

        public GiangVienDetailForm(long id, string name, string email, string chucvu, string khoa, int status, DataGridView dataGridView, QLGiangVien gvform)
        {
            table = dataGridView;
            mainForm = gvform;
            InitializeComponent();

            // Set các giá trị ban đầu
            currentGiangVienId = id;
            txtId.Text = id.ToString();
            txtId.ReadOnly = true; // Không cho phép chỉnh sửa ID
            txtTenGV.Text = name;
            txtEmail.Text = email;
            comboBoxChucVu.SelectedIndex = comboBoxChucVu.Items.IndexOf(chucvu);
            txtKhoa.Text = khoa;

            this.status = statusMapping[status];
            comboBoxTrangThai.SelectedItem = this.status;

            
            btnDelete.Enabled = this.status == "Hoạt động";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(txtTenGV.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(comboBoxChucVu.Text) || string.IsNullOrWhiteSpace(txtKhoa.Text) ||
                comboBoxTrangThai.SelectedItem == null || !IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng kiểm tra lại thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác nhận cập nhật
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn cập nhật thông tin giảng viên không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                UpdateGiangVienInfo();
            }
        }

        private void UpdateGiangVienInfo()
        {
            var giangVien = new GiangVienDTO
            {
                Id = currentGiangVienId,
                Name = txtTenGV.Text,
                Email = txtEmail.Text,
                ChucVu = comboBoxChucVu.SelectedItem?.ToString(),
                KhoaId = txtKhoa.Text,
                Status = comboBoxTrangThai.SelectedItem?.ToString() == "Hoạt động" ? 1 : 0
            };

            bool result = GiangVienBUS.UpdateGiangVien(giangVien);

            if (result)
            {
                MessageBox.Show("Cập nhật thông tin giảng viên thành công!");
                QLGiangVien.LoadGiangVienList(table); 
                this.Close();
            }
            else
            {
                MessageBox.Show("Cập nhật thông tin giảng viên không thành công. Vui lòng kiểm tra lại!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn ngừng hoạt động giảng viên này?",
                                                  "Xác nhận",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                bool isDeactivated = GiangVienBUS.DeleteGiangVien(currentGiangVienId);

                if (isDeactivated)
                {
                    MessageBox.Show("Giảng viên đã được ngừng hoạt động.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    QLGiangVien.LoadGiangVienList(table);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra khi ngừng hoạt động giảng viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                return new MailAddress(email).Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void GiangVienDetailForm_Load(object sender, EventArgs e)
        {
            btnDelete.Enabled = status == "Hoạt động";
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

            // Tạo viền
            int borderWidth = 5;
            Color borderColor = Color.Black;

            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
                e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, this.ClientSize.Width - borderWidth, this.ClientSize.Height - borderWidth));
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
