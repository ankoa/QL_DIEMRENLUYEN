using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ql_diemrenluyen.DTO
{
    public class GiangVienDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string ChucVu { get; set; }
        public String KhoaId { get; set; }
        public bool TrangThai {get;set;}

        public GiangVienDTO() { }

        public GiangVienDTO(string id, string name, string email, DateTime? createdAt, DateTime? updatedAt, string ChucVu, string khoaId,bool TrangThai)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
            this.ChucVu = ChucVu;
            this.KhoaId = KhoaId;
            this.TrangThai = TrangThai;
        }
    }
}
