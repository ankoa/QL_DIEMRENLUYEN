using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ql_diemrenluyen.DTO
{
    internal class ChuThichTieuChiDTO
    {
        public int Id { get; set; }
        public long TieuChiDanhGiaId { get; set; }
        public string Name { get; set; }
        public int Diem { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int Status { get; set; }

        public ChuThichTieuChiDTO(int id, long tieuChiDanhGiaId, string name, int diem, DateTime createdAt, DateTime updatedAt, int status)
        {
            Id = id;
            TieuChiDanhGiaId = tieuChiDanhGiaId;
            Name = name;
            Diem = diem;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Status = status;
        }
    }
}

