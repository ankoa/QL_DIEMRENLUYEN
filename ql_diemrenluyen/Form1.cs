using MySql.Data.MySqlClient;
using ql_diemrenluyen.DAO;
using ql_diemrenluyen.DTO;
using System.Data;

namespace ql_diemrenluyen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Tạo đối tượng SinhVienDTO và gán giá trị trực tiếp
            SinhVienDTO student = new SinhVienDTO
            {
                Name = "Nguyễn Văn ADFFF",  // Tên sinh viên
                NgaySinh = new DateTime(2000, 5, 8), // Ngày sinh
                Email = "nguyenvana@example.com", // Email
                GioiTinh = 1,            // Giới tính: 1 cho Nam, 0 cho Nữ (giả sử dùng int cho giới tính)
                LopId = 1,              // ID lớp (giả sử là lớp 1)
                ChucVu = 0               // Chức vụ: 0 cho sinh viên (giả sử dùng int cho chức vụ)
            };

            // Gọi phương thức AddStudent để thêm sinh viên
            if (SinhVienDAO.AddStudent(student))  // Gọi phương thức từ SinhVienDAO
            {
                MessageBox.Show("Thêm sinh viên thành công!");
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi thêm sinh viên.");
            }

            // Lấy danh sách sinh viên (nếu cần)
            LoadStudentIds();
        }


        /*private void button1_Click(object sender, EventArgs e)
        {
            // Đặt giá trị cho các trường dữ liệu
            string studentName = "Nguyễn Văn ABV"; // Tên sinh viên
            string birthDate = "2024-05-08"; // Ngày sinh (YYYY-MM-DD cho MySQL)
            string email = "nguyenvana@example.com"; // Email sinh viên
            string gender = "Nam"; // Giới tính (có thể là 'Nam', 'Nữ', hoặc 'Khác')
            int classId = 1; // ID lớp, đảm bảo giá trị hợp lệ
            string position = "Sinh viên"; // Chức vụ (có thể là 'Sinh viên', 'Thực tập sinh', v.v.)
            string createdAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); // Thời gian hiện tại
            string updatedAt = createdAt; // Thời gian cập nhật cũng là thời gian hiện tại

            // Câu lệnh chèn sinh viên mới vào bảng
            string insertSql = "INSERT INTO `sinhvien` (`name`, `ngaysinh`, `email`, `gioitinh`, `lop_id`, `chucvu`, `created_at`, `updated_at`) " +
                               "VALUES (@name, @birthDate, @email, @gender, @classId, @position, @createdAt, @updatedAt);";

            // Tạo đối tượng MySqlCommand và thêm tham số
            MySqlCommand insertCommand = new MySqlCommand(insertSql);
            insertCommand.Parameters.AddWithValue("@name", studentName);
            insertCommand.Parameters.AddWithValue("@birthDate", birthDate);
            insertCommand.Parameters.AddWithValue("@email", email);
            insertCommand.Parameters.AddWithValue("@gender", gender);
            insertCommand.Parameters.AddWithValue("@classId", classId); // Đảm bảo truyền ID lớp hợp lệ
            insertCommand.Parameters.AddWithValue("@position", position); // Đảm bảo truyền chức vụ hợp lệ
            insertCommand.Parameters.AddWithValue("@createdAt", createdAt);
            insertCommand.Parameters.AddWithValue("@updatedAt", updatedAt);

            // Thực hiện chèn vào cơ sở dữ liệu
            try
            {
                int rowsAffected = DBConnection.ExecuteNonQuery(insertCommand);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Thêm sinh viên thành công!");
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra khi thêm sinh viên.");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}"); // Hiển thị thông báo lỗi
            }

            // Lấy danh sách sinh viên
            LoadStudentIds();
        }
        */


        private void LoadStudentIds()
        {
            string sql = "SELECT id FROM sinhvien"; // Câu lệnh lấy ID sinh viên
            List<List<object>> result = DBConnection.ExecuteReader(sql); // Gọi hàm đọc dữ liệu

            listBoxStudents.Items.Clear(); // Xóa danh sách trước khi thêm dữ liệu mới

            if (result.Count > 0)
            {
                foreach (var row in result)
                {
                    try
                    {
                        int id = Convert.ToInt32(row[0]); // Chuyển đổi phần tử đầu tiên của hàng (id) sang int
                        listBoxStudents.Items.Add(id); // Thêm giá trị id vào listBox
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi chuyển đổi dữ liệu: {ex.Message}");
                    }
                }
                textBox1.Text = "Kết nối thành công! Dữ liệu đã được lấy.";
            }
            else
            {
                textBox1.Text = "Kết nối thành công nhưng không có dữ liệu.";
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
