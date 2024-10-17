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
        public static List<Dictionary<string, object>> GetDiemRenLuyenChiTiet(int sinhVienId)
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
    }
}
