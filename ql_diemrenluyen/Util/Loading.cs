namespace ql_diemrenluyen.Helper
{
    public static class Loading
    {
        // Tạo PictureBox chứa ảnh loading và thêm vào Form
        public static PictureBox CreateLoadingControl(Form form)
        {
            PictureBox loading = new PictureBox
            {
                Size = new Size(100, 100), // Tăng kích thước ảnh loading
                Image = Properties.Resources.Rolling_1x_1_0s_200px_200px, // Ảnh loading từ Resources
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.Transparent, // Nền trong suốt
                Visible = false // Ẩn khi khởi tạo
            };

            // Căn giữa PictureBox trong Form
            CenterControl(loading, form);

            // Đảm bảo PictureBox luôn ở trên cùng
            loading.BringToFront();
            form.Controls.Add(loading); // Thêm vào form

            return loading;
        }

        // Căn giữa PictureBox trong Form
        private static void CenterControl(Control control, Form form)
        {
            control.Location = new Point(
                (form.ClientSize.Width - control.Width) / 2,
                (form.ClientSize.Height - control.Height) / 2
            );
        }

        // Hiển thị PictureBox loading và đảm bảo nó ở trên cùng
        public static void ShowLoading(PictureBox pictureBox)
        {
            if (pictureBox.InvokeRequired)
            {
                pictureBox.Invoke(new Action(() => ShowLoading(pictureBox)));
            }
            else
            {
                pictureBox.BringToFront(); // Đảm bảo luôn hiển thị trên cùng
                pictureBox.Visible = true;
                pictureBox.Update(); // Cập nhật UI ngay lập tức
            }
        }

        // Ẩn PictureBox loading
        public static void HideLoading(PictureBox pictureBox)
        {
            if (pictureBox.InvokeRequired)
            {
                pictureBox.Invoke(new Action(() => HideLoading(pictureBox)));
            }
            else
            {
                pictureBox.Visible = false;
            }
        }
    }
}