namespace ql_diemrenluyen.DTO
{
    public class HocKyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string namhoc { get; set; }
        public HocKyDTO() { }

        public HocKyDTO(int id, string name, string namhoc)
        {
            this.Id = id;
            this.Name = name;
            this.namhoc = namhoc;
        }
    }
}
