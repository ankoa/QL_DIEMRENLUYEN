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
        public DateTime? NgaySinh { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int ChucVu { get; set; }
        public string KhoaId { get; set; }
        public int GioiTinh { get; set; }
        public int Status { get; set; }

        public GiangVienDTO() { }

        public GiangVienDTO(long id, string name, string email, DateTime? ngaySinh, DateTime? createdAt, DateTime? updatedAt, int chucVu, string khoaId, int gioiTinh, int status)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.NgaySinh = ngaySinh;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
            this.ChucVu = chucVu;
            this.KhoaId = khoaId;
            this.GioiTinh = gioiTinh;
            this.Status = status;
        }
    }
}
