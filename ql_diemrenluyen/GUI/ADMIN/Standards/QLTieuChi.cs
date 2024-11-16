using MySqlX.XDevAPI.Relational;
using Org.BouncyCastle.Asn1.Cmp;
using ql_diemrenluyen.BUS;
using ql_diemrenluyen.DTO;
using ql_diemrenluyen.GUI.ADMIN.Account;
using ql_diemrenluyen.GUI.ADMIN.Standards;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ql_diemrenluyen.GUI.ADMIN.TieuChi
{
    public partial class QLTieuChi : Form
    {
        public QLTieuChi()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill; // Đặt Dock để chiếm toàn bộ không gian
            this.ControlBox = false;
            InitializePlaceholder(txtTC, "Nhập ID, nội dung cần tìm...");

            InitializePlaceholder(txtTCP, "Nhập ID, nội dung cần tìm...");

            InitializePlaceholder(txtCTTC, "Nhập ID, nội dung cần tìm...");
            cbbStatusTC.SelectedItem = "Mặc định";
            cbbStatusTCP.SelectedItem = "Mặc định";
            cbbStatusCTTC.SelectedItem = "Mặc định";

        }

        private void TieuChi_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill; // Đảm bảo chiếm toàn bộ không gian
            this.ControlBox = false;
            //List<ChuThichTieuChiDTO> listchuthich = ChuThichTieuChiBUS.GetAllChuThichTieuChi();
            //MessageBox.Show("Lỗi khi tải danh sách tài khoản: " + listchuthich.Count());

            LoadStandardsList();
        }
        private void InitializePlaceholder(TextBox textBox, string placeholder)
        {
            // Gán giá trị ban đầu cho TextBox là placeholder
            textBox.Text = placeholder;
            textBox.ForeColor = Color.Gray; // Màu chữ placeholder (màu xám)

            // Sự kiện khi người dùng click vào TextBox (enter vào TextBox)
            textBox.Enter += (sender, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black; // Màu chữ khi người dùng bắt đầu nhập liệu
                }
            };

            // Sự kiện khi người dùng rời khỏi TextBox (leave khỏi TextBox)
            textBox.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = Color.Gray; // Màu chữ placeholder khi TextBox trống
                }
            };
        }
        private void LoadStandardsList()
        {
            try
            {
                List<TieuChiDanhGiaDTO> listtieuchi = TieuChiDanhGiaBUS.GetAllTieuChiDanhGia();
                tableTC.Rows.Clear();

                foreach (var tieuchi in listtieuchi)
                {
                    if (tieuchi.ParentId == null)
                    {
                        tableTC.Rows.Add(
                                               tieuchi.Id,
                                               tieuchi.Name,
                                               tieuchi.DiemMax,
                                               tieuchi.ParentId != null ? tieuchi.ParentId.ToString() : "none", // Kiểm tra nếu ParentId > 0 thì hiển thị, ngược lại để trống
                                               tieuchi.CreatedAt.HasValue ? tieuchi.CreatedAt.Value.ToString("dd/MM/yyyy") : "",
                                               tieuchi.UpdatedAt.HasValue ? tieuchi.UpdatedAt.Value.ToString("dd/MM/yyyy") : "",
                                               tieuchi.status == 1 ? "Hoạt động" : "Không hoạt động"
                                           );
                    }

                }

                ApplyTableStyles(tableTC); // Áp dụng kiểu dáng cho bảng
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách tiêu chí: " + ex.Message);
            }
            try
            {
                List<TieuChiDanhGiaDTO> listtieuchi = TieuChiDanhGiaBUS.GetAllTieuChiDanhGia();
                tbTCP.Rows.Clear();

                foreach (var tieuchi in listtieuchi)
                {
                    if (tieuchi.ParentId != null)
                    {
                        tbTCP.Rows.Add(
                                               tieuchi.Id,
                                               tieuchi.Name,
                                               tieuchi.DiemMax,
                                               tieuchi.ParentId != null ? tieuchi.ParentId.ToString() : "none", // Kiểm tra nếu ParentId > 0 thì hiển thị, ngược lại để trống
                                               tieuchi.CreatedAt.HasValue ? tieuchi.CreatedAt.Value.ToString("dd/MM/yyyy") : "",
                                               tieuchi.UpdatedAt.HasValue ? tieuchi.UpdatedAt.Value.ToString("dd/MM/yyyy") : "",
                                               tieuchi.status == 1 ? "Hoạt động" : "Không hoạt động"
                                           );
                    }

                }

                ApplyTableStyles(tbTCP); // Áp dụng kiểu dáng cho bảng
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách tiêu chí phụ: " + ex.Message);
            }
            try
            {
                List<ChuThichTieuChiDTO> listchuthich = ChuThichTieuChiBUS.GetAllChuThichTieuChi();

                tbCTTC.Rows.Clear();

                foreach (var chuthich in listchuthich)
                {

                    tbCTTC.Rows.Add(
                                               chuthich.Id,
                                               chuthich.TieuChiDanhGiaId,
                                               chuthich.Name,
                                               chuthich.Diem,
                                               chuthich.CreatedAt.HasValue ? chuthich.CreatedAt.Value.ToString("dd/MM/yyyy") : "",
                                               chuthich.UpdatedAt.HasValue ? chuthich.UpdatedAt.Value.ToString("dd/MM/yyyy") : "",
                                               chuthich.Status == 1 ? "Hoạt động" : "Không hoạt động"
                                           );


                }

                ApplyTableStyles(tbCTTC); // Áp dụng kiểu dáng cho bảng
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách chú thích tiêu chí: " + ex.Message);
            }
        }
        public static void LoadTieuChiDanhGiaList(DataGridView table, int? parentId)
        {
            try
            {
                List<TieuChiDanhGiaDTO> listtieuchi = TieuChiDanhGiaBUS.GetAllTieuChiDanhGia();
                table.Rows.Clear();
                if (parentId == null)
                {
                    foreach (var tieuchi in listtieuchi)
                    {
                        if (tieuchi.ParentId == null)
                        {
                            table.Rows.Add(
                                tieuchi.Id,
                                tieuchi.Name,
                                tieuchi.DiemMax,
                                tieuchi.ParentId > 0 ? tieuchi.ParentId.ToString() : "none", // Kiểm tra nếu ParentId > 0 thì hiển thị, ngược lại để trống
                                tieuchi.CreatedAt.HasValue ? tieuchi.CreatedAt.Value.ToString("dd/MM/yyyy") : "",
                                tieuchi.UpdatedAt.HasValue ? tieuchi.UpdatedAt.Value.ToString("dd/MM/yyyy") : "",
                                tieuchi.status == 1 ? "Hoạt động" : "Không hoạt động"
                            );
                        }
                    }
                }
                else
                {
                    foreach (var tieuchi in listtieuchi)
                    {
                        if (tieuchi.ParentId != null)
                        {
                            table.Rows.Add(
                                tieuchi.Id,
                                tieuchi.Name,
                                tieuchi.DiemMax,
                                tieuchi.ParentId != null ? tieuchi.ParentId.ToString() : "none", // Kiểm tra nếu ParentId > 0 thì hiển thị, ngược lại để trống
                                tieuchi.CreatedAt.HasValue ? tieuchi.CreatedAt.Value.ToString("dd/MM/yyyy") : "",
                                tieuchi.UpdatedAt.HasValue ? tieuchi.UpdatedAt.Value.ToString("dd/MM/yyyy") : "",
                                tieuchi.status == 1 ? "Hoạt động" : "Không hoạt động"
                            );
                        }
                    }
                }

                ApplyTableStyles(table); // Áp dụng kiểu dáng cho bảng
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách tiêu chí: " + ex.Message);
            }
        }
        public static void LoadChuThichTieuChiList(DataGridView table)
        {
            try
            {
                List<ChuThichTieuChiDTO> listchuthich = ChuThichTieuChiBUS.GetAllChuThichTieuChi();
                table.Rows.Clear();

                foreach (var chuthich in listchuthich)
                {
                    table.Rows.Add(
                        chuthich.Id,
                        chuthich.TieuChiDanhGiaId,
                        chuthich.Name,
                        chuthich.Diem,
                        chuthich.CreatedAt.HasValue ? chuthich.CreatedAt.Value.ToString("dd/MM/yyyy") : "",
                        chuthich.UpdatedAt.HasValue ? chuthich.UpdatedAt.Value.ToString("dd/MM/yyyy") : "",
                        chuthich.Status == 1 ? "Hoạt động" : "Không hoạt động"
                    );
                }

                ApplyTableStyles(table); // Áp dụng kiểu dáng cho bảng
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách chú thích tiêu chí: " + ex.Message);
            }
        }

        private void ApplyTableStyles()
        {
            tableTC.RowTemplate.Height = 40;
            tableTC.BorderStyle = BorderStyle.Fixed3D;
            tableTC.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle
            {
                Font = new System.Drawing.Font("Segoe UI", 14, FontStyle.Bold),
                BackColor = Color.RoyalBlue,
                ForeColor = Color.White
            };

            tableTC.ColumnHeadersDefaultCellStyle = headerStyle;
            tableTC.EnableHeadersVisualStyles = false;
            tableTC.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            tableTC.DefaultCellStyle.SelectionForeColor = Color.Black;
        }
        // Định nghĩa lại phương thức ApplyTableStyles
        private static void ApplyTableStyles(DataGridView table)
        {
            table.RowTemplate.Height = 40;
            table.BorderStyle = BorderStyle.Fixed3D;
            table.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle
            {
                Font = new System.Drawing.Font("Segoe UI", 14, FontStyle.Bold),
                BackColor = Color.RoyalBlue,
                ForeColor = Color.White
            };

            table.ColumnHeadersDefaultCellStyle = headerStyle;
            table.EnableHeadersVisualStyles = false;
            table.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            table.DefaultCellStyle.SelectionForeColor = Color.Black;
        }
        private void SearchTieuChiList()
        {
            try
            {

                int status = cbbStatusTC.SelectedItem?.ToString() == "Mặc định" ? -1 :
                             (cbbStatusTC.SelectedItem?.ToString() == "Hoạt động" ? 1 : 0);

                string search = txtTC.Text;
                //MessageBox.Show(role +"   "+ status+"  " +search, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (search.Equals("Nhập ID, nội dung cần tìm..."))
                {
                    search = null;
                }

                // Kiểm tra nếu không có điều kiện nào được nhập, tải danh sách tài khoản mặc định
                if (status == -1 && string.IsNullOrEmpty(search))
                {

                    LoadStandardsList();
                    return;
                }

                List<TieuChiDanhGiaDTO> listtieuchi = TieuChiDanhGiaBUS.SearchTieuChiDanhGiaWithoutParentId(status, search);

                tableTC.Rows.Clear();

                if (listtieuchi != null && listtieuchi.Count > 0)
                {
                    foreach (var tieuchi in listtieuchi)
                    {
                        if (tieuchi.ParentId == null)
                        {
                            tableTC.Rows.Add(
                                tieuchi.Id,
                                tieuchi.Name,
                                tieuchi.DiemMax,
                                tieuchi.ParentId != null ? tieuchi.ParentId.ToString() : "null", // Kiểm tra nếu ParentId > 0 thì hiển thị, ngược lại để trống
                                tieuchi.CreatedAt.HasValue ? tieuchi.CreatedAt.Value.ToString("dd/MM/yyyy") : "",
                                tieuchi.UpdatedAt.HasValue ? tieuchi.UpdatedAt.Value.ToString("dd/MM/yyyy") : "",
                                tieuchi.status == 1 ? "Hoạt động" : "Không hoạt động"
                            );
                        }
                    }

                    ApplyTableStyles(tableTC);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
            }
        }
        private void txtTC_TextChanged(object sender, EventArgs e)
        {
            SearchTieuChiList();
        }

        private void cbbStatusTC_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchTieuChiList();
        }
        private void clearFilter()
        {
            txtTC.Text = "Nhập ID, nội dung cần tìm...";
            txtTCP.Text= "Nhập ID, nội dung cần tìm...";
            txtCTTC.Text ="Nhập ID, nội dung cần tìm...";
            // Reset combo boxes to "Mặc định"
            cbbStatusTC.SelectedItem = "Mặc định";

            // Reset combo boxes to "Mặc định"
            cbbTC.SelectedItem = "Mặc định";
            cbbStatusTCP.SelectedItem = "Mặc định";
            // Reset combo boxes to "Mặc định"
            cbbTCP.SelectedItem = "Mặc định";
            cbbStatusCTTC.SelectedItem = "Mặc định";
            LoadStandardsList();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = cbStatusCTTC.SelectedIndex;

            switch (selectedIndex)
            {
                case 0:
                    clearFilter();
                    break;
                case 1:
                    clearFilter();
                    break;
                case 2:
                    clearFilter();
                    break;
                default:
                    break;
            }
        }


        private void btnClearTC_Click(object sender, EventArgs e)
        {
            clearFilter();
        }

        private void btnClearTCP_Click(object sender, EventArgs e)
        {
            clearFilter();
        }

        private void btnClearCTTC_Click(object sender, EventArgs e)
        {
            clearFilter();
        }

        private void tableTC_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = tableTC.Rows[e.RowIndex];

                // Lấy giá trị của các cột
                long id = (long)selectedRow.Cells["colTieuChi"].Value;
                int maxpoint = (int)selectedRow.Cells["colMaxPoint"].Value;

                string text = selectedRow.Cells["colNoiDung"].Value?.ToString() ?? "";
                int? parentID = null;
                string status = selectedRow.Cells["colStatus"].Value?.ToString() ?? "";

                DateTime createdAt = DateTime.TryParse(selectedRow.Cells["colCreate"].Value?.ToString(), out DateTime tempCreatedAt)
                    ? tempCreatedAt : DateTime.MinValue;

                DateTime updatedAt = DateTime.TryParse(selectedRow.Cells["colUpdate"].Value?.ToString(), out DateTime tempUpdatedAt)
                    ? tempUpdatedAt : DateTime.MinValue;

                // Tạo và hiển thị form chi tiết
                TieuChiDetailForm tcform = new TieuChiDetailForm(id, text, maxpoint, createdAt, updatedAt, status, tableTC, this, parentID);
                tcform.Show();
            }
        }

        private void btnAddTC_Click(object sender, EventArgs e)
        {

            TieuChiDetailForm tcform = new TieuChiDetailForm(tableTC, this, null);
            tcform.Show();
        }
    }
}

