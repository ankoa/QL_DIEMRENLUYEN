using MySql.Data.MySqlClient;
using ql_diemrenluyen.DTO;
using System;
using System.Collections.Generic;

namespace ql_diemrenluyen.DAO
{
    public class CVHocTapDAO
    {
        // Lấy tất cả CV học tập
        public static List<CVHocTapDTO> GetAllCVHocTap()
        {
            List<CVHocTapDTO> cvHocTaps = new List<CVHocTapDTO>();
            string sql = "SELECT * FROM cv_hoc_tap";

            List<List<object>> result = DBConnection.ExecuteReader(sql);

            foreach (var row in result)
            {
                CVHocTapDTO cvHocTap = new CVHocTapDTO
                {
                    Id = Convert.ToInt64(row[0]), // Id
                    GiangVienId = Convert.ToInt64(row[1]), // GiangVienId
                    LopId = Convert.ToInt64(row[2]), // LopId
                    CreatedAt = row[3] != null ? Convert.ToDateTime(row[3]) : (DateTime?)null, // CreatedAt
                    UpdatedAt = row[4] != null ? Convert.ToDateTime(row[4]) : (DateTime?)null // UpdatedAt
                };

                cvHocTaps.Add(cvHocTap);
            }

            return cvHocTaps;
        }

        // Thêm CV học tập mới
        public static bool AddCVHocTap(CVHocTapDTO cvHocTap)
        {
            string sql = "INSERT INTO cv_hoc_tap (GiangVienId, LopId, CreatedAt, UpdatedAt) " +
                         "VALUES (@giangVienId, @lopId, @createdAt, @updatedAt)";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@giangVienId", cvHocTap.GiangVienId);
            cmd.Parameters.AddWithValue("@lopId", cvHocTap.LopId);
            cmd.Parameters.AddWithValue("@createdAt", cvHocTap.CreatedAt);
            cmd.Parameters.AddWithValue("@updatedAt", cvHocTap.UpdatedAt);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Cập nhật thông tin CV học tập
        public static bool UpdateCVHocTap(CVHocTapDTO cvHocTap)
        {
            string sql = "UPDATE cv_hoc_tap SET GiangVienId = @giangVienId, LopId = @lopId, " +
                         "CreatedAt = @createdAt, UpdatedAt = @updatedAt WHERE Id = @id";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", cvHocTap.Id);
            cmd.Parameters.AddWithValue("@giangVienId", cvHocTap.GiangVienId);
            cmd.Parameters.AddWithValue("@lopId", cvHocTap.LopId);
            cmd.Parameters.AddWithValue("@createdAt", cvHocTap.CreatedAt);
            cmd.Parameters.AddWithValue("@updatedAt", cvHocTap.UpdatedAt);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Xóa CV học tập
        public static bool DeleteCVHocTap(long id)
        {
            string sql = "DELETE FROM cv_hoc_tap WHERE Id = @id";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", id);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }
    }
}
