using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ql_diemrenluyen.DAO;
using ql_diemrenluyen.DTO;

namespace ql_diemrenluyen.BUS
{
    public class ChiTietDotChamBUS
    {
        // Lấy tất cả chi tiết đợt chấm
        public static List<ChiTietDotChamDTO> GetAllChiTietDotCham()
        {
            try
            {
                return ChiTietDotChamDAO.GetAllChiTietDotCham();
            }
            catch (Exception ex)
            {
                // Log lỗi và trả về danh sách rỗng
                Console.WriteLine("Lỗi khi lấy tất cả chi tiết đợt chấm: " + ex.Message);
                return new List<ChiTietDotChamDTO>();
            }
        }

        // Thêm chi tiết đợt chấm mới
        public static bool AddChiTietDotCham(ChiTietDotChamDTO chiTietDotCham)
        {
            try
            {
                // Thực hiện kiểm tra logic trước khi thêm
                if (chiTietDotCham.Diem < 0 || chiTietDotCham.Diem > 100)
                {
                    throw new ArgumentException("Điểm phải nằm trong khoảng từ 0 đến 100.");
                }

                return ChiTietDotChamDAO.AddChiTietDotCham(chiTietDotCham);
            }
            catch (Exception ex)
            {
                // Log lỗi và trả về false
                Console.WriteLine("Lỗi khi thêm chi tiết đợt chấm: " + ex.Message);
                return false;
            }
        }

        // Cập nhật chi tiết đợt chấm
        public static bool UpdateChiTietDotCham(ChiTietDotChamDTO chiTietDotCham)
        {
            try
            {
                // Thực hiện kiểm tra logic trước khi cập nhật
                if (chiTietDotCham.Diem < 0 || chiTietDotCham.Diem > 100)
                {
                    throw new ArgumentException("Điểm phải nằm trong khoảng từ 0 đến 100.");
                }

                return ChiTietDotChamDAO.UpdateChiTietDotCham(chiTietDotCham);
            }
            catch (Exception ex)
            {
                // Log lỗi và trả về false
                Console.WriteLine("Lỗi khi cập nhật chi tiết đợt chấm: " + ex.Message);
                return false;
            }
        }

        // Xóa chi tiết đợt chấm (cập nhật status)
        public static bool DeleteChiTietDotCham(long id)
        {
            try
            {
                return ChiTietDotChamDAO.DeleteChiTietDotCham(id);
            }
            catch (Exception ex)
            {
                // Log lỗi và trả về false
                Console.WriteLine("Lỗi khi xóa chi tiết đợt chấm: " + ex.Message);
                return false;
            }
        }
        public static bool IsChiTietDotChamExist(long thongTinDotChamDiemId)
        {
            // Gọi phương thức DAO để kiểm tra sự tồn tại
            return ChiTietDotChamDAO.IsChiTietDotChamExist(thongTinDotChamDiemId);
        }
    }
}

