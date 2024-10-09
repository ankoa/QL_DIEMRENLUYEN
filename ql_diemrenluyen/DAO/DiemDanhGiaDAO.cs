using MySql.Data.MySqlClient;
using ql_diemrenluyen.DTO;
using System;
using System.Collections.Generic;

namespace ql_diemrenluyen.DAO
{
    public class DiemDanhGiaDAO
    {
        // Lấy tất cả điểm đánh giá
        public static List<DiemDanhGiaDTO> GetAllDiemDanhGia()
        {
            List<DiemDanhGiaDTO> diemDanhGias = new List<DiemDanhGiaDTO>();
            string sql = "SELECT * FROM diem_danh_gia";

            List<List<object>> result = DBConnection.ExecuteReader(sql);

            foreach (var row in result)
            {
                DiemDanhGiaDTO diemDanhGia = new DiemDanhGiaDTO
                {
                    Id = Convert.ToInt64(row[0]), // Id
                    Diem = Convert.ToInt32(row[1]), // Diem
                    ChiTietTieuChiId = Convert.ToInt64(row[2]), // ChiTietTieuChiId
                    SinhVienId = Convert.ToInt64(row[3]), // SinhVienId
                    GiangVienId = Convert.ToInt64(row[4]), // GiangVienId
                    HocKiId = Convert.ToInt32(row[5]), // HocKiId
                    CreatedAt = row[6] != null ? Convert.ToDateTime(row[6]) : (DateTime?)null, // CreatedAt
                    UpdatedAt = row[7] != null ? Convert.ToDateTime(row[7]) : (DateTime?)null // UpdatedAt
                };

                diemDanhGias.Add(diemDanhGia);
            }

            return diemDanhGias;
        }

        // Thêm điểm đánh giá mới
        public static bool AddDiemDanhGia(DiemDanhGiaDTO diemDanhGia)
        {
            string sql = "INSERT INTO diem_danh_gia (Diem, ChiTietTieuChiId, SinhVienId, GiangVienId, HocKiId, CreatedAt, UpdatedAt) " +
                         "VALUES (@diem, @chiTietTieuChiId, @sinhVienId, @giangVienId, @hocKiId, @createdAt, @updatedAt)";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@diem", diemDanhGia.Diem);
            cmd.Parameters.AddWithValue("@chiTietTieuChiId", diemDanhGia.ChiTietTieuChiId);
            cmd.Parameters.AddWithValue("@sinhVienId", diemDanhGia.SinhVienId);
            cmd.Parameters.AddWithValue("@giangVienId", diemDanhGia.GiangVienId);
            cmd.Parameters.AddWithValue("@hocKiId", diemDanhGia.HocKiId);
            cmd.Parameters.AddWithValue("@createdAt", diemDanhGia.CreatedAt);
            cmd.Parameters.AddWithValue("@updatedAt", diemDanhGia.UpdatedAt);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Cập nhật thông tin điểm đánh giá
        public static bool UpdateDiemDanhGia(DiemDanhGiaDTO diemDanhGia)
        {
            string sql = "UPDATE diem_danh_gia SET Diem = @diem, ChiTietTieuChiId = @chiTietTieuChiId, " +
                         "SinhVienId = @sinhVienId, GiangVienId = @giangVienId, HocKiId = @hocKiId, " +
                         "CreatedAt = @createdAt, UpdatedAt = @updatedAt WHERE Id = @id";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", diemDanhGia.Id);
            cmd.Parameters.AddWithValue("@diem", diemDanhGia.Diem);
            cmd.Parameters.AddWithValue("@chiTietTieuChiId", diemDanhGia.ChiTietTieuChiId);
            cmd.Parameters.AddWithValue("@sinhVienId", diemDanhGia.SinhVienId);
            cmd.Parameters.AddWithValue("@giangVienId", diemDanhGia.GiangVienId);
            cmd.Parameters.AddWithValue("@hocKiId", diemDanhGia.HocKiId);
            cmd.Parameters.AddWithValue("@createdAt", diemDanhGia.CreatedAt);
            cmd.Parameters.AddWithValue("@updatedAt", diemDanhGia.UpdatedAt);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Xóa điểm đánh giá
        public static bool DeleteDiemDanhGia(long id)
        {
            string sql = "DELETE FROM diem_danh_gia WHERE Id = @id";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", id);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }
    }
}
