using System;
using System.Collections.Generic;
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
            string sql = "SELECT * FROM sinhvien"; // Câu lệnh SQL để lấy dữ liệu

            List<List<object>> result = DBConnection.ExecuteReader(sql);

            foreach (var row in result)
            {
                SinhVienDTO student = new SinhVienDTO
                {
                    Id = Convert.ToInt64(row[0]), // ID
                    Name = Convert.ToString(row[1]), // Tên
                    MaSv = Convert.ToString(row[2]), // Mã sinh viên
                    NgaySinh = Convert.ToString(row[3]), // Ngày sinh
                    Email = Convert.ToString(row[4]), // Email
                    GioiTinh = Convert.ToInt32(row[5]), // Giới tính
                    LopId = Convert.ToInt64(row[6]), // ID lớp
                    ChucVu = Convert.ToInt32(row[7]) // Chức vụ
                };

                students.Add(student);
            }

            return students;
        }

        // Thêm sinh viên mới
        public static bool AddStudent(SinhVienDTO student)
        {
            string sql = $"INSERT INTO sinhvien (name, maSv, ngaySinh, email, gioiTinh, lopId, chucVu) " +
                         $"VALUES (@name, @maSv, @ngaySinh, @email, @gioiTinh, @lopId, @chucVu)";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@name", student.Name);
            cmd.Parameters.AddWithValue("@maSv", student.MaSv);
            cmd.Parameters.AddWithValue("@ngaySinh", student.NgaySinh);
            cmd.Parameters.AddWithValue("@email", student.Email);
            cmd.Parameters.AddWithValue("@gioiTinh", student.GioiTinh);
            cmd.Parameters.AddWithValue("@lopId", student.LopId);
            cmd.Parameters.AddWithValue("@chucVu", student.ChucVu);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Cập nhật thông tin sinh viên
        public static bool UpdateStudent(SinhVienDTO student)
        {
            string sql = $"UPDATE sinhvien SET name = @name, maSv = @maSv, ngaySinh = @ngaySinh, email = @email, " +
                         $"gioiTinh = @gioiTinh, lopId = @lopId, chucVu = @chucVu WHERE id = @id";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", student.Id);
            cmd.Parameters.AddWithValue("@name", student.Name);
            cmd.Parameters.AddWithValue("@maSv", student.MaSv);
            cmd.Parameters.AddWithValue("@ngaySinh", student.NgaySinh);
            cmd.Parameters.AddWithValue("@email", student.Email);
            cmd.Parameters.AddWithValue("@gioiTinh", student.GioiTinh);
            cmd.Parameters.AddWithValue("@lopId", student.LopId);
            cmd.Parameters.AddWithValue("@chucVu", student.ChucVu);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Xóa sinh viên
        public static bool DeleteStudent(long id)
        {
            string sql = $"DELETE FROM sinhvien WHERE id = @id";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", id);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }
    }
}
