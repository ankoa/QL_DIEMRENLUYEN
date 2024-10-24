using MySql.Data.MySqlClient;
using ql_diemrenluyen.DTO;
using System;
using System.Collections.Generic;

namespace ql_diemrenluyen.DAO
{
    public class KhoaDAO
    {
        // Lấy tất cả khoa
        public static List<KhoaDTO> GetAllKhoa()
        {
            List<KhoaDTO> khoaList = new List<KhoaDTO>();
            string sql = "SELECT * FROM khoa"; 

            List<List<object>> result = DBConnection.ExecuteReader(sql);

            foreach (var row in result)
            {
                KhoaDTO khoa = new KhoaDTO
                {
                    Id = Convert.ToInt64(row[0]),
                    TenKhoa = Convert.ToString(row[1]),
                    CreatedAt = row[2] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[2]) : null,
                    UpdatedAt = row[3] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[3]) : null
                };

                khoaList.Add(khoa);
            }

            return khoaList;
        }

        // Lấy đối tượng khoa từ ID của khoa
        public static KhoaDTO GetKhoaByID(long id)
        {
            string sql = "select * from khoa where khoa.id= @id"; // Câu lệnh SQL
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", id);

            List<List<object>> result = DBConnection.ExecuteReader(cmd);

            if (result.Count > 0)
            {
                List<object> row = result[0];
                KhoaDTO khoa = new KhoaDTO
                {
                    Id = Convert.ToInt64(row[0]),
                    TenKhoa = Convert.ToString(row[1]),
                    CreatedAt = row[2] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[2]) : null,
                    UpdatedAt = row[3] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[3]) : null
                };
                return khoa;
            }

            return null;
        }

        // Thêm khoa mới
        public static bool AddKhoa(KhoaDTO khoa)
        {
            string sql = "INSERT INTO khoa (tenkhoa, created_at, updated_at) VALUES (@tenKhoa, @createdAt, @updatedAt)";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@tenKhoa", khoa.TenKhoa);
            cmd.Parameters.AddWithValue("@createdAt", khoa.CreatedAt);
            cmd.Parameters.AddWithValue("@updatedAt", khoa.UpdatedAt);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Cập nhật thông tin khoa
        public static bool UpdateKhoa(KhoaDTO khoa)
        {
            string sql = "UPDATE khoa SET tenkhoa = @tenKhoa, created_at = @createdAt, updated_at = @updatedAt WHERE id = @id";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", khoa.Id);
            cmd.Parameters.AddWithValue("@tenKhoa", khoa.TenKhoa);
            cmd.Parameters.AddWithValue("@createdAt", khoa.CreatedAt);
            cmd.Parameters.AddWithValue("@updatedAt", khoa.UpdatedAt);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Xóa khoa
        public static bool DeleteKhoa(long id)
        {
            string sql = "DELETE FROM khoa WHERE id = @id";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", id);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }
    }
}
