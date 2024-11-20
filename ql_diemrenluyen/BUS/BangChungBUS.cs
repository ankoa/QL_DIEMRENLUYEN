using System.Collections.Generic;
using ql_diemrenluyen.DAO;
using ql_diemrenluyen.DTO;

namespace ql_diemrenluyen.BUS
{
    public class BangChungBUS
    {
        // Lấy danh sách tất cả bản chứng
        public static List<BangChungDTO> GetAllBangChung()
        {
            return BangChungDAO.GetAllBangChung();
        }

        // Thêm bản chứng mới
        public static bool AddBangChung(BangChungDTO bangChung)
        {
            return BangChungDAO.AddBangChung(bangChung);
        }

        // Cập nhật thông tin bản chứng
        public static bool UpdateBangChung(BangChungDTO bangChung)
        {
            return BangChungDAO.UpdateBangChung(bangChung);
        }

        // Xóa bản chứng
        public static bool DeleteBangChung(int id)
        {
            return BangChungDAO.DeleteBangChung(id);
        }
        public static List<BangChungDTO> SearchBangChung(int? TCid, int status, string search, int? selectedHocKyId)
        {
            return BangChungDAO.SearchBangChung(TCid, status, search, selectedHocKyId);
        }

    }
}
