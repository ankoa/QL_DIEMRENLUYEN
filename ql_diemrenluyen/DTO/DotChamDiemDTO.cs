namespace ql_diemrenluyen.DTO
{
    public class DotChamDiemDTO
    {
        public int Id { get; set; }
        public int HocKiId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }

        // Constructor
        public DotChamDiemDTO(int id, int hocKiId, DateTime startDate, DateTime endDate, string name, int status)
        {
            Id = id;
            HocKiId = hocKiId;
            StartDate = startDate;
            EndDate = endDate;
            Name = name;
            Status = status;
        }
        public DotChamDiemDTO()
        {

        }
    }
}
