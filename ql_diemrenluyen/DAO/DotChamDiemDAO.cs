using MySql.Data.MySqlClient;
using ql_diemrenluyen.DTO;

namespace ql_diemrenluyen.DAO
{
    public class DotChamDiemDAO
    {
        // Lấy tất cả đợt chấm điểm
        public static List<DotChamDiemDTO> GetAllDotChamDiem()
        {
            List<DotChamDiemDTO> dotChamDiems = new List<DotChamDiemDTO>();
            string sql = "SELECT * FROM dotchamdiem"; // Thay đổi câu lệnh SQL nếu cần

            List<List<object>> result = DBConnection.ExecuteReader(sql);

            foreach (var row in result)
            {
                DotChamDiemDTO dotChamDiem = new DotChamDiemDTO
                {
                    Id = Convert.ToInt32(row[0]),
                    HocKiId = Convert.ToInt32(row[1]),
                    StartDate = Convert.ToDateTime(row[2]),
                    EndDate = Convert.ToDateTime(row[3]),
                    Name = Convert.ToString(row[4]),
                    Status = Convert.ToInt32(row[5])
                };

                dotChamDiems.Add(dotChamDiem);
            }

            return dotChamDiems;
        }

        // Thêm đợt chấm điểm mới và trả về thông tin đợt chấm vừa thêm
        public static DotChamDiemDTO AddDotChamDiem(DotChamDiemDTO dotChamDiem)
        {
            // Câu SQL thêm đợt chấm điểm
            string sql = @"
        INSERT INTO dotchamdiem (hocki_id, startDate, endDate, name,status) 
        VALUES (@hocKiId, @startDate, @endDate, @name,@status);
        SELECT LAST_INSERT_ID();"; // Lấy ID vừa được thêm

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@hocKiId", dotChamDiem.HocKiId);
            cmd.Parameters.AddWithValue("@startDate", dotChamDiem.StartDate);
            cmd.Parameters.AddWithValue("@endDate", dotChamDiem.EndDate);
            cmd.Parameters.AddWithValue("@name", dotChamDiem.Name);
            cmd.Parameters.AddWithValue("@status", dotChamDiem.Status);

            // Thực thi lệnh và lấy ID vừa được thêm
            object result = DBConnection.ExecuteScalar(cmd);
            if (result != null && long.TryParse(result.ToString(), out long insertedId))
            {
                // Gán ID vào đối tượng và trả về
                dotChamDiem.Id = Convert.ToInt32(insertedId);
                return dotChamDiem;
            }

            // Trả về null nếu không thêm thành công
            return null;
        }


        // Cập nhật thông tin đợt chấm điểm
        public static bool UpdateDotChamDiem(DotChamDiemDTO dotChamDiem)
        {
            string sql = $"UPDATE dotchamdiem SET hocki_id = @hocKiId, startDate = @startDate, " +
                         $"endDate = @endDate, name = @name, status = @status WHERE id = @id";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", dotChamDiem.Id);
            cmd.Parameters.AddWithValue("@hocKiId", dotChamDiem.HocKiId);
            cmd.Parameters.AddWithValue("@startDate", dotChamDiem.StartDate);
            cmd.Parameters.AddWithValue("@endDate", dotChamDiem.EndDate);
            cmd.Parameters.AddWithValue("@name", dotChamDiem.Name);
            cmd.Parameters.AddWithValue("@status", dotChamDiem.Status);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }


