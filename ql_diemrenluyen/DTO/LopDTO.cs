namespace ql_diemrenluyen.DTO
{
    public class LopDTO
    {
        public long Id { get; set; }
        public string TenLop { get; set; }
        public KhoaDTO? Khoa { get; set; }
        public HeHocDTO? HeDaoTao { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int status { get; set; }
        public int KhoaId { get; set; }
        public long? CoVanId { get; set; }
        public LopDTO() { }

        public LopDTO(long id, string tenLop, KhoaDTO khoa, HeHocDTO heDaoTao, DateTime? createdAt, DateTime? updatedAt, int status, int KhoaId, long coVanId)
        {
            this.Id = id;
            this.TenLop = tenLop;
            this.Khoa = Khoa;
            this.HeDaoTao = heDaoTao;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
            this.status = status;
            this.KhoaId = KhoaId;
            CoVanId = coVanId;
        }
    }
}
