using ql_diemrenluyen.BUS;
using ql_diemrenluyen.DAO;
using ql_diemrenluyen.DTO;
using System.Text.RegularExpressions;

namespace ql_diemrenluyen.GUI.ADMIN.KhoaLop
{
    public partial class UpdateLop : Form
    {
        LopDTO lop;
        List<GiangVienDTO> giangvien_list = null;
        public UpdateLop(LopDTO value)
        {
            InitializeComponent();
            List<KhoaDTO> khoa_list = KhoaBUS.GetAllKhoa();
            List<HeHocDTO> hehoc_list = HeHocBUS.getAllHeHoc();
            lop = value;

            text_lop.Text = lop.TenLop.ToString();
            ib_lb.Text = lop.Id.ToString();
            created_lb.Text = lop.CreatedAt.ToString();
            updated_lb.Text = lop.UpdatedAt.ToString();

            Khoa_cbb.Items.Add("--Chọn--");
            Hdt_cbb.Items.Add("--Chọn--");
            cbbMaCV.Items.Add("--Chọn--");
            cbbTenCV.Items.Add("--Chọn--");

            cbbMaCV.SelectedIndexChanged += (s, e) => SyncComboBoxes(cbbMaCV, cbbTenCV, giangvien_list);
            cbbTenCV.SelectedIndexChanged += (s, e) => SyncComboBoxes(cbbTenCV, cbbMaCV, giangvien_list);


            // Load Khoa data vào ComboBox Khoa_cbb
            foreach (KhoaDTO khoa in khoa_list)
            {
                if (khoa.status == 1)
                {
                    Khoa_cbb.Items.Add(khoa.TenKhoa);
                    if (Khoa_cbb.Text.Equals(lop.Khoa.TenKhoa))
                    {
                        Khoa_cbb.SelectedIndex = Khoa_cbb.Items.IndexOf(lop.Khoa.TenKhoa);
                    }
                }
            }

            // Load HeHoc data vào ComboBox Hdt_cbb
            foreach (HeHocDTO hehoc in hehoc_list)
            {
                if (hehoc.status == 1)
                {
                    Hdt_cbb.Items.Add(hehoc.Name);
                }
            }

            int khoa_index = Khoa_cbb.Items.IndexOf(lop.Khoa.TenKhoa);
            if (khoa_index != -1)
            {
                Khoa_cbb.SelectedIndex = khoa_index;
                //MessageBox.Show(Khoa_cbb.SelectedItem.ToString());
                LoadGVByKhoa();
                if (lop.CoVanId != null)
                {
                    cbbMaCV.SelectedItem = lop.CoVanId; // Chọn ID giảng viên
                    cbbTenCV.SelectedItem = giangvien_list.FirstOrDefault(gv => gv.Id == lop.CoVanId)?.Name; // Chọn tên giảng viên tương ứng
                }
                else
                {
                    cbbMaCV.SelectedIndex = 0;
                    cbbTenCV.SelectedIndex = 0;
                }
            }

            // Load giá trị mặc định cho ComboBox Hdt_cbb (HeDaoTao)
            int hdt_index = Hdt_cbb.Items.IndexOf(lop.HeDaoTao.Name);
            if (hdt_index != -1)
            {
                Hdt_cbb.SelectedIndex = hdt_index;
            }
        }

        private void loadCV()
        {
            giangvien_list = GiangVienBUS.GetGiangVienByKhoaId(lop.Khoa.Id);

            // Thêm giảng viên vào ComboBox MaCV (ID) và TenCV (Tên)
            foreach (GiangVienDTO giangvien in giangvien_list)
            {
                cbbMaCV.Items.Add(giangvien.Id);      // Thêm ID vào cbbMaCV
                cbbTenCV.Items.Add(giangvien.Name); // Thêm tên giảng viên vào cbbTenCV
            }

            // Thiết lập giá trị mặc định cho cbbMaCV và cbbTenCV dựa trên covan_id
            if (lop.CoVanId != null)
            {
                cbbMaCV.SelectedItem = lop.CoVanId; // Chọn ID giảng viên
                cbbTenCV.SelectedItem = giangvien_list.FirstOrDefault(gv => gv.Id == lop.CoVanId)?.Name; // Chọn tên giảng viên tương ứng
            }
        }

