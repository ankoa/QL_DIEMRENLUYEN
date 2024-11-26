using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using ql_diemrenluyen.DTO;
using ql_diemrenluyen.DAO;

namespace ql_diemrenluyen.BUS
{
    public class KetQuaDotChamBUS
    {
        // Lấy tất cả kết quả đợt chấm
        public static List<KetQuaDotChamDTO> GetAllKetQuaDotCham()
        {
            try
            {
                return KetQuaDotChamDAO.GetAllKetQuaDotCham();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách kết quả đợt chấm: " + ex.Message);
            }
        }

        // Thêm kết quả đợt chấm
        public static bool AddKetQuaDotCham(KetQuaDotChamDTO ketQua)
        {
            if (ketQua == null || ketQua.ThongTinDotChamDiemId <= 0 || ketQua.KetQua < 0)
            {
                throw new ArgumentException("Dữ liệu kết quả không hợp lệ!");
            }

            try
            {
                return KetQuaDotChamDAO.AddKetQuaDotCham(ketQua);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm kết quả đợt chấm: " + ex.Message);
            }
        }

        // Cập nhật kết quả đợt chấm
        public static bool UpdateKetQuaDotCham(KetQuaDotChamDTO ketQua)
        {
            if (ketQua == null || ketQua.Id <= 0)
            {
                throw new ArgumentException("Dữ liệu kết quả hoặc ID không hợp lệ!");
            }

            try
            {
                return KetQuaDotChamDAO.UpdateKetQuaDotCham(ketQua);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật kết quả đợt chấm: " + ex.Message);
            }
        }

        // Xóa kết quả đợt chấm
        public static bool DeleteKetQuaDotCham(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID không hợp lệ!");
            }

            try
            {
                return KetQuaDotChamDAO.DeleteKetQuaDotCham(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa kết quả đợt chấm: " + ex.Message);
            }
        }
    }
}

