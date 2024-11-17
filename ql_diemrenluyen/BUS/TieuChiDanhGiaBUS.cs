using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ql_diemrenluyen.DAO;
using ql_diemrenluyen.DTO;

namespace ql_diemrenluyen.BUS
{
    public class TieuChiDanhGiaBUS
    {
        // Lấy tất cả tiêu chí đánh giá
        public static List<TieuChiDanhGiaDTO> GetAllTieuChiDanhGia()
        {
            return TieuChiDanhGiaDAO.GetAllTieuChiDanhGia();
        }

        // Xuất tất cả tiêu chí đánh giá theo định dạng phân cấp
        public static List<TieuChiDanhGiaDTO> XuatAllTieuChiDanhGia()
        {
            return TieuChiDanhGiaDAO.XuatAllTieuChiDanhGia();
        }

        // Thêm tiêu chí đánh giá mới
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

        // Cập nhật tiêu chí đánh giá
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
    }
}

