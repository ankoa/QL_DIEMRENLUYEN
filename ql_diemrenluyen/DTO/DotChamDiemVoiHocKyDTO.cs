namespace ql_diemrenluyen.DTO
{
    public class DotChamDiemVoiHocKyDTO
    {
        public int Id { get; set; }
        public string TenHocKy { get; set; }
        public string NamHoc { get; set; }
        public string TenDotChamDiem { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public DotChamDiemVoiHocKyDTO() { }

        public DotChamDiemVoiHocKyDTO(int id, string tenHocKy, string namHoc, string tenDotChamDiem, DateTime startDate, DateTime endDate)
        {
            Id = id;
            TenHocKy = tenHocKy;
            NamHoc = namHoc;
            TenDotChamDiem = tenDotChamDiem;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
