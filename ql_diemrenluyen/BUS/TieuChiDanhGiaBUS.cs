using System;
using System.Collections.Generic;
using ql_diemrenluyen.DAO;
using ql_diemrenluyen.DTO;

namespace ql_diemrenluyen.BUS
{
    internal class TieuChiDanhGiaBUS
    {
        // Lấy danh sách tất cả tiêu chí đánh giá
        public static List<TieuChiDanhGiaDTO> GetAllTieuChiDanhGia()
        {
            return TieuChiDanhGiaDAO.GetAllTieuChiDanhGia();
        }

        // Thêm mới tiêu chí đánh giá
        public static bool AddTieuChiDanhGia(TieuChiDanhGiaDTO tieuChi)
        {
            return TieuChiDanhGiaDAO.AddTieuChiDanhGia(tieuChi);
        }

        // Cập nhật thông tin tiêu chí đánh giá
        public static bool UpdateTieuChiDanhGia(TieuChiDanhGiaDTO tieuChi)
        {
            return TieuChiDanhGiaDAO.UpdateTieuChiDanhGia(tieuChi);
        }

        // Xóa tiêu chí đánh giá
        public static bool DeleteTieuChiDanhGia(long id)
        {
            return TieuChiDanhGiaDAO.DeleteTieuChiDanhGia(id);
        }

        // Tìm kiếm tiêu chí đánh giá mà không có ParentId
        public static List<TieuChiDanhGiaDTO> SearchTieuChiDanhGiaWithoutParentId(int status, string search)
        {
            return TieuChiDanhGiaDAO.SearchTieuChiDanhGiaWithoutParentId(status, search);
        }
        public static List<TieuChiDanhGiaDTO> SearchTieuChiDanhGia(int? parentId, int status, string search)
        {
            return TieuChiDanhGiaDAO.SearchTieuChiDanhGia(parentId,status, search);

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
    }
}
