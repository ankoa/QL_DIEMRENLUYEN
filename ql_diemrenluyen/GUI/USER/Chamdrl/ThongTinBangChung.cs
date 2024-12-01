using System.Net;

namespace QLDiemRenLuyen
{
    public partial class ThongTinBangChung : Form
    {
        public string SelectedImageUrl { get; set; }
        public long TieuChiId { get; set; }
        public string Mota { get; set; }
        public string filepath { get; set; }

        public ThongTinBangChung(long tieuChiId, string tenTieuChi, string imageUrl, string mota, int vaitro)
        {
            InitializeComponent();
            label1.Text = tenTieuChi;
            this.TieuChiId = tieuChiId;
            this.SelectedImageUrl = imageUrl;
            this.Mota = mota;
            txtMota.Text = mota;
            if (!string.IsNullOrEmpty(imageUrl))
            {
                try
                {
                    pictureBox1.Load(imageUrl); // Hiển thị hình ảnh từ URL
                }
                catch
                {
                    MessageBox.Show("Không thể tải ảnh từ URL.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (vaitro == 1)
            {
                button3.Visible = true;
                button2.Visible = true;
                txtMota.Enabled = true;
            }
            else
            {
                button3.Visible = false;
                button2.Visible = false;
                txtMota.Enabled = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtNgaySinh_TextChanged(object sender, EventArgs e)
        {

        }

        private void ThongTinhSinhVien_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Tạo hộp thoại chọn file
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif", // Lọc file hình ảnh
                Title = "Chọn hình ảnh"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn file và hiển thị
                string filePath = openFileDialog.FileName;
                pictureBox1.ImageLocation = filePath; // Hiển thị hình ảnh
                this.filepath = filePath; // Lưu đường dẫn ảnh
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(SelectedImageUrl))
            {
                // Hiển thị ảnh từ URL
                ImageViewerForm viewer = new ImageViewerForm(LoadImageFromUrl(SelectedImageUrl));
                viewer.ShowDialog(); // Hiển thị dưới dạng dialog
            }
        }

        private Image LoadImageFromUrl(string url)
        {
            try
            {
                using (var webClient = new WebClient())
                {
                    byte[] imageBytes = webClient.DownloadData(url); // Tải dữ liệu hình ảnh từ URL
                    using (var memoryStream = new MemoryStream(imageBytes))
                    {
                        return Image.FromStream(memoryStream); // Chuyển đổi byte[] thành Image
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải hình ảnh từ URL: " + ex.Message);
                return null;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.SelectedImageUrl = this.filepath;
            this.Mota = txtMota.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtMota_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Xóa thông tin hình ảnh và mô tả
            this.SelectedImageUrl = null;
            this.Mota = null;
            this.filepath = null;
            this.DialogResult = DialogResult.OK; // Thông báo đã xóa
            this.Close();
        }
    }
}
