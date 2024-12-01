using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ql_diemrenluyen.BUS;
using ql_diemrenluyen.DAO;
using ql_diemrenluyen.DTO;

namespace QLDiemRenLuyen
{
    public partial class ThemGiangVien : Form
    {
        private static GiangVienBUS GiangVienBUS = new GiangVienBUS();
        private static KhoaBUS KhoaBUS = new KhoaBUS();
        private AccountBUS AccountBUS = new AccountBUS();
        private List<GiangVienDTO> listGiangVien = new List<GiangVienDTO>();
        private List<LopDTO> listLop = LopBUS.getAllLop();
        private GiangVienDTO giangVienEdit;

        public ThemGiangVien(List<GiangVienDTO> listGiangVien)
        {
            InitializeComponent();
            this.listGiangVien = listGiangVien;
            //txtMaGV.ReadOnly = false;



            // ComboBox khoa
            var khoaList = KhoaBUS.GetAllKhoa();
            cBKhoa.DataSource = khoaList;
            cBKhoa.DisplayMember = "TenKhoa";
            cBKhoa.ValueMember = "Id";
            cBKhoa.DropDownStyle = ComboBoxStyle.DropDownList;
            cBKhoa.SelectedIndex = -1;
            cBKhoa.SelectedIndexChanged += CBKhoa_SelectedIndexChanged;

            cbGioiTinh.Items.Add("Nam");
            cbGioiTinh.Items.Add("Nữ");

            //cbTrangthai.Items.Add("Hoạt động");
            //cbTrangthai.Items.Add("Không hoạt động");
            cbGioiTinh.SelectedIndex = 0;
            cbTrangthai.SelectedIndex = 0;
            //try
            //{
            //    // Lọc danh sách lớp có CoVanId == null
            //    var danhSachLopCoVanNull = listLop.Where(lop => lop.CoVanId == null).ToList();

            //    // Xóa các mục cũ trong CheckedListBox
            //    clbLopcovan.Items.Clear();

            //    // Thêm các lớp đã lọc vào CheckedListBox
            //    foreach (var lop in danhSachLopCoVanNull)
            //    {
            //        clbLopcovan.Items.Add(lop.TenLop);
            //    }
            //}

            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi khi khởi tạo danh sách lớp: " + ex.Message);
            //}
            clbLopcovan.Items.Clear();
        }

