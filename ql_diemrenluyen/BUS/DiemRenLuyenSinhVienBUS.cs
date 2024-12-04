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



    }
}