        // Xóa đợt chấm điểm
        public static bool DeleteDotChamDiem(int id)
        {
            string sql = $"DELETE FROM dotchamdiem WHERE Id = @id";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", id);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        public static ThongTinDotChamDiemDTO GetDotChamDiemCuaSinhVienTheoId(int sinhVienId)
        {
            // Lấy giờ hiện tại theo múi giờ Việt Nam (UTC+7)
            TimeZoneInfo vnTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
            DateTime ngayHienTai = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, vnTimeZone);

            string sql = @"
        SELECT hk.Name AS HocKy, 
               dcd.name AS DotChamDiem, 
               dcd.startDate AS NgayBatDau, 
               dcd.endDate AS NgayKetThuc, 
               ttdcd.hoanthanh AS HoanThanh,
                dcd.id,hk.Id
        FROM hocky hk
        JOIN dotchamdiem dcd ON hk.Id = dcd.hocki_id
        JOIN thongtindotchamdiem ttdcd ON dcd.id = ttdcd.dotchamdiem_id
        WHERE ttdcd.sinhvien_id = @sinhVienId 
          AND dcd.name = 'Sinh viên'
          AND dcd.startDate <= @ngayHienTai 
          AND dcd.endDate >= @ngayHienTai
            AND dcd.status=1
        LIMIT 1"; // Giới hạn chỉ lấy 1 kết quả

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@sinhVienId", sinhVienId);
            cmd.Parameters.AddWithValue("@ngayHienTai", ngayHienTai); // Gán ngày hiện tại theo giờ VN

            List<List<object>> result = DBConnection.ExecuteReader(cmd);

            // Nếu không có kết quả trả về, trả về null
            if (result.Count == 0) return null;

            // Nếu có kết quả, chuyển đổi dòng đầu tiên thành đối tượng DTO
            var row = result[0];
            ThongTinDotChamDiemDTO thongTinDotChamDiem = new ThongTinDotChamDiemDTO
            {
                Id = Convert.ToInt32(row[5]),
                HocKyId = Convert.ToInt32(row[6]),
                HocKy = Convert.ToString(row[0]),
                DotChamDiem = Convert.ToString(row[1]),
                NgayBatDau = Convert.ToDateTime(row[2]),
                NgayKetThuc = Convert.ToDateTime(row[3]),
                HoanThanh = Convert.ToString(row[4]),
            };
            return thongTinDotChamDiem;
        }
        public static ThongTinDotChamDiemDTO GetDotChamDiemCuaCoVanTheoId(int coVanId)
        {
            // Lấy giờ hiện tại theo múi giờ Việt Nam (UTC+7)
            TimeZoneInfo vnTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
            DateTime ngayHienTai = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, vnTimeZone);

            string sql = @"
    SELECT hk.Name AS HocKy, 
           dcd.name AS DotChamDiem, 
           dcd.startDate AS NgayBatDau, 
           dcd.endDate AS NgayKetThuc, 
           (SUM(CASE WHEN ttdcd.hoanthanh = 0 THEN 1 ELSE 0 END) / COUNT(ttdcd.hoanthanh)) * 100 AS HoanThanh,
            dcd.id, hk.Id
    FROM hocky hk
    JOIN dotchamdiem dcd ON hk.Id = dcd.hocki_id
    JOIN thongtindotchamdiem ttdcd ON dcd.id = ttdcd.dotchamdiem_id
    WHERE ttdcd.covan_id = @coVanId 
      AND dcd.name = 'Cố vấn'
AND dcd.status=1
    GROUP BY hk.Name, dcd.name, dcd.startDate, dcd.endDate
    LIMIT 1"; // Giới hạn chỉ lấy 1 kết quả

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@coVanId", coVanId);

            List<List<object>> result = DBConnection.ExecuteReader(cmd);

            // Nếu không có kết quả trả về, trả về null
            if (result.Count == 0) return null;

            // Nếu có kết quả, chuyển đổi dòng đầu tiên thành đối tượng DTO
            var row = result[0];
            ThongTinDotChamDiemDTO thongTinDotChamDiem = new ThongTinDotChamDiemDTO
            {
                Id = Convert.ToInt32(row[5]),
                HocKyId = Convert.ToInt32(row[6]),
                HocKy = Convert.ToString(row[0]),
                DotChamDiem = Convert.ToString(row[1]),
                NgayBatDau = Convert.ToDateTime(row[2]),
                NgayKetThuc = Convert.ToDateTime(row[3]),
                HoanThanh = Convert.ToString(row[4]) + "%" // Thay đổi để gán giá trị phần trăm hoàn thành
            };
            return thongTinDotChamDiem;
        }

        //        public static ThongTinDotChamDiemDTO GetDotChamDiemCuaCoVanTheoId(int coVanId)
        //        {
        //            // Lấy giờ hiện tại theo múi giờ Việt Nam (UTC+7)
        //            TimeZoneInfo vnTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
        //            DateTime ngayHienTai = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, vnTimeZone);

