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
        public static List<KhoaDTO> GetAllKhoa()
        {
            return KhoaDAO.GetAllKhoa();
        }
        public static KhoaDTO GetKhoaByID(long id)
        {
            return KhoaDAO.GetKhoaByID(id);
        }
        public static bool AddKhoa(KhoaDTO khoa)
        {
            return KhoaDAO.AddKhoa(khoa);
        }
        public static bool UpdatedKhoa(KhoaDTO value)
        {
            return KhoaDAO.UpdateKhoa(value);
        }
        public static bool DeleteKhoa(long id) { 
            return KhoaDAO.DeleteKhoa(id);
        }
        public static List<KhoaDTO> findAll(String value)
        {
            return KhoaDAO.findAll(value);
        }
        public static KhoaDTO GetKhoaByName(String name) { 
            return KhoaDAO.GetKhoaByName(name);
        }
        public static List<KhoaDTO> GetListBySearch(String search) { 
            return KhoaDAO.GetListKhoaBySearch(search);
        }
    }
}
