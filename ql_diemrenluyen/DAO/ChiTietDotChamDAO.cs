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
                    Convert.ToInt32(row[2]), // Diem
                    Convert.ToInt64(row[1]), // ThongTinDotChamDiemId
                    Convert.ToInt64(row[3]), // TieuchiDanhgiaId
                    row[4] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[4]) : null, // CreatedAt
                    row[5] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[5]) : null // UpdatedAt
                );

                chiTietDotChams.Add(chiTietDotCham);
            }

            return chiTietDotChams;
        }

        // Thêm chi tiết đợt chấm mới
        public static bool AddChiTietDotCham(ChiTietDotChamDTO chiTietDotCham)
        {
            string sql = "INSERT INTO chitietdotcham (diem, thongtindotchamdiem_id, tieuchidanhgia_id, created_at, updated_at) " +
                         "VALUES (@diem, @thongTinDotChamDiemId, @tieuchiDanhgiaId, @createdAt, @updatedAt)";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@diem", chiTietDotCham.Diem);
            cmd.Parameters.AddWithValue("@thongTinDotChamDiemId", chiTietDotCham.ThongTinDotChamDiemId);
            cmd.Parameters.AddWithValue("@tieuchiDanhgiaId", chiTietDotCham.TieuchiDanhgiaId);
            cmd.Parameters.AddWithValue("@createdAt", chiTietDotCham.CreatedAt);
            cmd.Parameters.AddWithValue("@updatedAt", chiTietDotCham.UpdatedAt);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Cập nhật thông tin chi tiết đợt chấm
        public static bool UpdateChiTietDotCham(ChiTietDotChamDTO chiTietDotCham)
        {
            string sql = "UPDATE chitietdotcham SET diem = @diem, thongtindotchamdiem_id = @thongTinDotChamDiemId, " +
                         "tieuchidanhgia_id = @tieuchiDanhgiaId, created_at = @createdAt, updated_at = @updatedAt WHERE id = @id";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", chiTietDotCham.Id);
            cmd.Parameters.AddWithValue("@diem", chiTietDotCham.Diem);
            cmd.Parameters.AddWithValue("@thongTinDotChamDiemId", chiTietDotCham.ThongTinDotChamDiemId);
            cmd.Parameters.AddWithValue("@tieuchiDanhgiaId", chiTietDotCham.TieuchiDanhgiaId);
            cmd.Parameters.AddWithValue("@createdAt", chiTietDotCham.CreatedAt);
            cmd.Parameters.AddWithValue("@updatedAt", chiTietDotCham.UpdatedAt);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Xóa chi tiết đợt chấm
        public static bool DeleteChiTietDotCham(long id)
        {
            string sql = "DELETE FROM chitietdotcham WHERE id = @id";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", id);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }
    }
}
