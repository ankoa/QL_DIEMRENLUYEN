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
    public partial class TieuChiDetailForm : Form
    {
        private long currentAccountId;
        private QLTieuChi mainForm;
        private DataGridView table;
        private DataGridView tableAdd;
        private long id;
        int? parentID;
        String status;
        DateTime createdAt;
        public TieuChiDetailForm(long id, string text, int maxpoint, DateTime createdAt, DateTime updatedAt, string status, DataGridView dataGridView, QLTieuChi tieuChiForm, int? parentID)
        {
            //MessageBox.Show(parentID+"h ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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
                    if (parentID.HasValue)
                    {
                        cbbParentID.Items.Add(tieuchi.Id + " - " + tieuchi.Name);

                        if (tieuchi.Id == parentID.Value)
                        {
                            cbbParentID.SelectedIndex = cbbParentID.Items.Count - 1;
                        }
                    }
                }
            }
            else
            {
                cbbParentID.Enabled = false;
                lbparentID.Enabled = false;
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

        public TieuChiDetailForm(DataGridView dataGridView, QLTieuChi tieuChiForm, int? parentID)
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

            if (parentID != null)
            {
                lbTitle.Text = "Thông tin tiêu chí phụ";
                foreach (var tieuchi in listtieuchi)
                {
                    if (tieuchi.ParentId != null)
                    {
                        cbbParentID.Items.Add(tieuchi.Id + " - " + tieuchi.Name);

                    }
                }
                cbbParentID.SelectedItem = "ID - Nội dung";

            }
            else
            {
                cbbParentID.Enabled = false;
            }
            cbbStatus.SelectedItem = "Hoạt động";
            cbbStatus.Enabled = false;
        }
        //private void BtnAdd_Click(object sender, EventArgs e)
        //{
        //    // Kiểm tra dữ liệu nhập vào
        //    if (string.IsNullOrEmpty(txtNoiDung.Text) || string.IsNullOrEmpty(txtMaxPoint.Text) || cbbStatus.SelectedItem == null)
        //    {
        //        MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    // Kiểm tra điểm có phải là số hợp lệ
        //    if (!TieuChiDanhGiaBUS.IsValidScore(txtMaxPoint.Text))
        //    {
        //        MessageBox.Show("Điểm phải là số nguyên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    // Biến parentID được khởi tạo bên ngoài các điều kiện

        //    //if (parentID == null)
        //    //{
        //        DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn thêm Tiêu Chí", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //        if (dialogResult == DialogResult.Yes)
        //        {
        //            TieuChiDanhGiaDTO newTieuChi = new TieuChiDanhGiaDTO
        //            {
        //                Name = txtNoiDung.Text,
        //                DiemMax = int.TryParse(txtMaxPoint.Text, out int maxPoint) ? maxPoint : 0, // Sử dụng TryParse
        //                ParentId = null,
        //                CreatedAt = dtpCreatedAt.Value,
        //                UpdatedAt = dtpUpdatedAt.Value,
        //                status = cbbStatus.SelectedItem.ToString() == "Hoạt động" ? 1 : 0
        //            };

        //            bool isAdded = TieuChiDanhGiaBUS.AddTieuChiDanhGia(newTieuChi);
        //            if (isAdded)
        //            {
        //                MessageBox.Show("Thêm tiêu chí thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                QLTieuChi.LoadTieuChiDanhGiaList(table, null);
        //                this.Close();
        //            }
        //            else
        //            {
        //                MessageBox.Show("Thêm tiêu chí không thành công. Vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        //}
        //    }
        //    //else
        //    //{
        //    //    // Kiểm tra nếu có chọn ParentId từ combobox
        //    //    if (cbbParentID.SelectedIndex != -1)
        //    //    {
        //    //        string selectedItem = cbbParentID.SelectedItem.ToString();

        //    //        if (selectedItem.StartsWith("ID - Nội dung"))
        //    //        {
        //    //            MessageBox.Show("Bạn không thể chọn 'Mặc định' để cập nhật!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    //            return;
        //    //        }

        //    //        string[] parts = selectedItem.Split('-');

        //    //        if (parts.Length == 2 && int.TryParse(parts[0].Trim(), out int id))
        //    //        {
        //    //            parentID = id;  // Nếu đúng, lấy ID
        //    //        }
        //    //        else
        //    //        {
        //    //            MessageBox.Show("Định dạng không hợp lệ! Vui lòng chọn ID và Nội dung theo định dạng 'ID - Nội dung'.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    //            return;
        //    //        }
        //    //    }

        //    //    DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn thêm Tiêu Chí Phụ", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //    //    if (dialogResult == DialogResult.Yes)
        //    //    {
        //    //        TieuChiDanhGiaDTO newTieuChi = new TieuChiDanhGiaDTO
        //    //        {
        //    //            Name = txtNoiDung.Text,
        //    //            DiemMax = int.TryParse(txtMaxPoint.Text, out int maxPoint) ? maxPoint : 0, // Sử dụng TryParse
        //    //            ParentId = parentID,
        //    //            CreatedAt = dtpCreatedAt.Value,
        //    //            UpdatedAt = dtpUpdatedAt.Value,
        //    //            status = cbbStatus.SelectedItem.ToString() == "Hoạt động" ? 1 : 0
        //    //        };

        //    //        bool isAdded = TieuChiDanhGiaBUS.AddTieuChiDanhGia(newTieuChi);
        //    //        if (isAdded)
        //    //        {
        //    //            MessageBox.Show("Thêm tiêu chí phụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    //            QLTieuChi.LoadTieuChiDanhGiaList(table, null);
        //    //            this.Close();
        //    //        }
        //    //        else
        //    //        {
        //    //            MessageBox.Show("Thêm tiêu chí phụ không thành công. Vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    //        }
        //    //    }
        //    //}
        //}


        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text == "Thêm")
            {
                // Kiểm tra dữ liệu nhập vào
                if (string.IsNullOrEmpty(txtNoiDung.Text) || string.IsNullOrEmpty(txtMaxPoint.Text) || cbbStatus.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra điểm có phải là số hợp lệ
                if (!TieuChiDanhGiaBUS.IsValidScore(txtMaxPoint.Text))
                {
                    MessageBox.Show("Điểm phải là số nguyên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Biến parentID được khởi tạo bên ngoài các điều kiện

                if (parentID == null)
                {
                    DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn thêm Tiêu Chí", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        TieuChiDanhGiaDTO newTieuChi = new TieuChiDanhGiaDTO
                        {
                            Name = txtNoiDung.Text,
                            DiemMax = int.TryParse(txtMaxPoint.Text, out int maxPoint) ? maxPoint : 0, // Sử dụng TryParse
                            ParentId = null,
                            CreatedAt = dtpCreatedAt.Value,
                            UpdatedAt = dtpUpdatedAt.Value,
                            status = cbbStatus.SelectedItem.ToString() == "Hoạt động" ? 1 : 0
                        };

                        bool isAdded = TieuChiDanhGiaBUS.AddTieuChiDanhGia(newTieuChi);
                        if (isAdded)
                        {
                            MessageBox.Show("Thêm tiêu chí thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            QLTieuChi.LoadTieuChiDanhGiaList(tableAdd, null);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Thêm tiêu chí không thành công. Vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                if (parentID == 0)
                {
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



                    DialogResult dialogResult1 = MessageBox.Show("Bạn có chắc chắn muốn thêm Tiêu Chí Phụ", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult1 == DialogResult.Yes)
                    {
                        TieuChiDanhGiaDTO newTieuChi = new TieuChiDanhGiaDTO
                        {
                            Name = txtNoiDung.Text,
                            DiemMax = int.TryParse(txtMaxPoint.Text, out int maxPoint) ? maxPoint : 0, // Sử dụng TryParse
                            ParentId = parentID,
                            CreatedAt = dtpCreatedAt.Value,
                            UpdatedAt = dtpUpdatedAt.Value,
                            status = cbbStatus.SelectedItem.ToString() == "Hoạt động" ? 1 : 0
                        };

                        bool isAdded = TieuChiDanhGiaBUS.AddTieuChiDanhGia(newTieuChi);
                        if (isAdded)
                        {
                            MessageBox.Show("Thêm tiêu chí phụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            QLTieuChi.LoadTieuChiDanhGiaList(tableAdd, parentID);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Thêm tiêu chí phụ không thành công. Vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }

            }
            else
            {
                if (string.IsNullOrEmpty(txtNoiDung.Text) || cbbStatus.SelectedItem == null || string.IsNullOrEmpty(txtMaxPoint.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!TieuChiDanhGiaBUS.IsValidScore(txtMaxPoint.Text))
                {
                    MessageBox.Show("Điểm phải là số nguyên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Kiểm tra nếu parentID là null (không chọn hoặc không hợp lệ)
                if (parentID == null)
                {


                    DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn cập nhật Tiêu Chí không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.Yes)
                    {
                        // Nếu parentID là null, thì ParentId của Tiêu Chi sẽ là null
                        TieuChiDanhGiaDTO tc = new TieuChiDanhGiaDTO
                        {
                            Id = id,
                            Name = txtNoiDung.Text,
                            DiemMax = int.Parse(txtMaxPoint.Text),
                            ParentId = null,  // ParentId là null khi không có chọn trong cbbParentID
                            CreatedAt = createdAt,
                            UpdatedAt = DateTime.Now,
                            status = cbbStatus.SelectedItem.ToString() == "Hoạt động" ? 1 : 0
                        };

                        bool result = TieuChiDanhGiaBUS.UpdateTieuChiDanhGia(tc);

                        if (result)
                        {
                            MessageBox.Show("Cập nhật Tiêu Chí thành công!");
                            QLTieuChi.LoadTieuChiDanhGiaList(table, parentID);

                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật Tiêu Chí không thành công. Vui lòng kiểm tra lại!");
                            return;
                        }
                    }
                }
                else
                {
                    int? parentID = null;

                    // Kiểm tra nếu cbbParentID không phải là item cuối (Mặc định), kiểm tra nếu mục đầu tiên là "ID - Nội dung"
                    if (cbbParentID.SelectedIndex != -1)
                    {
                        // Lấy giá trị từ cbbParentID.SelectedItem và tách ID
                        string selectedItem = cbbParentID.SelectedItem.ToString();

                        // Kiểm tra xem nếu đó là mục đầu tiên và có phải là "ID - Nội dung" không hợp lệ
                        if (selectedItem.StartsWith("ID - Nội dung"))
                        {
                            // Thông báo cảnh báo và dừng tiếp tục
                            MessageBox.Show("Bạn không thể chọn 'Mặc định' để cập nhật!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Tách chuỗi thành mảng phần tử bằng dấu "-"
                        string[] parts = selectedItem.Split('-');

                        // Kiểm tra xem có đủ phần tử và phần đầu tiên có thể chuyển thành số
                        if (parts.Length == 2 && int.TryParse(parts[0].Trim(), out int id))
                        {
                            parentID = id;  // Nếu đúng, lấy ID
                        }
                        else
                        {
                            // Nếu không đúng định dạng, thông báo lỗi và dừng lại
                            MessageBox.Show("Định dạng không hợp lệ! Vui lòng chọn ID và Nội dung theo định dạng 'ID - Nội dung'.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Tiếp tục với các bước xử lý khác sau khi kiểm tra hợp lệ

                    // Nếu parentID không phải null, cập nhật giá trị ParentId từ cbbParentID
                    DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn cập nhật Tiêu Chí Phụ", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.Yes)
                    {
                        // Tiến hành cập nhật Tiêu Chí với ParentId được chọn từ cbbParentID
                        TieuChiDanhGiaDTO tc = new TieuChiDanhGiaDTO
                        {
                            Id = id,
                            Name = txtNoiDung.Text,
                            DiemMax = int.Parse(txtMaxPoint.Text),
                            ParentId = parentID,  // Cập nhật ParentId từ giá trị cbbParentID
                            CreatedAt = createdAt,
                            UpdatedAt = DateTime.Now,
                            status = cbbStatus.SelectedItem.ToString() == "Hoạt động" ? 1 : 0
                        };

                        bool result = TieuChiDanhGiaBUS.UpdateTieuChiDanhGia(tc);

                        if (result)
                        {
                            MessageBox.Show("Cập nhật Tiêu Chí Phụ thành công!");
                            QLTieuChi.LoadTieuChiDanhGiaList(table, parentID);

                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật Tiêu Chí Phụ không thành công. Vui lòng kiểm tra lại!");
                            return;
                        }
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

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn ngừng hoạt động tiêu chí này?",
                                  "Xác nhận",
                                  MessageBoxButtons.YesNo,
                                  MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                bool isDeactivated = TieuChiDanhGiaBUS.DeleteTieuChiDanhGia(id);
                if (isDeactivated)
                {
                    MessageBox.Show("Tiêu Chí đã được ngừng hoạt động.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    QLTieuChi.LoadTieuChiDanhGiaList(table, 0);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra khi ngừng hoạt động Tiêu Chí.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void dtpCreatedAt_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
