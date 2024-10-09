using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ql_diemrenluyen.DTO
{
    public class DiemDanhGiaDTO
    {
        public long Id { get; set; }
        public int Diem { get; set; }
        public long ChiTietTieuChiId { get; set; }
        public long SinhVienId { get; set; }
        public long GiangVienId { get; set; }
        public int HocKiId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public DiemDanhGiaDTO() { }

        public DiemDanhGiaDTO(long id, int diem, long chiTietTieuChiId, long sinhVienId, long giangVienId, int hocKiId, DateTime? createdAt, DateTime? updatedAt)
        {
            this.Id = id;
            this.Diem = diem;
            this.ChiTietTieuChiId = chiTietTieuChiId;
            this.SinhVienId = sinhVienId;
            this.GiangVienId = giangVienId;
            this.HocKiId = hocKiId;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
        }
    }
}
