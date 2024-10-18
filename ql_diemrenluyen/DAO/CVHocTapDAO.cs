using MySql.Data.MySqlClient;
using ql_diemrenluyen.DTO;

namespace ql_diemrenluyen.DAO
{
    public class CVHocTapDAO
    {
        // Lấy tất cả CV học tập
        public static List<CVHocTapDTO> GetAllCVHocTap()
        {
            List<CVHocTapDTO> cvHocTaps = new List<CVHocTapDTO>();
            string sql = "SELECT * FROM covan_hoctap"; // Đảm bảo tên bảng đúng

            try
            {
                List<List<object>> result = DBConnection.ExecuteReader(sql);

                foreach (var row in result)
                {
                    CVHocTapDTO cvHocTap = new CVHocTapDTO
                    {
                        Id = Convert.ToInt64(row[0]), // Id
                        GiangVienId = Convert.ToInt64(row[1]), // GiangVienId
                        LopId = Convert.ToInt64(row[2]), // LopId
                        CreatedAt = row[3] != DBNull.Value ? Convert.ToDateTime(row[3]) : (DateTime?)null, // CreatedAt
                        UpdatedAt = row[4] != DBNull.Value ? Convert.ToDateTime(row[4]) : (DateTime?)null // UpdatedAt
                    };

                    cvHocTaps.Add(cvHocTap);
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi (ghi log, ném lại lỗi, v.v.)
            }

            return cvHocTaps;
        }

        // Thêm CV học tập mới
        public static bool AddCVHocTap(CVHocTapDTO cvHocTap)
        {
            string sql = "INSERT INTO covan_hoctap (giangvien_id, lop_id, created_at, updated_at) " + // Đảm bảo tên cột đúng
                         "VALUES (@giangVienId, @lopId, @createdAt, @updatedAt)";

            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@giangVienId", cvHocTap.GiangVienId);
                cmd.Parameters.AddWithValue("@lopId", cvHocTap.LopId);
                cmd.Parameters.AddWithValue("@createdAt", cvHocTap.CreatedAt);
                cmd.Parameters.AddWithValue("@updatedAt", cvHocTap.UpdatedAt);

                return DBConnection.ExecuteNonQuery(cmd) > 0;
            }
        }

        // Cập nhật thông tin CV học tập
        public static bool UpdateCVHocTap(CVHocTapDTO cvHocTap)
        {
            string sql = "UPDATE covan_hoctap SET giangvien_id = @giangVienId, lop_id = @lopId, " +
                         "created_at = @createdAt, updated_at = @updatedAt WHERE id = @id";

            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@id", cvHocTap.Id);
                cmd.Parameters.AddWithValue("@giangVienId", cvHocTap.GiangVienId);
                cmd.Parameters.AddWithValue("@lopId", cvHocTap.LopId);
                cmd.Parameters.AddWithValue("@createdAt", cvHocTap.CreatedAt);
                cmd.Parameters.AddWithValue("@updatedAt", cvHocTap.UpdatedAt);

                return DBConnection.ExecuteNonQuery(cmd) > 0;
            }
        }

        // Xóa CV học tập
        public static bool DeleteCVHocTap(long id)
        {
            string sql = "DELETE FROM covan_hoctap WHERE id = @id";
            using (var cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@id", id);

                return DBConnection.ExecuteNonQuery(cmd) > 0;
            }
        }
    }
}
