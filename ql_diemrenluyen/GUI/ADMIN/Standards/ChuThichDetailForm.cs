using ql_diemrenluyen.BUS;
using ql_diemrenluyen.DTO;
using ql_diemrenluyen.GUI.ADMIN.TieuChi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ql_diemrenluyen.GUI.ADMIN.Standards
{
    public partial class ChuThichDetailForm : Form
    {
        private long currentAccountId;
        private QLTieuChi mainForm;
        private DataGridView table;
        private DataGridView tableAdd;
        private int id;
        int? parentID;
        String status;
        DateTime createdAt;
        public ChuThichDetailForm(int id, int? parentID, string text, int maxpoint, DateTime createdAt, DateTime updatedAt, string status, DataGridView dataGridView, QLTieuChi tieuChiForm)
        {
            this.BackColor = Color.Black;
            table = dataGridView;
            mainForm = tieuChiForm;
            this.id = id;
            this.status = status;
            this.parentID = parentID;
            this.createdAt = createdAt;
            InitializeComponent();

            // Set các giá trị cho các trường trong form
            txtId.Text = id.ToString();
            txtId.ReadOnly = true; // Không cho phép chỉnh sửa trường ID

            txtNoiDung.Text = text;
            txtMaxPoint.Text = maxpoint + "";

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
            List<TieuChiDanhGiaDTO> listtieuchi = TieuChiDanhGiaBUS.GetAllTieuChiDanhGia();

            if (parentID.HasValue)
            {
                foreach (var tieuchi in listtieuchi)
                {
                    if (tieuchi.ParentId.HasValue)
                    {
                        cbbParentID.Items.Add(tieuchi.Id + " - " + tieuchi.Name);

                        if (tieuchi.Id == parentID.Value)
                        {
                            cbbParentID.SelectedIndex = cbbParentID.Items.Count - 1;
                        }
                    }
                }
            }






            // Tải trạng thái vào ComboBox
            cbbStatus.SelectedItem = status;
            cbbStatus.Enabled = true; // Cho phép chọn trạng thái

            currentAccountId = id;

            // Hiển thị thông báo cảnh báo về trạng thái Tiêu Chí
            //MessageBox.Show($"Trạng thái Tiêu Chí: {status}", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            // Điều chỉnh trạng thái của nút Delete
            btnDelete.Enabled = status == "Hoạt động"; // Nếu Tiêu Chí không phải "Hoạt động", cho phép xóa
        }

        public ChuThichDetailForm(DataGridView dataGridView, QLTieuChi tieuChiForm)
        {
            this.BackColor = Color.Black;
            tableAdd = dataGridView;
            mainForm = tieuChiForm;
            this.parentID = parentID;
            InitializeComponent();
            dtpUpdatedAt.Value = DateTime.Now;
            dtpCreatedAt.Value = DateTime.Now;
            btnEdit.Text = "Thêm";
            btnEdit.Location = new Point(201 - 100, 524);
            btnEdit.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Visible = false;
            btnClose.Location = new Point(324 - 50, 524);
            lblId.Visible = false;
            txtId.Visible = false;
            List<TieuChiDanhGiaDTO> listtieuchi = TieuChiDanhGiaBUS.GetAllTieuChiDanhGia();

                foreach (var tieuchi in listtieuchi)
                {
                    if (tieuchi.ParentId != null)
                    {
                        cbbParentID.Items.Add(tieuchi.Id + " - " + tieuchi.Name);

                    }
                }
                cbbParentID.SelectedItem = "ID - Nội dung";


            cbbStatus.SelectedItem = "Hoạt động";
            cbbStatus.Enabled = false;
        }
        

        private void btnEdit_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtNoiDung.Text) || cbbStatus.SelectedItem == null || txtMaxPoint.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ChuThichTieuChiBUS.IsValidScore(txtMaxPoint.Text))
            {
                MessageBox.Show("Điểm phải là số nguyên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Kiểm tra nếu có chọn ParentId từ combobox
            if (cbbParentID.SelectedIndex != -1)
            {
                string selectedItem = cbbParentID.SelectedItem.ToString();

                if (selectedItem.StartsWith("ID - Nội dung"))
                {
                    MessageBox.Show("Bạn không thể chọn 'Mặc định' để cập nhật!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string[] parts = selectedItem.Split('-');

                if (parts.Length == 2 && int.TryParse(parts[0].Trim(), out int id))
                {
                    parentID = id;  // Nếu đúng, lấy ID
                }
                else
                {
                    MessageBox.Show("Định dạng không hợp lệ! Vui lòng chọn ID và Nội dung theo định dạng 'ID - Nội dung'.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (btnEdit.Text == "Thêm")
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn thêm Chú Thích Tiêu Chí không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    ChuThichTieuChiDTO tc = new ChuThichTieuChiDTO
                    {
                        TieuChiDanhGiaId = parentID,
                        Name = txtNoiDung.Text,
                        Diem = int.Parse(txtMaxPoint.Text),
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        Status = cbbStatus.SelectedItem.ToString() == "Hoạt động" ? 1 : 0
                    };

                    bool result = ChuThichTieuChiBUS.AddChuThichTieuChi(tc);

                    if (result)
                    {
                        MessageBox.Show("Thêm Chú Thích Tiêu Chí thành công!");
                        QLTieuChi.LoadChuThichTieuChiList(tableAdd);

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Thêm Chú Thích Tiêu Chí không thành công. Vui lòng kiểm tra lại!");
                        return;
                    }
                }
            }
            else
                    {
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn cập nhật Chú Thích Tiêu Chí không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    ChuThichTieuChiDTO tc = new ChuThichTieuChiDTO
                    {
                        Id = id,
                        TieuChiDanhGiaId = parentID,
                        Name = txtNoiDung.Text,
                        Diem = int.Parse(txtMaxPoint.Text),
                        CreatedAt = createdAt,
                        UpdatedAt = DateTime.Now,
                        Status = cbbStatus.SelectedItem.ToString() == "Hoạt động" ? 1 : 0
                    };

                    bool result = ChuThichTieuChiBUS.UpdateChuThichTieuChi(tc);

                    if (result)
                    {
                        MessageBox.Show("Cập nhật Tiêu Chí thành công!");
                        QLTieuChi.LoadChuThichTieuChiList(table);

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật Chú Thích Tiêu Chí không thành công. Vui lòng kiểm tra lại!");
                    }
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

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn ngừng hoạt động chú thích tiêu chí này?",
                                  "Xác nhận",
                                  MessageBoxButtons.YesNo,
                                  MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                bool isDeactivated = ChuThichTieuChiBUS.DeleteChuThichTieuChi(id);
                if (isDeactivated)
                {
                    MessageBox.Show("Chú Thích Tiêu Chí đã được ngừng hoạt động.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    QLTieuChi.LoadTieuChiDanhGiaList(table, 0);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra khi ngừng hoạt động Chú Thích Tiêu Chí.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Hành động đã bị hủy bỏ.", "Hủy bỏ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void AccountDetailsForm_Load(object sender, EventArgs e)
        {

            btnDelete.Enabled = status == "Hoạt động";
        }

        private void txtMaxPoint_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblId_Click(object sender, EventArgs e)
        {

        }

        private void ChuThichDetailForm_Load(object sender, EventArgs e)
        {

        }

        private void lbTitle_Click(object sender, EventArgs e)
        {

        }

        private void lblRememberToken_Click(object sender, EventArgs e)
        {

        }
    }
}