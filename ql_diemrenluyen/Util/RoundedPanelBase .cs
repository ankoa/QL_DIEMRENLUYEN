using System.Drawing.Drawing2D;

namespace ql_diemrenluyen.Util
{
    public class RoundedPanelBase : Panel
    {
        public int BorderRadius { get; set; } = 20; // Bán kính bo góc
        public Color BorderColor { get; set; } = Color.Gray; // Màu viền
        public int BorderSize { get; set; } = 1; // Độ dày viền

        public RoundedPanelBase()
        {
            this.DoubleBuffered = true; // Giảm nhấp nháy khi vẽ
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = this.ClientRectangle;
            rect.Width -= 1; // Giảm chiều rộng để vừa với viền
            rect.Height -= 1; // Giảm chiều cao để vừa với viền

            using (GraphicsPath path = CreateRoundedRectanglePath(rect, BorderRadius))
            using (Pen pen = new Pen(BorderColor, BorderSize))
            using (SolidBrush brush = new SolidBrush(this.BackColor))
            {
                // Vẽ nền với góc bo
                e.Graphics.FillPath(brush, path);
                // Vẽ viền nếu có BorderSize > 0
                if (BorderSize > 0)
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }

        private GraphicsPath CreateRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;

            // Thêm các góc bo
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90); // Góc trên-trái
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90); // Góc trên-phải
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90); // Góc dưới-phải
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90); // Góc dưới-trái

            path.CloseFigure(); // Đóng hình
            return path;
        }
    }
}

