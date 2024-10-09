using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ql_diemrenluyen.DTO
{
    public class KhoaDTO
    {
        public long Id { get; set; }
        public string TenKhoa { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public KhoaDTO() { }

        public KhoaDTO(long id, string tenKhoa, DateTime? createdAt, DateTime? updatedAt)
        {
            this.Id = id;
            this.TenKhoa = tenKhoa;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
        }
    }
}
