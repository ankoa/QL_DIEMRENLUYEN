using MySql.Data.MySqlClient;
using ql_diemrenluyen.DTO;
using System;
using System.Collections.Generic;

namespace ql_diemrenluyen.DAO
{
    public class BangChungDAO
    {
        // Lấy tất cả bản chứng
        public static List<BangChungDTO> GetAllBangChung()
        {
            List<BangChungDTO> bangChungs = new List<BangChungDTO>();
            string sql = "SELECT * FROM bangchung"; // Thay đổi câu lệnh SQL nếu cần

            List<List<object>> result = DBConnection.ExecuteReader(sql);

            foreach (var row in result)
            {
                BangChungDTO bangChung = new BangChungDTO
                {
                    Id = Convert.ToInt32(row[0]), // Id
                    SinhVienId = Convert.ToInt64(row[1]), // SinhVienId
                    TieuchiDanhgiaId = Convert.ToInt64(row[2]), // TieuchiDanhgiaId
                    LinkBangChung = Convert.ToString(row[3]), // LinkBangChung
                    CreatedAt = Convert.ToDateTime(row[4]), // CreatedAt
                    UpdatedAt = Convert.ToDateTime(row[5]) // UpdatedAt
                };

                bangChungs.Add(bangChung);
            }

            return bangChungs;
        }

        // Thêm bản chứng mới
        public static bool AddBangChung(BangChungDTO bangChung)
        {
            string sql = $"INSERT INTO bangchung (sinhvien_id, tieuchidanhgia_id, linkbangchung, createdAt, updatedAt) " +
                         $"VALUES (@sinhVienId, @tieuchiDanhGiaId, @linkBangChung, @createdAt, @updatedAt)";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@sinhVienId", bangChung.SinhVienId);
            cmd.Parameters.AddWithValue("@tieuchiDanhGiaId", bangChung.TieuchiDanhgiaId);
            cmd.Parameters.AddWithValue("@linkBangChung", bangChung.LinkBangChung);
            cmd.Parameters.AddWithValue("@createdAt", bangChung.CreatedAt);
            cmd.Parameters.AddWithValue("@updatedAt", bangChung.UpdatedAt);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Cập nhật thông tin bản chứng
        public static bool UpdateBangChung(BangChungDTO bangChung)
        {
            string sql = $"UPDATE bangchung SET sinhvien_id = @sinhVienId, tieuchidanhgia_id = @tieuchiDanhGiaId, " +
                         $"linkbangchung = @linkBangChung, createdAt = @createdAt, updatedAt = @updatedAt WHERE id = @id";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", bangChung.Id);
            cmd.Parameters.AddWithValue("@sinhVienId", bangChung.SinhVienId);
            cmd.Parameters.AddWithValue("@tieuchiDanhGiaId", bangChung.TieuchiDanhgiaId);
            cmd.Parameters.AddWithValue("@linkBangChung", bangChung.LinkBangChung);
            cmd.Parameters.AddWithValue("@createdAt", bangChung.CreatedAt);
            cmd.Parameters.AddWithValue("@updatedAt", bangChung.UpdatedAt);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Xóa bản chứng
        public static bool DeleteBangChung(int id)
        {
            string sql = $"DELETE FROM bangchung WHERE id = @id";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", id);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }
    }
}
