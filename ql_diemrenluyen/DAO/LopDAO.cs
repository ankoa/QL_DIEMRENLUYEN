using MySql.Data.MySqlClient;
using ql_diemrenluyen.DTO;
using System;
using System.Collections.Generic;

namespace ql_diemrenluyen.DAO
{
    public class LopDAO
    {
        // Lấy tất cả lớp
        public static List<LopDTO> GetAllLop()
        {
            List<LopDTO> lopList = new List<LopDTO>();
            string sql = "SELECT * FROM lop"; // Câu lệnh SQL

            List<List<object>> result = DBConnection.ExecuteReader(sql);

            foreach (var row in result)
            {
                LopDTO lop = new LopDTO
                {
                    Id = Convert.ToInt64(row[0]),
                    TenLop = Convert.ToString(row[1]),
                    KhoaId = Convert.ToInt64(row[2]),
                    HeDaoTao = Convert.ToInt32(row[3]),
                    CreatedAt = row[4] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[4]) : null,
                    UpdatedAt = row[5] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[5]) : null
                };

                lopList.Add(lop);
            }

            return lopList;
        }

        // Thêm lớp mới
        public static bool AddLop(LopDTO lop)
        {
            string sql = "INSERT INTO lop (tenlop, khoa_id, hedaotao, created_at, updated_at) VALUES (@tenLop, @khoaId, @heDaoTao, @createdAt, @updatedAt)";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@tenLop", lop.TenLop);
            cmd.Parameters.AddWithValue("@khoaId", lop.KhoaId);
            cmd.Parameters.AddWithValue("@heDaoTao", lop.HeDaoTao);
            cmd.Parameters.AddWithValue("@createdAt", lop.CreatedAt);
            cmd.Parameters.AddWithValue("@updatedAt", lop.UpdatedAt);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Cập nhật thông tin lớp
        public static bool UpdateLop(LopDTO lop)
        {
            string sql = "UPDATE lop SET tenlop = @tenLop, khoa_id = @khoaId, hedaotao = @heDaoTao, created_at = @createdAt, updated_at = @updatedAt WHERE id = @id";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", lop.Id);
            cmd.Parameters.AddWithValue("@tenLop", lop.TenLop);
            cmd.Parameters.AddWithValue("@khoaId", lop.KhoaId);
            cmd.Parameters.AddWithValue("@heDaoTao", lop.HeDaoTao);
            cmd.Parameters.AddWithValue("@createdAt", lop.CreatedAt);
            cmd.Parameters.AddWithValue("@updatedAt", lop.UpdatedAt);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Xóa lớp
        public static bool DeleteLop(long id)
        {
            string sql = "DELETE FROM lop WHERE id = @id";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", id);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }
    }
}
