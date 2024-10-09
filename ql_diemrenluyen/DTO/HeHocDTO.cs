using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ql_diemrenluyen.DTO
{
    public class HeHocDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public HeHocDTO() { }

        public HeHocDTO(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
