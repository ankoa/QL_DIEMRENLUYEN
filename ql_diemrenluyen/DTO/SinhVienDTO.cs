namespace ql_diemrenluyen.DTO
{
    public class SinhVienDTO
    {
        private long id;
        private string name;
        private DateTime ngaySinh;
        private string email;
        private int gioiTinh;
        private long lopId;
        private int chucVu;
        private DateTime? createdAt; // Thay đổi thành DateTime?
        private DateTime? updatedAt; // Thay đổi thành DateTime?

        // Constructor
        public SinhVienDTO() { }

        public SinhVienDTO(long id, string name, DateTime ngaySinh, string email, int gioiTinh, long lopId, int chucVu, DateTime? createdAt, DateTime? updatedAt)
        {
            this.id = id;
            this.name = name;
            this.ngaySinh = ngaySinh;
            this.email = email;
            this.gioiTinh = gioiTinh;
            this.lopId = lopId;
            this.chucVu = chucVu;
            this.createdAt = createdAt;  // Gán giá trị
            this.updatedAt = updatedAt;  // Gán giá trị
        }

        public String toStringGender()
        {
            if (gioiTinh == 1) return "Nam";
            return "Nữ";
        }

        // Getters và Setters
        public long Id { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public DateTime NgaySinh { get { return ngaySinh; } set { ngaySinh = value; } }
        public string Email { get { return email; } set { email = value; } }
        public int GioiTinh { get { return gioiTinh; } set { gioiTinh = value; } }
        public long LopId { get { return lopId; } set { lopId = value; } }
        public int ChucVu { get { return chucVu; } set { chucVu = value; } }
        public DateTime? CreatedAt { get { return createdAt; } set { createdAt = value; } }  // Sử dụng DateTime? cho nullable
        public DateTime? UpdatedAt { get { return updatedAt; } set { updatedAt = value; } }  // Sử dụng DateTime? cho nullable
    }
}
