using ql_diemrenluyen.DAO;
using ql_diemrenluyen.DTO;

namespace ql_diemrenluyen.BUS
{
    public class TieuChiDanhGiaBUS
    {
        // Lấy danh sách tất cả tiêu chí đánh giá
        public static List<TieuChiDanhGiaDTO> GetAllTieuChiDanhGia()
        {
            return TieuChiDanhGiaDAO.GetAllTieuChiDanhGia();
        }

        // Thêm mới tiêu chí đánh giá
        public static bool AddTieuChiDanhGia(TieuChiDanhGiaDTO tieuChi)
        {
            if (string.IsNullOrEmpty(tieuChi.Name))
            {
                throw new ArgumentException("Tên tiêu chí đánh giá không được để trống.");
            }

            if (tieuChi.DiemMax < 0)
            {
                throw new ArgumentException("Điểm tối đa không được âm.");
            }

            return TieuChiDanhGiaDAO.AddTieuChiDanhGia(tieuChi);
        }

        // Cập nhật thông tin tiêu chí đánh giá
        public static bool UpdateTieuChiDanhGia(TieuChiDanhGiaDTO tieuChi)
        {
            if (tieuChi.Id <= 0)
            {
                throw new ArgumentException("Id tiêu chí đánh giá không hợp lệ.");
            }

            if (string.IsNullOrEmpty(tieuChi.Name))
            {
                throw new ArgumentException("Tên tiêu chí đánh giá không được để trống.");
            }

            if (tieuChi.DiemMax < 0)
            {
                throw new ArgumentException("Điểm tối đa không được âm.");
            }

            return TieuChiDanhGiaDAO.UpdateTieuChiDanhGia(tieuChi);
        }

        // Xóa tiêu chí đánh giá
        public static bool DeleteTieuChiDanhGia(long id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id tiêu chí đánh giá không hợp lệ.");
            }

            return TieuChiDanhGiaDAO.DeleteTieuChiDanhGia(id);
        }

        // Tìm kiếm tiêu chí đánh giá mà không có ParentId
        public static List<TieuChiDanhGiaDTO> SearchTieuChiDanhGiaWithoutParentId(int status, string search)
        {
            return TieuChiDanhGiaDAO.SearchTieuChiDanhGiaWithoutParentId(status, search);
        }

        // Tìm kiếm tiêu chí đánh giá với ParentId
        public static List<TieuChiDanhGiaDTO> SearchTieuChiDanhGia(int? parentId, int status, string search)
        {
            return TieuChiDanhGiaDAO.SearchTieuChiDanhGia(parentId, status, search);
        }

        // Hàm kiểm tra điểm có phải là số hợp lệ hay không
        public static bool IsValidScore(string scoreText)
        {
            // Kiểm tra nếu scoreText là một số nguyên hợp lệ và lớn hơn hoặc bằng 0
            if (int.TryParse(scoreText, out int score))
            {
                return score >= 0; // Điểm phải là số dương hoặc bằng 0
            }
            return false; // Nếu không phải số hợp lệ
        }
        public static List<ChuThichTieuChiDTO> LayChuThichTieuChi()
        {
            return ChuThichTieuChiDAO.GetAllChuThichTieuChi();
        }
        public static void HienThiChuThich(List<ChuThichTieuChiDTO> chuThichList)
        {
            foreach (var chuThich in chuThichList)
            {
                Console.WriteLine($"ID: {chuThich.Id}, Tên: {chuThich.Name}, Điểm: {chuThich.Diem}, Trạng thái: {chuThich.Status}");
            }
        }
        // Xuất tất cả tiêu chí đánh giá theo định dạng phân cấp
        public static List<TieuChiDanhGiaDTO> XuatAllTieuChiDanhGia()
        {
            return TieuChiDanhGiaDAO.XuatAllTieuChiDanhGia();
        }
        public static List<ChuThichTieuChiDTO> GetChuThichByTieuChiId(long tieuChiId)
        {
            try
            {
                return ChuThichTieuChiDAO.GetChuThichByTieuChiId(tieuChiId);
            }
            catch (Exception ex)
            {
                // Ghi log lỗi hoặc xử lý ngoại lệ
                Console.WriteLine($"Lỗi khi lấy danh sách chú thích theo tiêu chí ID: {ex.Message}");
                return new List<ChuThichTieuChiDTO>();
            }
        }

        public static long? GetIdTieuChiCha(long tieuchiId)
        {
            return TieuChiDanhGiaDAO.GetIdTieuChiCha(tieuchiId);
        }

    }
}
