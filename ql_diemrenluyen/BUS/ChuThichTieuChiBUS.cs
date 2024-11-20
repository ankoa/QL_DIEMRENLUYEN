using System;
using System.Collections.Generic;
using ql_diemrenluyen.DTO;
using ql_diemrenluyen.DAO;

namespace ql_diemrenluyen.BUS
{
    public class ChuThichTieuChiBUS
    {
        // Lấy tất cả các chú thích tiêu chí
        public static List<ChuThichTieuChiDTO> GetAllChuThichTieuChi()
        {
            try
            {
                return ChuThichTieuChiDAO.GetAllChuThichTieuChi();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy tất cả chú thích tiêu chí: " + ex.Message);
                return new List<ChuThichTieuChiDTO>(); // Trả về danh sách rỗng nếu có lỗi
            }
        }
        public static List<ChuThichTieuChiDTO> GetAllChuThichTieuChi2()
        {
            try
            {
                return ChuThichTieuChiDAO.GetAllChuThichTieuChi2();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy tất cả chú thích tiêu chí: " + ex.Message);
                return new List<ChuThichTieuChiDTO>(); // Trả về danh sách rỗng nếu có lỗi
            }
        }
        
        // Hiển thị danh sách chú thích
        public static void HienThiChuThich(List<ChuThichTieuChiDTO> chuThichList)
        {
            foreach (var chuThich in chuThichList)
            {
                Console.WriteLine($"ID: {chuThich.Id}, Tên: {chuThich.Name}, Điểm: {chuThich.Diem}, Trạng thái: {chuThich.Status}");
            }
        }

        // Lấy danh sách chú thích theo ID tiêu chí
        public static List<ChuThichTieuChiDTO> GetChuThichByTieuChiId(long tieuChiId)
        {
            try
            {
                return ChuThichTieuChiDAO.GetChuThichByTieuChiId(tieuChiId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy danh sách chú thích theo tiêu chí ID: {ex.Message}");
                return new List<ChuThichTieuChiDTO>();
            }
        }

        // Thêm mới chú thích tiêu chí
        public static bool AddChuThichTieuChi(ChuThichTieuChiDTO chuThich)
        {
            try
            {
                return ChuThichTieuChiDAO.AddChuThichTieuChi(chuThich);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm chú thích tiêu chí: " + ex.Message);
                return false;
            }
        }

        // Cập nhật chú thích tiêu chí
        public static bool UpdateChuThichTieuChi(ChuThichTieuChiDTO chuThich)
        {
            try
            {
                return ChuThichTieuChiDAO.UpdateChuThichTieuChi(chuThich);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật chú thích tiêu chí: " + ex.Message);
                return false;
            }
        }

        // Xóa chú thích tiêu chí
        public static bool DeleteChuThichTieuChi(long id)
        {
            try
            {
                return ChuThichTieuChiDAO.DeleteChuThichTieuChi(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa chú thích tiêu chí: " + ex.Message);
                return false;
            }
        }

        // Tìm kiếm chú thích theo tiêu chí
        public static List<ChuThichTieuChiDTO> SearchChuThich(int? tcID, int status, string search)
        {
            return ChuThichTieuChiDAO.SearchChuThich(tcID, status, search);
        }

        // Kiểm tra điểm hợp lệ
        public static bool IsValidScore(string scoreText)
        {
            if (int.TryParse(scoreText, out int score))
            {
                return score >= 0; // Điểm phải là số dương hoặc bằng 0
            }
            return false;
        }
    }
}
