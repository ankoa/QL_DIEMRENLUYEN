using ql_diemrenluyen.BUS;
using ql_diemrenluyen.DAO;
using ql_diemrenluyen.DTO;

namespace ql_diemrenluyen.GUI.ADMIN.Account
{
    public partial class ThemDotCham : Form
    {
        private long currentAccountId;
        private DotCham mainForm;
        private DataGridView table;
        public ThemDotCham(DataGridView dataGridView, DotCham tkform)
        {
            table = dataGridView;
            mainForm = tkform;
            InitializeComponent();
            LoadYearsToComboBox();

            // Set the values for the form fields
            cbbhocki.SelectedItem = "Chọn học kì";
            cbbnamhoc.SelectedItem = "Chọn năm học";
            cbbnguoicham.SelectedItem = "Chọn người chấm";

            //MessageBox.Show(createdAt.ToString());

            dtpCreatedAt.Value = DateTime.Now;

            dtpCreatedAt.CustomFormat = "dd-MM-yyyy";
            dtpCreatedAt.Format = DateTimePickerFormat.Custom;

            // Configure DateTimePicker for UpdatedAt
            dtpCreatedAt.Value = DateTime.Now;

            dtpUpdatedAt.CustomFormat = "dd-MM-yyyy";
            dtpUpdatedAt.Format = DateTimePickerFormat.Custom;

            // Load status into ComboBox
            //comboBox1.SelectedItem = status;

            comboBox1.Enabled = true; // Cho phép chọn trạng thái
            comboBox1.SelectedIndex = 0;


        }

        public void LoadYearsToComboBox()
        {
            int currentYear = DateTime.Now.Year;

            // Duyệt từ năm hiện tại đến 10 năm sau
            for (int year = currentYear; year <= currentYear + 10; year++)
            {
                // Kiểm tra nếu năm chưa có trong ComboBox thì thêm vào
                if (!cbbnamhoc.Items.Contains(year))
                {
                    cbbnamhoc.Items.Add(year);
                }
            }
        }

        public bool checkDate()
        {
            // Lấy múi giờ Việt Nam
            TimeZoneInfo vietnamTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
            DateTime vietnamNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, vietnamTimeZone).Date;

            // Kiểm tra nếu ngày bắt đầu nhỏ hơn ngày hiện tại (theo giờ Việt Nam)
            if (dtpCreatedAt.Value < vietnamNow)
            {
                MessageBox.Show("Ngày bắt đầu phải lớn hơn hoặc bằng ngày hôm nay");
                return false;
            }

            // Kiểm tra nếu ngày kết thúc nhỏ hơn hoặc bằng ngày bắt đầu
            if (dtpUpdatedAt.Value <= dtpCreatedAt.Value)
            {
                MessageBox.Show("Ngày kết thúc phải lớn hơn ngày bắt đầu");
                return false;
            }

            return true;
        }

        public bool checkValidData()
        {
            if (cbbhocki.SelectedIndex == 0)
            {
                MessageBox.Show("Chọn học kì");
                return false;
            }
            if (cbbnamhoc.SelectedIndex == 0)
            {
                MessageBox.Show("Chọn năm học");
                return false;
            }
            if (cbbnguoicham.SelectedIndex == 0)
            {
                MessageBox.Show("Chọn người chấm");
                return false;
            }
            if (!checkDate())
            {
                return false;
            }
            return true;
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận trước khi cập nhật tài khoản
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn cập nhật đợt chấm không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.No)
            {
                return;
            }

            if (!checkValidData())
            {
                return;
            }

            string hocki = cbbhocki.SelectedItem.ToString();
            int namehoc = Convert.ToInt32(cbbnamhoc.SelectedItem);
            HocKyDTO hockidto = HocKyBUS.GetHocKyByNameAndYear(hocki, namehoc);

            if (hockidto == null)
            {
                hockidto = new HocKyDTO
                {
                    Name = hocki,
                    namhoc = namehoc,
                };
                if (!HocKyBUS.AddHocKy(hockidto))
                {
                    MessageBox.Show("Có lỗi xảy ra");
                    return;
                }
                hockidto = HocKyBUS.GetHocKyByNameAndYear(hocki, namehoc);
            }

            string nguoicham = cbbnguoicham.SelectedItem.ToString();

            if (!DotChamDiemBUS.CheckValidDotChamDiem(hocki, namehoc, nguoicham, dtpCreatedAt.Value, dtpUpdatedAt.Value))
            {
                return;
            }

            string status = comboBox1.SelectedItem.ToString();

            DotChamDiemDTO dotcham = new DotChamDiemDTO
            {
                HocKiId = hockidto.Id,
                Name = nguoicham,
                EndDate = dtpUpdatedAt.Value,
                StartDate = dtpCreatedAt.Value,
                Status = status == "Hoạt động" ? 1 : -1
            };



            if (nguoicham == "Cố vấn")
            {
                if (!LopBUS.AreAllClassesAssignedToAdvisor())
                {
                    MessageBox.Show("Có lớp chưa có cố vấn, hãy thử lại");
                    this.Close();
                    return;
                }
            }

            DotChamDiemDTO result = DotChamDiemBUS.AddDotChamDiem(dotcham);

            if (result != null)
            {
                bool res = false;
                if (nguoicham == "Sinh viên")
                {
                    res = ThongTinDotChamDAO.AddThongTinDotChamDiemSinhVien(result.Id);
                }
                else if (nguoicham == "Cố vấn")
                {
                    res = ThongTinDotChamDAO.AddThongTinDotChamDiemCoVan(result.Id);
                }
                else if (nguoicham == "Khoa")
                {
                    res = ThongTinDotChamDAO.AddThongTinDotChamDiemKhoa(result.Id);
                }
                else if (nguoicham == "Trường")
                {
                    res = ThongTinDotChamDAO.AddThongTinDotChamDiemTruong(result.Id);
                }

                if (res)
                {
                    MessageBox.Show("Thêm đợt chấm thành công!");

                    // Gọi phương thức để tải lại bảng trong TaiKhoan
                    mainForm.SearchAccountList(); // Gọi qua tên lớp

                    this.Close(); // Đóng form sau khi cập nhật thành công
                }
                else
                {
                    MessageBox.Show("Cập nhật đợt chấm không thành công. Vui lòng kiểm tra lại!");
                }

            }
            else
            {
                MessageBox.Show("Cập nhật đợt chấm không thành công. Vui lòng kiểm tra lại!");
            }
        }




        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
