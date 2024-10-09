using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ql_diemrenluyen.DTO
{
    public class LopDTO
    {
        public long Id { get; set; }
        public string TenLop { get; set; }
        public long KhoaId { get; set; }
        public int HeDaoTao { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public LopDTO() { }

        public LopDTO(long id, string tenLop, long khoaId, int heDaoTao, DateTime? createdAt, DateTime? updatedAt)
        {
            this.Id = id;
            this.TenLop = tenLop;
            this.KhoaId = khoaId;
            this.HeDaoTao = heDaoTao;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
        }
    }
}
