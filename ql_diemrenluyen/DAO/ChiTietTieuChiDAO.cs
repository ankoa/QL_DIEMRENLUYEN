using MySql.Data.MySqlClient;
using ql_diemrenluyen.DTO;
using System;
using System.Collections.Generic;

namespace ql_diemrenluyen.DAO
{
    public class ChiTietTieuChiDAO
    {
        // Lấy tất cả chi tiết tiêu chí
        public static List<ChiTietTieuChiDTO> GetAllChiTietTieuChi()
        {
            List<ChiTietTieuChiDTO> chiTietTieuChis = new List<ChiTietTieuChiDTO>();
            string sql = "SELECT * FROM chi_tiet_tieu_chi"; // Câu lệnh SQL

            List<List<object>> result = DBConnection.ExecuteReader(sql);

            foreach (var row in result)
            {
                ChiTietTieuChiDTO chiTietTieuChi = new ChiTietTieuChiDTO
                {
                    Id = Convert.ToInt64(row[0]), // Id
                    Name = Convert.ToString(row[1]), // Name
                    SoDiem = Convert.ToInt64(row[2]), // SoDiem
                    TieuChiId = Convert.ToInt64(row[3]), // TieuChiId
                    CreatedAt = row[4] != null ? Convert.ToDateTime(row[4]) : (DateTime?)null, // CreatedAt
                    UpdatedAt = row[5] != null ? Convert.ToDateTime(row[5]) : (DateTime?)null // UpdatedAt
                };

                chiTietTieuChis.Add(chiTietTieuChi);
            }

            return chiTietTieuChis;
        }

        // Thêm chi tiết tiêu chí mới
        public static bool AddChiTietTieuChi(ChiTietTieuChiDTO chiTietTieuChi)
        {
            string sql = "INSERT INTO chi_tiet_tieu_chi (Name, SoDiem, TieuChiId, CreatedAt, UpdatedAt) " +
                         "VALUES (@name, @soDiem, @tieuChiId, @createdAt, @updatedAt)";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@name", chiTietTieuChi.Name);
            cmd.Parameters.AddWithValue("@soDiem", chiTietTieuChi.SoDiem);
            cmd.Parameters.AddWithValue("@tieuChiId", chiTietTieuChi.TieuChiId);
            cmd.Parameters.AddWithValue("@createdAt", chiTietTieuChi.CreatedAt);
            cmd.Parameters.AddWithValue("@updatedAt", chiTietTieuChi.UpdatedAt);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Cập nhật thông tin chi tiết tiêu chí
        public static bool UpdateChiTietTieuChi(ChiTietTieuChiDTO chiTietTieuChi)
        {
            string sql = "UPDATE chi_tiet_tieu_chi SET Name = @name, SoDiem = @soDiem, " +
                         "TieuChiId = @tieuChiId, CreatedAt = @createdAt, UpdatedAt = @updatedAt WHERE Id = @id";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", chiTietTieuChi.Id);
            cmd.Parameters.AddWithValue("@name", chiTietTieuChi.Name);
            cmd.Parameters.AddWithValue("@soDiem", chiTietTieuChi.SoDiem);
            cmd.Parameters.AddWithValue("@tieuChiId", chiTietTieuChi.TieuChiId);
            cmd.Parameters.AddWithValue("@createdAt", chiTietTieuChi.CreatedAt);
            cmd.Parameters.AddWithValue("@updatedAt", chiTietTieuChi.UpdatedAt);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Xóa chi tiết tiêu chí
        public static bool DeleteChiTietTieuChi(long id)
        {
            string sql = "DELETE FROM chi_tiet_tieu_chi WHERE Id = @id";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", id);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }
    }
}
