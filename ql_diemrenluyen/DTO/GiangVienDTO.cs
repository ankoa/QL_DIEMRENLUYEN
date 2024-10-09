using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ql_diemrenluyen.DTO
{
    public class GiangVienDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Position { get; set; }
        public long KhoaId { get; set; }

        public GiangVienDTO() { }

        public GiangVienDTO(long id, string name, string email, DateTime? createdAt, DateTime? updatedAt, string position, long khoaId)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
            this.Position = position;
            this.KhoaId = khoaId;
        }
    }
}