        private void LoadGVByKhoa()
        {
            // Xóa dữ liệu cũ trong ComboBox giảng viên
            cbbMaCV.Items.Clear();
            cbbTenCV.Items.Clear();

            cbbMaCV.Items.Add("--Chọn--");
            cbbTenCV.Items.Add("--Chọn--");

            // Lấy thông tin khoa đang chọn
            if (Khoa_cbb.SelectedIndex > 0)
            {
                string selectedKhoaName = Khoa_cbb.SelectedItem.ToString();
                KhoaDTO selectedKhoa = KhoaBUS.GetKhoaByName(selectedKhoaName);

                if (selectedKhoa != null)
                {

                    // Lấy danh sách giảng viên theo khoa
                    giangvien_list = GiangVienBUS.GetGiangVienByKhoaId(selectedKhoa.Id);

                    // Thêm giảng viên vào ComboBox
                    foreach (var giangvien in giangvien_list)
                    {
                        cbbMaCV.Items.Add(giangvien.Id);      // Thêm ID vào cbbMaCV
                        cbbTenCV.Items.Add(giangvien.Name); // Thêm tên vào cbbTenCV
                    }
                }
            }
            else
            {
                giangvien_list = null;
            }



            //// Reset trạng thái ComboBox

        }


        private bool check(String value)
        {
            bool rs = true;
            bool strResult = Regex.IsMatch(value, @"[^a-zA-Z0-9" + " " + "]");
            if (value == "")
            {
                MessageBox.Show("Không được để trống dữ liệu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rs = false;
            }
            //else if (strResult)
            //{
            //    MessageBox.Show("Dữ liệu nhập không hợp lệ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    rs = false;
            //}
            return rs;
        }
        private void update_btn_Click(object sender, EventArgs e)
        {
            if (check(text_lop.Text))
            {
                if (Khoa_cbb.SelectedIndex > 0)
                {
                    if (Hdt_cbb.SelectedIndex > 0)
                    {
                        KhoaDTO khoa = KhoaBUS.GetKhoaByName(Khoa_cbb.Text.ToString());
                        HeHocDTO hehoc = HeHocBUS.GetHeHocByName(Hdt_cbb.Text.ToString());
                        LopDTO value = new LopDTO();
                        value.Id = lop.Id;
                        value.TenLop = text_lop.Text;
                        value.Khoa = khoa;
                        value.HeDaoTao = hehoc;
                        value.CreatedAt = lop.CreatedAt;
                        value.UpdatedAt = DateTime.Now;
                        value.status = 1;
                        if (lop.CoVanId == null)
                        {
                            if (cbbMaCV.SelectedIndex != 0)
                            {
                                var danhSachLopCoVan = LopBUS.getAllLop().Where(lop => lop.CoVanId == long.Parse(cbbMaCV.SelectedItem.ToString())).ToList();
                                if (danhSachLopCoVan.Count == 0)
                                {
                                    AccountDTO account = AccountDAO.GetAccountById(long.Parse(cbbMaCV.SelectedItem.ToString()));
                                    account.Role = 3;
                                    AccountBUS.UpdateAccount(account);
                                }
                            }
                        }
                        else
                        {
                            if (cbbMaCV.SelectedIndex > 0)
                            {
                                var danhSachLopCoVan = LopBUS.getAllLop().Where(lop => lop.CoVanId == this.lop.CoVanId).ToList();
                                if (danhSachLopCoVan.Count == 0)
                                {
                                    AccountDTO account = AccountDAO.GetAccountById(lop.CoVanId ?? 0);
                                    account.Role = 2;
                                    AccountBUS.UpdateAccount(account);
                                }
                                danhSachLopCoVan = LopBUS.getAllLop().Where(lop => lop.CoVanId == long.Parse(cbbMaCV.SelectedItem.ToString())).ToList();
                                if (danhSachLopCoVan.Count == 0)
                                {
                                    AccountDTO account = AccountDAO.GetAccountById(long.Parse(cbbMaCV.SelectedItem.ToString()));
                                    account.Role = 3;
                                    AccountBUS.UpdateAccount(account);
                                }
                            }
                            else
                            {
                                var danhSachLopCoVan = LopBUS.getAllLop().Where(lop => lop.CoVanId == this.lop.CoVanId).ToList();
                                MessageBox.Show(danhSachLopCoVan.Count.ToString());
                                if (danhSachLopCoVan.Count - 1 == 0)
                                {
                                    AccountDTO account = AccountDAO.GetAccountById(this.lop.CoVanId ?? 0);
                                    account.Role = 2;
                                    AccountBUS.UpdateAccount(account);
                                }
                            }
                        }

                        // Gán giá trị CoVanId, nếu không có giảng viên thì gán null
                        value.CoVanId = (cbbMaCV.SelectedIndex != 0) ? (long?)long.Parse(cbbMaCV.SelectedItem.ToString()) : null;

                        bool isUpdate = LopBUS.UpdateLop(value);
                        if (isUpdate)
                        {

                            MessageBox.Show("Cập nhật hệ học thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không được để trống dữ liệu hệ học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Không được để trống dữ liệu khoa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void delete_lop_Click(object sender, EventArgs e)
        {
            var rs = MessageBox.Show("Bạn có chắc muốn xóa lớp này chứ ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (rs == DialogResult.OK)
            {
                bool isDeleted = LopBUS.DeleteLop(lop.Id);
                if (isDeleted)
                {
                    MessageBox.Show("Xóa lớp thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void SyncComboBoxes(ComboBox changedCbb, ComboBox targetCbb, List<GiangVienDTO> giangvienList)
        {
            if (changedCbb.SelectedItem != null)
            {
                if (changedCbb == cbbMaCV)
                {
                    if (changedCbb.SelectedIndex != 0)
                    {
                        // Nếu thay đổi trên cbbMaCV, đồng bộ cbbTenCV
                        long selectedId = long.Parse(changedCbb.SelectedItem.ToString());
                        var selectedGiangVien = giangvienList.FirstOrDefault(gv => gv.Id == selectedId);
                        if (selectedGiangVien != null)
                        {
                            targetCbb.SelectedItem = selectedGiangVien.Name;
                        }
                    }
                    else
                    {
                        targetCbb.SelectedIndex = 0;
                    }
                }
                else if (changedCbb == cbbTenCV)
                {
                    if (changedCbb.SelectedIndex != 0)
                    {
                        // Nếu thay đổi trên cbbTenCV, đồng bộ cbbMaCV
                        string selectedName = changedCbb.SelectedItem.ToString();
                        var selectedGiangVien = giangvienList.FirstOrDefault(gv => gv.Name == selectedName);
                        if (selectedGiangVien != null)
                        {
                            targetCbb.SelectedItem = selectedGiangVien.Id;
                        }
                    }
                    else
                    {
                        targetCbb.SelectedIndex = 0;
                    }

                }
            }
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Khoa_cbb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Khoa_cbb_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            LoadGVByKhoa();
            if (lop.CoVanId != null)
            {
                cbbMaCV.SelectedItem = lop.CoVanId; // Chọn ID giảng viên
                cbbTenCV.SelectedItem = giangvien_list.FirstOrDefault(gv => gv.Id == lop.CoVanId)?.Name; // Chọn tên giảng viên tương ứng
            }
            cbbMaCV.SelectedIndex = 0;
            cbbTenCV.SelectedIndex = 0;
        }
    }
}