        //            string sql = @"
        //    SELECT hk.Name AS HocKy, 
        //           dcd.name AS DotChamDiem, 
        //           dcd.startDate AS NgayBatDau, 
        //           dcd.endDate AS NgayKetThuc, 
        //           (SUM(CASE WHEN ttdcd.hoanthanh = 0 THEN 1 ELSE 0 END) / COUNT(ttdcd.hoanthanh)) * 100 AS HoanThanh
        //    FROM hocky hk
        //    JOIN dotchamdiem dcd ON hk.Id = dcd.hocki_id
        //    JOIN thongtindotchamdiem ttdcd ON dcd.id = ttdcd.dotchamdiem_id
        //    WHERE ttdcd.covan_id = @coVanId 
        //      AND dcd.name = 'Cố vấn'
        //      AND dcd.startDate <= @ngayHienTai 
        //      AND dcd.endDate >= @ngayHienTai
        //AND dcd.status=1
        //    GROUP BY hk.Name, dcd.name, dcd.startDate, dcd.endDate
        //    LIMIT 1"; // Giới hạn chỉ lấy 1 kết quả

        //            var cmd = new MySqlCommand(sql);
        //            cmd.Parameters.AddWithValue("@coVanId", coVanId);
        //            cmd.Parameters.AddWithValue("@ngayHienTai", ngayHienTai); // Gán ngày hiện tại theo giờ VN

        //            List<List<object>> result = DBConnection.ExecuteReader(cmd);

        //            // Nếu không có kết quả trả về, trả về null
        //            if (result.Count == 0) return null;

        //            // Nếu có kết quả, chuyển đổi dòng đầu tiên thành đối tượng DTO
        //            var row = result[0];
        //            ThongTinDotChamDiemDTO thongTinDotChamDiem = new ThongTinDotChamDiemDTO
        //            {
        //                HocKy = Convert.ToString(row[0]),
        //                DotChamDiem = Convert.ToString(row[1]),
        //                NgayBatDau = Convert.ToDateTime(row[2]),
        //                NgayKetThuc = Convert.ToDateTime(row[3]),
        //                HoanThanh = Convert.ToString(row[4]) + "%" // Thay đổi để gán giá trị phần trăm hoàn thành
        //            };
        //            Console.WriteLine(thongTinDotChamDiem.ToString());
        //            return thongTinDotChamDiem;
        //        }

        public static List<ThongTinDotChamDiemDTO> GetAllDotChamDiemVoiHocKiVaNamHoc()
        {
            string sql = @"
                SELECT dcd.id AS Id,
                       hk.Name AS HocKy, 
                       dcd.name AS DotChamDiem, 
                       dcd.startDate AS NgayBatDau, 
                       dcd.endDate AS NgayKetThuc, 
                       hk.namhoc AS NamHoc,
                       dcd.status AS Status
                FROM hocky hk
                JOIN dotchamdiem dcd ON hk.Id = dcd.hocki_id
                WHERE dcd.status!=0";

            var cmd = new MySqlCommand(sql);
            List<List<object>> result = DBConnection.ExecuteReader(cmd);

            // Nếu không có kết quả, trả về danh sách rỗng
            if (result.Count == 0) return new List<ThongTinDotChamDiemDTO>();

            var danhSachDotChamDiem = new List<ThongTinDotChamDiemDTO>();

            foreach (var row in result)
            {
                var dotChamDiem = new ThongTinDotChamDiemDTO
                {
                    Id = Convert.ToInt32(row[0]),
                    HocKy = Convert.ToString(row[1]),
                    DotChamDiem = Convert.ToString(row[2]),
                    NgayBatDau = Convert.ToDateTime(row[3]),
                    NgayKetThuc = Convert.ToDateTime(row[4]),
                    NamHoc = Convert.ToString(row[5]),
                    Status = Convert.ToInt32(row[6]) // Thêm Status
                };

                danhSachDotChamDiem.Add(dotChamDiem);
            }
            return danhSachDotChamDiem;
        }


