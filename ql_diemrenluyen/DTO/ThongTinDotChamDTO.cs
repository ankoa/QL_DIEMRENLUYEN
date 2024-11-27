using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ql_diemrenluyen.DTO
{
    public class ThongTinDotChamDTO
    {
        public long Id { get; set; }
        public int DotChamDiemId { get; set; }
        public long? CoVanId { get; set; }
        public long SinhVienId { get; set; }
        public long? KhoaId { get; set; }
        public int Final { get; set; }
        public int HoanThanh { get; set; }
        public int Status { get; set; }
        public int? KetQua { get; set; }  // Thêm trường KetQua (nullable)
        public string DanhGia { get; set; }  // Thêm trường DanhGia (nullable)

        public ThongTinDotChamDTO(long id, int dotChamDiemId, long? coVanId, long sinhVienId, long? khoaId, int final, int hoanThanh, int status, int? ketQua, string danhGia)
        {
            this.Id = id;
            this.DotChamDiemId = dotChamDiemId;
            this.CoVanId = coVanId;
            this.SinhVienId = sinhVienId;
            this.KhoaId = khoaId;
            this.Final = final;
            this.HoanThanh = hoanThanh;
            this.Status = status;
            this.KetQua = ketQua;
            this.DanhGia = danhGia;
        }

        public ThongTinDotChamDTO() { }
    }


}
