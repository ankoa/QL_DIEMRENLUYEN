using System.Diagnostics;
using MySql.Data.MySqlClient;
using ql_diemrenluyen.DTO;

namespace ql_diemrenluyen.DAO
{
    public class SinhVienDAO
    {
        // Lấy tất cả sinh viên
        public static List<SinhVienDTO> GetAllStudents()
        {
            List<SinhVienDTO> students = new List<SinhVienDTO>();
            string sql = "SELECT * FROM sinhvien  ";

            List<List<object>> result = DBConnection.ExecuteReader(sql);

            foreach (var row in result)
            {
                SinhVienDTO student = MapToSinhVienDTO(row);
                students.Add(student);
            }

            return students;
        }

        // Lấy sinh viên theo ID
        public static SinhVienDTO GetStudentById(long id)
        {
            string sql = "SELECT * FROM sinhvien WHERE id = @id";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", id);

            List<List<object>> result = DBConnection.ExecuteReader(cmd);

            if (result.Count > 0)
            {
                return MapToSinhVienDTO(result[0]);
            }

            return null; // Trả về null nếu không tìm thấy sinh viên
        }

        // Thêm sinh viên mới
        public static bool AddStudent(SinhVienDTO student)
        {
            try
            {
                string sql = "INSERT INTO sinhvien (name, id, ngaySinh, email, gioiTinh, lop_id, chucVu, created_at, updated_at,status) " +
                             "VALUES (@name, @id, @ngaySinh, @email, @gioiTinh, @lopId, @chucVu, @createdAt, @updatedAt,@status)";

                var cmd = new MySqlCommand(sql);
                cmd.Parameters.AddWithValue("@name", student.Name);
                cmd.Parameters.AddWithValue("@id", student.Id);
                cmd.Parameters.AddWithValue("@ngaySinh", student.NgaySinh.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@email", student.Email);
                cmd.Parameters.AddWithValue("@gioiTinh", student.GioiTinh);
                cmd.Parameters.AddWithValue("@lopId", student.LopId);
                cmd.Parameters.AddWithValue("@chucVu", student.ChucVu);
                cmd.Parameters.AddWithValue("@createdAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@updatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@status",1);
                return DBConnection.ExecuteNonQuery(cmd) > 0;
            }

           
            
            catch (MySqlException ex)
{
                // Xử lý lỗi MySQL
                Debug.WriteLine("Lỗi MySQL: " + ex.Message);
                // Nếu cần, bạn có thể kiểm tra mã lỗi (error code)
                Debug.WriteLine("Mã lỗi: " + ex.Number);
            }
            catch (Exception ex)
            {
                // Xử lý các ngoại lệ khác
                Debug.WriteLine("Lỗi chung: " + ex.Message);
            }
            return false;
        }
       
        // Cập nhật thông tin sinh viên
        public static bool UpdateStudent(SinhVienDTO student)
        {
            string sql = "UPDATE sinhvien SET name = @name,ngaySinh = @ngaySinh, email = @email, " +
                         "gioiTinh = @gioiTinh, lop_id = @lopId, chucVu = @chucVu, updated_at = @updatedAt WHERE id = @id";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", student.Id);
            cmd.Parameters.AddWithValue("@name", student.Name);
            cmd.Parameters.AddWithValue("@ngaySinh", student.NgaySinh.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@email", student.Email);
            cmd.Parameters.AddWithValue("@gioiTinh", student.GioiTinh);
            cmd.Parameters.AddWithValue("@lopId", student.LopId);
            cmd.Parameters.AddWithValue("@chucVu", student.ChucVu);
            cmd.Parameters.AddWithValue("@updatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Xóa sinh viên
        public static bool DeleteStudent(long id)
        {
            string sql = "UPDATE sinhvien SET status=0 WHERE id = @id";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", id);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Hàm helper để chuyển dữ liệu từ List<object> sang SinhVienDTO
        private static SinhVienDTO MapToSinhVienDTO(List<object> row)
        {
            return new SinhVienDTO
            {
                Id = Convert.ToInt64(row[0]),
                Name = Convert.ToString(row[1]),
                NgaySinh = Convert.ToDateTime(row[2]),
                Email = Convert.ToString(row[3]),
                GioiTinh = Convert.ToInt32(row[4]),
                LopId = Convert.ToInt64(row[5]),
                ChucVu = Convert.ToInt32(row[6]),
                CreatedAt = Convert.ToDateTime(row[7]),
                UpdatedAt = Convert.ToDateTime(row[8]),
                status = Convert.ToInt32(row[9]) 
            };
        }
    }
}