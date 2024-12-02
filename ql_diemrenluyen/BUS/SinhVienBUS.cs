using ql_diemrenluyen.DAO;
using ql_diemrenluyen.DTO;

namespace ql_diemrenluyen.BUS
{
    public class SinhVienBUS
    {
        // Lấy tất cả sinh viên
        public static List<SinhVienDTO> GetAllStudents()
        {
            return SinhVienDAO.GetAllStudents();
        }

        public static List<SinhVienDTO> GetAllStudentsToChamDiem()
        {
            return SinhVienDAO.GetAllStudentsToChamDiem();
        }

        // Tìm kiếm sinh viên cơ bản
        public static List<SinhVienDTO> basicSearch(string str)
        {
            return SinhVienDAO.basicSearch(str);
        }

        // Tìm kiếm sinh viên nâng cao 
        public List<SinhVienDTO> advancedSearch(string maSV, string hoTen, long lopID, long khoaID)
        {
            return SinhVienDAO.advancedSearch(maSV, hoTen, lopID, khoaID);
        }

        // Lấy sinh viên theo ID
        public static SinhVienDTO GetStudentById(long id)
        {
            return SinhVienDAO.GetStudentById(id);
        }

        // Thêm sinh viên mới
        public static bool AddStudent(SinhVienDTO student)
        {
            return SinhVienDAO.AddStudent(student);
        }

        // Cập nhật thông tin sinh viên
        public static bool UpdateStudent(SinhVienDTO student)
        {
            return SinhVienDAO.UpdateStudent(student);
        }

        // Xóa sinh viên
        public static bool DeleteStudent(long id)
        {
            return SinhVienDAO.DeleteStudent(id);
        }

        public static List<SinhVienToExport> GetAllStudentsToExport()
        {
            return SinhVienDAO.GetAllStudentsToExport();
        }
    }
}
