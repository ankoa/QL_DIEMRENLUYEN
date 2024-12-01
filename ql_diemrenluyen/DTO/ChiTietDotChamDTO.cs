namespace ql_diemrenluyen.DTO
{
    public class ChiTietDotChamDTO
    {
        public long Id { get; set; } // Id
        public int Diem { get; set; } // Điểm
        public long ThongTinDotChamDiemId { get; set; } // Thông tin đợt chấm điểm
        public long TieuchiDanhgiaId { get; set; } // Tiêu chí đánh giá
        public DateTime? CreatedAt { get; set; } // Thời gian tạo
        public DateTime? UpdatedAt { get; set; } // Thời gian cập nhật
        public int Status { get; set; } // Trạng thái
        public string? ImageUrl { get; set; } // URL hình ảnh (có thể null)
        public string? MoTa { get; set; } // Mô tả (có thể null)

        // Constructor
        public ChiTietDotChamDTO(long id, int diem, long thongTinDotChamDiemId, long tieuchiDanhgiaId, DateTime? createdAt, DateTime? updatedAt, int status, string? imageUrl, string? moTa)
        {
            Id = id;
            Diem = diem;
            ThongTinDotChamDiemId = thongTinDotChamDiemId;
            TieuchiDanhgiaId = tieuchiDanhgiaId;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Status = status;
            ImageUrl = imageUrl;
            MoTa = moTa;
        }

        // Constructor mặc định
        public ChiTietDotChamDTO() { }
    }
}
