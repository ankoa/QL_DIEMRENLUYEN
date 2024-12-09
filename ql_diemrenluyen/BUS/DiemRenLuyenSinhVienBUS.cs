using ql_diemrenluyen.DAO;
using ql_diemrenluyen.DTO;

namespace ql_diemrenluyen.BUS
{
    public class DiemRenLuyenBUS
    {
        // Lấy tất cả điểm rèn luyện theo SinhVienId
        public static List<DiemRenLuyenSinhVienDTO> GetDiemRenLuyenBySinhVienId(int sinhVienId)
        {
            return DiemRenLuyenSinhVienDAO.GetDiemRenLuyenBySinhVienId(sinhVienId);
        }

        // Lấy thông tin điểm rèn luyện kèm tên học kỳ dưới dạng Dictionary
        public static List<Dictionary<string, object>> GetDiemRenLuyenChiTiet(long sinhVienId)
        {
            List<DiemRenLuyenSinhVienDTO> diemRenLuyens = DiemRenLuyenSinhVienDAO.GetDiemRenLuyenBySinhVienId(sinhVienId);
            List<HocKyDTO> hocKys = HocKyDAO.GetAllHocKy();

            var result = new List<Dictionary<string, object>>();

            foreach (var diem in diemRenLuyens)
            {
                var hocKy = hocKys.Find(hk => hk.Id == diem.SemesterId);
                var item = new Dictionary<string, object>
                {
                    { "Học kì", hocKy != null ? hocKy.Name : "N/A" },
                    { "Năm học", hocKy != null ? hocKy.namhoc : "N/A" },
                    { "Điểm rèn luyện", diem.Score },
                    { "Comments", diem.Comments }
                };

                result.Add(item);
            }

            return result;
        }

        // Lấy danh sách học kỳ và năm học dưới dạng Dictionary
        public static List<Dictionary<string, string>> GetHocKyVaNamHoc()
        {
            List<HocKyDTO> hocKys = HocKyDAO.GetAllHocKy();

            var result = new List<Dictionary<string, string>>();

            // Sắp xếp theo năm học tăng dần, sau đó là học kỳ theo thứ tự tăng dần
            var sortedHocKys = hocKys
                .OrderBy(h => h.namhoc)  // Sắp xếp theo năm học
                .ThenBy(h => h.Name)     // Sắp xếp theo học kỳ trong cùng năm học (giả sử h.Name là tên học kỳ có thể so sánh)
                .ToList();

            // Chuyển danh sách đã sắp xếp thành dictionary
            foreach (var hocKy in sortedHocKys)
            {
                var item = new Dictionary<string, string>
        {
            { "Học kì", hocKy.Name },
            { "Năm học", hocKy.namhoc.ToString() }
        };

                result.Add(item);
            }

            return result;
        }
        public static List<DiemRenLuyenSinhVienDTO> GetAllDiemRenLuyen()
        {
            return DiemRenLuyenSinhVienDAO.GetAllDiemRenLuyen();
        }

        // Thêm mới điểm rèn luyện
        public static bool AddDiemRenLuyen(DiemRenLuyenSinhVienDTO diemRenLuyen)
        {
            // Kiểm tra dữ liệu đầu vào trước khi gọi DAO
            if (diemRenLuyen == null || diemRenLuyen.Score == null)
                throw new ArgumentException("Dữ liệu điểm rèn luyện không hợp lệ.");

            return DiemRenLuyenSinhVienDAO.AddDiemRenLuyen(diemRenLuyen);
        }

        // Cập nhật điểm rèn luyện
        public static bool UpdateDiemRenLuyen(DiemRenLuyenSinhVienDTO diemRenLuyen)
        {
            if (diemRenLuyen == null || diemRenLuyen.Id == 0)
                throw new ArgumentException("Thông tin cập nhật không hợp lệ.");

            return DiemRenLuyenSinhVienDAO.UpdateDiemRenLuyen(diemRenLuyen);
        }

        // Xóa điểm rèn luyện theo Id
        public static bool DeleteDiemRenLuyen(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID không hợp lệ.");

            return DiemRenLuyenSinhVienDAO.DeleteDiemRenLuyen(id);
        }

        // Lấy danh sách điểm rèn luyện theo SinhVienId
        public static List<DiemRenLuyenSinhVienDTO> GetDiemRenLuyenBySinhVienId(long sinhVienId)
        {
            if (sinhVienId <= 0)
                throw new ArgumentException("SinhVienId không hợp lệ.");

            return DiemRenLuyenSinhVienDAO.GetDiemRenLuyenBySinhVienId(sinhVienId);
        }

        // Lấy điểm rèn luyện của 1 sinh viên trong 1 học kỳ
        public static DiemRenLuyenSinhVienDTO GetDiemRenLuyenBySinhVienIdAndHocKiId(long sinhVienId, int hocKiId)
        {
            if (sinhVienId <= 0 || hocKiId <= 0)
                throw new ArgumentException("Dữ liệu không hợp lệ.");

            return DiemRenLuyenSinhVienDAO.GetDiemRenLuyenBySinhVienIdAndHocKiId(sinhVienId, hocKiId);
        }

        // Lấy điểm trung bình rèn luyện của tất cả sinh viên
        public static double GetAverageDiemRenLuyen()
        {
            return DiemRenLuyenSinhVienDAO.GetAverageDiemRenLuyen();
        }

        // Lấy điểm trung bình rèn luyện theo bộ lọc
        public static double GetAverageDiemRenLuyenByFilter(long? khoaId = null, long? lopId = null, string? hockiname = null, string? namhoc = null)
        {
            return DiemRenLuyenSinhVienDAO.GetAverageDiemRenLuyenByFilter(khoaId, lopId, hockiname, namhoc);
        }


    }
}
