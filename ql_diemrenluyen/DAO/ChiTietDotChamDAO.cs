using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using ql_diemrenluyen.DTO;

namespace ql_diemrenluyen.DAO
{
    public class ChiTietDotChamDAO
    {
        // Lấy tất cả chi tiết đợt chấm
        public static List<ChiTietDotChamDTO> GetAllChiTietDotCham()
        {
            List<ChiTietDotChamDTO> chiTietDotChams = new List<ChiTietDotChamDTO>();
            string sql = "SELECT * FROM chitietdotcham"; // Thay đổi câu lệnh SQL nếu cần

            List<List<object>> result = DBConnection.ExecuteReader(sql);

            foreach (var row in result)
            {
                ChiTietDotChamDTO chiTietDotCham = new ChiTietDotChamDTO(
                    Convert.ToInt64(row[0]), // Id
                    Convert.ToInt32(row[1]), // Diem
                    Convert.ToInt32(row[2]), // DotChamId
                    Convert.ToInt64(row[3]), // ChiTietTieuChiId
                    Convert.ToInt64(row[4]), // SinhVienId
                    Convert.ToInt64(row[5]), // CoVanId
                    Convert.ToInt64(row[6]), // KhoaId
                    Convert.ToInt32(row[7]), // Final
                    Convert.ToInt32(row[8]), // HocKiId
                    row[9] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[9]) : null, // CreatedAt
                    row[10] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[10]) : null // UpdatedAt
                );

                chiTietDotChams.Add(chiTietDotCham);
            }

            return chiTietDotChams;
        }

        // Thêm chi tiết đợt chấm mới
        public static bool AddChiTietDotCham(ChiTietDotChamDTO chiTietDotCham)
        {
            string sql = $"INSERT INTO chitietdotcham (Diem, DotChamId, ChiTietTieuChiId, SinhVienId, CoVanId, KhoaId, Final, HocKiId, CreatedAt, UpdatedAt) " +
                         $"VALUES (@diem, @dotChamId, @chiTietTieuChiId, @sinhVienId, @coVanId, @khoaId, @final, @hocKiId, @createdAt, @updatedAt)";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@diem", chiTietDotCham.Diem);
            cmd.Parameters.AddWithValue("@dotChamId", chiTietDotCham.DotChamId);
            cmd.Parameters.AddWithValue("@chiTietTieuChiId", chiTietDotCham.ChiTietTieuChiId);
            cmd.Parameters.AddWithValue("@sinhVienId", chiTietDotCham.SinhVienId);
            cmd.Parameters.AddWithValue("@coVanId", chiTietDotCham.CoVanId);
            cmd.Parameters.AddWithValue("@khoaId", chiTietDotCham.KhoaId);
            cmd.Parameters.AddWithValue("@final", chiTietDotCham.Final);
            cmd.Parameters.AddWithValue("@hocKiId", chiTietDotCham.HocKiId);
            cmd.Parameters.AddWithValue("@createdAt", chiTietDotCham.CreatedAt);
            cmd.Parameters.AddWithValue("@updatedAt", chiTietDotCham.UpdatedAt);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Cập nhật thông tin chi tiết đợt chấm
        public static bool UpdateChiTietDotCham(ChiTietDotChamDTO chiTietDotCham)
        {
            string sql = $"UPDATE chitietdotcham SET Diem = @diem, DotChamId = @dotChamId, ChiTietTieuChiId = @chiTietTieuChiId, " +
                         $"SinhVienId = @sinhVienId, CoVanId = @coVanId, KhoaId = @khoaId, Final = @final, HocKiId = @hocKiId, " +
                         $"CreatedAt = @createdAt, UpdatedAt = @updatedAt WHERE Id = @id";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", chiTietDotCham.Id);
            cmd.Parameters.AddWithValue("@diem", chiTietDotCham.Diem);
            cmd.Parameters.AddWithValue("@dotChamId", chiTietDotCham.DotChamId);
            cmd.Parameters.AddWithValue("@chiTietTieuChiId", chiTietDotCham.ChiTietTieuChiId);
            cmd.Parameters.AddWithValue("@sinhVienId", chiTietDotCham.SinhVienId);
            cmd.Parameters.AddWithValue("@coVanId", chiTietDotCham.CoVanId);
            cmd.Parameters.AddWithValue("@khoaId", chiTietDotCham.KhoaId);
            cmd.Parameters.AddWithValue("@final", chiTietDotCham.Final);
            cmd.Parameters.AddWithValue("@hocKiId", chiTietDotCham.HocKiId);
            cmd.Parameters.AddWithValue("@createdAt", chiTietDotCham.CreatedAt);
            cmd.Parameters.AddWithValue("@updatedAt", chiTietDotCham.UpdatedAt);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Xóa chi tiết đợt chấm
        public static bool DeleteChiTietDotCham(long id)
        {
            string sql = $"DELETE FROM chitietdotcham WHERE Id = @id";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", id);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }
    }
}
