using MySql.Data.MySqlClient;
using ql_diemrenluyen.DTO;
using System.Diagnostics;

namespace ql_diemrenluyen.DAO
{
    public class SinhVienDAO
    {
        // Lấy tất cả sinh viên
        public static List<SinhVienDTO> GetAllStudents()
        {
            List<SinhVienDTO> students = new List<SinhVienDTO>();
            string sql = "SELECT * FROM sinhvien  ";

            List<List<object>> result = DBConnection.ExecuteReader(sql);

            foreach (var row in result)
            {
                SinhVienDTO student = MapToSinhVienDTO(row);
                students.Add(student);
            }

            return students;
        }

        public static List<SinhVienDTO> GetAllStudentsToChamDiem()
        {
            List<SinhVienDTO> students = new List<SinhVienDTO>();

            // Câu lệnh SQL kết nối bảng sinhvien và thongtindotchamdiem
            string sql = @"
        SELECT sv.* 
        FROM sinhvien sv
        INNER JOIN thongtindotchamdiem ttdcd 
        ON sv.id = ttdcd.sinhvien_id";

            // Thực thi câu lệnh SQL và lấy kết quả
            List<List<object>> result = DBConnection.ExecuteReader(sql);

            // Duyệt qua từng hàng kết quả và ánh xạ vào danh sách SinhVienDTO
            foreach (var row in result)
            {
                SinhVienDTO student = MapToSinhVienDTO(row);
                students.Add(student);
            }

            return students;
        }


        public static List<SinhVienToExport> GetAllStudentsToExport()
        {
            List<SinhVienToExport> students = new List<SinhVienToExport>();

            // Truy vấn SQL kết nối sinhvien, lop, và khoa
            string sql = @"
        SELECT sv.id, sv.name, sv.ngaysinh, sv.email, sv.gioitinh, sv.created_at, sv.updated_at, sv.status, 
               l.TenLop, k.TenKhoa
        FROM sinhvien sv
        INNER JOIN lop l ON sv.lop_id = l.Id
        INNER JOIN khoa k ON l.khoa_id = k.Id";

            List<List<object>> result = DBConnection.ExecuteReader(sql);

            foreach (var row in result)
            {
                SinhVienToExport student = MapToSinhVienToExport(row);

                students.Add(student);
            }

            return students;
        }



        // Lấy tất cả sinh viên
        public static List<SinhVienDTO> GetAllStudentsActive(long? khoaId = null, long? lopId = null)
        {
            List<SinhVienDTO> students = new List<SinhVienDTO>();

            // Câu lệnh SQL cơ bản với điều kiện tìm sinh viên có status = 1 (đang hoạt động)
            string sql = @"
                    SELECT *
                    FROM sinhvien sv
                LEFT JOIN lop l ON sv.lop_id = l.id
                    LEFT JOIN khoa k ON l.khoa_id = k.id
                        WHERE sv.status = 1
                And l.status=1
                And k.status=1";

            // Thêm điều kiện lọc theo khoaId nếu có
            if (khoaId.HasValue)
            {
                sql += " AND l.khoa_id = @khoaId";
            }

            // Thêm điều kiện lọc theo lopId nếu có
            if (lopId.HasValue)
            {
                sql += " AND sv.lop_id = @lopId";
            }

            // Tạo câu lệnh MySQL
            var cmd = new MySqlCommand(sql);

            // Thêm các tham số vào câu lệnh SQL nếu có
            if (khoaId.HasValue)
            {
                cmd.Parameters.AddWithValue("@khoaId", khoaId.Value);
            }

            if (lopId.HasValue)
            {
                cmd.Parameters.AddWithValue("@lopId", lopId.Value);
            }

            // Thực thi câu lệnh SQL và lấy kết quả
            List<List<object>> result = DBConnection.ExecuteReader(cmd);

            // Ánh xạ dữ liệu và thêm vào danh sách sinh viên
            foreach (var row in result)
            {
                SinhVienDTO student = MapToSinhVienDTO(row);
                students.Add(student);
            }

            return students;
        }


