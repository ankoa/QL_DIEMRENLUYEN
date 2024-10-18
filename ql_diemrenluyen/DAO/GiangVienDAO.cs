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
            string sql = "SELECT * FROM giangvien"; 

            List<List<object>> result = DBConnection.ExecuteReader(sql);

            foreach (var row in result)
            {
                GiangVienDTO giangVien = new GiangVienDTO
                {
                    Id = Convert.ToInt64(row[0]), 
                    Name = Convert.ToString(row[1]), 
                    Email = Convert.ToString(row[2]), 
                    CreatedAt = row[3] != null ? Convert.ToDateTime(row[3]) : (DateTime?)null, 
                    UpdatedAt = row[4] != null ? Convert.ToDateTime(row[4]) : (DateTime?)null, 
                    Position = Convert.ToString(row[5]),
                    KhoaId = Convert.ToInt64(row[6]) 
                };

                giangViens.Add(giangVien);
            }

            return giangViens;
        }

        // Thêm giảng viên mới
        public static bool AddGiangVien(GiangVienDTO giangVien)
        {
            string sql = $"INSERT INTO giangvien (name, email, created_at, updated_at, chucvu, khoa_id) " +
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
            string sql = $"UPDATE giangvien SET name = @name, email = @email, " +
                         $"created_at = @createdAt, updated_at = @updatedAt, chucvu = @position, khoa_id = @khoaId WHERE id = @id";

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
            string sql = $"DELETE FROM giangvien WHERE id = @id"; 
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", id);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }
    }
}
