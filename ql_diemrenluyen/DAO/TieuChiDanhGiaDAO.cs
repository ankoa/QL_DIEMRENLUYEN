using MySql.Data.MySqlClient;
using ql_diemrenluyen.DTO;
using System;
using System.Collections.Generic;

namespace ql_diemrenluyen.DAO
{
    public class TieuChiDanhGiaDAO
    {
        // Lấy tất cả tiêu chí đánh giá
        public static List<TieuChiDanhGiaDTO> GetAllTieuChiDanhGia()
        {
            List<TieuChiDanhGiaDTO> tieuChiList = new List<TieuChiDanhGiaDTO>();
            string sql = "SELECT * FROM tieu_chi_danh_gia"; // Câu lệnh SQL

            List<List<object>> result = DBConnection.ExecuteReader(sql);

            foreach (var row in result)
            {
                TieuChiDanhGiaDTO tieuChi = new TieuChiDanhGiaDTO(
                    Convert.ToInt64(row[0]),
                    Convert.ToString(row[1]),
                    Convert.ToInt32(row[2]),
                    Convert.ToInt64(row[3]),
                    row[4] != null ? (DateTime?)Convert.ToDateTime(row[4]) : null,
                    row[5] != null ? (DateTime?)Convert.ToDateTime(row[5]) : null
                );

                tieuChiList.Add(tieuChi);
            }

            return tieuChiList;
        }

        // Thêm tiêu chí đánh giá mới
        public static bool AddTieuChiDanhGia(TieuChiDanhGiaDTO tieuChi)
        {
            string sql = "INSERT INTO tieu_chi_danh_gia (Name, DiemMax, ParentId, CreatedAt, UpdatedAt) VALUES (@name, @diemMax, @parentId, @createdAt, @updatedAt)";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@name", tieuChi.Name);
            cmd.Parameters.AddWithValue("@diemMax", tieuChi.DiemMax);
            cmd.Parameters.AddWithValue("@parentId", tieuChi.ParentId);
            cmd.Parameters.AddWithValue("@createdAt", tieuChi.CreatedAt);
            cmd.Parameters.AddWithValue("@updatedAt", tieuChi.UpdatedAt);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Cập nhật thông tin tiêu chí đánh giá
        public static bool UpdateTieuChiDanhGia(TieuChiDanhGiaDTO tieuChi)
        {
            string sql = "UPDATE tieu_chi_danh_gia SET Name = @name, DiemMax = @diemMax, ParentId = @parentId, CreatedAt = @createdAt, UpdatedAt = @updatedAt WHERE Id = @id";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", tieuChi.Id);
            cmd.Parameters.AddWithValue("@name", tieuChi.Name);
            cmd.Parameters.AddWithValue("@diemMax", tieuChi.DiemMax);
            cmd.Parameters.AddWithValue("@parentId", tieuChi.ParentId);
            cmd.Parameters.AddWithValue("@createdAt", tieuChi.CreatedAt);
            cmd.Parameters.AddWithValue("@updatedAt", tieuChi.UpdatedAt);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Xóa tiêu chí đánh giá
        public static bool DeleteTieuChiDanhGia(long id)
        {
            string sql = "DELETE FROM tieu_chi_danh_gia WHERE Id = @id";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", id);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }
    }
}
