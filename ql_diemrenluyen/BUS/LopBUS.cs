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
        public static List<LopDTO> getAllLop()
        {
            return LopDAO.GetAllLop();
        }
        //Lấy Đối tượng lớp từ id của lớp
        public static LopDTO GetLopByID(long idLop)
        {
            return LopDAO.GetLopByID(idLop);
        }
        public static bool AddLop(LopDTO lop) { 
            return LopDAO.AddLop(lop);
        }
        public static bool UpdateLop(LopDTO lop) { 
            return LopDAO.UpdateLop(lop);
        }
        public static bool DeleteLop(long idLop) { 
            return LopDAO.DeleteLop(idLop);
        }
        public static List<LopDTO> findAll(String value)
        {
            return LopDAO.findAll(value);
        }
        public static List<LopDTO> findByName(String value)
        {
            return LopDAO.findByName(value);
        }
        public static List<LopDTO> findById(String value)
        {
            return LopDAO.findById(value);
        }
        public static List<LopDTO> findByKhoaId(String value)
        {
            return LopDAO.findByKhoaId(value);
        }
        public static List<LopDTO> findByHeHoc(String value)
        {
            return LopDAO.findByHeHoc(value);
        }
    }
}
