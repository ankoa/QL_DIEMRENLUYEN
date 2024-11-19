﻿using ql_diemrenluyen.DAO;
using ql_diemrenluyen.DTO;
using System.Collections.Generic;

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
        public static bool AddGiangVien(GiangVienDTO giangVien, DateTime ngaySinh)
        {
            return GiangVienDAO.AddGiangVien(giangVien,ngaySinh);
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
        public static List<GiangVienDTO> SearchGiangVien(string searchTerm)
        {
            return GiangVienDAO.SearchGiangVien(searchTerm);
        }

        public static List<GiangVienDTO> SearchGiangVienByChucVu(string searchTerm)
        {
            return GiangVienDAO.SearchGiangVienByChucVu(searchTerm);
        }

    }
}
