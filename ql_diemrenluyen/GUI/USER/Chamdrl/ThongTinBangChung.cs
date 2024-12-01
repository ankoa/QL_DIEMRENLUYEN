namespace QLDiemRenLuyen
{
    public partial class ThongTinBangChung : Form
    {
        public Image SelectedImage { get; set; }
        public long TieuChiId { get; set; }
        public string Mota { get; set; }

        public ThongTinBangChung(long tieuChiId, string tenTieuChi, Image image, string mota)
        {
            InitializeComponent();
            label1.Text = tenTieuChi;
            this.TieuChiId = tieuChiId;
            this.SelectedImage = image;
            this.Mota = mota;
            txtMota.Text = mota;
            if (image != null)
            {
                pictureBox1.Image = image;
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
                // Lấy đường dẫn file
                string filePath = openFileDialog.FileName;
                pictureBox1.Image = System.Drawing.Image.FromFile(filePath);
                this.SelectedImage = Image.FromFile(openFileDialog.FileName);

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                // Tạo và hiển thị cửa sổ ImageViewerForm
                ImageViewerForm viewer = new ImageViewerForm(pictureBox1.Image);
                viewer.ShowDialog(); // Hiển thị dưới dạng dialog
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Mota = txtMota.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtMota_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
