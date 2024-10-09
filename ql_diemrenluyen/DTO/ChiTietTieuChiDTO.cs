using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ql_diemrenluyen.DTO
{
    public class ChiTietTieuChiDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long SoDiem { get; set; }
        public long TieuChiId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public ChiTietTieuChiDTO() { }

        public ChiTietTieuChiDTO(long id, string name, long soDiem, long tieuChiId, DateTime? createdAt, DateTime? updatedAt)
        {
            this.Id = id;
            this.Name = name;
            this.SoDiem = soDiem;
            this.TieuChiId = tieuChiId;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
        }
    }
}