        public ThemGiangVien(long idGV)
        {
            InitializeComponent();

            // Gán danh sách giảng viên
            //this.listGiangVien = listGiangVien;

            // Thay đổi nút "Thêm" thành "Sửa"
            btnThem.Text = "Sửa";

            // Lấy thông tin giảng viên
            GiangVienDTO giangVien = GiangVienBUS.GetGiangVienById(idGV);
            if (giangVien == null)
            {
                MessageBox.Show("Không tìm thấy giảng viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            giangVienEdit = giangVien;

            // Gán thông tin giảng viên vào các trường
            txtHoTen.Text = giangVien.Name;
            txtEmail.Text = giangVien.Email;
            dtpNgaySinh.Value = giangVien.NgaySinh != default(DateTime) ? giangVien.NgaySinh : DateTime.Now;
            //MessageBox.Show($"Ngày sinh: {giangVien.NgaySinh}");
            // Ngày sinh, nếu null sẽ lấy ngày hiện tại

            cbGioiTinh.Items.Add("Nam");
            cbGioiTinh.Items.Add("Nữ");

            // Gán giới tính
            cbGioiTinh.SelectedIndex = giangVien.GioiTinh == 1 ? 0 : 1; // 1 = Nam, 0 = Nữ

            // Gán trạng thái
            cbTrangthai.SelectedIndex = giangVien.Status == 1 ? 0 : 1; // 1 = Hoạt động, 0 = Không hoạt động

            // Gán danh sách khoa vào ComboBox
            var khoaList = KhoaBUS.GetAllKhoa();
            cBKhoa.DataSource = khoaList;
            cBKhoa.DisplayMember = "TenKhoa";
            cBKhoa.ValueMember = "Id";
            cBKhoa.DropDownStyle = ComboBoxStyle.DropDownList;
            cBKhoa.SelectedValue = giangVien.KhoaId;
            cBKhoa.Enabled = false;

            // Gán danh sách lớp vào CheckedListBox và đánh dấu các lớp hiện tại của giảng viên
            try
            {
                // Lấy danh sách lớp đã có giảng viên làm cố vấn (CoVanId == idGV)
                var danhSachLopCoVan = listLop.Where(lop => lop.CoVanId == idGV).ToList(); // Lớp thuộc giảng viên
                clbLopcovan.Items.Clear();

                // Thêm các lớp có CoVanId == idGV vào CheckedListBox và đánh dấu
                foreach (var lop in danhSachLopCoVan)
                {
                    int index = clbLopcovan.Items.Add(lop.TenLop); // Thêm lớp vào CheckedListBox
                    clbLopcovan.SetItemChecked(index, true); // Đánh dấu lớp này đã chọn
                }

                // Thêm các lớp có CoVanId == null vào CheckedListBox
                foreach (var lop in listLop.Where(lop => lop.CoVanId == null))
                {
                    clbLopcovan.Items.Add(lop.TenLop); // Thêm lớp vào CheckedListBox
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi khởi tạo danh sách lớp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private Boolean checkExistMaGV(long id)
        {
            foreach (GiangVienDTO giangVien in this.listGiangVien)
            {
                if (giangVien.Id == id) return true;
            }
            return false;
        }

        private Boolean checkEmailExist(string email)
        {
            foreach (GiangVienDTO giangVien in this.listGiangVien)
            {
                if (giangVien.Email.Equals(email))
                {
                    if (giangVienEdit == null)
                        return true;
                    else if (!giangVienEdit.Email.Equals(email))
                        return true;
                }
            }
            return false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            // Kiểm tra họ và tên
            if (txtHoTen.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng không để trống họ và tên!");
                return;
            }
            else
            {
                Regex r = new Regex("[0-9\\.,\\-_()\\[\\]{}\\:;?!@#\\$%\\^&\\*\\+=/\\\\|<>~\"']");
                if (r.IsMatch(txtHoTen.Text.Trim()))
                {
                    MessageBox.Show("Họ tên không hợp lệ!");
                    return;
                }
            }

            // Kiểm tra email
            if (txtEmail.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng không để trống email!");
                return;
            }
            else
            {
                Regex r = new Regex("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$");
                if (!r.IsMatch(txtEmail.Text.Trim()))
                {
                    MessageBox.Show("Email không hợp lệ!");
                    return;
                }
                if (checkEmailExist(txtEmail.Text.Trim()))
                {
                    MessageBox.Show("Email đã tồn tại trong hệ thống!");
                    return;
                }
            }


            //lấy khoa id
            long khoaId;
            if (cBKhoa.SelectedValue == null || !long.TryParse(cBKhoa.SelectedValue.ToString(), out khoaId) || khoaId == -1)
            {
                MessageBox.Show("Vui lòng chọn khoa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int GioiTinh = cbGioiTinh.SelectedIndex == 0 ? 1 : 0;
            int Trangthai = cbTrangthai.SelectedIndex == 0 ? 1 : 0;

            GiangVienDTO giangVienAction = new GiangVienDTO
            {
                //Id = long.Parse(txtMaGV.Text.Trim()),
                Name = txtHoTen.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                NgaySinh = dtpNgaySinh.Value,
                KhoaId = khoaId,
                GioiTinh = GioiTinh,
                Status = Trangthai
            };
            //MessageBox.Show(giangVienAction.Name + giangVienAction.Email + giangVienAction.NgaySinh +"Khoa id:" + giangVienAction.KhoaId + "Giới tính: "+ giangVienAction.GioiTinh);
            Boolean status;
            //status = GiangVienBUS.AddGiangVien(giangVienAction);
            //status = GiangVienBUS.UpdateGiangVien(giangVienAction);
            //if (giangVienEdit == null)
            //{
            //    status = GiangVienBUS.AddGiangVien(giangVienAction);
            //    AccountDTO accountDTO = new AccountDTO
            //    {
            //        Id = giangVienAction.Id,
            //        //Password = "1" // Đặt mật khẩu mặc định
            //    };
            //    AccountBUS.AddAccountGV(accountDTO);
            //}
            //else
            //{
            //    status = GiangVienBUS.UpdateGiangVien(giangVienAction);
            //}

            //MessageBox.Show(status ? "Thêm giảng viên thành công!" : "Thêm giảng viên không thành công!");
            if (giangVienEdit == null) // Nếu giảng viên chưa được chỉnh sửa (thêm mới)
            {
                status = GiangVienBUS.AddGiangVien(giangVienAction);
                MessageBox.Show(status ? "Thêm giảng viên thành công!" : "Thêm giảng viên không thành công!");
            }
            else // Nếu đang sửa giảng viên đã có
            {
                giangVienAction.Id = giangVienEdit.Id;  // Sửa giảng viên đã có
                //MessageBox.Show(giangVienAction.Id.ToString());
                status = GiangVienBUS.UpdateGiangVien(giangVienAction);
                MessageBox.Show(status ? "Sửa giảng viên thành công!" : "Sửa giảng viên không thành công!");
            }
            if (status)
            {
                try
                {
                    long GiangVienId;
                    if (giangVienEdit == null) {
                        // Lấy id của giảng viên vừa thêm
                        GiangVienId = GiangVienBUS.GetLastInsertedId();
                    }
                    else
                    {
                        GiangVienId = giangVienEdit.Id;
                    }
                        

                    if (GiangVienId == -1)
                    {
                        MessageBox.Show("Không thể lấy ID giảng viên vừa thêm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }



                    for (int i = 0; i < clbLopcovan.Items.Count; i++)
                    {
                        // Lấy tên lớp hiện tại trong CheckedListBox
                        string tenLop = clbLopcovan.Items[i].ToString();

                        // Tìm lớp tương ứng trong danh sách lớp
                        LopDTO lop = listLop.FirstOrDefault(l => l.TenLop == tenLop);
                        if (lop == null) continue; // Bỏ qua nếu không tìm thấy lớp

                        // Nếu lớp được tick, gán CoVanId là GiangVienId
                        // Nếu không được tick, gán CoVanId là null
                        lop.CoVanId = clbLopcovan.GetItemChecked(i) ? GiangVienId : (long?)null;

                        // Cập nhật lớp vào cơ sở dữ liệu
                        bool isUpdated = LopBUS.UpdateLop(lop);

                        if (!isUpdated)
                        {
                            MessageBox.Show($"Cập nhật cố vấn cho lớp {lop.TenLop} thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    //MessageBox.Show("Cập nhật cố vấn cho các lớp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //this.Dispose();
        }
        private void CBKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cBKhoa.SelectedValue == null || !long.TryParse(cBKhoa.SelectedValue.ToString(), out long selectedKhoaId))
                {
                    
                    return; // Không làm gì nếu không có khoa được chọn
                }

                // Lọc danh sách lớp theo KhoaId và CoVanId == null
                var danhSachLopTheoKhoa = listLop
                    .Where(lop => lop.Khoa.Id == selectedKhoaId && lop.CoVanId == null)
                    .ToList();
                //MessageBox.Show(selectedKhoaId.ToString() + " và " + "â");
                // Xóa các mục cũ trong CheckedListBox
                clbLopcovan.Items.Clear();

                // Thêm các lớp đã lọc vào CheckedListBox
                foreach (var lop in danhSachLopTheoKhoa)
                {
                    clbLopcovan.Items.Add(lop.TenLop);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc danh sách lớp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMaGV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
