using MySql.Data.MySqlClient;
using ql_diemrenluyen.DTO;
using System.Collections.Generic;

namespace ql_diemrenluyen.DAO
{
    public class GiangVienDAO
    {
        // Lấy tất cả giảng viên
        public static List<GiangVienDTO> GetAllGiangVien()
        {
            List<GiangVienDTO> giangViens = new List<GiangVienDTO>();
            string sql = "SELECT * FROM giangvien"; 

            List<List<object>> result = DBConnection.ExecuteReader(sql);

            foreach (var row in result)
            {
                GiangVienDTO giangVien = new GiangVienDTO
                {
                    Id = Convert.ToString(row[0]), 
                    Name = Convert.ToString(row[1]), 
                    Email = Convert.ToString(row[2]), 
                    CreatedAt = row[3] != null ? Convert.ToDateTime(row[3]) : (DateTime?)null, 
                    UpdatedAt = row[4] != null ? Convert.ToDateTime(row[4]) : (DateTime?)null, 
                    ChucVu = Convert.ToString(row[5]),
                    KhoaId = Convert.ToString(row[6]) 
                };

                giangViens.Add(giangVien);
            }

            return giangViens;
        }

        // Thêm giảng viên mới
        public static bool AddGiangVien(GiangVienDTO giangVien)
        {
            string sql = $"INSERT INTO giangvien (name, email, created_at, updated_at, chucvu, khoa_id) " +
                         $"VALUES (@name, @email, @createdAt, @updatedAt, @ChucVu, @khoaId)";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@name", giangVien.Name);
            cmd.Parameters.AddWithValue("@email", giangVien.Email);
            cmd.Parameters.AddWithValue("@createdAt", giangVien.CreatedAt);
            cmd.Parameters.AddWithValue("@updatedAt", giangVien.UpdatedAt);
            cmd.Parameters.AddWithValue("@ChucVu", giangVien.ChucVu);
            cmd.Parameters.AddWithValue("@khoaId", giangVien.KhoaId);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Cập nhật thông tin giảng viên
        public static bool UpdateGiangVien(GiangVienDTO giangVien)
        {
            string sql = $"UPDATE giangvien SET name = @name, email = @email, " +
                         $"created_at = @createdAt, updated_at = @updatedAt, chucvu = @ChucVu, khoa_id = @khoaId WHERE id = @id";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", giangVien.Id);
            cmd.Parameters.AddWithValue("@name", giangVien.Name);
            cmd.Parameters.AddWithValue("@email", giangVien.Email);
            cmd.Parameters.AddWithValue("@createdAt", giangVien.CreatedAt);
            cmd.Parameters.AddWithValue("@updatedAt", giangVien.UpdatedAt);
            cmd.Parameters.AddWithValue("@ChucVu", giangVien.ChucVu);
            cmd.Parameters.AddWithValue("@khoaId", giangVien.KhoaId);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Xóa giảng viên
        public static bool DeleteGiangVien(long id)
        {
            string sql = $"DELETE FROM giangvien WHERE id = @id"; 
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", id);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Lấy giảng viên theo Email
        public static GiangVienDTO GetGiangVienByEmail(string email)
        {
            string sql = "SELECT * FROM giangvien WHERE email = @email";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@email", email);

            List<List<object>> result = DBConnection.ExecuteReader(cmd);

            if (result.Count > 0)
            {
                return MapToGiangVienDTO(result[0]);
            }

            return null; // Trả về null nếu không tìm thấy giảng viên
        }

        // Lấy giảng viên theo Id
        public static GiangVienDTO GetGiangVienById(long id)
        {
            string sql = "SELECT * FROM giangvien WHERE id = @id";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", id);

            List<List<object>> result = DBConnection.ExecuteReader(cmd);

            if (result.Count > 0)
            {
                return MapToGiangVienDTO(result[0]);
            }

            return null; // Trả về null nếu không tìm thấy giảng viên
        }

        // Tìm kiếm giảng viên theo từ khóa
        public static List<GiangVienDTO> SearchGiangVien(string searchTerm)
        {
            List<GiangVienDTO> giangViens = new List<GiangVienDTO>();
            string sql = "SELECT * FROM giangvien WHERE name LIKE @searchTerm OR email LIKE @searchTerm";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");

            List<List<object>> result = DBConnection.ExecuteReader(cmd);

            foreach (var row in result)
            {
                GiangVienDTO giangVien = new GiangVienDTO
                {
                    Id = Convert.ToString(row[0]), 
                    Name = Convert.ToString(row[1]), 
                    Email = Convert.ToString(row[2]), 
                    CreatedAt = row[3] != null ? Convert.ToDateTime(row[3]) : (DateTime?)null, 
                    UpdatedAt = row[4] != null ? Convert.ToDateTime(row[4]) : (DateTime?)null, 
                    ChucVu = Convert.ToString(row[5]),
                    KhoaId = Convert.ToString(row[6]) 
                };

                giangViens.Add(giangVien);
            }

            return giangViens;
        }

        private static GiangVienDTO MapToGiangVienDTO(List<object> row)
        {
            return new GiangVienDTO
            {
                Id = Convert.ToString(row[0]),
                Name = row[1].ToString(),
                Email = row[2].ToString(),
                ChucVu = row[3]?.ToString(),
                CreatedAt = row[4] as DateTime?,
                UpdatedAt = row[5] as DateTime?
            };
        }
    }
}