        // Lấy sinh viên theo ID
        public static SinhVienDTO GetStudentById(long id)
        {
            string sql = "SELECT * FROM sinhvien WHERE id = @id";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", id);

            List<List<object>> result = DBConnection.ExecuteReader(cmd);

            if (result.Count > 0)
            {
                return MapToSinhVienDTO(result[0]);
            }

            return null; // Trả về null nếu không tìm thấy sinh viên
        }

        //        public static List<SinhVienDetailsDTO> GetDanhSachSvAndDrl(long? khoaId = null, long? lopId = null, string? hockiId = null, string? namhocId = null)
        //        {
        //            string sql = @"
        //        SELECT sv.id, sv.name, 
        //       k.tenkhoa AS khoa_ten, 
        //       l.tenlop AS lop_ten, 
        //       drl.diemrenluyen, drl.danhgia
        //FROM sinhvien sv
        //LEFT JOIN lop l ON sv.lop_id = l.id
        //LEFT JOIN khoa k ON l.khoa_id = k.id
        //LEFT JOIN diemrenluyensinhvien drl ON sv.id = drl.sinhvien_id
        //LEFT JOIN hocky hk ON drl.hocki_id = hk.id
        //WHERE 1=1
        //    AND drl.status = 1
        //  AND sv.status = 1
        //  AND l.status = 1
        //  AND k.status = 1"; // Điều kiện luôn đúng, để dễ dàng thêm điều kiện WHERE sau này

        //            // Nếu có tham số khoaId, lopId, hockiId, namhocId thì thêm vào câu lệnh WHERE
        //            if (khoaId.HasValue)
        //                sql += " AND l.khoa_id = @khoaId";

        //            if (lopId.HasValue)
        //                sql += " AND sv.lop_id = @lopId";

        //            if (!string.IsNullOrEmpty(hockiId))
        //                sql += " AND drl.hocki_id = @hockiId";

        //            if (!string.IsNullOrEmpty(namhocId))
        //                sql += " AND hk.namhoc = @namhocId";

        //            // Tạo câu lệnh MySQL và thêm tham số vào câu lệnh SQL
        //            var cmd = new MySqlCommand(sql);

        //            if (khoaId.HasValue)
        //                cmd.Parameters.AddWithValue("@khoaId", khoaId.Value);

        //            if (lopId.HasValue)
        //                cmd.Parameters.AddWithValue("@lopId", lopId.Value);

        //            if (!string.IsNullOrEmpty(hockiId))
        //                cmd.Parameters.AddWithValue("@hockiId", hockiId);

        //            if (!string.IsNullOrEmpty(namhocId))
        //                cmd.Parameters.AddWithValue("@namhocId", namhocId);

        //            // Thực thi câu lệnh SQL và lấy kết quả
        //            List<List<object>> result = DBConnection.ExecuteReader(cmd);

        //            // Nếu có kết quả trả về, ánh xạ dữ liệu vào danh sách DTO
        //            List<SinhVienDetailsDTO> sinhVienDetails = new List<SinhVienDetailsDTO>();

        //            foreach (var row in result)
        //            {
        //                sinhVienDetails.Add(MapToSinhVienDetailsDTO(row));
        //            }

        //            return sinhVienDetails;
        //        }

