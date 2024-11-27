using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ql_diemrenluyen.DTO;
using ql_diemrenluyen.DAO;

namespace ql_diemrenluyen.BUS
{
    public class ThongTinDotChamBUS
    {
        // Lấy danh sách tất cả thông tin đợt chấm điểm
        public static List<ThongTinDotChamDTO> GetAllThongTinDotChamDiem()
        {
            try
            {
                return ThongTinDotChamDAO.GetAllThongTinDotChamDiem();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách thông tin đợt chấm điểm: " + ex.Message);
            }
        }

        // Thêm thông tin đợt chấm điểm
        public static bool AddThongTinDotCham(ThongTinDotChamDTO thongTin)
        {
            // Kiểm tra tính hợp lệ của dữ liệu trước khi thêm
            if (thongTin == null)
            {
                throw new ArgumentNullException("Thông tin đợt chấm không được để trống!");
            }

            if (thongTin.DotChamDiemId <= 0 || thongTin.SinhVienId <= 0 || thongTin.HoanThanh < 0 || thongTin.Status < 0)
            {
                throw new ArgumentException("Dữ liệu thông tin đợt chấm không hợp lệ!");
            }

            try
            {
                return ThongTinDotChamDAO.AddThongTinDotCham(thongTin);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm thông tin đợt chấm điểm: " + ex.Message);
            }
        }

        // Cập nhật thông tin đợt chấm điểm
        //public static bool UpdateThongTinDotCham(ThongTinDotChamDTO thongTin)
        //{
        //    // Kiểm tra tính hợp lệ của dữ liệu
        //    if (thongTin == null || thongTin.Id <= 0)
        //    {
        //        throw new ArgumentNullException("Thông tin đợt chấm hoặc ID không hợp lệ!");
        //    }

        //    try
        //    {
        //        return ThongTinDotChamDAO.UpdateThongTinDotCham(thongTin);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Lỗi khi cập nhật thông tin đợt chấm điểm: " + ex.Message);
        //    }
        //}
        public static bool UpdateThongTinDotCham(int dotChamDiemId, string role, long sinhVienId, long nguoiChamId, int? ketQua, string danhGia)
        {
            // Kiểm tra logic nghiệp vụ
            if (dotChamDiemId <= 0 || sinhVienId <= 0)
            {
                throw new ArgumentException("Dữ liệu không hợp lệ!");
            }

            if (role == "Sinh viên")
            {
                if (sinhVienId != nguoiChamId)
                {
                    throw new ArgumentException("Sinh viên và người chấm không khớp!");
                }
            }
            else if (role != "Cố vấn" && role != "Khoa" && role != "Trường")
            {
                throw new ArgumentException("Role không hợp lệ!");
            }

            // Kiểm tra nếu ketQua hoặc danhGia không hợp lệ (nếu cần thiết)

            // Gọi DAO thực hiện cập nhật
            return ThongTinDotChamDAO.UpdateThongTinDotCham(dotChamDiemId, role, sinhVienId, nguoiChamId, ketQua, danhGia);
        }

        public static long? GetThongTinDotChamId(long dotChamDiemId, string role, long sinhVienId, long nguoiChamId)
        {
            // Kiểm tra điều kiện role hợp lệ
            if (string.IsNullOrEmpty(role))
                throw new ArgumentException("Role không hợp lệb!");

            return ThongTinDotChamDAO.GetThongTinDotChamId(dotChamDiemId, role, sinhVienId, nguoiChamId);
        }
        //lấy id TTDCĐ
        public static long? GetThongTinDotChamDiemId(int dotChamDiemId, long sinhVienId)
        {
            long? thongTinDotChamDiemId = ThongTinDotChamDAO.GetThongTinDotChamDiemId(dotChamDiemId, sinhVienId);

            if (thongTinDotChamDiemId == null)
            {
                MessageBox.Show("Không tìm thấy thông tin đợt chấm điểm đã hoàn thành!", "Thông báo");
            }

            return thongTinDotChamDiemId;
        }


        // Xóa thông tin đợt chấm điểm
        public static bool DeleteThongTinDotChamDiem(long id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID không hợp lệ!");
            }

            try
            {
                return ThongTinDotChamDAO.DeleteThongTinDotChamDiem(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa thông tin đợt chấm điểm: " + ex.Message);
            }
        }
    }
}

