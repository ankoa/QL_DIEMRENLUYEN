using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ql_diemrenluyen.DTO
{
    public class BangChungDTO
    {
        public int Id { get; set; }
        public long SinhVienId { get; set; }
        public long ChiTietTieuChiId { get; set; }
        public string LinkBangChung { get; set; }
        public DateTime CreatedAt { get; set; }

        // Constructor
        public BangChungDTO(int id, long sinhVienId, long chiTietTieuChiId, string linkBangChung, DateTime createdAt)
        {
            Id = id;
            SinhVienId = sinhVienId;
            ChiTietTieuChiId = chiTietTieuChiId;
            LinkBangChung = linkBangChung;
            CreatedAt = createdAt;
        }

        public BangChungDTO()
        {
        }
    }
}
