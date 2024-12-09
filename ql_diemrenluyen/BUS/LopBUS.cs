using ql_diemrenluyen.DAO;
using ql_diemrenluyen.DTO;

namespace ql_diemrenluyen.BUS
{
    class LopBUS
    {
        public static List<LopDTO> getAllLop()
        {
            return LopDAO.GetAllLop();
        }
        public static List<LopToExport> GetLopHocToExports()
        {
            return LopDAO.GetLopHocToExport();
        }
        //Lấy Đối tượng lớp từ id của lớp
        public static LopDTO GetLopByID(long idLop)
        {
            return LopDAO.GetLopByID(idLop);
        }
        public static bool AddLop(LopDTO lop)
        {
            return LopDAO.AddLop(lop);
        }
        public static bool UpdateLop(LopDTO lop)
        {
            return LopDAO.UpdateLop(lop);
        }
        public static bool DeleteLop(long idLop)
        {
            return LopDAO.DeleteLop(idLop);
        }
        public static List<LopDTO> findAll(String value)
        {
            return LopDAO.findAll(value);
        }
        public static List<LopDTO> findByKhoaId(String value)
        {
            return LopDAO.findByKhoaId(value);
        }
        public static List<LopDTO> getLopByKhoaId(String value)
        {
            return LopDAO.getLopByKhoaId(value);
        }
        public static List<LopDTO> findByHeHoc(String value)
        {
            return LopDAO.findByHeHoc(value);
        }
        public static List<LopDTO> GetListBySearch(String value)
        {
            return LopDAO.GetListBySearch(value);
        }

        public static List<LopDTO> GetLopByCoVanID(long covanId)
        {
            try
            {
                return LopDAO.GetLopByCoVanID(covanId);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi (log lỗi hoặc thông báo người dùng)
                Console.WriteLine("Lỗi khi lấy danh sách lớp theo cố vấn ID: " + ex.Message);
                return new List<LopDTO>();
            }
        }
        public static LopDetailsDTO GetLopDetailsBySinhVienId(long sinhVienId)
        {
            try
            {
                // Gọi phương thức DAO để lấy dữ liệu
                return LopDAO.GetLopDetailsBySinhVienId(sinhVienId);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi (log lỗi hoặc thông báo người dùng)
                Console.WriteLine("Lỗi khi lấy chi tiết lớp theo sinh viên ID: " + ex.Message);
                return null;
            }
        }
        public static List<LopDetailsDTO> GetLopHocCuaCoVanById(long covanId)
        {
            try
            {
                // Gọi phương thức từ DAO để thực hiện truy vấn cơ sở dữ liệu
                return LopDAO.GetLopHocCuaCoVanById(covanId);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi (log lỗi hoặc thông báo người dùng)
                Console.WriteLine("Lỗi khi lấy lớp học của cố vấn theo ID: " + ex.Message);
                return new List<LopDetailsDTO>(); // Trả về danh sách rỗng nếu có lỗi
            }
        }
        public static bool AreAllClassesAssignedToAdvisor()
        {
            return LopDAO.AreAllClassesAssignedToAdvisor();
        }
    }
    //public class LopDetailsDTO
    //{
    //    public int? STT { get; set; }
    //    public long LopId { get; set; }
    //    public string TenLop { get; set; }
    //    public string TenKhoa { get; set; }
    //    public string CoVan { get; set; }
    //    public int? SoLuong { get; set; }
    //}

}
