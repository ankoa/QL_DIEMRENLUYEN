using MySql.Data.MySqlClient;
using ql_diemrenluyen.DTO;
using System;
using System.Collections.Generic;

namespace ql_diemrenluyen.DAO
{
    public class GiangVienDAO
    {
        // Lấy tất cả giảng viên
        public static List<GiangVienDTO> GetAllGiangVien()
        {
            List<GiangVienDTO> giangViens = new List<GiangVienDTO>();
            string sql = "SELECT * FROM giang_vien"; // Thay đổi câu lệnh SQL nếu cần

            List<List<object>> result = DBConnection.ExecuteReader(sql);

            foreach (var row in result)
            {
                GiangVienDTO giangVien = new GiangVienDTO
                {
                    Id = Convert.ToInt64(row[0]), // Id
                    Name = Convert.ToString(row[1]), // Name
                    Email = Convert.ToString(row[2]), // Email
                    CreatedAt = row[3] != null ? Convert.ToDateTime(row[3]) : (DateTime?)null, // CreatedAt
                    UpdatedAt = row[4] != null ? Convert.ToDateTime(row[4]) : (DateTime?)null, // UpdatedAt
                    Position = Convert.ToString(row[5]), // Position
                    KhoaId = Convert.ToInt64(row[6]) // KhoaId
                };

                giangViens.Add(giangVien);
            }

            return giangViens;
        }

        // Thêm giảng viên mới
        public static bool AddGiangVien(GiangVienDTO giangVien)
        {
            string sql = $"INSERT INTO giang_vien (Name, Email, CreatedAt, UpdatedAt, Position, KhoaId) " +
                         $"VALUES (@name, @email, @createdAt, @updatedAt, @position, @khoaId)";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@name", giangVien.Name);
            cmd.Parameters.AddWithValue("@email", giangVien.Email);
            cmd.Parameters.AddWithValue("@createdAt", giangVien.CreatedAt);
            cmd.Parameters.AddWithValue("@updatedAt", giangVien.UpdatedAt);
            cmd.Parameters.AddWithValue("@position", giangVien.Position);
            cmd.Parameters.AddWithValue("@khoaId", giangVien.KhoaId);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Cập nhật thông tin giảng viên
        public static bool UpdateGiangVien(GiangVienDTO giangVien)
        {
            string sql = $"UPDATE giang_vien SET Name = @name, Email = @email, " +
                         $"CreatedAt = @createdAt, UpdatedAt = @updatedAt, Position = @position, KhoaId = @khoaId WHERE Id = @id";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", giangVien.Id);
            cmd.Parameters.AddWithValue("@name", giangVien.Name);
            cmd.Parameters.AddWithValue("@email", giangVien.Email);
            cmd.Parameters.AddWithValue("@createdAt", giangVien.CreatedAt);
            cmd.Parameters.AddWithValue("@updatedAt", giangVien.UpdatedAt);
            cmd.Parameters.AddWithValue("@position", giangVien.Position);
            cmd.Parameters.AddWithValue("@khoaId", giangVien.KhoaId);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Xóa giảng viên
        public static bool DeleteGiangVien(long id)
        {
            string sql = $"DELETE FROM giang_vien WHERE Id = @id";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", id);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }
    }
}