        public static List<SinhVienDetailsDTO> GetDanhSachSvAndDrl(
       long? khoaId = null,
       long? lopId = null,
       string? hockiId = null,
       string? namhocId = null,
       string? sortOrder = null, // "asc" hoặc "desc"
       int? limit = null,        // Số lượng giới hạn cụ thể
       double? limitPercent = null, // Phần trăm giới hạn
       string? xeploai = null    // Lọc theo xếp loại
   )
        {
            string sql = @"
        SELECT sv.id, sv.name, 
               k.tenkhoa AS khoa_ten, 
               l.tenlop AS lop_ten, 
               drl.diemrenluyen, drl.danhgia
        FROM sinhvien sv
        LEFT JOIN lop l ON sv.lop_id = l.id
        LEFT JOIN khoa k ON l.khoa_id = k.id
        LEFT JOIN diemrenluyensinhvien drl ON sv.id = drl.sinhvien_id
        LEFT JOIN hocky hk ON drl.hocki_id = hk.id
        WHERE 1=1
          AND drl.status = 1
          AND sv.status = 1
          AND l.status = 1
          AND k.status = 1";

            // Thêm điều kiện WHERE nếu có tham số
            if (khoaId.HasValue)
                sql += " AND l.khoa_id = @khoaId";

            if (lopId.HasValue)
                sql += " AND sv.lop_id = @lopId";

            if (!string.IsNullOrEmpty(hockiId))
                sql += " AND hk.Name = @hockiId";

            if (!string.IsNullOrEmpty(namhocId))
                sql += " AND hk.namhoc = @namhocId";

            if (!string.IsNullOrEmpty(xeploai))
                sql += " AND drl.danhgia = @xeploai";

            // Thêm sắp xếp nếu có yêu cầu
            if (!string.IsNullOrEmpty(sortOrder))
            {
                sql += sortOrder.ToLower() == "desc"
                    ? " ORDER BY drl.diemrenluyen DESC"
                    : " ORDER BY drl.diemrenluyen ASC";
            }

            // Tạo lệnh MySQL
            var cmd = new MySqlCommand(sql);

            if (khoaId.HasValue)
                cmd.Parameters.AddWithValue("@khoaId", khoaId.Value);

            if (lopId.HasValue)
                cmd.Parameters.AddWithValue("@lopId", lopId.Value);

            if (!string.IsNullOrEmpty(hockiId))
                cmd.Parameters.AddWithValue("@hockiId", hockiId);

            if (!string.IsNullOrEmpty(namhocId))
                cmd.Parameters.AddWithValue("@namhocId", namhocId);

            if (!string.IsNullOrEmpty(xeploai))
                cmd.Parameters.AddWithValue("@xeploai", xeploai);

            // Thực thi câu lệnh SQL và lấy kết quả
            List<List<object>> result = DBConnection.ExecuteReader(cmd);

            // Tính toán số lượng kết quả cần lấy nếu có yêu cầu giới hạn
            int totalRecords = result.Count;
            int recordsToTake = totalRecords;

            if (limitPercent.HasValue && limitPercent.Value > 0)
            {
                recordsToTake = (int)(totalRecords * (limitPercent.Value / 100));
            }
            else if (limit.HasValue && limit.Value > 0)
            {
                recordsToTake = Math.Min(limit.Value, totalRecords);
            }

            // Cắt danh sách kết quả theo giới hạn
            result = result.Take(recordsToTake).ToList();

            // Ánh xạ kết quả vào danh sách DTO
            List<SinhVienDetailsDTO> sinhVienDetails = new List<SinhVienDetailsDTO>();

            foreach (var row in result)
            {
                sinhVienDetails.Add(MapToSinhVienDetailsDTO(row));
            }

            return sinhVienDetails;
        }


        // Inside SinhVienDAO class

        // Get student by email
        public static SinhVienDTO GetStudentByEmail(string email)
        {
            string sql = "SELECT * FROM sinhvien WHERE email = @Email";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@Email", email);

            List<List<object>> result = DBConnection.ExecuteReader(cmd);

            if (result.Count > 0)
            {
                return MapToSinhVienDTO(result[0]);
            }

            return null; // Return null if the student is not found
        }

        // Tìm kiếm sinh viên cơ bản 
        public static List<SinhVienDTO> basicSearch(string str)
        {
            List<SinhVienDTO> students = new List<SinhVienDTO>();
            string sql = "SELECT DISTINCT sinhvien.*, lop.tenlop, khoa.tenkhoa, khoa.id " +
              "FROM sinhvien " +
              "JOIN lop ON sinhvien.lop_id = lop.id " +
              "JOIN khoa ON lop.khoa_id = khoa.id " +
              "WHERE (sinhvien.status = 1) " +
              "AND (CAST(sinhvien.id AS CHAR) LIKE @str) " +
              "OR (sinhvien.name LIKE @str) " +
              "OR (lop.tenlop LIKE @str) " +
              "OR (khoa.tenkhoa LIKE @str)";
            var cmd = new MySqlCommand();
            cmd.Parameters.AddWithValue("@str", str + "%");
            cmd.CommandText = sql;
            string finalQuery = cmd.CommandText;

            // Lặp qua các tham số và thay thế tham số trong câu lệnh SQL
            foreach (MySqlParameter param in cmd.Parameters)
            {
                finalQuery = finalQuery.Replace(param.ParameterName, "'" + param.Value.ToString() + "'");
            }

            // In câu lệnh SQL và các giá trị tham số đã thay thế vào màn hình Debug
            Debug.WriteLine("Final SQL Query: " + finalQuery);
            List<List<object>> result = DBConnection.ExecuteReader(cmd);

            foreach (var row in result)
            {
                SinhVienDTO student = MapToSinhVienDTO(row);
                students.Add(student);
            }

            return students;
        }

