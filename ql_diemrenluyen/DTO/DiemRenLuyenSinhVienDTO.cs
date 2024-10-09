using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ql_diemrenluyen.DTO
{
    public class DiemRenLuyenSinhVienDTO
    {
        public int Id { get; set; }
        public int? SinhVienId { get; set; }
        public int? SemesterId { get; set; }
        public decimal? Score { get; set; }
        public string Comments { get; set; }

        public DiemRenLuyenSinhVienDTO() { }

        public DiemRenLuyenSinhVienDTO(int id, int? sinhVienId, int? semesterId, decimal? score, string comments)
        {
            this.Id = id;
            this.SinhVienId = sinhVienId;
            this.SemesterId = semesterId;
            this.Score = score;
            this.Comments = comments;
        }
    }
}
