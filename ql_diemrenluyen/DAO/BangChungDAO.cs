using MySql.Data.MySqlClient;
using ql_diemrenluyen.DTO;
using System;
using System.Collections.Generic;
using System.Data;

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
                    SinhVienId = Convert.ToInt64(row[1]),
                    TieuchiDanhgiaId = Convert.ToInt64(row[2]),
                    LinkBangChung = Convert.ToString(row[3]),
                    CreatedAt = Convert.ToDateTime(row[4]), 
                    UpdatedAt = Convert.ToDateTime(row[5]),
                    Status = Convert.ToInt32(row[6]), 
                    HocKiID = Convert.ToInt32(row[7]), 

                };

                bangChungs.Add(bangChung);
            }

            return bangChungs;
        }

        public static bool AddBangChung(BangChungDTO bangChung)
        {
            string sql = $"INSERT INTO bangchung (sinhvien_id, tieuchidanhgia_id, linkbangchung, hocki_ID, status, createdAt, updatedAt) " +
                         $"VALUES (@sinhVienId, @tieuchiDanhGiaId, @linkBangChung, @hocKiId, @status, @createdAt, @updatedAt)";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@sinhVienId", bangChung.SinhVienId);
            cmd.Parameters.AddWithValue("@tieuchiDanhGiaId", bangChung.TieuchiDanhgiaId);
            cmd.Parameters.AddWithValue("@linkBangChung", bangChung.LinkBangChung);
            cmd.Parameters.AddWithValue("@hocKiId", bangChung.HocKiID);
            cmd.Parameters.AddWithValue("@status", bangChung.Status);
            cmd.Parameters.AddWithValue("@createdAt", bangChung.CreatedAt);
            cmd.Parameters.AddWithValue("@updatedAt", bangChung.UpdatedAt);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        public static bool UpdateBangChung(BangChungDTO bangChung)
        {
            string sql = $"UPDATE bangchung SET sinhvien_id = @sinhVienId, tieuchidanhgia_id = @tieuchiDanhGiaId, " +
                         $"linkbangchung = @linkBangChung, hocki_ID = @hocKiId, status = @status, createdAt = @createdAt, updatedAt = @updatedAt WHERE id = @id";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", bangChung.Id);
            cmd.Parameters.AddWithValue("@sinhVienId", bangChung.SinhVienId);
            cmd.Parameters.AddWithValue("@tieuchiDanhGiaId", bangChung.TieuchiDanhgiaId);
            cmd.Parameters.AddWithValue("@linkBangChung", bangChung.LinkBangChung);
            cmd.Parameters.AddWithValue("@hocKiId", bangChung.HocKiID);
            cmd.Parameters.AddWithValue("@status", bangChung.Status);
            cmd.Parameters.AddWithValue("@createdAt", bangChung.CreatedAt);
            cmd.Parameters.AddWithValue("@updatedAt", bangChung.UpdatedAt);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        public static bool DeleteBangChung(int id)
        {
            string sql = $"UPDATE bangchung SET status = 0 WHERE id = @id";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", id);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        public static List<BangChungDTO> SearchBangChung(long? tieuchiID, int status, string search, int? hocKiID)
        {
            List<BangChungDTO> bangChungs = new List<BangChungDTO>();

            string sql = @"
SELECT * FROM bangchung
WHERE
    (@status IS NULL OR status = @status)
    AND (@tieuchiID IS NULL OR tieuchidanhgia_id = @tieuchiID)
    AND (@hocKiID IS NULL OR hocki_ID = @hocKiID)
    AND (@search IS NULL 
         OR id LIKE CONCAT('%', @search, '%') 
         OR sinhvien_id LIKE CONCAT('%', @search, '%') )";

            MySqlCommand cmd = new MySqlCommand(sql);

            try
            {
                cmd.Parameters.AddWithValue("@status", status == -1 ? (object)DBNull.Value : status);
                cmd.Parameters.AddWithValue("@tieuchiID", tieuchiID == -1 ? (object)DBNull.Value : tieuchiID);
                cmd.Parameters.AddWithValue("@hocKiID", hocKiID == null ? (object)DBNull.Value : hocKiID);  // Thêm tham số hocKiID
                cmd.Parameters.AddWithValue("@search", string.IsNullOrEmpty(search) ? (object)DBNull.Value : search);

                List<List<object>> result = DBConnection.ExecuteReader(cmd);

                foreach (var row in result)
                {
                    BangChungDTO bangChung = new BangChungDTO
                    {
                        Id = Convert.ToInt32(row[0]), // Id
                        SinhVienId = Convert.ToInt64(row[1]),
                        TieuchiDanhgiaId = Convert.ToInt64(row[2]),
                        LinkBangChung = Convert.ToString(row[3]),
                        CreatedAt = Convert.ToDateTime(row[4]),
                        UpdatedAt = Convert.ToDateTime(row[5]),
                        Status = Convert.ToInt32(row[6]),
                        HocKiID = Convert.ToInt32(row[7]),
                    };

                    bangChungs.Add(bangChung);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi tìm kiếm bằng chứng: " + ex.Message);
            }
            finally
            {
                if (cmd.Connection != null && cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }
                cmd.Dispose();
            }

            return bangChungs;
        }

    }
}
