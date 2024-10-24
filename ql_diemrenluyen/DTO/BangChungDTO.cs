using System;

namespace ql_diemrenluyen.DTO
{
    public class BangChungDTO
    {
        public int Id { get; set; }
        public long SinhVienId { get; set; }
        public long TieuchiDanhgiaId { get; set; }
        public string LinkBangChung { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; } 

        // Constructor
        public BangChungDTO(int id, long sinhVienId, long tieuchiDanhgiaId, string linkBangChung, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            SinhVienId = sinhVienId;
            TieuchiDanhgiaId = tieuchiDanhgiaId; 
            LinkBangChung = linkBangChung;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public BangChungDTO()
        {
        }
    }
}
