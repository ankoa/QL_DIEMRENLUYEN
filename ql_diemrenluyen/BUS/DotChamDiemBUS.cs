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
                MessageBox.Show("Ngày bắt đầu phải trước ngày kết thúc");
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

        public static bool CheckValidDotChamDiem(string hocKy, int namHoc, string nguoiCham, DateTime startDate, DateTime endDate)
        {
            // Lấy danh sách các đợt chấm điểm theo học kỳ và năm học
            List<DotChamDiemDTO> dotChamDiems = DotChamDiemDAO.GetDotChamDiemByHocKyAndNamHoc(hocKy, namHoc);

            // Kiểm tra xem có đợt chấm nào trùng người chấm và thời gian giao nhau không
            foreach (var dotCham in dotChamDiems)
            {
                // Kiểm tra nếu người chấm trùng và thời gian giao nhau
                if (dotCham.Name == nguoiCham)
                {
                    MessageBox.Show("Đợt chấm điểm " + nguoiCham + " đã tồn tại trong học kì " + hocKy + " năm học " + namHoc);
                    return false;
                }

                // Kiểm tra thứ tự chấm điểm
                if (!IsValidOrder(nguoiCham, dotCham.Name, startDate, dotCham.StartDate, endDate, dotCham.EndDate))
                {
                    return false; // Thứ tự không hợp lệ
                }
            }

            return true;
        }

        public static bool CheckValidDotChamDiemUpdate(string hocKy, int namHoc, string nguoiCham, DateTime startDate, DateTime endDate)
        {
            // Lấy danh sách các đợt chấm điểm theo học kỳ và năm học
            List<DotChamDiemDTO> dotChamDiems = DotChamDiemDAO.GetDotChamDiemByHocKyAndNamHoc(hocKy, namHoc);

            // Kiểm tra xem có đợt chấm nào trùng người chấm và thời gian giao nhau không
            foreach (var dotCham in dotChamDiems)
            {
                // Kiểm tra thứ tự chấm điểm
                if (!IsValidOrder(nguoiCham, dotCham.Name, startDate, dotCham.StartDate, endDate, dotCham.EndDate))
                {
                    return false; // Thứ tự không hợp lệ
                }
            }

            return true;
        }


        // Hàm kiểm tra thứ tự hợp lệ giữa các đợt chấm
        private static bool IsValidOrder(string newDotChamType, string existingDotChamType, DateTime newStartDate, DateTime existingStartDate, DateTime newEndDate, DateTime existingEndDate)
        {
            {
                // Định nghĩa thứ tự hợp lệ
                var order = new Dictionary<string, int>
                {
                    { "Sinh viên", 1 },
                    { "Cố vấn", 2 },
                    { "Khoa", 3 },
                    { "Trường", 4 }
                };

                // Kiểm tra thứ tự
                if (order.ContainsKey(newDotChamType) && order.ContainsKey(existingDotChamType))
                {
                    int newOrder = order[newDotChamType];
                    int existingOrder = order[existingDotChamType];

                    // Kiểm tra điều kiện thứ tự và thời gian không được giao nhau
                    if (newOrder < existingOrder)
                    {
                        // Đợt chấm mới phải diễn ra trước và kết thúc trước đợt chấm hiện có
                        if (newEndDate > existingStartDate)
                        {
                            MessageBox.Show("Đợt chấm điểm của " + newDotChamType + " phải kết thúc trước khi đợt chấm điểm của " + existingDotChamType + " bắt đầu.");
                            return false; // Thứ tự không hợp lệ hoặc bị giao nhau
                        }
                    }
                    else if (newOrder > existingOrder)
                    {
                        // Đợt chấm mới phải diễn ra sau và bắt đầu sau đợt chấm hiện có
                        if (newStartDate < existingEndDate)
                        {
                            MessageBox.Show("Đợt chấm điểm của " + newDotChamType + " phải bắt đầu sau khi đợt chấm điểm của " + existingDotChamType + " kết thúc.");
                            return false; // Thứ tự không hợp lệ hoặc bị giao nhau
                        }
                    }
                }

                return true; // Thứ tự và thời gian hợp lệ
            }

        }
        public static int GetIdVoiHocKyVaName(int hocKiId, string name)
        {
            if (hocKiId <= 0 || string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Dữ liệu không hợp lệ!");
            }

            var dotChamDiems = DotChamDiemDAO.GetAllDotChamDiem();
            foreach (var dot in dotChamDiems)
            {
                if (dot.HocKiId == hocKiId && dot.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    return dot.Id;
                }
            }

            throw new Exception("Không tìm thấy đợt chấm điểm với học kỳ đã chọn.");
        }



    }
}
