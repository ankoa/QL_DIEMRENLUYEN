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
                    Convert.ToInt64(row[0]),  // Id
                    Convert.ToInt32(row[2]), // Diem
                    Convert.ToInt64(row[1]), // ThongTinDotChamDiemId
                    Convert.ToInt64(row[3]), // TieuchiDanhgiaId
                    row[4] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[4]) : null, // CreatedAt
                    row[5] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[5]) : null, // UpdatedAt
                    Convert.ToInt32(row[6])  // Status
                );

                chiTietDotChams.Add(chiTietDotCham);
            }

            return chiTietDotChams;
        }

        // Thêm chi tiết đợt chấm mới
        public static bool AddChiTietDotCham(ChiTietDotChamDTO chiTietDotCham)
        {
            string sql = "INSERT INTO chitietdotcham (diem, thongtindotchamdiem_id, tieuchidanhgia_id, created_at, updated_at, status) " +
                         "VALUES (@diem, @thongTinDotChamDiemId, @tieuchiDanhgiaId, @createdAt, @updatedAt, @status)";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@diem", chiTietDotCham.Diem);
            cmd.Parameters.AddWithValue("@thongTinDotChamDiemId", chiTietDotCham.ThongTinDotChamDiemId);
            cmd.Parameters.AddWithValue("@tieuchiDanhgiaId", chiTietDotCham.TieuchiDanhgiaId);
            cmd.Parameters.AddWithValue("@createdAt", chiTietDotCham.CreatedAt);
            cmd.Parameters.AddWithValue("@updatedAt", chiTietDotCham.UpdatedAt);
            cmd.Parameters.AddWithValue("@status", chiTietDotCham.Status);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Cập nhật thông tin chi tiết đợt chấm
        public static bool UpdateChiTietDotCham(ChiTietDotChamDTO chiTietDotCham)
        {
            string sql = "UPDATE chitietdotcham SET diem = @diem, thongtindotchamdiem_id = @thongTinDotChamDiemId, " +
                         "tieuchidanhgia_id = @tieuchiDanhgiaId, created_at = @createdAt, updated_at = @updatedAt, status = @status WHERE id = @id";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", chiTietDotCham.Id);
            cmd.Parameters.AddWithValue("@diem", chiTietDotCham.Diem);
            cmd.Parameters.AddWithValue("@thongTinDotChamDiemId", chiTietDotCham.ThongTinDotChamDiemId);
            cmd.Parameters.AddWithValue("@tieuchiDanhgiaId", chiTietDotCham.TieuchiDanhgiaId);
            cmd.Parameters.AddWithValue("@createdAt", chiTietDotCham.CreatedAt);
            cmd.Parameters.AddWithValue("@updatedAt", chiTietDotCham.UpdatedAt);
            cmd.Parameters.AddWithValue("@status", chiTietDotCham.Status);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Xóa chi tiết đợt chấm (Cập nhật status thay vì xóa vĩnh viễn)
        public static bool DeleteChiTietDotCham(long id)
        {
            string sql = "UPDATE chitietdotcham SET status = 0 WHERE id = @id";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", id);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }
        // Kiểm tra xem chi tiết đợt chấm đã tồn tại hay chưa
        //public static bool IsChiTietDotChamExist(long thongTinDotChamDiemId)
        //{
        //    // Câu SQL kiểm tra sự tồn tại của thongTinDotChamDiemId với status = 1
        //    string sql = "SELECT 1 FROM chitietdotcham WHERE thongtindotchamdiem_id = @thongTinDotChamDiemId AND status = 1 LIMIT 1";

        //    var cmd = new MySqlCommand(sql);
        //    cmd.Parameters.AddWithValue("@thongTinDotChamDiemId", thongTinDotChamDiemId);

        //    object result = DBConnection.ExecuteScalar(cmd);

        //    // Nếu có kết quả thì tồn tại
        //    return result != null;
        //}
        public static bool IsChiTietDotChamExist(long thongTinDotChamDiemId)
        {
            string sql = "SELECT 1 FROM chitietdotcham WHERE thongtindotchamdiem_id = @thongTinDotChamDiemId AND status = 1 LIMIT 1";

            using (var connection = new MySqlConnection("<connection_string>"))
            using (var cmd = new MySqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@thongTinDotChamDiemId", thongTinDotChamDiemId);

                try
                {
                    connection.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        return reader.HasRows; // Nếu có hàng trả về, tồn tại
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi kiểm tra tồn tại: {ex.Message}", "Lỗi");
                    return false;
                }
            }
        }






    }
}