        public static List<ThongTinDotChamDiemDTO> TimKiemDotChamDiem(string hocKy = null, string namHoc = null, string dotChamDiem = null, DateTime? ngayBatDau = null, DateTime? ngayKetThuc = null)
        {
            List<ThongTinDotChamDiemDTO> danhSachDotChamDiem = new List<ThongTinDotChamDiemDTO>();

            // Khởi tạo câu lệnh SQL cơ bản
            string sql = @"
                SELECT dcd.id AS Id,
                       hk.Name AS HocKy, 
                       dcd.name AS DotChamDiem, 
                       dcd.startDate AS NgayBatDau, 
                       dcd.endDate AS NgayKetThuc, 
                       hk.namhoc AS NamHoc,
                        dcd.status
                FROM hocky hk
                JOIN dotchamdiem dcd ON hk.Id = dcd.hocki_id
                WHERE 1 = 1 and dcd.status!=0"; // Điều kiện luôn đúng

            // Khởi tạo danh sách tham số
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            // Thêm điều kiện tìm kiếm nếu có
            if (!string.IsNullOrEmpty(hocKy) && hocKy != "Chọn học kì")
            {
                sql += " AND hk.Name = @hocKy";
                parameters.Add(new MySqlParameter("@hocKy", hocKy));
                //MessageBox.Show(hocKy);
            }

            if (!string.IsNullOrEmpty(namHoc) && namHoc != "Chọn năm học")
            {
                sql += " AND hk.namhoc = @namHoc";
                parameters.Add(new MySqlParameter("@namHoc", namHoc));
                //MessageBox.Show(namHoc);
            }

            if (!string.IsNullOrEmpty(dotChamDiem) && dotChamDiem != "Chọn người chấm")
            {
                sql += " AND dcd.name = @dotChamDiem";
                parameters.Add(new MySqlParameter("@dotChamDiem", dotChamDiem));
                //MessageBox.Show(dotChamDiem);
            }

            if (ngayBatDau.HasValue && ngayKetThuc.HasValue)
            {
                sql += " AND dcd.startDate >= @ngayBatDau";
                sql += " AND dcd.endDate <= @ngayKetThuc";
                parameters.Add(new MySqlParameter("@ngayBatDau", ngayBatDau.Value.ToString("yyyy/MM/dd")));
                parameters.Add(new MySqlParameter("@ngayKetThuc", ngayKetThuc.Value.ToString("yyyy/MM/dd")));
            }
            else
            {
                if (ngayBatDau.HasValue)
                {
                    sql += " AND dcd.startDate = @ngayBatDau";
                    parameters.Add(new MySqlParameter("@ngayBatDau", ngayBatDau.Value.ToString("yyyy/MM/dd")));
                    //MessageBox.Show(ngayBatDau.ToString());
                }

                if (ngayKetThuc.HasValue)
                {
                    sql += " AND dcd.endDate = @ngayKetThuc";
                    parameters.Add(new MySqlParameter("@ngayKetThuc", ngayKetThuc.Value.ToString("yyyy/MM/dd")));
                    //MessageBox.Show(ngayKetThuc.ToString());
                }
            }
            // Thêm mệnh đề ORDER BY để sắp xếp theo NgayBatDau
            sql += " ORDER BY dcd.startDate ASC";

            var cmd = new MySqlCommand(sql);

            // Thêm các tham số vào lệnh
            foreach (var param in parameters)
            {
                cmd.Parameters.Add(param);
            }

            List<List<object>> result = DBConnection.ExecuteReader(cmd);

            // Nếu không có kết quả, trả về danh sách rỗng
            if (result.Count == 0) return danhSachDotChamDiem;

            // Chuyển đổi kết quả thành List<ThongTinDotChamDiemDTO>
            foreach (var row in result)
            {
                var dotChamDiem1 = new ThongTinDotChamDiemDTO
                {
                    Id = Convert.ToInt32(row[0]),
                    HocKy = Convert.ToString(row[1]),
                    DotChamDiem = Convert.ToString(row[2]),
                    NgayBatDau = Convert.ToDateTime(row[3]),
                    NgayKetThuc = Convert.ToDateTime(row[4]),
                    NamHoc = Convert.ToString(row[5]),
                    Status = Convert.ToInt32(row[6])
                };

                danhSachDotChamDiem.Add(dotChamDiem1);
            }

            return danhSachDotChamDiem;
        }


