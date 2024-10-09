using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ql_diemrenluyen.DTO
{
    public class CVHocTapDTO
    {
        public long Id { get; set; }
        public long GiangVienId { get; set; }
        public long LopId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public CVHocTapDTO() { }

        public CVHocTapDTO(long id, long giangVienId, long lopId, DateTime? createdAt, DateTime? updatedAt)
        {
            this.Id = id;
            this.GiangVienId = giangVienId;
            this.LopId = lopId;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
        }
    }
}
