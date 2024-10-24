namespace ql_diemrenluyen.DTO
{
    public class DiemRenLuyenSinhVienDTO
    {
        public int Id { get; set; }
        public long? SinhVienId { get; set; } // Change from int? to long?
        public int? SemesterId { get; set; }
        public int? Score { get; set; }
        public string Comments { get; set; }

        public DiemRenLuyenSinhVienDTO() { }

        public DiemRenLuyenSinhVienDTO(int id, long? sinhVienId, int? semesterId, int? score, string comments) // Update constructor
        {
            this.Id = id;
            this.SinhVienId = sinhVienId;
            this.SemesterId = semesterId;
            this.Score = score;
            this.Comments = comments;
        }
    }
}
