using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ql_diemrenluyen.DAO;
using ql_diemrenluyen.DTO;

namespace ql_diemrenluyen.BUS
{
    internal class KhoaBUS
    {
        public static KhoaDTO GetKhoaByID(long id)
        {
            return KhoaDAO.GetKhoaByID(id);
        }
        public static List<KhoaDTO> GetAllKhoa()
        {
            return KhoaDAO.GetAllKhoa();
        }
    }
}
