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
        //public static bool DeleteChuThichTieuChi(long id)
        //{
        //    try
        //    {
        //        return ChuThichTieuChiDAO.DeleteChuThichTieuChi(id);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Lỗi khi xóa chú thích tiêu chí: " + ex.Message);
        //        return false;
        //    }
        //}
    }
}
