using ql_diemrenluyen.DAO;
using ql_diemrenluyen.DTO;

namespace ql_diemrenluyen.BUS
{
    public class DotChamDiemBUS
    {
        // Lấy tất cả đợt chấm điểm
        public static List<DotChamDiemDTO> GetAllDotChamDiem()
        {
            try
            {
                return DotChamDiemDAO.GetAllDotChamDiem();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching data: " + ex.Message);
                return new List<DotChamDiemDTO>();
            }
        }

        // Lấy đợt chấm điểm theo ID
        public static DotChamDiemDTO GetDotChamDiemById(int id)
        {
            try
            {
                return DotChamDiemDAO.GetDotChamDiemById(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching DotChamDiem by ID: " + ex.Message);
                return null;
            }
        }

        // Thêm đợt chấm điểm mới
        public static bool AddDotChamDiem(DotChamDiemDTO dotChamDiem)
        {
            if (IsValidDotChamDiem(dotChamDiem))
            {
                return DotChamDiemDAO.AddDotChamDiem(dotChamDiem);
            }
            return false;
        }

        // Cập nhật thông tin đợt chấm điểm
        public static bool UpdateDotChamDiem(DotChamDiemDTO dotChamDiem)
        {
            if (dotChamDiem.Id <= 0)
            {
                MessageBox.Show("Invalid ID.");
                return false;
            }

            if (IsValidDotChamDiem(dotChamDiem))
            {
                return DotChamDiemDAO.UpdateDotChamDiem(dotChamDiem);
            }
            return false;
        }

        // Xóa đợt chấm điểm
        public static bool DeleteDotChamDiem(int id)
        {
            if (id <= 0)
            {
                Console.WriteLine("Invalid ID.");
                return false;
            }

            return DotChamDiemDAO.DeleteDotChamDiem(id);
        }

        // Kiểm tra dữ liệu đầu vào hợp lệ
        private static bool IsValidDotChamDiem(DotChamDiemDTO dotChamDiem)
        {
            if (dotChamDiem == null)
            {
                MessageBox.Show("DotChamDiemDTO is null.");
                return false;
            }

            if (dotChamDiem.HocKiId <= 0)
            {
                MessageBox.Show("Invalid HocKiId.");
                return false;
            }

            if (dotChamDiem.StartDate >= dotChamDiem.EndDate)
            {
                MessageBox.Show("StartDate must be before EndDate.");
                MessageBox.Show(dotChamDiem.StartDate.ToString());
                MessageBox.Show(dotChamDiem.EndDate.ToString());
                return false;
            }

            if (string.IsNullOrWhiteSpace(dotChamDiem.Name))
            {
                MessageBox.Show("Name is required.");
                return false;
            }

            return true;
        }

        // Lấy thông tin đợt chấm điểm của sinh viên theo ID
        public static List<ThongTinDotChamDiemDTO> GetDotChamDiemCuaSinhVienTheoId(int sinhVienId)
        {
            try
            {
                var thongTinDotChamDiem = DotChamDiemDAO.GetDotChamDiemCuaSinhVienTheoId(sinhVienId);
                if (thongTinDotChamDiem == null) return new List<ThongTinDotChamDiemDTO>(); // Trả về danh sách rỗng

                // Thiết lập trạng thái hoàn thành thành chuỗi
                thongTinDotChamDiem.HoanThanh = thongTinDotChamDiem.HoanThanh.Equals("0")
                    ? "Chưa hoàn thành"
                    : "Hoàn thành";

                // Bọc kết quả vào danh sách
                return new List<ThongTinDotChamDiemDTO> { thongTinDotChamDiem };
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching DotChamDiem for student: " + ex.Message);
                return new List<ThongTinDotChamDiemDTO>();
            }
        }

        // Lấy thông tin đợt chấm điểm của cố vấn theo ID
        public static List<ThongTinDotChamDiemDTO> GetDotChamDiemCuaCoVanTheoId(int coVanId)
        {
            try
            {
                var thongTinDotChamDiem = DotChamDiemDAO.GetDotChamDiemCuaCoVanTheoId(coVanId);
                if (thongTinDotChamDiem == null) return new List<ThongTinDotChamDiemDTO>(); // Trả về danh sách rỗng

                // Bọc kết quả vào danh sách
                return new List<ThongTinDotChamDiemDTO> { thongTinDotChamDiem };
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching DotChamDiem for advisor: " + ex.Message);
                return new List<ThongTinDotChamDiemDTO>();
            }
        }

        // Lấy tất cả đợt chấm điểm với học kỳ và năm học
        public static List<ThongTinDotChamDiemDTO> GetAllDotChamDiemVoiHocKiVaNamHoc()
        {
            try
            {
                var thongTinDotChamDiem = DotChamDiemDAO.GetAllDotChamDiemVoiHocKiVaNamHoc();
                if (thongTinDotChamDiem == null) return new List<ThongTinDotChamDiemDTO>(); // Trả về danh sách rỗng

                // Bọc kết quả vào danh sách
                return thongTinDotChamDiem;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching all DotChamDiem: " + ex.Message);
                return new List<ThongTinDotChamDiemDTO>();
            }
        }

        // Tìm kiếm đợt chấm điểm
        public static List<ThongTinDotChamDiemDTO> TimKiemDotChamDiem(string hocKy = null, string namHoc = null, string dotChamDiem = null, DateTime? ngayBatDau = null, DateTime? ngayKetThuc = null)
        {
            try
            {
                var thongTinDotChamDiem = DotChamDiemDAO.TimKiemDotChamDiem(hocKy, namHoc, dotChamDiem, ngayBatDau, ngayKetThuc);
                if (thongTinDotChamDiem == null) return new List<ThongTinDotChamDiemDTO>(); // Trả về danh sách rỗng

                // Bọc kết quả vào danh sách
                return thongTinDotChamDiem;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error searching for DotChamDiem: " + ex.Message);
                return new List<ThongTinDotChamDiemDTO>();
            }
        }
    }
}