        // Tìm kiếm sinh viên nâng cao 
        public static List<SinhVienDTO> advancedSearch(string maSV, string hoTen, long lopID, long khoaID)
        {
            List<SinhVienDTO> students = new List<SinhVienDTO>();
            string sql = "select sinhvien.*,lop.tenlop,khoa.tenkhoa,khoa.id from sinhvien,lop,khoa where sinhvien.lop_id=lop.id and lop.khoa_id=khoa.id and sinhvien.status=1";
            var cmd = new MySqlCommand();
            if (!string.IsNullOrWhiteSpace(maSV))
            {
                sql += " and CAST(sinhvien.id AS CHAR) LIKE @id";
                cmd.Parameters.AddWithValue("@id", maSV + "%");
            }

            if (!string.IsNullOrWhiteSpace(hoTen))
            {
                sql += " and sinhvien.name LIKE @hoTen";
                cmd.Parameters.AddWithValue("@hoTen", hoTen + "%");
            }

            if (lopID != -1)
            {
                sql += " and sinhvien.lop_id = @lopID";
                cmd.Parameters.AddWithValue("@lopID", lopID);
            }

            if (khoaID != -1)
            {
                sql += " and khoa.id = @khoaID";
                cmd.Parameters.AddWithValue("@khoaID", khoaID);
            }

            cmd.CommandText = sql;
            string finalQuery = cmd.CommandText;

            // Lặp qua các tham số và thay thế tham số trong câu lệnh SQL
            foreach (MySqlParameter param in cmd.Parameters)
            {
                finalQuery = finalQuery.Replace(param.ParameterName, "'" + param.Value.ToString() + "'");
            }

            // In câu lệnh SQL và các giá trị tham số đã thay thế vào màn hình Debug
            Debug.WriteLine("Final SQL Query: " + finalQuery);
            List<List<object>> result = DBConnection.ExecuteReader(cmd);

            foreach (var row in result)
            {
                SinhVienDTO student = MapToSinhVienDTO(row);
                students.Add(student);
            }

            return students;

        }

