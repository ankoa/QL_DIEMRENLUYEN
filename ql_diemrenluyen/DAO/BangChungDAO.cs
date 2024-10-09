using MySql.Data.MySqlClient;
using ql_diemrenluyen.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ql_diemrenluyen.DAO
{
    public class BangChungDAO
    {
        // Lấy tất cả bản chứng
        public static List<BangChungDTO> GetAllBangChung()
        {
            List<BangChungDTO> bangChungs = new List<BangChungDTO>();
            string sql = "SELECT * FROM bang_chung"; // Thay đổi câu lệnh SQL nếu cần

            List<List<object>> result = DBConnection.ExecuteReader(sql);

            foreach (var row in result)
            {
                BangChungDTO bangChung = new BangChungDTO
                {
                    Id = Convert.ToInt32(row[0]), // Id
                    SinhVienId = Convert.ToInt64(row[1]), // SinhVienId
                    ChiTietTieuChiId = Convert.ToInt64(row[2]), // ChiTietTieuChiId
                    LinkBangChung = Convert.ToString(row[3]), // LinkBangChung
                    CreatedAt = Convert.ToDateTime(row[4]) // CreatedAt
                };

                bangChungs.Add(bangChung);
            }

            return bangChungs;
        }

        // Thêm bản chứng mới
        public static bool AddBangChung(BangChungDTO bangChung)
        {
            string sql = $"INSERT INTO bang_chung (SinhVienId, ChiTietTieuChiId, LinkBangChung, CreatedAt) " +
                         $"VALUES (@sinhVienId, @chiTietTieuChiId, @linkBangChung, @createdAt)";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@sinhVienId", bangChung.SinhVienId);
            cmd.Parameters.AddWithValue("@chiTietTieuChiId", bangChung.ChiTietTieuChiId);
            cmd.Parameters.AddWithValue("@linkBangChung", bangChung.LinkBangChung);
            cmd.Parameters.AddWithValue("@createdAt", bangChung.CreatedAt);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Cập nhật thông tin bản chứng
        public static bool UpdateBangChung(BangChungDTO bangChung)
        {
            string sql = $"UPDATE bang_chung SET SinhVienId = @sinhVienId, ChiTietTieuChiId = @chiTietTieuChiId, " +
                         $"LinkBangChung = @linkBangChung, CreatedAt = @createdAt WHERE Id = @id";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", bangChung.Id);
            cmd.Parameters.AddWithValue("@sinhVienId", bangChung.SinhVienId);
            cmd.Parameters.AddWithValue("@chiTietTieuChiId", bangChung.ChiTietTieuChiId);
            cmd.Parameters.AddWithValue("@linkBangChung", bangChung.LinkBangChung);
            cmd.Parameters.AddWithValue("@createdAt", bangChung.CreatedAt);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Xóa bản chứng
        public static bool DeleteBangChung(int id)
        {
            string sql = $"DELETE FROM bang_chung WHERE Id = @id";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", id);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }
    }
}
