namespace ql_diemrenluyen.DTO
{
    public class DiemRenLuyenSinhVienDTO
    {
        public int Id { get; set; }
        public int? SinhVienId { get; set; }
        public int? SemesterId { get; set; }
        public int? Score { get; set; }
        public string Comments { get; set; }

        public DiemRenLuyenSinhVienDTO() { }

        public DiemRenLuyenSinhVienDTO(int id, int? sinhVienId, int? semesterId, int? score, string comments)
        {
            this.Id = id;
            this.SinhVienId = sinhVienId;
            this.SemesterId = semesterId;
            this.Score = score;
            this.Comments = comments;
        }
    }
}
