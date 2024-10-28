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
                    Name = Convert.ToString(row[4])
                };

                dotChamDiems.Add(dotChamDiem);
            }

            return dotChamDiems;
        }

        // Thêm đợt chấm điểm mới
        public static bool AddDotChamDiem(DotChamDiemDTO dotChamDiem)
        {
            string sql = $"INSERT INTO dotchamdiem (HocKiId, StartDate, EndDate, Name) " +
                         $"VALUES (@hocKiId, @startDate, @endDate, @name)";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@hocKiId", dotChamDiem.HocKiId);
            cmd.Parameters.AddWithValue("@startDate", dotChamDiem.StartDate);
            cmd.Parameters.AddWithValue("@endDate", dotChamDiem.EndDate);
            cmd.Parameters.AddWithValue("@name", dotChamDiem.Name);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Cập nhật thông tin đợt chấm điểm
        public static bool UpdateDotChamDiem(DotChamDiemDTO dotChamDiem)
        {
            string sql = $"UPDATE dotchamdiem SET HocKiId = @hocKiId, StartDate = @startDate, " +
                         $"EndDate = @endDate, Name = @name WHERE Id = @id";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", dotChamDiem.Id);
            cmd.Parameters.AddWithValue("@hocKiId", dotChamDiem.HocKiId);
            cmd.Parameters.AddWithValue("@startDate", dotChamDiem.StartDate);
            cmd.Parameters.AddWithValue("@endDate", dotChamDiem.EndDate);
            cmd.Parameters.AddWithValue("@name", dotChamDiem.Name);

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
               ttdcd.hoanthanh AS HoanThanh
        FROM hocky hk
        JOIN dotchamdiem dcd ON hk.Id = dcd.hocki_id
        JOIN thongtindotchamdiem ttdcd ON dcd.id = ttdcd.dotchamdiem_id
        WHERE ttdcd.sinhvien_id = @sinhVienId 
          AND dcd.name = 'Sinh viên'
          AND dcd.startDate <= @ngayHienTai 
          AND dcd.endDate >= @ngayHienTai
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
                HocKy = Convert.ToString(row[0]),
                DotChamDiem = Convert.ToString(row[1]),
                NgayBatDau = Convert.ToDateTime(row[2]),
                NgayKetThuc = Convert.ToDateTime(row[3]),
                HoanThanh = Convert.ToString(row[4])
            };
            Console.WriteLine(thongTinDotChamDiem.ToString());
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
           (SUM(CASE WHEN ttdcd.hoanthanh = 0 THEN 1 ELSE 0 END) / COUNT(ttdcd.hoanthanh)) * 100 AS HoanThanh
    FROM hocky hk
    JOIN dotchamdiem dcd ON hk.Id = dcd.hocki_id
    JOIN thongtindotchamdiem ttdcd ON dcd.id = ttdcd.dotchamdiem_id
    WHERE ttdcd.covan_id = @coVanId 
      AND dcd.name = 'Cố vấn'
      AND dcd.startDate <= @ngayHienTai 
      AND dcd.endDate >= @ngayHienTai
    GROUP BY hk.Name, dcd.name, dcd.startDate, dcd.endDate
    LIMIT 1"; // Giới hạn chỉ lấy 1 kết quả

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@coVanId", coVanId);
            cmd.Parameters.AddWithValue("@ngayHienTai", ngayHienTai); // Gán ngày hiện tại theo giờ VN

            List<List<object>> result = DBConnection.ExecuteReader(cmd);

            // Nếu không có kết quả trả về, trả về null
            if (result.Count == 0) return null;

            // Nếu có kết quả, chuyển đổi dòng đầu tiên thành đối tượng DTO
            var row = result[0];
            ThongTinDotChamDiemDTO thongTinDotChamDiem = new ThongTinDotChamDiemDTO
            {
                HocKy = Convert.ToString(row[0]),
                DotChamDiem = Convert.ToString(row[1]),
                NgayBatDau = Convert.ToDateTime(row[2]),
                NgayKetThuc = Convert.ToDateTime(row[3]),
                HoanThanh = Convert.ToString(row[4]) + "%" // Thay đổi để gán giá trị phần trăm hoàn thành
            };
            Console.WriteLine(thongTinDotChamDiem.ToString());
            return thongTinDotChamDiem;
        }

        public static List<ThongTinDotChamDiemDTO> GetAllDotChamDiemVoiHocKiVaNamHoc()
        {
            string sql = @"
            SELECT dcd.id AS Id,
                   hk.Name AS HocKy, 
                   dcd.name AS DotChamDiem, 
                   dcd.startDate AS NgayBatDau, 
                   dcd.endDate AS NgayKetThuc, 
                   hk.namhoc AS NamHoc
            FROM hocky hk
            JOIN dotchamdiem dcd ON hk.Id = dcd.hocki_id";

            var cmd = new MySqlCommand(sql);
            List<List<object>> result = DBConnection.ExecuteReader(cmd);

            // Nếu không có kết quả, trả về danh sách rỗng
            if (result.Count == 0) return new List<ThongTinDotChamDiemDTO>();

            // Chuyển đổi kết quả thành List<ThongTinDotChamDiemDTO>
            var danhSachDotChamDiem = new List<ThongTinDotChamDiemDTO>();

            foreach (var row in result)
            {
                var dotChamDiem = new ThongTinDotChamDiemDTO
                {
                    Id = Convert.ToInt32(row[0]),
                    HocKy = Convert.ToString(row[1]), // Chỉnh sửa: HocKy là kiểu string
                    DotChamDiem = Convert.ToString(row[2]), // Lấy tên Đợt Chấm Điểm
                    NgayBatDau = Convert.ToDateTime(row[3]), // Ngày Bắt Đầu
                    NgayKetThuc = Convert.ToDateTime(row[4]), // Ngày Kết Thúc
                    NamHoc = Convert.ToString(row[5]) // Gán NamHoc
                };

                Console.WriteLine($"HocKy: {dotChamDiem.HocKy}, DotChamDiem: {dotChamDiem.DotChamDiem}, NamHoc: {dotChamDiem.NamHoc}");
                danhSachDotChamDiem.Add(dotChamDiem);
            }
            return danhSachDotChamDiem;
        }
    }

    public class ThongTinDotChamDiemDTO
    {
        public int Id { get; set; }
        public string HocKy { get; set; }
        public string DotChamDiem { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public string? HoanThanh { get; set; }
        public string NamHoc { get; set; } // Thêm thuộc tính NamHoc
    }
}
