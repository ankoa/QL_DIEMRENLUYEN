public class ImageViewerForm : Form
{
    private PictureBox pictureBox;
    private float zoomFactor = 1.0f; // Hệ số phóng to
    private bool isDragging = false; // Trạng thái kéo thả
    private Point dragStartPoint; // Vị trí chuột ban đầu

    public ImageViewerForm(Image image)
    {
        this.Text = "Xem hình ảnh";
        this.Size = new System.Drawing.Size(1200, 800);

        // Tạo PictureBox
        pictureBox = new PictureBox
        {
            Image = image,
            SizeMode = PictureBoxSizeMode.Zoom,
            Dock = DockStyle.None, // Cho phép thay đổi vị trí
            Width = (int)(image.Width * zoomFactor),
            Height = (int)(image.Height * zoomFactor),
            Left = 0,
            Top = 0
        };

        // Thêm PictureBox vào Form
        this.Controls.Add(pictureBox);

        // Bắt sự kiện MouseWheel để phóng to/thu nhỏ
        this.MouseWheel += ImageViewerForm_MouseWheel;

        // Bắt sự kiện kéo thả
        pictureBox.MouseDown += PictureBox_MouseDown;
        pictureBox.MouseMove += PictureBox_MouseMove;
        pictureBox.MouseUp += PictureBox_MouseUp;
    }

    private void ImageViewerForm_MouseWheel(object sender, MouseEventArgs e)
    {
        if (e.Delta > 0)
            zoomFactor += 0.1f; // Phóng to
        else if (e.Delta < 0)
            zoomFactor -= 0.1f; // Thu nhỏ

        zoomFactor = Math.Max(0.1f, Math.Min(zoomFactor, 5.0f));

        pictureBox.Width = (int)(pictureBox.Image.Width * zoomFactor);
        pictureBox.Height = (int)(pictureBox.Image.Height * zoomFactor);
    }

    private void PictureBox_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            isDragging = true;
            dragStartPoint = e.Location; // Lưu lại vị trí chuột khi bắt đầu kéo
        }
    }

    private void PictureBox_MouseMove(object sender, MouseEventArgs e)
    {
        if (isDragging)
        {
            // Di chuyển PictureBox theo chuột
            pictureBox.Left += e.X - dragStartPoint.X;
            pictureBox.Top += e.Y - dragStartPoint.Y;
        }
    }

    private void PictureBox_MouseUp(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            isDragging = false; // Kết thúc kéo
        }
    }
}
