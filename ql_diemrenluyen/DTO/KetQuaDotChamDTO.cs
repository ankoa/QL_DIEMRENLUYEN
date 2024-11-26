using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace ql_diemrenluyen.DTO
{
    public class KetQuaDotChamDTO
    {
        public int Id { get; set; }
        public long ThongTinDotChamDiemId { get; set; }
        public int KetQua { get; set; }
        public string DanhGia { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Status { get; set; }

        public KetQuaDotChamDTO(int id, long thongTinDotChamDiemId, int ketQua, string danhGia, DateTime createdAt, int status)
        {
            Id = id;
            ThongTinDotChamDiemId = thongTinDotChamDiemId;
            KetQua = ketQua;
            DanhGia = danhGia;
            CreatedAt = createdAt;
            Status = status;
        }
    }
}

