using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ql_diemrenluyen.DTO
{
    public class TieuChiDanhGiaDTO
    {
        public long Id { get; set; } 
        public string Name { get; set; } 
        public int DiemMax { get; set; } 
        public long? ParentId { get; set; } 
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int status;

        // Constructor
        public TieuChiDanhGiaDTO(long id, string name, int diemMax, long? parentId, DateTime? createdAt, DateTime? updatedAt, int status)
        {
            this.Id = id;
            this.Name = name;
            
            this.DiemMax = diemMax;
            this.ParentId = parentId;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
            this.status = status;
        }
        public TieuChiDanhGiaDTO()
        {
            
        }
    }

}

