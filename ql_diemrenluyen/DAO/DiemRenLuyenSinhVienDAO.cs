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
            string sql = "INSERT INTO diemrenluyensinhvien (sinhvien_id, hocki_id, diemrenluyen, danhgia,status) " +
                         "VALUES (@sinhVienId, @semesterId, @score, @comments,1)";

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

        // Lấy điểm rèn luyện trung bình của tất cả sinh viên
        public static double GetAverageDiemRenLuyen()
        {
            double averageScore = 0;
            string sql = "SELECT AVG(diemrenluyen) AS AverageScore FROM diemrenluyensinhvien WHERE diemrenluyen IS NOT NULL and status =1";

            List<List<object>> result = DBConnection.ExecuteReader(sql);

            if (result.Count > 0 && result[0][0] != DBNull.Value)
            {
                averageScore = Convert.ToDouble(result[0][0]);
            }

            return averageScore;
        }

        public static double GetAverageDiemRenLuyenByFilter(long? khoaId = null, long? lopId = null, string? hockiname = null, string? namhoc = null)
        {
            double averageScore = 0;

            // Câu truy vấn SQL cơ bản
            string sql = @"
    SELECT AVG(drl.diemrenluyen) AS AverageScore
    FROM diemrenluyensinhvien drl
    JOIN sinhvien sv ON drl.sinhvien_id = sv.id
    JOIN lop l ON sv.lop_id = l.id
    JOIN khoa k ON l.khoa_id = k.id
    LEFT JOIN hocky hk ON drl.hocki_id = hk.Id
    WHERE drl.diemrenluyen IS NOT NULL 
      AND drl.status = 1
      AND sv.status = 1
      AND l.status = 1
      AND k.status = 1";

            // Thêm điều kiện lọc dựa trên `khoaId`, `lopId`, `hockiname`, và `namhoc`
            if (khoaId.HasValue)
            {
                sql += " AND k.id = @khoaId";
            }
            if (lopId.HasValue)
            {
                sql += " AND l.id = @lopId";
            }
            if (!string.IsNullOrEmpty(hockiname))
            {
                sql += " AND hk.Name = @hockiname"; // Lọc theo tên học kỳ
            }
            if (!string.IsNullOrEmpty(namhoc))
            {
                sql += " AND hk.namhoc = @namhoc";
            }

            // Tạo lệnh SQL
            var cmd = new MySqlCommand(sql);
            if (khoaId.HasValue)
            {
                cmd.Parameters.AddWithValue("@khoaId", khoaId.Value);
            }
            if (lopId.HasValue)
            {
                cmd.Parameters.AddWithValue("@lopId", lopId.Value);
            }
            if (!string.IsNullOrEmpty(hockiname))
            {
                cmd.Parameters.AddWithValue("@hockiname", hockiname);
            }
            if (!string.IsNullOrEmpty(namhoc))
            {
                cmd.Parameters.AddWithValue("@namhoc", namhoc);
            }

            // Thực thi câu lệnh
            List<List<object>> result = DBConnection.ExecuteReader(cmd);

            if (result.Count > 0 && result[0][0] != DBNull.Value)
            {
                averageScore = Convert.ToDouble(result[0][0]);
            }

            return averageScore;
        }



        public static int GetSoSinhVienCanhCaoByFilter(int drl, string sosanh, long? khoaId = null, long? lopId = null, string? hockyName = null, string? namhoc = null)
        {
            int warningCount = 0;

            // Kiểm tra toán tử so sánh có hợp lệ không
            string[] validOperators = { "<", "<=", ">", ">=", "=" };
            if (!validOperators.Contains(sosanh))
            {
                throw new ArgumentException("Toán tử so sánh không hợp lệ.");
            }

            // Câu truy vấn SQL cơ bản
            string sql = $@"
                SELECT COUNT(*) AS WarningCount
                FROM diemrenluyensinhvien drl
                JOIN sinhvien sv ON drl.sinhvien_id = sv.id
                JOIN lop l ON sv.lop_id = l.id
                JOIN khoa k ON l.khoa_id = k.id
                LEFT JOIN hocky hk ON drl.hocki_id = hk.id
                WHERE drl.diemrenluyen {sosanh} @drl
                  AND drl.diemrenluyen IS NOT NULL
                  AND drl.status = 1
                  AND sv.status = 1
                  AND l.status = 1
                  AND k.status = 1";

            // Thêm điều kiện lọc dựa trên `khoaId`, `lopId`, `hockyName`, và `namhoc`
            if (khoaId.HasValue)
            {
                sql += " AND k.id = @khoaId";
            }
            if (lopId.HasValue)
            {
                sql += " AND l.id = @lopId";
            }
            if (!string.IsNullOrEmpty(hockyName))
            {
                sql += " AND hk.Name = @hockyName";
            }
            if (!string.IsNullOrEmpty(namhoc))
            {
                sql += " AND hk.namhoc = @namhoc";
            }

            // Tạo lệnh SQL
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@drl", drl);

            if (khoaId.HasValue)
            {
                cmd.Parameters.AddWithValue("@khoaId", khoaId.Value);
            }
            if (lopId.HasValue)
            {
                cmd.Parameters.AddWithValue("@lopId", lopId.Value);
            }
            if (!string.IsNullOrEmpty(hockyName))
            {
                cmd.Parameters.AddWithValue("@hockyName", hockyName);
            }
            if (!string.IsNullOrEmpty(namhoc))
            {
                cmd.Parameters.AddWithValue("@namhoc", namhoc);
            }

            // Thực thi câu lệnh
            List<List<object>> result = DBConnection.ExecuteReader(cmd);

            if (result.Count > 0 && result[0][0] != DBNull.Value)
            {
                warningCount = Convert.ToInt32(result[0][0]);
            }

            return warningCount;
        }





        // Đếm số lượng sinh viên có điểm rèn luyện dưới 50
        public static int GetSoSinhVienCanhCao(int threshold = 50)
        {
            int count = 0;
            string sql = "SELECT COUNT(*) FROM diemrenluyensinhvien WHERE diemrenluyen < @threshold AND diemrenluyen IS NOT NULL and status = 1";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@threshold", threshold);

            List<List<object>> result = DBConnection.ExecuteReader(cmd);

            if (result.Count > 0 && result[0][0] != DBNull.Value)
            {
                count = Convert.ToInt32(result[0][0]);
            }

            return count;
        }

        public static Dictionary<string, double> GetDiemTrungBinhCuaCacKhoa(string? hockiId = null, string? namhocId = null)
        {
            var result = new Dictionary<string, double>();

            // Câu truy vấn SQL
            string sql = @"
        SELECT k.tenkhoa AS TenKhoa, AVG(drl.diemrenluyen) AS DiemTrungBinh
        FROM diemrenluyensinhvien drl
        JOIN sinhvien sv ON drl.sinhvien_id = sv.id
        JOIN lop l ON sv.lop_id = l.id
        JOIN khoa k ON l.khoa_id = k.id
        LEFT JOIN hocky hk ON drl.hocki_id = hk.Id
        WHERE drl.diemrenluyen IS NOT NULL
          AND drl.status = 1
          AND sv.status = 1
          AND l.status = 1
          AND k.status = 1";

            // Thêm điều kiện nếu có
            if (!string.IsNullOrEmpty(hockiId))
            {
                sql += " AND hk.Name = @hockiId";
            }
            if (!string.IsNullOrEmpty(namhocId))
            {
                sql += " AND hk.namhoc = @namhocId";
            }

            // Nhóm theo khoa
            sql += " GROUP BY k.id";

            //MessageBox.Show(hockiId);
            // Tạo lệnh SQL
            var cmd = new MySqlCommand(sql);

            // Thêm tham số nếu có
            if (!string.IsNullOrEmpty(hockiId))
            {
                cmd.Parameters.AddWithValue("@hockiId", hockiId);
            }
            if (!string.IsNullOrEmpty(namhocId))
            {
                cmd.Parameters.AddWithValue("@namhocId", namhocId);
            }

            // Thực thi câu lệnh và xử lý kết quả
            List<List<object>> queryResult = DBConnection.ExecuteReader(cmd);

            if (queryResult == null || queryResult.Count == 0)
            {
                return result;
            }

            foreach (var row in queryResult)
            {
                try
                {
                    string tenKhoa = row[0] != DBNull.Value ? Convert.ToString(row[0]) : "Không xác định";
                    double diemTrungBinh = row[1] != DBNull.Value ? Convert.ToDouble(row[1]) : 0.0;

                    result[tenKhoa] = diemTrungBinh;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xử lý dữ liệu: {ex.Message}");
                }
            }

            return result;
        }


        //       public static double GetAverageDiemRenLuyenByFilter(long? khoaId = null, long? lopId = null)
        //       {
        //           double averageScore = 0;

        //           // Câu truy vấn SQL cơ bản
        //           string sql = @"
        //SELECT AVG(drl.diemrenluyen) AS AverageScore
        //FROM diemrenluyensinhvien drl
        //JOIN sinhvien sv ON drl.sinhvien_id = sv.id
        //JOIN lop l ON sv.lop_id = l.id
        //JOIN khoa k ON l.khoa_id = k.id
        //WHERE drl.diemrenluyen IS NOT NULL 
        //  AND drl.status = 1
        //  AND sv.status = 1
        //  AND l.status = 1
        //  AND k.status = 1";

        //           // Thêm điều kiện lọc dựa trên khoaId và lopId
        //           if (khoaId.HasValue)
        //           {
        //               sql += " AND k.id = @khoaId";
        //           }
        //           if (lopId.HasValue)
        //           {
        //               sql += " AND l.id = @lopId";
        //           }

        //           // Tạo lệnh SQL
        //           var cmd = new MySqlCommand(sql);
        //           if (khoaId.HasValue)
        //           {
        //               cmd.Parameters.AddWithValue("@khoaId", khoaId.Value);
        //           }
        //           if (lopId.HasValue)
        //           {
        //               cmd.Parameters.AddWithValue("@lopId", lopId.Value);
        //           }

        //           // Thực thi câu lệnh
        //           List<List<object>> result = DBConnection.ExecuteReader(cmd);

        //           if (result.Count > 0 && result[0][0] != DBNull.Value)
        //           {
        //               averageScore = Convert.ToDouble(result[0][0]);
        //           }

        //           return averageScore;
        //       }

        public static Dictionary<string, int> GetXepLoai(long? khoaId = null, long? lopId = null, string? hockiId = null, string? namhocId = null)
        {
            var result = new Dictionary<string, int>();

            // Câu truy vấn SQL
            string sql = @"
SELECT drl.danhgia AS DanhGia, COUNT(*) AS SoLuong
FROM diemrenluyensinhvien drl
JOIN sinhvien sv ON drl.sinhvien_id = sv.id
JOIN lop l ON sv.lop_id = l.id
JOIN khoa k ON l.khoa_id = k.id
LEFT JOIN hocky hk ON drl.hocki_id = hk.Id
WHERE drl.danhgia IS NOT NULL
  AND drl.status = 1
  AND sv.status = 1
  AND l.status = 1
  AND k.status = 1";

            // Thêm điều kiện nếu có
            if (khoaId.HasValue)
            {
                sql += " AND k.id = @khoaId";
            }
            if (lopId.HasValue)
            {
                sql += " AND l.id = @lopId";
            }
            if (!string.IsNullOrEmpty(hockiId))
            {
                sql += " AND hk.Name = @hockiId";
            }
            if (!string.IsNullOrEmpty(namhocId))
            {
                sql += " AND hk.namhoc = @namhocId";
            }

            // Nhóm theo đánh giá
            sql += " GROUP BY drl.danhgia";

            // Tạo lệnh SQL
            var cmd = new MySqlCommand(sql);

            // Thêm tham số nếu có
            if (khoaId.HasValue)
            {
                cmd.Parameters.AddWithValue("@khoaId", khoaId.Value);
            }
            if (lopId.HasValue)
            {
                cmd.Parameters.AddWithValue("@lopId", lopId.Value);
            }
            if (!string.IsNullOrEmpty(hockiId))
            {
                cmd.Parameters.AddWithValue("@hockiId", hockiId);
            }
            if (!string.IsNullOrEmpty(namhocId))
            {
                cmd.Parameters.AddWithValue("@namhocId", namhocId);
            }

            // Thực thi câu lệnh và xử lý kết quả
            List<List<object>> queryResult = DBConnection.ExecuteReader(cmd);

            foreach (var row in queryResult)
            {
                try
                {
                    string danhGia = Convert.ToString(row[0]);  // Lấy đánh giá
                    int soLuong = Convert.ToInt32(row[1]);     // Lấy số lượng

                    // Thêm vào kết quả
                    result[danhGia] = soLuong;
                }
                catch (Exception ex)
                {
                    // Log lỗi nếu cần
                    Console.WriteLine($"Lỗi khi xử lý dữ liệu: {ex.Message}");
                }
            }

            return result;
        }


    }
}
