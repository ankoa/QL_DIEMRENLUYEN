using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ql_diemrenluyen.DAO;
using ql_diemrenluyen.DTO;

namespace ql_diemrenluyen.BUS
{
    public class HeHocBUS
    {
        public static List<HeHocDTO> getAllHeHoc()
        {
            return HeHocDAO.getAllHeHoc();
        }
        public static bool AddHeHoc(HeHocDTO heHoc)
        {
            return HeHocDAO.AddHeHoc(heHoc);
        }
        public static bool UpdateHeHoc(HeHocDTO hehoc)
        {
            return HeHocDAO.UpdateHeHoc(hehoc);
        }
        public static bool DeleteHeHoc(int id)
        {
            return HeHocDAO.DeleteHeHoc(id);
        }
        public static List<HeHocDTO> findById(int id) { 
            return HeHocDAO.GetHeHocById(id);
        }
        public static List<HeHocDTO> findAll(String value)
        {
            return HeHocDAO.findAll(value);
        }
        public static List<HeHocDTO> findName(String value)
        {
            return HeHocDAO.findName(value);
        }
        public static HeHocDTO GetHeHocByName(String name)
        {
            return HeHocDAO.GetHehocByName(name);
        }
        public static List<HeHocDTO> GetListBySearch(String value)
        {
            return HeHocDAO.GetListBySearch(value);
        }
    }
}
