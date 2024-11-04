using ql_diemrenluyen.BUS;
using ql_diemrenluyen.DTO;

namespace ql_diemrenluyen.GUI.ADMIN.Account
{
    public partial class AddDotCham : Form
    {
        private long currentAccountId;
        private DotCham mainForm;
        private DataGridView table;
        public AddDotCham(int id, string hocky, string namhoc, string nguoicham, DateTime createdAt, DateTime updatedAt, DataGridView dataGridView, DotCham tkform)
        {
            table = dataGridView;
            mainForm = tkform;
            InitializeComponent();

            // Set the values for the form fields
            txtId.Text = id.ToString();
            txtPassword.Text = hocky;
            txtRole.Text = namhoc;
            txtRememberToken.Text = nguoicham;
            //MessageBox.Show(createdAt.ToString());

            DateTime minValidDate = dtpCreatedAt.MinDate;
            dtpCreatedAt.Value = createdAt;
            //if (createdAt >= minValidDate)
            //{
            //    dtpCreatedAt.Value = createdAt;
            //}
            //else
            //{
            //    dtpCreatedAt.Value = DateTime.Now;
            //}
            dtpCreatedAt.CustomFormat = "yyyy-MM-dd";
            dtpCreatedAt.Format = DateTimePickerFormat.Custom;

            // Configure DateTimePicker for UpdatedAt
            dtpUpdatedAt.Value = updatedAt;
            //if (updatedAt >= minValidDate)
            //{
            //    dtpUpdatedAt.Value = updatedAt;
            //}
            //else
            //{
            //    dtpUpdatedAt.Value = DateTime.Now; // Fallback to current date if the value is invalid
            //}
            dtpUpdatedAt.CustomFormat = "yyyy-MM-dd";
            dtpUpdatedAt.Format = DateTimePickerFormat.Custom;

            // Load status into ComboBox
            //comboBox1.SelectedItem = status;

            comboBox1.Enabled = true; // Cho phép chọn trạng thái

            // Lưu ID của tài khoản hiện tại để sử dụng khi cập nhật
            currentAccountId = id;
        }



        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận trước khi cập nhật tài khoản
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn cập nhật đợt chấm không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                // Thực hiện cập nhật tài khoản ngay khi nhấn nút Sửa
                DotChamDiemDTO dotcham = DotChamDiemBUS.GetDotChamDiemById((int)currentAccountId);
                dotcham.StartDate = dtpCreatedAt.Value;
                dotcham.EndDate = dtpUpdatedAt.Value;

                // Gọi phương thức cập nhật tài khoản
                bool result = DotChamDiemBUS.UpdateDotChamDiem(dotcham);

                if (result)
                {
                    MessageBox.Show("Cập nhật đợt chấm thành công!");

                    // Gọi phương thức để tải lại bảng trong TaiKhoan
                    DotCham.LoadDotChamDiemList(table); // Gọi qua tên lớp

                    this.Close(); // Đóng form sau khi cập nhật thành công
                }
                else
                {
                    MessageBox.Show("Cập nhật đợt chấm không thành công. Vui lòng kiểm tra lại!");
                }
            }
        }




        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