        // Thêm sinh viên mới
        public static bool AddStudent(SinhVienDTO student)
        {
            try
            {
                string sql = "INSERT INTO sinhvien (name, id, ngaySinh, email, gioiTinh, lop_id, chucVu, created_at, updated_at,status) " +
                             "VALUES (@name, @id, @ngaySinh, @email, @gioiTinh, @lopId, @chucVu, @createdAt, @updatedAt,@status)";

                var cmd = new MySqlCommand(sql);
                cmd.Parameters.AddWithValue("@name", student.Name);
                cmd.Parameters.AddWithValue("@id", student.Id);
                cmd.Parameters.AddWithValue("@ngaySinh", student.NgaySinh.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@email", student.Email);
                cmd.Parameters.AddWithValue("@gioiTinh", student.GioiTinh);
                cmd.Parameters.AddWithValue("@lopId", student.LopId);
                cmd.Parameters.AddWithValue("@chucVu", student.ChucVu);
                cmd.Parameters.AddWithValue("@createdAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@updatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@status", 1);
                return DBConnection.ExecuteNonQuery(cmd) > 0;
            }



            catch (MySqlException ex)
            {
                // Xử lý lỗi MySQL
                Debug.WriteLine("Lỗi MySQL: " + ex.Message);
                // Nếu cần, bạn có thể kiểm tra mã lỗi (error code)
                Debug.WriteLine("Mã lỗi: " + ex.Number);
            }
            catch (Exception ex)
            {
                // Xử lý các ngoại lệ khác
                Debug.WriteLine("Lỗi chung: " + ex.Message);
            }
            return false;
        }

        // Cập nhật thông tin sinh viên
        public static bool UpdateStudent(SinhVienDTO student)
        {
            string sql = "UPDATE sinhvien SET name = @name,ngaySinh = @ngaySinh, email = @email, " +
                         "gioiTinh = @gioiTinh, lop_id = @lopId, chucVu = @chucVu, updated_at = @updatedAt WHERE id = @id";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", student.Id);
            cmd.Parameters.AddWithValue("@name", student.Name);
            cmd.Parameters.AddWithValue("@ngaySinh", student.NgaySinh.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@email", student.Email);
            cmd.Parameters.AddWithValue("@gioiTinh", student.GioiTinh);
            cmd.Parameters.AddWithValue("@lopId", student.LopId);
            cmd.Parameters.AddWithValue("@chucVu", student.ChucVu);
            cmd.Parameters.AddWithValue("@updatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Xóa sinh viên
        public static bool DeleteStudent(long id)
        {
            string sql = "UPDATE sinhvien SET status=0 WHERE id = @id";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", id);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Hàm helper để chuyển dữ liệu từ List<object> sang SinhVienDTO
        private static SinhVienDTO MapToSinhVienDTO(List<object> row)
        {
            return new SinhVienDTO
            {
                Id = Convert.ToInt64(row[0]),
                Name = Convert.ToString(row[1]),
                NgaySinh = Convert.ToDateTime(row[2]),
                Email = Convert.ToString(row[3]),
                GioiTinh = Convert.ToInt32(row[4]),
                LopId = Convert.ToInt64(row[5]),
                ChucVu = Convert.ToInt32(row[6]),
                CreatedAt = Convert.ToDateTime(row[7]),
                UpdatedAt = Convert.ToDateTime(row[8]),
                status = Convert.ToInt32(row[9])
            };
        }

        private static SinhVienDetailsDTO MapToSinhVienDetailsDTO(List<object> data)
        {
            return new SinhVienDetailsDTO
            {
                Id = Convert.ToInt64(data[0]),
                Ten = Convert.ToString(data[1]),
                Khoa = Convert.ToString(data[2]),
                Lop = Convert.ToString(data[3]),
                DiemRenLuyen = Convert.ToDecimal(data[4]),
                XepLoai = Convert.ToString(data[5])
            };
        }

        private static SinhVienToExport MapToSinhVienToExport(List<object> row)
        {
            return new SinhVienToExport
            {
                Id = Convert.ToInt64(row[0]),
                Name = row[1]?.ToString(),
                NgaySinh = row[2] != null
                    ? Convert.ToDateTime(row[2]).ToString("dd/MM/yyyy") // Chuyển thành chuỗi định dạng dd/MM/yyyy
                    : null, // Nếu null, để giá trị là null
                Email = row[3]?.ToString(),
                GioiTinh = Convert.ToInt32(row[4]) == 1 ? "Nam" : "Nữ",
                CreatedAt = row[5] != null ? Convert.ToDateTime(row[5]) : (DateTime?)null,
                UpdatedAt = row[6] != null ? Convert.ToDateTime(row[6]) : (DateTime?)null,
                Status = Convert.ToInt32(row[7]),
                Lop = row[8]?.ToString(),
                Khoa = row[9]?.ToString()
            };
        }


    }

    public class SinhVienDetailsDTO
    {
        public long Id { get; set; }
        public string Ten { get; set; }
        public string Khoa { get; set; }
        public string Lop { get; set; }
        public decimal DiemRenLuyen { get; set; }
        public string XepLoai { get; set; }
    }

    public class SinhVienToExport
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string NgaySinh { get; set; }
        public string Email { get; set; }
        public string GioiTinh { get; set; }
        public string Khoa { get; set; } // Tên khoa
        public string Lop { get; set; } // Tên lớp
        public DateTime? CreatedAt { get; set; } // Nullable DateTime
        public DateTime? UpdatedAt { get; set; } // Nullable DateTime
        public int Status { get; set; }

    }

}