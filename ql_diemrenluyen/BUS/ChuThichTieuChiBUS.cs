using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ql_diemrenluyen.DAO;
using ql_diemrenluyen.DTO;

namespace ql_diemrenluyen.BUS
{
    internal class ChuThichTieuChiBUS
    {
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
    }
}
