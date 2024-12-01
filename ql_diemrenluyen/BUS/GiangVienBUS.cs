using ql_diemrenluyen.DAO;
using ql_diemrenluyen.DTO;

namespace ql_diemrenluyen.BUS
{
    public class GiangVienBUS
    {
        // Lấy tất cả giảng viên
        public static List<GiangVienDTO> GetAllGiangVien()
        {
            return GiangVienDAO.GetAllGiangVien();
        }

        // Thêm giảng viên mới
        public static bool AddGiangVien(GiangVienDTO giangVien)
        {
            return GiangVienDAO.AddGiangVien(giangVien);
        }
        public static long GetLastInsertedId()
        {
            return GiangVienDAO.GetLastInsertedId();
        }
        // Cập nhật thông tin giảng viên
        public static bool UpdateGiangVien(GiangVienDTO giangVien)
        {
            return GiangVienDAO.UpdateGiangVien(giangVien);
        }

        // Xóa giảng viên
        public static bool DeleteGiangVien(long id)
        {
            return GiangVienDAO.DeleteGiangVien(id);
        }
        public static GiangVienDTO GetGiangVienById(long id)
        {
            return GiangVienDAO.GetGiangVienById(id);
        }

        public static List<GiangVienDTO> GetGiangVienByKhoaId(long khoaId)
        {
            return GiangVienDAO.GetGiangVienByKhoaId(khoaId);
        }
        public static List<GiangVienDTO> SearchGiangVien(int? selectedId, int status, string searchTerm)
        {
            return GiangVienDAO.SearchGiangVien(searchTerm);
        }

        //public static List<GiangVienDTO> SearchGiangVienByChucVu(string searchTerm)
        //{
        //    return GiangVienDAO.SearchGiangVienByChucVu(searchTerm);
        //}

    }
}
