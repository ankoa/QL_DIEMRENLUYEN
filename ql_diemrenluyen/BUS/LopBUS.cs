using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ql_diemrenluyen.DAO;
using ql_diemrenluyen.DTO;

namespace ql_diemrenluyen.BUS
{
    class LopBUS
    {
        //Lấy Đối tượng lớp từ id của lớp
        public static LopDTO GetLopByID(long idLop)
        {
            return LopDAO.GetLopByID(idLop);
        }
        public static List<LopDTO> GetAllLop()
        { return LopDAO.GetAllLop(); }
    }
}
