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

        // Thêm đợt chấm điểm mới
        public bool AddDotChamDiem(DotChamDiemDTO dotChamDiem)
        {
            if (IsValidDotChamDiem(dotChamDiem))
            {
                return DotChamDiemDAO.AddDotChamDiem(dotChamDiem);
            }
            return false;
        }

        // Cập nhật thông tin đợt chấm điểm
        public bool UpdateDotChamDiem(DotChamDiemDTO dotChamDiem)
        {
            if (dotChamDiem.Id <= 0)
            {
                Console.WriteLine("Invalid ID.");
                return false;
            }

            if (IsValidDotChamDiem(dotChamDiem))
            {
                return DotChamDiemDAO.UpdateDotChamDiem(dotChamDiem);
            }
            return false;
        }

        // Xóa đợt chấm điểm
        public bool DeleteDotChamDiem(int id)
        {
            if (id <= 0)
            {
                Console.WriteLine("Invalid ID.");
                return false;
            }

            return DotChamDiemDAO.DeleteDotChamDiem(id);
        }

        // Kiểm tra dữ liệu đầu vào hợp lệ
        private bool IsValidDotChamDiem(DotChamDiemDTO dotChamDiem)
        {
            if (dotChamDiem == null)
            {
                Console.WriteLine("DotChamDiemDTO is null.");
                return false;
            }

            if (dotChamDiem.HocKiId <= 0)
            {
                Console.WriteLine("Invalid HocKiId.");
                return false;
            }

            if (dotChamDiem.StartDate >= dotChamDiem.EndDate)
            {
                Console.WriteLine("StartDate must be before EndDate.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(dotChamDiem.Name))
            {
                Console.WriteLine("Name is required.");
                return false;
            }

            return true;
        }

        public static List<ThongTinDotChamDiemDTO> GetDotChamDiemCuaSinhVienTheoId(int sinhVienId)
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

        public static List<ThongTinDotChamDiemDTO> GetDotChamDiemCuaCoVanTheoId(int coVanId)
        {
            var thongTinDotChamDiem = DotChamDiemDAO.GetDotChamDiemCuaCoVanTheoId(coVanId);
            if (thongTinDotChamDiem == null) return new List<ThongTinDotChamDiemDTO>(); // Trả về danh sách rỗng

            // Bọc kết quả vào danh sách
            return new List<ThongTinDotChamDiemDTO> { thongTinDotChamDiem };
        }


    }
}
