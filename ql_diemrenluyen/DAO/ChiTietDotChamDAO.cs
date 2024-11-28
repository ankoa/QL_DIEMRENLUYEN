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
        public static List<ChiTietDotChamDTO> GetListChiTietDotChamByThongTinDotChamId(long thongTinDotChamDiemId)
        {
            List<ChiTietDotChamDTO> chiTietDotChams = new List<ChiTietDotChamDTO>();

            string sql = @"
        SELECT id, diem, thongtindotchamdiem_id, tieuchidanhgia_id, created_at, updated_at, status 
        FROM chitietdotcham 
        WHERE thongtindotchamdiem_id = @thongTinDotChamDiemId AND status = 1";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@thongTinDotChamDiemId", thongTinDotChamDiemId);

            try
            {
                DBConnection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ChiTietDotChamDTO chiTietDotCham = new ChiTietDotChamDTO
                        {
                            Id = Convert.ToInt64(reader["id"]),
                            Diem = Convert.ToInt32(reader["diem"]),
                            ThongTinDotChamDiemId = Convert.ToInt64(reader["thongtindotchamdiem_id"]),
                            TieuchiDanhgiaId = Convert.ToInt64(reader["tieuchidanhgia_id"]),
                            CreatedAt = reader["created_at"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(reader["created_at"]) : null,
                            UpdatedAt = reader["updated_at"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(reader["updated_at"]) : null,
                            Status = Convert.ToInt32(reader["status"])
                        };

                        chiTietDotChams.Add(chiTietDotCham);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách chi tiết đợt chấm: " + ex.Message);
            }
            finally
            {
                DBConnection.Close();
            }

            return chiTietDotChams;
        }

        public static int? GetDiem(long sinhVienID, long tieuChiDanhGiaID, int dotchamdiemID, long? coVanID = null, int? khoaID = null, int? final = null)
        {
            string sql = "SELECT ct.diem " +
                         "FROM thongtindotchamdiem tt " +
                         "JOIN chitietdotcham ct ON tt.id = ct.thongtindotchamdiem_id " +
                         "JOIN dotchamdiem d ON tt.dotchamdiem_id = d.Id " +  // Kết nối với bảng dotchamdiem
                         "WHERE tt.sinhvien_id = @sinhVienID ";

            // Thêm các điều kiện vào câu SQL nếu các tham số khác không phải NULL
            if (coVanID.HasValue)
            {
                sql += "AND tt.covan_id = @coVanID ";
            }

            if (khoaID.HasValue)
            {
                sql += "AND tt.khoa_id = @khoaID ";
            }

            if (final.HasValue)
            {
                sql += "AND tt.final = @final ";
            }

            // Thêm điều kiện tìm kiếm theo dotchamdiemID
            sql += "AND tt.dotchamdiem_id = @dotchamdiemID " +
                   "AND ct.tieuchidanhgia_id = @tieuChiDanhGiaID " +
                   "LIMIT 1;";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@sinhVienID", sinhVienID);
            if (coVanID.HasValue) cmd.Parameters.AddWithValue("@coVanID", coVanID.Value);
            if (khoaID.HasValue) cmd.Parameters.AddWithValue("@khoaID", khoaID.Value);
            if (final.HasValue) cmd.Parameters.AddWithValue("@final", final.Value);
            cmd.Parameters.AddWithValue("@tieuChiDanhGiaID", tieuChiDanhGiaID);
            cmd.Parameters.AddWithValue("@dotchamdiemID", dotchamdiemID);  // Thêm tham số dotchamdiemID

            var result = DBConnection.ExecuteScalar(cmd);

            if (result != null && result != DBNull.Value)
            {
                return Convert.ToInt32(result);
            }

            return null; // Trả về null nếu không tìm thấy điểm
        }




    }
}
