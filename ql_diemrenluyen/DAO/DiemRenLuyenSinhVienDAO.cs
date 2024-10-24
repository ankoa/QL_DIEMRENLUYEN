using MySql.Data.MySqlClient;
using ql_diemrenluyen.DTO;

namespace ql_diemrenluyen.DAO
{
    public class DiemRenLuyenSinhVienDAO
    {
        // Lấy tất cả điểm rèn luyện sinh viên
        public static List<DiemRenLuyenSinhVienDTO> GetAllDiemRenLuyen()
        {
            List<DiemRenLuyenSinhVienDTO> diemRenLuyens = new List<DiemRenLuyenSinhVienDTO>();
            string sql = "SELECT * FROM diemrenluyensinhvien"; // Đảm bảo tên bảng đúng

            List<List<object>> result = DBConnection.ExecuteReader(sql);

            foreach (var row in result)
            {
                DiemRenLuyenSinhVienDTO diemRenLuyen = new DiemRenLuyenSinhVienDTO
                {
                    Id = Convert.ToInt32(row[0]), // Id
                    SinhVienId = row[1] != null ? (long?)Convert.ToInt64(row[1]) : null, // sinhvien_id
                    SemesterId = row[2] != null ? (int?)Convert.ToInt32(row[2]) : null, // hocki_id
                    Score = row[3] != null ? (int?)Convert.ToInt32(row[3]) : null, // diemrenluyen
                    Comments = row[4] != null ? Convert.ToString(row[4]) : null // danhgia
                };

                diemRenLuyens.Add(diemRenLuyen);
            }

            return diemRenLuyens;
        }

        // Thêm điểm rèn luyện sinh viên mới
        public static bool AddDiemRenLuyen(DiemRenLuyenSinhVienDTO diemRenLuyen)
        {
            string sql = "INSERT INTO diemrenluyensinhvien (sinhvien_id, hocki_id, diemrenluyen, danhgia) " +
                         "VALUES (@sinhVienId, @semesterId, @score, @comments)";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@sinhVienId", diemRenLuyen.SinhVienId);
            cmd.Parameters.AddWithValue("@semesterId", diemRenLuyen.SemesterId);
            cmd.Parameters.AddWithValue("@score", diemRenLuyen.Score);
            cmd.Parameters.AddWithValue("@comments", diemRenLuyen.Comments);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Cập nhật thông tin điểm rèn luyện sinh viên
        public static bool UpdateDiemRenLuyen(DiemRenLuyenSinhVienDTO diemRenLuyen)
        {
            string sql = "UPDATE diemrenluyensinhvien SET sinhvien_id = @sinhVienId, hocki_id = @semesterId, " +
                         "diemrenluyen = @score, danhgia = @comments WHERE Id = @id";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", diemRenLuyen.Id);
            cmd.Parameters.AddWithValue("@sinhVienId", diemRenLuyen.SinhVienId);
            cmd.Parameters.AddWithValue("@semesterId", diemRenLuyen.SemesterId);
            cmd.Parameters.AddWithValue("@score", diemRenLuyen.Score);
            cmd.Parameters.AddWithValue("@comments", diemRenLuyen.Comments);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Xóa điểm rèn luyện sinh viên
        public static bool DeleteDiemRenLuyen(int id)
        {
            string sql = "DELETE FROM diemrenluyensinhvien WHERE Id = @id";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", id);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Tìm điểm rèn luyện theo SinhVienId
        public static List<DiemRenLuyenSinhVienDTO> GetDiemRenLuyenBySinhVienId(long sinhVienId) // Chỉnh sửa kiểu tham số
        {
            List<DiemRenLuyenSinhVienDTO> diemRenLuyens = new List<DiemRenLuyenSinhVienDTO>();

            string sql = "SELECT * FROM diemrenluyensinhvien WHERE sinhvien_id = @sinhVienId";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@sinhVienId", sinhVienId);

            List<List<object>> result = DBConnection.ExecuteReader(cmd);

            foreach (var row in result)
            {
                DiemRenLuyenSinhVienDTO diemRenLuyen = new DiemRenLuyenSinhVienDTO
                {
                    Id = Convert.ToInt32(row[0]), // Id
                    SinhVienId = row[1] != null ? (long?)Convert.ToInt64(row[1]) : null, // sinhvien_id
                    SemesterId = row[2] != null ? (int?)Convert.ToInt32(row[2]) : null, // hocki_id
                    Score = row[3] != null ? (int?)Convert.ToInt32(row[3]) : null, // diemrenluyen
                    Comments = row[4] != null ? Convert.ToString(row[4]) : null // danhgia
                };

                diemRenLuyens.Add(diemRenLuyen);
            }

            return diemRenLuyens;
        }
    }
}
