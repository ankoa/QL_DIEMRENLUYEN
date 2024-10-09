using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ql_diemrenluyen.DTO
{
    public class HocKyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public HocKyDTO() { }

        public HocKyDTO(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
