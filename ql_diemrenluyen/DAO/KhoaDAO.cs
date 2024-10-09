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
            string sql = "SELECT * FROM khoa"; // Câu lệnh SQL

            List<List<object>> result = DBConnection.ExecuteReader(sql);

            foreach (var row in result)
            {
                KhoaDTO khoa = new KhoaDTO
                {
                    Id = Convert.ToInt64(row[0]),
                    TenKhoa = Convert.ToString(row[1]),
                    CreatedAt = row[2] != null ? (DateTime?)Convert.ToDateTime(row[2]) : null,
                    UpdatedAt = row[3] != null ? (DateTime?)Convert.ToDateTime(row[3]) : null
                };

                khoaList.Add(khoa);
            }

            return khoaList;
        }

        // Thêm khoa mới
        public static bool AddKhoa(KhoaDTO khoa)
        {
            string sql = "INSERT INTO khoa (TenKhoa, CreatedAt, UpdatedAt) VALUES (@tenKhoa, @createdAt, @updatedAt)";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@tenKhoa", khoa.TenKhoa);
            cmd.Parameters.AddWithValue("@createdAt", khoa.CreatedAt);
            cmd.Parameters.AddWithValue("@updatedAt", khoa.UpdatedAt);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Cập nhật thông tin khoa
        public static bool UpdateKhoa(KhoaDTO khoa)
        {
            string sql = "UPDATE khoa SET TenKhoa = @tenKhoa, CreatedAt = @createdAt, UpdatedAt = @updatedAt WHERE Id = @id";

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
            string sql = "DELETE FROM khoa WHERE Id = @id";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", id);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }
    }
}