        // Lấy đợt chấm điểm theo ID
        public static DotChamDiemDTO GetDotChamDiemById(int id)
        {
            DotChamDiemDTO dotChamDiem = null;
            string sql = "SELECT * FROM dotchamdiem WHERE id = @id"; // Câu lệnh SQL

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", id); // Thêm tham số cho câu lệnh SQL

            List<List<object>> result = DBConnection.ExecuteReader(cmd);

            // Nếu có kết quả, chuyển đổi dòng đầu tiên thành đối tượng DTO
            if (result.Count > 0)
            {
                var row = result[0];
                dotChamDiem = new DotChamDiemDTO
                {
                    Id = Convert.ToInt32(row[0]),
                    HocKiId = Convert.ToInt32(row[1]),
                    StartDate = Convert.ToDateTime(row[2]),
                    EndDate = Convert.ToDateTime(row[3]),
                    Name = Convert.ToString(row[4])
                };
            }

            return dotChamDiem; // Trả về đối tượng DotChamDiemDTO hoặc null nếu không tìm thấy
        }

        // Lấy đợt chấm điểm theo học kỳ và năm học
        public static List<DotChamDiemDTO> GetDotChamDiemByHocKyAndNamHoc(string hocKy, int namHoc)
        {
            List<DotChamDiemDTO> dotChamDiems = new List<DotChamDiemDTO>();

            string sql = @"
        SELECT dcd.id, dcd.hocki_id, dcd.startDate, dcd.endDate, dcd.name
        FROM dotchamdiem dcd
        JOIN hocky hk ON dcd.hocki_id = hk.id
        WHERE hk.Name = @hocKy AND hk.namhoc = @namHoc";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@hocKy", hocKy);
            cmd.Parameters.AddWithValue("@namHoc", namHoc);

            List<List<object>> result = DBConnection.ExecuteReader(cmd);

            foreach (var row in result)
            {
                DotChamDiemDTO dotChamDiem = new DotChamDiemDTO
                {
                    Id = Convert.ToInt32(row[0]),
                    HocKiId = Convert.ToInt32(row[1]),
                    StartDate = Convert.ToDateTime(row[2]),
                    EndDate = Convert.ToDateTime(row[3]),
                    Name = Convert.ToString(row[4])
                };

                dotChamDiems.Add(dotChamDiem);
            }

            return dotChamDiems;
        }

        public static int? GetIdVoiHocKyVaName(int hocKiId, string name)
        {
            string sql = "SELECT Id FROM dotchamdiem WHERE hocki_id = @hocKiId AND name = @name LIMIT 1";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@hocKiId", hocKiId);
            cmd.Parameters.AddWithValue("@name", name);

            List<List<object>> result = DBConnection.ExecuteReader(cmd);

            // Nếu không tìm thấy kết quả, trả về null
            if (result.Count == 0)
                return null;

            // Trả về Id (giả định Id luôn ở cột đầu tiên)
            return Convert.ToInt32(result[0][0]);
        }
        public static List<int> GetDotChamDiemIdsByHocKiId(int hocKiId)
        {
            List<int> dotChamDiemIds = new List<int>();
            string sql = "SELECT id FROM dotchamdiem WHERE hocki_id = @hocKiId";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@hocKiId", hocKiId);

            List<List<object>> result = DBConnection.ExecuteReader(sql, cmd);

            foreach (var row in result)
            {
                dotChamDiemIds.Add(Convert.ToInt32(row[0]));
            }

            return dotChamDiemIds;
        }



    }



    public class ThongTinDotChamDiemDTO
    {
        public int Id { get; set; }
        public int HocKyId { get; set; }
        public string HocKy { get; set; }
        public string DotChamDiem { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public string? HoanThanh { get; set; }
        public string NamHoc { get; set; } // Thêm thuộc tính NamHoc
        public int Status { get; set; }
    }
}
