using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ql_diemrenluyen.DTO
{
    public class ChiTietDotChamDTO
    {
        public long Id { get; set; }
        public int Diem { get; set; }
        public int DotChamId { get; set; }
        public long ChiTietTieuChiId { get; set; }
        public long SinhVienId { get; set; }
        public long CoVanId { get; set; }
        public long KhoaId { get; set; }
        public int Final { get; set; }
        public int HocKiId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Constructor
        public ChiTietDotChamDTO(long id, int diem, int dotChamId, long chiTietTieuChiId, long sinhVienId, long coVanId, long khoaId, int final, int hocKiId, DateTime? createdAt, DateTime? updatedAt)
        {
            Id = id;
            Diem = diem;
            DotChamId = dotChamId;
            ChiTietTieuChiId = chiTietTieuChiId;
            SinhVienId = sinhVienId;
            CoVanId = coVanId;
            KhoaId = khoaId;
            Final = final;
            HocKiId = hocKiId;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public ChiTietDotChamDTO()
        {
        }
    }

}
