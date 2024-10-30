using ql_diemrenluyen.DAO;
using ql_diemrenluyen.DTO;

namespace ql_diemrenluyen.BUS
{
    public class HocKyBUS
    {
        // Lấy tất cả học kỳ
        public static List<HocKyDTO> GetAllHocKy()
        {
            try
            {
                return HocKyDAO.GetAllHocKy();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách học kỳ: " + ex.Message);
                return new List<HocKyDTO>();
            }
        }

        // Thêm học kỳ mới
        public static bool AddHocKy(HocKyDTO hocKy)
        {
            try
            {
                if (IsValidHocKy(hocKy))
                {
                    return HocKyDAO.AddHocKy(hocKy);
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm học kỳ: " + ex.Message);
                return false;
            }
        }

        // Cập nhật học kỳ
        public static bool UpdateHocKy(HocKyDTO hocKy)
        {
            try
            {
                if (IsValidHocKy(hocKy))
                {
                    return HocKyDAO.UpdateHocKy(hocKy);
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật học kỳ: " + ex.Message);
                return false;
            }
        }

        // Xóa học kỳ
        public static bool DeleteHocKy(int id)
        {
            try
            {
                return HocKyDAO.DeleteHocKy(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa học kỳ: " + ex.Message);
                return false;
            }
        }

        // Lấy tất cả các năm học
        public static List<string> GetAllNamHoc()
        {
            try
            {
                return HocKyDAO.GetAllNamHoc();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách năm học: " + ex.Message);
                return new List<string>();
            }
        }

        // Kiểm tra tính hợp lệ của dữ liệu học kỳ
        private static bool IsValidHocKy(HocKyDTO hocKy)
        {
            if (string.IsNullOrWhiteSpace(hocKy.Name))
            {
                Console.WriteLine("Tên học kỳ không được để trống.");
                return false;
            }
            if (hocKy.namhoc <= 0)
            {
                Console.WriteLine("Năm học không hợp lệ.");
                return false;
            }
            return true;
        }
    }
}
